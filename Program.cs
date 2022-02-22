namespace mega_sena
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Bem vindo ao sorteador de números para Mega Sena!\nVamos começar?\n");

      bool loop = true;
      while(loop)// loop enquanto "loop" for true
      {
        Console.Write("Digite seu nome: ['sair' para sair]_> ");
        string? nome = Console.ReadLine();
        if (string.IsNullOrEmpty(nome))
        {
          Console.WriteLine("\b\b\tNome não pode ser vazio\n");
          continue;
        }

        if (nome == "sair")
        {
          Console.WriteLine("\n\tSaindo do programa...");
          loop = false;
          continue;
        }

        Console.Write("Quantos jogos vc quer? [numeros] _> ");
        string? jogos = Console.ReadLine();
        Console.WriteLine(jogos?.ToInt());
        if (string.IsNullOrEmpty(jogos) || jogos.ToInt(-1) == -1 || jogos.ToInt() == 0)
        {
          Console.WriteLine("\b\n\tNúmero de jogos não pode ser vazio, e deve ser número maior que zero.\n");
          continue;
        }
        // fail safe

        // nome ou sobrenome
        string _name = nome;
        string[] _split = nome.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        if (_split.Length > 0)
          _name = $"Sr(a) {_split[_split.Length-1]}";
        Console.WriteLine($"{_name}, seus números da sorte de hoje são:");

        // quantidade de jogos
        int _jogos = jogos.ToInt();

        // jogos
        for (int i = 0; i < _jogos; i++)
        {
          // números aleatórios
          Random rand = new Random();
          // lista de números nesta jogada
          int[] numeros = new int[6];
          for (int j = 0; j < 6; j++)
          {
            // número aleatório entre 0 e 60, que não já esteje sorteado
            int n = rand.Next(0,60);
            if (!numeros.Contains(n))// verifica se o número já existe na lista de sorteio
            {
              numeros[j] = n;// adiciona o número a lista
            }
            else
            {
              j--;// refaz o sorteio se o número já tiver sido escolhido
            }
          }

          Console.WriteLine("\t"+ $"Jogada {i+1}: {string.Join('-', numeros)}");
        }

        Console.Write("\n\nDeseja continuar? [s/n] _> ");
        string? continuar = Console.ReadLine();
        switch(continuar)
        {
          case "n":
          case "N":
            loop = false;
            break;
        }
      }

      Console.WriteLine("\n\nAgradeço a participação.\n\tTenha um ótimo dia!");
    }

    static int ToInt(this string value, int defValue = 0)
    {
      try
      {
        return Convert.ToInt32(value);
      }
      catch {
        return defValue;
      }
    }
  }
}