using System;

namespace amoba
{
    internal class Program
    {
        static string[,] palya = new string[10, 10];

        static void Main(string[] args)
        {
            
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    palya[i, j] = "   ";

            bool lepes = false; 
            bool jatek = false;

          
            Console.WriteLine("****Amőba játék****");
            Console.WriteLine("1. Játék indítása");
            Console.WriteLine("2. Kilépés");

            string valasztas = Console.ReadLine();
            if (valasztas == "1")
            {
                jatek = true;
            }
            else
            {
                Console.WriteLine("Kilépés...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            
            while (jatek)
            {
                Console.Clear();
                Kiir();

                string jatekos = lepes ? " o " : " x ";

                int xkoor, ykoor;

                
                while (true)
                {
                    Console.WriteLine($"{jatekos} következik.");
                    Console.Write("Adja meg az első koordinátát (1-10): ");
                    if (!int.TryParse(Console.ReadLine(), out xkoor)) continue;
                    Console.Write("Adja meg a második koordinátát (1-10): ");
                    if (!int.TryParse(Console.ReadLine(), out ykoor)) continue;

                    if (xkoor < 1 || xkoor > 10 || ykoor < 1 || ykoor > 10)
                    {
                        Console.WriteLine("Érvénytelen koordináta! Próbálja újra.");
                        continue;
                    }
                    if (palya[xkoor, ykoor] != "   ")
                    {
                        Console.WriteLine("Ez a mező már foglalt! Próbálja újra.");
                        continue;
                    }
                    break; 
                }

                
                palya[xkoor-1, ykoor-1] = jatekos;

                
                lepes = !lepes;
            }
        }

        
        static void Kiir()
        {
            Console.WriteLine("┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(palya[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
                if (i != 9)
                    Console.WriteLine("├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
                else
                    Console.WriteLine("└───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            }
        }
    }
}
