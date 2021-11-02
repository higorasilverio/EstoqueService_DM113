using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Estoque
{
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(Produto produto);

        [OperationContract]
        bool RemoverProduto(string numeroProduto);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        Produto VerProduto(string numeroProduto);

    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

    }

    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;

    }
}
