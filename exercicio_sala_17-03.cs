using System;
using System.Security.Cryptography;
namespace exercicio_sala 
{
    class exercicio_sala
    {
        static void Main(string[] args)
        {
            // FAÇA UM PROGRAMA QUE GERENCIA O ESTOQUE DE UM MERCADO
            // CRIE UMA STRUCT COM PONTEIRO PARA CÓDIGO, NOME, PREÇO E PONTEIRO PARA QUANTIDADE
            // CRIE UM VETOR DE 5 UNIDADES E CADASTRE OS PRODUTOS. DEPOIS EXIBA OS PRODUTOS NA TELA

            //ex();
            ex2();
        }

        public unsafe struct Produto
        {
            public string nome;
            public double preco;
            public int* quantidade, codigo;
        }
        
        public unsafe static void ex() // POR VETOR
        {
            int tamanho = 5;
            Produto[]produtos = new Produto[tamanho];
            int[] codigos = new int[tamanho];
            int[] quantidade = new int[tamanho];

            fixed (int* aux_cod = &codigos[0])
            fixed (int* aux_qnt = &quantidade[0])
            {
                int* aux_cod2 = aux_cod;
                int* aux_qnt2 = aux_qnt;

                for (int i = 0; i < tamanho; i++)
                {
                    Console.WriteLine($"Produto {i + 1}");

                    Console.Write("Código: ");
                    codigos[i] = int.Parse(Console.ReadLine());
                    aux_cod2 = aux_cod + i;
                    produtos[i].codigo = aux_cod2;

                    Console.Write("Nome: ");
                    produtos[i].nome = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    quantidade[i] = int.Parse(Console.ReadLine());
                    aux_qnt2 = aux_qnt + i;
                    produtos[i].quantidade = aux_qnt2;

                    Console.Write("Preço: ");
                    produtos[i].preco = double.Parse(Console.ReadLine());

                    Console.WriteLine();
                }
            }

            fixed (int* aux = &codigos[0]) 
            fixed (int* aux2 = &quantidade[0])
            {
                for (int i = 0; i < tamanho; i++)
                {
                    produtos[i].codigo = &aux[i];
                    produtos[i].quantidade = &aux2[i];
                }
            }

            Console.WriteLine("Produtos cadastrados: ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine($"Produto {i + 1}:");
                Console.WriteLine($"Código: {*produtos[i].codigo}"); 
                Console.WriteLine($"Nome: {produtos[i].nome}");
                Console.WriteLine($"Preço: {produtos[i].preco}");
                Console.WriteLine($"Quantidade: {*produtos[i].quantidade}"); 
                Console.WriteLine();
            }
        }

        unsafe static void ex2() // POR INTEIRO
        {
            int tamanho = 5;
            Produto[] produtos = new Produto[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine($"Produto {i + 1}");

                Console.Write("Código: ");
                int cod_novo = int.Parse(Console.ReadLine());
                produtos[i].codigo = &cod_novo;

                Console.Write("Nome: ");
                produtos[i].nome = Console.ReadLine();

                Console.Write("Quantidade: ");
                int qnt_novo = int.Parse(Console.ReadLine());
                produtos[i].quantidade = &qnt_novo;

                Console.Write("Preço: ");
                produtos[i].preco = double.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            Console.WriteLine("\nProdutos cadastrados: ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"Produto {i + 1}:");
                Console.WriteLine($"Código: {*produtos[i].codigo}");
                Console.WriteLine($"Nome: {produtos[i].nome}");
                Console.WriteLine($"Preço: {produtos[i].preco}");
                Console.WriteLine($"Quantidade: {*produtos[i].quantidade}");
                Console.WriteLine();
            }
        }
    }
}