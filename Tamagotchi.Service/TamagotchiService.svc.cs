using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tamagotchi.Service.Model;

namespace Tamagotchi.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
        readonly ITamagotchiRepository repo;

        public TamagotchiService()
        {
            IKernel kernel = new StandardKernel(new TamagotchiModule());
            repo = kernel.Get<ITamagotchiRepository>();
        }

        public bool ActivateRuleForTamagotchi(string tamagotchiName, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiName), ruleName, true);
        }

        bool SetIsActiveForRule(Domain.Tamagotchi tama, string ruleName, bool value)
        {
            if (tama == null)
                return false;

            var rule = tama.TamagotchiRules.FirstOrDefault(r => r.RuleName == ruleName);

            if (rule == null)
                return false;

            rule.IsActive = value;

            if (!value)
                rule.Rule.Deactivate(tama);

            repo.SaveChanges();
            return true;
        }

        public bool AddTamagotchi(string name)
        {
            return repo.Add(name);
        }

        public bool DectivateRuleForTamagotchi(string tamagotchiName, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiName), ruleName, false);
        }

        public bool Eat(string name)
        {
            return Eat(repo.Get(name));
        }

        public bool Eat(int id)
        {
            return Eat(repo.Get(id));
        }

        bool Eat(Domain.Tamagotchi tama)
        {
            if (tama == null)
                return false;

            if (tama.EatAction(DateTime.UtcNow))
                return repo.SaveChanges();

            return false;
        }

        public IEnumerable<TamagotchiContract> GetAllTamagotchi()
        {
            return repo.GetAll().Select(t => new TamagotchiContract(t));
        }

        public TamagotchiContract GetTamagotchi(string name)
        {
            var tamagotchi = repo.Get(name);

            if (tamagotchi != null)
                return new TamagotchiContract(tamagotchi);

            return null;
        }

        public bool Hug(string name)
        {
            return Hug(repo.Get(name));
        }

        public bool Hug(int id)
        {
            return Hug(repo.Get(id));
        }

        bool Hug(Domain.Tamagotchi tama)
        {
            if (tama == null)
                return false;

            if (tama.HugAction(DateTime.UtcNow))
                return repo.SaveChanges();

            return false;
        }

        public bool Play(string name)
        {
            return Play(repo.Get(name));
        }

        public bool Play(int id)
        {
            return Play(repo.Get(id));
        }

        bool Play(Domain.Tamagotchi tama)
        {
            if (tama == null)
                return false;

            if (tama.PlayAction(DateTime.UtcNow))
                return repo.SaveChanges();

            return false;
        }

        public bool RemoveTamagotchi(string name)
        {
            return repo.Remove(name);
        }

        public bool Sleep(string name)
        {
            return Sleep(repo.Get(name));
        }

        public bool Sleep(int id)
        {
            return Sleep(repo.Get(id));
        }

        bool Sleep(Domain.Tamagotchi tama)
        {
            if (tama == null)
                return false;

            if (tama.SleepAction(DateTime.UtcNow))
                return repo.SaveChanges();

            return false;
        }

        public bool Workout(string name)
        {
            return Workout(repo.Get(name));
        }

        public bool Workout(int id)
        {
            return Workout(repo.Get(id));
        }

        bool Workout(Domain.Tamagotchi tama)
        {
            if (tama == null)
                return false;

            if (tama.WorkoutAction(DateTime.UtcNow))
                return repo.SaveChanges();

            return false;
        }

        public bool IsRunning() => true;

        public TamagotchiContract GetTamagotchi(int id)
        {
            var tamagotchi = repo.Get(id);

            if (tamagotchi != null)
                return new TamagotchiContract(tamagotchi);

            return null;
        }

        public bool ActivateRuleForTamagotchi(int tamagotchiId, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiId), ruleName, true);
        }

        public bool DectivateRuleForTamagotchi(int tamagotchiId, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiId), ruleName, false);
        }

        public bool ValidId(int id)
        {
            return repo.ValidId(id);
        }

        public bool ValidName(string name)
        {
            return repo.ValidName(name);
        }
    }
}
