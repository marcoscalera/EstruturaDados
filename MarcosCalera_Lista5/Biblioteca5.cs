using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaEx5
{
    public class Aviao
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Capacidade { get; set; }
        public int TempoVoo { get; set; }

        public Aviao(int id, string modelo, int capacidade, int tempoVoo)
        {
            Id = id;
            Modelo = modelo;
            Capacidade = capacidade;
            TempoVoo = tempoVoo;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Modelo: {Modelo}, Capacidade: {Capacidade}, Tempo de Voo: {TempoVoo}";
        }
    }

    public class PistaVoo
    {
        private Queue<Aviao> filaAvioes;

        public PistaVoo()
        {
            filaAvioes = new Queue<Aviao>();
        }

        public void AdicionarAviao(Aviao aviao) => filaAvioes.Enqueue(aviao);

        public Aviao RemoverAviao() => filaAvioes.Count > 0 ? filaAvioes.Dequeue() : null;

        public int QuantidadeAvioes() => filaAvioes.Count;

        public Aviao AviaoMaiorTempoVoo()
        {
            return filaAvioes.Count > 0 ? filaAvioes.MaxBy(a => a.TempoVoo) : null;
        }

        public Aviao AviaoMaiorCapacidade()
        {
            return filaAvioes.Count > 0 ? filaAvioes.MaxBy(a => a.Capacidade) : null;
        }

        public Aviao PrimeiroAviao()
        {
            return filaAvioes.Count > 0 ? filaAvioes.Peek() : null;
        }

        public void ListarAvioes()
        {
            Console.WriteLine("Fila de Aviões:");
            foreach (var aviao in filaAvioes)
                Console.WriteLine(aviao);
        }
    }
}
