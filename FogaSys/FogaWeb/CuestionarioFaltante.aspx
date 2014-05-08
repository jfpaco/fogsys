<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="CuestionarioFaltante.aspx.cs" Inherits="CuestionarioFaltante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Scripts/jquery-1.7.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grdBusqueda" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" 
        EmptyDataText="No hay prospectos sin cuestionario" OnRowCommand="grdBusqueda_RowCommand" >
        <Columns>            
            <asp:ButtonField ButtonType="Button" Text="Seleccionar" CommandName="Seleccionar" />
            <asp:BoundField DataField="Id" HeaderText="Folio" HeaderStyle-CssClass="wd100" />
            <asp:BoundField DataField="Nom_Comercial" HeaderText="Nombre Comercial" HeaderStyle-CssClass="wd400" />
            <asp:BoundField DataField="RFC" HeaderText="RFC" HeaderStyle-CssClass="wd100" />
            <asp:BoundField DataField="Tipo_RFC" HeaderText="Tipo" HeaderStyle-CssClass="wd75" />
        </Columns>        
    </asp:GridView>
</asp:Content>

