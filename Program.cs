using textdungeon.Play;

namespace textdungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.BufferWidth = 120;
            Console.WindowHeight = 40;
            Console.BufferHeight = 40;

            // 게임 구동
            Game game = new Game();
        }
    }
}
