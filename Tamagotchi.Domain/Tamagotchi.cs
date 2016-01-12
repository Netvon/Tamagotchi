using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Tamagotchi.Domain
{
    public class Tamagotchi
    {
        #region Constants
        const int MaxPropValue = 100;
        const int MinPropValue = 0;
        #endregion

        #region Fields
        int _boredom;
        int _health;
        int _hunger;
        int _sleep;
        DateTime _lastAccessedOn;
        bool _hasDied;
        #endregion

        #region Constructors

        public Tamagotchi(int boredom, int health, int hunger,
            int sleep, DateTime lastAccess, TimeSpan coolDown)
            : this()
        {
            CoolDown = coolDown;
            LastAccessedOnUtc = lastAccess;
            LastAllRulesPassedUtc = LastAccessedOnUtc;
            Sleep = sleep;
            Hunger = hunger;
            Health = health;
            Boredom = boredom;

            CreatedOnUtc = lastAccess;
        }

        public Tamagotchi(string name, params Rule[] rules)
            : this(name)
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            TamagotchiRules = new List<TamagotchiRule>();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor

            foreach (var r in rules)
                TamagotchiRules.Add(new TamagotchiRule(this, r));
        }

        public Tamagotchi(string name)
            : this()
        {
            Name = name;
            if (LastAccessedOnUtc == DateTime.MinValue)
                LastAccessedOnUtc = DateTime.UtcNow;

            LastAllRulesPassedUtc = LastAccessedOnUtc;
            CoolDown = TimeSpan.Zero;

            CreatedOnUtc = LastAccessedOnUtc;
        }

        Tamagotchi()
        {
            if (string.IsNullOrEmpty(Name))
                Name = "Unnamed Tamagotchi";

#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            if (TamagotchiRules == null)
                TamagotchiRules = new List<TamagotchiRule>();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor            
        }

        #endregion

        #region Properties

        [Key]
        /*[ExcludeFromCodeCoverage]*/ // not testing this prop
        public int TamagotchiID { get; internal set; }

        [Required]
        public string Name { get; /*[ExcludeFromCodeCoverage]*/ internal set; }

        [Range(MinPropValue, MaxPropValue)]
        public int Boredom
        {
            get { return _boredom; }
            internal set { _boredom = ClampValue(value); }
        }

        [Range(MinPropValue, MaxPropValue)]
        public int Health
        {
            get { return _health; }
            internal set { _health = ClampValue(value); }
        }

        [Range(MinPropValue, MaxPropValue)]
        public int Hunger
        {
            get { return _hunger; }
            internal set { _hunger = ClampValue(value); }
        }

        [Range(MinPropValue, MaxPropValue)]
        public int Sleep
        {
            get { return _sleep; }
            internal set { _sleep = ClampValue(value); }
        }

        public bool HasMunchies { get; set; }

        public bool HasDied
        {
            get
            {
                return _hasDied;
            }

            set
            {
                _hasDied = value;

                if (_hasDied)
                    DiedOnUtc = DateTime.UtcNow;
            }
        }

        public DateTime LastAccessedOnUtc
        {
            get
            {
                return _lastAccessedOn;
            }

            internal set
            {
                _lastAccessedOn = value;
            }
        }

        //public DateTime LastRefreshedOn { get; internal set; }

        public DateTime LastAllRulesPassedUtc { get; internal set; }

        public TimeSpan CoolDown { get; internal set; }

        public DateTime CreatedOnUtc { get; internal set; }
        public DateTime? DiedOnUtc { get; internal set; }


        public virtual ICollection<TamagotchiRule> TamagotchiRules { get; /*[ExcludeFromCodeCoverage]*/ internal set; }

        [NotMapped]
        public string Status
        {
            get
            {
                if (HasDied)
                    return "Dead";

                var properties = new[]
                {
                    new { Name = nameof(Boredom), Value = Boredom },
                    new { Name = nameof(Health), Value = Health },
                    new { Name = nameof(Hunger), Value = Hunger },
                    new { Name = nameof(Sleep), Value = Sleep }
                };

                int max = properties.Max(p => p.Value);

                if (properties.Count(p => p.Value == max) > 1)
                    return "Neutral";

                return properties.OrderByDescending(x => x.Value).FirstOrDefault()?.Name;
            }
        }

        public bool IsAthletic { get; internal set; }
        public bool IsCrazy { get; internal set; }

        #endregion

        #region Methods

        public bool EatAction(DateTime now)
        {
            return PerformAction(now, () => Hunger = MinPropValue, TimeSpan.FromSeconds(30));
        }

        public bool SleepAction(DateTime now)
        {
            return PerformAction(now, () => Sleep = MinPropValue, TimeSpan.FromHours(2));
        }

        public bool PlayAction(DateTime now)
        {
            return PerformAction(now, () => Boredom -= 10, TimeSpan.FromSeconds(30));
        }

        public bool WorkoutAction(DateTime now)
        {
            return PerformAction(now, () => Health -= 5, TimeSpan.FromMinutes(1));
        }

        public bool HugAction(DateTime now)
        {
            return PerformAction(now, () => Health -= 10, TimeSpan.FromMinutes(1));
        }

        bool PerformAction(DateTime now, Action action, TimeSpan cooldown)
        {
            if (HasDied)
                return false;

            RefreshRules(now);

            if (CheckRandomDeath())
                return false;

            if (IsInCoolDown(now))
                return false;

            LastAccessedOnUtc = now;

            action.Invoke();
            CoolDown = cooldown;

            return true;
        }

        public bool RefreshRules(DateTime now)
        {
            if (HasDied)
                return false;

            var allActive = TamagotchiRules
                .Where(r => r.IsActive);

            if (allActive.Count() == 0)
                return false;

            var allPassed = allActive
                .OrderBy(r => r.Rule.Order)
                .All(r =>
                {
                    var @out = r.Rule.Execute(this, now);

                    if (@out)
                        r.LastPassedOnUtc = now;

                    return @out;
                });

            if (allPassed)
            {
                LastAllRulesPassedUtc = now;
                return true;
            }

            return false;
        }

        public bool IsInCoolDown(DateTime now)
            => now < LastAccessedOnUtc + CoolDown;

        int ClampValue(int value)
            => Math.Min(Math.Max(value, 0), MaxPropValue);

        /*[ExcludeFromCodeCoverage]*/ // can't test something random
        bool CheckRandomDeath()
        {
            if (!IsCrazy)
                return false;

            var r = new Random();

            if (r.Next(0, 2) == 0)
            {
                HasDied = true;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"[Name:{Name}][Status:{Status}]";
        }

        #endregion
    }
}