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

        public DataSet GetQualification(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct education_level as [Code], education_level as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet GetGender(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQl = "select distinct sex as [Code], sex as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQl;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Verified Teachers
        public DataSet GetVerifiedTeachers(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQl = "select distinct case when registration_status='1' then 'Verified Teachers' else 'Not Verified Teachers' end as [Desc], case when  registration_status='1' then '1' else '0' end as [Code] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQl;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Printed Certificate
        public DataSet GetPrintedCertificate(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct case when printing_status='1' then 'Printed Certificate' else 'Not Printed Certificate' end as [Desc], case when  printing_status='1' then '1' else '0' end as [Code] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get School Type
        public DataSet GetSchoolType(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct school_type as [Code], school_type as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Marital Status
        public DataSet GetMaritalStatus(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct marital_status as [Code], marital_status as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Category Status
        public DataSet GetCategoryStatus(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct category as [Code], category as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Institution Attended
        public DataSet GetInstitutionAttended(string sState, string sLga)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct institution_attended as [Code], institution_attended as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
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

