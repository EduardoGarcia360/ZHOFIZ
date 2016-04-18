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

        public bool Insertar_en_Archivo(string depa, string tipo, string fechagen, string horagen, string fecharece, string horarece, string estado)
        {
            SqlConnection conn;
            try
            {
                using (conn = get_conexion())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "INSERT INTO archivo "
                            + "(departamento, tipo_trabajo, fecha_generado, hora_generado, fecha_recepcion, hora_recepcion, estado)"
                            + " VALUES (@departamento, @tipo_trabajo, @fecha_generado, @hora_generado, @fecha_recepcion, @hora_recepcion, @estado)";

                        command.Parameters.Add("@departamento", System.Data.SqlDbType.VarChar).Value = depa;
                        command.Parameters.Add("@tipo_trabajo", System.Data.SqlDbType.VarChar).Value = tipo;
                        command.Parameters.Add("@fecha_generado", System.Data.SqlDbType.VarChar).Value = fechagen;
                        command.Parameters.Add("@hora_generado", System.Data.SqlDbType.VarChar).Value = horagen;
                        command.Parameters.Add("@fecha_recepcion", System.Data.SqlDbType.VarChar).Value = fecharece;
                        command.Parameters.Add("@hora_recepcion", System.Data.SqlDbType.VarChar).Value = horarece;
                        command.Parameters.Add("@estado", System.Data.SqlDbType.VarChar).Value = estado;
                        return (command.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }//fin incertar en archivo

        public bool insertar_en_descartado(string nombre, string extencion, string fecharec, string horarec)
        {
            SqlConnection conn;
            try
            {
                using (conn = get_conexion())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "INSERT INTO descartado (nombre, extencion, fecha_recibido, hora_recibido)"
                                                + " VALUES (@nombre, @extencion, @fecharec, @horarec)";

                        command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
                        command.Parameters.Add("@extencion", System.Data.SqlDbType.VarChar).Value = extencion;
                        command.Parameters.Add("@fecharec", System.Data.SqlDbType.VarChar).Value = fecharec;
                        command.Parameters.Add("@horarec", System.Data.SqlDbType.VarChar).Value = horarec;
                        return (command.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }//fin descartado
    }
}
