using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Diagnostics;

namespace Laboratorio2
{
    public partial class ProfesorImportar : System.Web.UI.Page
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
            Xml1.DocumentSource = Server.MapPath("App_Data\\" + DropDownList1.SelectedValue + ".xml");
            Xml1.TransformSource = Server.MapPath("App_Data/VerTablaTareas.xsl");
        }

        protected void Button1_Click(object sender, EventArgs e)    
        {
            String select = " SELECT *  FROM TareasGenericas WHERE 1=0";

            string connectionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            

            SqlDataAdapter datosAdaptador = new SqlDataAdapter(select, cnn);

            SqlCommandBuilder builder = new SqlCommandBuilder(datosAdaptador);

            DataSet setData = new DataSet();
            datosAdaptador.Fill(setData);

            DataTable tablaDatos = new DataTable();
            tablaDatos = setData.Tables[0];

            setData.CaseSensitive = false;



            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("App_Data\\" + DropDownList1.SelectedValue + ".xml"));
            

            XmlNodeList listaTareas = xml.GetElementsByTagName("tarea");

            foreach (XmlNode nodo in listaTareas)
            {
                DataRow filaDato = tablaDatos.NewRow();

                filaDato["Codigo"] = nodo.Attributes.GetNamedItem("codigo").Value;


                filaDato["Descripcion"] = nodo.ChildNodes[0].InnerText;

                filaDato["HEstimadas"] = nodo.ChildNodes[1].InnerText;
                if (nodo.ChildNodes[2].InnerText == "true")
                {
                    filaDato["Explotacion"] = 1;
                }
                else
                {
                    filaDato["Explotacion"] = 0;
                }
                
                filaDato["TipoTarea"] = nodo.ChildNodes[3].InnerText;
                filaDato["CodAsig"] = DropDownList1.SelectedItem.Text;

                tablaDatos.Rows.Add(filaDato);
                
            }

            
            try
            {


                int resul = datosAdaptador.Update(setData);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + "Las tareas se han importado correctamente" + ");", true);
                Label1.Text = "Las tareas se han importado correctamente"; 

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + "Las tareas ya estaban importadas" + ");", true);

            }

            

        }

        protected void DropDownList1_DataBound1(object sender, EventArgs e)
        {
            Xml1.DocumentSource = Server.MapPath("App_Data\\" + DropDownList1.SelectedValue + ".xml");
            Xml1.TransformSource = Server.MapPath("App_Data/VerTablaTareas.xsl");
        }
    }
}