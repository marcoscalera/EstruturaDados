using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
namespace MarcosCalera_Lista4
{
    class MarcosCalera_Lista4
    {
        public unsafe static void Main(string[] args)
        {
            //ex1();  // feito comentado na void
            //ex2();  // feito comentado na void
            //ex3();  // feito comentado na void
            //ex4();  // feito comentado na void
            //ex5();  // feito
            //ex6();  // feito
            //ex7();  // feito
            ex8();  // feito
            //ex9();  // feito
            //ex10(); // feito
            //ex11(); // feito
            //ex12(); // feito 
            //ex13(); // feito
            //ex14(); // feito
            //ex15(); // feito
            //ex16(); // feito
        }

        public static void ex1() // feito
        {
            // Pergunta: O que é e como funciona uma estrutura do tipo Pilha? Em que situações ela é utilizada

            // Resposta: a estrutura de dados pilha é uma abstração que segue o princípio LIFO (Last In, First Out)
            // onde o último elemento adicionado é o primeiro a ser removido, as operações básicas incluem
            // (adicionar elemento - push) para adicionar elementos 
            // (remover elemento - pop) para remover o elemento do topo
            // pode ser usada para funções recursivas em compiladores
        }

        public static void ex2() // feito
        {
            // Pergunta: O que significa alocação sequencial de memória para um conjunto de elementos?

            // Resposta: alocação sequencial significa que os dados são armazenados em
            // posições contíguas(sequenciais) de memória, facilitando o acesso por meio de
            // índices ou deslocamentos
        }

        public static void ex3() // feito
        {
            // Pergunta: O que significa alocação estática de memória para um conjunto de elementos?

            // Resposta: alocação estática de memória significa que o espaço para um conjunto de elementos
            // é reservado durante a compilação e mantido fixo durante toda a execução do programa
        }

        public static void ex4() // feito
        {
            // Pergunta: O que significa alocação dinâmica de memória para um conjunto de elementos?

            // Resposta: alocação dinâmica de memória significa que o espaço para um conjunto de elementos
            // é reservado durante a execução do programa (em tempo de execução), permitindo que o tamanho
            // seja definido ou alterado conforme a necessidade.
        }

