using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Metoder
    {

        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("KontrolleraRader", MetUppgift2));
            l.Add(new proghubben.Solution("Summering av udda tal", MetUppgift3));

            return l;
        }
        static void MetUppgift2()
        {
            // vi är lite busiga här och använder en lambda funktion
            bool KontrolleraRader(string rad1, string rad2) => rad1 == rad2;

            string[] rader = new string[2];
            for (int i = 0; i < rader.Length; i++)
            {
                Console.Write($"rad {i + 1}: ");
                rader[i] = Console.ReadLine();
            }

            if (KontrolleraRader(rader[0], rader[1]))
            {
                Console.WriteLine("raderna är lika!");
            }
            else
            {
                Console.WriteLine("raderna är inte lika!");
            }
        }

        static void MetUppgift3()
        {
            int Add(int nr1, int nr2)
            {
                if (nr1 % 2 == 0 || nr2 % 2 == 0)
                {
                    Console.WriteLine("Bara udda tal tack.");
                    return 0;
                }

                Console.WriteLine(nr1 + nr2);
                return nr1 + nr2;
            }

            var a = Helpers.GetArguments<int>(2, "tal");

            int res = Add(a[0], a[1]);
            if(res != 0)
            {
                Console.WriteLine($"{a[0]}+{a[1]}={res}");
            }
        }
    }
}
