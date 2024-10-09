using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionLib
{
    public class Agendamentos
    {//Declaração das Variaveis
        

        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Funcionario { get; set; }
        public DateTime Data_Agendamento { get; set; }

        //Métodos Construtores

        //Método Com Tudo
        public Agendamentos(int id, int id_Cliente, int id_Funcionario, DateTime data_Agendamento)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
            Data_Agendamento = data_Agendamento;
        }

        //Método sem Id
        public Agendamentos( int id_Cliente, int id_Funcionario, DateTime data_Agendamento)
        {

            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
            Data_Agendamento = data_Agendamento;
        }

        //Método sem Id e Data_Agendamento
        public Agendamentos( int id_Cliente, int id_Funcionario)
        {
            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
        }

        //Método Com Id e Sem Data_Agendamento
        public Agendamentos(int id, int id_Cliente, int id_Funcionario)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
        }

        //Funções

        //Função Para Inserir
        public void
    }
}
