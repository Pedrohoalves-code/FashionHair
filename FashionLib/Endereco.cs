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
    public class Endereco
    {//Declaração das Variaveis
       

        public int Id {  get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set;}
        public string Cep {  get; set;}

        //Métodos Construtores

        //Método com Tudo
        public Endereco(int id, string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        //Método sem Id
        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        //Método Vazio
        public Endereco()
        {
            Id = new();
        }

        //Funções 

        //Função Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"sp_endereco_insert";
            cmd.Parameters.AddWithValue("splogradouro",Logradouro);
            cmd.Parameters.AddWithValue("spnumero",Numero);
            cmd.Parameters.AddWithValue("spbairro",Bairro);
            cmd.Parameters.AddWithValue("spcidade",Cidade);
            cmd.Parameters.AddWithValue("spestado",Estado);
            cmd.Parameters.AddWithValue("spcep",Cep);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        //Função Onter Por Id
        public static Endereco ObterPorId(int Id)
        {
            Endereco endereco = new Endereco();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"Select * from enderecos where id = {Id}";
            cmd.Connection.Close();
            return endereco;
        }

        //Função Listar
        public static List<Endereco> ObterPorLista(string? nome = "")
        {
            List<Endereco> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            if(nome == "")
            {
                cmd.CommandText = "Select * from enderecos order by estado";
            }
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetString(6)
                    ));
            }
            cmd.Connection.Close();
            return lista;

        }

        //Função Atualizar
        public void Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"sp_endereco_update";
            cmd.Parameters.AddWithValue("splogradouro", Logradouro);
            cmd.Parameters.AddWithValue("spnumero", Numero);
            cmd.Parameters.AddWithValue("spbairro", Bairro);
            cmd.Parameters.AddWithValue("spcidade", Cidade);
            cmd.Parameters.AddWithValue("spestado", Estado);
            cmd.Parameters.AddWithValue("spcep", Cep);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Função Deletar
        public void Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType= CommandType.Text;
            cmd.CommandText = $"Delete from enderecos where id = {Id}";
            cmd.Connection.Close();
        }
    }
}
