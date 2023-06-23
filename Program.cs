using ConsoleMenu.Application;
using ConsoleMenu.Model.Domain;
using CpfCnpjLibrary;

class Program
{

    static void Main(string[] args)
    {
    Initial:

        bool sair = false;
        Calculo calculo = new Calculo();
        List<string> errorMessages = new List<string>();

        while (!sair)
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Olá, digite seu nome: ");
            string nome = Console.ReadLine();
            cliente.Nome = nome;

            Console.WriteLine("Olá, digite seu Id: ");
            string id = Console.ReadLine();
            var isNumeric = int.TryParse(id, out _);

            if (isNumeric)
            {
                cliente.Id = int.Parse(id);
            }
            else
            {
                errorMessages.Add("Identificador não é válido");
                foreach (string error in errorMessages)
                {
                    Console.WriteLine(error);
                }
                Console.ReadLine();
                Console.Clear();
                goto Initial;
            }

            Console.WriteLine("Digite seu CPF: ");
            string cpf = Console.ReadLine();

            if (Cpf.Validar(cpf) == true)
            {
                cliente.Cpf = long.Parse(cpf);
            }
            else
            {
                errorMessages.Add("CPF digitado não é válido");
                foreach (string error in errorMessages)
                {
                    Console.WriteLine(error);
                }
                Console.ReadLine();
                Console.Clear();
                goto Initial;
            }

            Console.WriteLine("Digite seu saldo: ");
            string saldo = Console.ReadLine();

            if (!float.TryParse(saldo, out float parsedSaldo))
            {
                errorMessages.Add("Saldo não é válido");
                foreach (string error in errorMessages)
                {
                    Console.WriteLine(error);
                }
                Console.ReadLine();
                Console.Clear();
                goto Initial;
            }
            else
            {
                cliente.Saldo = parsedSaldo;
            }

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