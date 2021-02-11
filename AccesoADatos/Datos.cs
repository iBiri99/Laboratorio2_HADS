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
        string connetionString;
        SqlConnection cnn;
        //Devuelve 0 si se ha hecho correctamente la conexion y 1 si se ha hecho correctamente.
        public int AbrirSesion()
        {
            try
            {
                connetionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        //Funcion que saca si el correo esta en la base de datos.
        public int comprobarCorreo(String correo)
        {
            SqlCommand command = cnn.CreateCommand();
            command.CommandText ="Select ";
        }

    }
}
