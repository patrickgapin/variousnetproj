using System;
namespace MovieStreaming
{
    public static class ColorConsole
    {
        public static void WriteLineGreen(string message) { WriteLineColor(ConsoleColor.Green, message); }

        public static void WriteLineYellow(string message) { WriteLineColor(ConsoleColor.Yellow, message); }

        public static void WriteLineRed(string message) { WriteLineColor(ConsoleColor.Red, message); }

        public static void WriteLineCyan(string message) { WriteLineColor(ConsoleColor.Cyan, message); }
        
        private static void WriteLineColor(ConsoleColor color, string message)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = beforeColor;
        }
    }
}
