namespace InstagramConsoleApp
{
    internal static class Other
    {
       public  static void TypeLine(string ? line)
        {
            for (int i = 0; i < line!.Length; i++)
            {
                Console.Write($"{line[i]}");
                Thread.Sleep(41);
            }
        }
    }
}
