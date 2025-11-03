using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using PetShop.Domain;


namespace PetShop.Repository
{
    public class ServicosRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void RegistrarServicos()
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = "INSERT INTO servicos ()";
            }
        }

        public List<Servicos> RetornaListaServicos()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Exemplo: Executando uma consulta com Dapper
                    var servicos = connection.Query<Servicos>("SELECT * FROM servicos");

                    return servicos.ToList();
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
