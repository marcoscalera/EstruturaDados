using System;
namespace MarcosCalera_Lista1
{

    class MarcosCalera_Lista1
    {
        public static void Main(string[] args)
        {
            // MARCOS PAULO CALERA

            //ex1(); // feito
            //ex2(); // feito
            //ex3(); // feito
            //ex4(); // feito
            ex5(); // feito
            //ex6(); // feito
            //ex7(); // feito
            //ex8(); // feito
            //ex9(); // feito
            
        }

        static void ex1() // EXERCICIO 1
        {
            int num1 = 1, num2 = 1, total = 0;
            for (num1 = 1; num1 < 10; num1++)
            {
                for (num2 = 1; num2 < 10; num2++)
                {
                    total = num1 * num2;
                    Console.WriteLine(num1 + " * " + num2 + " = " + total + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        static void ex2() // EXERCICIO 2
        {
            double[] precos = new double[10]; // criei o vetor que armazena 10 preços, o double é um "ponto flutuante", armazena decimais, [ ] para declarar array

            Console.WriteLine("Digite os 10 preços iniciais para calcular o aumento:"); // usuario popula o vetor

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Preço {i + 1}: "); // o $ interpola pra escrever mais facil
                precos[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 10; i++) // aumento 15%
            {
                precos[i] *= 1.15;
            }

            Console.WriteLine("\nPreços atualizados com 15% de inflação:"); // exibir preços novos
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Preço {i + 1}: {precos[i]:F2}"); // garante que aparece apenas 2 numeros apos a virgula
            }
        }

        static void ex3() // EXERCICIO 3
        {
            int[] numeros = new int[10];
            int soma = 0;
            int media = 0;
            int contador = 0;

            Console.WriteLine("Digite 10 numeros inteiros");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Número {i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine()); // le uma string digitada pelo usuário e converte para um numero inteiro
                soma += numeros[i];
            }

            media = soma / 10;

            for (int i = 0; i < 10; i++)
            {
                if (numeros[i] == media)
                {
                    contador++;
                }
            }
            Console.WriteLine($"O resultado da média foi {media}, ela foi digitada {contador} vezes pelo usuário");
        }

        static void ex4() // EXERCICIO 4
        {
            Console.WriteLine("Digite SIM ou NÃO");
            string opcao = Console.ReadLine();

            if (opcao.Equals("SIM", StringComparison.OrdinalIgnoreCase)) // a comparação so funciona com o metodo EQUALS, ali ignora se é maiusculo ou nao
            {
                Console.WriteLine($"Você digitou a opção SIM, valor: 01");
            }

            else if (opcao.Equals("NÃO", StringComparison.OrdinalIgnoreCase) ||
                    (opcao.Equals("NAO", StringComparison.OrdinalIgnoreCase))) // a comparação so funciona com o metodo EQUALS, ali ignora se é maiusculo ou nao
            {
                Console.WriteLine($"Você digitou a opção NÃO, valor: 0");
            }

            else
            {
                Console.WriteLine("Escolha corretamente as opções");
            }
        }

        static void ex5() // EXERCICO 5
        {
            int termo = 15;
            Console.WriteLine("série de fibonacci do 1º ao 15º termo:");
            for (int i = 1; i <= termo; i++)
            {
                Console.Write($"{fibonacci(i)} ");
            }

        }

        static int fibonacci(int n) // EXERCICIO 5
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;

            int a = 0;
            int b = 1;
            int resultado = 0;

            for (int i = 2; i <= n; i++)
            {
                resultado = a + b;
                a = b;
                b = resultado;
            }

            return resultado;
        }

        static void ex6() // EXERCICIO 6
        {
            int[] numeros = new int[4];
            float[] resultado = new float[4];

            Console.WriteLine("Digite 4 numeros inteiros");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Número {i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    resultado[i] = (float)numeros[i] * 3; // cast pro float, indice 0
                }

                else
                {
                    resultado[i] = (float)numeros[i] * numeros[i]; // cast pra float dnv
                }
            }

            Console.WriteLine("\nResultados: ");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Numero {i + 1}: {resultado[i]}");
            }
        }

        static void ex7() // EXERCICIO 7
        {
            int[] numeros = new int[10];

            Console.WriteLine("Digite 10 valores inteiros:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Valor {i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Digite 1 para ordem CRESCENTE e 2 para DECRESCENTE:");
            int opcao = int.Parse(Console.ReadLine());

            int[] numerosOrdenados = new int[10];
            Array.Copy(numeros, numerosOrdenados, 10);

            switch (opcao)
            {
                case 1:
                    BubbleSortCrescente(numerosOrdenados);
                    Console.WriteLine("\nA sequência CRESCENTE é: ");
                    break;

                case 2:
                    BubbleSortDecrescente(numerosOrdenados);
                    Console.WriteLine("\nA sequência DECRESCENTE é: ");
                    break;

                default:
                    Console.WriteLine("\nAlgo deu errado");
                    return;
            }

            foreach (int num in numerosOrdenados)
            {
                Console.Write(num + " ");
            }

            static void BubbleSortCrescente(int[] array) // EXERCICIO 7 BUBBLE C
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            // troca elementos
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            static void BubbleSortDecrescente(int[] array) // EXERCICIO 7 BUBBLE DC
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] < array[j + 1])
                        {
                            // troca elementos
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }

        static void ex8() // EXERCICIO 8
        {
            float[] vetor = new float[10];
            float menor, maior;

            Console.WriteLine("Digite 10 valores");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Numero {i + 1}: ");
                vetor[i] = float.Parse(Console.ReadLine()); // atribuindo o valor
            }

            menor = vetor[0];
            maior = vetor[0];

            for (int i = 0; i < 10; i++)
            {
                if (vetor[i] < menor)
                {
                    menor = vetor[i];
                }

                if (vetor[i] > maior)
                {
                    maior = vetor[i];
                }
            }
            Console.WriteLine($"\nO maior numero é: {maior}\nO menor numero é: {menor}");
        }

        static void ex9() // EXERCICIO 9
        {
            Console.WriteLine("Digite um numero inteiro");
            int digitado = int.Parse(Console.ReadLine());

            if (digitado % 2 == 0)
            {
                Console.WriteLine($"\nO numero {digitado} é par");
            }

            else
            {
                Console.WriteLine($"\nO numero {digitado} é impar");
            }

            bool priminho = true; // aqui to assumindo que tudo é primo 

            if (digitado <= 1)
            {
                priminho = false;
            }

            else
            {
                for (int i = 2; i < digitado; i++) // verificando divisibilidade
                {
                    if (digitado % 1 == 0)
                    {
                        priminho = false; // se conseguir ser divisivel deixa de ser primo
                        break;
                    }
                }
            }

            if (priminho)
            {
                Console.WriteLine("\nÉ primo");
            }

            else
            {
                Console.WriteLine("\nÑão é primo");
            }
        }
    }
}
