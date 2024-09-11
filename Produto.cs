class Produto
{
    public string Nome;
    public int Quantidade;
    public double Preco;

    // Construtor da classe Produto
    public Produto(string nome, int quantidade, double preco)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }

    // Método para adicionar estoque
    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            Quantidade += quantidade;
            ExibirMensagem("Adicionado " + quantidade + " unidades. Estoque atual: " + Quantidade);
        }
        else
        {
            ExibirMensagem("Quantidade inválida! A quantidade deve ser maior que 0.");
        }
    }

    // Método para remover estoque
    public void RemoverEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            if (Quantidade >= quantidade)
            {
                Quantidade -= quantidade;
                ExibirMensagem("Removido " + quantidade + " unidades. Estoque atual: " + Quantidade);
            }
            else
            {
                ExibirMensagem("Erro! A quantidade a ser removida é maior do que a disponível em estoque.");
            }
        }
        else
        {
            ExibirMensagem("Quantidade inválida! A quantidade deve ser maior que 0.");
        }
    }

    // Método para calcular o valor total do estoque
    public double CalcularValorEstoque()
    {
        return Quantidade * Preco;
    }

    // Método para exibir os detalhes do produto
    public void ExibirDetalhes()
    {
        ExibirMensagem("Detalhes do produto:");
        ExibirMensagem("Nome: " + Nome);
        ExibirMensagem("Quantidade em estoque: " + Quantidade);
        ExibirMensagem("Preço unitário: " + Preco);
        ExibirMensagem("Valor total em estoque: " + CalcularValorEstoque());
    }

    // Método para exibir uma mensagem (agora sem modificador de acesso)
    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
}
