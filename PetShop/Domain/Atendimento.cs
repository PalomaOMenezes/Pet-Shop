using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repository;


namespace PetShop.Domain
{
    public class Atendimento
    {
        public Servicos servico;
        public Pet pet;


        public Atendimento() 
        {
            servico = new Servicos();
            pet = new Pet();
        }

        public int Id { get; set; }
        public int Pet_Id { get; set; }
        public DateTime Data_Atendimento { get; set; }
        public decimal Valor_Total { get; set; }

        List<Servicos> servicosDoAtendimento = new List<Servicos>();

        AtendimentoRepository _atendimentoRepository = new AtendimentoRepository();
        public async Task CadastrarAtendimento(int clienteId)
        {
            
            pet = await pet.RegistrarPet(clienteId);

            this.Data_Atendimento = DateTime.UtcNow;

            List<Servicos> listaDeServicos = servico.MostrarServicos();

            Console.WriteLine("---------------------------");
            Console.WriteLine("Deseja adicionar mais serviços ao pedido? s/n");

            string desejoCliente = Console.ReadLine();
            bool resposta = true;

            if (desejoCliente == "s")
            {
                while (resposta == true)
                {
                    Console.WriteLine("Por favor digite o numero do serviço desejado: ");

                    int servicoEscolhido = int.Parse(Console.ReadLine());


                    if (servicoEscolhido > 0 && servicoEscolhido <= 7)
                    {
                        servicosDoAtendimento.Add(listaDeServicos.Where(x => x.Id == servicoEscolhido).FirstOrDefault());

                        Console.WriteLine("Serviço incluido com sucesso!");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Deseja incluir algo a mais? s/n");
                        desejoCliente = Console.ReadLine();

                        if (desejoCliente == "n")
                        {
                            resposta = false;                           
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não encontrado, digite uma opação valida");
                    }
                }
            }
            else
            {
                Console.WriteLine("Vamos finalizar seu pedido.");
            }

            await ValorFinal(pet);

            this.Valor_Total = await ValorFinal(pet);

            Console.WriteLine("------------------------------");
            Console.WriteLine($"O valor total do seu pedido é {Valor_Total}");
        }

        public async Task<decimal> ValorFinal(Pet pet)
        {
            decimal valorServico = 0;
            decimal valorTotal = 0;
            foreach(Servicos servico in servicosDoAtendimento)
            {

                valorServico = valorServico + servico.Valor;
            }

            int valorBanho = 0;
            if (pet.Tipo_Pet == "pequeno")
            {
                valorBanho = 100;             
            }
            else if (pet.Tipo_Pet == "medio")
            {
                valorBanho = 150;
            }
            else if (pet.Tipo_Pet == "grande")
            {
                valorBanho = 250;
            }

            valorServico = valorServico + valorBanho;
            
            return valorServico;
        }
    }
}
