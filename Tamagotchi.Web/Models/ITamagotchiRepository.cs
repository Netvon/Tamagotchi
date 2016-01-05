using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Web.TamagotchiService;

namespace Tamagotchi.Web.Models
{
    interface ITamagotchiRepository
    {
        Task<TamagotchiContract> GetAsync(string name);
        Task<TamagotchiContract> GetAsync(int id);
        Task<TamagotchiContract[]> GetAllAsync();

        Task<bool> SleepAsync(int id);
        Task<bool> EatAsync(int id);
        Task<bool> HugAsync(int id);
        Task<bool> WorkoutAsync(int id);
        Task<bool> PlayAsync(int id);

        Task<bool> AddAsync(string name);

        Task<bool> HasDataAsync();

        string WhereAmI();

        Task<bool> IsValidIdAsync(int id);
        Task<bool> IsValidNameAsync(string name);

        Task<bool> SetRuleForTamagotchiAsync(int tamagotchiId, string ruleName, bool setActive);
    }
}