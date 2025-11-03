using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repository;

namespace PetShop.Domain
{
    public class AtendimentoServicos
    {
        public int Atendimento_Id { get; set; }

        public int Servicos_Id { get; set; }

        AtendimentoServicosRepository _atendimentoServicosRepository = new AtendimentoServicosRepository();

        Atendimento atendimento = new Atendimento();
        Servicos servico = new Servicos();

        public void RegistroAtendimentoServico(Atendimento atendimento, Servicos servico)
        {
            

            this.Atendimento_Id = atendimento.Id;
            this.Servicos_Id = servico.Id;
        }
    }
}
