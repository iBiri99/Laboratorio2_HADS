<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="Laboratorio2.TareasAlumno" %>

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
<body>
    <form id="form1" runat="server">
        <div style="height: 542px">
            <div style="height: 67px; background-color: #C0C0C0; color: #000000;">
                <p class="auto-style1">
                    Alumnos gestion de tareas</p>
                <p class="auto-style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar sesión" />
                </p>
            </div>
            <br />
            Asignaturas:<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT codigoasig FROM GruposClase
WHERE codigo in (SELECT Grupo FROM EstudiantesGrupo WHERE EstudiantesGrupo.Email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Correo" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" Height="26px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="162px">
            </asp:DropDownList>
            <br />
            <br />
            <div style="height: 278px" runat="server" id="div2">
                Tareas a realizar<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Height="210px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="526px" emptydatatext="No hay tareas!">
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:CommandField SelectText="Instanciar" ShowSelectButton="True" />
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                        <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                        <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-15ConnectionString %>" SelectCommand="SELECT [Codigo], [Descripcion], [HEstimadas], [TipoTarea] FROM [TareasGenericas] WHERE (([Explotacion] = @Explotacion) AND ([CodAsig] = @CodAsig) and codigo not in (SELECT  CodTarea FROM EstudiantesTareas WHERE EstudiantesTareas.Email=@email))" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [HEstimadas], [TipoTarea]) VALUES (@Codigo, @Descripcion, @HEstimadas, @TipoTarea)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [HEstimadas] = @HEstimadas, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
                <DeleteParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="True" Name="Explotacion" Type="Boolean" />
                    <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                    <asp:SessionParameter DefaultValue="" Name="email" SessionField="Correo" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                    <asp:Parameter Name="Codigo" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
