<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Credito.aspx.cs" Inherits="Credito" ClientIDMode="Static" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.min.js"></script>
    <link href="css/gris/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />
    <script src="Controlador/General.js"></script>
    <script src="Controlador/Credito.js"></script>
    <script src="Scripts/catalogo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="titForm">
        <h1>Alta de Crédito</h1>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <table>
        <tr>
            <th colspan="4">
                <span>Datos Prospecto</span>
            </th>
        </tr>
    </table>
    <div id="tabs" style="margin: 5px 0 5px 0;">
        <ul>
            <li><a href="#datGral">Datos Generales</a></li>
            <li><a href="#actSCIAN">Actividad SCIAN</a></li>
            <li><a href="#domFis">Domicilio Fiscal</a></li>
            <li><a href="#conMoral">Constitución Persona Moral</a></li>
            <li><a href="#datPers">Datos Personales</a></li>
            <li><a href="#domPar">Domicilio Particular</a></li>
        </ul>

        <div id="datGral">
            <table>
                <tr>
                    <td colspan="4" class="derecha">
                        <span><b>Folio: </b></span>
                        <asp:Label ID="lblFolio" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="wd250">
                        <span>Nombre comercial de la empresa                    
                        </span>
                    </td>
                    <td>
                        <asp:Label ID="txtNomComercial" CssClass="wd400 datos" MaxLength="300" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="wd100">
                        <span>RFC
                        </span>
                    </td>
                    <td>
                        <asp:Label ID="txtRFC" runat="server" MaxLength="13" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Principales Productos o Servicios                  
                        </span>
                    </td>
                    <td>
                        <asp:Label ID="txtProducServi" CssClass="wd400" runat="server" MaxLength="500" Text=""></asp:Label>
                    </td>
                    <td>
                        <span>Fecha de alta en SAT
                        </span>
                    </td>
                    <td>
                        <asp:Label ID="txtFaltaSat" CssClass="wd75 fecha" MaxLength="10" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="wd150"><span>Tipo de Persona Fiscal
                    </span>
                    </td>
                    <td class="rdoPersonaFisica radios" colspan="3">
                        <asp:Label ID="lblTipoPersona" CssClass="wd75" runat="server" MaxLength="500" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div id="actSCIAN">
            <asp:GridView ID="grdActividadSCIAN" runat="server" DataKeyNames="IdClase,Porcentaje" AutoGenerateColumns="false">
                <Columns>
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
        </div>

        <div id="domFis">
            <table>
                <tr>
                    <td class="wd250">
                        <span>Calle:</span>
                    </td>
                    <td class="wd200">
                        <span>Num. Ext.:
                        </span>
                    </td>
                    <td class="wd200">
                        <span>Num. Int
                        </span>
                    </td>
                    <td class="wd200">
                        <span>Colonia/Fraccionamiento:
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
                        <span>C.P.:</span>
                    </td>
                    <td>
                        <span>Estado:
                        </span>
                    </td>
                    <td>
                        <span>Municipio:
                        </span>
                    </td>
                    <td>
                        <span>Teléfono Empresa:
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCPDfisPfis" MaxLength="5" CssClass="wd50" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="cboEdoDfisPfis" Width="150" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                        <asp:HiddenField ID="hddEdoDfisPfis" runat="server" />

                        <asp:DropDownList ID="cboMunDfisPfis" CssClass="wd200" runat="server"></asp:DropDownList>
                        <asp:HiddenField ID="hddMunDfisPfis" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelDfisPfis" MaxLength="10" CssClass="wd75" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>

        <div id="conMoral">
            <table>
                <tr>
                    <td class="wd200 justificado">
                        <span>Número de Notario que realizó la escritura pública de Constitución:
                        </span>
                    </td>
                    <td class="wd300 justificado">
                        <span>Nombre del Notario (completo):
                        </span>
                    </td>
                    <td>
                        <span>Número de Escritura Pública de Constitución de la empresa:
                        </span>
                    </td>
                    <td>
                        <span>Fecha de Escrituración:
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
                        <span>Estado:
                        </span>
                    </td>
                    <td colspan="3">
                        <span>Municipio:
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
                        <span>Número de Escritura de Nombramiento de Representante Legal:
                        </span>
                    </td>
                    <td colspan="3">
                        <span>Fecha de Escritura de Nombramiento de Representante Legal:
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
        </div>

        <div id="datPers">
            <table>
                <tr>
                    <td class="wd270">
                        <span>Nombre:
                        </span>
                    </td>
                    <td class="wd300">
                        <span>Apellido Paterno:
                        </span>
                    </td>
                    <td>
                        <span>Apellido Materno:
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
                        <span>Fecha de Nacimiento
                        </span>
                    </td>
                    <td colspan="2">
                        <span>Estado Civil
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
        </div>

        <div id="domPar">
            <table>
                <tr>
                    <td class="wd250">
                        <span>Calle:
                        </span>
                    </td>
                    <td class="wd200">
                        <span>Num. Ext.:
                        </span>
                    </td>
                    <td class="wd200">
                        <span>Num. Int:
                        </span>
                    </td>
                    <td class="wd200">
                        <span>Colonia/Fraccionamiento:
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
                        <span>C.P.:
                        </span>
                    </td>
                    <td>
                        <span>Estado:
                        </span>
                    </td>
                    <td colspan="2">
                        <span>Municipio:
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
                        <span>Teléfono Particular:
                        </span>
                    </td>
                    <td>
                        <span>Teléfono Celular:
                        </span>
                    </td>
                    <td colspan="2">
                        <span>Correo electrónico:
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
            </table>
        </div>
    </div>


    <asp:Panel ID="pnlAnteCredi" runat="server">
        <table>
            <tr>
                <th colspan="2">Antecedentes Crediticios
                </th>
            </tr>
            <tr>
                <td>¿Declara el Prospecto que cuenta con Antecedentes Crediticios?
                </td>
                <td>
                    <asp:RadioButtonList ID="rdoCrediAnteced" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0" Selected="true">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td class="wd200">Nombre de la Persona o Institución que otorgó el crédito
                </td>
                <td>Monto    
                </td>
                <td>Fecha de Liquidación
                </td>
                <td colspan="2">Saldo Actual
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCrediAcreed" runat="server" Text="" CssClass="wd150" />
                </td>
                <td>
                    <asp:TextBox ID="txtCrediMonto" runat="server" Text="" CssClass="wd100" />
                </td>
                <td>
                    <asp:TextBox ID="txtCrediFechLiquid" runat="server" Text="" CssClass="fecha wd75" />
                </td>
                <td>
                    <asp:TextBox ID="txtCrediSaldoActual" runat="server" Text="" CssClass="wd100" />
                </td>
                <td>
                    <asp:Button ID="btnAgregarCrediAnteced" runat="server" Text="Agregar" OnClick="btnAgregarCrediAnteced_Click" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="grdCrediAnteced" runat="server" AutoGenerateColumns="false" CssClass="grid" OnRowCommand="grdCrediAnteced_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="button" Text="Eliminar" CommandName="Eliminar" />
                <asp:BoundField DataField="CrediAcreed" HeaderText="Persona o Institución" HeaderStyle-CssClass="" />
                <asp:BoundField DataField="CrediMonto" HeaderText="Monto" HeaderStyle-CssClass="" />
                <asp:BoundField DataField="CrediFechLiquid" HeaderText="Fecha Liquidación" HeaderStyle-CssClass="" />
                <asp:BoundField DataField="CrediSaldoActual" HeaderText="Saldo Actual" HeaderStyle-CssClass="" />
            </Columns>
        </asp:GridView>

    </asp:Panel>

    <asp:Panel ID="pnlFormEmpPro" runat="server">
        <table>
            <tr>
                <th colspan="2">Formación Empresarial y Profesional
                </th>
            </tr>
            <tr>
                <td class="wd400">
                    <span>Describir a grandes rasgos formación empresarial del Representante Legal o Titular del RFC persona moral
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtFormaEmpresa" runat="server" MaxLength="150" CssClass="wd400"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Describir a grandes rasgos formación profesional del Representante Legal o Titular del RFC persona moral
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtFormaProfes" runat="server" MaxLength="150" CssClass="wd400"></asp:TextBox>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlTipoCredito" runat="server">
        <table>
            <tr>
                <th colspan="2">Formación Empresarial y Profesional
                </th>
            </tr>
            <tr>
                <td class="wd400">Seleccione el Tipo de Crédito Solicitado de acuerdo al Fondo
                </td>
                <td>
                    <asp:DropDownList ID="cboDescTcred" Width="200" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="cboDescTcred_SelectedIndexChanged">
                        <asp:ListItem Value="Seleccionar...">Seleccionar...</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table style="border-top: 0px solid #ccc;">
            <tr>
                <td class="izquierda" colspan="6">Características del Crédito Seleccionado
                </td>
            </tr>
            <tr>
                <td>Monto Máximo
                </td>
                <td>
                    <asp:Label ID="lblTcredFogaMontoMax" runat="server" Text="" CssClass="lblTcredFogaMontoMax"></asp:Label>
                </td>
                <td>Monto Mínimo
                </td>
                <td colspan="3">
                    <asp:Label ID="lblDescMontoMin" runat="server" Text="" CssClass="lblDescMontoMin"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Tasa ordinaria
                </td>
                <td>
                    <asp:Label ID="lblTcredFogaTord" runat="server" Text=""></asp:Label>
                </td>
                <td>Tasa por pronto pago
                </td>
                <td>
                    <asp:Label ID="lblTcredFogaTordPronto" runat="server" Text=""></asp:Label>
                </td>
                <td>Tasa Moratoria
                </td>
                <td>
                    <asp:Label ID="lblDescTasaIncum" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFondeoRecursos" runat="server">
        <table style="border-top: 0px solid #ccc;">
            <tr>
                <td class="wd75">Fondeo
                </td>
                <td>
                    <asp:DropDownList ID="cboDescFondeo" Width="200" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="cboDescFondeo_SelectedIndexChanged">
                        <asp:ListItem Value="Seleccionar...">Seleccionar...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Plazo Mínimo:
                </td>
                <td>
                    <asp:Label ID="lblDescPlazoMin" runat="server" Text="" CssClass="lblDescPlazoMin"></asp:Label>
                </td>
                <td>Plazo Máximo:
                </td>
                <td>
                    <asp:Label ID="lblDescPlazoMax" runat="server" Text="" CssClass="lblDescPlazoMax"></asp:Label>
                </td>
            </tr>            
        </table>
        <table>
            <tr>
                <th colspan="4">
                    Valor del Proyecto, Crédito Solicitado, Plazo y Gracia

                </th>
            </tr>
            <tr>
                <td>
                    Costo total del Proyecto
                </td>
                <td>
                    <asp:TextBox ID="txtCostoProyect" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
                <td>
                    Plazo solicitado para el Pago
                </td>
                <td>
                    <asp:TextBox ID="txtPlazoMeses" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cantidad Solicitada para el Crédito
                </td>
                <td>
                    <asp:TextBox ID="txtMontoSolicit" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
                <td>
                    Periodio de Gracia solicitado
                </td>
                <td>
                    <asp:TextBox ID="txtPlazoGracia" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Recursos Propios para aportar al Proyecto
                </td>
                <td>
                    <asp:TextBox ID="txtRecPropios" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
                <td>
                    Otros recursos para aportar al Proyecto
                </td>
                <td>
                    <asp:TextBox ID="txtOtrosRec" runat="server" MaxLength="15" CssClass="wd100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnAgregarFondeo" runat="server" Text="Agregar" OnClick="btnAgregarFondeo_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ListBox ID="lstFondeo" runat="server" Rows="4" Width="100%"></asp:ListBox>
                </td>
            </tr>
        </table>
    </asp:Panel>



</asp:Content>

