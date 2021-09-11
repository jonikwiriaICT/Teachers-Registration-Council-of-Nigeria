using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;


    public partial class SysAdminModel : _Database
    {

        public DataSet getReport(string sState)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select row_number() over(order by rec_id) as [S/N], registration_no as [Registration Number], ISNULL(firstname,'') + '  ' + ISNULL(middlename,'') + '  ' + ISNULL(surname,'') as [Teacher Name], state_id as [State], lga_id as [L.G.A.], state_of_origin as [State of Origin], lga_origin as [L.G.A. of Origin], nationality as [Nationality], category as [Category], sex as [Gender], school_type as [School Type], education_level as [Education Level,], phone_no as [Telephone No.] FROM " + sState + "";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet allReportDataQuery(string NameType, string sState)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select " + NameType + " as [Type], count(*) as [Total by Type], COUNT(*) * 100.0 / (Select count(*) from " + sState + ") as [Percentage] from " + sState + " group by " + NameType + " ";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet allQueryStatus(string sState)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = " select count(*) as [All Total Teacher], COUNT(*) * 100.0 / (Select count(*) from " + sState + ") as [Percentage] from " + sState + " ";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet allQueryStatusByType(string sState, string type, string sNo)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select row_number() over(order by rec_id) as [S/N], registration_no as [Registration Number], ISNULL(firstname,'') + '  ' + ISNULL(middlename,'') + '  ' + ISNULL(surname,'') as [Teacher Name], state_id as [State], category as [Category], sex as [Gender], school_type as [School Type], nationality as [Nationality], verification_date as [Date of Verification], unverification_date as [Unverification Date],  printed_certificate_date as [Printed Certificate Date], re_printed_certificate_date as [Reprinted Certificate Date] FROM " + sState + " where  " + type + " ='" + sNo + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet allQueryResult(string sState, string type, string sNo)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select row_number() over(order by rec_id) as [S/N], names as [Teachers' Name], pqe_number as [PQE Number], exam_type as [Exam Type], state_id as [State], category as [Category], statue as [Status], institution_name as [Institution Name], nin_no as [NIN No.], year as [Year], gender as [Gender] from result " + sState + " where  " + type + " ='" + sNo + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet allTotalCount(string sState)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select count(*) as [Total_Record] from " + sState + "";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet QueryByStatus(string sState, string sStatus, string sNo)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select count(*) as [All Total Teacher], COUNT(*) * 100.0 / (Select count(*) from " + sState + ") as [Percentage] from " + sState + "  where " + sStatus + "='" + sNo + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }


        public DataSet allTotalCountByTeachers(string sState, string sStatus, string sNo)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select count(*) as [Total_Record] from " + sState + " where " + sStatus + "='" + sNo + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

    }

