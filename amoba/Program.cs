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
            bool fomenu = false;

            do
            {
                Console.Clear();
                Console.WriteLine("****Amőba játék****");
                Console.WriteLine("1. Játék indítása");
                Console.WriteLine("2. Téma választása");
                Console.WriteLine("3. Kilépés");

                string tema = "fekete";
                
                string valasztas = Console.ReadLine();
                if (valasztas == "1")
                {
                    jatek = true;
                    fomenu = false;
                }
                else if (valasztas == "2")
                {
                    Console.Clear();
                    Console.WriteLine("1. Fekete (alap)");
                    Console.WriteLine("2. Fehér");
                    Console.WriteLine("3. Kék");
                    Console.WriteLine("4. Cián");
                    Console.WriteLine("5. Vörös");
                    Console.WriteLine("6. Zöld");
                    string alvalasztas = Console.ReadLine();
                    if (alvalasztas == "1")
                    {
                        Console.Clear();
                        tema = "fekete";
                        fomenu = true;
                    }
                    else if (alvalasztas == "2")
                    {
                        Console.Clear();
                        tema = "fehér";
                        fomenu = true;
                    }
                    else if (alvalasztas == "3")
                    {
                        Console.Clear();
                        tema = "kék";
                        fomenu = true;
                    }
                    else if (alvalasztas == "4")
                    {
                        Console.Clear();
                        tema = "cián";
                        fomenu = true;
                    }
                    else if (alvalasztas == "5")
                    {
                        Console.Clear();
                        tema = "vörös";
                        fomenu = true;
                    }
                    else if (alvalasztas == "6")
                    {
                        Console.Clear();
                        tema = "zöld";
                        fomenu = true;
                    }
                    if (tema == "fekete")
                    {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (tema == "fehér")
                    {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (tema == "kék")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (tema == "cián")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (tema == "vörös")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (tema == "zöld")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.WriteLine("Kilépés...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } while (fomenu);

            while (jatek)
            {
                bool jatekmenet = true;
                Console.Clear();
                Kiir();

                string jatekos = lepes ? " o " : " x ";

                int xkoor = 0;
                int ykoor = 0;


                bool jatekb = true;
                while (jatekb)
                {
                    Console.WriteLine($"{jatekos} következik.");
                    Console.Write("Adja meg az első koordinátát (1-10) ('q' a kilépéshez): ");
                    string bemenet = Console.ReadLine();
                    if (bemenet == "q")
                    {
                        Console.WriteLine("Viszlát!");
                        jatekmenet = false;
                        break;
                    }

                    if (!int.TryParse(bemenet, out xkoor))
                    {
                        Console.WriteLine("Kérlek számot adj meg!");
                        continue;
                    }
                    Console.Write("Adja meg a második koordinátát (1-10) ('q' a kilépéshez): ");
                    string bemenet2 = Console.ReadLine();
                    if (bemenet2 == "q")
                    {
                        Console.WriteLine("Viszlát!");
                        jatekmenet = false;
                        break;
                    }
                    if (!int.TryParse(bemenet2, out ykoor))
                    {
                        Console.WriteLine("Kérlek számot adj meg!");
                        continue;
                    }
                    
                    else if (xkoor < 1 || xkoor > 10 || ykoor < 1 || ykoor > 10)
                    {
                        Console.WriteLine("Érvénytelen koordináta! Próbálja újra.");
                        continue;
                    }
                    else if (palya[xkoor-1, ykoor-1] != "   ")
                    {
                        Console.WriteLine("Ez a mező már foglalt! Próbálja újra.");
                        continue;
                    }
                    break; 
                }
                
                if(jatekmenet == false)
                {
                    break;
                }
                
                palya[xkoor-1, ykoor-1] = jatekos;

                
                lepes = !lepes;
            }
        }

        
        static void Kiir()
        {
             Console.Write("  ");
            for (int j = 1; j <= 10; j++)
            {
               
                Console.Write($" {j,2} ");  
            }
            Console.WriteLine();

            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int i = 0; i < 10; i++)
            {
                // Sor száma bal oldalon
                Console.Write($"{i + 1,2}|");

                // Cella tartalom
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(palya[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
                if (i != 9)
                    Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
                else
                    Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            }
        }
    }
}
