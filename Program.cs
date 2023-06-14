using Microsoft.VisualBasic.FileIO;
using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
    Initial:

        bool sair = false;

        while (!sair)
        {

            Console.WriteLine("Olá, digite seu nome: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Como posso ajudar, {name}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção: ");

            string option = Console.ReadLine();

            if (option != "1" && option != "2" && option != "3")
            {
                Console.Clear();
                goto Initial;
            }



            switch (option)
            {

                case "1":
                    Console.WriteLine("Depósito");
                    break;

                case "2":
                    Console.WriteLine("Saque");
                    break;

                case "3":
                    sair = true;
                    break;

                default:
                    Console.Clear();
                    break;

            }

            sair = true;
        }

        Console.ReadLine();
    }



}