using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;


    public partial class SysAdminModel : _Database
    {

    public string connectionstring = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString();
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());

}

