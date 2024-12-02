using System;
using System.Diagnostics;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(String[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Menu();
                    break;
            }

        }

        static void Abrir()
        {
            Console.Clear();

            Console.WriteLine("Qual caminho do arquivo?");

            string caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho)) //ler o caminho
            {
                string texto = arquivo.ReadToEnd(); //ler o texto completo
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo (ESC para sair):");
            Console.WriteLine("-------------------------------------------");

            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine; //quebra de linha de cada leitura

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            // enquanto o user não aperta ESC, o arquivo não vai parar

            Salvar(texto);

        }

        static void Salvar(string texto)
        {
            Console.Clear();

            Console.WriteLine("Onde deseja salvar o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))// StreamWrite, fluxo de arquivos e caracteres
            {
                arquivo.Write(texto);
            }

            Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

    }

}