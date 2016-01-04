using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class ActionValues
    {
        [TestMethod]
        [TestCategory("Tamgotchi - Actions - values")]
        public void TamagotchiAction_EatValue()
        {
            Tamagotchi t = new Tamagotchi(0, 0, 10, 0, new DateTime(1994, 1, 5, 10, 10, 10), TimeSpan.Zero);

            t.EatAction(new DateTime(1994, 1, 5, 10, 10, 10));

            Assert.AreEqual(0, t.Hunger);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - values")]
        public void TamagotchiAction_SleepValue()
        {
            Tamagotchi t = new Tamagotchi(0, 0, 0, 10, new DateTime(1994, 1, 5, 10, 10, 10), TimeSpan.Zero);

            t.SleepAction(new DateTime(1994, 1, 5, 10, 10, 10));

            Assert.AreEqual(0, t.Sleep);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - values")]
        public void TamagotchiAction_PlayValue()
        {
            Tamagotchi t = new Tamagotchi(20, 0, 0, 0, new DateTime(1994, 1, 5, 10, 10, 10), TimeSpan.Zero);

            t.PlayAction(new DateTime(1994, 1, 5, 10, 10, 10));

            Assert.AreEqual(10, t.Boredom);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - values")]
        public void TamagotchiAction_WorkoutValue()
        {
            Tamagotchi t = new Tamagotchi(0, 20, 0, 0, new DateTime(1994, 1, 5, 10, 10, 10), TimeSpan.Zero);

            t.WorkoutAction(new DateTime(1994, 1, 5, 10, 10, 10));

            Assert.AreEqual(15, t.Health);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - values")]
        public void TamagotchiAction_HugValue()
        {
            Tamagotchi t = new Tamagotchi(0, 20, 0, 0, new DateTime(1994, 1, 5, 10, 10, 10), TimeSpan.Zero);

            t.HugAction(new DateTime(1994, 1, 5, 10, 10, 10));

            Assert.AreEqual(10, t.Health);
        }
    }
}
