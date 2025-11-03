using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repository;

namespace PetShop.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public string Nome_Pet { get; set; }
        public string Tipo_Pet { get; set; }
        public string DescricaoBreve { get; set; }


        public async Task<Pet> RegistrarPet(int Idcliente)
        {
            double valorBanho;

            PetRepository petRepository = new PetRepository();

            this.Cliente_Id = Idcliente;

            Console.WriteLine("Hora de registrar nosso cliente de 4 patas que vai tomar banho: ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Nome: ");
            this.Nome_Pet = Console.ReadLine();
            Console.WriteLine("Tipo (pequeno, medio ou grande): ");
            this.Tipo_Pet = Console.ReadLine();
            Console.WriteLine("Descreva brevemente seu pet: ");
            this.DescricaoBreve = Console.ReadLine();


            petRepository.RegistrarPet(this);

            return this;
        }
    }
}
