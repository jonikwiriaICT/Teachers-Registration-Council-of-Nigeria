using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public partial class SysAdminModel : _Database
    {
        public DataSet LoadEmail()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [RecID], smtp_server as [Server Name], smtp_username as [Username] from tbl_mail_server";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataTable GetEmail()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select rec_id as [RecID], smtp_server as [Server Name], smtp_username as [Username] from tbl_mail_server", conn))

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

