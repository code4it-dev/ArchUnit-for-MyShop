namespace Common
{
    public static class MyLogger
    {
        public static void LogInfo(string text)
        {
            var baseColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {text}");
            Console.ForegroundColor = baseColor;
        }

        public static void LogError(string text)
        {
            var baseColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {text}");
            Console.ForegroundColor = baseColor;
        }
    }
}
