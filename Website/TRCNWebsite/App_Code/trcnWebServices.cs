using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for trcnWebServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class trcnWebServices : System.Web.Services.WebService
{
    SysAdminModel objAdm = new SysAdminModel();
    public static string DB = "LICENSED";

    public trcnWebServices()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<object> getTeacherStatus(string state)
    {
        List<object> iData = new List<object>();
        List<string> labels = new List<string>();
        List<string> labels1 = new List<string>();
        string query1 = "select 'All Registered Teacher' as [Status], count(*) as [Total] from " + state + " union select 'Verified Teacher' as [Status], count(*) as [Total] from " + state + " where registration_status='1' union select 'Not Verified Teacher' as [Status], count(*) as [Total] from " + state + " where registration_status='0' ";
        DataTable dtLabels = commonFuntionGetData(query1);
        foreach (DataRow drow in dtLabels.Rows)
        {
            labels.Add(drow["Status"].ToString());
            labels1.Add(drow["Total"].ToString());
        }
        iData.Add(labels);
        iData.Add(labels1);
        return iData;
    }

    [WebMethod]
    public List<object> getCertificateStatus(string state)
    {
        List<object> sData = new List<object>();
        List<string> sLabel = new List<string>();
        List<string> sLabel2 = new List<string>();
        string query1 = "select 'Certificate Printed' as [Status], count(*) as [Total] from " + state + " where printing_status='1' union select 'Certificate Not Printed' as [Status], count(*) as [Total] from " + state + " where printing_status='0' ";

        DataTable dtLabels = commonFuntionGetData(query1);
        foreach (DataRow drow in dtLabels.Rows)
        {
            sLabel.Add(drow["Status"].ToString());
            sLabel2.Add(drow["Total"].ToString());

        }
        sData.Add(sLabel);
        sData.Add(sLabel2);
        return sData;

    }

    [WebMethod]
    public List<object> getResult(string state)
    {
        List<object> sData = new List<object>();
        List<string> sLabel = new List<string>();
        List<string> sLabel2 = new List<string>();
        string query1 = "select 'PASSED' as [Status], count(*) as [Total] from result where statue = 'PASSED' AND state_id='" + state + "' UNION select 'FAILED' as [Status], count(*) as [Total] from result where statue = 'FAILED' AND state_id='" + state + "'  ";

        DataTable dtLabels = commonFuntionGetData(query1);
        foreach (DataRow drow in dtLabels.Rows)
        {
            sLabel.Add(drow["Status"].ToString());
            sLabel2.Add(drow["Total"].ToString());

        }
        sData.Add(sLabel);
        sData.Add(sLabel2);
        return sData;

    }
    [WebMethod]
    public List<object> getLicensed(string state)
    {
        List<object> sData = new List<object>();
        List<string> sLabel = new List<string>();
        List<string> sLabel2 = new List<string>();
        string query1 = "select 'Not Approved Licensed' as [Status], count(*) as [Total] from " + DB + state + " where licensed_status = 'NOT' union select 'Approved Licensed' as [Status], count(*) as [Total] from " + DB + state + " where licensed_status = '2' union select 'Printed Licensed' as [Status], count(*) as [Total] from " + DB + state + " where licensed_status = '3'";
        DataTable dtLabels = commonFuntionGetData(query1);
        foreach (DataRow drow in dtLabels.Rows)
        {
            sLabel.Add(drow["Status"].ToString());
            sLabel2.Add(drow["Total"].ToString());

        }
        sData.Add(sLabel);
        sData.Add(sLabel2);
        return sData;
    }
    public DataTable commonFuntionGetData(string strQuery)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
        SqlDataAdapter dap = new SqlDataAdapter(strQuery, cn);
        DataSet ds = new DataSet();
        dap.Fill(ds);
        cn.Close();
        cn.Dispose();
        return ds.Tables[0];
    }

}
