<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Laboratorio2.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="height: 134px; width: 1298px; margin-left: 9px; background-color: #C0C0C0; font-size: 23px; color: #000000; text-align: inherit; vertical-align: middle;">
            <p style="margin-left: 560px">
                PROFESOR</p>
            <p style="margin-left: 520px">
                GESTIÓN DE TAREAS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <p style="margin-left: 560px">
                GENÉRICOS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        </div>
        </div>
        <p>
            Código<asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged" style="margin-left: 90px" Width="109px"></asp:TextBox>
        </p>
        <p style="vertical-align: top; line-height: normal; text-align: left;">
            Descripción<asp:TextBox ID="TextBox1" runat="server" Height="45px" OnTextChanged="TextBox1_TextChanged" style="margin-left: 62px" Width="333px"></asp:TextBox>
        </p>
        <p>
            Asignatura&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="codigo" DataValueField="codigo" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
        </p>
        <p>
            Horas Estimadas<asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged" style="margin-left: 31px" Width="120px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="el valor que ha insertado n o es un un numero" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </p>
        <p>
            Tipo Tarea&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="TipoTarea" DataValueField="TipoTarea" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" SelectCommand="SELECT Distinct [TipoTarea] FROM [TareasGenericas]"></asp:SqlDataSource>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Añadir Tarea" />
        </p>
        <div style="margin-left: 480px">
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Size="X-Large" NavigateUrl="~/TareasProfesor.aspx">Ver Tareas</asp:HyperLink>
        </div>
    </form>
</body>
</html>
