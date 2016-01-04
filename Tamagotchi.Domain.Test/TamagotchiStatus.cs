using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class TamagotchiStatus
    {
        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusBoredom()
        {
            Tamagotchi t1 = new Tamagotchi(100, 90, 80, 70, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(nameof(t1.Boredom), t1.Status);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusHealth()
        {
            Tamagotchi t1 = new Tamagotchi(90, 100, 80, 70, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(nameof(t1.Health), t1.Status);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusHunger()
        {
            Tamagotchi t1 = new Tamagotchi(90, 80, 100, 70, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(nameof(t1.Hunger), t1.Status);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusSleep()
        {
            Tamagotchi t1 = new Tamagotchi(90, 80, 70, 100, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(nameof(t1.Sleep), t1.Status);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusDoubleValue()
        {
            Tamagotchi t1 = new Tamagotchi(90, 100, 70, 100, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual("Neutral", t1.Status);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Status")]
        public void Tamagotchi_StatusDead()
        {
            Tamagotchi t1 = new Tamagotchi(90, 100, 70, 100, DateTime.UtcNow, TimeSpan.Zero);
            t1.HasDied = true;

            Assert.AreEqual("Dead", t1.Status);
        }
    }
}
