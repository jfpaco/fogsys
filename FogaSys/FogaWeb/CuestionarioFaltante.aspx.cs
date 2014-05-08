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
public partial class CuestionarioFaltante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spConsultaDatosGrales";
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@Cuestionario", 0);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tblResultado = new DataTable();
                da.Fill(tblResultado);
                grdBusqueda.DataSource = tblResultado;
                grdBusqueda.DataBind();
            }
        }
    }
    protected void grdBusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Seleccionar")
        {

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow fila = grdBusqueda.Rows[index];
            
            Session["folio"] = fila.Cells[1].Text;

            this.ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "location.href='CuestionarioPreDiagnostico.aspx'", true);
                        
        }
    }
}