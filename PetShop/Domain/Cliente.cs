using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repository;

namespace PetShop.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string Sexo { get; set; }


        public Cliente CadastrarCliente()
        {

            ClienteRepository clienteRepository = new ClienteRepository();

            Console.WriteLine(@"Cadastre sua conta 
---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Nome: ");
            this.Nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            this.Documento = (Console.ReadLine());
            Console.WriteLine("Data de nascimento: ");
            this.DataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Sexo: ");
            this.Sexo = Console.ReadLine();           

            clienteRepository.CadastrarCliente(this);

            //Consulta o cliente add para recuperar o id
            var cliente = clienteRepository.ConsultarCliente(this.Documento);

            return cliente;

        }           

        

        public Cliente ConsultarCliente(String documento)
        {
            ClienteRepository clienteRepository = new ClienteRepository();

            var cliente = clienteRepository.ConsultarCliente(documento);
            
            return cliente;
        }
    }
}
