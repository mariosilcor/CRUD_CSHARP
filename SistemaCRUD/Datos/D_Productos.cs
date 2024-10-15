using SistemaCRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCRUD.Datos
{
    //Definición de Clase.
    public class D_Productos
    {
        //Definición de Método.
        public DataTable Listado_pr(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Proceso de Comunicación desde C# para llevarnos a SQL Server
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Proceso de Cerrar la Conexión de SQL Server.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Definición de Método para Guardar los Productos.
        public string Guardar_pr(int nOpcion,
                                 E_Productos oPro)
        {
            //Definición de Variables.
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GUARDAR_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = oPro.Codigo_pr;
                Comando.Parameters.Add("@cDescripcion_pr", SqlDbType.VarChar).Value = oPro.Descripcion_pr;
                Comando.Parameters.Add("@cMarca_pr", SqlDbType.VarChar).Value = oPro.Marca_pr;
                Comando.Parameters.Add("@nCodigo_me", SqlDbType.Int).Value = oPro.Codigo_me;
                Comando.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = oPro.Codigo_ca;
                Comando.Parameters.Add("@nStock_actual", SqlDbType.Decimal).Value = oPro.Stock_actual;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "NO SE PUDIERON REGISTRAR LOS DATOS";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                //Proceso de Cerrar la Conexión de SQL Server.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        //Definición de Método para Activar y Desactivar los Productos.
        public string Activo_pr(int nCodigo_pr,
                                bool bEstado_activo)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ACTIVO_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = nCodigo_pr;
                Comando.Parameters.Add("@bEstado_pr", SqlDbType.Bit).Value = bEstado_activo;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "NO SE PUDO CAMBIAR EL ESTADO ACTIVO DEL PRODUCTO";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                //Proceso de Cerrar la Conexión de SQL Server.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        //Definición de Método.
        public DataTable Listado_me()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Proceso de Comunicación desde C# para llevarnos a SQL Server
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_ME", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Proceso de Cerrar la Conexión de SQL Server.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Definición de Método.
        public DataTable Listado_ca()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Proceso de Comunicación desde C# para llevarnos a SQL Server
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_CA", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Proceso de Cerrar la Conexión de SQL Server.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
