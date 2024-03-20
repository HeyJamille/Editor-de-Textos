using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

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
          Abrir_Arquivo();
          break;
        case 2:
          Editar_Arquivo();
          break;
        default:
          Menu();
          break;
      }
    }

    // Método Abrir_Arquivo
    static void Abrir_Arquivo()
    {
      Console.Clear();

      Console.WriteLine("Qual caminho do arquivo?");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path)) ;
      {
        string texto = file.ReadToEnd();
        Console.WriteLine(texto);
      }

      Console.WriteLine("");
      Console.ReadLine();

      Menu();

    }

    // Método Editar_Arquivo
    static void Editar_Arquivo()
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

    // Método Editar_Arquivo
    static void Salvar(string texto)
    {
      Console.Clear();

      Console.WriteLine("Qual o caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      // Cria o arquivo
      using (var file = new StreamWriter(path))
      {
        file.Write(texto); // Escreve e armazena na variavel texto
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso");
      Console.ReadLine();

      Menu();
    }
  }
}

