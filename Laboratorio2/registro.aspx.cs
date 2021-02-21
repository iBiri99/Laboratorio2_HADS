using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class WebForm3 : System.Web.UI.Page

    {
        AccesoADatos.Datos bd;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var email = TextBox1.Text;
            var pass = TextBox3.Text;

            
            var nombre = TextBox2.Text;
            var apellidos = TextBox5.Text;
            var passconf = TextBox4.Text;
            var roll = DropDownList1.SelectedValue;
            var codpass = 0;

            EnvioCorreo.Correo correo = new EnvioCorreo.Correo();
            
            var rand = new Random();
            var numconf = (int)(rand.Next(1000000,10000000));
            try
            {
                bd = new AccesoADatos.Datos();
                int resul;
                int a = bd.AbrirSesion();
                if (a == 0)
                {
                    resul = bd.registrar(nombre, apellidos, numconf, false, email, pass, codpass);
                }

                bd.cerrarConexion();
                var sol=correo.enviarEmail(email,numconf, "https://localhost:44394/Confirmar.aspx");
            

                System.Diagnostics.Debug.WriteLine(sol);





            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hay algun dato mal insertado.');", true);
            }
            
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}