using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;


    public partial class SysAdminModel : _Database
    {
        public string sAuthenticationID = string.Empty;
        public bool GetAuthenticationID(string sEmailAddress)
        {
            try
            {
                DataSet ds = new DataSet();
                string NewGuid = GetNewUniqueID();
                string sSQL = "select * from user_management where email='" + sEmailAddress + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Email Address was not Found";
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
    }

