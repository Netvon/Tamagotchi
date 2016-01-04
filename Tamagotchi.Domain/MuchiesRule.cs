using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Domain
{
    public class MuchiesRule : Rule
    {
        const int HungerThreshold = 80;

        public MuchiesRule() 
            : base("Munchies Rule", 
                  $"If boredom is over {HungerThreshold} points, hungriness rises two times faster",
                  order: 2)
        { }

        public override void Deactivate(Tamagotchi tama)
        {
            tama.HasMunchies = false;
        }

        public override bool Execute(Tamagotchi tama, DateTime now)
        {
            if (tama.Boredom > 80)
                tama.HasMunchies = true;
            else
                tama.HasMunchies = false;

            return true;
        }
    }
}
