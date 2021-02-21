using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["cod"]) && !string.IsNullOrEmpty(Request.Params["mail"]))
            {
                //Ha clicado desde el enlace
                Solicitar.Visible = false;
                Correo1.Text = Request.Params["mail"].ToString();
                Codigo.Text = Request.Params["cod"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccesoADatos.Datos bd = new AccesoADatos.Datos();
            int a = bd.AbrirSesion();
            if (a == 0)
            {
                int resul = bd.CambiarContrasenaCorreo(Correo.Text, HttpContext.Current.Request.Url.AbsoluteUri);
                if (resul == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El correo se ha enviado de manera correcta.');", true);
                }
                else if (resul == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El correo insertado no esta registrado.');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ha habido un problema al enviar el correo.');", true);
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            try
            {
                AccesoADatos.Datos bd = new AccesoADatos.Datos();
                int a = bd.AbrirSesion();
                if (a == 0)
                {
                    int resul;
                    //Vamos a cambiar la contraseña.
                    if (Codigo.Text != "000000")
                    {
                        resul = bd.cambiarPass(Correo1.Text, Pass.Text, Codigo.Text);
                    }
                    else
                    {
                        resul = 0;
                    }

                    if (resul == 1)
                    {
                        //EL cambio se ha realizado de manera correcta.
                        Response.Write("<script language='javascript'>window.alert('La contraseña se ha cambiado correctamente.');window.location='Inicio.aspx';</script>");
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La contraseña se ha cambiado correctamente');", true);
                        //Response.Redirect("~/Inicio.aspx");
                    }
                    else if (resul == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El codigo o el correo no es correcto');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ha habido un fallo."+resul+"');", true);
                    }
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hay algun dato mal insertado.');", true);
            }
        }

        protected void Pass1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}