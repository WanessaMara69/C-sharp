using System;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Exibir()
        {
            Console.Clear();

            //Trocar a cor de fundo, neste caso blue
            Console.BackgroundColor = ConsoleColor.Blue;

            //Troca a cor da letra, neste caso será black
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());

            HandleMenuOptions(option);
        }

        public static void DrawScreen()
        {
            Console.Write("+");
            for (int i = 0; i <= 40; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine("+");

            for (int lines = 0; lines <= 15; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 40; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }

            Console.Write("+");
            for (int i = 0; i <= 40; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");



        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 1); //Coluna/Linha
            Console.WriteLine("Editor Html");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("==============");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 8);
            Console.Write("Opção:");
        }

        public static void HandleMenuOptions(short option) //Handle = manipular
        {
            switch (option)
            {
                case 1:
                    Editor.Exibir();
                    break;
                case 2:
                    Console.WriteLine("View");
                    break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Exibir();
                    break;
            }
        }
    }
}