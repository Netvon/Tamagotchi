using System;

namespace Tamagotchi.Domain
{
    public class BordedomRule : Rule
    {
        private const int DeltaBoredom = 15;
        static readonly TimeSpan oneHour = new TimeSpan(1, 0, 0);

        public BordedomRule()
            : base("Bordedom Rule", $"Every hour boredom rises by {DeltaBoredom} points",
                  order: 1)
        { }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            var timeSpan = now - tama.LastAllRulesPassedUtc;

            if (timeSpan >= oneHour)
            {
                tama.Boredom += DeltaBoredom * (int)timeSpan.TotalHours;
                return true;
            }

            return false;
        }
    }
}
