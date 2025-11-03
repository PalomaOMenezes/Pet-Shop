using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetShop.Domain
{
    public class ServicoOpenCep
    {
        // A boa prática é instanciar o HttpClient uma vez e reutilizá-lo. Comunicação com o mundo externo, só serve pra pegar infos
        private static readonly HttpClient client = new HttpClient();

        public async Task<Endereco> BuscarEnderecoPorCepAsync(string cep)
        {
            // Garante que o CEP contenha apenas dígitos.
            var cepLimpo = new string(cep.Where(char.IsDigit).ToArray());

            if (cepLimpo.Length != 8)
            {
                Console.WriteLine("Erro: O CEP deve conter exatamente 8 dígitos.");
                // No seu sistema real, você poderia lançar uma exceção ou retornar uma mensagem de erro.
                return null;
            }

            try
            {
                // Monta a URL da requisição para a API OpenCEP
                string url = $"https://opencep.com/v1/{cepLimpo}";

                // Faz a requisição GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Se o status code for 404 (Not Found), significa que o CEP não foi encontrado.
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("CEP não encontrado.");
                    return null;
                }

                // Garante que a requisição foi bem-sucedida (status code 2xx)
                response.EnsureSuccessStatusCode();

                // Lê o conteúdo da resposta como uma string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Desserializa o JSON para o objeto EnderecoOpenCep
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Endereco? endereco = JsonSerializer.Deserialize<Endereco>(responseBody, options);

                return endereco;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nErro na requisição HTTP: {e.Message}");
                Console.WriteLine($"Status Code: {e.StatusCode}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"\nErro ao desserializar o JSON: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
                return null;
            }
        }
    }
}
