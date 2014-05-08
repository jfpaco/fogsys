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
using System.Globalization;
using System.Web.Globalization;

public partial class CuestionarioPreDiagnostico : System.Web.UI.Page
{

    private string guardaCuestionario() {
        StringBuilder error = new StringBuilder();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAltaCuestionarioPre";
            cnn.Open();

            //Folio
            cmd.Parameters.AddWithValue("@Folio", Convert.ToInt64(lblFolio.Text));

            //Validacion Fecha Reistro
            if (txtFechaPre.Text.Trim() != string.Empty)
            {
                if (Validacion.valFecha(txtFechaPre.Text.Trim()))
                {
                    DateTime fecha = DateTime.ParseExact(txtFechaPre.Text.Trim(), "dd/MM/yyyy", null);
                    cmd.Parameters.AddWithValue("@FechaPre", fecha);
                }
                else
                {
                    error.Append("Error en formato de la fecha de registro\n");
                }
            }

            // OPCIONAL
            //
            cmd.Parameters.AddWithValue("@SolicOtroEmpleo", rdoSolicOtroEmpleo.SelectedValue);

            if (rdoSolicOtroEmpleo.SelectedValue == "1")
            {
                cmd.Parameters.AddWithValue("@SolicOtroEmpleoEsp", txtSolicOtroEmpleoEsp.Text.Trim());

                //Validacion Ingresos
                if (Validacion.valNumerico(txtSolicOtroEmpleoIngr.Text.Replace(",", "")))
                {
                    cmd.Parameters.AddWithValue("@SolicOtroEmpleoIngr", Convert.ToDouble(txtSolicOtroEmpleoIngr.Text.Trim()));
                }
                else
                {
                    error.Append("Error en Campo Ingresos");
                }
            }

            //Validacion Fecha Antiguedad
            if (txtAntigNego.Text.Trim() != string.Empty)
            {
                if (Validacion.valFecha(txtAntigNego.Text.Trim()))
                {
                    DateTime fecha = DateTime.ParseExact(txtAntigNego.Text.Trim(), "dd/MM/yyyy", null);
                    cmd.Parameters.AddWithValue("@AntigNego", fecha);
                }
                else
                {
                    error.Append("Error en formato de la fecha de Antiguedad del Negocio\n");
                }
            }

            cmd.Parameters.AddWithValue("@LocalNego", cboLocalNego.SelectedValue);

            //OPCIONAL
            //

            if (cboLocalNego.SelectedValue == "1")
            {
                //Validacion Renta
                if (Validacion.valNumerico(txtLocalNegoRenta.Text.Replace(",", "")))
                {
                    cmd.Parameters.AddWithValue("@LocalNegoRenta", Convert.ToDouble(txtLocalNegoRenta.Text.Trim()));
                }
                else
                {
                    error.Append("Error en Campo Renta");
                }
            }

            //Validacion Fecha Arrendamiento
            if (txtLocalNegoVigen.Text.Trim() != string.Empty)
            {
                if (Validacion.valFecha(txtLocalNegoVigen.Text.Trim()))
                {
                    DateTime fecha = DateTime.ParseExact(txtLocalNegoVigen.Text.Trim(), "dd/MM/yyyy", null);
                    cmd.Parameters.AddWithValue("@LocalNegoVigen", fecha);
                }
                else
                {
                    error.Append("Error en formato de la fecha de Antiguedad del Negocio\n");
                }
            }


            //Validacion Personas
            if (Validacion.valNumerico(txtPersonalAct.Text.Trim()))
            {
                cmd.Parameters.AddWithValue("@PersonalAct", Convert.ToDouble(txtPersonalAct.Text.Trim()));
            }
            else
            {
                error.Append("Error en Campo Personas que intervienen");
            }


            //Validacion Nomina            
            if (Validacion.valNumerico(txtNomiSem.Text.Replace(",", "")))
            {
                cmd.Parameters.AddWithValue("@NomiSem", Convert.ToDouble(txtNomiSem.Text.Trim()));
            }
            else
            {
                error.Append("Error en Campo Renta");
            }

            cmd.Parameters.AddWithValue("@SegTipo", rdoSegTipo.SelectedValue);

            //OPCIONAL
            //

            if (rdoSegTipo.SelectedValue == "1")
            {
                //Validacion Fecha Seguro
                if (txtSegTipoDescrp.Text.Trim() != string.Empty)
                {
                    if (Validacion.valFecha(txtSegTipoDescrp.Text.Trim()))
                    {
                        DateTime fecha = DateTime.ParseExact(txtSegTipoDescrp.Text.Trim(), "dd/MM/yyyy", null);
                        cmd.Parameters.AddWithValue("@SegTipoDescrp", fecha);
                    }
                    else
                    {
                        error.Append("Error en formato de la fecha de alta seguro\n");
                    }
                }
            }

            //Response.Write(error.ToString());

            if (error.ToString().Trim() == string.Empty)
            {
                string resultado = cmd.ExecuteNonQuery().ToString();
                cnn.Close();
                error.Append(resultado);
            }
        }
        return error.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["folio"] == null)
        {
            Response.Redirect("Prospecto.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                lblFolio.Text = Session["folio"].ToString();                              
                //DateTime fecha = Convert.ToDateTime(fechaHoy, System.Globalization.CultureInfo.GetCultureInfo("es-MX").DateTimeFormat);
                txtFechaPre.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
        }
    }

    public string GetFormattedDate(string date, string sFormat)
    {        
        txtFechaPre.Text = ""; 
        string fdate = "";
       
            if (date != "")
            {
                IFormatProvider f = new CultureInfo("es-MX", false);
                DateTime d = DateTime.Parse(date, f);
                fdate = d.ToString(sFormat);
            }
        
        return fdate;
    }
    protected void rdoSolicOtroEmpleo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSolicOtroEmpleo.SelectedValue == "1")
        {
            pnlSolicOtroEmpleo.Visible = true;
            txtSolicOtroEmpleoEsp.Focus();
            //Validaciones
            rfvSolicOtroEmpleoEsp.ValidationGroup = "cuestionario";
            rfvSolicOtroEmpleoIngr.ValidationGroup = "cuestionario";
            revSolicOtroEmpleoIngr.ValidationGroup = "cuestionario";
        }
        else
        { 
            pnlSolicOtroEmpleo.Visible = false;
            txtAntigNego.Focus();
            //Validacion
            rfvSolicOtroEmpleoEsp.ValidationGroup = "solic";
            rfvSolicOtroEmpleoIngr.ValidationGroup = "solic";
            revSolicOtroEmpleoIngr.ValidationGroup = "solic";
        }
    }
    protected void cboLocalNego_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboLocalNego.SelectedValue == "1")
        {
            pnlLocalNego.Visible = true;
            txtLocalNegoRenta.Focus();
            //Validacion
            rfvLocalNegoRenta.ValidationGroup = "cuestionario";
            revLocalNegoRenta.ValidationGroup = "cuestionario";
            rfvLocalNegoVigen.ValidationGroup = "cuestionario";
        }
        else {
            pnlLocalNego.Visible = false;
            txtPersonalAct.Focus();
            //Validacion
            rfvLocalNegoRenta.ValidationGroup = "local";
            revLocalNegoRenta.ValidationGroup = "local";
            rfvLocalNegoVigen.ValidationGroup = "local";
        }
    }
    protected void rdoSegTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSegTipo.SelectedValue == "1")
        {
            pnlSegTipo.Visible = true;
            txtSegTipoDescrp.Focus();
            //Validacion
            rfvSegTipoDescrp.ValidationGroup = "cuestionario";
        }
        else {
            pnlSegTipo.Visible = false;
            txtNomiSem.Focus();
            rfvSegTipoDescrp.ValidationGroup = "seguro";
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string resultado = guardaCuestionario();
        if (resultado == "2")
        {
            Session.Abandon();
            this.ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Guardado Correctamente', 'Default.aspx');", true);                        
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "error1", "mensaje('" + resultado + "');", true);
        }
    }
}