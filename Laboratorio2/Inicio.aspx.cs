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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('La conexion se ha realizado correctamente.')", true);
                bd.comprobarCorreo("hola");
            }
        }
    }
}