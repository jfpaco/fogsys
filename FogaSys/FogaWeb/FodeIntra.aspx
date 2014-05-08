<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="FodeIntra.aspx.cs" Inherits="FodeIntra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/fileupload.js"></script>
    <script src="Controlador/FodeIntra.js"></script>        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1">
        <tr>
            <th colspan="2">Requisitos para la obtención de crédito
            </th>
        </tr>
        <tr>
            <td>Carta Solicitud de Financiamiento 
            </td>
            <td style="width: 430px;">
                <asp:RadioButtonList ID="rdo_fode_soli_fina" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Formato de solicitud
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_forma_soli" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Programa de Inversión de Crédito
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_prg_inver" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Cotizaciones
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_cot" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile" runat="server"></span>
                <asp:HiddenField ID="hdd_fode_cot" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Referencias Comerciales
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_ref_com" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Estado de Cuenta 1
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_edo_cuent_1" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_edo_cuent_1" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Estado de Cuenta 2
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_edo_cuent_2" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_edo_cuent_2" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Estado de Cuenta 3
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_edo_cuent_3" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_edo_cuent_3" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Copia de la Escritura de los Bienes
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_escr_bien" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Imagen de la Copia de Escritura de los Bienes
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_bien" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_bien" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Certificado de Libertad de Gravamen, Sección de la Propiedad y Comercio
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_grav" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Imagen del Certificado
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_grav" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_grav" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Avalúo o Estimación del Valor de las Garantías
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_aval_garant" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Imagen del Avalúo
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_aval" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_aval" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Estado Financiero del Ultimo Ejercicio
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_edo_fin" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Imagen del Estado Financiero
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_edo_fin" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_edo_fin" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Garantes
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_garantes" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Imagen del Acta de Matrimonio
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_mat" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_mat" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Identificación Oficial 1
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_id_1" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_id_1" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Identificación Oficial 2
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_id_2" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_id_2" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Acta de Nacimiento 1
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_act_nac_1" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_act_nac_1" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Acta de Nacimiento 2
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_act_nac_2" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_act_nac_2" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Persona Moral: Acta Constitutiva y poderes
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_act_const" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Acta Constitutiva
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_act_const" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_act_const" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Poderes
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_pod" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_pod" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Acta de Nacimiento
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_soc_act_nac" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_soc_act_nac" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Identificación Oficial
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_soc_id" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_soc_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Comprobante de Domicilio Particular
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_soc_com_dom" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_soc_com_dom" runat="server" />                 
            </td>
        </tr>
        <tr>
            <td>Curriculum Vitae
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_soc_cv" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_soc_cv" runat="server" />                
            </td>
        </tr>

        <tr>
            <td>Documentos Fiscales
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_doc_fisc" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Comprobante de Domicilio Fiscal y/o Negocio
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_dom_fisc" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_dom_fisc" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Copia RFC
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_rfc" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_rfc" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Copia Licencia Municipal
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_lic_muni" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_lic_muni" runat="server" />                
            </td>
        </tr>
        <tr>
            <td>Afiliación a Canacintra
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_afil_cana" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_afil_cana" runat="server" />                
            </td>
        </tr>

        <tr>
            <td>Comprobante de Pagos de Impuesto Sobre Nomina
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_comp_pag" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Copia del Comprobante de Pagos de Impuesto Sobre Nomina
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_arch_comp_pag" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_arch_comp_pag" runat="server" />                
            </td>
        </tr>

        <tr>
            <td>Visita Previa de Reconocimiento
            </td>
            <td>
                <asp:RadioButtonList ID="rdo_fode_visit_prev" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Archivos de Visita Previa
            </td>
            <td>
                <div class="uploadStatus"></div>
                <asp:Button ID="fup_fode_fot_reco" runat="server" Text="Subir" CssClass="uploadButton" />
                <span class="uploadedFile"></span>
                <asp:HiddenField ID="hdd_fode_fot_reco" runat="server" />                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Button" OnClick="btnGuardar_Click" />
            </td>
        </tr>
    </table>            
</asp:Content>