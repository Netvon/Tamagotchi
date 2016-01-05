using System;

namespace Tamagotchi.Domain
{
    public class IsolationRule : Rule
    {
        const int DeltaHealth = 5;
        static readonly TimeSpan oneHour = new TimeSpan(1, 0, 0);

        public IsolationRule()
            : base("Isolation Rule", $"Every hour health rises by {DeltaHealth} points",
                  order: 4)
        { }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            var timeSpan = now - tama.LastAllRulesPassedUtc;

            if (timeSpan >= oneHour)
            {
                tama.Health += DeltaHealth * (int)timeSpan.TotalHours;
                return true;
            }

            return false;
        }
    }
}
