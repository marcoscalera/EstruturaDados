using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
namespace MarcosCalera_Lista2
{
    class MarcosCalera_Lista2
    {
        public static void Main(string[] args)
        {
            //ex1(); // feito
            //ex2(); // feito
            //ex3(); // feito
            //ex4(); // feito
            //ex5(); // feito
            //ex6(); // feito
            ex7(); // feito 
        }

        public struct Contas // STRUCT EX 1
        {
            public string nome, cpf;
            public double saldo;

            public Contas(string nome, double saldo)
            {
                this.nome = nome; 
                this.saldo = saldo;
                this.cpf = cpf;
            }
        }

        static void decrescente(Contas[] contas) // BUBBLE SORT EX 1
        {
            int n = contas.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (contas[j].saldo < contas[j + 1].saldo)
                    {
                        // troca conta
                        Contas temp = contas[j];
                        contas[j] = contas[j + 1];
                        contas[j + 1] = temp;
                    }
                }
            }
        }

        static void ex1()
        {
            Contas[]contas = new Contas[5];
            for (int i = 0; i < 5; i++) // cadastro
            {
                Console.WriteLine($"Conta {i + 1}");
                Console.Write("Nome: ");
                contas[i].nome = Console.ReadLine();

                Console.Write("Saldo: ");
                contas[i].saldo = double.Parse(Console.ReadLine());
                
                Console.Write("CPF: ");
                contas[i].cpf = Console.ReadLine();
                Console.WriteLine(""); // so pra separar
            }

            decrescente(contas); // bubble sort
            Console.WriteLine("Cadastros Ordenados (Saldo Decrescente)");
            Console.WriteLine(""); // so pra separar tbm
            for (int i = 0; i < 5; i++) // sama ensinou que é assim que imprime todas
            {
                Console.WriteLine($"Nome: {contas[i].nome}, Saldo: {contas[i].saldo}, CPF: {contas[i].cpf}");
            }
        }
        public struct Pessoas // STRUCT EX 2 PESSOA CONTENDO OUTRA STRUCT
        {
            public string nome;
            public data_nascimento data_nasc; // struct nascimento dentro de struct pessoa
        }
        public struct data_nascimento // STRUCT EX 2 NASCIMENTO
        {
            public int dia, mes, ano;
            public data_nascimento(int dia, int mes, int ano)
            {
                this.dia = dia;
                this.mes = mes;
                this.ano = ano;
            }
        }

        static void ex2()
        {
            Pessoas[] pessoas = new Pessoas[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Pessoa {i + 1}");
                Console.Write("Nome: ");
                pessoas[i].nome = Console.ReadLine();

                Console.Write("Dia de nascimento: ");
                int dia = int.Parse(Console.ReadLine());
                while (dia < 1 || dia > 31)
                {
                    Console.WriteLine("Dia inválido!");
                    Console.Write("Dia de nascimento: ");
                    dia = int.Parse(Console.ReadLine());
                }

                Console.Write("Mês de nascimento: ");
                int mes = int.Parse(Console.ReadLine());
                while (mes < 1 || mes > 12)
                {
                    Console.WriteLine("Mês inválido!");
                    Console.Write("Mês de nascimento: ");
                    mes = int.Parse(Console.ReadLine());
                }

                Console.Write("Ano de nascimento: ");
                int ano = int.Parse(Console.ReadLine());

                pessoas[i].data_nasc = new data_nascimento(dia, mes, ano);
                Console.WriteLine("");
            }
            // encontra a pessoa mais velha
            Pessoas maisVelha = pessoas[0];
            for (int i = 1; i < 5; i++)
            {
                if (pessoas[i].data_nasc.ano < maisVelha.data_nasc.ano ||
                   (pessoas[i].data_nasc.ano == maisVelha.data_nasc.ano && pessoas[i].data_nasc.mes < maisVelha.data_nasc.mes) ||
                   (pessoas[i].data_nasc.ano == maisVelha.data_nasc.ano && pessoas[i].data_nasc.mes == maisVelha.data_nasc.mes && pessoas[i].data_nasc.dia < maisVelha.data_nasc.dia))
                {
                    maisVelha = pessoas[i];
                }
            }
            Console.WriteLine("A pessoa mais velha é:");
            Console.WriteLine($"Nome: {maisVelha.nome}");
            Console.WriteLine($"Data de nascimento: {maisVelha.data_nasc.dia}/{maisVelha.data_nasc.mes}/{maisVelha.data_nasc.ano}");
        }
        struct Ponto // STRUCT EX 3 PONTOS (REUTILIZADA NO EX4)
        {
            public double x;
            public double y;
        }

        static double calcDistancia(Ponto p1, Ponto p2) // FUNCAO EX 3 (REUTILIZADA NO EX4)
        {
            double dx = p2.x - p1.x;
            double dy = p2.y - p2.y;
            return Math.Sqrt(dx * dx + dy * dy); // essa função sera utilizada para conseguir fazer o calculo na void ex3()
        }

        static void ex3()
        {
            Ponto ponto1 = new Ponto { x = 3, y = 10 };
            Ponto ponto2 = new Ponto { y = 13, x = 50 }; // aqui eu defini 2 valores de ponto, podem ser mudados

            double distancia = calcDistancia(ponto1, ponto2); // puxando a função anterior para fazer o calculo

            Console.WriteLine($"Distância de (X: {ponto1.x}, Y: {ponto1.y}) e (X: {ponto2.x}, Y: {ponto2.y}) é {distancia}");
        }
        static void Triangulo(double lado1, double lado2, double lado3) // FUNCAO EX 4, SERVE PARA CLASSIFICAR TIPO DE TRIANGULO
        {
            if (lado1 == lado2 && lado2 == lado3)
            {
                Console.WriteLine("Triangulo equilatero");
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                Console.WriteLine("Triangulo isosceles");
            }
            else
            {
                Console.WriteLine("Triangulo escaleno");
            }
        }
        static void ex4()
        {
            Ponto[] pontos = new Ponto[6]; // armazenei os pontos que o sama pediu e depois peço ao usuario

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Digite as coordenadas do X e Y Ponto {i + 1} (exemplo de como digitar: 10 50)");
                string[] entrada = Console.ReadLine().Split(' '); // utilizei split pq o usuario digita 1 numero, aperta espaço e poe outro numero
                Console.WriteLine(); // espaço
                pontos[i].x = double.Parse(entrada[0]); // assim eu consigo dividir exemplo entrada[0], entrada[1]
                pontos[i].y = double.Parse(entrada[1]);
            }

            double lado1_T1 = calcDistancia(pontos[0], pontos[1]); // calculaar lado dos triangulos T1 0 1 2
            double lado2_T1 = calcDistancia(pontos[1], pontos[2]);
            double lado3_T1 = calcDistancia(pontos[2], pontos[0]);

            double lado1_T2 = calcDistancia(pontos[3], pontos[4]); // calculaar lado dos triangulos T2 3 4 5
            double lado2_T2 = calcDistancia(pontos[4], pontos[5]);
            double lado3_T3 = calcDistancia(pontos[5], pontos[3]);

            // partindo pra classificacao
            Console.Write("Primeiro triangulo: ");
            Triangulo(lado1_T1, lado2_T1, lado3_T1);
            Console.WriteLine(); // espaço
            Console.Write("Segundo triangulo: ");
            Triangulo(lado1_T2, lado2_T2, lado3_T3);
        }

        struct Produto // EX 5 STRUCT
        {
            public int Codigo;
            public string Nome;
            public double Preco;
            public int Quant;
        } 

        static void ex5() // DEU TRABALHO ESSE EIN PLMDDS
        {
            Produto[] produtos = new Produto[5];

            for (int i = 0; i < produtos.Length; i++) // loop for para preencher com produtos
            {
                Console.WriteLine($"Digite o produto {i + 1}");
                Console.Write("Código: ");
                produtos[i].Codigo = int.Parse(Console.ReadLine());
                Console.Write("Nome (máximo 15 letras): ");
                produtos[i].Nome = Console.ReadLine();
                Console.Write("Preço: ");
                produtos[i].Preco = double.Parse(Console.ReadLine());
                Console.Write("Quantidade: ");
                produtos[i].Quant = int.Parse(Console.ReadLine());
                Console.WriteLine(""); // so pra ppular linha
            }
            while(true) // aqui sai do loop for e entra em while para processar os peddidos
            {
                Console.Write("Digite o código do produto (ou 0 para sair): ");
                int codigoPedido = int.Parse(Console.ReadLine());

                if (codigoPedido == 0) // break do while
                {
                    Console.WriteLine("Saindo...");
                    break;
                }

                Console.WriteLine("Digite a quantidade: ");
                int quantidadePedido = int.Parse(Console.ReadLine());

                bool produtoEncontrado = false; // procurando produto em array

                for (int i = 0; i < produtos.Length; i++)
                {
                    if (produtos[i].Codigo == codigoPedido)
                    {
                        produtoEncontrado = true;

                        if (produtos[i].Quant >= quantidadePedido)
                        {
                            // atualização de estoque
                            produtos[i].Quant -= quantidadePedido;
                            Console.WriteLine($"Item vendido: {produtos[i].Nome}");
                            Console.WriteLine($"Quantidade vendida: {quantidadePedido}");
                            Console.WriteLine($"Quantidade restante: {produtos[i].Quant}");
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade insuficiente. Estoque disponivel: {produtos[i].Quant}");
                        }
                        break;
                    }
                }
                if (!produtoEncontrado)
                {
                    Console.WriteLine("Produto não encontrado");
                }
            }
        }

        public struct pessoaEx6 // STRUCT EX 6
        {
            public int numero;
            public string nome;
        }

        static int sortear(pessoaEx6[] pessoas) // FUNCAO DE SORTEIO EX 6
        {
            Random random = new Random();
            int indiceSorteado = random.Next(0, pessoas.Length);
            return pessoas[indiceSorteado].numero;
        }
        static void ex6()
        {
            pessoaEx6[] pessoas = new pessoaEx6[] // definindo conjuto das pessoas
            {
                new pessoaEx6 {numero = 1, nome = "Sama"},
                new pessoaEx6 {numero = 2, nome = "Marcos"},
                new pessoaEx6 {numero = 3, nome = "Vitor"},
                new pessoaEx6 {numero = 4, nome = "Gerso"},
                new pessoaEx6 {numero = 5, nome = "Roberto"},
                new pessoaEx6 {numero = 6, nome = "Julio"},
                new pessoaEx6 {numero = 7, nome = "Romeu"},
                new pessoaEx6 {numero = 8, nome = "Jailson"},
                new pessoaEx6 {numero = 9, nome = "Pedro"},
                new pessoaEx6 {numero = 10, nome = "Romario"}
            };

            int sortearNumero = sortear(pessoas);

            Console.WriteLine("Tente adivinhar o numero sorteado");
            Console.WriteLine(""); // pulando linha
            bool acertou = false;
            while (!acertou)
            {
                Console.Write("Digite um numero de 1 a 10: ");
                if (int.TryParse(Console.ReadLine(), out int palpite)) // criando o acerto do sorteio
                {
                    if (palpite == sortearNumero)
                    {
                        pessoaEx6 pessoaSorteada = pessoas.First(p => p.numero == sortearNumero);
                        Console.WriteLine("Você acertou");
                        Console.WriteLine($"\nNúmero sorteado: {sortearNumero}");
                        Console.WriteLine($"Pessoa sorteada: {pessoaSorteada.nome}");
                        acertou = true;
                    }
                    else
                    {
                        Console.WriteLine("Você errou, tente dnv");
                        Console.WriteLine(""); // pulando linha
                    }
                }
                else
                {
                    Console.WriteLine("Algo deu errado");
                    Console.WriteLine(""); // pulando linha
                }
            }
        }
         
        public struct Aeroporto // EX 7 STRUCT DO AEROPORTO
        {
            public int Codigo, VoosSaida, VoosChegada;
            public string Nome;
        }

        public struct Voo
        {
            public int Origem, Destino;
        }

        static void ex7() // PEGOU PPESADO DEMAIS AQUI EX 7
        {
            Aeroporto[] aeroportos = new Aeroporto[5]; // criando os 5 aeroportos

            // definindo qual é qual aeroporto
            for (int i = 0; i < aeroportos.Length; i++)
            {
                aeroportos[i] = new Aeroporto { Codigo = i, Nome = $"Aeroporto {i + 1}", VoosChegada = 0, VoosSaida = 0 };
            }

            Voo[] voos = new Voo[10]; // definindo os 10 voos

            for (int i = 0; i < voos.Length; i++) // loop for para ler voos do user
            {
                Console.WriteLine($"Digite os detalhes do voo {i + 1}: ");
                Console.Write("Codigo do aeroporto de origem (0 a 4): ");
                int origem = int.Parse(Console.ReadLine());
                Console.WriteLine(); // pula linha

                while (origem < 0 || origem > 4) // barrando o usuario de digitar um aeroporto que nao existe
                {
                    Console.WriteLine("Codigo de aeroporto invalido");
                    origem = int.Parse(Console.ReadLine());
                }

                Console.Write("Codigo do aeroporto de destino (0 a 4): ");
                int destino = int.Parse(Console.ReadLine());
                Console.WriteLine(); // pula linha

                while (destino < 0 || destino > 4) // fazendo a mesma barragem porem em destino
                {
                    Console.WriteLine("Codigo de aeroporto invalido");
                    destino = int.Parse(Console.ReadLine());
                }

                // verificando se passou o limite de 10 pedido no ex
                if (aeroportos[origem].VoosSaida >= 10 || aeroportos[destino].VoosChegada >= 10)
                {
                    Console.WriteLine("Erro: O aeroporto não pode ter mais de 10 voos de saída ou chegada...");
                    i--; // decrementa o contador para refazer a entrada do voo
                    continue;
                }

                voos[i] = new Voo { Origem = origem, Destino = destino };

                // atualizando quantidade de voos que sai
                aeroportos[origem].VoosSaida++;

                // atualizando quantidade de voos que chega
                aeroportos[destino].VoosChegada++;
            }

            foreach (var aeroporto in aeroportos) // exibindo informação de voo e aeroporto
            {
                Console.WriteLine($"\nAeroporto: {aeroporto.Nome}");
                Console.WriteLine($"\nVoos de saída: {aeroporto.VoosSaida}");
                Console.WriteLine($"Voos de chegada: {aeroporto.VoosChegada}");
                Console.WriteLine("\nVoos que saem deste aeroporto");

                foreach (var voo in voos)
                {
                    if (voo.Origem == aeroporto.Codigo)
                    {
                        Console.WriteLine($" -> Para: {aeroportos[voo.Destino].Nome}");
                    }
                }

                Console.WriteLine("\nVoos que chegam a este aeroporto");

                foreach (var voo in voos)
                {
                    if (voo.Destino == aeroporto.Codigo)
                    {
                        Console.WriteLine($" <- De: {aeroportos[voo.Origem].Nome}");
                    }
                }

                Console.WriteLine(); // pula linha
                Console.WriteLine("========================================================"); 
                // tava uma bagunça coloquei isso para separar os voos
            }
        }
    }
}
