using System.Collections;
using static Console_Game.Helper;

namespace Console_Game
{
    class Game
    {
        int playerCoordsRow = 1;
        int playerCoordsIndex = 5;

        int id = 0;

        int coins = 0;

        Dictionary<string, int> items = new Dictionary<string, int>();

        static string[] mapCopy =
        {
            "-----------",
            "-----P-----",
            "----WWWWW--",
            "----W---W--",
            "----D---W--",
            "----WWWWW--",
            "-----------"
        };

        List<string> mapL = new List<string>()
        {
            "-----------",
            "-C---P-----",
            "----WWWWW--",
            "----W--EW--",
            "-C--D---W--",
            "CC--WWWWW--",
            "-----C-----"
        };

        List<int[]> doorsCoords = new List<int[]>();
        List<int[]> coinsCoords = new List<int[]>();

        public Game(int id = 0)
        {
            this.id = id;
        }

        public void setMap(string[] map)
        {
            mapL = map.ToList();
        }

        public void Start()
        {
            Console.Clear();

            for (int i = 0; i < mapL.Count; i++)
                for (int j = 0; j < mapL[i].Length; j++)
                    if (mapL[i][j] == 'D')
                        doorsCoords.Add(new int[] { i, j });
            for (int i = 0; i < mapL.Count; i++)
                for (int j = 0; j < mapL[i].Length; j++)
                    if (mapL[i][j] == 'C')
                        coinsCoords.Add(new int[] { i, j });

            Run();
        }

        public void Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();

                int borderLength = mapL[0].Length;

                for (int x = 0; x < mapL.Count; x++)
                {
                    if (x == 0) Console.WriteLine(StringRepeat("#", borderLength + 2));
                    Console.Write("#");
                    foreach(char elem in mapL[x])
                    {
                        switch (elem)
                        {
                            case 'P':
                                Console.ForegroundColor = Defaults.Player;
                                Console.BackgroundColor = Defaults.Player;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            case '-':
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            case 'W':
                                Console.ForegroundColor = Defaults.Wall;
                                Console.BackgroundColor = Defaults.Wall;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            case 'E':
                                Console.ForegroundColor = Defaults.Exit;
                                Console.BackgroundColor = Defaults.Exit;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            case 'D':
                                Console.ForegroundColor = Defaults.Door;
                                Console.BackgroundColor = Defaults.Door;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            case 'C':
                                Console.ForegroundColor = Defaults.Coin;
                                Console.BackgroundColor = Defaults.Coin;
                                Console.Write(elem);
                                Console.ResetColor();
                                break;
                            default:
                                Console.Write(elem);
                                break;
                        }
                    }
                    Console.WriteLine("#");
                    if(x == mapL.Count - 1) Console.WriteLine(StringRepeat("#", borderLength + 2));
                }

                Console.WriteLine();
                Console.WriteLine("Coins - " + coins);
                Console.WriteLine();
                Console.WriteLine(Colorize("P", Defaults.Player, Defaults.Player) + " - Player");
                Console.WriteLine(Colorize("W", Defaults.Wall, Defaults.Wall) + " - Wall");
                Console.WriteLine(Colorize("-", ConsoleColor.Black) + " - Free Space");
                Console.WriteLine(Colorize("D", Defaults.Door, Defaults.Door) + " - Door");
                Console.WriteLine(Colorize("C", Defaults.Coin, Defaults.Coin) + " - Coin");
                Console.WriteLine(Colorize("E", Defaults.Exit, Defaults.Exit) + " - Exit");

                keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (playerCoordsRow != 0)
                    {
                        if (mapL[playerCoordsRow - 1][playerCoordsIndex] != 'W')
                        {
                            if(mapL[playerCoordsRow - 1][playerCoordsIndex] == 'C') coins++;

                            System.Text.StringBuilder lineUp = new System.Text.StringBuilder(mapL[playerCoordsRow - 1]);
                            lineUp[playerCoordsIndex] = 'P';
                            System.Text.StringBuilder line = new System.Text.StringBuilder(mapL[playerCoordsRow]);
                            line[playerCoordsIndex] = '-';
                            mapL[playerCoordsRow - 1] = lineUp.ToString();
                            mapL[playerCoordsRow] = line.ToString();

                            foreach (int[] iCoords in doorsCoords)
                            {
                                if (iCoords[0] == playerCoordsRow && iCoords[1] == playerCoordsIndex)
                                {
                                    line[playerCoordsIndex] = 'D';
                                    mapL[playerCoordsRow] = line.ToString();
                                }
                            }

                            playerCoordsRow--;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (playerCoordsRow != mapL.Count - 1)
                    {
                        if (mapL[playerCoordsRow + 1][playerCoordsIndex] != 'W')
                        {
                            if (mapL[playerCoordsRow + 1][playerCoordsIndex] == 'C') coins++;

                            System.Text.StringBuilder lineDown = new System.Text.StringBuilder(mapL[playerCoordsRow + 1]);
                            lineDown[playerCoordsIndex] = 'P';
                            System.Text.StringBuilder line = new System.Text.StringBuilder(mapL[playerCoordsRow]);
                            line[playerCoordsIndex] = '-';
                            mapL[playerCoordsRow + 1] = lineDown.ToString();
                            mapL[playerCoordsRow] = line.ToString();

                            foreach (int[] iCoords in doorsCoords)
                            {
                                if (iCoords[0] == playerCoordsRow && iCoords[1] == playerCoordsIndex)
                                {
                                    line[playerCoordsIndex] = 'D';
                                    mapL[playerCoordsRow] = line.ToString();
                                }
                            }

                            playerCoordsRow++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (playerCoordsIndex != mapL[0].Length - 1)
                    {
                        if (mapL[playerCoordsRow][playerCoordsIndex + 1] != 'W')
                        {
                            if (mapL[playerCoordsRow][playerCoordsIndex + 1] == 'C') coins++;

                            System.Text.StringBuilder lineRight = new System.Text.StringBuilder(mapL[playerCoordsRow]);
                            lineRight[playerCoordsIndex + 1] = 'P';
                            lineRight[playerCoordsIndex] = '-';
                            mapL[playerCoordsRow] = lineRight.ToString();

                            foreach (int[] iCoords in doorsCoords)
                            {
                                if (iCoords[0] == playerCoordsRow && iCoords[1] == playerCoordsIndex)
                                {
                                    lineRight[playerCoordsIndex] = 'D';
                                    mapL[playerCoordsRow] = lineRight.ToString();
                                }
                            }

                            playerCoordsIndex++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (playerCoordsIndex != 0)
                    {
                        if (mapL[playerCoordsRow][playerCoordsIndex - 1] != 'W')
                        {
                            if (mapL[playerCoordsRow][playerCoordsIndex - 1] == 'C') coins++;

                            System.Text.StringBuilder lineRight = new System.Text.StringBuilder(mapL[playerCoordsRow]);
                            lineRight[playerCoordsIndex - 1] = 'P';
                            lineRight[playerCoordsIndex] = '-';
                            mapL[playerCoordsRow] = lineRight.ToString();

                            foreach (int[] iCoords in doorsCoords)
                            {
                                if (iCoords[0] == playerCoordsRow && iCoords[1] == playerCoordsIndex)
                                {
                                    lineRight[playerCoordsIndex] = 'D';
                                    mapL[playerCoordsRow] = lineRight.ToString();
                                }
                            }

                            playerCoordsIndex--;
                        }
                    }
                }

            } while (keyPressed != ConsoleKey.Escape);

            Levels menu = new Levels();
            menu.Start(id);
            Console.ReadKey(true);
        }

        public string Colorize(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }
    }
}