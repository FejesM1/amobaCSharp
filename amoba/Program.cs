using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace amoba
{
    internal class Program
    {
        static string[,] palya = new string[10, 10];
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    palya[i, j] = "   ";
                }
            }

           
            Kiir();

            Console.ReadLine();
            Console.WriteLine("Adja meg az elso koordinátát: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Adja meg a második koordinátát: ");
            int y = Convert.ToInt32(Console.ReadLine());

           
        }
        static void Kiir()
        {
            Console.WriteLine("┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");

            for (int c = 0; c < 10; c++)
            {
                Console.Write("|");
                for (int o = 0; o < 10; o++)
                {
                    Console.Write(palya[c, o]);
                    Console.Write('|');
                }

                Console.WriteLine();
                if (c != 9)
                {
                    Console.WriteLine("├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");

                }
                else
                {
                    Console.WriteLine("└───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
                }
            }
            void Lep(int x, int y, string jel)
            {
                if (x < 0 || x >= 10 || y < 0 || y >= 10)
                {
                    Console.WriteLine("Érvénytelen koordináta");
                }
                if (palya[x, y] == "   ")
                {
                    palya[x, y] = jel;
                }
                else
                {
                    Console.WriteLine("Ez a mező már foglalt!");                
                }

            }
        }
    }
}   
