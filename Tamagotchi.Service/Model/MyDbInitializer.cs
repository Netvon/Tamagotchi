using Ninject;
using System.Data.Entity;

namespace Tamagotchi.Service.Model
{
    class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            IKernel kernel = new StandardKernel(new TamagotchiModule());

            var rules = kernel.GetAll<Domain.Rule>();
            context.Rules.AddRange(rules);

            base.Seed(context);
        }
    }
}