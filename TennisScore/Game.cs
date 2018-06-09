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
            var isSameScore = FirstPlayerScore==SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }
    }
}