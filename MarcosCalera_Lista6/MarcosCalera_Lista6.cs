using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
namespace MarcosCalera_Lista6
{
    class MarcosCalera_Lista6
    {
        public static void Main(string[] args)
        {
            //ex1();  // FEITO COMENTADO NA VOID
            //ex2();  // FEITO COMENTADO NA VOID
            //ex3();  // FEITO
            //ex4();  // FEITO
            //ex5();  // FEITO
            //ex6();  // FEITO  
            //ex7();  // FEITO
            //ex8();  // FEITO COMENTADO NA VOID
            //ex9();  // FEITO COMENTADO NA VOID
            //ex10(); // FEITO COMENTADO NA VOID
        }

        public static void ex1() // FEITO
        {
            // Expresse a função n³/1000 - 100n² - 100n + 3 em termos de notação Θ

            //  n³ ( 1000, 100n², 100,  3) - corta tudo no parenteses

            // n³ - n² - n

            // Resposta: O(N³)
        }

        public static void ex2() // FEITO 
        {
            // ALGORITMO A = O(n^3) em todos os casos

            // ALGORITMO B = Melhor: O(logP);
            //               Médio: O(P^2);
            //               Pior: O(P^3)
        }

        unsafe struct Produto // STRUCT EX 3
        {
            public int* Codigo;
            public char* Nome;
            public decimal* Preco;
        }
        
        public unsafe static void ex3() // FEITO
        {
            const int tam = 5;

            Produto** produtos = (Produto**)NativeMemory.Alloc((nuint)tam, (nuint)sizeof(Produto*));

            for (int i = 0; i < tam; i++)
            {
                produtos[i] = (Produto*)NativeMemory.Alloc(1, (nuint)sizeof(Produto));

                produtos[i]->Codigo = (int*)NativeMemory.Alloc(1, (nuint)sizeof(int));
                produtos[i]->Nome = (char*)NativeMemory.Alloc(1, (nuint)sizeof(char));
                produtos[i]->Preco = (decimal*)NativeMemory.Alloc(1, (nuint)sizeof(decimal));

                Console.WriteLine($"\n ===== Produto {i + 1} =====");

                Console.Write("\nDigite o Código (int): ");
                *produtos[i]->Codigo = int.Parse(Console.ReadLine());

                Console.Write("Digite o Nome (char): ");
                string nomeInput = Console.ReadLine();
                *produtos[i]->Nome = nomeInput.Length > 0 ? nomeInput[0]: ' ';

                Console.Write("Digite o Preço (decimal): ");
                *produtos[i]->Preco = decimal.Parse(Console.ReadLine());
            }

            for (int i = 0; i < tam - 1; i++) // bubble sort decrescente
            {
                for (int j = i + 1; j < tam; j++)
                {
                    if (*produtos[i]->Preco < *produtos[j]->Preco)
                    {
                        Produto* temp = produtos[i];
                        produtos[i] = produtos[j];
                        produtos[j] = temp;
                    }
                }
            }

            decimal soma = 0;
            for (int i = 0; i < tam; i++)
            {
                soma += *produtos[i]->Preco;
            }
            decimal media = soma / tam;

            Console.WriteLine($"\n ===== Média dos preços: {media:F2}=====");

            Console.WriteLine("\nProdutos Cadastrados:\n");

            for (int i = 0; i < tam; i++)
            {
                Console.WriteLine($"Codigo: {*produtos[i]->Codigo}, Nome: {*produtos[i]->Nome}, Preco: {*produtos[i]->Preco:F2}");
            }

            for (int i = 0; i < tam; i++) 
            {
                NativeMemory.Free(produtos[i]->Codigo);
                NativeMemory.Free(produtos[i]->Preco);
                NativeMemory.Free(produtos[i]->Nome);
            }
            NativeMemory.Free(produtos);
        }

        public static void MedirTempoDeAlocacao(int tamanho) // VOID EX 4 
        { 
            Stopwatch sw = new Stopwatch(); // USEI STOPWATCH, NAO EXISTE CTIME EM C#, SO C E C++
            sw.Start();

            int[,] matriz = new int[tamanho, tamanho]; 

            sw.Stop();
            Console.WriteLine($"Tempo para alocar matriz {tamanho}x{tamanho}: {sw.Elapsed.TotalMilliseconds} ms");
        }

        public unsafe static void ex4() // FEITO
        {
            int tamanho;
            int* ptrTamanho;

            Console.Write("Informe o tamanho da matriz quadrada: ");
            int valor = int.Parse(Console.ReadLine());

            ptrTamanho = &valor;
            tamanho = *ptrTamanho;

            Console.WriteLine($"Tamanho informado: {tamanho}");

            MedirTempoDeAlocacao(tamanho);

            Console.WriteLine("\n== Testes para tamanhos 10 e 1000000 ==");

            MedirTempoDeAlocacao(10);
            //MedirTempoDeAlocacao(1000000);
        }

