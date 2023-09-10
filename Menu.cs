using InstagramConsoleApp.classes;
using System.Text.Json;

namespace InstagramConsoleApp
{
    internal static class Menu
    {
       public static string[] MainMenuElements = {"\t\tU s e r","\t\tA d m i n","\t\tC l e a r   A l l   N o t i f i c a t i o n s","\t\tA b o u t","\t\tE x i t"};

        public static string[] UserMainElements = { "\t\tL o g   i n", "\t\tR e g i s t e r", "\t\tB a c k" };

        public static string[] AdminMainElements = { "\t\tN e w   P o s t", "\t\tR e m o v e   P o s t", "\t\tS h o w   N o t i f i c a t i o n s","\t\tI n f o   a b o u t   m e" ,"\t\tB a c k"};

        public static string[] PostSettingsForUser = { "\t\t\tLike", "\t\t\tComment", "\t\t\tBack" };
        

        public static int OtherMenu(string[] elements)
        {
            int count = 0;
            while (true)
            {
                Console.Clear();
                if (count == -1) count = elements.Length - 1;if (count == elements.Length) count = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if(i == count)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write($"{elements[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{elements[i]}");
                    }

                }
                var result = Console.ReadKey();
                if (result.Key == ConsoleKey.Enter) return count;

                switch (result.Key)
                {
                    case ConsoleKey.LeftArrow:
                        count--;
                        break;
                    case ConsoleKey.RightArrow:
                        count++;
                        break;

                }
            }
        }


        public static int Menu_(string[] elementsToShow)
        {
            int count = 0;
            while (true)
            {
                Console.Clear();
                if (count == -1) count = elementsToShow.Length - 1; if (count == elementsToShow.Length) count = 0;
                for (int i = 0; i < elementsToShow.Length; i++)
                {

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (i == count && i == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t{elementsToShow[i]} ");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else if (i == count)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t{elementsToShow[i]} ");
                        Console.WriteLine();
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine($"\t\t\t\t{elementsToShow[i]} ");
                        Console.WriteLine();

                    }
                }
                var result = Console.ReadKey();
                if (result.Key == ConsoleKey.Enter) return count;

                switch (result.Key)
                {
                    case ConsoleKey.UpArrow:
                        count--;
                        break;
                    case ConsoleKey.DownArrow:
                        count++;
                        break;

                }
            }

        }
    }
}
