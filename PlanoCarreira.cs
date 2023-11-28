using System;
using System.Collections.Generic;


public class PlanoCarreira : Funcionario
{
  public float tempo_de_empresa { get; protected set; }
  private bool avaliacao_gerente = true;
  private Funcionario funcionario;


  public PlanoCarreira(Funcionario funcionario) : base(funcionario.nome, funcionario.cargo, funcionario.salario, funcionario.data_entrada)
  {
    this.tempo_de_empresa = funcionario.CalcularDiasNaEmpresa() / 30;
    this.funcionario = funcionario;
  }

  public override string ToString()
  {
    return base.ToString() + $"\nTempo de empresa em MESES: {tempo_de_empresa}";
  }




  // Método pra verificar se está apto a subir de cargo:
  public void SubirCargo()
  {
    Console.WriteLine("\nPassou na avaliação do gerente? [S]/[N]:  ");
    avaliacao_gerente = (char.ToUpper(Console.ReadLine()![0]) == 'N') ? false : avaliacao_gerente;

    if (tempo_de_empresa >= 8 && avaliacao_gerente)
    {
      Console.WriteLine("==================================================");
      Console.WriteLine("\n[✓]  Avaliação do Gerente\n[✓]  Tempo de empresa maior que 8 meses");
      Console.WriteLine("\n>> APROVADO, apto a subir de cargo.\n");
      Console.WriteLine("==================================================");

    }

    else if (tempo_de_empresa < 8 && avaliacao_gerente)
    {
      Console.WriteLine("==================================================");
      Console.WriteLine("\n[✓]  Avaliação do Gerente\n[x]  Tempo de empresa maior que 8 meses");
      Console.WriteLine("\n>> REPROVADO, aprovado pela vistoria do gerente, porém sem tempo suficiente de empresa.\n");
      Console.WriteLine("==================================================");

    }
    else if (tempo_de_empresa > 8 && avaliacao_gerente == false)
    {
      Console.WriteLine("==================================================");
      Console.WriteLine("\n[x]  Avaliação do Gerente\n[✓]  Tempo de empresa maior que 8 meses");
      Console.WriteLine("\n>> REPROVADO, possui tempo de empresa porém não passou pela vistoria do gerente.\n");
      Console.WriteLine("==================================================");
    }
    else
    {
      Console.WriteLine("=====================================================");
      Console.WriteLine("\n[x]  Avaliação do Gerente\n[x]  Tempo de empresa maior que 8 meses");
      Console.WriteLine("\n>> REPROVADO, não está apto a subir de cargo.\n");
      Console.WriteLine("=====================================================");
    }
  }





}