using System;

namespace Tamagotchi.Domain
{
    public class StarvationRule : Rule
    {
        const int HungerThreshold = 100;

        public StarvationRule()
            : base("Starvation Rule",
                  $"If hunger is equal to {HungerThreshold} points the Tamagotchi will die",
                  order: 8)
        { }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            if (tama.Hunger == HungerThreshold && !tama.IsAthletic)
                tama.HasDied = true;
            else
                tama.HasDied = false;

            return true;
        }
    }
}
