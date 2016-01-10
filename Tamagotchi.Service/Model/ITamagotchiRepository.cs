using System;
using System.Collections.Generic;

namespace Tamagotchi.Service.Model
{
    interface ITamagotchiRepository
    {
        IEnumerable<Domain.Tamagotchi> GetAll();
        Domain.Tamagotchi Get(string name);
        Domain.Tamagotchi Get(int id);

        bool Remove(string name);
        bool Remove(int id);
        CreatedArguments Add(string name);

        bool SaveChanges();

        bool ValidId(int id);
        bool ValidName(string name);
    }
}
