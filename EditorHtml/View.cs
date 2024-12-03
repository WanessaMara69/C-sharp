using System;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public class View
    {
        public static void Exibir(string text)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
            Console.WriteLine("Modo Visualização");
            Console.WriteLine("-------------------");
            Replace(text);
            Console.WriteLine("--------------------");
            Console.ReadKey();
            Menu.Exibir();


        }

        public static void Replace(string text)
        {
            var strong = new Regex(@"<strong>(.*?)<\/strong>"); //string que subistitui varias string
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1, //uma palavra ou char
                            ((words[i].LastIndexOf('<')
                            - 1) - words[i].IndexOf('>')
                            )
                        )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }

    }
}