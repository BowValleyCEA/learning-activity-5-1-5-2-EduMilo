namespace game1401_la_5
{
    internal class HighscoreBoard
    {
        private List<(int score, string intials)> _highScoresAndInitials = new List<(int, string)>(); //tuples :)


        public void AddScore(int newScore, string newInitials)
        {
            //places score in the right place on the board
            _highScoresAndInitials.Add((newScore, newInitials));
        }

        private void SortScores()
        {
            //sorts all the scores
            _highScoresAndInitials.Sort(); //ascending order
            _highScoresAndInitials.Reverse();
        }
        public void DisplayTopScores()
        {
            SortScores();
            Console.WriteLine("HIGHSCORES:");
            for(int i = 0; i < Math.Min(_highScoresAndInitials.Count, 10); i++)
            {
                Console.WriteLine($"{i+1} - {_highScoresAndInitials[i].intials} {_highScoresAndInitials[i].score}");
            }
        }
    }
}
