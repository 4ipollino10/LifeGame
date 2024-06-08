namespace LifeGame;

public static class Game
{
    private static GameFieldMatrix _gameFieldMatrix = null!;

    public static void Start()
    {
        InitializeGameFiled();
        StartGame();
    }

    private static void InitializeGameFiled()
    {
        _gameFieldMatrix = new GameFieldMatrix();
    }

    private static void StartGame()
    {
        _gameFieldMatrix.SetStartCells();
        
        while (true)
        {
            _gameFieldMatrix.Print();
            Thread.Sleep(500);
            _gameFieldMatrix.NextTurn();
            Console.Clear();
        }
    }
}