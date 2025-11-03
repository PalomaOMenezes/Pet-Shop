namespace PetShop.Domain
{
    class program
    {
        static  void Main(String[] args)
        {

            try
            {
                Console.WriteLine(@"-----------------------------------------
Bem-vindo(a) à PetWash, a loja do seu animal!
-----------------------------------------");

                Console.WriteLine("Você ja possui cadastro? (s/n)");
                string temCadastro = Console.ReadLine();

                if (temCadastro == "s")
                {
                    Console.WriteLine("Digite seu documento:");
                    string docCliente = Console.ReadLine();

                    Cliente cliente = new Cliente();
                    var clienteCadastrado = cliente.ConsultarCliente(docCliente);

                    Atendimento atendimento = new Atendimento();
          
                    atendimento.CadastrarAtendimento(clienteCadastrado.Id);

                }
                else
                {
                    Console.WriteLine("Realizar cadastro");

                    Cliente cliente = new Cliente();
                    var clienteCadastrado =  cliente.CadastrarCliente();

                    Endereco endereco = new Endereco();
                    endereco.CadastrarEndereco(clienteCadastrado.Id);

                    Thread.Sleep(4500);

                    Atendimento atendimento = new Atendimento();
                    atendimento.CadastrarAtendimento(clienteCadastrado.Id);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ocorreu o erro : {ex.Message}");
                throw;
            }
        }

        
    }
}
