using System;
using System.Collections.Generic;
using System.Linq;
using Estoque.ServicoEstoque;

namespace ClienteEstoqueDesktop
{
    class Program
    {
        private static string numeroProduto;

        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER quando o servidor estiver rodando..."); 
            Console.ReadLine();

            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            Console.WriteLine("Teste 01 - Adicionar um produto à lista de produtos: ");
            Produto produto01 = new Produto()
            {
                DescricaoProduto = "Teste",
                EstoqueProduto = 100,
                NomeProduto = "Produto 11",
                NumeroProduto = "11000"
            };

            if (proxy.IncluirProduto(produto01))
            {
                Produto produtoFinal = proxy.VerProduto("11000");
                Console.WriteLine(
                    "Produto incluso à lista #{0}: {1}.",
                    produtoFinal.NumeroProduto,
                    produtoFinal.NomeProduto
                );
            }
            else
                Console.WriteLine("Não foi possível incluir um produto!");
            Console.WriteLine();

            Console.WriteLine("Teste 02 - Remover um produto da lista de produtos: ");
            numeroProduto = "11000";
            if (proxy.RemoverProduto(numeroProduto))
                Console.WriteLine("Produto removido da lista: #{0}.", numeroProduto);
            else
                Console.WriteLine("Não foi possível incluir um produto!");
            Console.WriteLine();

            Console.WriteLine("Teste 03 - Listar todos os produtos: ");
            List<string> listaNomesProdutos = proxy.ListarProdutos().ToList();
            foreach (string nomeProduto in listaNomesProdutos) Console.WriteLine("Produto: {0}", nomeProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 04 - Verificar as informações de um produto: ");
            numeroProduto = "2000";
            Produto produtoInicial = proxy.VerProduto(numeroProduto);
            Console.WriteLine("Nome do produto: {0};", produtoInicial.NomeProduto);
            Console.WriteLine("Número do produto: {0};", produtoInicial.NumeroProduto);
            Console.WriteLine("Descrição do produto: {0};", produtoInicial.DescricaoProduto);
            Console.WriteLine("Quantidade do produto em estoque: {0}.", produtoInicial.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 05 - Adicionar estoque a um produto e verificar quantidade resultante: ");
            if (proxy.AdicionarEstoque(numeroProduto, 10))
            {
                int quantidade = proxy.ConsultarEstoque(numeroProduto);
                Console.WriteLine(
                    "Estoque para o produto #{0} alterado. Quantidade atual do estoque: {1}.",
                    numeroProduto,
                    quantidade
                );
            }
            else
                Console.WriteLine("Não foi possível alterar o estoque do produto!");
            Console.WriteLine();

            Console.WriteLine("Teste 06 - Verificar as informações de um produto: ");
            numeroProduto = "3000";
            produtoInicial = proxy.VerProduto(numeroProduto);
            Console.WriteLine("Nome do produto: {0};", produtoInicial.NomeProduto);
            Console.WriteLine("Número do produto: {0};", produtoInicial.NumeroProduto);
            Console.WriteLine("Descrição do produto: {0};", produtoInicial.DescricaoProduto);
            Console.WriteLine("Quantidade do produto em estoque: {0}.", produtoInicial.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 07 - Remover estoque de um produto e verificar quantidade restante: ");
            if (proxy.RemoverEstoque(numeroProduto, 20))
            {
                int quantidade = proxy.ConsultarEstoque(numeroProduto);
                Console.WriteLine(
                    "Estoque para o produto #{0} alterado. Quantidade atual do estoque: {1}.",
                    numeroProduto,
                    quantidade
                );
            }
            else
                Console.WriteLine("Não foi possível alterar o estoque do produto!");
            Console.WriteLine();

            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
