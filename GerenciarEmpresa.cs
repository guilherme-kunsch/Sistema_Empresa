using System;

using System.IO;
using System.Text;

class GerenciarEmpresa
{
  Empresa nova_empresa;

  private bool continueRunning = true;

  public bool CarregarDadosFuncionarios(string funcionarios_dados)
  {
    string[] linhas = File.ReadAllLines(funcionarios_dados);

    foreach (string linha in linhas)
    {
      string[] dados = linha.Split(";");
      string nome = dados[0];
      string cargo = dados[1];
      int salario = int.Parse(dados[2]);

      DateTime data_de_entrada = DateTime.Parse(dados[3]);

      Funcionario novo_funcionario = new(nome, cargo, salario, data_de_entrada);
      nova_empresa.CadastrarFuncionario(novo_funcionario);

    }

    return true;

  }

  public bool GravarDadosFuncionarios(string funcionarios_dados)
  {
    using (StreamWriter writer = new StreamWriter(funcionarios_dados))
    {
      foreach (Funcionario f in nova_empresa.getListaFuncionarios())
      {
        string linha = string.Format("{0};{1};{2};{3}", f.nome, f.cargo, f.salario, f.data_entrada);
        writer.WriteLine(linha);
      }

    }

    return true;
  }


  public GerenciarEmpresa()
  {
    nova_empresa = new Empresa("ENTERPRISE OTAKU", new DateTime(2000, 01, 01)
, 0);
  }

  public void Menu()
  {

    string option = "";
    do
    {
      limpaConsoleExibeLogo();
      System.Console.WriteLine("Selecione uma opção abaixo:");
      System.Console.WriteLine("[0] - Sair");
      System.Console.WriteLine("[1] - Cadastrar filial");
      System.Console.WriteLine("[2] - Cadastrar colaborador");
      System.Console.WriteLine("[3] - Plano de carreira");
      System.Console.WriteLine("[4] - Relatórios");
      System.Console.WriteLine("[5] - Gravar Funcionarios Cadastrados Até o Momento");
      System.Console.Write("Digite sua opção: ");
      option = Console.ReadLine();

      switch (option)
      {
        case "0":
          System.Console.WriteLine("Programa encerrado");
          continueRunning = false;
          break;

        case "1":
          limpaConsoleExibeLogo();
          Console.WriteLine("Digite o código da filial: ");
          int codigo_filial = Convert.ToInt32(Console.ReadLine());
          Console.Write("Digite o CNPJ: ");
          string cnpj = Console.ReadLine();
          Console.Write("Digite o nome da filial: ");
          string nome_filial = Console.ReadLine();
          Console.Write("Digite o endereço da filial: ");
          string estado = Console.ReadLine();
          Console.Write("Digite a quantidade de funcionários: ");
          int qtd_funcionario = Convert.ToInt32(Console.ReadLine());

          Filiais nova_filial = new(codigo_filial, cnpj, nome_filial, estado, qtd_funcionario);

          nova_filial.CadastrarFilial(nova_filial);

          Console.Write("Filial cadastrada com sucesso!!");

          break;

        case "2":
          limpaConsoleExibeLogo();
          System.Console.Write("Nome: ");
          string nome_funcionario = Console.ReadLine();
          System.Console.Write("Cargo: ");
          string cargo = Console.ReadLine();
          System.Console.Write("Salário: ");
          float salario = float.Parse(Console.ReadLine());

          Console.WriteLine("Data de entrada: ");
          Console.Write("Dia: ");
          int dia = int.Parse(Console.ReadLine());
          Console.Write("Mês: ");
          int mes = int.Parse(Console.ReadLine());
          Console.Write("Ano: ");
          int ano = int.Parse(Console.ReadLine());


          nova_empresa.CadastrarFuncionario(new Funcionario(nome_funcionario, cargo, salario, new DateTime(ano, mes, dia)));


          Console.WriteLine("\nFuncionário cadastrado com sucesso!\n\n");
          Console.WriteLine("Pressione qualquer tecla para retornar ao menu inicial");
          Console.ReadKey();

          break;

        case "3":
          limpaConsoleExibeLogo();
          nova_empresa.ExibirFuncionarios();
          Console.Write("Digite o número referente ao funcionário para visualizar seu plano de carreira: ");
          int resposta = int.Parse(Console.ReadLine()!);

          Funcionario funcionario_plano_carreira = nova_empresa.GetFuncionario(resposta - 1);

          PlanoCarreira novo_plano = new(funcionario_plano_carreira);

          Console.WriteLine($"Nome: {funcionario_plano_carreira.nome}\nCargo: {funcionario_plano_carreira.cargo}\nSalario: {funcionario_plano_carreira.salario}\nTempo de empresa em DIAS: {funcionario_plano_carreira.CalcularDiasNaEmpresa()}\nTempo de empresa em MESES: {novo_plano.tempo_de_empresa}\n");

          novo_plano.SubirCargo();

          Console.ReadKey();


          break;

        case "4":
          do
          {
            limpaConsoleExibeLogo();
            System.Console.WriteLine("[1] - Relatório de funcionários");
            System.Console.WriteLine("[2] - Relatório de pagamentos");
            System.Console.WriteLine("[3] - Voltar ao menu principal");
            System.Console.Write("Digite sua opção: ");
            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
              case 1:
                limpaConsoleExibeLogo();
                nova_empresa.ExibirDadosCompletosFuncionarios();

                Console.ReadKey();
                break;

              case 2:
                System.Console.WriteLine("Relatório de filiais/funcionários aqui");
                break;

              case 3:
                System.Console.WriteLine("Relatório de pagamentos aqui");
                break;

              case 4:
                break;

              default:
                System.Console.WriteLine("Opção inválida");
                break;
            }
          } while (option != "4");
          break;

        case "5":
          GravarDadosFuncionarios("banco_de_dados/FuncionariosCadastrados");
          Console.WriteLine("\nDados gravados com sucesso! Pressione qualquer teclar continuar.");
          Console.ReadKey();

          break;

        default:
          System.Console.WriteLine("Opção inválida");
          break;
      }

    } while (continueRunning);
  }

  private void limpaConsoleExibeLogo()
  {
    Console.Clear();
    Logo();
  }

  private void Logo()
  {
    Console.WriteLine(@"
█████████████████████████████████████████████████████████████████████████████████████████████
█▄─▄▄─█▄─▀█▄─▄█─▄─▄─█▄─▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄▀█▄─▄█─▄▄▄▄█▄─▄▄─███─▄▄─█─▄─▄─██▀▄─██▄─█─▄█▄─██─▄█
██─▄█▀██─█▄▀─████─████─▄█▀██─▄─▄██─▄▄▄██─▄─▄██─██▄▄▄▄─██─▄█▀███─██─███─████─▀─███─▄▀███─██─██
▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▀▀▄▄▄▄▀▀");
  }

  public static void Main(string[] args)
  {
    GerenciarEmpresa meu_gerenciador = new GerenciarEmpresa();

    ///Metodo pra carregar dados existentes no banco de dados:
    meu_gerenciador.CarregarDadosFuncionarios("banco_de_dados/FuncionariosCadastrados.txt");
    meu_gerenciador.Menu();
  }
}
