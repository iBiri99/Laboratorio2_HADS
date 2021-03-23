<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfesorImportar.aspx.cs" Inherits="Laboratorio2.ProfesorImportar" %>

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
            IMPORTAR TAREAS GENÉRICAS</div>
            <p>
                Seleccionar asignaturas a importar:</p>
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="asig" DataTextField="codigoasig" DataValueField="codigoasig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true" OnDataBound="DropDownList1_DataBound1">
                </asp:DropDownList>
                <asp:SqlDataSource ID="asig" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" SelectCommand="SELECT codigoasig FROM GruposClase
WHERE codigo in (SELECT Codigogrupo FROM ProfesoresGrupo WHERE ProfesoresGrupo.Email = @email)">
                    <SelectParameters>
                        <asp:SessionParameter Name="email" SessionField="Correo" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </p>
            <p>
                <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <asp:Button ID="Button1" runat="server" Text="IMPORTAR XMLD" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Menu Profesor</asp:HyperLink>
        </form>
</body>
</html>
