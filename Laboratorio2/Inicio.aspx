<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Laboratorio2.WebForm1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style2">
        <strong><span class="auto-style1">Inicio de sesión:</span></strong><br class="auto-style2" />
        <br class="auto-style2" />
        Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Correo" runat="server" AutoCompleteType="Email" required="true"></asp:TextBox>
        <br />
        <br class="auto-style2" />
        <div style="margin-left: 40px">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Correo" ErrorMessage="Correo electronico no valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <br class="auto-style2" />
        Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Contra" runat="server" TextMode="Password" required="true"></asp:TextBox>
        <br class="auto-style2" />
        <br class="auto-style2" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Contra" ErrorMessage="La contraseña tiene que tener 6 digitos por lo menos." ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br class="auto-style2" />
        <div style="margin-left: 320px">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CambiarPass.aspx">Cambiar contraseña</asp:HyperLink>
        </div>
        <div style="margin-left: 80px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        </div>
        <div style="margin-left: 320px">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/registro.aspx">Registrar</asp:HyperLink>
        </div>
        <br />
    </form>
</body>
</html>
