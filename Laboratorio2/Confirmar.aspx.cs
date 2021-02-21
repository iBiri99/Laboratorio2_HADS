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

                if (numcof == numconfBD)
                {
                    
                    System.Diagnostics.Debug.WriteLine("iguales");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El correo se ha confirmado de manera correcta.');", true);
                    bd.confirmarCorreo(correo);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("no iguales");

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El correo no se ha podido confirmar');", true);
                }
            }
        }
    }
}