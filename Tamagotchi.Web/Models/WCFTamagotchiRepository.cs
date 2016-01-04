using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Web.TamagotchiService;

namespace Tamagotchi.Web.Models
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

        public Task<TamagotchiContract[]> GetAllAsync()
        {
            return service.GetAllTamagotchiAsync();
        }

        public bool Sleep(int id)
        {
            return service.SleepById(id);
        }

        public bool Eat(int id)
        {
            return service.EatById(id);
        }

        public bool Hug(int id)
        {
            return service.HugById(id);
        }

        public bool Workout(int id)
        {
            return service.WorkoutById(id);
        }

        public bool Play(int id)
        {
            return service.PlayById(id);
        }

        public bool Add(string name)
        {
            return service.AddTamagotchi(name);
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

        public bool ValidId(int id)
        {
            return service.ValidId(id);
        }

        public bool ValidName(string name)
        {
            return service.ValidName(name);
        }

        public bool SetRuleForTamagotchi(int tamagotchiId, string ruleName, bool setActive)
        {
            if(setActive)
            {
                return service.ActivateRuleForTamagotchiById(tamagotchiId, ruleName);
            }

            return service.DactivateRuleForTamagotchiById(tamagotchiId, ruleName);
        }
    }
}
