using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FashionLib
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateOnly Data_Nasc {  get; set; }
        public bool Ativo {  get; set; }

        //Método Construtor Vazio
        public Cliente()
        {
            Id = new();
        }

        //Método Construtor com Tudo
        public Cliente(int id, string nome, string cpf, DateOnly data_Nasc, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Ativo = ativo;
        }

        //Método Construtor Sem Id
        public Cliente(string nome, string cpf, DateOnly data_Nasc, bool ativo)
        {
           
            Nome = nome;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
            Ativo = ativo;
        }

        //Método Construtor sem Id e Ativo
        public Cliente( string nome, string cpf, DateOnly data_Nasc)
        {

            Nome = nome;
            Cpf = cpf;
            Data_Nasc = data_Nasc;
        }

        //Método Construtor sem Data_Nasc
        public Cliente(int id, string nome, string cpf, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Ativo = ativo;
        }

        //Função para Inserir Cliente
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_insert";
            cmd.Parameters.AddWithValue("spnome",Nome);
            cmd.Parameters.AddWithValue("spcpf",Cpf);
            cmd.Parameters.AddWithValue("spdata_nascimento",Data_Nasc);
            cmd.Parameters.AddWithValue("spativo",Ativo);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        //Função para Atulizar todos os Dados do Cliente
        public void Atualizar()
        {
            var cmd = Banco.Abrir();
        }
    }
}
