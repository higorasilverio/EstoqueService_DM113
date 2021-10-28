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

        [Required(ErrorMessage = "O número do produto é mandatório")]
        public string NumeroProduto { get; set; }

        [Required(ErrorMessage = "O nome do produto é mandatório")]
        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }

        [Required(ErrorMessage = "O número do produtos no estoque é mandatório")]
        public int EstoqueProduto { get; set; }
    }

}