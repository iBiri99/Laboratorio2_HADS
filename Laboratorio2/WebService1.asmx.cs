using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Laboratorio2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://Grupo15.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string Media(String asig)
        {
            string connetionString = @"Server=tcp:hads21-15.database.windows.net,1433;Initial Catalog=HADS21-15;Persist Security Info=False;User ID=hads2021@outlook.es@hads21-15;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command= new SqlCommand("Select count(*) from TareasGenericas  INNER JOIN EstudiantesTareas on TareasGenericas.Codigo=EstudiantesTareas.CodTarea where CodAsig=@asig", cnn);
            command.Parameters.Add("@asig", System.Data.SqlDbType.VarChar);
            command.Parameters["@asig"].Value = asig;
            int total=(int) command.ExecuteScalar();
            if (total > 0)
            {
                SqlCommand command2 = new SqlCommand("Select SUM(Hreales) from TareasGenericas INNER JOIN EstudiantesTareas on TareasGenericas.Codigo=EstudiantesTareas.CodTarea where CodAsig=@asig", cnn);
                command2.Parameters.Add("@asig", System.Data.SqlDbType.VarChar);
                command2.Parameters["@asig"].Value = asig;
                int HorasTotal = (int)command2.ExecuteScalar();
                return (HorasTotal / total).ToString();
            }
            else
            {
                return "Error en la solicitud.";
            }
        }
    }
}
