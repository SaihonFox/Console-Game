namespace Console_Game
{
    class Program
    {
        const int WindowWidth = 105;
        const int WindowHeight = 40;

        static void Main()
        {
            Console.Title = "Console Game";
            Console.CursorVisible = false;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(WindowWidth, WindowHeight);
            new Menu().Start();
        }
    }
}