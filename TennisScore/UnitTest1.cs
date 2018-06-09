using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private int _gameId = 1;
        private TennisGame _tennisGame;

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(Substitute.For<IRepository<Game>>());
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGame(0, 0);
            ScoreShouldBe("Love All");
        }

        private void ScoreShouldBe(string expect)
        {
            var scoreResult = _tennisGame.ScoreResult(_gameId);
            Assert.AreEqual(expect, scoreResult);
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            Substitute.For<IRepository<Game>>().GetGame(_gameId).Returns(new Game {Id = _gameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore});
        }
    }
}