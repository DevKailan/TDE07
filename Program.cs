using System;

class Program
{
    static void Main()
    {
        Program program = new Program();
        program.Iniciar();
    }

    Produto produto1 = null;
    bool sair = false;

    public void Iniciar()
    {
        while (!sair)
        {
            Console.WriteLine("\nDigite uma opção:");
            Console.WriteLine("1. Definir os dados");
            Console.WriteLine("2. Adicionar ao estoque");
            Console.WriteLine("3. Remover do estoque");
            Console.WriteLine("4. Exibir detalhes do produto");
            Console.WriteLine("5. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    produto1 = DefinirProduto();
                    break;
                case "2":
                    if (produto1 == null)
                    {
                        Console.WriteLine("Primeiro defina os dados do produto.");
                    }
                    else
                    {
                        Console.WriteLine("Digite um valor para adicionar ao estoque:");
                        int quantidadeAdicionar = LerNumeroInteiro();
                        produto1.AdicionarEstoque(quantidadeAdicionar);
                    }
                    break;
                case "3":
                    if (produto1 == null)
                    {
                        Console.WriteLine("Primeiro defina os dados do produto.");
                    }
                    else
                    {
                        Console.WriteLine("Digite um valor para remover a quantidade do estoque:");
                        int quantidadeRemover = LerNumeroInteiro();
                        produto1.RemoverEstoque(quantidadeRemover);
                    }
                    break;
                case "4":
                    if (produto1 == null)
                    {
                        Console.WriteLine("Primeiro defina os dados do produto.");
                    }
                    else
                    {
                        produto1.ExibirDetalhes();
                    }
                    break;
                case "5":
                    sair = true;
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    Produto DefinirProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine() ?? ""; // Previne valores nulos

        Console.WriteLine("Digite a quantidade inicial:");
        int quantidade = LerNumeroInteiro();

        Console.WriteLine("Digite o preço unitário:");
        double preco = LerNumeroDecimal();

        return new Produto(nome, quantidade, preco);
    }

    int LerNumeroInteiro()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            int numero;
            if (ValidarInteiro(entrada, out numero))
            {
                return numero;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número inteiro.");
            }
        }
    }

    bool ValidarInteiro(string entrada, out int numero)
    {
        numero = 0;
        if (string.IsNullOrEmpty(entrada))
        {
            return false;
        }

        for (int i = 0; i < entrada.Length; i++)
        {
            if (entrada[i] < '0' || entrada[i] > '9')
            {
                return false;
            }
        }

        for (int i = 0; i < entrada.Length; i++)
        {
            numero = numero * 10 + (entrada[i] - '0');
        }

        return true;
    }

    double LerNumeroDecimal()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            double numero;
            if (ValidarDecimal(entrada, out numero))
            {
                return numero;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número decimal.");
            }
        }
    }

    bool ValidarDecimal(string entrada, out double numero)
    {
        numero = 0;
        if (string.IsNullOrEmpty(entrada))
        {
            return false;
        }

        int ponto = -1;
        for (int i = 0; i < entrada.Length; i++)
        {
            if (entrada[i] == '.')
            {
                if (ponto != -1)
                {
                    return false;
                }
                ponto = i;
            }
            else if (entrada[i] < '0' || entrada[i] > '9')
            {
                return false;
            }
        }

        int parteInteira = 0;
        double parteDecimal = 0;
        if (ponto == -1)
        {
            parteInteira = LerParteInteira(entrada);
        }
        else
        {
            parteInteira = LerParteInteira(entrada.Substring(0, ponto));
            parteDecimal = LerParteDecimal(entrada.Substring(ponto + 1));
        }

        numero = parteInteira + parteDecimal;
        return true;
    }

    int LerParteInteira(string parte)
    {
        int resultado = 0;
        for (int i = 0; i < parte.Length; i++)
        {
            resultado = resultado * 10 + (parte[i] - '0');
        }
        return resultado;
    }

    double LerParteDecimal(string parte)
    {
        double resultado = 0;
        double divisor = 1;
        for (int i = 0; i < parte.Length; i++)
        {
            divisor *= 10;
            resultado = resultado + (parte[i] - '0') / divisor;
        }
        return resultado;
    }
}
