using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using _Foundation;

/// <summary>
/// Summary description for ChatBot
/// </summary>
public partial class SysAdminModel: _Database
{
    public string Message = string.Empty;
    public bool GetMessage(string Text)
    {
        try
        {
            DataSet ds = new DataSet();
            string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
            SqlCommand objCmd = new SqlCommand();
            objCmd.Parameters.Clear();
            objCmd.Parameters.AddWithValue("@s1", Text);
            objCmd.CommandText = sSQL;
            ds = ExecuteDataSet(objCmd);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return false;
            }
            Message = ds.Tables[0].Rows[0]["replies"].ToString();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}