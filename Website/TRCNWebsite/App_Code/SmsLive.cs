using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Net;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


    public partial class SysAdminModel : _Database
    {
        public DataSet LoadSms()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select row_number() over(order by rec_id) as [S/N], rec_id as [RecID], source_id as [AuthToken], sms_message as [Sender Name] from tbl_sms";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataTable GetSms()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select row_number() over(order by rec_id) as [S/N], rec_id as [RecID], source_id as [AuthToken], sms_message as [Sender Name] from tbl_sms", conn))

            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                conn.Close();
                conn.Dispose();
                return teacher;
            }
        }

    }

