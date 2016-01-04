using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Web.TamagotchiService;

namespace Tamagotchi.Web.Models
{
    interface ITamagotchiRepository
    {
        TamagotchiContract Get(string name);
        TamagotchiContract Get(int id);
        Task<TamagotchiContract[]> GetAllAsync();

        bool Sleep(int id);
        bool Eat(int id);
        bool Hug(int id);
        bool Workout(int id);
        bool Play(int id);

        bool Add(string name);

        bool HasData();

        string WhereAmI();

        bool ValidId(int id);
        bool ValidName(string name);

        bool SetRuleForTamagotchi(int tamagotchiId, string ruleName, bool setActive);
    }
}