using System;
using System.Collections.Generic;

namespace caixaEletronico.Entidades
{
    public class CaixaEletronico
    {
        protected List<Cedula> cedulas = new List<Cedula>();
        public int[] valores = new int[] {2,5,10,20,50};
        public CaixaEletronico()
        {
            IniciaCaixa();
        }

        private void IniciaCaixa()
        {
            for(int i = 0; i < 5; i++)
            {
                cedulas.Add(new Cedula(Valor: valores[i], Quantidade: 0));
            }
        }

        public string RelatorioCedulas()
        {
            string relatorio = default;
            foreach(var ced in cedulas)
            {
                relatorio = String.Concat(relatorio, $"Cédula: R$ {ced.RetornaValor()}, Quantidade: {ced.RetornaQuantidade()}\n");
                // Console.WriteLine($"Cédula: R$ {ced.RetornaValor()}, Quantidade: {ced.RetornaQuantidade()}");
            }
            return relatorio;
        }

        public void Saque(int valor)
        {
            int resto = 0;
            bool sucesso = false;
            for(int i = 4; i >= 0; i--)
            {
                
            }
        }

        public int RelatorioTotalCaixa()
        {
            int relatorio = default;
            foreach(var ced in cedulas)
            {
                relatorio += (ced.RetornaQuantidade() * ced.RetornaValor());
            }
            return relatorio;

        }
        public void ReporCedulas(int Posicao, int Quantidade)
        {
            cedulas[Posicao].AlteraQuantidade(Quantidade);
        }
    }
}