using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ContactosMavi.Clases
{
    public class Conexion
    {
        private SqlConnection conexion;
        public Conexion() 
        {
            string DBConn = ConfigurationManager.AppSettings["conexionBD"];
            conexion = new SqlConnection(DBConn);
        }

        public void Abrir()
        {
            if(conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Cerrar()
        {
            if(conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public SqlConnection GetConnection() 
        {
            return conexion;
        }
    }
}