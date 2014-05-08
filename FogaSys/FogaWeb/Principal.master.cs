using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.AddHeader("cache-control", "private");
        //Response.AddHeader("pragma", "no-cache");
        //Response.AddHeader("Cache-Control", "must-revalidate");
        //Response.AddHeader("Cache-Control", "no-cache");                
    }
}
