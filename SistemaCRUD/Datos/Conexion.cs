using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCRUD.Datos
{
    //Definición de Clase.
    public class Conexion
    {
        //Definición de Variables.
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        //Definición de Método.
        private Conexion()
        {
            this.Base = "BD_CRUD_SQL";
            this.Servidor = "DESKTOP-P6CGJ57\\SQLEXPRESS";
            this.Usuario = "user_crud";
            this.Clave = "12345678";
        }

        //Definición de Método-Conexión a SQL Server.
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                        "; Database=" + this.Base +
                                        "; User Id=" + this.Usuario +
                                        "; Password=" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        //Definición de Método para garantizar una Sola Conexión a SQL Server
        public static Conexion getInstancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
