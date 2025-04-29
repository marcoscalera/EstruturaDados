using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaEx4
{
    public class Processo
    {
        public int Id { get; set; }
        public int TempoEspera { get; set; }

        public Processo(int id, int tempo)
        {
            Id = id;
            TempoEspera = tempo;
        }

        public override string ToString()
        {
            return $"Processo {Id}, Tempo de Espera: {TempoEspera}";
        }
    }

    public class GerenciadorProcessos
    {
        private Queue<Processo> processos;

        public GerenciadorProcessos()
        {
            processos = new Queue<Processo>();
        }

        public void IncluirProcesso(Processo p)
        {
            processos.Enqueue(p);
        }

        public void MatarProcessoMaiorEspera()
        {
            if (processos.Count == 0) return;

            var lista = processos.ToList();
            var maior = lista.MaxBy(p => p.TempoEspera);
            lista.Remove(maior);
            processos = new Queue<Processo>(lista);

            Console.WriteLine($"Processo com maior tempo de espera removido: {maior}");
        }

        public void ExecutarProcesso()
        {
            if (processos.Count > 0)
            {
                var p = processos.Dequeue();
                Console.WriteLine($"Processo executado: {p}");
            }
        }

        public void ImprimirFila()
        {
            Console.WriteLine("Fila de processos:");
            foreach (var p in processos)
                Console.WriteLine(p);
        }
    }
}
