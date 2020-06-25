using System;
using caixaEletronico.Telas;
using caixaEletronico.Entidades;

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
