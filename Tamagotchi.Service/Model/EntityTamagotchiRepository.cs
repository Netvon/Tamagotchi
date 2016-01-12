using System;
using System.Collections.Generic;
using System.Linq;
using Tamagotchi.Domain;

namespace Tamagotchi.Service.Model
{
    class EntityTamagotchiRepository : ITamagotchiRepository
    {
        readonly MyContext _context;
        const string IncludeString = nameof(Domain.Tamagotchi.TamagotchiRules) + "." +
                                     nameof(TamagotchiRule.Rule);

        public EntityTamagotchiRepository(MyContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public CreatedArguments Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || _context.Tamagotchis.Any(t => t.Name == name))
                return new CreatedArguments(0, name, false);

            var tamagotchi = new Domain.Tamagotchi(name, _context.Rules.ToArray());

            _context.Tamagotchis.Add(tamagotchi);
            var wasCreated = SaveChanges();
            return new CreatedArguments(tamagotchi.TamagotchiID, name, wasCreated);
        }

        public Domain.Tamagotchi Get(int id)
        {
            if (id <= 0)
                return null;

            var tamagotchi = _context.Tamagotchis.Include(IncludeString)
                                                 .FirstOrDefault(t => t.TamagotchiID == id);

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
                return null;

            var tamagotchi = _context.Tamagotchis.Include(IncludeString)
                                                 .FirstOrDefault(t => t.Name == name);

            if (tamagotchi != null)
            {
                if(tamagotchi.RefreshRules(DateTime.UtcNow))
                    SaveChanges();
            }

            return tamagotchi;
        }

        public IEnumerable<Domain.Tamagotchi> GetAll(int start, int amount)
        {
            var all = _context.Tamagotchis.Include(IncludeString);
            var allPaged = all.ToList().OrderBy(t => t.HasDied).OrderByDescending(t => t.CreatedOnUtc)
                              .Skip(start).Take(amount);

            var now = DateTime.UtcNow;

            var changes = new List<bool>();

            foreach (var item in all)
                changes.Add(item.RefreshRules(now));

            if(changes.Any())
                SaveChanges();

            return allPaged;
        }

        public bool Remove(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            var tama = _context.Tamagotchis.FirstOrDefault(t => t.Name == name);

            if (tama == null)
                return false;

            _context.Tamagotchis.Remove(tama);
            return SaveChanges();
        }

        public bool Remove(int id)
        {
            if (id <= 0)
                return false;

            var tama = _context.Tamagotchis.FirstOrDefault(t => t.TamagotchiID == id);

            if (tama == null)
                return false;

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
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsKnownId(int id)
        {
            if (id <= 0)
                return false;

            return _context.Tamagotchis.Count(t => t.TamagotchiID == id) == 1;
        }

        public bool IsKnownName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;

            return _context.Tamagotchis.Count(t => t.Name == name) == 1;
        }

        public int TamgotchiCount()
        {
            return _context.Tamagotchis.Count();
        }
    }
}