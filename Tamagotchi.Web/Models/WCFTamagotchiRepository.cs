using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Tamagotchi.Web.TamagotchiService;

namespace Tamagotchi.Web.Models
{
    class WCFTamagotchiRepository : ITamagotchiRepository
    {
        readonly TamagotchiServiceClient service;

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

        public Task<TamagotchiContract[]> GetAllAsync(int start)
        {
            return service.GetAllTamagotchiAsync(start);
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

        public Task<bool> IsKnownIdAsync(int id)
        {
            return service.IsKnownIdAsync(id);
        }

        public Task<bool> IsKnownNameAsync(string name)
        {
            return service.IsKnownNameAsync(name);
        }

        public Task<bool> SetRuleForTamagotchiAsync(int tamagotchiId, string ruleName, bool setActive)
        {
            if (setActive)
            {
                return service.ActivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
            }

            return service.DeactivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
        }

        public Task<bool> RemoveAsync(int id)
        {
            return service.RemoveTamagotchiByIdAsync(id);
        }

        public Task<int> TamagotchiPerPageAsync()
        {
            return service.TamagotchiPerPageAsync();
        }

        public Task<int> TamagotchiCountAsync()
        {
            return service.TamagotchiCountAsync();
        }
    }
}
