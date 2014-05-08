using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Text;
using System.Collections.Specialized;

public partial class Prospecto : System.Web.UI.Page
{
    #region variables

    private static DataSet ds = new DataSet();

    #endregion

    #region metodos

    private void cargaGrdActSCIAN() {
        grdActividadSCIAN.DataSource = ((DataTable)Session["tblAct"]).DefaultView;
        grdActividadSCIAN.DataBind();
    }
    private void cargaEstados(DropDownList[] cbo)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdEdo, Estado FROM TC_Estado";
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            cbo[0].Items.Clear();
            cbo[0].Items.Add("Seleccionar...");
            cbo[0].DataSource = tblResultado;
            cbo[0].DataTextField = "Estado";
            cbo[0].DataValueField = "IdEdo";
            cbo[0].DataBind();

            cbo[1].Items.Clear();
            cbo[1].Items.Add("Seleccionar...");
            cbo[1].DataSource = tblResultado;
            cbo[1].DataTextField = "Estado";
            cbo[1].DataValueField = "IdEdo";
            cbo[1].DataBind();

            cbo[2].Items.Clear();
            cbo[2].Items.Add("Seleccionar...");
            cbo[2].DataSource = tblResultado;
            cbo[2].DataTextField = "Estado";
            cbo[2].DataValueField = "IdEdo";
            cbo[2].DataBind();


        }
    }
    private DataTable creaTablaAct()
    {
        DataTable tblTemp = new DataTable();
        tblTemp.Columns.Add("IdClase");
        tblTemp.Columns.Add("Clase");
        tblTemp.Columns.Add("SubRama");
        tblTemp.Columns.Add("Rama");
        tblTemp.Columns.Add("SubSector");
        tblTemp.Columns.Add("Sector");
        tblTemp.Columns.Add("Porcentaje");

        return tblTemp;
    }
    protected string guardaDatosGral()
    {
        StringBuilder error = new StringBuilder();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spDatosGrales";
            cnn.Open();
            if (lblFolio.Text == "Nuevo")
            {                
                
            }
            else {
                cmd.Parameters.AddWithValue("@FOLIO", Convert.ToInt64(lblFolio.Text));                
            }
            cmd.Parameters.AddWithValue("@NOM_COMERCIAL", txtNomComercial.Text.Trim());

            //Validacion RFC
            if (Validacion.valRFC(txtRFC.Text.Trim()))
                cmd.Parameters.AddWithValue("@RFC", txtRFC.Text.Trim());
            else
                error.Append("Error en el RFC\n");                        
                
            cmd.Parameters.AddWithValue("@TIPO_RFC", rdoTipoPersona.SelectedValue);
            

            cmd.Parameters.AddWithValue("@PRODUC_SERV", txtProducServi.Text.Trim());
            //Validación Fecha Alta SAT
            if (txtFaltaSat.Text.Trim() != string.Empty)
            {
                if (Validacion.valFecha(txtFaltaSat.Text.Trim()))
                {
                    DateTime fecha = DateTime.ParseExact(txtFaltaSat.Text.Trim(), "dd/MM/yyyy", null);
                    cmd.Parameters.AddWithValue("@ALTA_SAT", fecha);
                }
                else
                {
                    error.Append("Error en formato de la fecha\n");
                }
            }

            SqlParameter mensaje = new SqlParameter();
            mensaje.ParameterName = "@MENSAJE";
            mensaje.SqlDbType = SqlDbType.NVarChar;
            mensaje.SqlValue = "";
            mensaje.Size = 124;
            mensaje.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(mensaje);

            //Checamos que no se hayan producido errores
            if (error.ToString().Trim() == string.Empty)
            {
                string consultaValor = cmd.ExecuteNonQuery().ToString();
                cnn.Close();
                string msjID = (string)cmd.Parameters["@MENSAJE"].Value;
                if (consultaValor == "1")
                {
                    if (Convert.ToInt64(msjID) > 0)
                    {
                        //Insertado correctamente
                       // lblError.Text += "Valor consultaValor: " + consultaValor + " MsjID: " + msjID;
                        error.Append(msjID);
                    }
                    else
                    {
                        error.Append("Error al convertir msjID\n");
                    }
                }
                else
                {
                    error.Append("Error en la ejecución de la consulta\n");
                }
            }            
        }
        return error.ToString();
    }
    protected void cargaDatosGral(long folio) {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetDatosGrales";
            cmd.Parameters.AddWithValue("@Folio", folio);
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            foreach (DataRow fila in tblResultado.Rows) {
                txtNomComercial.Text = fila["Nom_comercial"].ToString();
                txtRFC.Text = fila["RFC"].ToString();
                txtProducServi.Text = fila["Prod_Serv"].ToString();
                DateTime altaSat = new DateTime();
                altaSat = Convert.ToDateTime(fila["Alta_SAT"].ToString());
                string fechaAlta = String.Format("{0:dd/MM/yyyy}", altaSat); 

                txtFaltaSat.Text = fechaAlta.Substring(0,10);
                rdoTipoPersona.SelectedValue = fila["Tipo_RFC"].ToString();
            }
        }
    }
    protected string guardaActSCIAN(long folio){
        StringBuilder error = new StringBuilder();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            if (grdActividadSCIAN.Rows.Count > 0)
            {
                for (int i = 0; i <= grdActividadSCIAN.Rows.Count - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spAltaActividad";
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@Folio", folio);
                    
                    cmd.Parameters.AddWithValue("@Tipo", rdoTipoPersona.SelectedValue);

                    //Validacion Id Clase
                    string idClase = grdActividadSCIAN.Rows[i].Cells[1].Text.Trim();
                    if (Validacion.valNumerico(idClase))
                        cmd.Parameters.AddWithValue("@IdClase", Convert.ToInt64(idClase));
                    else
                        error.Append("Error en la Actividad\n");
                    cmd.Parameters.AddWithValue("@Descripcion", Server.HtmlDecode(grdActividadSCIAN.Rows[i].Cells[2].Text.Trim()));
                    //Validacion Porcentaje
                    TextBox txtPorcentaje;
                    txtPorcentaje = (TextBox)grdActividadSCIAN.Rows[i].Cells[7].FindControl("txtPorcentaje");
                    if (Validacion.valNumerico(txtPorcentaje.Text.Trim()))
                        cmd.Parameters.AddWithValue("@Porcentaje", int.Parse(txtPorcentaje.Text.Trim()));
                    else
                        error.Append("Error en los porcentajes\n");

                    //Checamos que no se hayan producido errores
                    if (error.ToString().Trim() == string.Empty)
                    {
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        //string msjID = (string)cmd.Parameters["@MENSAJE"].Value;
                        //error.Append(msjID);
                    }
                    else
                    {
                        cnn.Close();
                    }
                }
            }
        }
        return error.ToString();
    }
    protected void cargaActSCIAN(long folio) {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetActividad";
            cmd.Parameters.AddWithValue("@Folio", folio);
            cmd.Parameters.AddWithValue("@Tipo", rdoTipoPersona.SelectedValue);
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            DataRow row;

            DataTable tblAct = (DataTable)Session["tblAct"];

            foreach (DataRow fila in tblResultado.Rows)
            {
                row = tblAct.NewRow();

                row["IdClase"] = fila["IdClase"].ToString();
                row["Clase"] = Server.HtmlDecode(fila["Clase"].ToString());
                row["SubRama"] = Server.HtmlDecode(fila["SubRama"].ToString());
                row["Rama"] = Server.HtmlDecode(fila["Rama"].ToString());
                row["SubSector"] = Server.HtmlDecode(fila["SubSector"].ToString());
                row["Sector"] = Server.HtmlDecode(fila["Sector"].ToString());
                row["Porcentaje"] = fila["Porcentaje"].ToString(); ;

                tblAct.Rows.Add(row);                
            }            

        }
    }

    protected string guardaDatosPerFisica(long id)
    {
        StringBuilder error = new StringBuilder();
        error.Append(guardaActSCIAN(id));
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            if (error.ToString() == string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spPerFisicas";
                cnn.Open();                
                cmd.Parameters.AddWithValue("@FOLIO", id);
                cmd.Parameters.AddWithValue("@PATERNO", txtPatRfcPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@MATERNO", txtMatRfcPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NOMBRE", txtNomRfcPfis.Text.Trim());
                //Validacion Fecha Nacimiento
                if (txtFechaNacPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valFecha(txtFechaNacPfis.Text.Trim()))
                    {
                        DateTime fecha = DateTime.ParseExact(txtFechaNacPfis.Text.Trim(), "dd/MM/yyyy", null);
                        cmd.Parameters.AddWithValue("@FECHA_NAC", fecha);
                    }
                    else
                    {
                        error.Append("Error en formato de la fecha\n");
                    }
                }
                if (cboEdoCivPfis.SelectedItem.Text != "Seleccionar...")
                {
                    cmd.Parameters.AddWithValue("@EDO_CIVIL", int.Parse(cboEdoCivPfis.SelectedValue));
                }
                else
                {
                    error.Append("Error no a seleccionado el Estado Civil");
                }

                cmd.Parameters.AddWithValue("@CALLE_FIS", txtCalleDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_EXT_FIS", txtNoExtDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_INT_FIS", txtNoIntDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@COLONIA_FIS", txtColDfisPfis.Text.Trim());
                //Validacion C.P. Fiscal
                if (Validacion.valNumerico(txtCPDfisPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@CP_FIS", Convert.ToInt16(txtCPDfisPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en C.P. Fisica");
                }
                //Validacion combo Municipio
                if (!string.IsNullOrEmpty(hddMunDfisPfis.Value))
                    cmd.Parameters.AddWithValue("@MUNICIPIO_FIS", hddMunDfisPfis.Value);
                else
                    error.Append("Error no se a seleccionado Municipio");

                //Validacion combo Estado
                if (cboEdoDfisPfis.SelectedItem.Text != "Seleccionar...")
                    cmd.Parameters.AddWithValue("@ESTADO_FIS", cboEdoDfisPfis.SelectedValue);
                else
                    error.Append("Error no se a seleccionado Estado");

                //Validacion Teléfono
                if (Validacion.valNumerico(txtTelDfisPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@TEL_FIS", Convert.ToInt64(txtTelDfisPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en numero Telefónico");
                }
                cmd.Parameters.AddWithValue("@CALLE_PAR", txtCalleDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_EXT_PAR", txtNoExtDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_INT_PAR", txtNoIntDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@COLONIA_PAR", txtColDparPfis.Text.Trim());
                //Validacion C.P. Particular
                if (Validacion.valNumerico(txtCPDparPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@CP_PAR", Convert.ToInt16(txtCPDparPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en C.P. Particular");
                }

                //Validacion combo Municipio
                if (!string.IsNullOrEmpty(hddMunDparPfis.Value))
                    cmd.Parameters.AddWithValue("@MUNICIPIO_PAR", hddMunDparPfis.Value);
                else
                    error.Append("Error no a seleccionado Municipio");

                //Validacion combo Estado
                if (cboEdoDparPfis.SelectedItem.Text.Trim() != "Seleccionar...")
                    cmd.Parameters.AddWithValue("@ESTADO_PAR", cboEdoDparPfis.SelectedValue);
                else
                    error.Append("Error no a seleccionado Estado");
                //Validacion Tel. Particular
                if (txtTelParPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valNumerico(txtTelParPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@TEL_PAR", Convert.ToInt64(txtTelParPfis.Text.Trim()));
                    }
                    else
                    {
                        error.Append("Error en teléfono particular");
                    }
                }
                //Validación Cel. Particular
                if (txtTelCelPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valNumerico(txtTelCelPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@CEL_PAR", Convert.ToInt64(txtTelCelPfis.Text.Trim()));
                    }
                    else
                    {
                        error.Append("Error en teléfono celular");
                    }
                }
                //Validacion Correo
                if (txtMailPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valCorreo(txtMailPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@CORREO", txtMailPfis.Text.Trim());
                    }
                }
                //Checamos que no se hayan producido errores
                if (error.ToString().Trim() == string.Empty)
                {
                    string resultado = cmd.ExecuteNonQuery().ToString();
                    cnn.Close();                    
                    error.Append(resultado);                    
                }
            }
        }
        return error.ToString();
    }

    protected void cargaDatosPerFisica(long folio) {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetPerFisica";
            cmd.Parameters.AddWithValue("@Folio", folio);
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            foreach (DataRow fila in tblResultado.Rows)
            {
                txtCalleDfisPfis.Text = fila["CALLE_FIS"].ToString();
                txtNoExtDfisPfis.Text = fila["NUM_EXT_FIS"].ToString();
                txtNoIntDfisPfis.Text = fila["NUM_INT_FIS"].ToString();
                txtColDfisPfis.Text = fila["COLONIA_FIS"].ToString();
                txtCPDfisPfis.Text = fila["CP_FIS"].ToString();
                //COMBO ESTADO FISICA
                cboEdoDfisPfis.SelectedValue = fila["ESTADO_FIS"].ToString();
                //MUNICIPIO
                hddMunDfisPfis.Value = fila["MUNICIPIO_FIS"].ToString();
                txtTelDfisPfis.Text = fila["TEL_FIS"].ToString();
                txtNomRfcPfis.Text = fila["NOMBRE"].ToString();
                txtPatRfcPfis.Text = fila["PATERNO"].ToString();
                txtMatRfcPfis.Text = fila["MATERNO"].ToString();

                DateTime fechaNac = new DateTime();
                fechaNac = Convert.ToDateTime(fila["FECHA_NAC"].ToString());
                txtFechaNacPfis.Text = String.Format("{0:dd/MM/yyyy}", fechaNac);

                cboEdoCivPfis.SelectedValue = fila["EDO_CIVIL"].ToString();
                txtCalleDparPfis.Text = fila["CALLE_PAR"].ToString();
                txtNoExtDparPfis.Text = fila["NUM_EXT_PAR"].ToString();
                txtNoIntDparPfis.Text = fila["NUM_INT_PAR"].ToString();
                txtColDparPfis.Text = fila["COLONIA_PAR"].ToString();
                txtCPDparPfis.Text = fila["CP_PAR"].ToString();
                //COMBO ESTADO PARTICULAR
                cboEdoDparPfis.SelectedValue = fila["ESTADO_PAR"].ToString();
                //MUNICIPIO
                hddMunDparPfis.Value = fila["MUNICIPIO_PAR"].ToString();

                txtTelParPfis.Text = fila["TEL_PAR"].ToString();
                txtTelCelPfis.Text = fila["CEL_PAR"].ToString();
                txtMailPfis.Text = fila["CORREO"].ToString();             
            }
        }
    }
    protected string guardaDatosPerMoral(long id)
    {
        StringBuilder error = new StringBuilder();
        error.Append(guardaActSCIAN(id));
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            if (error.ToString() == string.Empty)
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString);
                cmd.CommandText = "spPerMorales";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cnn.Open();
                cmd.Parameters.AddWithValue("@FOLIO", id);
                cmd.Parameters.AddWithValue("@PATERNO", txtPatRfcPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@MATERNO", txtMatRfcPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NOMBRE", txtNomRfcPfis.Text.Trim());
                //Validacion Fecha Nacimiento
                if (txtFechaNacPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valFecha(txtFechaNacPfis.Text.Trim()))
                    {
                        DateTime fecha = DateTime.ParseExact(txtFechaNacPfis.Text.Trim(), "dd/MM/yyyy", null);
                        cmd.Parameters.AddWithValue("@FECHA_NAC", fecha);
                    }
                    else
                    {
                        error.Append("Error en formato de la fecha\n");
                    }
                }

                cmd.Parameters.AddWithValue("@EDO_CIVIL", cboEdoCivPfis.SelectedValue);
                cmd.Parameters.AddWithValue("@CALLE_FISCAL", txtCalleDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_EXT_FISCAL", txtNoExtDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_INT_FISCAL", txtNoIntDfisPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@COLONIA_FISCAL", txtColDfisPfis.Text.Trim());

                //Validacion C.P. Fiscal
                if (Validacion.valNumerico(txtCPDfisPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@CP_FISCAL", Convert.ToInt16(txtCPDfisPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en C.P. Fisica");
                }
                //Validacion combo Municipio
                if (!string.IsNullOrEmpty(hddMunDfisPfis.Value))
                    cmd.Parameters.AddWithValue("@MUNICIPIO_FISCAL", hddMunDfisPfis.Value);
                else
                    error.Append("Error no a seleccionado Municipio");

                //Validacion combo Estado
                if (cboEdoDfisPfis.SelectedItem.Text != "Seleccionar...")
                    cmd.Parameters.AddWithValue("@ESTADO_FISCAL", cboEdoDfisPfis.SelectedValue);
                else
                    error.Append("Error no a seleccionado Estado");

                //Validacion Teléfono
                if (Validacion.valNumerico(txtTelDfisPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@TEL_FISCAL", Convert.ToInt64(txtTelDfisPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en numero Telefónico");
                }
                cmd.Parameters.AddWithValue("@CALLE_REP_LEGAL", txtCalleDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_EXT_REP_LEGAL", txtNoExtDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_INT_REP_LEGAL", txtNoIntDparPfis.Text.Trim());
                cmd.Parameters.AddWithValue("@COLONIA_REP_LEGAL", txtColDparPfis.Text.Trim());

                //Validacion C.P. Representante Legal
                if (Validacion.valNumerico(txtCPDparPfis.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@CP_REP_LEGAL", Convert.ToInt16(txtCPDparPfis.Text.Trim()));
                }
                else
                {
                    error.Append("Error en C.P. Representante Legal");
                }

                //Validacion combo Municipio
                if (!string.IsNullOrEmpty(hddMunDparPfis.Value))
                    cmd.Parameters.AddWithValue("@MUNICIPIO_REP_LEGAL", hddMunDparPfis.Value);
                else
                    error.Append("Error no a seleccionado Municipio");

                //Validacion combo Estado
                if (cboEdoDparPfis.SelectedItem.Text != "Seleccionar...")
                    cmd.Parameters.AddWithValue("@ESTADO_REP_LEGAL", cboEdoDparPfis.SelectedValue);
                else
                    error.Append("Error no a seleccionado Estado");

                //Validacion Tel. Particular
                if (txtTelParPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valNumerico(txtTelParPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@TEL_REP_LEGAL", Convert.ToInt64(txtTelParPfis.Text.Trim()));
                    }
                    else
                    {
                        error.Append("Error en teléfono particular");
                    }
                }

                //Validación Cel. Particular
                if (txtTelCelPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valNumerico(txtTelCelPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@CEL_REP_LEGAL", Convert.ToInt64(txtTelCelPfis.Text.Trim()));
                    }
                    else
                    {
                        error.Append("Error en teléfono celular");
                    }
                }

                //Validacion Correo
                if (txtMailPfis.Text.Trim() != string.Empty)
                {
                    if (Validacion.valCorreo(txtMailPfis.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@CORREO", txtMailPfis.Text.Trim());
                    }
                }

                cmd.Parameters.AddWithValue("@NOTARIO", txtNotEp.Text.Trim());

                //Validacion combo Municipio
                if (!string.IsNullOrEmpty(hddMunNot.Value))
                    cmd.Parameters.AddWithValue("@MUNICIPIO_NOT", hddMunNot.Value);
                else
                    error.Append("Error no a seleccionado Municipio");

                //Validacion combo Estado
                if (cboEdoNot.SelectedItem.Text != "Seleccionar...")
                    cmd.Parameters.AddWithValue("@ESTADO_NOT", cboEdoNot.SelectedValue);
                else
                    error.Append("Error no a seleccionado Estado");

                cmd.Parameters.AddWithValue("@NUM_NOT", txtNumNot.Text.Trim());
                cmd.Parameters.AddWithValue("@NUM_ESCRITURA", txtNumEscEp.Text.Trim());

                //Validacion Fecha de Escrituracion
                if (txtFescPub.Text.Trim() != string.Empty)
                {
                    if (Validacion.valFecha(txtFescPub.Text.Trim()))
                    {
                        DateTime fecha = DateTime.ParseExact(txtFescPub.Text.Trim(), "dd/MM/yyyy", null);
                        cmd.Parameters.AddWithValue("@FECHA_ESCRITURA", fecha);
                    }
                    else
                    {
                        error.Append("Error en formato de la fecha\n");
                    }
                }

                cmd.Parameters.AddWithValue("@NUM_ESCRITURA_REP_LEGAL", txtNumEscRepleg.Text.Trim());

                //Validacion Fecha de Nombramiento de Representante Legal
                if (txtFescRepleg.Text.Trim() != string.Empty)
                {
                    if (Validacion.valFecha(txtFescRepleg.Text.Trim()))
                    {
                        DateTime fecha = DateTime.ParseExact(txtFescRepleg.Text.Trim(), "dd/MM/yyyy", null);
                        cmd.Parameters.AddWithValue("@FECHA_PODER_REP_LEGAL", fecha);
                    }
                    else
                    {
                        error.Append("Error en formato de la fecha\n");
                    }
                }

                //Checamos que no se hayan producido errores
                if (error.ToString().Trim() == string.Empty)
                {
                    string resultado = cmd.ExecuteNonQuery().ToString();
                    error.Append(resultado);
                    cnn.Close();
                }
            }
        }
        return error.ToString();
    }

    protected void cargaDatosPerMoral(long folio) {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetPerMoral";
            cmd.Parameters.AddWithValue("@Folio", folio);
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            foreach (DataRow fila in tblResultado.Rows)
            {
                txtCalleDfisPfis.Text = fila["CALLE_FISCAL"].ToString();
                txtNoExtDfisPfis.Text = fila["NUM_EXT_FISCAL"].ToString();
                txtNoIntDfisPfis.Text = fila["NUM_INT_FISCAL"].ToString();
                txtColDfisPfis.Text = fila["COLONIA_FISCAL"].ToString();
                txtCPDfisPfis.Text = fila["CP_FISCAL"].ToString();
                //COMBO ESTADO FISICA
                cboEdoDfisPfis.SelectedValue = fila["ESTADO_FISCAL"].ToString();
                //MUNICIPIO
                hddMunDfisPfis.Value = fila["MUNICIPIO_FISCAL"].ToString();
                txtTelDfisPfis.Text = fila["TEL_FISCAL"].ToString();

                txtNumNot.Text = fila["NUM_NOT"].ToString();
                txtNotEp.Text = fila["NOTARIO"].ToString();
                txtNumEscEp.Text = fila["NUM_ESCRITURA"].ToString();

                DateTime fechaEscritura = new DateTime();
                fechaEscritura = Convert.ToDateTime(fila["FECHA_ESCRITURA"].ToString());
                txtFescPub.Text = String.Format("{0:dd/MM/yyyy}", fechaEscritura);
                //COMBO ESTADO NOTARIO
                cboEdoNot.SelectedValue = fila["ESTADO_NOT"].ToString();
                hddMunNot.Value = fila["MUNICIPIO_NOT"].ToString();

                txtNumEscRepleg.Text = fila["NUM_ESCRITURA_REP_LEGAL"].ToString();

                DateTime fechaPoder = new DateTime();
                fechaPoder = Convert.ToDateTime(fila["FECHA_PODER_REP_LEGAL"].ToString());
                txtFescRepleg.Text = String.Format("{0:dd/MM/yyyy}", fechaPoder);

                txtNomRfcPfis.Text = fila["NOMBRE"].ToString();
                txtPatRfcPfis.Text = fila["PATERNO"].ToString();
                txtMatRfcPfis.Text = fila["MATERNO"].ToString();


                DateTime fechaNac = new DateTime();
                fechaNac = Convert.ToDateTime(fila["FECHA_NAC"].ToString());
                txtFechaNacPfis.Text = String.Format("{0:dd/MM/yyyy}", fechaPoder);

                cboEdoCivPfis.SelectedValue = fila["EDO_CIVIL"].ToString();

                txtCalleDparPfis.Text = fila["CALLE_REP_LEGAL"].ToString();
                txtNoExtDparPfis.Text = fila["NUM_EXT_REP_LEGAL"].ToString();
                txtNoIntDparPfis.Text = fila["NUM_INT_REP_LEGAL"].ToString();
                txtColDparPfis.Text = fila["COLONIA_REP_LEGAL"].ToString();
                txtCPDparPfis.Text = fila["CP_REP_LEGAL"].ToString();
                //COMBO ESTADO PARTICULAR
                cboEdoDparPfis.SelectedValue = fila["ESTADO_REP_LEGAL"].ToString();
                //MUNICIPIO
                hddMunDparPfis.Value = fila["MUNICIPIO_REP_LEGAL"].ToString();

                txtTelParPfis.Text = fila["TEL_REP_LEGAL"].ToString();
                txtTelCelPfis.Text = fila["CEL_REP_LEGAL"].ToString();
                txtMailPfis.Text = fila["CORREO"].ToString();
            }
        }
    }
    #endregion

    #region eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string tipo = "";
            if (!string.IsNullOrEmpty(Request.QueryString["tip"]))
            {
                 tipo = Request.QueryString["tip"];
                 //Response.Write(tipo);
                 if (tipo != "nuevo") {
                     if(tipo != "modificar")
                        Response.Redirect("Default.aspx");
                 }
            }            
            
            DropDownList[] cboEstados = new DropDownList[3];
            cboEstados[0] = cboEdoDfisPfis;
            cboEstados[1] = cboEdoNot;
            cboEstados[2] = cboEdoDparPfis;
            cargaEstados(cboEstados);
            //Carganis tabla de Actividad SCIAN
            DataTable tblAct = new DataTable();
            tblAct = creaTablaAct();
            Session["tblAct"] = tblAct;
            Session.Timeout = 100;
            

            StringBuilder displayValues = new StringBuilder();
            NameValueCollection postedValues = Request.Form;
            if (postedValues.AllKeys.Length > 2)
            {
                displayValues.Append(postedValues["ctl00$ContentPlaceHolder1$txtFolio"]);
            }

            if (!string.IsNullOrEmpty(displayValues.ToString()))
            {
                lblFolio.Text = displayValues.ToString();
                long folio = Convert.ToInt64(displayValues.ToString());
                cargaDatosGral(folio);
                cargaActSCIAN(folio);
                if(rdoTipoPersona.SelectedValue == "F")
                    cargaDatosPerFisica(folio);
                if (rdoTipoPersona.SelectedValue == "M")
                    cargaDatosPerMoral(folio);
            }
            else
            {
                lblFolio.Text = "Nuevo";
            }
            cargaGrdActSCIAN();
        }
    }
    protected void btnBuscadorSCIAN_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spConsultaSCIAN";
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@Busqueda", txtBuscadorSCIAN.Text.Trim());
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            grdConsultaSCIAN.DataSource = tblResultado;
            grdConsultaSCIAN.DataBind();
        }
    }
    protected void grdConsultaSCIAN_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Seleccionar")
        {

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow fila = grdConsultaSCIAN.Rows[index];

            DataRow row;

            DataTable tblAct = (DataTable)Session["tblAct"];

            bool existe = false;
            foreach (DataRow filas in tblAct.Rows)
            {
                if (fila.Cells[1].Text == filas[0].ToString())
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                row = tblAct.NewRow();

                row["IdClase"] = fila.Cells[1].Text;
                row["Clase"] = Server.HtmlDecode(fila.Cells[2].Text);
                row["SubRama"] = Server.HtmlDecode(fila.Cells[3].Text);
                row["Rama"] = Server.HtmlDecode(fila.Cells[4].Text);
                row["SubSector"] = Server.HtmlDecode(fila.Cells[5].Text);
                row["Sector"] = Server.HtmlDecode(fila.Cells[6].Text);
                row["Porcentaje"] = "";

                tblAct.Rows.Add(row);
            }

            cargaGrdActSCIAN();

            //this.ClientScript.RegisterStartupScript(this.GetType(), "navigate", "obtieneAncla();", true);
            ScriptManager.RegisterStartupScript(updPnlSCIAN, this.GetType(), "validacion", "getFormulario()", true);
        }
    }
    protected void grdActividadSCIAN_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ((DataTable)Session["tblAct"]).Rows.RemoveAt(index);
            cargaGrdActSCIAN();
            
            ScriptManager.RegisterStartupScript(updPnlSCIAN, this.GetType(), "validacion", "getFormulario()", true);
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {        
        string folio = guardaDatosGral();
        //Validamos el folio
        if (Validacion.valNumerico(folio.Trim()))
        {
            string tipoPer = rdoTipoPersona.SelectedValue;
            long folioNumeric = Convert.ToInt64(folio);
            string resultado = "";            
            if (tipoPer == "F")
            {
                resultado = guardaDatosPerFisica(folioNumeric);
            }
            else if (tipoPer == "M")
            {
                resultado = guardaDatosPerMoral(folioNumeric);
            }
            //Validamos Resultado
            if (resultado == "1")
            {
                Session["folio"] = folio;
                this.ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Guardado Correctamente', 'CuestionarioPreDiagnostico.aspx');", true);
            }
            else
            {
                lblError.Text = resultado.ToString();
                this.ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "msj('Ocurrio un error, verifica los datos');", true);
            }
        }
        else {
            lblError.Text = folio.ToString();
            this.ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "msj('Ocurrio un error, verifica los datos');", true);
        }
    }

    #endregion
}