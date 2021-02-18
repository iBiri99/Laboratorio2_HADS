using System;
using System.Net.Mail;

namespace EnvioCorreo
{
    public class Correo
    {

        //0= todo bien
        //2= ha saltado
        public int cambiarContraseña(string correo,int conf)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("SMTP.Office365.com");

                mail.From = new MailAddress("hads2021@outlook.es");
                mail.To.Add(correo);
                mail.Subject = "Cambiar contraseña";
                mail.Body = "Accede al siguiente enlace para poder cambiar la contraseña de este usuario";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads2021@outlook.es", "1234Pass");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 2;
            }
        }

        public int confirmarUsuario(string correo)
        {
            return 0;
        }
    }
}
