using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClienteEstoqueDesktop.ServicoEstoque;

namespace ClienteEstoqueDesktop
{
    class Program
    {

        private static Produto produtoInicial;
        private static Produto produtoFinal;
        private static string numeroProduto;
        private static List<string> listaNomesProdutos;
        private static int quantidade;

        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient();

            Console.WriteLine("Teste 01 - Adicionar um produto à lista de produtos: ");
            produtoInicial = new Produto()
            {
                DescricaoProduto = "Este é o produto 11",
                EstoqueProduto = 11000,
                NomeProduto = "Produto 11",
                NumeroProduto = "11000"
            };
            if (proxy.IncluirProduto(produtoInicial))
            {
                produtoFinal = proxy.VerProduto("11000");
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
            listaNomesProdutos = proxy.ListarProdutos().ToList();
            foreach (string nomeProduto in listaNomesProdutos) Console.WriteLine("Produto: {0}", nomeProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 04 - Verificar as informações de um produto: ");
            numeroProduto = "2000";
            produtoInicial = proxy.VerProduto(numeroProduto);
            Console.WriteLine("Nome do produto: {0};", produtoInicial.NomeProduto);
            Console.WriteLine("Número do produto: {0};", produtoInicial.NumeroProduto);
            Console.WriteLine("Descrição do produto: {0};", produtoInicial.DescricaoProduto);
            Console.WriteLine("Quantidade do produto em estoque: {0}.", produtoInicial.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 05 - Adicionar estoque a um produto e verificar quantidade resultante: ");
            if (proxy.AdicionarEstoque(numeroProduto, 10))
            {
                quantidade = proxy.ConsultarEstoque(numeroProduto);
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
                quantidade = proxy.ConsultarEstoque(numeroProduto);
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
