using System;

namespace Tamagotchi.Domain
{
    public class AthleticRule : Rule
    {
        const int HealthThreshold = 20;

        public AthleticRule()
            : base("Athletic Rule",
                  $"If health is lower than {HealthThreshold} points the Tamagotchi"
                  + " obtains the Athlectic status meaning it can no longer die",
                  order: 5)
        { }

        public override void Deactivate(Tamagotchi tama)
        {
            tama.IsAthletic = false;
        }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            if (tama.Health < HealthThreshold)
                tama.IsAthletic = true;
            else
                tama.IsAthletic = false;

            return true;
        }
    }
}
