using System;
using System.Data;
using System.Threading;

namespace Stopwatch
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

            Console.WriteLine("Escolha uma opção de contagem:");
            Console.WriteLine("S - Segundos => 10s = 10 segundos");
            Console.WriteLine("M - Minutos => 1m = 1 minuto");
            Console.WriteLine("0 - Sair");

            string data = Console.ReadLine().ToLower(); // converte tudo em minusculo
            char type = char.Parse(data.Substring(data.Length - 1, 1)); //Length conta os caracteres
            int time = int.Parse(data.Substring(0, data.Length - 1));
            int multiplier = 1;

            if (type == 'm')
            {
                multiplier = 60;
            }

            if (time == 0)
            {
                System.Environment.Exit(0);
            }

            PreStatic(time * multiplier);
        }

        static void PreStatic(int time)
        {
            Console.Clear();

            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(1000);

            Start(time);
        }
        static void Start(int time)
        {
            int currentTime = 0;


            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);

                Thread.Sleep(1000); //Cada numeral dorme por 1 segundo
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizando... voltando para o menu");
            Thread.Sleep(1003);
            Menu();
        }
    }
}
