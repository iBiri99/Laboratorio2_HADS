using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class TareasProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Tipo"] != null)
            {
                if (Session["Tipo"] != "Prof")
                {
                    Response.Redirect("~/Inicio.aspx");
                }
            }
            else
            { //Control de que no venga directamente.
                Response.Redirect("~/Inicio.aspx");
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InsertarTarea.aspx");
        }
    }
}