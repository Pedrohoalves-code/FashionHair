using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FashionLib
{
    public class Agendamentos
    {//Declaração das Variaveis


        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Funcionario { get; set; }
        public DateTime Data_Agendamento { get; set; }
        public DateTime Hora_Agendamento { get; set; }

        //Métodos Construtores

        //Método Com Tudo
        public Agendamentos(int id, int id_Cliente, int id_Funcionario, DateTime data_Agendamento, DateTime hora_agendamento)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
            Data_Agendamento = data_Agendamento;
            Hora_Agendamento = hora_agendamento;
        }

        //Método sem Nada
        public Agendamentos()
        {
            Id = new();
        }

        //Método sem Id
        public Agendamentos(int id_Cliente, int id_Funcionario, DateTime data_Agendamento)
        {

            Id_Cliente = id_Cliente;
            Id_Funcionario = id_Funcionario;
            Data_Agendamento = data_Agendamento;
        }

        //Método sem Id e Data_Agendamento
        public Agendamentos(int id_Cliente, int id_Funcionario)
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
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"sp_agendamento_insert";
            cmd.Parameters.AddWithValue("spid_cliente",Id_Cliente);
            cmd.Parameters.AddWithValue("spid_funcionario", Id_Funcionario);
            cmd.Parameters.AddWithValue("spdia",Data_Agendamento);
            cmd.Parameters.AddWithValue("sphora", Hora_Agendamento);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        //Função para Atualizar
        public void Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "sp_agendamento_update";
            cmd.Parameters.AddWithValue("spid_cliente", Id_Cliente);
            cmd.Parameters.AddWithValue("spid_funcionario", Id_Funcionario);
            cmd.Parameters.AddWithValue("spdia", Data_Agendamento);
            cmd.Parameters.AddWithValue("sphora", Hora_Agendamento);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Função Listar
        public static List<Agendamentos> ObterPorLista(string? nome = "")
        {
            List<Agendamentos> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            if (nome == "")
            {
                cmd.CommandText = "Select * from agendamentos";
            }
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new(
                 dr.GetInt32(0),
                 dr.GetInt32(1),
                 dr.GetInt32(2),
                 dr.GetDateTime(3),
                 dr.GetDateTime(4)
                    ));
            }
            cmd.Connection.Close();
            return lista;
        }

        //Função Onter Por Id
        public static Agendamentos ObterPorId(int Id)
        {
            Agendamentos agendamentos = new Agendamentos();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"Select * from agendamentos where id = {Id}";
            cmd.Connection.Close();
            return agendamentos;
        }
    }
}
