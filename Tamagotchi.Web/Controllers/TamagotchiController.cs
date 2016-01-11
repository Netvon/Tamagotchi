using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Tamagotchi.Web.Models;

namespace Tamagotchi.Web.Controllers
{
    [RoutePrefix("overview")]
    [Route("{action=index}")]
    public class TamagotchiController : Controller
    {
        // GET: Tamagotchi
        [Route("{page?}")]
        public async Task<ActionResult> Index(int page = 0)
        {
            ITamagotchiRepository repo = GetRepo();

            var tamagotchiContract = await repo.GetAllAsync();

            int per_page = 10;
            int all_count = tamagotchiContract.Count();
            int page_num = (int)Math.Ceiling(all_count / (double)per_page);

            if (page > page_num)
                page = page_num;

            if (page < 0)
                page = 0;

            var param = new TamagotchiOverviewModel(tamagotchiContract.Skip(per_page * page).Take(per_page), page, page_num);

            return View(param);
        }

        [Route("~/show/{id}")]
        public async Task<ActionResult> Show(int id)
        {
            if(id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = await repo.GetAsync(id);

            if(tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            return View(tama);
        }

        [Route("~/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = await repo.GetAsync(id);

            if (tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            int in_id = id;

            if (!tama.HasDied)
                return RedirectToAction("DeleteError", "Tamagotchi", new { id = in_id });

            await repo.RemoveAsync(id);

            return RedirectToAction("Index", "Tamagotchi");
        }

        [Route("~/find")]
        public async Task<ActionResult> DetailsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = await repo.GetAsync(name);

            if (tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            return RedirectToAction("Show", "Tamagotchi", new { id = tama.ID });
        }

        [Route("~/show/{id}/eat")]
        public async Task<ActionResult> Eat(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().EatAsync(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }          

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/sleep")]
        public async Task<ActionResult> Sleep(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().SleepAsync(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/hug")]
        public async Task<ActionResult> Hug(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().HugAsync(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/workout")]
        public async Task<ActionResult> Workout(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().WorkoutAsync(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/play")]
        public async Task<ActionResult> Play(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().PlayAsync(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/rule")]
        public async Task<ActionResult> SetRule(int id, string ruleName, bool setActive)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (await GetRepo().IsValidIdAsync(id))
            {
                await GetRepo().SetRuleForTamagotchiAsync(id, ruleName, setActive);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/error")]
        public ActionResult Error()
        {
            return View();
        }

        [Route("~/delete/error")]
        public ActionResult DeleteError(int? id)
        {
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/create")]
        public async Task<ActionResult> Create(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return RedirectToAction("CreateError", controllerName: "Tamagotchi");

            var createContract = await GetRepo().AddAsync(name);

            if (createContract.WasCreated)
                return RedirectToAction("Show", "Tamagotchi", new { id = createContract.CreatedId });
            else
                return RedirectToAction("CreateError", controllerName: "Tamagotchi");
        }

        [Route("~/create/error")]
        public ActionResult CreateError()
        {
            return View("CreateError");
        }

        ITamagotchiRepository GetRepo()
        {
            if (Session[nameof(ITamagotchiRepository)] == null)
            {
                IKernel kernel = new StandardKernel(new WebModule());
                var repo = kernel.Get<ITamagotchiRepository>();

                Session[nameof(ITamagotchiRepository)] = repo;

                return repo;
            }

            return Session[nameof(ITamagotchiRepository)] as ITamagotchiRepository;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            const string Timezone = "timezoneoffset";
            if (HttpContext.Request.Cookies.AllKeys.Contains(Timezone))
            {
                Session[Timezone] =
                    HttpContext.Request.Cookies[Timezone].Value;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}