using ConsoleMenu.Application;
using ConsoleMenu.Model.Domain;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;

class Program
{
    //Metodo identificação

    //Mudar Pessoa para Cliente

    //Usuario visualizar Saldo
    static void Main(string[] args)
    {
    Initial:

        bool sair = false;
        Calculo calculo = new Calculo();

        while (!sair)
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Olá, digite seu nome: ");
            string nome = Console.ReadLine();
            cliente.Nome = nome;

            Console.WriteLine("Digite seu saldo: ");
            float saldo = float.Parse(Console.ReadLine());
            cliente.Saldo = saldo;
            ConsoleMenu:
            Console.WriteLine($"Como posso ajudar, {nome}?");
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
                    Console.Clear();
                    Console.WriteLine("Depósito");
                    Console.WriteLine("Digite o valor: ");
                    float valor = float.Parse(Console.ReadLine());
                    
                    calculo.Deposito(cliente, valor);
                    Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                    goto ConsoleMenu; 

                case "2":
                    Console.Clear();
                    Console.WriteLine("Saque");
                    Console.WriteLine("Digite o valor: ");
                    float valorSaque = float.Parse(Console.ReadLine());
                    
                    calculo.Saque(cliente, valorSaque);
                    Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                    goto ConsoleMenu;

                case "3":
                    Console.WriteLine("Para confirmar, clique Enter para sair do sistema definitivamente...");
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