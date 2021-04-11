using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class UsuariosConectados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            ListBox1.Items.Add("");
            ListBox2.Items.Add("");
            foreach (String element in Profesores)
            {
                ListBox1.Items.Add(element);
            }
            foreach (String element in alumnos)
            {
                ListBox2.Items.Add(element);
            }
        }
    }
}