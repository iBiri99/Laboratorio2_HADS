<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPass.aspx.cs" Inherits="Laboratorio2.WebForm4" %>

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
    <form id="form1" runat="server">
        <div>
        <strong><span class="auto-style1">Cambiar contraseña:</span></strong><br class="auto-style2" />
        <br class="auto-style2" />
        Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Correo" runat="server" AutoCompleteType="Email"></asp:TextBox>
            <br class="auto-style2" />
            <div style="margin-left: 40px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Correo" ErrorMessage="Correo electronico no valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
        <p style="margin-left: 80px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cambiar contraseña" />
        </p>
    </form>
</body>
</html>
