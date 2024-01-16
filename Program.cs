using textdungeon.Play;

namespace textdungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.BufferWidth = 120;
            Console.WindowHeight = 39;
            Console.BufferHeight = 39;

            // 게임 구동
            Game game = new Game();
            game.StartMenu();
        }
    }
}
