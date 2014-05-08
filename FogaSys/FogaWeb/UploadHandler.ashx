<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System.Collections.Generic;
using System;
using System.Drawing;
using System.Web;
using System.IO;

public class UploadHandler : IHttpHandler {
    
    public void ProcessRequest(HttpContext context)
    {
            //delete uploaded file if we call this page and pass query sting with the name of the file
            if (context.Request.QueryString.Count > 0)
            {
                string filePath = HttpContext.Current.Server.MapPath("Archivos") + "//" + context.Request.QueryString[0].ToString();
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            // if we are not passing the name of the file then we are uploading ..
            else
            {
                  var ext = System.IO.Path.GetExtension(context.Request.Files[0].FileName); // get file extention
                  var fileName = Path.GetFileName( context.Request.Files[0].FileName); // take the  name of the uploaded file .
                    if (context.Request.Files[0].FileName.LastIndexOf("\\") != -1)
                    {
                        fileName = context.Request.Files[0].FileName.Remove(0, context.Request.Files[0].FileName.LastIndexOf("\\")).ToLower(); // remove extra folder path (IE bug)
                    }
                
                    //fileName = GetUniqueFileName(fileName, HttpContext.Current.Server.MapPath("Archivos/") , ext).ToLower(); // get unique name
                    fileName = generaNomArchivo(ext, fileName.Length);
                string location = HttpContext.Current.Server.MapPath("Archivos/")  + fileName; //save path
                context.Request.Files[0].SaveAs(location);  // save the file
                context.Response.Write(fileName); // return saved name
                context.Response.End();
            }
    }

    public static string generaNomArchivo(string extension, int aleatorio)
    {
        Random r = new Random(DateTime.Now.Millisecond);
        string fecha = DateTime.Now.ToShortDateString();
        fecha = fecha.Replace("/", "_");
        string numeroAleatorio = (r.Next(100000, 999999) + aleatorio).ToString();
        return numeroAleatorio + "_" + fecha + extension;
    }
    
    public static string GetUniqueFileName(string name, string savePath, string ext)
    {
        name = name.Replace(ext, "").Replace(" ", "_"); // remove extension and spaces from the name
        name = System.Text.RegularExpressions.Regex.Replace(name, @"[^\w\s]", ""); // remove all punctuations
        var newName = name;
        var i = 0;
        if (System.IO.File.Exists(savePath + newName + ext)) // check if the file name already there
        {
            do
            {
                i++;
                newName = name + "_" + i;
            }
            while (System.IO.File.Exists(savePath + newName + ext));
        }
        return newName; // return new name
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}