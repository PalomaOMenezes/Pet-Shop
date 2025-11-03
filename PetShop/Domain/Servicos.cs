using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repository;

namespace PetShop.Domain
{
    public class Servicos
    {
        public int Id {  get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }


        public List<Servicos> MostrarServicos()
        {
            var _servicosRepository = new ServicosRepository();

            try
            {
                var listaDeServicos = _servicosRepository.RetornaListaServicos();

                if (listaDeServicos != null && listaDeServicos.Any())
                {

                    Console.WriteLine("----------------Nossos serviços----------------");

                    foreach (var servico in listaDeServicos)
                    {
                        Console.WriteLine($"Id: {servico.Id}, item: {servico.Tipo}, valor: {servico.Valor} ");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum serviço disponível no momento.");
                }

                return listaDeServicos;
            }
            catch(Exception)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os serviços.");
                throw;
            }
        }
    }
}
