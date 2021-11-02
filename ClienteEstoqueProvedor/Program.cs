using System;
using ClientEstoqueProvedor.ServicoEstoque;

namespace ClienteEstoqueProvedor
{
    class Program
    {
        private static string numeroProduto;
        private static int quantidade;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("PROVEDOR DE SERVIÇO DE VENDAS");
                Console.WriteLine();

                Console.WriteLine("Pressione ENTER quando o servidor estiver rodando...");
                Console.ReadLine();

                ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");

                Console.WriteLine("Teste 01 - Verificar a quantidade de um produto em estoque: ");
                numeroProduto = "1000";
                quantidade = proxy.ConsultarEstoque(numeroProduto);
                Console.WriteLine(
                    "Estoque atual do produto #{0}: {1} unidades.",
                    numeroProduto,
                    quantidade
                );
                Console.WriteLine();

                Console.WriteLine(
                    "Teste 02 - Adicionar 20 unidades ao estoque deste produto e verificar quantidade resultante: "
                );
                if (proxy.AdicionarEstoque(numeroProduto, 20))
                {
                    quantidade = proxy.ConsultarEstoque(numeroProduto);
                    Console.WriteLine(
                        "Estoque para o produto #{0} alterado. Quantidade atual do estoque: {1} unidades.",
                        numeroProduto,
                        quantidade
                    );
                }
                else
                    Console.WriteLine("Não foi possível alterar o estoque do produto!");
                Console.WriteLine();

                Console.WriteLine("Teste 03 - Verificar a quantidade de um produto em estoque: ");
                numeroProduto = "5000";
                quantidade = proxy.ConsultarEstoque(numeroProduto);
                Console.WriteLine(
                    "Estoque atual do produto #{0}: {1} unidades.",
                    numeroProduto,
                    quantidade
                );
                Console.WriteLine();

                Console.WriteLine(
                    "Teste 04 - Remover 10 unidades do estoque deste produto e verificar quantidade restante: "
                );
                if (proxy.RemoverEstoque(numeroProduto, 10))
                {
                    quantidade = proxy.ConsultarEstoque(numeroProduto);
                    Console.WriteLine(
                        "Estoque para o produto #{0} alterado. Quantidade atual do estoque: {1} unidades.",
                        numeroProduto,
                        quantidade
                    );
                }
                else
                    Console.WriteLine("Não foi possível alterar o estoque do produto!");
                Console.WriteLine();

                proxy.Close();
                Console.WriteLine("Pressione ENTER para finalizar...");
                Console.ReadLine();
            }
            catch
            {
                throw new ArgumentException("Ocorreu um erro inesperado!");
            }
        }
    }
}
