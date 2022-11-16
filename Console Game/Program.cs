namespace Console_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Game";
            Console.CursorVisible = false;
            new Menu().Start();
        }
    }
}