using System;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Exibir()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Modo Editor");
            Console.WriteLine("--------------------");

            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("-----------------");
            Console.WriteLine("  Deseja salvar o arquivo?");

            string resposta = Console.ReadLine();
            if (resposta == "S" || resposta == "s")
            {
                Console.Clear();
                Console.WriteLine("Onde deseja salvar o arquivo?");
                var caminho = Console.ReadLine();

                using (var arquivo = new StreamWriter(caminho))
                {
                    arquivo.Write(file);
                }

                Console.WriteLine($"Arquivo {caminho} salvo com sucesso");
                Console.ReadLine();
                View.Exibir(file.ToString());

            }
            else
            {
                Console.WriteLine("Operação cancelada");

            }



        }
    }
}