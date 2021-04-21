using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = DropDownList1.SelectedValue;

            try
            {
                var client = new WebService1();

                String horas = client.Media(selected);
                Label1.Text = horas;
            }
            catch
            {
                Label1.Text = "no se ha podido determinar el numero de horas";
            }

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            String selected = DropDownList1.SelectedValue;

            try
            {
                var client = new WebService1();

                String horas = client.Media(selected);
                Label1.Text = horas;
            }
            catch
            {
                Label1.Text = "no se ha podido determinar el numero de horas";
            }
        }
    }
}