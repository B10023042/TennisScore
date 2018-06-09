﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private int _gameId = 1;
        private TennisGame _tennisGame;
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGame(0, 0);
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(1, 0);
            ScoreShouldBe("Fifteen Love");
        }
        [TestMethod]
        public void Thirty_Love()
        {
            GivenGame(2, 0);
            ScoreShouldBe("Thirty Love");
        }
        [TestMethod]
        public void Forty_Love()
        {
            GivenGame(3, 0);
            ScoreShouldBe("Forty Love");
        }
        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGame(0, 1);
            ScoreShouldBe("Love Fifteen");
        }
        [TestMethod]
        public void Love_Thirty()
        {
            GivenGame(0, 2);
            ScoreShouldBe("Love Thirty");
        }
        private void ScoreShouldBe(string expect)
        {
            var scoreResult = _tennisGame.ScoreResult(_gameId);
            Assert.AreEqual(expect, scoreResult);
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(_gameId).Returns(new Game {Id = _gameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore});
        }
    }
}