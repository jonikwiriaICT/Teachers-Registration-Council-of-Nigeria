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
        public string sFirstName;
        public string sMiddlename;
        public string sLastName;
        public string sTeacherNames;
        public string sGender;
        public string sEmail;
        public string sTelephoneNo;
        public string sMaritalStatus;
        //Get Annual licensed information by state
        public DataSet AnnualLicensedByState(string sStateID)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_statelog WHERE StateID='" + sStateID + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Annual Licensed by Registration ID
        public DataSet AnnualLicensedByRegistrationNo(string sRegistrationNo, string sStateID)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_statelog WHERE RegistrationNo='" + sRegistrationNo + "' AND StateID='" + sStateID + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Annual Licensed by Range
        public DataSet AnnualLicensedByRange(string sStateID, string sRange1, string sRange2)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_statelog WHERE  StateID='" + sStateID + "' AND RegistrationNo between '" + sRange1 + "' AND '" + sRange2 + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Annual Licensed by All Search
        public DataSet AnnualLicensedByIntelligence(string sState, string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_statelog where (StateID='" + sState + "') AND (Gender='" + Search + " ' or FirstName='" + Search + "' or [MiddleName]='" + Search + "' or Surname='" + Search + "' or TeacherNames='" + Search + "' or RegistrationNo='" + Search + "' or BankName='" + Search + "' or BankTeller ='" + Search + "' or MaritalStatus='" + Search + "' or TelephoneNumber='" + Search + "' or Email='" + Search + "' or DatePaid='" + Search + "')";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        //Get Annual  Licensed by Date
        public DataSet AnnualLicensedByDate(string sState, string sDateFrom, string sDateTo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_statelog WHERE  (StateID='" + sState + "') AND (DatePaid between '" + sDateFrom + "' AND '" + sDateTo + "')";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Registration Number By State
        public DataSet GetRegistrationNo(string sState)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select [Registration No] as [Code], [Registration No] as [Desc] from qry_search where State='" + sState + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //Get Teacher Names 
        public DataSet GetYear(string sState)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select [Code], [Desc] from (SELECT distinct annual_date_paid as [Code], annual_date_paid as [Desc] from statelog where state_id='" + sState + "' ) as tblQuery order by [Code] asc";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }


        public bool GetTeacherNames(string sRegistrationNo)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "select * from qry_search where [Registration No]='" + sRegistrationNo + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Registration Number was not Found";
                    return false;
                }
                sFirstName = ds.Tables[0].Rows[0]["First Name"].ToString();
                sMiddlename = ds.Tables[0].Rows[0]["Middle Name"].ToString();
                sLastName = ds.Tables[0].Rows[0]["Surname"].ToString();
                sTeacherNames = sFirstName + "  " + sMiddlename + "  " + sLastName;
                sGender = ds.Tables[0].Rows[0]["Gender"].ToString();
                sTelephoneNo = ds.Tables[0].Rows[0]["Telephone No."].ToString();
                sEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                sMaritalStatus = ds.Tables[0].Rows[0]["Marital Status"].ToString();


                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        //Get Excel Sheet
        public DataTable GetExcelSheet(string sStateID)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select ROW_NUMBER() over (order by RecID) as [S/N], RecID as [RecID], Firstname + ' ' + [Middle Name] + ' ' + Surname as [Teacher Names], RegistrationNo as [Registration No.], StateID as [State], AnnualDatePaid as [Date Paid], BankName as [Bank Name], RRRNumber as [RRR Number], FirstPaymemtLog as [First Payment], SecondAndOtherPaymentLog as [Other Payment] from qry_statelog WHERE StateID='" + sStateID + "'", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }
        //insert into AnnualLicensedLog
        public bool InsertIntoLicensedLog(string Firstname, string Middlename, string Lastname, string Teachernames, string Registration_No, string sAnnualAmountPaid, string sBankName, string sStateID, string sAnnualBankTeller, string sAnnualExpiringDate, string sAnnualDatePaid)
        {
            try
            {
                DateTime sDate = DateTime.UtcNow;
                string sLicensedDate = sDate.Date.ToString();
                string sExpiringDate = sDate.Date.AddYears(2).ToString();
                DateTime sDaNow = DateTime.Parse(sExpiringDate);
                DateTime sDateTimeLicensed = DateTime.Parse(sLicensedDate);
                string sSQL = "insert into statelog(firstname, middlename, lastname, teachernames, registration_no, annual_amount_paid, annual_bank_name, state_id, annual_bank_teller, annual_expiring_date, annual_date_paid) values('" + Firstname + "', '" + Middlename + "', '" + Lastname + "', '" + Teachernames + "', '" + Registration_No + "', '" + sAnnualAmountPaid + "', '" + sBankName + "', '" + sStateID + "', '" + sAnnualBankTeller + "', '" + sAnnualExpiringDate + "', '" + sAnnualDatePaid + "')";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to insert transaction";
                    return false;
                }
                ErrorMessage = "Record saved successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }


    }

