using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class FodeIntra : System.Web.UI.Page
{
    public int errores = 0;
    public string erroresDesc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            rdo_fode_soli_fina.Focus();
            Response.Write(hdd_fode_cot.Value);
            //ClientScript.RegisterClientScriptBlock(this.GetType(),"cargaArchivos", "<script type='text/javascript'>cargaArchivos();</script>");
        }
    }

    public bool validaExtension(string extension) { 
        switch (extension){
            case ".jpg":
            case ".jpeg":
            case ".png":
            case ".pdf":
                return true;            
            default:
                return false;
        }
    }

    public string generaNomArchivo(string extension, int aleatorio)
    {
        Random r = new Random(DateTime.Now.Millisecond);
        string fecha = DateTime.Now.ToShortDateString();
        fecha = fecha.Replace("/", "_");
        string numeroAleatorio = (r.Next(100000, 999999) + aleatorio).ToString();
        return numeroAleatorio + "_" + fecha + extension;
    }

    public string guardaImagen(FileUpload fup) {
        if (fup.HasFile)
        {
            try
            {
                string extArchivo = Path.GetExtension(fup.FileName);
                if (validaExtension(extArchivo))
                {
                    string nomArchivo = generaNomArchivo(extArchivo , fup.ToolTip.Length);
                    fup.SaveAs(Server.MapPath("~/Archivos/") + nomArchivo);
                    Response.Write("Archivo " + nomArchivo + " Componente " + fup.ToolTip.ToString());
                    return nomArchivo;
                }
                else
                {
                    //StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    return "Error-00001: Extensión incorrecta en el archivo " + fup.ToolTip.ToString();
                }
            }
            catch (Exception ex)
            {
                return "Error-00002: Error del sistema " + ex.Message;
            }
        }
        else {
            return "Error-00003: No se encontró el archivo";
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Response.Write(hdd_fode_cot.Value);
    }
}