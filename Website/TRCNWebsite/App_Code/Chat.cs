using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for ChatService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Chat : System.Web.Services.WebService
{
    SysAdminModel objAdm = new SysAdminModel();
    public static string ChatType = string.Empty;

    
    [WebMethod(EnableSession = true)]
    public string IntelligentBotChat(string text)
    {
        string sText = text.ToLower().ToString();
        string Number = new string(sText.Where(char.IsDigit).ToArray());
        ChatType = text.ToLower().ToString();

        if (objAdm.GetMessage(sText) == true)
        {
            
            return objAdm.Message;
        }
        return objAdm.ErrorMessage;
    }










}
