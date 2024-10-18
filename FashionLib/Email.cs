using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace FashionLib
{
    public class Email
    {
        // Declaração das Variáveis
        public int Id { get; set; }
        public string E_mail { get; set; }

        // Métodos Construtores

        // Método com Tudo
        public Email(int id, string email)
        {
            Id = id;
            E_mail = email;
        }

        // Método sem Id
        public Email(string email)
        {
            E_mail = email;
        }

        // Método Vazio
        public Email()
        {
            Id = Id;
        }

        // Funções

        // Funções Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_emails_insert";
            cmd.Parameters.AddWithValue("sp_email",E_mail);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
        }
        
        // Função Obter Por Id
        public static Email ObterPorId (int Id)
        {
            Email email = new Email();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from emails where id = {Id}";
            cmd.Connection.Close();
            return email;
        }

        // Função Listar
        public static List<Email> ObterPorLista(string? e_mail = "")
        {
            List<Email> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            if(e_mail == "")
            {
                cmd.CommandText = "select * from emails order by email";
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
            cmd.CommandText = "sp_emails_update";
            cmd.Parameters.AddWithValue("sp_email", E_mail);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
