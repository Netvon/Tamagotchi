using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tamagotchi.Web.Models;

namespace Tamagotchi.Web.Controllers
{
    [RoutePrefix("overview")]
    [Route("{action=index}")]
    public class TamagotchiController : Controller
    {
        // GET: Tamagotchi
        public async Task<ActionResult> Index()
        {
            ITamagotchiRepository repo = GetRepo();

            var tamagotchiContract = await repo.GetAllAsync();

            return View(tamagotchiContract);
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

        [Route("~/find")]
        public async Task<ActionResult> DetailsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = await repo.GetAsync(name);

            if (tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            //TempData["ID"] = tama.ID;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/create")]
        public async Task<ActionResult> Create(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return CreateError();

            var createContract = await GetRepo().AddAsync(name);

            if (createContract.WasCreated)
                return RedirectToAction("Show", "Tamagotchi", new { id = createContract.CreatedId });
            else
                return CreateError();
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
            if (HttpContext.Request.Cookies.AllKeys.Contains("timezoneoffset"))
            {
                Session["timezoneoffset"] =
                    HttpContext.Request.Cookies["timezoneoffset"].Value;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}