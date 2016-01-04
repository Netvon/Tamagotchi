using System;
using System.Collections.Generic;
using System.Linq;
using Tamagotchi.Domain;

namespace Tamagotchi.Service.Model
{
    class EntityTamagotchiRepository : ITamagotchiRepository
    {
        readonly MyContext _context;

        public EntityTamagotchiRepository(MyContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            this._context = context;
        }

        public bool Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || _context.Tamagotchis.Any(t => t.Name == name))
                return false;

            var tamagotchi = new Domain.Tamagotchi(name, _context.Rules.ToArray());

            _context.Tamagotchis.Add(tamagotchi);
            return SaveChanges();
        }

        public Domain.Tamagotchi Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var tamagotchi = _context.Tamagotchis.Include("TamagotchiRules.Rule").FirstOrDefault(t => t.TamagotchiID == id);

            if (tamagotchi != null)
            {
                if(tamagotchi.RefreshRules(DateTime.UtcNow))
                    SaveChanges();
            }

            return tamagotchi;
        }

        public Domain.Tamagotchi Get(string name)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var tamagotchi = _context.Tamagotchis.Include("TamagotchiRules.Rule").FirstOrDefault(t => t.Name == name);

            if (tamagotchi != null)
            {
                if(tamagotchi.RefreshRules(DateTime.UtcNow))
                    SaveChanges();
            }

            return tamagotchi;
        }

        public IEnumerable<Domain.Tamagotchi> GetAll()
        {
            var all = _context.Tamagotchis.Include("TamagotchiRules.Rule");

            var now = DateTime.UtcNow;

            var changes = new List<bool>();

            foreach (var item in all)
                changes.Add(item.RefreshRules(now));

            if(changes.Any())
                SaveChanges();

            return all;
        }

        public bool Remove(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !_context.Tamagotchis.Any(t => t.Name == name))
                return false;

            var tama = _context.Tamagotchis.First(t => t.Name == name);

            _context.Tamagotchis.Remove(tama);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ValidId(int id)
        {
            if (id <= 0)
                return false;

            return _context.Tamagotchis.Count(t => t.TamagotchiID == id) == 1;
        }

        public bool ValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return _context.Tamagotchis.Count(t => t.Name == name) == 1;
        }
    }
}