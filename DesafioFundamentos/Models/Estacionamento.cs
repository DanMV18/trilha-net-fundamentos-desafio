using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (formato: ABC-1234):");
            string placa = Console.ReadLine();

            // Garante que a entrada não é nula ou vazia
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode ser vazia. Por favor, tente novamente.");
                return;
            }

            // Converte para maiúsculas para consistência na validação e armazenamento
            placa = placa.ToUpper();

            // Valida o formato da placa (padrão antigo LLL-NNNN) usando Regex
            if (!Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$"))
            {
                Console.WriteLine($"Formato de placa inválido. O formato correto é ABC-1234. Você digitou: {placa}");
                return;
            }

            // Verifica se o veículo já está estacionado
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine($"O veículo com a placa {placa} já se encontra no estacionamento.");
            }
            else
            {
                // Adiciona o veículo à lista
                veiculos.Add(placa);
                Console.WriteLine("Veículo cadastrado com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();
            
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = Convert.ToInt32(Console.ReadLine());

                if (horas <= 0)
                {
                    Console.WriteLine("A quantidade de horas não pode ser negativa. Por favor, tente novamente.");
                    return;
                }

                else if (horas == 1)
                {
                    valorTotal = precoInicial;
                }
                else
                {
                    valorTotal = precoInicial + (precoPorHora * (horas-1));
                }

                // Remove o veículo da lista
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Lista todos os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
