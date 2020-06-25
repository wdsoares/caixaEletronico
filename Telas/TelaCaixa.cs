using System;
using caixaEletronico.Entidades;
namespace caixaEletronico.Telas
{
    public class TelaCaixa
    {
        CaixaEletronico caixa = new CaixaEletronico();
        public void Executar()
        {
            do
            {
                Menu();
            }while(true);
        }

        private void Menu()
        {
            var opc = default(int);
            var entradaInvalida = true;
            Console.WriteLine(" ---- Caixa Eletrônico ----");
            Console.WriteLine("| 1 | - Sacar");
            Console.WriteLine("| 2 | - Repor cédulas");
            Console.WriteLine("| 3 | - Exibir relatório de cédulas");
            Console.WriteLine("| 4 | - Repor cédulas");
            Console.WriteLine("| 5 | - Sair");
            do
            {
                try
                {
                    Console.Write("Opção: ");
                    opc = Convert.ToInt32(Console.ReadLine());
                    entradaInvalida = false;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida, digite novamente!");
                }

            }while(entradaInvalida);

            switch(opc)
            {
                case 1:
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    break;
                case 3:
                    ImprimeRelatorio();
                    Console.Clear();
                    break;
                case 4:
                    ReporCedulas();
                    Console.Clear();
                    break;
                case 5:
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    Console.Clear();
                    break;

            }

        }
        public void ImprimeRelatorio()
        {
            Console.Clear();
            Console.WriteLine("---- Relatório de Cédulas ----");
            Console.WriteLine(caixa.RelatorioCedulas());
            Console.Write("Total em caixa: R$ ");
            Console.WriteLine($"{caixa.RelatorioTotalCaixa()},00");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }

        public void ReporCedulas()
        {
            var quant = default(int);
            var entradaInvalida = true;
            Console.Clear();
            Console.WriteLine("--- Reposição de cédulas ---");
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Cédulas de R$ {caixa.valores[i]}");
                do
                {
                    try
                    {
                        Console.Write("Quantas cédulas adicionar? ");
                        quant = Convert.ToInt32(Console.ReadLine());
                        entradaInvalida = false;
                    }
                    catch
                    {
                        Console.WriteLine("Entrada inválida, digite novamente!");
                    }

                }while(entradaInvalida);
                caixa.ReporCedulas(Posicao: i, Quantidade: quant);
            }
        }
    }
}