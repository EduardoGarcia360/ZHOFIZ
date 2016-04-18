using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOFIS
{
    class Conexion
    {
        public static string cadena_conexion;
        SqlDataReader dr;

        public Conexion()
        {
            cadena_conexion = "Data Source=Edu-PC;Initial Catalog=SOFISBD;Integrated Security=True";
        }

        private SqlConnection get_conexion()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena_conexion);
                conn.Open();
                return conn;
            }
            catch (Exception exc)
            {
                return null;
            }
        } //fin private

        public void Insertar_en_Archivo(string depa, string tipo, string fechagen, string horagen, string fechares)
        {
            //INSERT INTO archivo (departamento, tipo_trabajo, fecha_generado, hora_generado, fecha_recibido) VALUES ('comunicacion', 'estadodecuenta','2016-04-08', '23:45:15', '2016-04-07')
            SqlConnection conn;
            try
            {
                using (conn = get_conexion())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "INSERT INTO archivo"
                            + "(departamento, tipo_trabajo, fecha_generado, hora_generado, fecha_recibido)"
                            + "values (@departamento, @tipo_trabajo, @fecha_generado, @hora_generado, @fecha_recibido";

                        command.Parameters.Add("@departamento", System.Data.SqlDbType.VarChar).Value = depa;
                        command.Parameters.Add("@tipo_trabajo", System.Data.SqlDbType.VarChar).Value = tipo;
                        command.Parameters.Add("@fecha_generado", System.Data.SqlDbType.Date).Value = fechagen;
                        command.Parameters.Add("@hora_generado", System.Data.SqlDbType.Time).Value = horagen;
                        command.Parameters.Add("@fecha_recibido", System.Data.SqlDbType.Date).Value = fechares;
                        //return (command.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("error");
                //return false;
            }
        }
    }
}
