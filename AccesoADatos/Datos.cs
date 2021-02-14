using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class Datos
    {
        private SqlConnection cnn;
        private SqlCommand command;
        //Devuelve 0 si se ha hecho correctamente la conexion y 1 si se ha hecho correctamente.
        public int AbrirSesion()
        {
            try
            {
                string connetionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        //Funcion que saca si el correo esta en la base de datos. 1= si esta y 0 si no.
        public int comprobarCorreo(String correo)
        {
            command = new SqlCommand("Select count(email) from Usuarios where email=@email", cnn);
            //command.CommandText ="Select count(email) from Usuarios where email="+correo;
            command.Parameters.Add("@email",System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = correo;
            return (int) command.ExecuteScalar();
        }

        //Funcion que saca si el correo y la contraseña es correcta. 1= si es correcto y 0 si no lo es.
        public int comprobarCorreoYContraseña(String correo, String pass)
        {
            command = new SqlCommand("Select count(email) from Usuarios where email=@email and Pass=@Pass", cnn);
            //command.CommandText ="Select count(email) from Usuarios where email="+correo;
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = correo;
            command.Parameters.Add("@Pass", System.Data.SqlDbType.VarChar);
            command.Parameters["@Pass"].Value = pass;

            return (int)command.ExecuteScalar();
        }

        public int cerrarConexion()
        {
            try
            {
                cnn.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

    }
}
