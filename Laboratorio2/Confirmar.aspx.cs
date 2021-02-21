using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["conf"]) && !string.IsNullOrEmpty(Request.Params["mail"]))
            {
                //Ha clicado desde el enlace
                AccesoADatos.Datos bd = new AccesoADatos.Datos();
                bd.AbrirSesion();

                var correo = Request.Params["mail"].ToString();
                var numcof =Request.Params["conf"].ToString();
                var numconfBD = bd.getNumcof(correo).ToString() ;
                System.Diagnostics.Debug.WriteLine(numconfBD + " " + numcof);
                bool estaconfirmado = bd.esConfirmado(correo);

                if (numcof == numconfBD && !estaconfirmado)
                {
                    bd.confirmarCorreo(correo);
                    div1.InnerHtml = "El usuario se ha registrado correctamente";
                    
                }
                else if(numcof!=numconfBD)
                {
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Numero de confirmacion incorrecta ');", true);
                    Response.Redirect("~/Inicio.aspx");

                }else if (estaconfirmado)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Este usuario ya esta registrado');", true);
                    Response.Redirect("~/Inicio.aspx");
                }
            }
        }
    }
}