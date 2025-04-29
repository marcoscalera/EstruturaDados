using System;
using System.Runtime.Intrinsics.X86;
using BibliotecaEx3;
using BibliotecaEx4;
using BibliotecaEx5;
using BibliotecaEx6;
namespace MarcosCalera_Lista5
{
    class MarcosCalera_Lista5
    {
        public static void Main(string[] args)
        {
            //ex1(); // FEITO COMENTADO NA VOID
            //ex2(); // FEITO COMENTADO NA VOID 
            //ex3(); // feito
            //ex4(); // feito
            //ex5(); // feito
            ex6(); // feito
        }

        public static void ex1() // feito
        {
            // 1) O que é e como funciona uma estrutura do tipo Fila? Em que situações ela é utilizada?

            // Resposta: Uma fila é uma estrutura de dados do tipo FIFO(First In, First Out), 
            // ou seja, o primeiro elemento que entra é também o primeiro a sair.
            // Seu funcionamento é semelhante a uma fila de pessoas:
            // os novos elementos são inseridos no final da fila e a remoção acontece sempre no início.
            // Essa estrutura é muito utilizada em situações onde é necessário manter a ordem de chegada,
            // como em filas de impressão, no processamento de tarefas em sistemas operacionais
        }

        public static void ex2() // feito
        {
            // 2) Uma fila implementa o mecanismo de inserção e remoção por:

            // a) FIFO
            // b) FIFA
            // c) LIFO
            // d) FFLL
            // e) N.D.A

            // Resposta: Uma fila é uma estrutura de dados do tipo FIFO(First In, First Out)
        }

        public static void ex3() // feito
        {
            var inversor = new FilaInversao();
            inversor.PreencherFila(new int[] { 1, 2, 3, 4, 5 });
            Console.Write("Antes da inversão: 1 2 3 4 5\n");
            inversor.InverterFila();
            inversor.ExibirFila();
        }

        public static void ex4() // feito
        {
            var gerenciador = new GerenciadorProcessos();

            gerenciador.IncluirProcesso(new Processo(1, 5));
            gerenciador.IncluirProcesso(new Processo(2, 10));
            gerenciador.IncluirProcesso(new Processo(3, 3));
            gerenciador.IncluirProcesso(new Processo(4, 8));
            gerenciador.IncluirProcesso(new Processo(5, 6));

            Console.WriteLine("\nFila inicial:");
            gerenciador.ImprimirFila();

            gerenciador.MatarProcessoMaiorEspera();
            Console.WriteLine("\nDepois de matar processo com maior tempo de espera:");
            gerenciador.ImprimirFila();

            gerenciador.ExecutarProcesso();
            Console.WriteLine("\nDepois de executar um processo:");
            gerenciador.ImprimirFila();

            Console.WriteLine("\nFila final:");
            gerenciador.ImprimirFila();
        }
        

        public static void ex5() // feito
        {
            var pista = new PistaVoo();

            pista.AdicionarAviao(new Aviao(101, "Airbus A320", 150, 5));
            pista.AdicionarAviao(new Aviao(102, "Boeing 737", 180, 6));
            pista.AdicionarAviao(new Aviao(103, "Embraer 195", 120, 7));

            var removido = pista.RemoverAviao();
            Console.WriteLine($"\nAvião removido: {removido}");

            Console.WriteLine($"\nQuantidade de aviões na fila: {pista.QuantidadeAvioes()}");

            Console.WriteLine($"\nAvião com maior tempo de voo:\n{pista.AviaoMaiorTempoVoo()}");

            Console.WriteLine($"\nAvião com maior capacidade:\n{pista.AviaoMaiorCapacidade()}");

            Console.WriteLine($"\nPrimeiro avião na fila:\n{pista.PrimeiroAviao()}");

            Console.WriteLine("\nTodos os aviões na fila:");
            pista.ListarAvioes();
        }

        public static void ex6() // feito
        {
            var estruturas = new EstruturasCompostas();

            Console.WriteLine("\nFila de Pilhas:");
            estruturas.FilaDePilhas();

            Console.WriteLine("\nPilha de Filas:");
            estruturas.PilhaDeFilas();

            Console.WriteLine("\nFila de Filas:");
            estruturas.FilaDeFilas();

            Console.WriteLine("\nPilha de Pilhas:");
            estruturas.PilhaDePilhas();
        }
    }
}