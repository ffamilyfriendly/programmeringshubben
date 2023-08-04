using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben
{
    class Helpers
    {
        public static bool Range(int comp, int lower, int upper) => lower <= comp && comp <= upper;

        public static T[] GetArguments<T>(int len, string label = "")
        {
            T[] rv = new T[len];

            for(int i = 0; i < rv.Length; i++)
            {
                if(label.Length == 0)
                {
                    Console.Write((char)('X' + i) + ": ");
                } else
                {
                    Console.Write($"{label} {i}: ");
                }
                string input = Console.ReadLine();

                if (typeof(T) == typeof(string))
                {
                    rv[i] = (T)Convert.ChangeType(input, typeof(string));
                } else
                {
                    try
                    {
                        rv[i] = (T)Convert.ChangeType(input, typeof(T));
                    } catch (Exception)
                    {
                        i -= 1;
                        Console.WriteLine($"[FEL] kunde inte tyda \"{input}\" som {typeof(T)}");
                    }
                    
                }
            }

            return rv;
        }

        public static string[] GetArguments(int len, string label)
        {
            string[] rv = new string[len];

            for (int i = 0; i < len; i++)
                rv[i] = Helpers.GetArgument($"{label} {i+1}");

            return rv;
        }

        public static string PrettyPrint<T>(T[] arr)
        {
            string rv = "";
            for (int i = 0; i < arr.Length; i++)
                rv += arr[i].ToString() + ", ";

            return rv.Substring(0, rv.Length - 2);
        }

        public static string GetArgument(string prompt, string defaultAnswer = "")
        {
            Console.Write(prompt + ": ");
            string ans = Console.ReadLine();

            if (ans.Length == 0)
            {
                Console.WriteLine("default: " + defaultAnswer);
                return defaultAnswer;
            }
            else return ans;
        }

        // https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        public static void Shuffle<T>(Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static int[] GenerateList(int len, int incramentRate = 1, bool entropy = false)
        {
            int[] rv = new int[len];

            for (int i = 0; i < len; i++)
                rv[i] = i * incramentRate;

            if(entropy)
            {
                var rng = new Random();
                Helpers.Shuffle(rng, rv);
            }
                

            return rv;
        }
    }

    public delegate void FunctionCall();
    public struct Solution
    {
        public string name;
        public FunctionCall func;

        public Solution(string FuncName, FunctionCall function)
        {
            name = FuncName;
            func = function;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var strängar = proghubben.Lösningar.Strängar.getFunctions();

            int kategori = -1;

            void drawCategoryMenu(List<Solution> solutions)
            {
                Console.Clear();
                for (int i = 0; i < solutions.Count; i++)
                {
                    var s = solutions[i];
                    Console.WriteLine($"{i}: {s.name}");
                }
                Console.Write("Välj lösning att köra (-1 för att avbryta): ");
                int.TryParse(Console.ReadLine(), out int funcSelect);

                if (funcSelect == -1) kategori = -1;
                else
                {
                    if(funcSelect >= solutions.Count)
                    {
                        Console.WriteLine($"valda funktionen ({funcSelect}) översteg mängden funktioner i denna kategori ({solutions.Count})");
                        return;
                    }
                    solutions[funcSelect].func();
                    Console.WriteLine("tryck på valfri knapp för att fortsätta...");
                    Console.ReadKey();
                }
            }

            bool run = true;

            void drawMenu()
            {
                Console.Clear();
                if (kategori == -1)
                {
                    Console.WriteLine("Välkommen till min samling av lösningar på programmeringhubbens uppgifter!\nKategorier:\n0: Datatyper\n1: Metoder\n2: Selektion\n3: Arrayer\n4: Strängar\n5: Problemlösning");
                    Console.Write("\nKategori (-1 för att avsluta): ");
                    int.TryParse(Console.ReadLine(), out int sel);
                    if (sel == -1)
                    {
                        run = false;
                        return;
                    }
                    else
                        kategori = sel;
                }
                else {
                    List<Solution> r = new List<Solution>();

                    switch(kategori)
                    {
                        case 0:
                            r = proghubben.Lösningar.Datatyper.getFunctions();
                            break;
                        case 1:
                            r = proghubben.Lösningar.Metoder.getFunctions();
                            break;
                        case 2:
                            r = proghubben.Lösningar.Selektion.getFunctions();
                            break;
                        case 3:
                            r = proghubben.Lösningar.Arrayer.getFunctions();
                            break;
                        case 4:
                            r = proghubben.Lösningar.Strängar.getFunctions();
                            break;
                        case 5:
                            r = proghubben.Lösningar.Problem.getFunctions();
                            break;
                        default:
                            kategori = -1;
                            return;
                            break;
                    }

                    drawCategoryMenu(r);
                };
            }

            while (run)
            {
                drawMenu();
            }
        }

        // Metoder


        // Selektion
       

        // Iteration/Arrayer
       

        // Strängar


        // Problemlösning


    }
}
