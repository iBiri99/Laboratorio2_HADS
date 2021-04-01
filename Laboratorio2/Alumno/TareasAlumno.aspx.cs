using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class TareasAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Alumno/InstanciarTarea.aspx?codigo="+ GridView1.SelectedRow.Cells[1].Text + "&he="+ GridView1.SelectedRow.Cells[3].Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Inicio.aspx");
        }
    }
}