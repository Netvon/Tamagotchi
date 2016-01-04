using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tamagotchi.Domain.Test
{
    [TestClass]
    public class Rules
    {
        void CheckRule(Rule rule, 
            Func<Tamagotchi, int> assertValue,
            TimeSpan elapsedTime,
            int expectedValue)
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 0, 0, dateTime, TimeSpan.Zero);

            Rule fr = rule;

            fr.Execute(t, dateTime + elapsedTime);
            Assert.AreEqual(expectedValue, assertValue.Invoke(t));
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_DefaultValues()
        {
            Tamagotchi t = new Tamagotchi("test");
            Rule rule = new FatigueRule();

            TamagotchiRule tr = new TamagotchiRule(t, rule);

            Assert.IsTrue(tr.IsActive);

            tr.IsActive = false;
            Assert.IsFalse(tr.IsActive);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_FatigueRule_Value()
        {
            CheckRule(new FatigueRule(), t => t.Sleep, new TimeSpan(1, 0, 0), 5);
            CheckRule(new FatigueRule(), t => t.Sleep, new TimeSpan(2, 0, 0), 10);
            CheckRule(new FatigueRule(), t => t.Sleep, new TimeSpan(25, 0, 0), 100);
        }        

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_FatigueRule_ValueNotChanged()
        {
            CheckRule(new FatigueRule(), t => t.Sleep, new TimeSpan(0, 1, 0), 0);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_IsolationRule_Value()
        {
            CheckRule(new IsolationRule(), t => t.Health, new TimeSpan(1, 0, 0), 5);
            CheckRule(new IsolationRule(), t => t.Health, new TimeSpan(2, 0, 0), 10);
            CheckRule(new IsolationRule(), t => t.Health, new TimeSpan(25, 0, 0), 100);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_IsolationRule_ValueNotChanged()
        {
            CheckRule(new IsolationRule(), t => t.Health, new TimeSpan(0, 1, 0), 0);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_BoredomRule_Value()
        {
            CheckRule(new BordedomRule(), t => t.Boredom, new TimeSpan(1, 0, 0), 15);
            CheckRule(new BordedomRule(), t => t.Boredom, new TimeSpan(2, 0, 0), 30);
            CheckRule(new BordedomRule(), t => t.Boredom, new TimeSpan(25, 0, 0), 100);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_BoredomRule_ValueNotChanged()
        {
            CheckRule(new BordedomRule(), t => t.Health, new TimeSpan(0, 1, 0), 0);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_HungerRule_Value()
        {
            CheckRule(new HungerRule(), tama => tama.Hunger, new TimeSpan(1, 0, 0), 5);
            CheckRule(new HungerRule(), tama => tama.Hunger, new TimeSpan(2, 0, 0), 10);
            CheckRule(new HungerRule(), tama => tama.Hunger, new TimeSpan(25, 0, 0), 100);

            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(81, 0, 0, 0, dateTime, TimeSpan.Zero);
            t.HasMunchies = true;

            Rule fr = new HungerRule();

            fr.Execute(t, dateTime + new TimeSpan(2,0,0));
            Assert.AreEqual(20, t.Hunger);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_HungerRule_ValueNotChanged()
        {
            CheckRule(new HungerRule(), t => t.Hunger, new TimeSpan(0, 1, 0), 0);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_AthleticRule_Value()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 21, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new AthleticRule();

            rule.Execute(t, dateTime);
            Assert.IsFalse(t.IsAthletic);

            t.HugAction(dateTime);
            rule.Execute(t, dateTime);

            Assert.IsTrue(t.IsAthletic);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_AthleticRule_Deactivate()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 21, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new AthleticRule();

            rule.Execute(t, dateTime);
            t.HugAction(dateTime);
            rule.Execute(t, dateTime);

            Assert.IsTrue(t.IsAthletic);

            rule.Deactivate(t);
            Assert.IsFalse(t.IsAthletic);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_CrazinessRule_Value()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 95, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new CrazinessRule();
            Rule iso = new IsolationRule();

            rule.Execute(t, dateTime);
            Assert.IsFalse(t.IsCrazy);

            iso.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsTrue(t.IsCrazy);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_CrazinessRule_Deactivate()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 100, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new CrazinessRule();

            rule.Execute(t, dateTime);
            Assert.IsTrue(t.IsCrazy);

            rule.Deactivate(t);
            
            Assert.IsFalse(t.IsCrazy);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_MuchiesRule_Value()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(79, 0, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new MuchiesRule();
            Rule bore = new BordedomRule();

            rule.Execute(t, dateTime);
            Assert.IsFalse(t.HasMunchies);

            bore.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsTrue(t.HasMunchies);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_MuchiesRule_Deactivate()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(81, 0, 0, 0, dateTime, TimeSpan.Zero);

            Rule rule = new MuchiesRule();

            rule.Execute(t, dateTime);
            Assert.IsTrue(t.HasMunchies);

            rule.Deactivate(t);

            Assert.IsFalse(t.HasMunchies);
        }


        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_SleepDeprivationRule_Value()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 0, 95, dateTime, TimeSpan.Zero);

            Rule rule = new SleepDeprivationRule();
            Rule fat = new FatigueRule();

            rule.Execute(t, dateTime);
            Assert.IsFalse(t.HasDied);

            fat.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsTrue(t.HasDied);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_SleepDeprivationRule_DoNothingIsAthletic()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 0, 95, dateTime, TimeSpan.Zero);

            Rule rule = new SleepDeprivationRule();
            Rule fat = new FatigueRule();
            Rule ath = new AthleticRule();

            ath.Execute(t, dateTime);
            rule.Execute(t, dateTime);
            Assert.IsFalse(t.HasDied);

            fat.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsFalse(t.HasDied);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_StarvationRule_Value()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 95, 0, dateTime, TimeSpan.Zero);

            Rule rule = new StarvationRule();
            Rule hun = new HungerRule();

            rule.Execute(t, dateTime);
            Assert.IsFalse(t.HasDied);

            hun.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsTrue(t.HasDied);
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void Rules_StarvationRule_DoNothingIsAthletic()
        {
            var dateTime = new DateTime(1994, 1, 5, 10, 10, 10);
            Tamagotchi t = new Tamagotchi(0, 0, 95, 0, dateTime, TimeSpan.Zero);

            Rule rule = new SleepDeprivationRule();
            Rule hun = new HungerRule();
            Rule ath = new AthleticRule();

            ath.Execute(t, dateTime);
            rule.Execute(t, dateTime);
            Assert.IsFalse(t.HasDied);

            hun.Execute(t, dateTime + TimeSpan.FromHours(2));
            rule.Execute(t, dateTime + TimeSpan.FromHours(2));
            Assert.IsFalse(t.HasDied);
        }
    }
}
