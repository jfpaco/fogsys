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

    private void cargaFondos(DropDownList cbo)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdFondo, DescTipoFondo FROM TC_Fondo";
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tblResultado = new DataTable();
            da.Fill(tblResultado);
            cbo.DataSource = tblResultado;
            cbo.DataTextField = "DescTipoFondo";
            cbo.DataValueField = "IdFondo";
            cbo.DataBind();
        }
    }

    private void getDescFondos(string idFondo)
    {
        if (idFondo == "Seleccionar...")
        {
            lblTcredFogaMontoMax.Text = "";
            lblDescMontoMin.Text = "";
            lblTcredFogaTord.Text = "";
            lblTcredFogaTordPronto.Text = "";
            lblTcredFogaTordPronto.Text = "";

            cboDescFondeo.Items.Clear();
            cboDescFondeo.Items.Add("Seleccionar...");

            lblDescPlazoMin.Text = "";
            lblDescPlazoMax.Text = "";
            
        }
        else
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT REPLACE(CONVERT(VARCHAR(20), CAST(DescMontoMax AS MONEY), 1), '.00', '') as DescMontoMax, REPLACE(CONVERT(VARCHAR(20), CAST(DescMontoMin AS MONEY), 1), '.00', '') as DescMontoMin, DescTasaOrdi, DescTasaPpago, DescTasaIncum FROM TC_Fondo WHERE IdFondo = @IdFondo";
                cmd.Parameters.AddWithValue("@IdFondo", idFondo);
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tblResultado = new DataTable();
                da.Fill(tblResultado);

                foreach (DataRow fila in tblResultado.Rows)
                {
                    lblTcredFogaMontoMax.Text = "$" + fila["DescMontoMax"].ToString();
                    lblDescMontoMin.Text = "$" + fila["DescMontoMin"].ToString();
                    lblTcredFogaTord.Text = fila["DescTasaOrdi"].ToString();
                    lblTcredFogaTordPronto.Text = fila["DescTasaPpago"].ToString();
                    lblDescTasaIncum.Text = fila["DescTasaIncum"].ToString();
                }

                cboDescFondeo.Items.Clear();
                cboDescFondeo.Items.Add("Seleccionar...");
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT IdFondeo, DescFondeo FROM TC_Fondeo WHERE IdFondo = @IdFondo";
                cmd2.Parameters.AddWithValue("@IdFondo", idFondo);
                cmd2.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable tblResultado2 = new DataTable();
                da2.Fill(tblResultado2);
                cboDescFondeo.DataSource = tblResultado2;
                cboDescFondeo.DataTextField = "DescFondeo";
                cboDescFondeo.DataValueField = "IdFondeo";
                cboDescFondeo.DataBind();

                lblDescPlazoMin.Text = "";
                lblDescPlazoMax.Text = "";
                
            }
        }
    }

    private void getDescFondeo(string idFondeo)
    {
        if (idFondeo == "Seleccionar...")
        {
            lblDescPlazoMin.Text = "";
            lblDescPlazoMax.Text = "";
        }
        else
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM TC_Fondeo WHERE IdFondeo = @IdFondeo";
                cmd.Parameters.AddWithValue("@IdFondeo", idFondeo);
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tblResultado = new DataTable();
                da.Fill(tblResultado);

                foreach (DataRow fila in tblResultado.Rows)
                {
                    lblDescPlazoMin.Text = fila["DescPlazoMin"].ToString();
                    lblDescPlazoMax.Text = fila["DescPlazoMax"].ToString();
                }

            }
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
                if (fila["Tipo_RFC"].ToString() == "F")
                {
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
            cmd.Parameters.AddWithValue("@Tipo", lblTipoPersona.Text.Substring(0, 1));
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

            //Cargando Combo de Fondos
            cargaFondos(cboDescTcred);

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
                if (lblTipoPersona.Text.Substring(0, 1) == "F")
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


    protected void cboDescTcred_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDescFondos(cboDescTcred.SelectedValue);
    }


    protected void cboDescFondeo_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDescFondeo(cboDescFondeo.SelectedValue);
    }
    protected void btnAgregarFondeo_Click(object sender, EventArgs e)
    {
        StringBuilder textoItem = new StringBuilder();
        //item.Text = cboDescTcred.SelectedItem.Text + " - " + cboDescFondeo.SelectedItem.Text + ", ;
        textoItem.Append(cboDescTcred.SelectedItem.Text);
        textoItem.Append(" - ");
        textoItem.Append(cboDescFondeo.SelectedItem.Text);
        textoItem.Append(",");
        textoItem.Append(txtCostoProyect.Text);
        textoItem.Append(",");
        textoItem.Append(txtPlazoMeses.Text);
        textoItem.Append(",");
        textoItem.Append(txtMontoSolicit.Text);
        textoItem.Append(",");
        textoItem.Append(txtPlazoGracia.Text);        
        ListItem item = new ListItem();
        item.Value = cboDescFondeo.SelectedValue;
        item.Text = textoItem.ToString();
        bool existe = false;
        foreach (ListItem item2 in lstFondeo.Items)
        {
            if (item.Value == item2.Value)
                existe = true;

        }
        if (!existe)
            lstFondeo.Items.Add(item);
    }

    #endregion
}