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

        public Task<TamagotchiContract> GetAsync(string name)
        {
            return service.GetTamagotchiByNameAsync(name);
        }

        public Task<TamagotchiContract> GetAsync(int id)
        {
            return service.GetTamagotchiByIdAsync(id);
        }

        public Task<TamagotchiContract[]> GetAllAsync()
        {
            return service.GetAllTamagotchiAsync();
        }

        public Task<bool> SleepAsync(int id)
        {
            return service.SleepByIdAsync(id);
        }

        public Task<bool> EatAsync(int id)
        {
            return service.EatByIdAsync(id);
        }

        public Task<bool> HugAsync(int id)
        {
            return service.HugByIdAsync(id);
        }

        public Task<bool> WorkoutAsync(int id)
        {
            return service.WorkoutByIdAsync(id);
        }

        public Task<bool> PlayAsync(int id)
        {
            return service.PlayByIdAsync(id);
        }

        public Task<CreateContract> AddAsync(string name)
        {
            return service.AddTamagotchiAsync(name);
        }

        public Task<bool> HasDataAsync()
        {
            try
            {                
                return service.IsRunningAsync();
            }
            catch (Exception)
            {
                return new Task<bool>(() => false);
            }
        }

        public string WhereAmI()
        {
            return service.Endpoint.Address.Uri.ToString();
        }

        public Task<bool> IsValidIdAsync(int id)
        {
            return service.ValidIdAsync(id);
        }

        public Task<bool> IsValidNameAsync(string name)
        {
            return service.ValidNameAsync(name);
        }

        public Task<bool> SetRuleForTamagotchiAsync(int tamagotchiId, string ruleName, bool setActive)
        {
            if(setActive)
            {
                return service.ActivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
            }

            return service.DactivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
        }
    }
}
