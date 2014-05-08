<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fogacintra WEB</title>
    <link href="login.css" rel="stylesheet" type="text/css" />        
    <script src="../Scripts/jquery-1.7.1.js" type="text/javascript"></script>   
</head>
<body>    
    <form id="form1" runat="server">
    <div id="contenedor">
        <div id="login" class="centrarHV">            
            <div id="frmLogin">
            <table class="tbl-login" border="0" cellspacing="0" cellpadding="0">
                <tr>                    
                    <td>
                        <asp:TextBox ID="txtUsr" runat="server" placeholder="Nombre de Usuario"></asp:TextBox>
                    </td>
                </tr>
                <tr>                    
                    <td>
                        <asp:TextBox ID="txtPsw" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="remember">
                        <asp:CheckBox ID="chkRem" runat="server" Text=" Mantener la sesión iniciada" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEntrar" runat="server" Text="" />
                    </td>
                </tr>
            </table>
            </div>    
            
        </div>
        <div style="clear:both"></div>
    </div>    
    </form>    
    <script type="text/javascript">
        $('document').ready(function () {
            $(':input[placeholder]').placeholder();
        });
    </script>    
</body>
</html>
