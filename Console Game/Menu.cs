using static Console_Game.Helper;

namespace Console_Game
{
    class Menu
    {
        public static int CurrentTitle = 0; // 0 - default title. other number is index+1 of title in Assets/Title
        public static int CurrentOption = 0;

        string[] options = { "Start", "Create Assets Folders", "Exit" };
        bool assetsCreated = false;

        public void Start()
        {
            if (Directory.Exists(@"Assets"))
            {
                assetsCreated = true;
                options[1] = "Settings";
            }
            Console.Clear();
            Run();
        }
        
        private void ShowTitle(string title = "")
        {
            if (title.Trim() == "") Console.WriteLine(Defaults.Title);
            else Console.WriteLine(title);
        }

        public void Set()
        {
            options[1] = "Settings";
        }

        private void ShowOptions()
        {
            for(int i = 0; i < options.Length; i++)
            {
                string option = options[i];
                string prefix;

                if(i == CurrentOption)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                } else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (option == "Exit")
                {
                    Console.Write($"{prefix} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<<{option}>>");
                    Console.ResetColor();
                } else Console.WriteLine($"{prefix} <<{option}>>");
            }
            Console.ResetColor();
        }

        public void Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                ShowTitle();
                ShowOptions();
                keyPressed = Console.ReadKey(true).Key;
                if(!Directory.Exists(@"Assets"))
                {
                    options[1] = "Create Assets Folders";
                    assetsCreated = false;
                }

                if (keyPressed == ConsoleKey.DownArrow)
                    CurrentOption = ++CurrentOption >= options.Length ? 0 : CurrentOption;
                else if (keyPressed == ConsoleKey.UpArrow)
                    CurrentOption = --CurrentOption < 0 ? options.Length - 1 : CurrentOption;
            } while (keyPressed != ConsoleKey.Enter);
            if (CurrentOption == 0) new Levels().Start();
            else if (CurrentOption == 1) SecondOption();
            else Environment.Exit(0);
        }

        public void SecondOption()
        {
            if (!assetsCreated)
            {
                CreateAssetsFolder();
                options[1] = "Settings";
                Run();
            } else
            {
                options[1] = "Settings";
                new Settings().Start();
            }
        }

        public void CreateAssetsFolder()
        {
            string[] dirs = { "Title", "Levels" };
            new DirectoryInfo(@"Assets").Create();
            foreach(string dir in dirs)
            {
                new DirectoryInfo(@"Assets\\" + dir).Create();
            }
        }

        /*public void Exit()
        {
            Environment.Exit(0);
        }*/
    }
}