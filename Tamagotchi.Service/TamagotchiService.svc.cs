﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using Tamagotchi.Service.Model;

namespace Tamagotchi.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
        private const int TamgotchiPerPage = 10;
        readonly ITamagotchiRepository repo;

        public TamagotchiService()
        {
            var kernel = new StandardKernel(new TamagotchiModule());
            repo = kernel.Get<ITamagotchiRepository>();
        }

        public bool ActivateRuleForTamagotchiByName(string tamagotchiName, string ruleName)
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

        public CreateContract AddTamagotchi(string name)
        {
            return new CreateContract(repo.Add(name));
        }

        public bool DeactivateRuleForTamagotchiByName(string tamagotchiName, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiName), ruleName, false);
        }

        public bool EatByName(string name)
        {
            return Eat(repo.Get(name));
        }

        public bool EatById(int id)
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

        public IEnumerable<TamagotchiContract> GetAllTamagotchi(int start)
        {
            return repo.GetAll(start, TamgotchiPerPage).Select(t => new TamagotchiContract(t));
        }

        public int TamagotchiPerPage()
        {
            return TamgotchiPerPage;
        }

        public TamagotchiContract GetTamagotchiByName(string name)
        {
            var tamagotchi = repo.Get(name);

            if (tamagotchi != null)
                return new TamagotchiContract(tamagotchi);

            return null;
        }

        public bool HugByName(string name)
        {
            return Hug(repo.Get(name));
        }

        public bool HugById(int id)
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

        public bool PlayByName(string name)
        {
            return Play(repo.Get(name));
        }

        public bool PlayById(int id)
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

        public bool RemoveTamagotchiByName(string name)
        {
            return repo.Remove(name);
        }

        public bool RemoveTamagotchiById(int id)
        {
            return repo.Remove(id);
        }

        public bool SleepByName(string name)
        {
            return Sleep(repo.Get(name));
        }

        public bool SleepById(int id)
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

        public bool WorkoutByName(string name)
        {
            return Workout(repo.Get(name));
        }

        public bool WorkoutById(int id)
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

        public TamagotchiContract GetTamagotchiById(int id)
        {
            var tamagotchi = repo.Get(id);

            if (tamagotchi != null)
                return new TamagotchiContract(tamagotchi);

            return null;
        }

        public bool ActivateRuleForTamagotchiById(int tamagotchiId, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiId), ruleName, true);
        }

        public bool DeactivateRuleForTamagotchiById(int tamagotchiId, string ruleName)
        {
            return SetIsActiveForRule(repo.Get(tamagotchiId), ruleName, false);
        }

        public bool IsKnownId(int id)
        {
            return repo.IsKnownId(id);
        }

        public bool IsKnownName(string name)
        {
            return repo.IsKnownName(name);
        }

        public int TamagotchiCount()
        {
            return repo.TamgotchiCount();
        }
    }
}
