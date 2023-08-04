using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proghubben.Lösningar
{
    class Strängar
    {
        public static List<proghubben.Solution> getFunctions()
        {
            var l = new List<proghubben.Solution>();

            l.Add(new proghubben.Solution("reverse string", StrUppgift2));
            l.Add(new proghubben.Solution("RemoveSpaces", StrUppgift3));
            l.Add(new proghubben.Solution("Sammanställning av sträng", StrUppgift5));
            l.Add(new proghubben.Solution("Manuell IndexOf", StrUppgift7));
            l.Add(new proghubben.Solution("IsStringInString", StrUppgift8));

            return l;
        }
        static void StrUppgift2()
        {
            string StringReversed(string str)
            {
                string rv = "";
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    rv += str[i];
                }
                return rv;
            }

            Console.WriteLine(StringReversed(Helpers.GetArgument("text")));
        }

        static void StrUppgift3()
        {
            void RemoveSpaces(string str)
            {
                var split = str.Split(' ');
                if (split.Length == 1)
                {
                    Console.WriteLine("No spaces in string.");
                }
                else
                {
                    Console.WriteLine(String.Join("", split));
                }
            }

            RemoveSpaces(Helpers.GetArgument("text"));
        }

        static void StrUppgift5()
        {
            void GetStringContent(string str)
            {
                int letters = 0, numbers = 0, special = 0;

                foreach (char c in str)
                {
                    if (c == ' ') continue;

                    if (char.IsDigit(c))
                        numbers++;
                    else if (char.IsLetter(c))
                        letters++;
                    else
                        special++;
                }

                Console.WriteLine($"Bokstäver: {letters}\nSiffror: {numbers}\nSpecialtecken: {special}");
            }

            GetStringContent(Helpers.GetArgument("text", "Hello world! 123"));
        }

        // Uppgift 6
        static string SubString(string str, int start)
        {
            string rv = "";
            for (int i = Math.Max(start, 0); i < str.Length; i++)
                rv += str[i];
            return rv;
        }

        static string SubString(string str, int start, int end)
        {
            string rv = "";
            for (int i = Math.Max(start, 0); i < Math.Min(end, str.Length); i++)
                rv += str[i];
            return rv;
        }
        static void StrUppgift7()
        {
            int IndexOfChar(string str, char target, int start)
            {
                int rv = -1;

                for (int i = Math.Max(start, 0); i < str.Length; i++)
                {
                    if (str[i] == target)
                    {
                        rv = i;
                        break;
                    }
                }

                return rv;
            }

            int index = IndexOfChar(Helpers.GetArgument("text"), '*', 0);
            Console.WriteLine($"tecken \"*\" { (index == -1 ? "hittades ej" : $"hittades på index {index}") }");
        }

        static void StrUppgift8()
        {
            bool IsStringInString(string str1, string str2)
            {
                return str2.IndexOf(str1) != -1;
            }

            Console.WriteLine(IsStringInString("heaj", "god dag och hej världen!!!"));
        }
    }
}
