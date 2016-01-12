using Ninject.Modules;

namespace Tamagotchi.Web.Models
{
    class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITamagotchiRepository>().To<WCFTamagotchiRepository>().InSingletonScope();
        }
    }
}
