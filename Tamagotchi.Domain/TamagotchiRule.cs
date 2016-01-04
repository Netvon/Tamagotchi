using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Domain
{
    public class TamagotchiRule
    {
        public TamagotchiRule(Tamagotchi tama, Rule rule)
            :this()
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            Tamagotchi = tama;
            Rule = rule;
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        TamagotchiRule()
        {
            IsActive = true;
            LastPassedOnUtc = DateTime.UtcNow;
        }

        [Key, Column(Order = 1)]
        /*[ExcludeFromCodeCoverage]*/
        public int TamagotchiID { get; internal set; }

        [Key, Column(Order = 2)]
        /*[ExcludeFromCodeCoverage]*/
        public string RuleName { get; internal set; }

        public virtual Rule Rule { get; internal set; }
        public virtual Tamagotchi Tamagotchi { get; internal set; }

        public bool IsActive { get; set; }

        public DateTime LastPassedOnUtc { get; set; }
    }
}
