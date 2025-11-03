using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using PetShop.Domain;


namespace PetShop.Repository
{
    public class ClienteRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void CadastrarCliente(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                // Abre a comunicação com o banco de dados
                conexao.Open();

                // Comando SQL para inserir os dados. Usamos parâmetros (@nome, @cpf, etc.)
                string sql = "INSERT INTO cliente (nome, documento, dataNascimento, sexo) VALUES (@nome, @documento, @dataNascimento, @sexo)";

                // Cria o comando que será executado no banco
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    // Substitui os parâmetros (@) pelos valores que o usuário digitou
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo == "m" ? 1 : 2);

                    // Executa o comando no banco. ExecuteNonQuery() é usado para INSERT, UPDATE e DELETE.
                    cmd.ExecuteNonQuery();
                }
                // A conexão é fechada aqui automaticamente.
            }
        }

        public Cliente ConsultarCliente(string documento)
        {

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Exemplo: Executando uma consulta com Dapper
                    var cliente = connection.QueryFirstOrDefault<Cliente>(@"
                            SELECT 
                                Id, nome, documento, ifnull(datanascimento, '2001-01-01'), sexo 
                            FROM
                                Cliente 
                            Where 
                                Documento = @documento", new { Documento = documento });

                    return cliente;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao conectar: {ex.Message}");
                    return null;
                }
                finally
                {
                    connection.Clone();
                }
            }


        }
    }
}
