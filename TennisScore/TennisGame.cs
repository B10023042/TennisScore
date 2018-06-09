using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            var scoreLookup = new Dictionary<int, string>
            {
                [0] = "Love",
                [1] = "Fifteen",
                [2] = "Thirty",
                [3] = "Forty"
            };
            if (game.IsDiffScore())
            {
                if (game.IsGamePoint())
                {
                    if (Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
                    {
                        return game.AdvPlayer() + " Adv";

                    }
                    else
                    {
                        return game.AdvPlayer() + " Win";
                    }
                }


                return scoreLookup[game.FirstPlayerScore] + " " + scoreLookup[game.SecondPlayerScore];
            }
            if (game.IsDeuce())
            {
                return "Deuce";
            }
            return scoreLookup[game.FirstPlayerScore] + " All";

        }
    }
}