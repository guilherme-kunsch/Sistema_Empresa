using System;
using System.Collections.Generic;

class Filiais
{
  public int codigo_filial { get; protected set; }
  public string cnpj { get; protected set; }
  public string nome { get; protected set; }
  public string estado { get; protected set; }
  public int quantidade_funcionarios { get; protected set; }
  private List<Filiais> filiais;

  // Construtor
  public Filiais(int codigo_filial, string cnpj, string nome, string estado, int quantidade_funcionarios)
  {
    this.codigo_filial = codigo_filial;
    this.cnpj = cnpj;
    this.estado = estado.ToUpper();
    this.quantidade_funcionarios = quantidade_funcionarios;
    this.nome = nome.ToUpper();
    filiais = new List<Filiais>();
  }

  //Construtor sem parametro 
  public Filiais()
  {
    codigo_filial = 0;
    cnpj = "0";
    nome = "sem nome";
    estado = "vazio";
    quantidade_funcionarios = 0;
    filiais = new List<Filiais>();
  }

  public void CadastrarFilial(Filiais x)
  {
    filiais.Add(x);
  }
}
