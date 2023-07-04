using Dapper;
using ConsoleMenu.Domain.Modelo;
using System.Data.SqlClient;

namespace SeuProjeto.Repository
{
    public class ClienteRepository
    {
        private string connectionString = "Server=tcp:localhost;Database=Cliente01;User Id=sa;Password=admin123;\r\n";

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Cliente ObterClientePorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cliente WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Cliente>(query, new { Id = id });
            }
        }

        public void SalvarCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (ClienteExiste(cliente.Id, connection))
                {
                    AtualizarCliente(cliente, connection);
                }
                else
                {
                    InserirCliente(cliente, connection);
                }
            }
        }

        private bool ClienteExiste(int id, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Cliente WHERE Id = @Id";
            return connection.ExecuteScalar<int>(query, new { Id = id }) > 0;
        }

        private void AtualizarCliente(Cliente cliente, SqlConnection connection)
        {
            string query = "UPDATE Cliente SET Nome = @Nome, Cpf = @Cpf, Saldo = @Saldo WHERE Id = @Id";
            connection.Execute(query, cliente);
        }

        private void InserirCliente(Cliente cliente, SqlConnection connection)
        {
            string query = "INSERT INTO Cliente (Id, Nome, Cpf, Saldo) VALUES (@Id, @Nome, @Cpf, @Saldo)";
            connection.Execute(query, cliente);
        }
    }
}
