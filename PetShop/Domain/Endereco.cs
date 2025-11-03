using System.Text.Json.Serialization;
using PetShop.Repository;

namespace PetShop.Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }


        public async Task CadastrarEndereco(int clienteId)
        {
            var servicoCep = new ServicoOpenCep();

            Console.Write("Digite o CEP para consulta (somente números): ");
            

            bool cepValido = false;

            while(cepValido == false)
            {
                string? cep = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(cep))
                {
                    // Chama o serviço da OpenCEP
                    var endereco = await servicoCep.BuscarEnderecoPorCepAsync(cep);


                    if (endereco != null)
                    {
                        Console.WriteLine("--- Endereço Encontrado via OpenCEP ---");
                        Console.WriteLine($"Logradouro: {endereco.Logradouro}");
                        Console.WriteLine($"Bairro: {endereco.Bairro}");
                        Console.WriteLine($"Cidade: {endereco.Localidade}");
                        Console.WriteLine($"Estado: {endereco.Uf}");
                        Console.WriteLine("--------------------------------------");

                        EnderecoRepository enderecoRepository = new EnderecoRepository();

                        enderecoRepository.SalvandoEndereco(endereco, clienteId);

                        cepValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível obter o endereço. Verifique o CEP digitado.");
                    }

                }
            }
        }
    }
}
