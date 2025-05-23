using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proyecto_1_programacion
{
    public class BDService
    {
        private readonly string cadenaConexion;
        
        public BDService()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        }

        public void GuardarResultado(string tema, string resultado)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string query = "INSERT INTO Investigaciones (Tema, Resultado, Fecha) VALUES (@Tema, @Resultado, @Fecha)";
                using (SqlCommand cmd = new  SqlCommand (query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Tema", tema);
                    cmd.Parameters.AddWithValue("@Resultado", resultado);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
