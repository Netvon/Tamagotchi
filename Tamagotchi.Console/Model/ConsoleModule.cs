using Ninject.Modules;

namespace Tamagotchi.Console.Model
{
    class ConsoleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITamagotchiRepository>().To<WCFTamagotchiRepository>();
        }
    }
}
