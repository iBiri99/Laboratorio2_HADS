using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Comprobando que es alumno.
            if (Session["Tipo"] != null)
            {
                if (Session["Tipo"] != "Alum")
                {
                    Response.Redirect("~/Inicio.aspx");
                }
            }
            else
            { //Control de que no venga directamente.
                Response.Redirect("~/Inicio.aspx");
            }
            //Comprobar que tenga los parametros
            if (string.IsNullOrEmpty(Request.Params["codigo"]) || string.IsNullOrEmpty(Request.Params["he"]))
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hay algun dato mal insertado.');", true);
                Response.Redirect("~/Inicio.aspx");

            }
            //Si llega todo esta bien :)
            TextBox1.Text = Session["Correo"].ToString();
            TextBox2.Text = Request.Params["codigo"];
            TextBox3.Text = Request.Params["he"];
        }
    }
}