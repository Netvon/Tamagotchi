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

            return View(await repo.GetAllAsync());
        }

        [Route("~/show/{id}")]
        public ActionResult Show(int id)
        {
            //if (TempData["ID"] != null)
            //    id = Convert.ToInt32(TempData["ID"]);

            if(id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = repo.Get(id);

            if(tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            return View(tama);
        }

        [Route("~/find")]
        public ActionResult DetailsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Error", "Tamagotchi");

            var repo = GetRepo();

            var tama = repo.Get(name);

            if (tama == null)
                return RedirectToAction("Error", "Tamagotchi");

            //TempData["ID"] = tama.ID;

            return RedirectToAction("Show", "Tamagotchi", new { id = tama.ID });
        }

        [Route("~/show/{id}/eat")]
        public ActionResult Eat(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().Eat(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/sleep")]
        public ActionResult Sleep(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().Sleep(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/hug")]
        public ActionResult Hug(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().Hug(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/workout")]
        public ActionResult Workout(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().Workout(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/play")]
        public ActionResult Play(int id)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().Play(id);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/{id}/rule/{setActive}")]
        public ActionResult SetRule(int id, string ruleName, bool setActive)
        {
            if (id <= 0)
                return RedirectToAction("Error", "Tamagotchi");

            if (GetRepo().ValidId(id))
            {
                GetRepo().SetRuleForTamagotchi(id, ruleName, setActive);

                return RedirectToAction("Show", "Tamagotchi", new { id });
            }

            return RedirectToAction("Error", "Tamagotchi");
        }

        [Route("~/show/error")]
        public ActionResult Error()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name)
        {
            var wasCreated = GetRepo().Add(name);
            return RedirectToAction("Index");
        }

        static ITamagotchiRepository GetRepo()
        {
            IKernel kernel = new StandardKernel(new WebModule());
            var repo = kernel.Get<ITamagotchiRepository>();
            return repo;
        }
    }
}