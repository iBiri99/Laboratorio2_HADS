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
            try
            {
                var resul = command2.ExecuteReader();
                bool confi;
                resul.Read();
                confi = resul.GetBoolean(0);
                resul.Close();


                
                if (confi)
                {
                    //Todo bien, deberia de devolver 1.
                    return (int)command.ExecuteScalar();
                }
                else
                {
                    //Todo mal, deberia de devolver 2.
                    return 2;
                }
            }
            catch
            {
                return 0;
            }
        }

        //0-> no existe correo
        //1-> Todo correcto.
        //2-> Ha habido algun error
        
        public int CambiarContrasenaCorreo(String correo,String pagin)
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
                    if (cor.cambiarContraseña(correo, num,pagin)==2)
                    {
                        return 2;
                    }
                    

                    return 1;
                }
                catch
                {
                    return 2; 
                }
            }
            else
            {
                return 0;
            }
           
        }

        //0->No existe correo o el codigo es incorrecto
        //1->Todo bien
        //2->Fallo extra.
        //3->Resul raro :(
        public int cambiarPass(String correo, String pass, String codigo)
        {
            //Primero vamos a comprobar que el codigo metido sea el correcto.
            SqlCommand command3 = new SqlCommand("Select count(email) from Usuarios where email=@email and codpass=@cod", cnn);

            //Parametros para el primero.
            command3.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command3.Parameters["@email"].Value = correo;
            command3.Parameters.Add("@cod", System.Data.SqlDbType.VarChar);
            command3.Parameters["@cod"].Value = codigo;

            int resul = (int)command3.ExecuteScalar();
            //int resul = 1;
            if(resul == 1) //TODO BIEN
            {
                try
                {
                    
                    //Procedemos a cambiar la contraseña.
                    SqlCommand command2 = new SqlCommand("UPDATE Usuarios SET pass = @value, codpass='000000' WHERE email=@email;", cnn);
                    command2.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                    command2.Parameters["@email"].Value = correo;
                    command2.Parameters.Add("@value", System.Data.SqlDbType.VarChar);
                    command2.Parameters["@value"].Value = pass;
                    command2.ExecuteNonQuery();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else if(resul==0)
            {
                return 0;
            }
            return 3;

        }

        public int registrar(String nombre, String apellidos, int numConf, bool confirmado, String correo, String pass, int codpass)
        {
            command = new SqlCommand("INSERT into Usuarios(email,nombre,apellidos,numconfir,confirmado,tipo,pass,codpass) Values(@email,@nombre,@apellidos,@numconf,@confirmado,@tipo,@pass,@codpass) ", cnn);




            command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar);
            command.Parameters["@nombre"].Value = nombre;

            command.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar);
            command.Parameters["@apellidos"].Value = apellidos;

            command.Parameters.Add("@tipo", System.Data.SqlDbType.VarChar);
            command.Parameters["@tipo"].Value = 0; 



            command.Parameters.Add("@numconf", System.Data.SqlDbType.Int);
            command.Parameters["@numconf"].Value = numConf;

            command.Parameters.Add("@confirmado", System.Data.SqlDbType.Bit);
            command.Parameters["@confirmado"].Value = confirmado;

            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = correo;

            command.Parameters.Add("@Pass", System.Data.SqlDbType.VarChar);
            command.Parameters["@Pass"].Value = pass;

            command.Parameters.Add("@codpass", System.Data.SqlDbType.Int);
            command.Parameters["@codpass"].Value = codpass;

            int resul=(int)command.ExecuteNonQuery();

            if (resul == 1)
            {
                
            }
            return resul;
            

        }
        public int getNumcof(string email)
        {
           
            SqlCommand command4 = new SqlCommand("SELECT numconfir from Usuarios WHERE email=@email;", cnn);
            command4.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command4.Parameters["@email"].Value = email;
            var resul= command4.ExecuteReader();
            int sol;
            resul.Read();
            sol= resul.GetInt32(0);
            resul.Close();
            return sol;
            
        }

        public bool esConfirmado(string email)
        {

            SqlCommand command4 = new SqlCommand("SELECT confirmado from Usuarios WHERE email=@email;", cnn);
            command4.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command4.Parameters["@email"].Value = email;
            var resul = command4.ExecuteReader();
            bool sol;
            resul.Read();
            sol = resul.GetBoolean(0);
            resul.Close();
            return sol;

        }


        public void confirmarCorreo(string email)
        {
            SqlCommand command3 = new SqlCommand("UPDATE Usuarios SET confirmado = 1 WHERE email = @email;",cnn);
            command3.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command3.Parameters["@email"].Value = email;
            command3.ExecuteNonQuery();
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
