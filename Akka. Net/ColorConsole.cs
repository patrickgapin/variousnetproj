using System;
namespace MovieStreaming
{
    public static class ColorConsole
    {
        public static void WriteLineGreen(string message, params object[] args) { WriteLineColor(ConsoleColor.Green, message, args); }

        public static void WriteLineYellow(string message, params object[] args) { WriteLineColor(ConsoleColor.Yellow, message, args); }

        public static void WriteLineRed(string message, params object[] args) { WriteLineColor(ConsoleColor.Red, message, args); }

        public static void WriteLineCyan(string message, params object[] args) { WriteLineColor(ConsoleColor.Cyan, message, args); }

        internal static void WriteLineGray(string message, params object[] args) { WriteLineColor(ConsoleColor.Gray, message, args); }

        internal static void WriteLineWhite(string message, params object[] args) { WriteLineColor(ConsoleColor.White, message, args); }

        internal static void WriteLineMagenta(string message, params object[] args) { WriteLineColor(ConsoleColor.Magenta, message, args); }

        private static void WriteLineColor(ConsoleColor color, string message, object[] args)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(string.Format(message, args));
            Console.ForegroundColor = beforeColor;
        }


    }
}
