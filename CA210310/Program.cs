using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210310
{

    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            Fealdatok0307();
            Console.ReadKey();
        }

        private static void Fealdatok0307()
        {
            #region jatek
            int[] tippek = new int[5];

            Console.WriteLine("Milyen számokat szeretnél megjátszani?");
            for (int i = 0; i < tippek.Length;)
            {
                Console.Write($"{i + 1}. tipp: ");
                int tipp = int.Parse(Console.ReadLine());

                if(tipp >= 1 && tipp <= 90 && !tippek.Contains(tipp))
                {
                    tippek[i] = tipp;
                    i++;
                }
                else Console.WriteLine("\tnem jó, próbáld újra");
            }

            Console.Clear();
            #endregion

            #region sorsolas
            int[] nyeroszamok = new int[90];
            for (int i = 0; i < nyeroszamok.Length; i++) nyeroszamok[i] = i + 1;
            for (int i = 0; i < nyeroszamok.Length; i++)
            {
                int x = rnd.Next(nyeroszamok.Length);
                int y = rnd.Next(nyeroszamok.Length);

                int s = nyeroszamok[x];
                nyeroszamok[x] = nyeroszamok[y];
                nyeroszamok[y] = s;
            }
            Array.Resize(ref nyeroszamok, 5);
            #endregion

            #region eredmeny
            for (int i = 1; i <= 90; i++)
            {

                if(nyeroszamok.Contains(i))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                if(tippek.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("{0,2} ", i);
                Console.ResetColor();
                if (i % 10 == 0) Console.Write('\n');
            }
            int talalat = 0;
            foreach (var tipp in tippek)
            {
                if (nyeroszamok.Contains(tipp)) talalat++;
            }
            Console.WriteLine("\n\n");
            if(talalat > 1) Console.WriteLine("NYERTÉL!!!");
            Console.WriteLine($"Összesen {talalat} találatod volt!");
            #endregion
        }

        private static void Fealdatok0306()
        {
            int[] t = new int[50];

            int visz = 0;
            for (int i = 0; i < t.Length; )
            {
                int x = rnd.Next(10, 100);

                if(!t.Contains(x))
                {
                    t[i] = x;
                    i++;
                }
                visz++;
            }

            Array.Sort(t);

            for (int i = 0; i < t.Length; i++)
            {
                Console.Write($"{t[i]} ");
                if ((i + 1) % 10 == 0) Console.Write('\n');
            }

            Console.WriteLine($"\nValós iterációk száma generálásnál: {visz}");
        }
        private static void Fealdatok0305()
        {
            int[] t = new int[50];
            bool van13 = false;
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = rnd.Next(5, 50) * 2 + 1;
                if (t[i] == 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    van13 = true;
                }
                Console.Write(t[i] + " ");
                Console.ResetColor();
                if((i + 1) % 10 == 0) Console.Write("\n");
            }

            //Console.WriteLine(van13 ? "VAN 13" : "NINCS 13");

            if (van13) Console.WriteLine("VAN 13");
            else Console.WriteLine("NINCS 13");
        }
        private static void Fealdatok0304()
        {
            string[] nevek = new string[20];
            int i = 0;
            for (; i < nevek.Length; i++)
            {
                Console.Write("{0,2}. név: ", i + 1);
                string nev = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nev)) break;
                else nevek[i] = nev;
            }
            Array.Resize(ref nevek, i);

            Array.Sort(nevek);
            foreach (var nev in nevek) Console.Write($"{nev} ");
        }
        private static void Feladatok0303()
        {
            int[] t = new int[20];
            int a = 10;
            for (int i = 0; i < t.Length; i++)
            {
                //t[i] = rnd.Next(a, 10 + ((i+1) * 5));
                t[i] = rnd.Next(a, 100);
                a = t[i];
                Console.Write($"{a} ");
            }
        }
        private static void Feladatok0302()
        {
            int[] tomb = new int[20];

            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(50, 151);
            }

            Array.Sort(tomb);

            int sum = 0;
            int c = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 10 == 0)
                {
                    c++;
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write("{0,3} ", tomb[i]);

                Console.ResetColor();
                if ((i + 1) % 5 == 0) Console.Write("\n");
                sum += tomb[i];
                
            }

            Console.WriteLine($"\nElemek összege: {sum}");
            Console.WriteLine($"Elemek átlaga: {sum / (float)tomb.Length}");
            Console.WriteLine($"0ra végződők száma: {c}");
        }
        private static void Fealdatok0301v3()
        {
            string[] nevek = { "Bianka", "Emese", "Zsuzsanna", "Rita", "Renáta", };
            int[] magassagok = new int[5];

            for (int i = 0; i < nevek.Length; i++)
            {
                Console.Write($"Add meg {nevek[i]} magasságát: ");
                magassagok[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("-----------------");
            for (int i = 0; i < nevek.Length; i++)
                Console.WriteLine($"{nevek[i]} {magassagok[i]} cm magas");
            Console.WriteLine("-----------------");
            int sum = 0;
            foreach (int m in magassagok) sum += m;
            Console.WriteLine($"Átlagmagasság: {sum / (float)magassagok.Length}");
            Console.WriteLine("-----------------");
            Array.Sort(nevek, magassagok);
            for (int i = 0; i < nevek.Length; i++)
                Console.WriteLine($"{nevek[i]} {magassagok[i]} cm magas");
            Console.WriteLine("-----------------");
            Array.Sort(magassagok, nevek);
            Console.WriteLine($"A legmagasabb {nevek[nevek.Length - 1]}, ({magassagok.Last()} cm)");

            //elemek sorrendjének megfordítása a vektorban
            Array.Reverse(magassagok);
            foreach (var m in magassagok)
            {
                Console.Write(m + " ");
            }
        }
        private static void Feladatok0301v2()
        {
            //string[] nevek = new string[] { "I. Béla", "II. Béla", "III. Béla", "IV. Béla", "V. Béla", };
            string[] nevek = { "I. Béla", "II. Béla", "III. Béla", "IV. Béla", "V. Béla", };

            Console.WriteLine(nevek[0]);


            int[] szamok = new int[10];

            Console.WriteLine(szamok[2]);
        }
        private static void Fealdatok0301v1()
        {
            string[] nevek = new string[5];

            nevek[0] = "Bianka";
            nevek[1] = "Emese";
            nevek[2] = "Zsuzsanna";
            nevek[3] = "Rita";
            nevek[4] = "Renáta";

            for(int i = 0; i < nevek.Length; i++)
            {
                //nevek[i] += "cica";
                Console.WriteLine(nevek[i]);
            }
            Console.WriteLine("-----------------");
            foreach(string nev in nevek)
            {
                //a foreach-ben NEM tudok módosítani az éppen bejárt adatszerkezeten
                Console.WriteLine(nev);
            }
        }
    }
}
