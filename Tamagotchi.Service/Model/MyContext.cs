using System.Data.Entity;

namespace Tamagotchi.Service.Model
{
    class MyContext : DbContext
    {
        public MyContext()
            :base("name=ReleaseDb")
        {
            Database.SetInitializer(new MyDbInitializer());
            Database.Initialize(true);
        }

        public DbSet<Domain.Tamagotchi> Tamagotchis { get; set; }
        public DbSet<Domain.Rule> Rules { get; set; }
    }
}