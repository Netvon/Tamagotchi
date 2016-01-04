using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Console.Controller;
using Tamagotchi.Console.Model;
using Tamagotchi.Console.TamagotchiService;

namespace Tamagotchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ConsoleModule());
            var repo = kernel.Get<ITamagotchiRepository>();

            var controller = new TamagotchiController(repo);

            controller.Start();
        }
    }
}
