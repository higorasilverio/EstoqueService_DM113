using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Servico
{
    [ServiceContract]
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