        public static void ex5() // feito
        {
            const int TAMANHO = 20;

            int[] numeros = new int[TAMANHO];

            int[] P1 = new int[TAMANHO]; // pilha par positivo e negativo
            int[] P2 = new int[TAMANHO]; // pilha impar positivo e negativo
            int[] P3 = new int[TAMANHO]; // positivos P2 e negativos P1

            int topoP1 = -1;
            int topoP2 = -1;
            int topoP3 = -1;

            Console.WriteLine("Digite 20 números (positivos, negativos, pares e ímpares): ");
            for (int i = 0; i < TAMANHO; i++)
            {
                Console.Write($"Número {i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            foreach (int num in numeros)
            {
                if (num % 2 == 0) // pares
                {
                    if (topoP1 < TAMANHO - 1)
                    {
                        P1[++topoP1] = num;
                    }
                }
                else // impares
                {
                    if (topoP2 < TAMANHO - 1)
                    {
                        P2[++topoP2] = num;
                    }
                }
            }
            // mover positivo p P3
            int tempTopoP2 = topoP2;
            topoP2 = -1;
            int[] tempP2 = new int[TAMANHO];
            Array.Copy(P2, tempP2, TAMANHO);

            for (int i = 0; i <= tempTopoP2; i++)
            {
                int num = tempP2[i];
                if (num > 0)
                {
                    if (topoP3 < TAMANHO - 1)
                    {
                        P3[++topoP3] = num;
                    }
                }
                else // manter negativo impar no P2
                {
                    if (topoP2 < TAMANHO - 1)
                    {
                        P2[++topoP2] = num;
                    }
                }
            }

            int tempTopoP1 = topoP1;
            topoP1 = -1;
            int[] tempP1 = new int[TAMANHO];
            Array.Copy(P1, tempP1, TAMANHO);

            for (int i = 0; i <= tempTopoP1; i++)
            {
                int num = tempP1[i];
                if (num < 0) // mover negativo p P3
                {
                    if (topoP3 < TAMANHO - 1)
                    {
                        P3[++topoP3] = num;
                    }
                }
                else // par positivo mantem em P1
                {
                    if (topoP1 < TAMANHO - 1)
                    {
                        P1[++topoP1] = num;
                    }
                }
            }

            Console.WriteLine("\n======== RESULTADO FINAL ========\n");
            ImprimirPilha(P1, topoP1, "P1 - Pares Positivos");
            ImprimirPilha(P2, topoP2, "P2 - Ímpares Negativos");
            ImprimirPilha(P3, topoP3, "P3 - Positivos(P2) e Negativos(P1)");
            Console.WriteLine("=================================");

            void ImprimirPilha(int[] pilha, int topo, string nome) // funcao de impressao ex 5
            {
                Console.WriteLine();
                Console.WriteLine($"=== {nome} ===");
                Console.WriteLine($"Elementos ({topo + 1}):");

                for (int i = 0; i <= topo; i++)
                {
                    Console.WriteLine($"  [{i}] > {pilha[i]}");
                }
                Console.WriteLine();
            }
        }


        public static void ex6() // feito
        {
            // Analise as afirmações a seguir a respeito de pilhas:
            // I - Novos elementos entram, no conjunto, exclusivamente, no topo da pilha.

            // II - O único elemento que pode sair da pilha em um dado momento, é o elemento do topo.

            // III - As Pilhas são conhecidas como LIFO(last in, first out), isto é,
            // o último a entrar é o último asair.

            // IV - As operações Push e Pop são respectivamente para desempilhar e empilhar

            // Estão corretas as afirmações:
            // a) I e II.
            // b) I e III.
            // c) II e III.
            // d) I, II e III.
            // e) III e IV

            // Resposta: a) I e II.
            // pilhas só permitem inserções (push) no topo, o único elemento que pode sair é o do topo
        }

        public static void ex7() // feito
        {
            // Pilha_Vazia(P): retorna True se a pilha P estiver vazia e False se estiver cheia;
            // Pilha_Cheia(P): retorna True se a pilha P estiver cheia e False se estiver vazia;
            // Empilha(P,’x’): insere o elemento x no topo da pilha P;
            // Desempilha(P): remove o 1º elemento da pilha P e retorna o conteúdo como valor da função;
            // Imprime(P) – imprime a pilha P.

            const int TAMANHO = 8;

            Stack<char> pilha = new Stack<char>(TAMANHO);

            // pilha_cheia(P)
            Console.WriteLine("Pilha cheia? " + (pilha.Count == TAMANHO));

            // empilha(P, 's')
            if (pilha.Count < TAMANHO) pilha.Push('s');

            // empilha(P, 'p')
            if (pilha.Count < TAMANHO) pilha.Push('p');

            // desempilha(P)
            if (pilha.Count > 0) pilha.Pop();

            // empilha(P, 'h')
            if (pilha.Count < TAMANHO) pilha.Push('h');

            // empilha(P, 'j')
            if (pilha.Count < TAMANHO) pilha.Push('j');

            // desempilha(P)
            if (pilha.Count > 0) pilha.Pop();

            // desempilha(P)
            if (pilha.Count > 0) pilha.Pop();

            // empilha(P, 't')
            if (pilha.Count < TAMANHO) pilha.Push('t');

            // empilha(P, 'r')
            if (pilha.Count < TAMANHO) pilha.Push('r');

            // empilha(P, 'y')
            if (pilha.Count < TAMANHO) pilha.Push('y');

            // empilha(P, 'x')
            if (pilha.Count < TAMANHO) pilha.Push('x');

            // desempilha(P)
            if (pilha.Count > 0) pilha.Pop();

            // pilha_vazia(P)
            Console.WriteLine("Pilha vazia? " + (pilha.Count == 0));

            // imprime(P)
            Console.WriteLine("Conteúdo da pilha:");
            foreach (char item in pilha)
            {
                Console.WriteLine(item);
            }
        }

        public static void ex8() // feito
        {
            // Pilha_Vazia(P): retorna True se a pilha P estiver vazia e False se estiver cheia;
            // Pilha_Cheia(P): retorna True se a pilha P estiver cheia e False se estiver vazia;
            // Empilha(P,’x’): insere o elemento x no topo da pilha P;
            // Desempilha(P): remove o 1º elemento da pilha P e retorna o conteúdo como valor da função;
            // Imprime(P) – imprime a pilha P.

            Stack<char> P = new Stack<char>();
            const int max = 6;

            void Empilha(char x)
            {
                if (P.Count < max)
                    P.Push(x);
                else
                    Console.WriteLine($"Pilha cheia! Não é possível empilhar '{x}'");
            }

            char Desempilha()
            {
                if (P.Count > 0)
                    return P.Pop();
                else
                {
                    Console.WriteLine("Pilha vazia! Não é possível desempilhar");
                    return ' ';
                }
            }

            bool Pilha_Cheia() => P.Count == max;
            bool Pilha_Vazia() => P.Count == 0;

            void Imprime()
            {
                Console.WriteLine("Estado atual da pilha:");
                foreach (char c in P)
                    Console.WriteLine(c);
            }

            Empilha('b');
            if (!Pilha_Cheia()) Empilha('s');
            if (!Pilha_Cheia()) Empilha('a');
            Empilha('p');
            Empilha('c');

            Empilha('h');
            if (!Pilha_Cheia()) Empilha('r');
            if (!Pilha_Cheia()) Desempilha();
            Empilha('t');

            Empilha('b');
            if (!Pilha_Cheia()) Desempilha();
            Empilha('m');
            Desempilha();
            Desempilha();
            Imprime();

            Console.WriteLine("Pilha vazia? " + Pilha_Vazia());
        }
        
        public static void ex9() // feito
        {
            Stack<char> pilha = new Stack<char>();

            pilha.Push('A'); // linha 1

            pilha.Push('B'); // linha 2

            pilha.Push('C'); // linha 3

            pilha.Push('D'); // linha 4

            pilha.Pop(); // linha 5
            pilha.Pop();

            pilha.Push('K'); // linha 6
            pilha.Push('V');
            pilha.Pop();

            foreach (char item in pilha)
            {
                Console.WriteLine(item);
            }
        }

        public static void ex10() // feito
        {
            Stack<int> pilha = new Stack<int>();
            pilha.Push(10);
            pilha.Push(2);
            pilha.Push(-11);
            pilha.Push(46);
            pilha.Push(5);

            Maior(pilha);
            Menor(pilha);
            Media(pilha);
        }

        public static void Maior(Stack<int> pilha) // funcao do maior numero ex 10
        {
            Stack<int> pilhaAux = new Stack<int>();
            int maior = int.MinValue;

            while (pilha.Count > 0)
            {
                int valor = pilha.Pop();
                if (valor > maior)
                {
                    maior = valor;
                }
                pilhaAux.Push(valor); // guardei na pilha auxiliar
            }

            while (pilhaAux.Count > 0) // devolve os valores
            {
                pilha.Push(pilhaAux.Pop());
            }
            Console.Write($"O maior valor é: {maior}");
        }

        public static void Menor(Stack<int> pilha) // funcao do menor numero ex 10
        {
            Stack<int> pilhaAux = new Stack<int>();
            int menor = int.MaxValue;

            while (pilha.Count > 0)
            {
                int valor = pilha.Pop();
                if (valor < menor)
                {
                    menor = valor;
                }
                pilhaAux.Push(valor);
            }

            while (pilhaAux.Count > 0) // devolve os valores
            {
                pilha.Push(pilhaAux.Pop());
            }
            Console.Write($"\nO menor valor é: {menor}");
        }

        public static void Media(Stack<int> pilha) // funcao media ex 10
        {
            Stack<int> pilhaAux = new Stack<int>();
            int soma = 0;
            int contador = 0;

            while (pilha.Count > 0)
            {
                int valor = pilha.Pop();
                soma += valor;
                contador++;
                pilhaAux.Push(valor);
            }

            while (pilhaAux.Count > 0) // devolve os valores
            {
                pilha.Push(pilhaAux.Pop());
            }

            if (contador > 0)
            {
                double media = (double)soma / contador;
                Console.Write($"\nA média é: {media}");
            }
            else
            {
                Console.WriteLine("\nA pilha está vazia");
            }
                
        }

        public static void ex11() // feito
        {
            Stack<int> pilha = new Stack<int>();
            pilha.Push(1);
            pilha.Push(2);
            pilha.Push(3);
            pilha.Push(4);

            Console.WriteLine("Pilha original:");
            foreach (var item in pilha)
            {
                Console.WriteLine(item);
            }

            InverterPilha(pilha);

            Console.WriteLine("\nPilha invertida:");
            foreach (var item in pilha)
            {
                Console.WriteLine(item);
            }
        }

        public static void InverterPilha(Stack<int> pilha) // função ex 11
        {
            if (pilha == null || pilha.Count <= 1)
            {
                return;
            }

            Stack<int> pilhaAuxiliar1 = new Stack<int>(); 
            Stack<int> pilhaAuxiliar2 = new Stack<int>(); 

            while (pilha.Count > 0)
            {
                pilhaAuxiliar1.Push(pilha.Pop()); // pilha original para a auxiliar 1
            }

            while (pilhaAuxiliar1.Count > 0)
            {
                pilhaAuxiliar2.Push(pilhaAuxiliar1.Pop()); // auxiliar 1 para a auxiliar 2
            }

            while (pilhaAuxiliar2.Count > 0)
            {
                pilha.Push(pilhaAuxiliar2.Pop()); // volta da auxiliar 2 para a pilha original 
            }
        }

        public static void ex12() // feito
        {
            Stack<int> pilha1 = new Stack<int>();
            Stack<int> pilha2 = new Stack<int>();

            pilha1.Push(1);
            pilha1.Push(2);
            pilha1.Push(3);

            pilha2.Push(4);
            pilha2.Push(5);

            bool resultado = MaisElementos(pilha1, pilha2);
            Console.WriteLine($"Pilha 1 tem mais elemento que a Pilha 2? {resultado}");
        }

        public static bool MaisElementos(Stack<int> pilha1, Stack<int> pilha2) // funcao p ver mais elemento ex 12
        {
            Stack<int> aux1 = new Stack<int>();
            Stack<int> aux2 = new Stack<int>();
            
            while (true)
            {
                bool p1_temItem = Mover(pilha1, aux1);
                bool p2_temItem = Mover(pilha2, aux2);

                if (!p1_temItem && p2_temItem) // mesma quantidade
                {
                    break; 
                }

                if (p1_temItem && !p2_temItem) // p1 terminou por ultimo e tem mais elemtno
                {
                    return true; 
                }

                if (!p1_temItem && p2_temItem) // p2 terminou por ultimo e tem mais elemento
                {
                    return false;
                }
            }

            while (Mover(aux1, pilha1)) { }
            while (Mover(aux2, pilha2)) { }

            return false; // aqui as duastem mesma quantidade
        }

        public static bool Mover(Stack<int> origem, Stack<int> destino) // funcao de mover ex 12
        {
            try
            {
                destino.Push(origem.Pop());
                return true;
            }

            catch { return false; } // pilha vazzia entao nem tem como remover
        }

        public static void ex13() // feito
        {
            Console.WriteLine("Preenchendo pilha P1: ");
            Stack<int> P1 = PreencherPilha("P1");

            Console.WriteLine("\nPreenchendo pilha P2: ");
            Stack<int> P2 = PreencherPilha("P2");

            bool resultado = PilhasIguais(P1, P2);

            Console.WriteLine($"\nAs pilhas P1 e P2 são {(resultado ? "iguais" : "diferentes")}");
        }

        public static bool PilhasIguais(Stack<int> p1, Stack<int> p2) // funcao pra ver se pilha é igual ex13
        {
            bool iguais = true;

            Stack<int> aux1 = new Stack<int>();
            Stack<int> aux2 = new Stack<int>();

            while (p1.Count > 0 && p2.Count > 0)
            {
                int topo1 = p1.Pop();
                int topo2 = p2.Pop();

                if (topo1 != topo2)
                    iguais = false;

                aux1.Push(topo1);
                aux2.Push(topo2);
            }

            if (p1.Count != p2.Count)
                iguais = false;

            while (aux1.Count > 0)
                p1.Push(aux1.Pop());

            while (aux2.Count > 0)
                p2.Push(aux2.Pop());

            return iguais;
        }

        public static Stack<int> PreencherPilha(string nome) // funcao pra preencher pilha ex13
        {
            Stack<int> pilha = new Stack<int>();
            Console.Write($"\nQuantos valores quer colocar na pilha {nome}: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Digite o {i + 1}º elemento da pilha {nome}: ");
                int valor = int.Parse(Console.ReadLine());
                pilha.Push(valor);
            }

            return pilha;
        }

        public static void ex14() // feito
        {
            string texto;
            Console.Write("Digite um texto: ");
            texto = Console.ReadLine();
            Console.WriteLine($"Texto Normal: {texto}");
            string textoInvertido = inverterString(texto);
            Console.WriteLine($"Texto Invertido: {textoInvertido}");
        }

        public static string inverterString(string str) // recursao ex 14
        {
            if (str.Length <= 1)
            {
                return str;
            }
            return string.Concat(str[str.Length - 1].ToString(), inverterString(str.Substring(0, str.Length - 1)));
        }

        public static void ex15() // feito
        {
            Console.Write("Digite um número inteiro: ");
            int numero = int.Parse(Console.ReadLine());
            int quantidadeDigitos = contarDigito(numero);
            Console.WriteLine($"O número digitado tem {quantidadeDigitos} digitos");
        }

        public static int contarDigito(int num) // recursao ex 15
        {
            if (num >= -9 && num <= 9)
            {
                return 1;
            }
            return 1 + contarDigito(num / 10); // dividi por 10 pq ai vai remover o ultimo digito do numero
        }

        public static void ex16() // feito
        {
            Console.Write("Digite um número inteiro positivo: ");
            int N = int.Parse(Console.ReadLine());

            if (N <= 0)
            {
                Console.WriteLine($"Erro, o número {N} não é maior que 0");
            }
            else
            {
                int soma = somaRecursao(N);
                Console.WriteLine($"A somatória de 1 até {N} é: {soma}");
            }
        }

        public static int somaRecursao(int n) // recursao ex 16
        {
            if (n == 1)
            {
                return 1;
            }
            else if (n <= 0)
            {
                Console.WriteLine($"Erro, o número {n} não é maior que 0");
                return 0;
            }
            return n + somaRecursao(n - 1);
        }
    }
}