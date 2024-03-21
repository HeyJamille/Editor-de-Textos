using System;
using System.Diagnostics.CodeAnalysis;
using System.IO; // Para usar o using para abrir e editar arquivo

namespace Editor_texto
{
  class Program
  {
    public static void Main(String[] args)
    {
      Menu();
    }

    // Menu
    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1 - Abrir arquivo \n" +
                        "2 - Criar novo arquivo \n" +
                        "0 - Sair");

      Console.Write("Opção: ");
      int opcao = int.Parse(Console.ReadLine()!);

      switch (opcao)
      {
        case 0:
          System.Environment.Exit(0);
          break;
        case 1:
          Abrir();
          break;
        case 2:
          Editar();
          break;
        default:
          Menu();
          break;
      }
    }

    // Método Abrir
    static void Abrir()
    {
      Console.Clear();

      Console.WriteLine("Qual caminho do arquivo?");
      string path = Console.ReadLine();
      Console.WriteLine("-------------------------------------- \n");

      if (File.Exists(path))
      {
        using (var file = new StreamReader(path))
        {
          string texto = file.ReadToEnd();
          Console.WriteLine(texto);
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
      }
      else
      {
        Console.WriteLine("O arquivo digitado não existe. Por favor, escreva um arquivo existente. \n");

        Thread.Sleep(3000); // Dorme por 4 segundo
        Abrir();
      }

    }

    // Método Editar
    static void Editar()
    {
      Console.Clear();

      Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
      Console.WriteLine("--------------------------------------");
      string texto = "";

      // Enquanto o usuário não apertar o ESC, ele não sai do sistema
      do
      {
        texto += Console.ReadLine();
        texto += Environment.NewLine; // Quebra a linha após cada leitura
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      // Chama a função Salvar e passa o texto para ela
      Salvar(texto);
    }

    // Método Salvar
    static void Salvar(string texto)
    {
      Console.Clear();

      Console.WriteLine("Qual o caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      // Cria o arquivo
      using (var file = new StreamWriter(path)!)
      {
        file.Write(texto); // Escreve e armazena na variavel texto
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso");
      Console.ReadLine();

      Menu();
    }
  }
}

