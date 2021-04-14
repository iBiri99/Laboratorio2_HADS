using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class Alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
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
            */

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> Alumnos = (List<string>)Application["alumnos"];
            Alumnos.Remove((String)Session["Correo"]);
            Application["alumnos"] = Alumnos;
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            List<string> Profesores;
            List<string> alumnos;
            if (Application["profesores"] != null)
            {
                Profesores = (List<string>)Application["profesores"];
            }
            else
            {
                Profesores = new List<string>();
            }

            if (Application["alumnos"] != null)
            {
                alumnos = (List<string>)Application["alumnos"];
            }
            else
            {
                alumnos = new List<string>();
            }
            int prof = 0;
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            foreach (String element in Profesores)
            {
                ListBox1.Items.Add(element);
                prof++;
            }
            int al = 0;
            foreach (String element in alumnos)
            {
                ListBox2.Items.Add(element);
                al++;
            }
            Label1.Text = "Profesores conectados: " + prof;
            Label2.Text = "Alumnos conectados: " + al;
        }
    }
}