using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
namespace MarcosCalera_Lista3
{
    class MarcosCalera_Lista3
    {
        static void Main(string[] args)
        {
            // utilizei ia para compreensao de fila (stackalloc), pois estava com dificuldades
            //ex1(); // feito
            //ex2(); // feito
            //ex3(); // feito - não entendi direito a questao
            //ex4(); // feito
            //ex5(); // feito - não entendi direito a questao
            //ex6(); // feito
            //ex7(); // feito
            //ex8(); // feito
            //ex9(); // feito
            //ex10(); // feito
        }

        public struct Atleta // STRUCT DO EX 1
        {
            public int idade;
            public string posicao, nome;
            public double altura;

            public Atleta(int idade, string? posicao, string? nome, double altura)
            {
                this.idade = idade;
                this.posicao = posicao;
                this.nome = nome;
                this.altura = altura;
            }
        }

        static void idadeDecrescente(Atleta[]atletas) // BUBBLE SORT EX 1
        {
            int n = atletas.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (atletas[j].idade < atletas[j + 1].idade)
                    {
                        // troca 
                        Atleta temp = atletas[j];
                        atletas[j] = atletas[j + 1];
                        atletas[j + 1] = temp;
                    }
                }
            }
        }
  
        static void ex1() // EXERCICIO 1
        {
            int tamanho = 5; // limitador no loop que irei criar para nao usar funcao pronta
            Atleta[]atletas = new Atleta[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine($"Atleta {i + 1}: ");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Posição: ");
                string posicao = Console.ReadLine();

                Console.Write("Idade: ");
                int idade = int.Parse(Console.ReadLine());

                Console.Write("Altura: ");
                double altura = double.Parse(Console.ReadLine());

                Console.WriteLine("");

                atletas[i] = new Atleta(idade, posicao, nome, altura);
            }

            idadeDecrescente(atletas); 
                
            for (int i = 0;i < tamanho; i++)
            {
                Console.WriteLine($"Nome: {atletas[i].nome}, Posição: {atletas[i].posicao}, Idade: {atletas[i].idade}, Altura: {atletas[i].altura}");
            }
        }

        public unsafe struct Produto // STRUCT EX 2
        {
            public string nome, fornecedor;
            public int* codigo;
            public double* preco;

        }

        unsafe static void ex2() // EXERICICO 2
        {
            int tamanho = 5; // nao utilizando funcao pronta
            Produto[] produtos = new Produto[tamanho]; // array dos 5 produtos

            int[] codigos = new int[5];
            double[] precos = new double[5]; // criei as duas variaveis temporarias de armazenamento

            for (int i = 0; i < tamanho; i++) // for de preenchimento dos dados do produtos
            {
                Console.WriteLine($"Produto {i + 1}");
                Console.WriteLine(""); 

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Código: ");
                codigos[i] = int.Parse(Console.ReadLine());

                Console.Write("Preço: ");
                precos[i] = double.Parse(Console.ReadLine());

                Console.Write("Fornecedor: ");
                string fornecedor = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("======================="); // frufru
                Console.WriteLine("");

                fixed (int* codigoPtr = &codigos[i]) // atribuindo endereco nas temporarias
                fixed (double* precoPtr = &precos[i])
                {
                    produtos[i] = new Produto
                    {
                        nome = nome,
                        codigo = codigoPtr,
                        preco = precoPtr,
                        fornecedor = fornecedor
                    };
                }
            }
            Console.WriteLine("Produtos cadastrados: ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine($"\nProduto {i + 1}");
                Console.WriteLine($"Nome: {produtos[i].nome}");
                Console.WriteLine($"Código: {*produtos[i].codigo}");
                Console.WriteLine($"Preço: {*produtos[i].preco}");
                Console.WriteLine($"Fornecedor: {produtos[i].fornecedor}");
                Console.WriteLine("");
            }
        }

        unsafe static void ex3() // EXERCICIO 3 - NÃO ENTENDI A QUESTAO
        {
            //int arr[5] = { 10, 80, 40, 30, 20 };
            //int* parr = &arr[4];
            //int inx = 0;
            //inx = *parr++;

            // a) O código compila?
            // sim o código compila mas somente em C, eu até consegui fazer compilar em C# mas precisaria mudar as linhas de códigos se tornando outra coisa
            // em resumo, compila sim mas somente em C

            // b) Após executar o código, qual será o valor de inx?
            // o valor de inx sera 20

            // c) Após executar o código, para onde parr estará apontando?
            // parr vai apontar para um endereço de memória fora do array arr.
        }

        unsafe static void exibir(string[]arr, int tamanho) // FUNCAO PEDIDO NO EX 4
        {
            for (int i = 0; i < tamanho; i++) // array de strings
            {
                fixed (char* ptr = arr[i]) // fixando a string na memoria pra depois acessar o ponteiro
                {
                    char* p = ptr;
                    while (*p != '\0')
                    {
                        Console.Write(*p);
                        p++;
                    }
                    Console.WriteLine(""); // so pra pular linha
                }
            }
        }

        unsafe static void ex4() // EXERCICIO 4
        {
            string[] nomes = { "Luis", "Fernando", "Vitoria", "Leticia" };
            exibir(nomes, nomes.Length); 
        }

        unsafe static void ex5() // EXERCICIO 5 - NÃO ENTENDI A QUESTÃO
        {
            //int count = 30, *temp, sum = 2;
            //temp = &count;
            //*temp = 20;
            //temp = 8
            //* temp = count;

            // O que aparecerá quando executarmos o programa abaixo?
            // nao funcionou, esta escrito em C igual no exercicio 3, porem este nao executa nem em C por conta do erro de ponteiro temp = 8

            // O que vai exibir em cada variável ?
            // se corrigir o código arrumando sua estrutura ficaria como: count: 20, sum: 2, temp apontando para count
        }

        struct Dados // STRUCT DO EX 6 
        {
            public int[] inteiros;
            public double[] decimais;
            public char[] letras;
        }

        unsafe static void ex6() // EXERCICIO 6
        {
            int tamanho = 5;
            Dados dados;
            dados.inteiros = new int[tamanho];
            dados.decimais = new double[tamanho];
            dados.letras = new char[tamanho];

            Console.WriteLine("Digite 5 numeros inteiros: ");
            for (int i = 0; i < tamanho; i++) // loop for que vai nos dados de toda struct a seguir
            {
                dados.inteiros[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("");
            Console.WriteLine("Digite 5 numeros decimais: ");
            for (int i = 0; i < tamanho; i++)
            {
                dados.decimais[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("");
            Console.WriteLine("Digite 5 letras: ");
            for (int i = 0; i < tamanho; i++)
            {
                dados.letras[i] = Console.ReadLine()[0];
            }

            fixed (int* pInteiros = dados.inteiros) // substituicao dos valores
            fixed (double* pDecimais = dados.decimais)
            fixed (char* pLetras = dados.letras)
            {
                for (int i = 0; i < tamanho; i++) // loop for para substituicao pedido no ex
                {
                    *(pInteiros + i) = 100;
                    *(pDecimais + i) = 1.99;
                    *(pLetras + i) = 'W';
                }
            }

            Console.WriteLine("\nValores atualizados: ");
            Console.WriteLine("");
            Console.WriteLine("Inteiros: ");
            foreach (int i in dados.inteiros) // loop foreach para atualizacao
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("");
            Console.WriteLine("Decimais: ");
            foreach (double d in dados.decimais)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("");
            Console.WriteLine("Letras: ");
            foreach (char c in dados.letras)
            {
                Console.WriteLine(c);
            }
        }

        struct Carrefourto // STRUCT EX 7
        {
            public string Nome;
            public double Valor;

            public Carrefourto(string nome, double valor)
            {
                Nome = nome;
                Valor = valor;
            }
        }

        unsafe static void ex7() // EXERCICIO 7
        {
            const int numProdutos = 10; 
            Carrefourto[] produtos = new Carrefourto[numProdutos];
            Carrefourto[] produtosAjustados = new Carrefourto[numProdutos];

            for (int i = 0; i < numProdutos; i++) // loop for para ler os produtos
            {
                Console.Write($"Digite o Produto {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write($"Digite o valor atual do produto: ");
                double valor = double.Parse(Console.ReadLine());
                Console.WriteLine("");


                produtos[i] = new Carrefourto(nome, valor);
            }

            fixed (Carrefourto* pProdutos = &produtos[0], pProdutosAjustados = &produtosAjustados[0]) // apliquei reajuste de preço com ponteiro
            {
                for (int i = 0; i < numProdutos; i++)
                {
                    (pProdutosAjustados + i)->Nome = (pProdutos + i)->Nome; // aqui a -> serve para acessar os campos da struct com ponteiro
                    (pProdutosAjustados + i)->Valor = (pProdutos + i)->Valor * 1.0478; // multipliquei pra aplicar o aumento
                }
            }

            Console.WriteLine("\nValores ajustados: ");
            Console.WriteLine("");
            for (int i = 0; i < numProdutos; i++)
            {
                Console.WriteLine($"Produto: {produtosAjustados[i].Nome}, Valor ajustado: {produtosAjustados[i].Valor:C}"); 
                // coloquei o :C dps do valor pra mostrar em moeda e fixar em 2 casas depois da virgula
            }
        }

        unsafe static void ex8() // EXERCICIO 8
        {
            int tamanho = 9; // SEM FUNCAO PRONTA 
            int[] vetor = new int[tamanho];
            int* pVetor = stackalloc int[tamanho]; // criacao de pilha, aqui alocou memoria na pilha

            // a) populando vetor usando ponteiro
            Console.WriteLine("Digite 9 valores inteiros: ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write($"Valor {i + 1}: ");
                *(pVetor + i) = int.Parse(Console.ReadLine());
            }

            // b) ordenando vetor com bubble sort
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < (tamanho - 1) - i; j++)
                {
                    if (*(pVetor + j) > *(pVetor + j + 1))
                    {
                        int temp = *(pVetor + j);
                        *(pVetor + j) = *(pVetor + j + 1);
                        *(pVetor + j + 1) = temp;
                    }
                }
            }
            // c) populando matriz 3x3 com valores do vetor
            int* pMatriz = stackalloc int[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                *(pMatriz + i) = *(pVetor + i);
            }

            // d) exibir os elementos do vetor
            Console.WriteLine("\nElementos do vetor ordenado: ");
            for (int i = 0;i < tamanho; i++)
            {
                Console.Write(*(pVetor + i) + " ");
            }

            int tamMatriz = 3; // sem funcao pronta
            Console.WriteLine("\n\nElementos da matriz 3x3: ");
            for (int i = 0; i < tamMatriz; i++)
            {
                for (int j = 0; j < tamMatriz; j++)
                {
                    Console.Write(*(pMatriz + i * tamMatriz + j) + " ");
                }
                Console.WriteLine(" ");
            }
        }

        unsafe static int contarChar(string frase) // FUNCAO DE CONTAR CARACTERES DO EXERCICIO 9
        {
            int tamanho = 0;
            fixed (char* p = frase)
            {
                char* ponteiro = p;
                while (*ponteiro != '\0') // percore ate encontraro char nulo
                {
                    tamanho++;
                    ponteiro++;
                }
            }
            return tamanho;
        }

        static void ex9() // EXERCICIO 9 
        {
            Console.Write("Digite a primeira frase: ");
            string frase1 = Console.ReadLine();
            Console.Write("Digite a segunda frase: ");
            string frase2 = Console.ReadLine();

            int tamanhoFrase1 = contarChar(frase1); // usando ponteiro pra contar o tamanho
            int tamanhoFrase2 = contarChar(frase2);

            int tamanhoMaior = Math.Max(tamanhoFrase1, tamanhoFrase2); // definindo a maior

            Console.WriteLine($"\nO tamanho da maior frase é: {tamanhoMaior}");
        }

        unsafe static void crescente(decimal* arr, int tamanho) // BUBBLE SORT EX 10
        {
            for (int i = 0; i < tamanho - 1; i++)
            {
                for (int j = 0; j < tamanho - i - 1; j++)
                {
                    if (*(arr + j) > *(arr + j + 1))
                    {
                        decimal temp = *(arr + j);
                        *(arr + j) = *(arr + j + 1);
                        *(arr + j + 1) = temp;
                    }
                }
            }
        }

        unsafe static void ex10() // EXERCICIO 10
        {
            int tamanho = 10; // SEM FUNCAO PRONTA
            decimal* numeros = stackalloc decimal[tamanho]; // criacao de pilha
            decimal* ptr = numeros; // alocando os 10 numeros

            for (int i = 0; i < tamanho; i++) // loop for para leitura dos numeros
            {
                Console.Write($"Digite o {i + 1}º numero decimal: ");
                *(ptr + i) = decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine("");

            Console.Write("Digite o numero que deseja buscar: ");
            decimal numeroBuscado = decimal.Parse(Console.ReadLine());

            crescente(ptr, 10); // puxando o bubble sort

            bool encontrado = false;
            for (int i = 0; i < tamanho; i++)
            {
             if (*(ptr + i) == numeroBuscado)
                {
                    encontrado = true;
                    break;
                }   
            }
            if (encontrado)
            {
                Console.WriteLine("O numero buscado foi encontrado no vetor");
            }
            else
            {
                Console.WriteLine("O numero nao foi encontrado no vetor");
            }
        }
    }
}