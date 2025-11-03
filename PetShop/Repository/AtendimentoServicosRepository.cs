using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PetShop.Domain;

namespace PetShop.Repository
{
    public class AtendimentoServicosRepository
    {
        private string ConnectionString = "Server=localhost;Database=petshop;Uid=root;Pwd=teste;";

        public void RegistroAtendimentoServico(AtendimentoServicos atendimentoServicos)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = "INSERT INTO (Atendimento_Id, Servico_Id) VALUES (@atendimentoId, @servicoId)";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@atendimentoId", atendimentoServicos.Atendimento_Id);
                    cmd.Parameters.AddWithValue("@servicoId", atendimentoServicos.Servicos_Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
