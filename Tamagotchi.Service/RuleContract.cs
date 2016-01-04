using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Tamagotchi.Service
{
    [DataContract]
    public class RuleContract
    {
        public RuleContract() { }

        public RuleContract(Domain.TamagotchiRule rule)
        {
            Name = rule.RuleName;
            Discription = rule.Rule.Discription;
            IsActive = rule.IsActive;

            LastPassedOnUtc = rule.LastPassedOnUtc;
        }

        [DataMember]
        public string Discription { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public DateTime LastPassedOnUtc { get; set; }
    }
}