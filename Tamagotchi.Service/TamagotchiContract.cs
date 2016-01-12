using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Tamagotchi.Service
{
    [DataContract]
    public class TamagotchiContract
    {
        public TamagotchiContract() { }

        public TamagotchiContract(Domain.Tamagotchi tama)
        {
            ID = tama.TamagotchiID;
            Name = tama.Name;
            Status = tama.Status;
            HasDied = tama.HasDied;
            var now = DateTime.UtcNow;
            IsInCoolDown = tama.IsInCoolDown(now);

            if (IsInCoolDown)
            {
                CoolDownLeft = tama.CoolDown - (now - tama.LastAccessedOnUtc);
                CoolDownUntilUtc = now + CoolDownLeft;
            }
            else
            {
                CoolDownLeft = TimeSpan.Zero;
                CoolDownUntilUtc = DateTime.MinValue;
            }

            CreatedOnUtc = tama.CreatedOnUtc;
            DiedOnUtc = tama.DiedOnUtc;

            Health = tama.Health;
            Hungriness = tama.Hunger;
            Sleepiness = tama.Sleep;
            Boredom = tama.Boredom;

            tama.TamagotchiRules.ToList();

            Rules = tama.TamagotchiRules?.OrderBy(r => r.Rule.Order)
                                         .Select(r => new RuleContract(r));
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public bool IsInCoolDown { get; set; }

        [DataMember]
        public bool HasDied { get; set; }

        [DataMember]
        public TimeSpan CoolDownLeft { get; set; }

        [DataMember]
        public DateTime CoolDownUntilUtc { get; set; }

        [DataMember]
        public DateTime CreatedOnUtc { get; set; }

        [DataMember]
        public DateTime? DiedOnUtc { get; set; }

        [DataMember]
        public int Health { get; set; }

        [DataMember]
        public int Boredom { get; set; }

        [DataMember]
        public int Sleepiness { get; set; }

        [DataMember]
        public int Hungriness { get; set; }

        [DataMember]
        public IEnumerable<RuleContract> Rules { get; set; }

        public override string ToString()
        {
            return $"[Name:{Name}][Status:{Status}]";
        }
    }
}