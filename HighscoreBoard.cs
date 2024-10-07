namespace game1401_la_5
{
    internal class HighscoreBoard
    {
        List<int> _highScores = new List<int>();

        public void AddScore(int newScore)
        {
            //places score in the right place on the board
            _highScores.Add(newScore);
        }

        void SortScores()
        {
            //sorts all the scores
            _highScores.Sort(); //ascending order
            _highScores.Reverse();
        }
        public void DisplayTopScores()
        {
            SortScores();
            Console.WriteLine("HIGHSCORES:");
            for(int i = 0; i < Math.Min(_highScores.Count, 10); i++)
            {
                Console.WriteLine($"{i+1} - {_highScores[i]}");
            }
        }
    }
}
