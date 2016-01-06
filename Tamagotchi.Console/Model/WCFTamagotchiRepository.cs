using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Console.TamagotchiService;

namespace Tamagotchi.Console.Model
{
    class WCFTamagotchiRepository : ITamagotchiRepository
    {
        TamagotchiServiceClient service;

        public WCFTamagotchiRepository()
        {
            service = new TamagotchiServiceClient("BasicHttpsBinding_ITamagotchiService");
        }

        public TamagotchiContract Get(string name)
        {
            return service.GetTamagotchiByName(name);
        }

        public TamagotchiContract Get(int id)
        {
            return service.GetTamagotchiById(id);
        }

        public TamagotchiContract[] GetAll()
        {
            return service.GetAllTamagotchi();
        }

        public bool Sleep(string name)
        {
            return service.SleepByName(name);
        }

        public bool Eat(string name)
        {
            return service.EatByName(name);
        }

        public bool Hug(string name)
        {
            return service.HugByName(name);
        }

        public bool Workout(string name)
        {
            return service.WorkoutByName(name);
        }

        public bool Play(string name)
        {
            return service.PlayByName(name);
        }

        public bool Add(string name)
        {
            return service.AddTamagotchi(name).WasCreated;
        }

        public bool HasData()
        {
            try
            {                
                return service.IsRunning();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string WhereAmI()
        {
            return service.Endpoint.Address.Uri.ToString();
        }

        public bool SetRule(string name, string ruleName, bool setActive)
        {
            if (setActive)
                return service.ActivateRuleForTamagotchiByName(name, ruleName);

            return service.DactivateRuleForTamagotchiByName(name, ruleName);
        }
    }
}
