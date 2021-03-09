<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="Laboratorio2.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 291px">
            <br />
            Asignaturas:<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT codigoasig FROM GruposClase
WHERE codigo in (SELECT Grupo FROM EstudiantesGrupo WHERE EstudiantesGrupo.Email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Correo" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" Height="26px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="162px">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
