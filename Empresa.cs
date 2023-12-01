using System;
using System.IO;
using System.Collections.Generic;

class Empresa
{
  public string nome { get; protected set; }
  public DateTime data_criacao { get; protected set; }
  public int identificacao { get; protected set; }
  public string cpnj_matriz;

  public List<Funcionario> lista_funcionarios;
  public List<Filial> lista_filiais;




  // Construtures da classe empresa, para depois gerenciarmos a empresa especifica:
  public Empresa()
  {
    nome = "Vazio";
    data_criacao = new DateTime();
    identificacao = 0;
    lista_funcionarios = new List<Funcionario>();
    lista_filiais = new List<Filial>();

  }

  public Empresa(string nome, DateTime data_criacao, int identificacao, string cnpj_matriz)
  {
    this.nome = nome.ToUpper();
    this.data_criacao = data_criacao;
    this.identificacao = identificacao;
    this.cpnj_matriz = cnpj_matriz;
  }




  // Metodo acessar a lista de funcionarios cadastrados:
  public List<Funcionario> getListaFuncionarios()
  {
    return lista_funcionarios;
  }

  // Metodo acessar a lista de filiais cadastrados:
  public List<Filial> getListaFiliais()
  {
    return lista_filiais;
  }


  // Metodo para acessar um funcionario na lista pelo seu index:
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

    Filial filialAssociada = lista_filiais.Find(filial => filial.identificacao == x.codigo_filial);

    if (filialAssociada != null)
    {
      filialAssociada.lista_funcionarios.Add(x);
    }

  }

  // Metodo para cadastrar filiais na empresa:
  public void CadastrarFilial(Filial f)
  {
    if (lista_filiais == null)
    {
      lista_filiais = new List<Filial>();
    }

    lista_filiais.Add(f);
  }



  // Metodo para exibir a lista de funcionarios cadastrados com todos os dados completos:
  public void ExibirDadosCompletosFuncionarios()
  {
    for (int i = 0; i < lista_funcionarios.Count; i++)
    {
      Funcionario f = lista_funcionarios[i];

      Console.WriteLine($"Funcionário {i + 1}\nNome:{f.nome}\nCargo: {f.cargo}\nData de entrada: {f.data_entrada}\nMeses na empresa: {f.CalcularDiasNaEmpresa() / 30}\nAnos na empresa:{(f.CalcularDiasNaEmpresa() / 30) / 12}\n");
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

  // Metodo para exibir a lista de filiais cadastrados com todos os dados:
  public void ExibirDadosFiliais()
  {
    // Console.WriteLine("==================================================");
    // Console.WriteLine("-------------FILIAIS CADASTRADAS-------------");
    // Console.WriteLine("==================================================\n\n");

    for (int i = 0; i < lista_filiais.Count; i++)
    {
      Filial f = lista_filiais[i];
      Console.WriteLine($"Nome: {f.nome}\nCÓDIGO: {f.identificacao}\nData criação: {f.data_criacao}\nCNPJ: {f.cnpj}\nEstado: {f.filial_estado}\nQuantidade de Funcionários: {f.quantidade_funcionarios}\n");
    }

  }

  public void ExibirCodigoFiliais()
  {
    Console.WriteLine("==================================================");
    Console.WriteLine("-------------FILIAIS CADASTRADAS-------------");
    Console.WriteLine("==================================================\n\n");

    for (int i = 0; i < lista_filiais.Count; i++)
    {
      Filial f = lista_filiais[i];
      Console.WriteLine($"CÓDIGO {f.identificacao}: {f.nome} \n");
    }

  }

  public void CodigoFilial(int codigo, Funcionario f)
  {
    if (lista_filiais == null)
    {
      lista_filiais = new List<Filial>();
    }

    for (int i = 0; i < lista_filiais.Count; i++)
    {
      if (lista_filiais[i].identificacao == f.codigo_filial)
      {
        lista_filiais[i].quantidade_funcionarios++;
      }
    }
  }





  public void ExibirFuncionariosPorFilial(Empresa x)
  {
    foreach (Filial filial in x.getListaFiliais())
    {
      Console.WriteLine("==================================================");
      Console.WriteLine($"-------------FILIAL: {filial.nome.ToUpper()}-------------");
      Console.WriteLine("==================================================\n\n");
      filial.ExibirDadosCompletosFuncionarios();
      Console.WriteLine();
    }
  }
}