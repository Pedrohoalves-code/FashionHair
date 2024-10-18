using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace FashionLib
{
    public class Cargo
    {
        // Declaração das Variáveis
        public int Id { get; set; }
        public string Cargos { get; set; }

        // Métodos Construtores

        // Método com Tudo
        public Cargo(int id, string cargos)
        {
            Id = id;
            Cargos = cargos;
        }

        // Métodos sem Id
        public Cargo(string cargos)
        {
            Cargos = cargos;
        }

        // Métodos Vazio
        public Cargo()
        {
            Id = new();
        }

        // Funções

        // Funções Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cargos_insert";
            cmd.Parameters.AddWithValue("sp_cargos", Cargos);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
        }

        // Função Obter Por Id
        public static Cargo ObterPorId(int Id)
        {
            Cargo cargo = new Cargo();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from cargos where id = {Id}";
            cmd.Connection.Close();
            return cargo;
        }

        // Função Listar
        public static List<Cargo> ObterPorLista(string? cargos = "")
        {
            List<Cargo> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            if (cargos == "")
            {
                cmd.CommandText = "select * from cargos order by cargo";
            }
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1)
                    ));
            }
            cmd.Connection.Close();
            return lista;
        }

        // Função Atualizar
        public void Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_cargos_update";
            cmd.Parameters.AddWithValue("sp_cargos", Cargos);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
