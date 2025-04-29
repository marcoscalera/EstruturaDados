using System;
using System.Collections.Generic;

namespace BibliotecaEx3
{
    public class FilaInversao
    {
        private Queue<int> fila;
        private Stack<int> pilha;

        public FilaInversao()
        {
            fila = new Queue<int>();
            pilha = new Stack<int>();
        }

        public void PreencherFila(int[] elementos)
        {
            foreach (var item in elementos)
                fila.Enqueue(item);
        }

        public void InverterFila()
        {
            while (fila.Count > 0)
                pilha.Push(fila.Dequeue());

            while (pilha.Count > 0)
                fila.Enqueue(pilha.Pop());
        }

        public void ExibirFila()
        {
            Console.WriteLine("Fila Invertida:");
            foreach (var item in fila)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
