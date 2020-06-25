using System;
using caixaEletronico.Telas;

namespace caixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaCaixa tela = new TelaCaixa();
            tela.Executar();
            Console.ReadKey();
        }
    }
}
