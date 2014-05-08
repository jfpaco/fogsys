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
using System.IO;
using System.Runtime.Serialization.Json;

public partial class Catalogos : System.Web.UI.Page
{
    public class MunicipioInfo
    {
        public int IdMuni
        {
            get;
            set;
        }

        public string MuniNombre
        {
            get;
            set;
        }
    }

    public List<MunicipioInfo> CountryInformation { get; set; }

    [WebMethod()]
    public static List<MunicipioInfo> ChecaMunicipio(string idEdo)
    {
        DataSet ds = new DataSet();
        List<MunicipioInfo> MuniInformacion = new List<MunicipioInfo>();
        
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["FogaWeb"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from TC_Municipio where IdEdo = @IdEdo";
            cmd.Parameters.AddWithValue("@IdEdo", idEdo);
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    MuniInformacion.Add(new MunicipioInfo()
                    {
                        IdMuni = Convert.ToInt32(dr["IdMun"]),
                        MuniNombre = dr["Municipio"].ToString()

                    });
                }                
            }
        }

        return MuniInformacion;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}