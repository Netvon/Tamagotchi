using Tamagotchi.Console.TamagotchiService;

namespace Tamagotchi.Console.Model
{
    interface ITamagotchiRepository
    {
        TamagotchiContract Get(string name);
        TamagotchiContract Get(int id);
        TamagotchiContract[] GetAll();

        bool Sleep(string name);
        bool Eat(string name);
        bool Hug(string name);
        bool Workout(string name);
        bool Play(string name);

        bool Add(string name);
        bool Remove(string name);

        bool HasData();

        string WhereAmI();

        bool SetRule(string name, string ruleName, bool setActive);
    }
}