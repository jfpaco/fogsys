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
public partial class ModificarProspecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBusqueda_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spConsultaDatosGrales";
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@Busqueda", txtBusqueda.Text.Trim());
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