<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="Laboratorio2.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 560px;
        }
    </style>
</head>
     <script>
             setInterval(function () {
             if (XMLHttpRequest) {
                 xhr = new XMLHttpRequest();
                 xhr.open('GET', '../AJAX/UsuariosConectados.aspx', true);
                 xhr.onreadystatechange = function () {
                     if (xhr.readyState == 4 && xhr.status == 200) {
                         document.getElementById('Usuarios').innerHTML = xhr.responseText;
                     }
                 }
                 xhr.send('');
             }  
             }, 1000);
         </script>
<body>
    <form id="form1" runat="server">
        <div style="height: 660px">
            <div style="height: 67px; background-color: #C0C0C0; color: #000000;">
                <p class="auto-style1">
                    Alumnos gestion de tareas</p>
                <p class="auto-style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar sesión" />
                </p>
                <div style="height: 364px">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Tareas genéricas</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/tipos-de-becas-y-ayudas-para-universitarios.jpg" />
                    <br />
                    <br />
        Profesores:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Alumnos:<br />
                </div>
            </div>
        </div>
    </form>
                    <div id="Usuarios">
    </div>
            </body>
</html>
