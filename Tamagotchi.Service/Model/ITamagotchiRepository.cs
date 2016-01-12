using System.Collections.Generic;

namespace Tamagotchi.Service.Model
{
    interface ITamagotchiRepository
    {
        IEnumerable<Domain.Tamagotchi> GetAll(int start, int amount);
        Domain.Tamagotchi Get(string name);
        Domain.Tamagotchi Get(int id);

        bool Remove(string name);
        bool Remove(int id);
        CreatedArguments Add(string name);

        bool SaveChanges();

        bool IsKnownId(int id);
        bool IsKnownName(string name);
        int TamgotchiCount();
    }
}
