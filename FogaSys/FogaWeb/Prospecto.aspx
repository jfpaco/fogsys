<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Prospecto.aspx.cs" Inherits="Prospecto" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.min.js"></script>
    <link href="css/gris/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />
    <script src="Controlador/General.js"></script>
    <script src="Controlador/Prospecto.js"></script>
    <script src="Scripts/catalogo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="titForm">
        <h1>Prospecto</h1>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <asp:Panel ID="pnlDatosGral" runat="server">
        <table>
            <tr>
                <th colspan="4">
                    <span>Datos Generales de la empresa</span>
                </th>
            </tr>
            <tr>
                <td colspan="4" class="derecha">
                    <span><b>Folio: </b></span>
                    <asp:Label ID="lblFolio" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="wd250">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNomComercial" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Nombre comercial de la empresa obligatorio"
                            ControlToValidate="txtNomComercial" Display="Dynamic"></asp:RequiredFieldValidator>
                        Nombre comercial de la empresa                    
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtNomComercial" CssClass="wd400" MaxLength="300" runat="server" Text=""></asp:TextBox>
                </td>
                <td class="wd100">
                    <span>
                        <asp:RegularExpressionValidator ID="revRFC" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Error Formato de RFC"
                            ControlToValidate="txtRFC" Display="Dynamic" ValidationExpression="[A-Z]{4}[0-9]{6}[A-Z0-9]{3}" />
                        <asp:RequiredFieldValidator ID="rfvRFC" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo RFC obligatorio"
                            ControlToValidate="txtRFC" Display="Dynamic"></asp:RequiredFieldValidator>
                        RFC
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtRFC" runat="server" MaxLength="13" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvProducServi" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Principales Productos o Servicios obligatorio"
                            ControlToValidate="txtProducServi" Display="Dynamic"></asp:RequiredFieldValidator>
                        Principales Productos o Servicios                  
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtProducServi" CssClass="wd400" runat="server" MaxLength="500" Text=""></asp:TextBox>
                </td>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvFaltaSat" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Fecha de alta en SAT obligatorio"
                            ControlToValidate="txtFaltaSat" Display="Dynamic"></asp:RequiredFieldValidator>
                        Fecha de alta en SAT
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtFaltaSat" CssClass="wd75 fecha" MaxLength="10" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>

                <td class="wd150"><span>Tipo de Persona Fiscal
                </span>
                </td>
                <td class="rdoPersonaFisica radios" colspan="3">
                    <asp:RadioButtonList ID="rdoTipoPersona" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">

                        <asp:ListItem Value="F">Fisica</asp:ListItem>
                        <asp:ListItem Value="M">Moral</asp:ListItem>

                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlGral" runat="server" CssClass="frmAmbos">
        <table>
            <tr>
                <th colspan="3">Actividad PRINCIPAL (de acuerdo a SCIAN)</th>
            </tr>
            <tr>
                <td class="wd150 centrado" colspan="3">Buscador SCIAN
                    <asp:TextBox ID="txtBuscadorSCIAN" runat="server" Text="" CssClass="wd300"></asp:TextBox>
                    <asp:Button ID="btnBuscadorSCIAN" runat="server" Text="Buscar" ValidationGroup="ninguno" OnClick="btnBuscadorSCIAN_Click" />
                    <asp:UpdateProgress ID="udpPnlSCIAN" runat="server">
                        <ProgressTemplate>
                            <img src="Imagenes/load.gif" alt="Cargando" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updPnlSCIAN" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grdConsultaSCIAN" runat="server" AutoGenerateColumns="false" DataKeyNames="IdClase" CssClass="grd" OnRowCommand="grdConsultaSCIAN_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Link" Text="Seleccionar" CommandName="Seleccionar" />
                        <asp:BoundField DataField="IdClase" HeaderText="Clave" />
                        <asp:BoundField DataField="Clase" HeaderText="Clase" HeaderStyle-CssClass="wd100" />
                        <asp:BoundField DataField="SubRama" HeaderText="Sub Rama" HeaderStyle-CssClass="wd100" />
                        <asp:BoundField DataField="Rama" HeaderText="Rama" />
                        <asp:BoundField DataField="SubSector" HeaderText="Sub Sector" HeaderStyle-CssClass="wd100" />
                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grdActividadSCIAN" runat="server" DataKeyNames="IdClase,Porcentaje" AutoGenerateColumns="false" OnRowCommand="grdActividadSCIAN_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Link" Text="Quitar" CommandName="Eliminar" />
                        <asp:BoundField DataField="IdClase" HeaderText="Clave SCIAN" />
                        <asp:BoundField DataField="Clase" HeaderText="Clase" />
                        <asp:BoundField DataField="SubRama" HeaderText="Sub Rama" />
                        <asp:BoundField DataField="Rama" HeaderText="Rama" />
                        <asp:BoundField DataField="SubSector" HeaderText="Sub Sector" />
                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                        <asp:TemplateField HeaderText="Porcentaje %">
                            <ItemTemplate>
                                <asp:TextBox ID='txtPorcentaje' CssClass="porcentaje" runat="server" ViewStateMode="Enabled" Text='<%#Bind("Porcentaje") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscadorSCIAN" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Font-Size="12px"  Font-Bold="true" ForeColor="Red" ClientValidationFunction="validaPorcentaje" Text="El porcentaje debe ser de 100%"
                        ErrorMessage="El porcentaje debe ser de 100%">
                    </asp:CustomValidator>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <th colspan="4">
                    <span>Domicilio Fiscal
                    </span>
                </th>
            </tr>
            <tr>
                <td class="wd250">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvCalleDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Calle (Domicilio Fiscal) obligatorio"
                            ControlToValidate="txtCalleDfisPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Calle:</span>
                </td>
                <td class="wd200">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNoExtDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Num. Exterior (Domicilio Fiscal) obligatorio"
                            ControlToValidate="txtCalleDfisPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Num. Ext.:
                    </span>
                </td>
                <td class="wd200">
                    <span>Num. Int
                    </span>
                </td>
                <td class="wd200">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvColDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Colonia (Domicilio Fiscal) obligatorio"
                            ControlToValidate="txtColDfisPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Colonia/Fraccionamiento:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCalleDfisPfis" MaxLength="150" CssClass="wd250" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNoExtDfisPfis" MaxLength="6" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNoIntDfisPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtColDfisPfis" MaxLength="150" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvCPDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Código Postal (Domicilio Fiscal) obligatorio"
                            ControlToValidate="txtCPDfisPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCPDfisPfis" runat="server" Text="*M" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Código Postal mínimo 5 caracteres numéricos"
                            ControlToValidate="txtCPDfisPfis" Display="Dynamic" ValidationExpression="^[0-9]{5,5}$" />

                        C.P.:</span>
                </td>
                <td>
                    <span>
                        <asp:CompareValidator ID="covEdoDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" 
                                ForeColor="Red" ErrorMessage="Campo Estado (Domicilio Fiscal) obligatorio"
                                ControlToValidate="cboEdoDfisPfis" Display="Dynamic" Operator="NotEqual" ValueToCompare="Seleccionar..." ></asp:CompareValidator>
                        Estado:
                    </span>
                </td>
                <td>
                    <span>                        
                        <asp:CustomValidator ID="cuvHddMunDfisPfis" runat="server" Font-Size="12px"  Font-Bold="true" ForeColor="Red" ClientValidationFunction="validaHdd" Text="*" 
                        ErrorMessage="Campo Municipio (Domicilio Fiscal) obligatorio" Display="Dynamic" ToolTip="hddMunDfisPfis" >
                        </asp:CustomValidator>
                        Municipio:
                    </span>
                </td>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvTelDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Teléfono Empresa (Domicilio Fiscal) obligatorio"
                            ControlToValidate="txtTelDfisPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelDfisPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Télefono Empresa mínimo 10 caracteres numéricos"
                            ControlToValidate="txtTelDfisPfis" Display="Dynamic" ValidationExpression="^[0-9]{10,10}$" />
                        Teléfono Empresa:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCPDfisPfis" MaxLength="5" CssClass="wd50" runat="server" Text=""></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="cboEdoDfisPfis" Width="215" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:HiddenField ID="hddEdoDfisPfis" runat="server" />

                    <asp:DropDownList ID="cboMunDfisPfis" CssClass="wd200" runat="server"></asp:DropDownList>
                    <asp:HiddenField ID="hddMunDfisPfis" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtTelDfisPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlMoral" runat="server" CssClass="frmMoral">
        <table>
            <tr>
                <th colspan="4">Constitución de la Persona Moral
                </th>
            </tr>
            <tr>
                <td class="wd200 justificado">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNumNot" runat="server" Text="*" Font-Bold="true" CssClass="moral" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Número de Notario que realizó la escritura... obligatorio"
                            ControlToValidate="txtNumNot" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revNumNot" runat="server" Text="*" Font-Bold="true" CssClass="moral" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Número de Notario que realizó... máximo 5 caracteres numéricos"
                            ControlToValidate="txtNumNot" Display="Dynamic" ValidationExpression="^[0-9]{1,50}$" />
                        Número de Notario que realizó la escritura pública de Constitución:
                    </span>
                </td>
                <td class="wd300 justificado">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNotEp" runat="server" Text="*" Font-Bold="true" CssClass="moral" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Nombre del Notario obligatorio"
                            ControlToValidate="txtNotEp" Display="Dynamic"></asp:RequiredFieldValidator>
                        Nombre del Notario (completo):
                    </span>
                </td>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNumEscEp" runat="server" Text="*" Font-Bold="true" CssClass="moral" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Número de Escritura Pública... obligatorio"
                            ControlToValidate="txtNumEscEp" Display="Dynamic"></asp:RequiredFieldValidator>
                        Número de Escritura Pública de Constitución de la empresa:
                    </span>
                </td>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvFescPub" runat="server" Text="*" Font-Bold="true" CssClass="moral" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Fecha de Escrituración obligatorio"
                            ControlToValidate="txtFescPub" Display="Dynamic"></asp:RequiredFieldValidator>
                        Fecha de Escrituración:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNumNot" MaxLength="50" CssClass="wd100" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNotEp" MaxLength="150" CssClass="wd250" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNumEscEp" MaxLength="50" CssClass="wd100" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtFescPub" MaxLength="10" CssClass="wd75 fecha" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:CompareValidator ID="rfvEdoNot" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" CssClass="moral"
                                    ForeColor="Red" ErrorMessage="Campo Estado (Constitución de la Persona Moral) obligatorio"
                                    ControlToValidate="cboEdoNot" Display="Dynamic" Operator="NotEqual" ValueToCompare="Seleccionar..." ></asp:CompareValidator>
                        Estado:
                    </span>
                </td>
                <td colspan="3">
                    <span>
                        <%--<asp:RequiredFieldValidator ID="rfvMunNot" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" CssClass="moral"
                            ForeColor="Red" ErrorMessage="Campo Municipio (Constitución de la Persona Moral) obligatorio"
                            ControlToValidate="hddMunNot" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        <asp:CustomValidator ID="cuvhddMunNot" runat="server" Font-Size="12px" CssClass="moral" Font-Bold="true" ForeColor="Red" ClientValidationFunction="validaHdd" Text="*" 
                        ErrorMessage="Campo Municipio (Domicilio Fiscal) obligatorio" Display="Dynamic" ToolTip="hddMunNot" >
                        </asp:CustomValidator>
                        Municipio:
                    </span>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:DropDownList ID="cboEdoNot" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:HiddenField ID="hddEdoNot" runat="server" />
                    <asp:DropDownList ID="cboMunNot" runat="server"></asp:DropDownList>
                    <asp:HiddenField ID="hddMunNot" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNumEscRepleg" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" CssClass="moral"
                            ForeColor="Red" ErrorMessage="Campo Número de Escritura de Nombramiento de Representante Legal obligatorio"
                            ControlToValidate="txtNumEscRepleg" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revNumEscRepleg" runat="server" Text="*M" Font-Bold="true" Font-Size="Larger" CssClass="moral"
                            ForeColor="Red" ErrorMessage="Campo Número de Escritura de Nombramiento de Representante Legal máximo 50 caracteres numéricos"
                            ControlToValidate="txtNumEscRepleg" Display="Dynamic" ValidationExpression="^[0-9]{1,50}$" />
                        Número de Escritura de Nombramiento de Representante Legal:
                    </span>
                </td>
                <td colspan="3">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvFescRepleg" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" CssClass="moral"
                            ForeColor="Red" ErrorMessage="Campo Fecha de Escritura de Nombramiento de Representante Legal obligatorio"
                            ControlToValidate="txtFescRepleg" Display="Dynamic"></asp:RequiredFieldValidator>
                        Fecha de Escritura de Nombramiento de Representante Legal:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNumEscRepleg" MaxLength="50" CssClass="wd100" runat="server" Text=""></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtFescRepleg" MaxLength="10" CssClass="wd75 fecha" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlGral2" runat="server" CssClass="frmAmbos">
        <table>
            <tr>
                <th colspan="3">
                    <label id="lblTitDatPer">Datos Personales</label>
                </th>
            </tr>
            <tr>
                <td class="wd270">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNomRfcPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Nombre (Datos Personales) obligatorio"
                            ControlToValidate="txtNomRfcPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Nombre:
                    </span>
                </td>
                <td class="wd300">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvPatRfcPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Apellido Paterno (Datos Personales) obligatorio"
                            ControlToValidate="txtPatRfcPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Apellido Paterno:
                    </span>
                </td>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvMatRfcPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Apellido Materno (Datos Personales) obligatorio"
                            ControlToValidate="txtMatRfcPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Apellido Materno:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNomRfcPfis" MaxLength="75" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPatRfcPfis" MaxLength="50" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtMatRfcPfis" MaxLength="50" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvFechaNacPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Fecha de Nacimiento (Datos Personales) obligatorio"
                            ControlToValidate="txtFechaNacPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Fecha de Nacimiento
                    </span>
                </td>
                <td colspan="2">
                    <span>
                        <asp:CompareValidator ID="rfvEdoCivPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Estado Civil (Datos Personales) obligatorio"
                            ControlToValidate="cboEdoCivPfis" Display="Dynamic" Operator="NotEqual" ValueToCompare="Seleccionar..."></asp:CompareValidator>
                        Estado Civil
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtFechaNacPfis" MaxLength="10" CssClass="wd75 fecha" runat="server" Text=""></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="cboEdoCivPfis" runat="server">
                        <asp:ListItem Text="Seleccionar..." Value="Seleccionar..." Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Soltero(a)" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Casado(a)" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Unión libre" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Divorciado(a)" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Viudo(a)" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <th colspan="4">
                    <label id="lblTitDomPar">Domicilio Particular</label>
                </th>
            </tr>
            <tr>
                <td class="wd250">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvCalleDparPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Calle (Domicilio Particular) obligatorio"
                            ControlToValidate="txtCalleDparPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Calle:
                    </span>
                </td>
                <td class="wd200">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvNoExtDparPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Num. Exterior (Domicilio Particular) obligatorio"
                            ControlToValidate="txtNoExtDparPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Num. Ext.:
                    </span>
                </td>
                <td class="wd200">
                    <span>Num. Int:
                    </span>
                </td>
                <td class="wd200">
                    <span>
                        <asp:RequiredFieldValidator ID="rfvColDparPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Num. Interior (Domicilio Particular) obligatorio"
                            ControlToValidate="txtColDparPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        Colonia/Fraccionamiento:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCalleDparPfis" MaxLength="150" CssClass="wd250" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNoExtDparPfis" MaxLength="6" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNoIntDparPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtColDparPfis" MaxLength="150" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvCPDparPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Código Postal (Domicilio Particular) obligatorio"
                            ControlToValidate="txtCPDparPfis" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCPDparPfis" runat="server" Text="*M" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Código Postal mínimo 5 caracteres numéricos"
                            ControlToValidate="txtCPDparPfis" Display="Dynamic" ValidationExpression="^[0-9]{5,5}$" />
                        C.P.:
                    </span>
                </td>
                <td>
                    <span>
                        <asp:CompareValidator ID="covEdoDparPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger" 
                                ForeColor="Red" ErrorMessage="Campo Estado (Domicilio Particular) obligatorio"
                                ControlToValidate="cboEdoDparPfis" Display="Dynamic" Operator="NotEqual" ValueToCompare="Seleccionar..." ></asp:CompareValidator>
                        Estado:
                    </span>
                </td>
                <td colspan="2">
                    <span>                        
                        <asp:CustomValidator ID="cuvhddMunDparPfis" runat="server" Font-Size="12px"  Font-Bold="true" ForeColor="Red" ClientValidationFunction="validaHdd" Text="*" 
                        ErrorMessage="Campo Municipio (Domicilio Fiscal) obligatorio" Display="Dynamic" ToolTip="hddMunDparPfis" >
                        </asp:CustomValidator>
                        Municipio:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCPDparPfis" MaxLength="5" CssClass="wd50" runat="server" Text=""></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="cboEdoDparPfis" Width="216" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:HiddenField ID="hddEdoDparPfis" runat="server" />
                    <asp:DropDownList ID="cboMunDparPfis" CssClass="wd200" runat="server"></asp:DropDownList>
                    <asp:HiddenField ID="hddMunDparPfis" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:RegularExpressionValidator ID="revTelParPfis" runat="server" Text="*M" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Teléfono Particular solo caracteres numéricos"
                            ControlToValidate="txtTelParPfis" Display="Dynamic" ValidationExpression="^\d*$" />
                        Teléfono Particular:
                    </span>
                </td>
                <td>
                    <span>
                        <asp:RegularExpressionValidator ID="revTelCelPfis" runat="server" Text="*M" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ErrorMessage="Campo Teléfono Celular solo caracteres numéricos"
                            ControlToValidate="txtTelCelPfis" Display="Dynamic" ValidationExpression="^\d*$" />
                        Teléfono Celular:
                    </span>
                </td>
                <td colspan="2">
                    <span>
                        <asp:RegularExpressionValidator ID="revMailPfis" runat="server" Text="*" Font-Bold="true" Font-Size="Larger"
                            ForeColor="Red" ControlToValidate="txtMailPfis" ErrorMessage="Campo Correo electrónico invalido"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        Correo electrónico:
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTelParPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtTelCelPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtMailPfis" CssClass="wd200" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="centrado">                    
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>                    
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

