// See https://aka.ms/new-console-template for more information

using game1401_la_5;

Console.WriteLine("Hello, World!");
LearningActivity5_1();
LearningActivity5_2();

void LearningActivity5_1()
{
    HighscoreBoard highscoreBoard = new HighscoreBoard();
    Random randomScore = new Random();
    while (true)
    {
        GameSelection choice = ChooseOption();
        Console.Clear();
        switch (choice)
        {
            case GameSelection.Play:
                int newHighScore = randomScore.Next(1000, 1000000);
                Console.WriteLine($"You finished with a score of {newHighScore}");
                highscoreBoard.AddScore(newHighScore);
                break;
            case GameSelection.SeeHighScore:
                highscoreBoard.DisplayTopScores();
                break;
            case GameSelection.Exit:
                return;

        }
    }
}

GameSelection ChooseOption()
{
    bool validSelection = false;
    int selection = 0;
    while (!validSelection)
    {
        Console.WriteLine(
            "Would you like to:\n\t 1: Play again\n\t 2: See the list of high scores\n\t 3: Exit the game?");

        if (int.TryParse(Console.ReadLine(), out selection) && selection >= 1 && selection <= 3)
            validSelection = true;
    }
    return (GameSelection)selection;
}
//Be kind, rewind.
void LearningActivity5_2()
{
    //uhhhhhh
}

enum GameSelection
{
    Play = 1, SeeHighScore = 2, Exit = 3
}