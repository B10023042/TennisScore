using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
		
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public bool IsDiffScore()
        {
            return SecondPlayerScore != FirstPlayerScore;
        }

        public string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore ? FirstPlayerName : SecondPlayerName;
        }

        public bool IsGamePoint()
        {
            return SecondPlayerScore > 3 || FirstPlayerScore > 3;
        }

        public bool IsDeuce()
        {
            var isSameScore = FirstPlayerScore == SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }

        public bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        public static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };


        public string SorceLookUp()
        {
            return Game._scoreLookup[FirstPlayerScore] + " " + Game._scoreLookup[SecondPlayerScore];
        }


        public string GamePointState()
        {
            if (IsAdv())
            {
                return AdvPlayer() + " Adv";
            }
            else
            {
                return AdvPlayer() + " Win";
            }
        }

        public string LookUpScoreResult()
        {
            return Game._scoreLookup[FirstPlayerScore] + " " + Game._scoreLookup[SecondPlayerScore];
        }

        public static string Deuce = "Deuce";

        public string SameScoreResult()
        {
            return Game._scoreLookup[FirstPlayerScore] + " All";
        }
    }
}