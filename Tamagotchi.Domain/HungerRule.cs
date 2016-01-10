using System;

namespace Tamagotchi.Domain
{
    public class HungerRule : Rule
    {
        const int DeltaHunger = 5;
        static readonly TimeSpan oneHour = new TimeSpan(1, 0, 0);

        public HungerRule()
            : base("Hunger Rule",
                  $"Every hour hungriness rises by {DeltaHunger} points" +
                  ", expect for when the Tamagotchi has the munchies " +
                  $"then it increases by {DeltaHunger * 2} points",
                  order: 3)
        { }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            var timeSpan = now - tama.LastAllRulesPassedUtc;

            if (timeSpan >= oneHour)
            {
                int delta = DeltaHunger;

                if (tama.HasMunchies)
                    delta *= 2;

                tama.Hunger += delta * (int)timeSpan.TotalHours;

                return true;
            }

            return false;
        }
    }
}
