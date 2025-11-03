using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using PetShop.Domain;

namespace PetShop.Repository
{
    public class EnderecoRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void SalvandoEndereco(Endereco endereco, int clienteId)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = @"INSERT INTO endereco (Cliente_Id, Cep, Logradouro, Bairro, Localidade, Uf) 
                                VALUES (@clienteId, @cep, @logradouro, @bairro, @localidade, @uf)";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    cmd.Parameters.AddWithValue("@cep", endereco.Cep);
                    cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                    cmd.Parameters.AddWithValue("@localidade", endereco.Localidade);
                    cmd.Parameters.AddWithValue("@uf", endereco.Uf);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
