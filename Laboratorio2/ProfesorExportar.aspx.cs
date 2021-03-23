using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Laboratorio2
{
    public partial class ProfesorExportar : System.Web.UI.Page
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
            String select = " SELECT Codigo, Descripcion, HEstimadas, Explotacion, tipoTarea   FROM TareasGenericas WHERE CodAsig = '" + DropDownList1.SelectedValue + "'";

            string connectionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();



            SqlDataAdapter datosAdaptador = new SqlDataAdapter(select, cnn);

            datosAdaptador.SelectCommand = new SqlCommand(select, cnn);

            DataSet setData = new DataSet();
            datosAdaptador.Fill(setData);

            GridView1.DataSource = setData;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String select = " SELECT Codigo,Descripcion,HEstimadas,Explotacion,tipoTarea  FROM TareasGenericas WHERE CodAsig = '" + DropDownList1.SelectedValue + "'";

            string connectionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();



            SqlDataAdapter datosAdaptador = new SqlDataAdapter(select, cnn);

            SqlCommandBuilder builder = new SqlCommandBuilder(datosAdaptador);

            DataSet setData = new DataSet();
            datosAdaptador.Fill(setData);

            DataTable tablaDatos = new DataTable();
            tablaDatos = setData.Tables[0];


            tablaDatos.Columns[0].ColumnMapping = MappingType.Attribute;
            
            setData.DataSetName = "tareas";
            
            tablaDatos.TableName = "tarea";
            


            for (int i = 0; i < tablaDatos.Columns.Count; i++)
            {
                string nombre = tablaDatos.Columns[i].ColumnName.ToLower();
                tablaDatos.Columns[i].ColumnName = nombre;

            }
            
       




            setData.WriteXml(Server.MapPath("App_Data\\" + DropDownList1.SelectedValue + ".xml"));

            

            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("App_Data\\" + DropDownList1.SelectedValue + ".xml"));
        }
        public class Select
        {
            [XmlAttribute] public string path;
            [XmlNamespaceDeclarations] public XmlSerializerNamespaces xmlns;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            String select = " SELECT Codigo, Descripcion, HEstimadas, Explotacion, tipoTarea   FROM TareasGenericas WHERE CodAsig = '" + DropDownList1.SelectedValue + "'";

            string connectionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();



            SqlDataAdapter datosAdaptador = new SqlDataAdapter(select, cnn);

            datosAdaptador.SelectCommand = new SqlCommand(select, cnn);

            DataSet setData = new DataSet();
            datosAdaptador.Fill(setData);

            GridView1.DataSource = setData;
            GridView1.DataBind();
        }
    }
}