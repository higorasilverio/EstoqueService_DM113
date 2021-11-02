using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using EstoqueEntityModel;

namespace Estoque
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque
    {
        public bool AdicionarEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    int produtoId = (
                        from p in database.ProdutosEstoque
                        where String.Compare(p.NumeroProduto, numeroProduto) == 0
                        select p.Id).First();

                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(p => p.Id == produtoId);
                    produtoEstoque.EstoqueProduto += quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ConsultarEstoque(string numeroProduto)
        {
            int quantidadeTotal = 0;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    quantidadeTotal = (
                        from p in database.ProdutosEstoque
                        where String.Compare(p.NumeroProduto, numeroProduto) == 0
                        select p.EstoqueProduto
                        ).First();
                }
            }
            catch
            {
                throw new ArgumentException(
                    String.Format("Algo deu errado ao consultar o estoque do produto número {0}!", numeroProduto)
                );
            }

            return quantidadeTotal;
        }

        public bool IncluirProduto(Produto produto)
        {
            try
            {
                ProdutoEstoque produtoParaIncluir = new ProdutoEstoque()
                {
                    DescricaoProduto = produto.DescricaoProduto,
                    EstoqueProduto = produto.EstoqueProduto,
                    NomeProduto = produto.NomeProduto,
                    NumeroProduto = produto.NumeroProduto
                };

                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    database.ProdutosEstoque.Add(produtoParaIncluir);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<string> ListarProdutos()
        {
            List<string> listaProdutos = new List<string>();

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> produtos =
                        (from NomeProduto in database.ProdutosEstoque select NomeProduto).ToList();

                    foreach (ProdutoEstoque produto in produtos) listaProdutos.Add(produto.NomeProduto);
                }
            }
            catch
            {
                throw new ArgumentException("Algo deu errado ao listar os produtos!");
            }

            return listaProdutos;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    int produtoId = (
                        from p in database.ProdutosEstoque
                        where String.Compare(p.NumeroProduto, numeroProduto) == 0
                        select p.Id).First();

                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(p => p.Id == produtoId);
                    produtoEstoque.EstoqueProduto -= quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverProduto(string numeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produto = database.ProdutosEstoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0
                    );

                    database.ProdutosEstoque.Remove(produto);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Produto VerProduto(string numeroProduto)
        {
            Produto produto = null;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEncontrado = database.ProdutosEstoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0
                    );

                    produto = new Produto()
                    {
                        NumeroProduto = produtoEncontrado.NumeroProduto,
                        DescricaoProduto = produtoEncontrado.DescricaoProduto,
                        EstoqueProduto = produtoEncontrado.EstoqueProduto,
                        NomeProduto = produtoEncontrado.NomeProduto
                    };
                }
            }
            catch
            {
                throw new ArgumentException(
                    String.Format("Algo deu errado ao consultar o produto número {0}!", numeroProduto)
                );
            }

            return produto;
        }
    }
}
