namespace Console_Game
{
    class Defaults
    {
        public static string Title = 
            " ▄████▄   ▒█████   ███▄    █   ██████  ▒█████   ██▓    ▓█████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████ \r\n" +
            "▒██▀ ▀█  ▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ ▒██▒  ██▒▓██▒    ▓█   ▀     ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ \r\n" +
            "▒▓█    ▄ ▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   ▒██░  ██▒▒██░    ▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   \r\n" +
            "▒▓▓▄ ▄██▒▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒▒██   ██░▒██░    ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ \r\n" +
            "▒ ▓███▀ ░░ ████▓▒░▒██░   ▓██░▒██████▒▒░ ████▓▒░░██████▒░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒\r\n" +
            "░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░ ▒░▓  ░░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░\r\n" +
            "  ░  ▒     ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░  ░ ▒ ▒░ ░ ░ ▒  ░ ░ ░  ░     ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░\r\n" +
            "░        ░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  ░ ░ ░ ▒    ░ ░      ░      ░ ░   ░   ░   ▒   ░      ░      ░   \r\n" +
            "░ ░          ░ ░           ░       ░      ░ ░      ░  ░   ░  ░         ░       ░  ░       ░      ░  ░\r\n" +
            "░";

        public static ConsoleColor Player = ConsoleColor.Blue;
        public static ConsoleColor Door = ConsoleColor.DarkYellow;
        public static ConsoleColor Wall = ConsoleColor.Gray;
        public static ConsoleColor Grass = ConsoleColor.Green;
        public static ConsoleColor Exit = ConsoleColor.Red;
        public static ConsoleColor Coin = ConsoleColor.Yellow;

        public static string[] Map = {
            "-----------",
            "-----P-----",
            "----WWWWW--",
            "----W---W--",
            "----D---W--",
            "----WWWWW--",
            "-----------"
        };
    }
}