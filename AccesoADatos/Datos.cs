﻿using System;
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

        //Funcion que saca si el correo y la contraseña es correcta. 1= si es correcto y 0 si no lo es. 2= No esta confirmado.
        public int comprobarCorreoYContraseña(String correo, String pass)
        {
            command = new SqlCommand("Select count(email) from Usuarios where email=@email and Pass=@Pass", cnn);
            SqlCommand command2 = new SqlCommand("Select confirmado from Usuarios where email=@email and Pass=@Pass", cnn); //Mejorar esto.

            //Parametros para el primero.
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = correo;
            command.Parameters.Add("@Pass", System.Data.SqlDbType.VarChar);
            command.Parameters["@Pass"].Value = pass;

            //Añadiendo parametros para el segundo.
            command2.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command2.Parameters["@email"].Value = correo;
            command2.Parameters.Add("@Pass", System.Data.SqlDbType.VarChar);
            command2.Parameters["@Pass"].Value = pass;

            bool confi=(bool)command2.ExecuteScalar();
            if (confi)
            {
                //Todo bien, deberia de devolver 1.
                return (int)command.ExecuteScalar();
            }
            else
            {
                //Todo bien, deberia de devolver 2.
                return 2;
            }

           
        }

        //0-> no existe correo
        //1-> Todo correcto.
        //3-> Ha habido algun error
        
        public int CambiarContrasenaCorreo(String correo)
        {
            int esta = comprobarCorreo(correo);
            if (esta == 1)
            {
                try
                {
                    //Creacion del numero aleatorio
                    var rand = new Random();
                    int num = rand.Next(100000, 999999);

                    command = new SqlCommand("UPDATE Usuarios SET codpass = @value WHERE email=@email;", cnn);
                    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                    command.Parameters["@email"].Value = correo;
                    command.Parameters.Add("@value", System.Data.SqlDbType.VarChar);
                    command.Parameters["@value"].Value = num;
                    command.ExecuteNonQuery();

                    //Ahora mandaremos el correo.

                    EnvioCorreo.Correo cor = new EnvioCorreo.Correo();
                    if (cor.cambiarContraseña(correo, num)==2)
                    {
                        return 2;
                    }
                    

                    return 1;
                }
                catch
                {
                    return 3; 
                }
            }
            else
            {
                return 0;
            }
           
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
