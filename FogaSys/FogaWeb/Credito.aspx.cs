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

public partial class Credito : System.Web.UI.Page
{
    #region variables

    private static DataSet ds = new DataSet();

    #endregion

    #region metodos

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

    protected void cargaDatosGral(long folio)
    {
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
            foreach (DataRow fila in tblResultado.Rows)
            {
                txtNomComercial.Text = fila["Nom_comercial"].ToString();
                txtRFC.Text = fila["RFC"].ToString();
                txtProducServi.Text = fila["Prod_Serv"].ToString();
                DateTime altaSat = new DateTime();
                altaSat = Convert.ToDateTime(fila["Alta_SAT"].ToString());
                string fechaAlta = String.Format("{0:dd/MM/yyyy}", altaSat);

                txtFaltaSat.Text = fechaAlta.Substring(0, 10);
                if (fila["Tipo_RFC"].ToString() == "F") {
                    lblTipoPersona.Text = "Fisica";
                }
                else
                {
                    lblTipoPersona.Text = "Moral";
                }

            }
        }
    }

    protected void cargaActSCIAN(long folio)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetActividad";
            cmd.Parameters.AddWithValue("@Folio", folio);            
            cmd.Parameters.AddWithValue("@Tipo", lblTipoPersona.Text.Substring(0,1));
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);

            grdActividadSCIAN.DataSource = tblResultado;
            grdActividadSCIAN.DataBind();

        }
    }

    protected void cargaDatosPerFisica(long folio)
    {
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

    protected void cargaDatosPerMoral(long folio)
    {
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

    private DataTable creaTablaAct()
    {
        DataTable tblTemp = new DataTable();
        tblTemp.Columns.Add("CrediAcreed");
        tblTemp.Columns.Add("CrediMonto");
        tblTemp.Columns.Add("CrediFechLiquid");
        tblTemp.Columns.Add("CrediSaldoActual");        
        return tblTemp;
    }

    private void cargaGrdCrediAnteced()
    {
        grdCrediAnteced.DataSource = ((DataTable)Session["tblAnte"]).DefaultView;
        grdCrediAnteced.DataBind();
    }
    #endregion

    #region eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList[] cboEstados = new DropDownList[3];
            cboEstados[0] = cboEdoDfisPfis;
            cboEstados[1] = cboEdoNot;
            cboEstados[2] = cboEdoDparPfis;
            cargaEstados(cboEstados);

            //Carganis tabla de Antecedentes Crediticios
            DataTable tblAct = new DataTable();
            tblAct = creaTablaAct();
            Session["tblAnte"] = tblAct;
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
                long folio = Convert.ToInt64(lblFolio.Text);
                cargaDatosGral(folio);
                cargaActSCIAN(folio);
                if (lblTipoPersona.Text.Substring(0,1) == "F")
                    cargaDatosPerFisica(folio);
                if (lblTipoPersona.Text.Substring(0, 1) == "M")
                    cargaDatosPerMoral(folio);
            }
            else
            {
                Response.Redirect("ModificarProspecto.aspx");
            }
        }
    }

    

    protected void btnAgregarCrediAnteced_Click(object sender, EventArgs e)
    {
        DataRow row;

        DataTable tblAnte = (DataTable)Session["tblAnte"];

        bool existe = false;

        foreach (DataRow filas in tblAnte.Rows)
        {
            if (txtCrediAcreed.Text == filas[0].ToString())
            {
                existe = true;
            }
        }


        if (!existe)
        {
            row = tblAnte.NewRow();

            row["CrediAcreed"] = txtCrediAcreed.Text.Trim();
            row["CrediMonto"] = txtCrediMonto.Text.Trim();
            row["CrediFechLiquid"] = txtCrediFechLiquid.Text.Trim();
            row["CrediSaldoActual"] = txtCrediSaldoActual.Text.Trim();

            tblAnte.Rows.Add(row);

            cargaGrdCrediAnteced();
        }
    }
    
    protected void grdCrediAnteced_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ((DataTable)Session["tblAnte"]).Rows.RemoveAt(index);
            cargaGrdCrediAnteced();
            
        }
    }

    #endregion
    protected void cboDescTcred_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}