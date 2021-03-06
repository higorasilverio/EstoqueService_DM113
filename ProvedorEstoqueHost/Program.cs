using System;
using System.ServiceModel;
using Estoque;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost provedorEstoqueHost = new ServiceHost(typeof(ServicoEstoque));

            provedorEstoqueHost.Open();
            Console.WriteLine("O servidor está rodando...");

            Console.ReadLine();
            Console.WriteLine("O servidor está sendo desligado...");

            provedorEstoqueHost.Close();
        }
    }
}
