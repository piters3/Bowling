using Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTests
{
    [TestClass]
    public class BowlingTesting
    {
        BowlingGame BG = new BowlingGame();

        [TestMethod]
        public void AllStrikesReturns300()
        {
            for (int i = 0; i < 21; i++)
            {
                BG.Throw(10);
            }
            int sum = BG.Sum;

            Assert.AreEqual(sum, 300);
        }

        [TestMethod]
        public void AllSparesReturns150()
        {
            for (int i = 0; i < 21; i++)
            {
                BG.Throw(5);
            }
            int sum = BG.Sum;

            Assert.AreEqual(sum, 150);
        }

        [TestMethod]
        public void All0Returns0()
        {
            for (int i = 0; i < 20; i++)
            {
                BG.Throw(0);
            }
            int sum = BG.Sum;

            Assert.AreEqual(sum, 0);
        }

        [TestMethod]
        public void All1Returns20()
        {
            for (int i = 0; i < 20; i++)
            {
                BG.Throw(1);
            }
            int sum = BG.Sum;

            Assert.AreEqual(sum, 20);
        }

        [TestMethod]
        public void OneStrike()
        {
            BG.Throw(1);
            BG.Throw(4);
            BG.Throw(10);
            for (int i = 0; i < 9; i++)
            {
                BG.Throw(1);
                BG.Throw(4);
            }
            int sum = BG.Sum;

            Assert.AreEqual(sum, 60);
        }
    }
}
