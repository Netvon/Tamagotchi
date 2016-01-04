using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class TamagotchiProp
    {
        [TestMethod]
        [TestCategory("Tamagotchi - Properties")]
        public void Tamagotchi_Boredom_MinMax()
        {
            Tamagotchi t1 = new Tamagotchi(-20, -20, -20, -20, DateTime.UtcNow, TimeSpan.Zero);
            Tamagotchi t2 = new Tamagotchi(120, 120, 120, 120, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(0, t1.Boredom);
            Assert.AreEqual(100, t2.Boredom);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Properties")]
        public void Tamagotchi_Health_MinMax()
        {
            Tamagotchi t1 = new Tamagotchi(-20, -20, -20, -20, DateTime.UtcNow, TimeSpan.Zero);
            Tamagotchi t2 = new Tamagotchi(120, 120, 120, 120, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(0, t1.Health);
            Assert.AreEqual(100, t2.Health);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Properties")]
        public void Tamagotchi_Hunger_MinMax()
        {
            Tamagotchi t1 = new Tamagotchi(-20, -20, -20, -20, DateTime.UtcNow, TimeSpan.Zero);
            Tamagotchi t2 = new Tamagotchi(120, 120, 120, 120, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(0, t1.Hunger);
            Assert.AreEqual(100, t2.Hunger);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Properties")]
        public void Tamagotchi_Sleep_MinMax()
        {
            Tamagotchi t1 = new Tamagotchi(-20, -20, -20, -20, DateTime.UtcNow, TimeSpan.Zero);
            Tamagotchi t2 = new Tamagotchi(120, 120, 120, 120, DateTime.UtcNow, TimeSpan.Zero);

            Assert.AreEqual(0, t1.Sleep);
            Assert.AreEqual(100, t2.Sleep);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Properties")]
        public void Tamagotchi_RequireName()
        {
            Tamagotchi t1 = new Tamagotchi(-20, -20, -20, -20, DateTime.UtcNow, TimeSpan.Zero);

            Assert.IsTrue(!string.IsNullOrEmpty(t1.Name));
        }
    }
}
