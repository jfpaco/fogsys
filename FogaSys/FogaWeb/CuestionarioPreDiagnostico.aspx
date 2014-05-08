<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="CuestionarioPreDiagnostico.aspx.cs" Inherits="CuestionarioPreDiagnostico" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Scripts/jquery-1.7.1.min.js"></script>  
    <script src="Scripts/jquery-ui-1.10.4.custom.min.js"></script>
    <link href="css/gris/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />
    <script src="Controlador/General.js"></script>
    <script src="Controlador/CuestionarioPreDiagnostico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titForm"><h1>Cuestionario de Pre Diagnóstico</h1></div>
<asp:Panel ID="pnlPreDiagnostico" runat="server">
    <table>
        <tr>
            <th colspan="4">
                Información General del Solicitante
            </th>
        </tr>
        <tr>
            <td>
                <b>Folio Prospecto:</b>
                <asp:Label ID="lblFolio" runat="server" Text=""></asp:Label>
            </td>
            <td colspan="3" class="derecha">
                Fecha:            
                <asp:TextBox ID="txtFechaPre" runat="server" Enabled="false" CssClass="wd75 fecha"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="wd200">
                ¿Cuenta con otro empleo?
            </td>
            <td colspan="3">
                <asp:RadioButtonList ID="rdoSolicOtroEmpleo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rdoSolicOtroEmpleo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>                                        
        </tr>   
        <asp:Panel ID="pnlSolicOtroEmpleo" runat="server" Visible="false">                                         
        <tr>            
            <td>
                <asp:RequiredFieldValidator ID="rfvSolicOtroEmpleoEsp" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtSolicOtroEmpleoEsp" ErrorMessage="Campo Descripción del Empleo obligatorio" ValidationGroup="solic"></asp:RequiredFieldValidator>
                Descripción del Empleo:
            </td>
            <td>
                <asp:TextBox ID="txtSolicOtroEmpleoEsp" runat="server" MaxLength="75" CssClass="wd250"></asp:TextBox>                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvSolicOtroEmpleoIngr" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtSolicOtroEmpleoIngr" ErrorMessage="Campo Ingresos Mensuales obligatorio" ValidationGroup="solic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revSolicOtroEmpleoIngr" runat="server" Text="*M" Font-Bold="true" ForeColor="Red"   
                                ErrorMessage="Campo Ingresos Mensuales máximo 10 caracteres numéricos" ValidationGroup="solic"
                                ControlToValidate="txtSolicOtroEmpleoIngr" Display="Dynamic" ValidationExpression="^[0-9,]{1,10}$" />	
                Ingresos Mensuales (sin centavos):
            </td>
            <td>
                <asp:TextBox ID="txtSolicOtroEmpleoIngr" MaxLength="10" CssClass="wd100 moneda" runat="server"></asp:TextBox>
            </td>
        </tr>        
        </asp:Panel>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvAntigNego" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtAntigNego" ErrorMessage="Campo Descripción del Empleo obligatorio" ValidationGroup="cuestionario"></asp:RequiredFieldValidator>
                Antigüedad del Negocio:
            </td>
            <td colspan="3">                
                <asp:TextBox ID="txtAntigNego" runat="server" MaxLength="10" CssClass="wd75 fecha"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CompareValidator ID="rfvLocalNego" runat="server" Text="*" Font-Bold="true" ForeColor="Red" 
                                ErrorMessage="Campo Estado (Domicilio Fiscal) obligatorio" ValidationGroup="cuestionario"
                                ControlToValidate="cboLocalNego" Display="Dynamic" Operator="NotEqual" ValueToCompare="Seleccionar..." ></asp:CompareValidator>	
                Tipo de Local en que Tiene el Negocio:
            </td>
            <td colspan="3">
                <asp:DropDownList ID="cboLocalNego" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboLocalNego_SelectedIndexChanged">
                    <asp:ListItem>Seleccionar...</asp:ListItem>
                    <asp:ListItem Value="0">Propio</asp:ListItem>
                    <asp:ListItem Value="1">Arrendado</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <asp:Panel ID="pnlLocalNego" runat="server" Visible="false">
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvLocalNegoRenta" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtLocalNegoRenta" ErrorMessage="Campo Precio de la Renta obligatorio" ValidationGroup="local"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLocalNegoRenta" runat="server" Text="*M" Font-Bold="true"   
                                ForeColor="Red" ErrorMessage="Campo Precio de la Renta máximo 10 caracteres numéricos" ValidationGroup="local"
                                ControlToValidate="txtLocalNegoRenta" Display="Dynamic" ValidationExpression="^[0-9,]{1,10}$" />
                Precio de la Renta:
            </td>
            <td>
                <asp:TextBox ID="txtLocalNegoRenta" MaxLength="10" CssClass="wd100 moneda" runat="server"></asp:TextBox>                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvLocalNegoVigen" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtLocalNegoVigen" ErrorMessage="Campo Ingresos Mensuales obligatorio" ValidationGroup="local"></asp:RequiredFieldValidator>
                Vigencia del Arrendamiento:
            </td>
            <td>
                <asp:TextBox ID="txtLocalNegoVigen" runat="server" CssClass="wd75 fecha"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvPersonalAct" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtPersonalAct" ErrorMessage="Campo Personas que intervienen en la actividad del Negocio obligatorio" ValidationGroup="cuestionario"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPersonalAct" runat="server" Text="*M" Font-Bold="true"    
                                ForeColor="Red" ErrorMessage="Campo Personas que intervienen en la actividad del Negocio 5 caracteres numéricos" ValidationGroup="cuestionario"
                                ControlToValidate="txtPersonalAct" Display="Dynamic" ValidationExpression="^[0-9]{1,5}$" />
                Personas que intervienen en la actividad del Negocio:
            </td>
            <td>
                <asp:TextBox ID="txtPersonalAct" MaxLengt="5" runat="server" CssClass="wd100"></asp:TextBox>                
            </td>
            <td>
                ¿Cuenta con algún tipo de seguro?
            </td>
            <td>
                <asp:RadioButtonList ID="rdoSegTipo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rdoSegTipo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <asp:Panel ID="pnlSegTipo" runat="server" Visible="false">
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvSegTipoDescrp" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtSegTipoDescrp" ErrorMessage="Campo Fecha de alta del seguro obligatorio" ValidationGroup="seguro"></asp:RequiredFieldValidator>
                Fecha de alta del seguro:
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSegTipoDescrp" runat="server" MaxLength="10" CssClass="wd75 fecha"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvNomiSem" runat="server" Text="*" Display="Dynamic" Font-Bold="true" ForeColor="Red" 
                    ControlToValidate="txtNomiSem" ErrorMessage="Campo Costo de la Nomina Semanal obligatorio" ValidationGroup="cuestionario"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNomiSem" runat="server" Text="*M" Font-Bold="true"    
                                ForeColor="Red" ErrorMessage="Campo Costo de la Nomina Semanal 10 caracteres numéricos" ValidationGroup="cuestionario"
                                ControlToValidate="txtNomiSem" Display="Dynamic" ValidationExpression="^[0-9,]{1,10}$" />
                Costo de la Nomina Semanal:
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtNomiSem" runat="server" MaxLength="12" CssClass="wd100 moneda"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="cuestionario" DisplayMode="List" Font-Bold="True" ForeColor="Red" ShowMessageBox="True"/>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="centrado">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="cuestionario" OnClick="btnGuardar_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

