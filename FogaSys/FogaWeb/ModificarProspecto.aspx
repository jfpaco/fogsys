<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="ModificarProspecto.aspx.cs" Inherits="ModificarProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function mandaFolio() {
            var text = $(this);
            alert(text.attr('Text'));
            //$("$txtFolio").val($(this).attr("title"));
            //alert($("$txtFolio").val());
            return false;
        }
        $(document).ready(function () {
            $(".lnkFolio").live("click", function () {
                var text = $(this);
                //alert(text.attr('title'));
                $("#txtFolio").val(text.attr('title'));
                $("#txtFolio").val();
                return true;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <th>
                <span>Busqueda (Nombre comercial, RFC)</span>
            </th>
        </tr>
        <tr>
            <td class="centrado">
                <asp:Panel ID="pnlBusqueda" runat="server" DefaultButton="btnBusqueda">
                    <asp:TextBox ID="txtBusqueda" runat="server" CssClass="wd300"></asp:TextBox>
                    <asp:Button ID="btnBusqueda" runat="server" Text="Buscar" OnClick="btnBusqueda_Click" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdBusqueda" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" >
        <Columns>            
            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="wd150">
                <ItemTemplate>                    
                    <asp:Button ID="btnMandar" CssClass="lnkFolio" runat="server" Text="Modificar" PostBackUrl="~/Prospecto.aspx?tip=modificar" ToolTip='<%#Bind("Id") %>' /> 
                    <asp:Button ID="btnCredito" CssClass="lnkFolio" runat="server" Text="Crédito" PostBackUrl="~/Credito.aspx" ToolTip='<%#Bind("Id") %>' />                     
                </ItemTemplate>                
            </asp:TemplateField>                            
            <asp:BoundField DataField="Nom_Comercial" HeaderText="Nombre Comercial" HeaderStyle-CssClass="wd400" />
            <asp:BoundField DataField="RFC" HeaderText="RFC" HeaderStyle-CssClass="wd100" />
            <asp:BoundField DataField="Tipo_RFC" HeaderText="Tipo" HeaderStyle-CssClass="wd75" />
        </Columns>        
    </asp:GridView>
    <asp:HiddenField ID="txtFolio" runat="server" />
    <%--<asp:TextBox ID="txtFolio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" PostBackUrl="~/Prospecto.aspx?tip=modificar" />--%>
</asp:Content>

