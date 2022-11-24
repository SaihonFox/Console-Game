namespace Console_Game
{
    class Levels
    {
        int CurrentLevel = 0;
        List<string> levels = new List<string>() { "First" };

        bool isLevelsFolderCreated;

        public void Start(int setCurrrentLevel = 0)
        {
            isLevelsFolderCreated = Directory.Exists(@"Assets\Levels\");
            if(isLevelsFolderCreated)
            {
                Directory.GetFiles(@"Assets\Levels\").ToList().ForEach(files =>
                {
                    FileInfo file = new FileInfo(files);
                    if(file.Name.EndsWith(".level"))
                    {
                        levels.Add(file.Name.Replace(".level", ""));
                    }
                });
            }

            CurrentLevel = setCurrrentLevel;
            Console.Clear();
            Run();
        }

        public void ShowLevels()
        {
            for (int i = 0; i < levels.Count; i++)
            {
                string level = levels[i];
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
                    CurrentLevel = ++CurrentLevel >= levels.Count ? 0 : CurrentLevel;
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    CurrentLevel = --CurrentLevel < 0 ? levels.Count - 1 : CurrentLevel;
                }
                else if (keyPressed == ConsoleKey.Escape) new Menu().Start();
            } while (keyPressed != ConsoleKey.Enter);

            if (CurrentLevel == 0) new Game().Start(null);
            else new Game().Start(File.ReadLines("Assets/Levels/" + levels[CurrentLevel] + ".level").ToList());
        }
    }
}