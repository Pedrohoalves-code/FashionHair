using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FashionLib
{
    internal class Funcionario // O nome da classe deve começar com letra maiúscula por convenção
    {
        // Declaração das Variáveis
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_Nasc { get; set; }
        public int? Ativo { get; set; }
        public int Id_Cargo { get; set; }
        public char Disponibilidade { get; set; }

        // Métodos Construtores

        // Método Com Tudo
        public Funcionario(int id, string nome, string rg, string cpf, DateTime data_Nasc, int? ativo, int id_Cargo, char disponibilidade)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Ativo = ativo;
            Id_Cargo = id_Cargo;
            Disponibilidade = disponibilidade;
        }

        // Método Sem Id
        public Funcionario(string nome, string rg, string cpf, DateTime data_Nasc, int ativo, int id_Cargo, char disponibilidade)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Ativo = ativo;
            Id_Cargo = id_Cargo;
            Disponibilidade = disponibilidade;
        }

        // Método Sem Id e Ativo
        public Funcionario(string nome, string rg, string cpf, DateTime data_Nasc, int id_Cargo, char disponibilidade)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Id_Cargo = id_Cargo;
            Disponibilidade = disponibilidade;
        }

        // Método com Id e Ativo e Sem Id_Cargo
        public Funcionario(int id, string nome, string rg, string cpf, DateTime data_Nasc, int ativo, char disponibilidade)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Ativo = ativo;
            Disponibilidade = disponibilidade;
        }

        // Método Vazio
        public Funcionario()
        {
            Id = new();
        }

        // Funções 

        // Função Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_funcionario_insert";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("sprg", Rg);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("spdata_nascimento", Data_Nasc);
            cmd.Parameters.AddWithValue("spativo", Ativo);
            cmd.Parameters.AddWithValue("spid_cargo", Id_Cargo);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // Função Atualizar
        public void Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_funcionario_update";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("sprg", Rg);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("spdata_nascimento", Data_Nasc);
            cmd.Parameters.AddWithValue("spativo", Ativo);
            cmd.Parameters.AddWithValue("spid_cargo", Id_Cargo);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        // Função para deixar o funcionário inativo
        public void DeixarInativo(int id)
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"update funcionarios set ativo = 0 where id = {id}";
            cmd.ExecuteNonQuery(); 
            cmd.Connection.Close();
        }

        // Função para ativar o funcionário novamente
        public void DeixarAtivo(int id)
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"update funcionarios set ativo = 1 where id = {id}";
            cmd.ExecuteNonQuery(); 
            cmd.Connection.Close();
        }
    }
}
