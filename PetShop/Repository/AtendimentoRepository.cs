using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PetShop.Domain;

namespace PetShop.Repository
{
    public class AtendimentoRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void RegistrandoAtendimento(Atendimento atendimento)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = "INSERT INTO (pet_Id, data_Atendimento, valor_Total) VALUES (@petId, @dataAtendimento, @valorTotal )";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@petId", atendimento.Pet_Id);
                    cmd.Parameters.AddWithValue("@dataAtendimento", atendimento.Data_Atendimento);
                    cmd.Parameters.AddWithValue("@valorTotal", atendimento.Valor_Total);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
