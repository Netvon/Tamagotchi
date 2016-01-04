using Ninject.Modules;

namespace Tamagotchi.Service.Model
{
    class TamagotchiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITamagotchiRepository>().To<EntityTamagotchiRepository>();

            Bind<Domain.Rule>().To<Domain.CrazinessRule>();
            Bind<Domain.Rule>().To<Domain.SleepDeprivationRule>();
            Bind<Domain.Rule>().To<Domain.AthleticRule>();
            Bind<Domain.Rule>().To<Domain.StarvationRule>();
            Bind<Domain.Rule>().To<Domain.MuchiesRule>();
            Bind<Domain.Rule>().To<Domain.FatigueRule>();
            Bind<Domain.Rule>().To<Domain.HungerRule>();
            Bind<Domain.Rule>().To<Domain.IsolationRule>();
            Bind<Domain.Rule>().To<Domain.BordedomRule>();
        }
    }
}