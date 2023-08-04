using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Datatyper
    {

        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("Hello, Name!", Uppgift2));
            l.Add(new proghubben.Solution("Modifiering av datatyper - Konvertering", Uppgift3));
            l.Add(new proghubben.Solution("Summera två heltal", Uppgift6));
            l.Add(new proghubben.Solution("Division av heltal", Uppgift7));
            l.Add(new proghubben.Solution("Korrekt beräkning", Uppgift10));
            l.Add(new proghubben.Solution("Modulus", Uppgift13));

            return l;
        }
        static void Uppgift2()
        {
            Console.WriteLine("Ditt namn:");
            string name = Console.ReadLine();
            Console.WriteLine($"Tack, {name}. Vad är din address?");
            string addr = Console.ReadLine();

            // Skriv ut
            Console.WriteLine($"Du heter {name} och bor på {addr}");
        }

        static void Uppgift3()
        {
            Console.WriteLine("Ge mig ett nummer:");
            string strNumber = Console.ReadLine();

            int parsedNumber;

            bool success = int.TryParse(strNumber, out parsedNumber);

            if (success)
            {
                Console.WriteLine($"Du valde nummret {parsedNumber}.");
            }
            else
            {
                Console.WriteLine($"Du skrev {strNumber} vilket inte kunde tydas. Tänk på att ditt nummer måste vara ett heltal dvs får inte innehålla decimaler.");
            }

        }

        static void Uppgift6()
        {
            Console.WriteLine("Nummer 1:");
            bool nr1Cont = int.TryParse(Console.ReadLine(), out int nr1);
            Console.WriteLine("Nummer 2:");
            bool nr2Cont = int.TryParse(Console.ReadLine(), out int nr2);

            // Hantera de fall där ints inte kunde tydas
            if (!nr1Cont || !nr2Cont)
            {
                Console.WriteLine($"Något gick fel med att tyda dina nummer.\nnr 1: { (nr1Cont ? "OK" : "ERR") }\nnr 2: { (nr2Cont ? "OK" : "ERR") }");
                return;
            }

            // Vi använder en 64 bitars int här eftersom nr1 + nr2 kan överstiga vad en int32 kan hålla vilket skulle få den att flöda över och bli negativ
            Int64 sum = (Int64)nr1 + (Int64)nr2;

            Console.WriteLine($"{nr1} + {nr2} = {sum}");
        }

        static void Uppgift7()
        {
            // Konverera nummer från konsolen. Byter ut "." mot "," eftersom float.TryParse funktionen förväntar sig karaktären "," som brytpunkt för decimaler
            Console.WriteLine("Nummer 1:");
            bool nr1Cont = float.TryParse(Console.ReadLine().Replace('.', ','), out float nr1);
            Console.WriteLine("Nummer 2:");
            bool nr2Cont = float.TryParse(Console.ReadLine().Replace('.', ','), out float nr2);

            // Hantera de fall där ints inte kunde tydas
            if (!nr1Cont || !nr2Cont)
            {
                Console.WriteLine($"Något gick fel med att tyda dina nummer.\nnr 1: { (nr1Cont ? "OK" : "ERR") }\nnr 2: { (nr2Cont ? "OK" : "ERR") }");
                return;
            }

            float sum = nr1 / nr2;

            Console.WriteLine($"{nr1}/{nr2} = {sum}");
        }

        static void Uppgift10()
        {
            int[] nrs = new int[3];

            for (int i = 0; i < nrs.Length; i++)
            {
                Console.Write((char)('x' + i) + ": ");
                if (int.TryParse(Console.ReadLine(), out int nr))
                {
                    nrs[i] = nr;
                }
                else
                {
                    Console.WriteLine("kunde inte tyda numret. Tänk på att det måste vara ett heltal så inkludera inga decimaltäcken eller bokstäver.");
                    i -= 1;
                }
            }

            // (x + y) * z
            int op1 = (nrs[0] + nrs[1]) * nrs[2];
            Console.WriteLine("Första kalkylationen: " + op1);
            // x * y + y * z
            int op2 = nrs[0] * nrs[1] + nrs[1] * nrs[2];
            Console.WriteLine("Andra kalkylationen: " + op2);
        }

        static void Uppgift13()
        {
            Console.Write("Ange ett heltal: ");
            if (int.TryParse(Console.ReadLine(), out int nr))
            {
                Console.WriteLine($"Resten efter division är: {nr % 2}");
            }
            else
            {
                Console.WriteLine("kunde inte tyda numret.");
            }
        }
    }
}
