<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfesorExportar.aspx.cs" Inherits="Laboratorio2.ProfesorExportar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #C0C0C0; margin-top: 0px; font-size: large; vertical-align: middle; text-align: center; font-weight: bold;">
            PROFESOR<br />
            EXPORTAR TAREAS GENÉRICAS</div>
            <p>
                Seleccionar asignaturas a exportar:
        </p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="true" OnDataBound="DropDownList1_DataBound">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" SelectCommand="SELECT codigoasig FROM GruposClase
WHERE codigo in (SELECT Codigogrupo FROM ProfesoresGrupo WHERE ProfesoresGrupo.Email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Correo" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
        </p>
        <asp:Button ID="Button1" runat="server" Height="69px" OnClick="Button1_Click" Text="EXPORTAR XML" />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Menu Profesor</asp:HyperLink>
    </form>
</body>
</html>
