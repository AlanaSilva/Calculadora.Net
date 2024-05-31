using System;
using System.Collections.Generic;



namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647L, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' });

            Calculadora calculadora = new Calculadora();

            Stack<long> historico = new Stack<long>();

            
            while (filaOperacoes.Count > 0)
            {
                Operacoes operacao = filaOperacoes.Dequeue();
                calculadora.calcular(operacao);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA,operacao.operador,operacao.valorB, operacao.resultado);

                Console.WriteLine();

                OperacoesRestantes(filaOperacoes);
                historico.Push(operacao.resultado);
                
            }
            

            Console.WriteLine("Histórico:");
            foreach (long resultado in historico)
            {
                Console.WriteLine(resultado);
            }
            Console.WriteLine();
        }

        static void OperacoesRestantes(Queue<Operacoes> filaOperacoes)
        {
            Console.WriteLine("Operações restantes:");

            foreach (Operacoes operacao in filaOperacoes)
            {
                Console.WriteLine("{0} {1} {2}", operacao.valorA, operacao.operador, operacao.valorB);
            }
            Console.WriteLine();
        }
    }
}
