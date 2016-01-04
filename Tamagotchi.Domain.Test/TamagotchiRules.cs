using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class TamagotchiRules
    {
        [TestMethod]
        [TestCategory("Tamagotchi - Rules")]
        public void Tamagotchi_NoRules_DoNothing()
        {
            Tamagotchi t1 = new Tamagotchi(0,0,0,0, DateTime.UtcNow, TimeSpan.Zero);

            t1.RefreshRules(DateTime.UtcNow);

            Assert.AreEqual(0, t1.Sleep);
            Assert.AreEqual(0, t1.Boredom);
            Assert.AreEqual(0, t1.Health);
            Assert.AreEqual(0, t1.Hunger);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Rules")]
        public void Tamagotchi_Dead_DoNothing()
        {
            var rules = new Rule[]
            {
                new AthleticRule(),
                new BordedomRule(),
                new CrazinessRule(),
                new FatigueRule(),
                new HungerRule(),
                new IsolationRule(),
                new MuchiesRule(),
                new SleepDeprivationRule(),
                new StarvationRule()
            };

            rules = rules.OrderBy(r => r.Order).ToArray();

            Tamagotchi t1 = new Tamagotchi("test", rules);

            t1.HasDied = true;            

            var now = DateTime.UtcNow + TimeSpan.FromHours(2);

            Assert.IsFalse(t1.EatAction(now));
            Assert.IsFalse(t1.RefreshRules(now));

            Assert.AreNotEqual(t1.LastAllRulesPassedUtc, now);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Rules")]
        public void Tamagotchi_Rule_TwoHours()
        {
            var rules = new Rule[]
            {
                new AthleticRule(),
                new BordedomRule(),
                new CrazinessRule(),
                new FatigueRule(),
                new HungerRule(),
                new IsolationRule(),
                new MuchiesRule(),
                new SleepDeprivationRule(),
                new StarvationRule()
            };

            rules = rules.OrderBy(r => r.Order).ToArray();

            var now = DateTime.UtcNow;
            Tamagotchi t1 = new Tamagotchi("test", rules);

            var inTheFuture = now + TimeSpan.FromHours(2);
            t1.RefreshRules(inTheFuture);

            Assert.AreNotEqual(0, t1.Sleep);
            Assert.AreNotEqual(0, t1.Boredom);
            Assert.AreNotEqual(0, t1.Health);
            Assert.AreNotEqual(0, t1.Hunger);

            Assert.AreEqual(t1.LastAllRulesPassedUtc, inTheFuture);
        }

        [TestMethod]
        [TestCategory("Tamagotchi - Rules")]
        public void Tamagotchi_Rule_TwentyFiveHours()
        {
            var rules = new Rule[]
            {
                new AthleticRule(),
                new BordedomRule(),
                new CrazinessRule(),
                new FatigueRule(),
                new HungerRule(),
                new IsolationRule(),
                new MuchiesRule(),
                new SleepDeprivationRule(),
                new StarvationRule()
            };

            rules = rules.OrderBy(r => r.Order).ToArray();

            var now = DateTime.UtcNow;
            Tamagotchi t1 = new Tamagotchi("test", rules);

            var inTheFuture = now + TimeSpan.FromHours(25);
            t1.RefreshRules(inTheFuture);

            Assert.AreEqual(100, t1.Sleep);
            Assert.AreEqual(100, t1.Boredom);
            Assert.AreEqual(100, t1.Health);
            Assert.AreEqual(100, t1.Hunger);

            Assert.IsTrue(t1.HasDied);

            Assert.AreEqual(t1.LastAllRulesPassedUtc, inTheFuture);
        }
    }
}
