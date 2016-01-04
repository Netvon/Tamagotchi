using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Domain
{
    public class SleepDeprivationRule : Rule
    {
        const int SleepThreshold = 100;

        public SleepDeprivationRule() 
            : base("Sleep Deprivation Rule",
                  $"If sleep is equal to {SleepThreshold} points the Tamagotchi will die",
                  order: 7)
        {
        }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            if (tama.Sleep == SleepThreshold && !tama.IsAthletic)
                tama.HasDied = true;
            else
                tama.HasDied = false;

            return true;
        }
    }
}
