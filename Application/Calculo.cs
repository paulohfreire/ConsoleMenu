using ConsoleMenu.Model.Domain;

namespace ConsoleMenu.Application
{
    public class Calculo
    {
        public void Deposito(Cliente cliente, float valor)
        {
            cliente.Saldo += valor;
        }

        public void Saque(Cliente cliente, float valor)
        {
            if (valor <= cliente.Saldo)
            {
                cliente.Saldo -= valor;
            }
            else
            {
                Console.WriteLine("Você não possui saldo suficiente.");
            }

        }
    }
}
