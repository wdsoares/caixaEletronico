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
            // Inicia caixa eletrônico com 10 cédulas de cada valor
            for(int i = 0; i < 5; i++)
            {
                cedulas.Add(new Cedula(Valor: valores[i], Quantidade: 10));
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
            if(valor > RelatorioTotalCaixa())
            {
                Console.WriteLine("Caixa não possui saldo suficiente para saque!");
                Console.ReadKey();
            }
            else
            {
                // Armazena quantidade de cada cédula em caso de falha na transação
                int[] notas = new int[5];
                int k = 0;
                foreach(var cel in cedulas)
                {
                    notas[k] = cel.RetornaQuantidade();
                    k++;
                }

                for(int i = 4; i >= 0; i--)
                {
                    // Se quantidade disponível > 0, procede para a subtração do total
                    if(cedulas[i].RetornaQuantidade() > 0)
                    {
                        // Divide o valor pelo total de cédulas do valor sendo iterado = Número de cédulas a ser subtraído
                        var t = valor / cedulas[i].RetornaValor();
                        if(t > 0) 
                        {
                            if(cedulas[i].RetornaQuantidade() >= t)
                            {
                                valor = valor % cedulas[i].RetornaValor();
                                cedulas[i].SubtraiQuantidade(t);
                            }
                            else
                            {
                                valor -= (cedulas[i].RetornaQuantidade() * cedulas[i].RetornaValor());
                                cedulas[i].SubtraiQuantidade(cedulas[i].RetornaQuantidade());
                            }     
                        }
                    }
                    // Interrompe a execução do laço se o valor já estiver subtraído corretamente
                    if(valor == 0)
                    {
                        break;
                    }
                }
                // Caso o valor restante seja diferente de zero, realiza rollback
                if(valor != 0)
                {
                    Console.WriteLine("Não foi possível realizar a transação!");
                    k = 0;
                    foreach(var cel in cedulas)
                    {
                        cel.AlteraQuantidade(notas[k] - cel.RetornaQuantidade());
                        k++;
                    }
                    Console.ReadKey();
                }
            }
        }

        // Retorna inteiro contendo o valor total em cédulas no caixa    
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