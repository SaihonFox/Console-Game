namespace Console_Game
{
    class Helper
    {
        public static string StringRepeat(string str, int times)
        {
            string text = "";
            for (int i = 0; i < times; i++)
                text += str;
            return text;
        }

        public static string Colorize(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }
    }
}