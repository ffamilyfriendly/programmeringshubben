using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Selektion
    {
        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("Går det att bada?", SelUppgift6));
            l.Add(new proghubben.Solution("Är personen arbetsför?", SelUppgift7));
            l.Add(new proghubben.Solution("Vilket betyg får studenten?", SelUppgift8));
            l.Add(new proghubben.Solution("Introduktion till Switch", SelUppgift9));
            l.Add(new proghubben.Solution("Vinst eller förlust?", SelUppgift11));
            l.Add(new proghubben.Solution("Typ av triangel?", SelUppgift12));
            l.Add(new proghubben.Solution("En enkel meny", SelUppgift13));

            return l;
        }
        static void SelUppgift6()
        {
            Console.Write("har badet vatten (true/yes/y): ");
            string harVatten = Console.ReadLine().ToLower();
            string[] confirmOptions = { "yes", "true", "y" };
            if (!confirmOptions.Contains(harVatten))
            {
                Console.WriteLine("Badet måste ha vatten om Kajsa vill bada.");
                return;
            }

            Console.Write("vattnets temperatur: ");
            int.TryParse(Console.ReadLine(), out int vattenTemp);
            if (vattenTemp < 30 || vattenTemp > 42)
            {
                Console.WriteLine("vattnet har fel temperatur.");
                return;
            }

            Console.WriteLine("Kajsa kan bada!");
        }

        static void SelUppgift7()
        {
            Console.Write("Personens ålder: ");
            int.TryParse(Console.ReadLine(), out int ålder);
            string kategori = "";
            switch (ålder)
            {
                case int i when Helpers.Range(i, 16, 19):
                    kategori = "Tonåring";
                    break;
                case int i when Helpers.Range(i, 20, 29):
                    kategori = "Ung vuxen";
                    break;
                case int i when Helpers.Range(i, 30, 39):
                    kategori = "vuxen";
                    break;
                case int i when Helpers.Range(i, 40, 49):
                    kategori = "Medelålder";
                    break;
                case int i when Helpers.Range(i, 50, 64):
                    kategori = "Äldre";
                    break;
            }

            if (kategori.Length > 0)
            {
                Console.WriteLine($"Personens kategori är: {kategori}");
            }
            else
            {
                Console.WriteLine("Personen tillhör inte arbetsför kategori!");
            }
        }

        static void SelUppgift8()
        {
            Console.Write("Ange elevens skrivpoäng:");
            int.TryParse(Console.ReadLine(), out int skrivPoäng);
            Console.Write("Ange elevens extrapoäng:");
            int.TryParse(Console.ReadLine(), out int extraPoäng);
            int kombineradPoäng = skrivPoäng + extraPoäng;


            string betyg = "";
            bool fel = false;
            switch (kombineradPoäng)
            {
                case int i when Helpers.Range(i, 0, 60):
                    betyg = "U";
                    break;
                case int i when Helpers.Range(i, 60, 84):
                    betyg = "G";
                    break;
                case int i when Helpers.Range(i, 85, 100):
                    betyg = "VG";
                    break;
                default:
                    fel = true;
                    break;
            }

            if (betyg == "G" || betyg == "VG")
            {
                Console.WriteLine($"Studenten har avslutat kursen med betyget {betyg}!");
            }
            else if (fel)
            {
                Console.WriteLine("Något har gått fel vid inmatning");
            }
            else
            {
                Console.WriteLine("Studenten klarade inte kursen :(.");
            }
        }

        static void SelUppgift9()
        {
            string[] dagar = new string[] { "Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lördag", "Söndag" };
            Console.Write("Dag: ");
            int.TryParse(Console.ReadLine(), out int dag);

            if (dag > dagar.Length || dag < 0)
            {
                Console.WriteLine("Incorrect input.");
                return;
            }

            Console.WriteLine($"dag {dag}: {dagar[dag - 1]}");
        }

        static void SelUppgift11()
        {
            Console.Write("Köpvärde: ");
            int.TryParse(Console.ReadLine(), out int köpVärde);
            Console.Write("Säljvärde: ");
            int.TryParse(Console.ReadLine(), out int säljVärde);

            int delta = säljVärde - köpVärde;
            double utveckling = (double)säljVärde / (double)köpVärde - 1;

            Console.WriteLine($"{ (0 < delta ? "Vinst" : "Förlust") } {delta} ({ utveckling * 100 }%)");
        }

        static void SelUppgift12()
        {
            var args = Helpers.GetArguments<int>(3);
            var (x, y, z) = (args[0], args[1], args[2]);

            Console.WriteLine($"x ({x}), y ({y}), z ({z})");
            string typ = "oliksidig";
            if (x == y && y == z)
            {
                typ = "liksidig";
            }
            else if (x == y || y == z || z == x)
            {
                typ = "likbent";
            }

            Console.WriteLine($"Triangeln är {typ}");
        }

        static void SelUppgift13()
        {
            Console.WriteLine("Vad vill du göra?\n1: räkna arean av en cirkel\n2: räkna arean av en rektangel\n3: avsluta");
            char key = Console.ReadLine()[0];
            if (key != '1' && key != '2')
            {
                Console.WriteLine("Programmet avslutat.");
                return;
            }

            switch (key)
            {
                case '1':
                    Console.Write("Radie: ");
                    int.TryParse(Console.ReadLine(), out int r);
                    Console.WriteLine($"Radien på cirkeln är { Math.PI * Math.Pow(r, 2) }");
                    break;
                case '2':
                    var variables = Helpers.GetArguments<int>(2);
                    Console.WriteLine($"Arean på rektangeln är { variables[0] * variables[1] }");
                    break;
            }
        }
    }
}
