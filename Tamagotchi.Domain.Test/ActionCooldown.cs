using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class ActionCooldown
    {
        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_EatValue()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 10, 0, DateTime.MinValue, TimeSpan.Zero);

            Assert.IsTrue(t.EatAction(dateTime));

            Assert.AreEqual(dateTime, t.LastAccessedOnUtc);
            Assert.AreEqual(new TimeSpan(0,0,30), t.CoolDown);
            Assert.IsTrue(t.IsInCoolDown(dateTime + new TimeSpan(0, 0, 10)));            
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_SleepValue()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 0, 10, DateTime.MinValue, TimeSpan.Zero);

            Assert.IsTrue(t.SleepAction(dateTime));

            Assert.AreEqual(dateTime, t.LastAccessedOnUtc);
            Assert.AreEqual(new TimeSpan(2, 0, 0), t.CoolDown);
            Assert.IsTrue(t.IsInCoolDown(dateTime + new TimeSpan(1, 0, 0)));
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_PlayValue()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(20, 0, 0, 0, DateTime.MinValue, TimeSpan.Zero);

            Assert.IsTrue(t.PlayAction(dateTime));

            Assert.AreEqual(dateTime, t.LastAccessedOnUtc);
            Assert.AreEqual(new TimeSpan(0, 0, 30), t.CoolDown);
            Assert.IsTrue(t.IsInCoolDown(dateTime + new TimeSpan(0, 0, 10)));
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_WorkoutValue()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 20, 0, 0, DateTime.MinValue, TimeSpan.Zero);

            Assert.IsTrue(t.WorkoutAction(dateTime));

            Assert.AreEqual(dateTime, t.LastAccessedOnUtc);
            Assert.AreEqual(new TimeSpan(0, 1, 0), t.CoolDown);
            Assert.IsTrue(t.IsInCoolDown(dateTime + new TimeSpan(0, 0, 30)));
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_HugValue()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 20, 0, 0, DateTime.MinValue, TimeSpan.Zero);

            Assert.IsTrue(t.HugAction(dateTime));

            Assert.AreEqual(dateTime, t.LastAccessedOnUtc);
            Assert.AreEqual(new TimeSpan(0, 1, 0), t.CoolDown);
            Assert.IsTrue(t.IsInCoolDown(dateTime + new TimeSpan(0, 0, 30)));
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_EatDoNothingInCooldown()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(10,10,10,10, dateTime, new TimeSpan(1));

            Assert.IsFalse(t.EatAction(dateTime));
            Assert.AreEqual(10, t.Hunger);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_SleepDoNothingInCooldown()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(10, 10, 10, 10, dateTime, new TimeSpan(1));

            Assert.IsFalse(t.SleepAction(dateTime));
            Assert.AreEqual(10, t.Sleep);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_PlayDoNothingInCooldown()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(10, 10, 10, 10, dateTime, new TimeSpan(1));

            Assert.IsFalse(t.PlayAction(dateTime));
            Assert.AreEqual(10, t.Boredom);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_WorkoutDoNothingInCooldown()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(10, 10, 10, 10, dateTime, new TimeSpan(1));

            Assert.IsFalse(t.WorkoutAction(dateTime));
            Assert.AreEqual(10, t.Health);
        }

        [TestMethod]
        [TestCategory("Tamgotchi - Actions - cooldown")]
        public void TamagotchiAction_HugDoNothingInCooldown()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(10, 10, 10, 10, dateTime, new TimeSpan(1));

            Assert.IsFalse(t.HugAction(dateTime));
            Assert.AreEqual(10, t.Health);
        }
    }
}
