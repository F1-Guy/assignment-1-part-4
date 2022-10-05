using assignment1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace assignment4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        internal FootballPlayersManager manager = new();
        internal FootballPlayer testPlayer = new() { Id = 5, Name = "Vida", Age = 33, ShirtNumber = 21 };

        [TestMethod()]
        public void GetByIdTest()
        {
            var result = manager.GetById(4);
            Assert.AreEqual(4, result.Id);
            Assert.AreEqual("Kramaric", result.Name);
        }

        [TestMethod()]
        public void GetByWrongIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() => manager.GetById(-500));
        }

        [TestMethod()]
        public void AddTest()
        {
            var NnumberOfPlayersBefore = manager.GetAll().Count();

            manager.Add(testPlayer);

            Assert.AreEqual(NnumberOfPlayersBefore + 1, manager.GetAll().Count());
            Assert.AreEqual(testPlayer.Name, manager.GetById(testPlayer.Id).Name);
        }

        [TestMethod()]
        public void AddInvalidDataTest()
        {
            testPlayer.Age = int.MinValue;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => manager.Add(testPlayer));
        }

        [TestMethod()]
        public void AddEdgeDataTest()
        {
            var NnumberOfPlayersBefore = manager.GetAll().Count();

            testPlayer.Name = "Aa";
            testPlayer.ShirtNumber = 1;
            testPlayer.Age = 1;

            manager.Add(testPlayer);

            Assert.AreEqual(NnumberOfPlayersBefore + 1, manager.GetAll().Count());
            Assert.AreEqual(testPlayer.Name, manager.GetById(testPlayer.Id).Name);
        }
    }
}