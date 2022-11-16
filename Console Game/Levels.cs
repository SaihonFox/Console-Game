namespace Console_Game
{
    class Levels
    {
        private int CurrentLevel = 0;
        private string[] levels = { "First", "Test", "Chat", "ABIBA", "ABOBA" };

        bool isAssetsFolderCreated = false;

        public void Start(int setCurrrentLevel = 0)
        {
            CurrentLevel = setCurrrentLevel;
            Console.Clear();
            Run();
        }

        public void ShowLevels()
        {
            for (int i = 0; i < this.levels.Length; i++)
            {
                string level = this.levels[i];
                string prefix;

                if (i == CurrentLevel)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix} <<{level}>>");
            }
            Console.ResetColor();
        }

        public void Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                ShowLevels();
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    CurrentLevel = ++CurrentLevel >= levels.Length ? 0 : CurrentLevel;
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    CurrentLevel = --CurrentLevel < 0 ? levels.Length - 1 : CurrentLevel;
                }
                else if (keyPressed == ConsoleKey.Escape) new Menu().Start();
            } while (keyPressed != ConsoleKey.Enter);
            
            if (CurrentLevel == 0) new Game().Start();
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCurrent level doesn't ready now. Press Esc");
                Console.ResetColor();
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) new Levels().Start(CurrentLevel);
            }
        }
    }
}