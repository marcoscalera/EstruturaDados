using System;
using System.Collections.Generic;

namespace BibliotecaEx6
{
    public class EstruturasCompostas
    {
        public void FilaDePilhas()
        {
            Queue<Stack<int>> filaDePilhas = new Queue<Stack<int>>();
            var pilha = new Stack<int>();
            pilha.Push(10);
            filaDePilhas.Enqueue(pilha);

            Console.WriteLine($"Fila de Pilhas - Elemento Removido: {filaDePilhas.Peek().Pop()}");
        }

        public void PilhaDeFilas()
        {
            Stack<Queue<int>> pilhaDeFilas = new Stack<Queue<int>>();
            var fila = new Queue<int>();
            fila.Enqueue(20);
            pilhaDeFilas.Push(fila);

            Console.WriteLine($"Pilha de Filas - Elemento Removido: {pilhaDeFilas.Peek().Dequeue()}");
        }

        public void FilaDeFilas()
        {
            Queue<Queue<int>> filaDeFilas = new Queue<Queue<int>>();
            var fila = new Queue<int>();
            fila.Enqueue(30);
            filaDeFilas.Enqueue(fila);

            Console.WriteLine($"Fila de Filas - Elemento Removido: {filaDeFilas.Peek().Dequeue()}");
        }

        public void PilhaDePilhas()
        {
            Stack<Stack<int>> pilhaDePilhas = new Stack<Stack<int>>();
            var pilha = new Stack<int>();
            pilha.Push(40);
            pilhaDePilhas.Push(pilha);

            Console.WriteLine($"Pilha de Pilhas - Elemento Removido: {pilhaDePilhas.Peek().Pop()}");
        }
    }
}
