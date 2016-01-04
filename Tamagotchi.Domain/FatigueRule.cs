using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Domain
{
    public class FatigueRule : Rule
    {
        const int DeltaSleep = 5;
        static readonly TimeSpan oneHour = new TimeSpan(1, 0, 0);

        public FatigueRule()
            : base("Fatigue Rule", $"Every hour sleepiness rises by {DeltaSleep} points",
                  order: 0)
        { }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            var timeSpan = now - tama.LastAllRulesPassedUtc;

            if (timeSpan >= oneHour)
            {
                tama.Sleep += DeltaSleep * (int)timeSpan.TotalHours;
                return true;
            }

            return false;
        }
    }
}
