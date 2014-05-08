using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Descripción breve de Validacion
/// </summary>
public class Validacion
{
	public Validacion()
	{
		
	}
    public static bool valCorreo(string correo)
    {
        Regex expVal = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        if (expVal.IsMatch(correo))
            return true;
        else
            return false;
    }

    public static bool valFecha(string fecha)
    {
        Regex expVal = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
        if (expVal.IsMatch(fecha))
            return true;
        else
            return false;
    }

    public static bool valRFC(string rfc)
    {
        Regex expVal = new Regex(@"[A-Z]{4}[0-9]{6}[A-Z0-9]{3}");
        if (expVal.IsMatch(rfc))
            return true;
        else
            return false;
    }

    public static bool valNumerico(string  num)
    {
        if (!string.IsNullOrEmpty(num))
        {
            Regex expVal = new Regex(@"^\d*$");
            if (expVal.IsMatch(num))
                return true;
            else
                return false;
        }
        else {
            return false;
        }
        
    }
}