﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccesoADatos.Datos bd = new AccesoADatos.Datos();
            int a = bd.AbrirSesion();
            if (a == 0)
            {
                int resul = bd.CambiarContrasenaCorreo(Correo.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + resul + ");", true);
            }
        }
    }
}