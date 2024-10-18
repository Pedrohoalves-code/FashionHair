using SysPecNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FashionLib
{
    internal class Procedimentos
    {
        

        public int Id {  get; set; }
        public int Id_procedimento_H {  get; set; }
        public int Id_procedimento_M {  get; set; }


        public Procedimentos()
        {          
        }

        public Procedimentos(int id, int id_procedimento_H, int id_procedimento_M)
        {
            Id = id;
            Id_procedimento_H = id_procedimento_H;
            Id_procedimento_M = id_procedimento_M;
        }

        public Procedimentos(int id,int id_procedimento_M)
        {
            Id = id;
            Id_procedimento_M = id_procedimento_M;
        }

        public Procedimentos( int id_procedimento_H)
        {          
            Id_procedimento_H = id_procedimento_H;            
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_procedimentos";
            cmd.Parameters.AddWithValue("sp_id_procedimentos_homens", Id_procedimento_H);
            cmd.Parameters.AddWithValue("sp_id_procedimentos_mulheres", Id_procedimento_M);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }      

    }

}
