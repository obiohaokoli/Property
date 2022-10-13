namespace Obioha_VillaAPI.Logger
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "Error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Error -  "  + message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (type == "warning")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning -  " +  message);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
               // Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
