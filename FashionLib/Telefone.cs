using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FashionLib
{
    public class Telefone
    {

        public int Id { get; set; }
        public string? Telefones { get; set; }
        public string? Tipo { get; set; }

        public Telefone()
        {

        }

        public Telefone(int id, string? telefones)
        {
            Id = id;
            Telefones = telefones;
        }

        public Telefone(int id, string? telefones, string? tipo)
        {
            Id = id;
            Telefones = telefones;
            Tipo = tipo;

        }

        public void Inserir()
        {

            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_telefone_insert";
            cmd.Parameters.AddWithValue("sptelefone", Telefones);
            cmd.Parameters.AddWithValue("sptipo", Tipo);
        }

        public static Telefone ObterPorId(int id)
        {
            Telefone telefone = new ();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from telefones where id = {id}";
            var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                telefone = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2)
                    );
            }
            return telefone;

        }
        public void Atualizar(int id)
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_telefone_update";

            cmd.Parameters.AddWithValue("sptelefone", Telefones);
            cmd.Parameters.AddWithValue("sptipo", Tipo);
           
            //Quando uma procedure é executada, 0 nenhuma alteração, 1 alterado e -1 falha
            //return cmd.ExecuteNonQuery()>-1?true:false

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }




    }

}
