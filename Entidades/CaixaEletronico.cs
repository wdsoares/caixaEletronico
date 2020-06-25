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

        public string RelatorioCedulas() // Retorna string com as notas e quantidades de cada disponível
        {
            string relatorio = default;
            foreach(var ced in cedulas)
            {
                relatorio = String.Concat(relatorio, $"Cédula: R$ {ced.RetornaValor()}, Quantidade: {ced.RetornaQuantidade()}\n");
            }
            return relatorio;
        }

        public string RetornaNotasDisponiveis() // Exibe string com as notas disponíveis no caixa
        {
            var notas = "Cédulas disponíveis: ";
            foreach(var nota in cedulas)
            {
                if(nota.RetornaQuantidade() > 0)
                {
                    notas = String.Concat(notas, $"R$: {nota.RetornaValor()} ");
                }
            }
            return notas;
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
                string textoNotas = "Notas: ";
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
                            if(cedulas[i].RetornaQuantidade() >= t) // Se o número de cédulas disponíveis for maior igual que "t", subtrai as cédulas.
                            {
                                valor = valor % cedulas[i].RetornaValor();
                                cedulas[i].SubtraiQuantidade(t);
                                textoNotas = String.Concat(textoNotas, $"R$ {cedulas[i].RetornaValor()}: {t} ");
                            }
                            else // Se o número de cédulas for menor, subtrai as cédulas existentes e segue para a próxima cédula
                            {
                                valor -= (cedulas[i].RetornaQuantidade() * cedulas[i].RetornaValor());
                                textoNotas = String.Concat(textoNotas, $"R$ {cedulas[i].RetornaValor()}: {cedulas[i].RetornaQuantidade()} ");
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
                    Console.WriteLine("Não foi possível realizar essa operação");
                    k = 0;
                    foreach(var cel in cedulas)
                    {
                        cel.AlteraQuantidade(notas[k] - cel.RetornaQuantidade());
                        k++;
                    }
                    Console.ReadKey();
                }
                Console.WriteLine(textoNotas);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
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
        public void ReporCedulas(int Posicao, int Quantidade) // Adiciona cédulas no caixa, Posicao = índice da lista de cédulas
        {
            cedulas[Posicao].AlteraQuantidade(Quantidade);
        }
    }
}