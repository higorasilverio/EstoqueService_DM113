using System;
using System.Collections.Generic;
using System.Linq;
using ClientEstoqueDesktop.ServicoEstoque;

namespace ClienteEstoqueDesktop
{
    class Program
    {
        private static Produto produto;
        private static Produto produtoFinal;
        private static int quantidade;
        private static string numeroProduto;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("APLICAÇÃO CLIENTE DESKTOP");
                Console.WriteLine();

                Console.WriteLine("Pressione ENTER quando o servidor estiver rodando...");
                Console.ReadLine();

                ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

                Console.WriteLine("Teste 01 - Adicionar um produto à lista de produtos: ");
                produto = new Produto()
                {
                    DescricaoProduto = "Teste",
                    EstoqueProduto = 100,
                    NomeProduto = "Produto 11",
                    NumeroProduto = "11000"
                };

                if (proxy.IncluirProduto(produto))
                {
                    produtoFinal = proxy.VerProduto("11000");
                    Console.WriteLine(
                        "Produto incluso à lista #{0}: {1}.",
                        produtoFinal.NumeroProduto,
                        produtoFinal.NomeProduto
                    );
                }
                else
                    Console.WriteLine("Não foi possível incluir o produto!");
                Console.WriteLine();

                Console.WriteLine("Teste 02 - Remover o mesmo produto da lista de produtos: ");
                numeroProduto = "11000";
                if (proxy.RemoverProduto(numeroProduto))
                    Console.WriteLine("Produto removido da lista: #{0}.", numeroProduto);
                else
                    Console.WriteLine("Não foi possível excluir o produto!");
                Console.WriteLine();

                Console.WriteLine("Teste 03 - Listar todos os produtos da lista: ");
                List<string> listaNomesProdutos = proxy.ListarProdutos().ToList();
                foreach (string nomeProduto in listaNomesProdutos) Console.WriteLine("--> {0}", nomeProduto);
                Console.WriteLine();

                Console.WriteLine("Teste 04 - Verificar as informações de um produto: ");
                numeroProduto = "2000";
                produto = proxy.VerProduto(numeroProduto);
                Console.WriteLine("Nome do produto: {0};", produto.NomeProduto);
                Console.WriteLine("Número do produto: {0};", produto.NumeroProduto);
                Console.WriteLine("Descrição do produto: {0};", produto.DescricaoProduto);
                Console.WriteLine("Quantidade do produto em estoque: {0} unidades.", produto.EstoqueProduto);
                Console.WriteLine();

                Console.WriteLine(
                    "Teste 05 - Adicionar 10 unidades ao estoque deste produto e verificar quantidade resultante: "
                );
                if (proxy.AdicionarEstoque(numeroProduto, 10))
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

                Console.WriteLine("Teste 06 - Verificar as informações de um outro produto: ");
                numeroProduto = "3000";
                produto = proxy.VerProduto(numeroProduto);
                Console.WriteLine("Nome do produto: {0};", produto.NomeProduto);
                Console.WriteLine("Número do produto: {0};", produto.NumeroProduto);
                Console.WriteLine("Descrição do produto: {0};", produto.DescricaoProduto);
                Console.WriteLine("Quantidade do produto em estoque: {0} unidades.", produto.EstoqueProduto);
                Console.WriteLine();

                Console.WriteLine(
                    "Teste 07 - Remover 20 unidades do estoque deste produto e verificar quantidade restante: "
                );
                if (proxy.RemoverEstoque(numeroProduto, 20))
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
