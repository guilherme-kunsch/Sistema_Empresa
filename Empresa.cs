using System;
using System.IO;
using System.Collections.Generic;

class Empresa
{
  private string nome;
  private DateTime data_criacao;
  private int identificacao;

  private List<Funcionario> lista_funcionarios;



  // Construtures da classe empresa, para depois gerenciarmos a empresa especifica:
  public Empresa()
  {
    nome = "Vazio";
    data_criacao = new DateTime();
    identificacao = 0;
    lista_funcionarios = new List<Funcionario>();

  }

  public Empresa(string nome, DateTime data_criacao, int identificacao)
  {
    this.nome = nome;
    this.data_criacao = data_criacao;
    this.identificacao = identificacao;
  }




  // Metodo acessar a lista de funcionarios cadastrados:
  public List<Funcionario> getListaFuncionarios()
  {
    return lista_funcionarios;
  }

  public Funcionario GetFuncionario(int index)
  {
    return lista_funcionarios[index];
  }


  // Metodo para cadastrar funcionario na empresa:
  public void CadastrarFuncionario(Funcionario x)
  {

    if (lista_funcionarios == null)
    {
      lista_funcionarios = new List<Funcionario>();
    }
    lista_funcionarios.Add(x);
  }



  // Metodo para exibir a lista de funcionarios cadastrados com todos os dados completos:
  public void ExibirDadosCompletosFuncionarios()
  {
    Console.WriteLine("==================================================");
    Console.WriteLine("-------------FUNCIONÁRIOS CADASTRADOS-------------");
    Console.WriteLine("==================================================\n\n");

    for (int i = 0; i < lista_funcionarios.Count; i++)
    {
      Funcionario f = lista_funcionarios[i];
      Console.WriteLine($"Funcionário {i + 1}: {f.nome} \nCargo: {f.cargo}\nData de entrada: {f.data_entrada}\nMeses na empresa: {f.CalcularDiasNaEmpresa() / 30}\nAnos na empresa:{(f.CalcularDiasNaEmpresa() / 30) / 12}\n");
    }

  }

  // Metodo para exibir funcionarios cadastrados e enumerados para escolha do plano de carreira:
  public void ExibirFuncionarios()
  {
    Console.WriteLine("==================================================");
    Console.WriteLine("-------------FUNCIONÁRIOS CADASTRADOS-------------");
    Console.WriteLine("==================================================\n\n");

    for (int i = 0; i < lista_funcionarios.Count; i++)
    {
      Funcionario f = lista_funcionarios[i];
      Console.WriteLine($"Funcionário {i + 1}: {f.nome}");
    }

  }

}