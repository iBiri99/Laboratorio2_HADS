using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Laboratorio2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        AccesoADatos.Datos bd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
/*
        protected void Page_Unload(object sender, EventArgs e)
        {

           int a=bd.cerrarConexion();
            if (a == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('hello')", true);
            }
            else
            {

            }
        }
*/

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            bd = new AccesoADatos.Datos();
            int a=bd.AbrirSesion();
            if (a == 0)
            {
                int b = bd.comprobarCorreoYContraseña(Correo.Text,Contra.Text);
                if (b == 1)//El inicio de sesion ha sido correcto!
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Inicio de sesion correcto.');", true);
                    Response.Redirect("http://www.google.com");

                }
                else if(b==2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Tienes que confirmar el correo :)');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El correo o contraseña es incorrecto.');", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ha habido un problema (con la base de datos).');", true);
            }
            bd.cerrarConexion();
        }

    }
}