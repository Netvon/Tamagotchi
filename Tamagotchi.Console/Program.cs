using Ninject;
using Tamagotchi.Console.Controller;
using Tamagotchi.Console.Model;

namespace Tamagotchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ConsoleModule());
            var repo = kernel.Get<ITamagotchiRepository>();

            var controller = new TamagotchiController(repo);

            controller.Start();
        }
    }
}
