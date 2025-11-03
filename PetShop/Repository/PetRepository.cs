using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Domain;
using Dapper;
using MySqlConnector;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace PetShop.Repository
{
    public class PetRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void RegistrarPet (Pet pet)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = "INSERT INTO pet (Cliente_Id, Nome_Pet, Tipo_Pet, Descricao_breve) VALUES (@clienteId, @nomePet, @tipoPet, @breveDescricao)";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", pet.Cliente_Id);
                    cmd.Parameters.AddWithValue("@nomePet", pet.Nome_Pet);
                    cmd.Parameters.AddWithValue("@tipoPet", pet.Tipo_Pet);
                    cmd.Parameters.AddWithValue("@breveDescricao", pet.DescricaoBreve);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
