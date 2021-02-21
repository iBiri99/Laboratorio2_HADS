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
        <div id="Solicitar" runat="server" style="height: 120px">

        <strong><span class="auto-style1">Cambiar contraseña:</span></strong><br class="auto-style2" />
        <br class="auto-style2" />
        Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Correo" runat="server" AutoCompleteType="Email"></asp:TextBox>
            <br class="auto-style2" />
            <div style="margin-left: 40px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Correo" ErrorMessage="Correo electronico no valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Solicitar cambio" />
                <br />
                <br />
                <br />
            </div>
            </div>
        <div id="Cambiar" runat="server" style="height: 241px">&nbsp;<strong><span class="auto-style1">Datos para cambiar contraseña<br />
            </span></strong>Codigo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Codigo" runat="server" AutoCompleteType="Email" ></asp:TextBox>
            <br />
            <br />
            Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Correo1" runat="server" AutoCompleteType="Email" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Correo1" ErrorMessage="Correo electronico no valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
        <br class="auto-style2" />
            Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Pass" runat="server" AutoCompleteType="Email" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Pass" ErrorMessage="La contraseña tiene que tener 6 digitos por lo menos." ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
            <br />
            <br />
            Repetir contraseña:<asp:TextBox ID="Pass1" runat="server" AutoCompleteType="Email" OnTextChanged="Pass1_TextChanged" ></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="Pass" ControlToValidate="Pass1" ErrorMessage="Las contraseñas no coinciden."></asp:CompareValidator>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Cambiar contraseña" />
            <br />
            <br />
            <br />
            <br class="auto-style2" />
        </div>
    </form>
</body>
</html>
