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

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccesoADatos.Datos dat = new AccesoADatos.Datos();
            dat.AbrirSesion();
            if (dat.verTareaSiRealizada(Request.Params["codigo"].ToString(), Session["Correo"].ToString()) != 0)
            {
                //Ya esta instanciada
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La tarea ya esta instanciada.');", true);
                //Hacer un redirect.
            }
            else
            {
                //No esta instanciada, la podemos instanciar.
                //1º miramos
                int resul= dat.InstanciarTareaAlumno(Request.Params["codigo"].ToString(), Session["Correo"].ToString(),Request.Params["he"].ToString(),TextBox4.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert("+resul+");", true);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
                
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}