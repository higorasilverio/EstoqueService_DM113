using System;
using System.ServiceModel;
using Servico;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost provedorServicoEstoque = new ServiceHost(typeof(ServicoEstoque));
            provedorServicoEstoque.Open();
            Console.WriteLine("O serviço está rodando...");

            Console.ReadLine();
            Console.WriteLine("O serviço está sendo encerrado...");
            provedorServicoEstoque.Close();
        }
    }
}
