﻿using ConsoleMenu.Application;
using ConsoleMenu.Domain.Modelo;
using CpfCnpjLibrary;
using SeuProjeto.Repository;

class Program
{

    static void Main(string[] args)
    {
        bool sair = false;
        Calculo calculo = new Calculo();

        List<string> errorMessages = new List<string>();
        string connectionString = "Server=tcp:localhost;Database=Cliente01;User Id=sa;Password=admin123;\r\n";

        ClienteRepository clienteRepository = new ClienteRepository(connectionString);

        while (!sair)
        {
            //Cliente cliente = new Cliente();
            Console.WriteLine("Olá, digite seu nome: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                errorMessages.Add("Nome digitado não é válido");
                ShowErrorsAndClearConsole(errorMessages);
                continue;

            }
            else
            {
                Console.WriteLine("Olá, digite seu Id: ");
                string id = Console.ReadLine();
                var isNumeric = int.TryParse(id, out int parsedId);

                if (isNumeric)
                {
                    Cliente cliente = clienteRepository.ObterClientePorId(parsedId);

                    if (cliente == null)
                    {
                        cliente = new Cliente { Id = parsedId, Nome = nome };
                        Console.WriteLine("Digite seu CPF: ");
                        string cpf = Console.ReadLine();

                        if (Cpf.Validar(cpf) == true)
                        {
                            cliente.Cpf = long.Parse(cpf);
                        }
                        else
                        {
                            errorMessages.Add("CPF digitado não é válido");
                            ShowErrorsAndClearConsole(errorMessages);
                            continue;
                        }

                        Console.WriteLine("Digite seu saldo: ");
                        string saldo = Console.ReadLine();

                        if (!float.TryParse(saldo, out float parsedSaldo))
                        {
                            errorMessages.Add("Saldo não é válido");
                            ShowErrorsAndClearConsole(errorMessages);
                            continue;
                        }
                        else
                        {
                            cliente.Saldo = parsedSaldo;
                        }
                        clienteRepository.SalvarCliente(cliente);
                        sair = ShowMainMenu(nome, cliente, calculo, clienteRepository);
                    }
                    else
                    {
                        // Cliente já existe, redirecionar para o menu
                        sair = ShowMainMenu(cliente.Nome, cliente, calculo, clienteRepository);
                        continue;
                    }

                }
                else
                {
                    errorMessages.Add("Identificador não é válido");
                    ShowErrorsAndClearConsole(errorMessages);
                    continue;
                }

            }
        }

        Console.ReadLine();

        static void ShowErrorsAndClearConsole(List<string> errorMessages)
        {
            foreach (string error in errorMessages)
            {
                Console.WriteLine(error);

            }

            Console.ReadLine();
            Console.Clear();
        }

        static bool ShowMainMenu(string nome, Cliente cliente, Calculo calculo, ClienteRepository clienteRepository)
        {
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
                return false;
            }

            switch (option)
            {

                case "1":
                    ProcessDeposit(nome, cliente, calculo, clienteRepository);
                    break;

                case "2":
                    ProcessWithdrawal(nome, cliente, calculo, clienteRepository);
                    break;

                case "3":
                    Console.WriteLine("Para confirmar, clique Enter para sair do sistema definitivamente...");
                    return true;

                default:
                    Console.Clear();
                    break;

            }

            return false;
        }

        static void ProcessDeposit(string nome, Cliente cliente, Calculo calculo, ClienteRepository clienteRepository)
        {
            Console.Clear();
            Console.WriteLine("Depósito");
            Console.WriteLine("Digite o valor: ");
            float valor = float.Parse(Console.ReadLine());

            calculo.Deposito(cliente, valor);
            Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
            clienteRepository.SalvarCliente(cliente);
            Console.ReadLine();
        }

        static void ProcessWithdrawal(string nome, Cliente cliente, Calculo calculo, ClienteRepository clienteRepository)
        {
            Console.Clear();
            Console.WriteLine("Saque");
            Console.WriteLine("Digite o valor: ");
            float valorSaque = float.Parse(Console.ReadLine());

            calculo.Saque(cliente, valorSaque);
            Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
            clienteRepository.SalvarCliente(cliente);
            Console.ReadLine();
        }
    }

}