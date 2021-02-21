using System;
using System.Net.Mail;

namespace EnvioCorreo
{
    public class Correo
    {

        //0= todo bien
        //2= ha saltado
        public int cambiarContraseña(string correo,int conf,string pagin)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("SMTP.Office365.com");

                mail.From = new MailAddress("hads2021@outlook.es");
                mail.To.Add(correo);
                mail.Subject = "Cambiar contraseña";
                mail.Body = "Accede al siguiente enlace para poder cambiar la contraseña de este usuario: \n "+ pagin + "?cod=" + conf + "&mail=" + correo + "\n El codigo es: " + conf;

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

        public int confirmarUsuario(string email, int numcof, int conf)
        {
            return 0;

        }

        public bool enviarEmail(string email,int conf, string pagin)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("SMTP.Office365.com");

            mail.From = new MailAddress("hads2021@outlook.es");
            mail.To.Add(email);
            mail.Subject = "Confirmacion de su correo electronico";
            mail.Body = "Para validar el registro pulse el siguiente enlace: \n " + pagin + "?mail=" + email + "&conf=" + conf;

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("hads2021@outlook.es", "1234Pass");
            smtpServer.EnableSsl = true;

           // cliente.Host = "smtp.gmail.com";
            


            try
            {
                smtpServer.Send(mail);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }
    }
}
