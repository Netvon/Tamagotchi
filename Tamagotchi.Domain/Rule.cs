using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Diagnostics.CodeAnalysis;

namespace Tamagotchi.Domain
{
    public abstract class Rule
    {
        public Rule(string name, string discription, int order)
        {
            RuleName = name;
            Discription = discription;
            Order = order;
        }

        Rule()
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            TamagotchiRules = new List<TamagotchiRule>();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        [Key]
        /*[ExcludeFromCodeCoverage]*/ // not testing this prop
        public string RuleName { get; internal set; }

        /*[ExcludeFromCodeCoverage]*/ // not testing this prop
        public string Discription { get; internal set; }

        /*[ExcludeFromCodeCoverage]*/
        public int Order { get; internal set; }

        /*[ExcludeFromCodeCoverage]*/
        public virtual ICollection<TamagotchiRule> TamagotchiRules { get; internal set; }

        public abstract bool Execute(Tamagotchi tama, DateTime now);

        public virtual void Deactivate(Tamagotchi tama) { /* do nothing */ }
    }
}
