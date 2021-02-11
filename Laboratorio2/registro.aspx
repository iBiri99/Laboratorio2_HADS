<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Laboratorio2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Direccíón de correo<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 24px"></asp:TextBox>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Correo no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;&nbsp;
            <br />
            <br />
            Nombre y apellidos<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 25px"></asp:TextBox>
            <br />
            <br />
            password<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 85px" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="contraseña no valida" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
            <br />
            <br />
            password<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 82px" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="CompareValidator">las contraseñas no coinciden</asp:CompareValidator>
            <br />
            <br />
            Rol<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" style="margin-left: 122px" Width="127px">
                <asp:ListItem>Alumno</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registrarse" />
        </div>
    </form>
</body>
</html>
