using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Problem
    {
        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("Summering och sammanslagning av arrayer (Enkel)", Problem1));
            l.Add(new proghubben.Solution("Prisberäkning för inträde (Enkel)", Problem2));
            l.Add(new proghubben.Solution("Palindrom (Enkel/Medel)", Problem12));
            l.Add(new proghubben.Solution("RotateArrayBy2 (Medel/Svår)", Problem21));
            l.Add(new proghubben.Solution("En bättre sökalgoritm (Svår)", Problem29));
            l.Add(new proghubben.Solution("RemoveDuplicates (Svår)", Problem30));

            return l;
        }

        static void Problem1()
        {
            int[] SumArrays(int[] arr1, int[] arr2)
            {
                int len = Math.Max(arr1.Length, arr2.Length);
                int[] arr3 = new int[len];

                for (int i = 0; i < len; i++)
                {
                    if (i < arr1.Length && i < arr2.Length)
                        arr3[i] = arr1[i] + arr2[i];
                    else if (i < arr1.Length)
                        arr3[i] = arr1[i];
                    else
                        arr3[i] = arr2[i];
                }

                return arr3;
            }

            var a1 = new int[] { 2, 3, 4, 5, 9, 3, 1 };
            var a2 = new int[] { 3, 7, 4, 2 };

            Console.WriteLine(Helpers.PrettyPrint(SumArrays(a1, a2)));
        }

        struct p2Result
        {
            public int guestAmount;
            public int totalPrice;

            public p2Result(int guests = 0, int price = 0)
            {
                guestAmount = guests;
                totalPrice = price;
            }
        }

        static void Problem2()
        {
            p2Result AdmissionPrice()
            {
                int price = 0;

                Console.Write("Antal gäster: ");
                int.TryParse(Console.ReadLine(), out int guests);

                foreach (string guest in Helpers.GetArguments(guests, "gäst"))
                {
                    Console.Write($"{guest}s ålder: ");
                    int.TryParse(Console.ReadLine(), out int age);

                    switch (age)
                    {
                        case int i when Helpers.Range(i, 3, 12):
                            price += 50;
                            break;
                        case int i when Helpers.Range(i, 65, int.MaxValue):
                            price += 75;
                            break;
                        default:
                            price += 110;
                            break;
                    }
                }

                int calcPrice = (int)(price * (guests > 4 ? 0.8 : 1));

                return new p2Result(guests, calcPrice);
            }

            var res = AdmissionPrice();
            Console.WriteLine($"Ditt besök till parken kommer att kosta {res.totalPrice}kr för {res.guestAmount} gäster. Ha det kul!");
        }

        static void Problem12()
        {
            bool IsPalindrome(string str)
            {
                string rev = string.Join("", str.Reverse());
                return rev == str;
            }

            var s = Helpers.GetArgument("text", "sirap i paris");
            Console.WriteLine($"{s} { (IsPalindrome(s) ? "är" : "är inte") } en palindrom.");
        }

        static void Problem21()
        {
            // detta är en "impure function" eftersom vi direkt modifierar värdet på parametervärden.
            // detta kan leda till problem men i just detta fall är allt lugnt
            void RotateArrayBy2(int[] arr)
            {
                // om arrayen bara innehåller 2 element kommer denna funktion inte göra något.
                if (arr.Length == 2)
                    return;

                int v1 = arr[0], v2 = arr[1];
                for (int i = 2; i < arr.Length; i++)
                    arr[i - 2] = arr[i];

                arr[arr.Length - 2] = v1;
                arr[arr.Length - 1] = v2;
            }

            var testArray = new int[] { 3, 5, 10, 2, 6 };
            Console.WriteLine(Helpers.PrettyPrint(testArray));

            RotateArrayBy2(testArray);
            Console.WriteLine("Efter skift:");

            Console.WriteLine(Helpers.PrettyPrint(testArray));
        }

        static void Problem29()
        {
            bool AvSearch(int[] arr, int target, int min = 0, int max = -1, int oldIndex = -1)
            {
                if (max == -1) max = arr.Length;
                int index = min + (max - min) / 2;

                // om förra gångens index är samma som denna gång så är det ingen anledning att fortsätta letandet
                if (oldIndex == index)
                    return false;

                if (arr[index] == target)
                    return true;
                else if (arr[index] < target)
                {
                    return AvSearch(arr, target, index, max, index);
                }
                else
                {
                    return AvSearch(arr, target, min, index, index);
                }
            }

            Console.Write("sök: ");
            int.TryParse(Console.ReadLine(), out int search);

            string milliseconds(double ticks) => $"{(ticks / System.Diagnostics.Stopwatch.Frequency) * 1000}ms";

            var watch = new System.Diagnostics.Stopwatch();

            void test(int size)
            {
                var testArray = Helpers.GenerateList(size, 3);
                watch.Start();
                bool found = AvSearch(testArray, search);
                watch.Stop();
                Console.WriteLine($"{search} { (found ? "förekommer" : "förekommer inte") } i arrayen med {size} element ({milliseconds(watch.ElapsedTicks)})");
            }

            test(200);
            test(2000);
            test(20000);
            test(2000000);
        }

        static void Problem30()
        {
            /*
                RemoveDuplicates:
                    - tar array A heltal
                    - returnerar en ny array (B) som innehåller unika värden från array A
                    
                Förutsättningar:
                    Bara array får nyttjas. Inte ArrayList, List, eller liknande. Annars hade man kunnat använda en
                    HashSet men detta hade varit lite för enkelt.
            */

            int[] RemoveDuplicates(int[] arr)
            {
                // Skapa en ny array med samma längd som orginalarrayen
                int[] rv = new int[arr.Length];
                // nummer som räknar antalet unika element.
                int count = 0;

                foreach (int i in arr)
                {
                    // Kolla om unikarrayen innehåller heltalet
                    if (rv.Contains(i))
                        // om talet redan finns så kollar vi nästa tal
                        continue;
                    else
                    {
                        // om talet inte finns i unika arrayen så lägger vi till det
                        // och ökar count variabeln med ett
                        rv[count] = i;
                        count += 1;
                    }
                }

                // Ändra storleken på listan till antalet orginella element
                Array.Resize(ref rv, count);

                return rv;
            }

            var testArray = new int[] { 6, 6, 3, 3, 1, 9, 4 };
            Console.WriteLine(Helpers.PrettyPrint(testArray));

            Console.WriteLine("Unik:");
            Console.WriteLine(Helpers.PrettyPrint(RemoveDuplicates(testArray)));
        }
    }
}
