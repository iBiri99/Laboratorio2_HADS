using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        AccesoADatos.Datos bd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var codigo = TextBox5.Text;
            var descripcion = TextBox1.Text;
            var asignatura = DropDownList1.SelectedValue;
            var horasAux = TextBox3.Text;
            int horas = 0; 

            for (int i = 0; i < horasAux.Length; i++)
            {
                    horas = horasAux[i];
            }


            var tipoTarea = DropDownList2.SelectedValue;

            bd = new AccesoADatos.Datos();
            int a = bd.AbrirSesion();

            bd.crearTarea(codigo, descripcion, asignatura, horas, tipoTarea);
            bd.cerrarConexion();
            
        }
    }
}