        public static void ex5() // FEITO
        {
            int[] vetor = new int[1];
            int tamanho = 0;
            int anterior = int.MinValue;

            Console.WriteLine("Digite valores inteiros (-1 para parar):");

            while (true)
            {
                int valor = int.Parse(Console.ReadLine());
                if (valor == -1)
                    break;

                if (valor != anterior)
                {
                    int[] novoVetor = new int[tamanho + 1];
                    for (int i = 0; i < tamanho; i++)
                    {
                        novoVetor[i] = vetor[i];
                    }
                    novoVetor[tamanho] = valor;
                    vetor = novoVetor;
                    tamanho++;
                }

                anterior = valor;
            }

            Console.WriteLine($"Tamanho final = {tamanho}");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write($"{vetor[i]} ");
            }
            Console.WriteLine();
        }

        public unsafe static void ex6() // FEITO
        {
            int linhas, colunas;
            int* ptrLinhas, ptrColunas;

            Console.Write("Informe o número de linhas: ");
            int l = int.Parse(Console.ReadLine());
            Console.Write("Informe o número de colunas: ");
            int c = int.Parse(Console.ReadLine());

            ptrLinhas = &l;
            ptrColunas = &c;

            linhas = *ptrLinhas;
            colunas = *ptrColunas;

            Console.WriteLine($"Criando matriz {linhas} x {colunas}...");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[][] matriz = new int[linhas][];
            for (int i = 0; i < linhas; i++)
            {
                matriz[i] = new int[colunas];
            }

            sw.Stop();

            Console.WriteLine($"Tempo de alocação: {sw.Elapsed.TotalMilliseconds} ms");
        }

        static long Fatorial(int n) // EX 7
        {
            long fat = 1;
            for (int i = 2; i <= n; i++)
            {
                fat *= i;
            }
            return fat;
        }

        public static void ex7() // FEITO
        {
            Console.Write("Digite um número para calcular o fatorial: ");
            int n = int.Parse(Console.ReadLine());

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long resultado = Fatorial(n);

            sw.Stop();

            Console.WriteLine($"Fatorial de {n} é {resultado}");
            Console.WriteLine($"Tempo de execução: {sw.Elapsed.TotalMilliseconds} ms");
        }

        public static void ex8() // FEITO
        {
            // O que é?
            // A imagem é um gráfico comparativo das complexidades de tempo mais comuns em algoritmos,
            // representadas em notação Big-O

            // Para que serve?
            // 1 - Comparar eficiência de algoritmos;
            // 2 - Estimar tempo de execução conforme o crescimento da entrada;
            // 3 - Ajudar na escolha do algoritmo mais adequado para um problema;
            // 4 - Prever escalabilidade do sistema ou software

            // Quando é utilizado?
            // 1 - Durante o desenvolvimento de algoritmos;
            // 2 - Em entrevistas técnicas e concursos;
            // 3 - Na escolha entre diferentes estruturas de dados;
            // 4 - Em avaliações de desempenho de sistemas

            // Exemplo: Em um aplicativo de agenda, ao procurar por um evento por data em uma lista ordenada,
            // é possível usar busca binária (O(log n)), que é mais eficiente do que uma busca simples (O(n)).
        }

        public static void ex9() // FEITO
        {
            // Quais fatores determinam o custo final de um algoritmo?

            // RESPOSTA: 

            // Tamanho de entrada (N), complexidade do algoritmo, tipo de operações realizadas,
            // estrutura de dados utilizada, recursos computacionais disponíveis, implementação e otimização
        }

        public static void ex10() // FEITO
        {
            // Quando um código tem uma PA ou uma PG qual a complexidade do algoritmo?
            // Que tipos de códigos que aparecem uma PA ou PG ?

            // RESPOSTA:

            // PA (Progressão Aritmética): isso significa que o incremento ou decremento dentro de uma estrutura
            // de repetição acontece de forma constante, quando um laço FOR incrementa a variável de controle de
            // (i = i + 1), o número total de iterações cresce proporcionalmente ao tamanho da entrada

            // PG (Progressão Geométrica), o incremento ocorre de forma multiplicativa,
            // como em i = i * 2. Esse tipo de laço executa um número de vezes que cresce de forma logarítmica
            // em relação ao tamanho da entrada

            // Códigos com progressão aritmética são comuns em situações onde é necessário percorrer elementos um a um, 
            // como ao somar todos os valores de um vetor. Já os com progressão geométrica aparecem com frequência em
            // algoritmos mais eficientes, como a busca binária, onde a cada passo o espaço de busca é reduzido pela metade
        }
    }
}
