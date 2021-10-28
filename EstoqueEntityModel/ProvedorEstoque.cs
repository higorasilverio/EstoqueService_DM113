using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace EstoqueEntityModel
{
    public class ProvedorEstoque : DbContext
    {

        public ProvedorEstoque()
            : base("name=ProvedorEstoque")
        {
        }

        public virtual DbSet<ProdutoEstoque> ProdutosEstoque { get; set; }

    }

    public class ProdutoEstoque
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O n�mero do produto � mandat�rio")]
        public string NumeroProduto { get; set; }

        [Required(ErrorMessage = "O nome do produto � mandat�rio")]
        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }

        [Required(ErrorMessage = "O n�mero do produtos no estoque � mandat�rio")]
        public int EstoqueProduto { get; set; }
    }

}