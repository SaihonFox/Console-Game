namespace Console_Game
{
    class Settings
    {
        string[] settings =
        {
            "Back"
        };

        public void Start()
        {
            Run();
        }

        public void Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                keyPressed = Console.ReadKey(true).Key;
            } while (keyPressed != ConsoleKey.Escape);
            new Menu().Start();
        }
    }
}