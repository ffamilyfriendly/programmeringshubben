using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Arrayer
    {
        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("Strukturerad utskrift", ArrUppgift2));
            l.Add(new proghubben.Solution("Strukturerad utskrift II", ArrUppgift3));
            l.Add(new proghubben.Solution("Beräkna medelvärdet", ArrUppgift8));
            l.Add(new proghubben.Solution("Rekursiv metod (Fakultet II)", ArrUppgift10));
            l.Add(new proghubben.Solution("Primtal?", ArrUppgift11));
            l.Add(new proghubben.Solution("Summering av arrayer", ArrUppgift20));
            l.Add(new proghubben.Solution("PrintUniques", ArrUppgift22));
            l.Add(new proghubben.Solution("Sort array", ArrUppgift23));
            l.Add(new proghubben.Solution("IsDuplicate", ArrUppgift24));

            return l;
        }
        static void ArrUppgift2()
        {
            void PrintNumbersTwo()
            {
                for (int i = 0; i <= 50; i++)
                {
                    if (i % 10 == 0 && i != 0)
                    {
                        Console.Write(i + "\n");
                    }
                    else
                    {
                        Console.Write(i + ", ");
                    }
                }
            }

            PrintNumbersTwo();
        }

        static void ArrUppgift3()
        {
            void NestedPrint(int len, char ikon = '*')
            {
                for (int i = 0; i < len; i++)
                {
                    bool nested = false;

                    if (nested)
                    {
                        for (int j = 0; j < i + 1; j++)
                            Console.Write(ikon);
                        Console.Write("\n");
                    }
                    else
                    {
                        // Smidig "one-liner" för detta problem
                        Console.WriteLine(new string(ikon, i + 1));
                    }
                }
            }

            void NestedPrint2(int len, char ikon = '*')
            {
                for (int i = 0; i < len; i++)
                {
                    int padding = (len - i);
                    string pad = new string(' ', padding);
                    Console.Write(pad);
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.Write(ikon + " ");
                    }
                    Console.WriteLine();
                }
            }

            void NestedPrint3(int len)
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.Write(i + 1);
                    }
                    Console.WriteLine();
                }
            }

            void NestedPrint4(int len, char ikon = '*')
            {
                int width = len * 2;
                int drawAmount = 1;
                for (int i = 0; i < len; i++)
                {
                    if (i != 0) drawAmount += 2;
                    Console.Write(new string(' ', width - drawAmount));
                    for (int j = 0; j < drawAmount; j++)
                    {
                        Console.Write(ikon + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.Write("Längd: ");
            int.TryParse(Console.ReadLine(), out int längd);
            Console.Write("stil (1/2/3/4): ");
            char stil = Console.ReadLine()[0];

            switch (stil)
            {
                case '1':
                    NestedPrint(längd);
                    break;
                case '2':
                    NestedPrint2(längd);
                    break;
                case '3':
                    NestedPrint3(längd);
                    break;
                case '4':
                    NestedPrint4(längd);
                    break;
            }
        }

        static void ArrUppgift8()
        {
            bool run = true;

            int tally = 0, items = 0;

            while (run)
            {
                Console.Write("Ange ett heltal (-1 för att avsluta): ");
                int.TryParse(Console.ReadLine(), out int nr);

                if (nr == -1)
                {
                    Console.WriteLine($"Medelvärdet är {tally / items} ({tally}/{items})");
                    run = false;
                }
                else
                {
                    tally += nr;
                    items += 1;
                }
            }
        }

        static void ArrUppgift10()
        {
            int Factorial(int target, int depth = 1)
            {
                if (target == depth)
                {
                    return depth;
                }
                else
                {
                    return Factorial(target, depth + 1) * depth;
                }
            }

            Console.Write("Ange heltal att faktorisera: ");
            int.TryParse(Console.ReadLine(), out int nr);
            Console.WriteLine($"!{nr} är {Factorial(nr)}");
        }

        static void ArrUppgift11()
        {
            bool IsPrime(int n)
            {
                if (n == 2) return true;
                if (n % 2 == 0) return false;

                for (int i = 3; i < n; i += 2)
                {
                    if (n % i == 0)
                        return false;
                }


                return true;
            }

            Console.Write("Ange ett heltal: ");
            int.TryParse(Console.ReadLine(), out int nr);
            Console.WriteLine($"{nr} { (IsPrime(nr) ? "är" : "är inte") } ett primtal");
        }

        static void ArrUppgift20()
        {
            int[] SumArrays(int[] a, int[] b)
            {
                int smallest = Math.Min(a.Length, b.Length);
                int[] rv = new int[smallest];

                for (int i = 0; i < smallest; i++)
                    rv[i] = a[i] + b[i];

                return rv;
            }

            var arrA = new int[] { 5, 3, 4 };
            var arrB = new int[] { 13, 1, 10 };
            Console.WriteLine(Helpers.PrettyPrint(SumArrays(arrA, arrB)));
        }

        static void ArrUppgift22()
        {
            void PrintUniques(int[] arr)
            {
                Dictionary<int, int> timesSeen = new Dictionary<int, int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    timesSeen.TryGetValue(arr[i], out int times);
                    if (times == 0)
                    {
                        timesSeen.Add(arr[i], 1);
                    }
                    else
                    {
                        timesSeen[arr[i]] = times + 1;
                    }
                }

                var uniques = new List<int>();
                foreach (var entry in timesSeen)
                {
                    if (entry.Value == 1) uniques.Add(entry.Key);
                }

                if (uniques.Count == 0)
                {
                    Console.WriteLine("There are no unique values in the array.");
                }
                else
                {
                    Console.WriteLine(Helpers.PrettyPrint(uniques.ToArray()));
                }
            }
            int[] testArr = Helpers.GetArguments<int>(6, "element");
            PrintUniques(testArr);
        }

        static void ArrUppgift23()
        {
            // Har aldrig vågat mig på att skriva sorteringsfunktion tidigare.
            // har hört talas om en alg där du går från vänster till höger och jämför 2 element
            // om det vänstra är av större värde så byter du plats på de två elementen och fortsätter med detta
            // tills det att inga element flyttas under en itteration
            int[] SimpleSort(int[] arr)
            {
                int[] sorted = arr;
                bool doSort = true;

                // inte viktigt för funktionalitet men alltid kul att veta :)
                int passes = 0;

                while (doSort)
                {
                    bool hasAltered = false;
                    passes += 1;

                    for (int i = 0; i < sorted.Length - 1; i++)
                    {
                        if (sorted[i] > sorted[i + 1])
                        {
                            // byt plats på de två elementen
                            var temp = sorted[i];
                            sorted[i] = sorted[i + 1];
                            sorted[i + 1] = temp;

                            hasAltered = true;
                        }
                    }

                    if (!hasAltered) doSort = false;
                }

                Console.WriteLine($"Sorteringen tog {passes} försök.");
                return sorted;
            }

            var testArray = new int[] { 6, 3, 420, 64, 23123, 1, 8, -1, -999999, 2323, 4, 3 };

            Console.WriteLine(Helpers.PrettyPrint(SimpleSort(testArray)));

            Console.WriteLine("\ntestar att sortera en 20000 lång array...");
            var bigTestArray = Helpers.GenerateList(20000, 1, true);
            SimpleSort(bigTestArray);
        }

        static void ArrUppgift24()
        {
            bool IsDuplicate(int[] arr, int target)
            {
                bool seenOnce = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    bool matchesTarget = arr[i] == target;
                    if (matchesTarget && !seenOnce) seenOnce = true;
                    else if (matchesTarget && seenOnce) return true;
                }

                return false;
            }

            var dupe = IsDuplicate(new int[] { 6, 3, 1, 8, 4, 3 }, 3);
            Console.WriteLine(dupe);
        }
    }
}
