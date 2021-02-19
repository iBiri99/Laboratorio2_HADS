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

            String nombreApellidos = TextBox2.Text;
            String[] subna = nombreApellidos.Split(' ');
            var nombre = subna[0];
            var apellidos = subna[1]*subna[2];
            var Apellidos = 
            var passconf = TextBox4.Text;

            bd = new AccesoADatos.Datos();
            int a = bd.AbrirSesion();
            bd.registrar()
            var rand = new Random();
            var Numconf = (int)(rand.Next(1000000,10000000));

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