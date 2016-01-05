using System;

namespace Tamagotchi.Domain
{
    public class CrazinessRule : Rule
    {
        const int HealthThreshold = 100;

        public CrazinessRule() 
            : base("Craziness Rule",
                  $"If health is equal to {HealthThreshold} points the Tamagotchi " +
                  "obtains the Crazy status meaning it has a 50% chance of " + 
                  "dying when preforming actions",
                  order : 6)
        { }

        public override void Deactivate(Tamagotchi tama)
        {
            tama.IsCrazy = false;
        }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            if (tama.Health == HealthThreshold)
                tama.IsCrazy = true;
            else
                tama.IsCrazy = false;

            return true;
        }
    }
}
