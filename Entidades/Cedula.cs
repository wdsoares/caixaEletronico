using System;

namespace caixaEletronico.Entidades
{
    public class Cedula
    {
        protected int valor {get; set;}
        protected int quantidade {get; set;}

        public Cedula(int Valor, int Quantidade)
        {
            this.valor = Valor;
            this.quantidade = Quantidade;
        }
        public int RetornaQuantidade()
        {
            return this.quantidade;
        }

        public void AlteraQuantidade(int Quantidade)
        {
            this.quantidade += Quantidade;
        }

        public void SubtraiQuantidade(int Quantidade)
        {
            this.quantidade -= Quantidade;
        }

        public int RetornaValor()
        {
            return this.valor;
        }
    }
}