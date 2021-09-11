using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Net;

    public partial class SysAdminModel : _Database
    {
        public string statistics = "";
        public string sAuth = "You are not licensed to use this page.";
        public string sLicensedNumber = "";
        public string chartData = "";
        public string chartGender = "";
        public string sExamType = "";
        public string sChartResult = "";
        public string sCheck = "Please enter your name or PQE Number to check your result";
        public string chartCategory = "";
        public string sNotAuthorizedUsed = "You are not authorized to use this page.";
        public string sUsername = "";
        public string directorate = "";
        public string administrtaor = "";
        public string recordManager = "";
        public string accounthead = "";
        public string stat = "";
        public string account = "";
        public string sPassword = "";
        public string Scertification = "";
        public string adminSignature = "";
        public string sLastRecID = "";
        public string sTeacherName = "";
        public string Surname = "";
        public string Othernames = "";
        public string sUrl = "";
        public string sMailServer = "";
        public int sPort;
        public bool bSSL;
        public string stmpUsername = "";
        public string stmpPassword = "";
        public string stmpAddressFrom = "";
        public string allCount = "";
        public string teachCount = "";

        public string sRegStatue = "";
        public string sRegNo = "";
        public string sRegName = "";
        public string sCertificate = "";
        public string sLicensedStatus = "";
        public string sValidLicensed = "";
        public string sStateLocation = "";
        public string sCategory = "";
        public string sHighestQualification = "";
        public string sLicensedDate = "";
        public string sExpiringDate = "";
        public string userID = "";
        public string Licensed = "";
        public string sState = "";
        public string States = "";
        public string GetRegNo = "";

        public bool AllTeacherCount(string sModule)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT total from qry_teacher_count where module='" + sModule + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public string GetRegistrationNumber(string tbl, string sRecID)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT registration_no from " + tbl + " where rec_id='" + sRecID + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return null;
                }
                GetRegNo = ds.Tables[0].Rows[0]["registration_no"].ToString();
                return GetRegNo;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return null;
            }
        }


        public string ALLLicensedCount(string sModule)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT total from qry_licensed_count where module='" + sModule + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return null;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return teachCount;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return null;
            }
        }
        public string allLicensedStateCount(string tbl, string picNo)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT count(*) as [total] from " + tbl + " where pic_no='" + picNo + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return null;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return teachCount;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return null;
            }
        }
        public string allStateOfficeTeacherRegistration(string tbl)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT count(*) as [total] from " + tbl + "";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return null;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return teachCount;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return null;
            }
        }
        public bool allcountresult(string sModule)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT total from qry_result where module='" + sModule + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool SendHtmlFormattedEmail(string subject, string body, string userEmail)
        {
            try
            {
                if (getServerDetails() == true)
                {
                    using (MailMessage mm = new MailMessage())
                    {
                        mm.From = new MailAddress(stmpUsername); //--- Email address of the sender
                        mm.To.Add(userEmail); //---- Email address of the recipient.
                        mm.Subject = subject; //---- Subject of email.
                        mm.Body = body; //---- Content of email.
                        mm.IsBodyHtml = true; //---- To specify wether email body contains HTML tags or not.
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = sMailServer; //---- SMTP Host Details. 
                        smtp.EnableSsl = false; //---- Specify whether host accepts SSL Connections or not.
                        NetworkCredential NetworkCred = new NetworkCredential(stmpUsername, stmpPassword);
                        //---Your Email and password
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 25; //---- SMTP Server port number. This varies from host to host. 
                        smtp.Send(mm);

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool getTrcnAuthentication(string sUserID, string sPassword)
        {

            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM tbl_trcn_user WHERE [userID]=@userID AND [userpassword]=@sPassword ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@userID", sUserID);
                objCmd.Parameters.AddWithValue("@sPassword", sPassword);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid User. Contact Administrator.";
                    return false;
                }
                userID = ds.Tables[0].Rows[0]["userID"].ToString();
                sRegName = ds.Tables[0].Rows[0]["registration_no"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }

        public bool setChangePassword(string sUsername, string sNewPassword)
        {
            try
            {
                string sSQL = "UPDATE tbl_trcn_user SET [userpassword]=@user_password " +
                    " WHERE [registration_no]=@user_name ";

                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                //sNewPassword = Encrypt(sNewPassword, true);
                objCmd.Parameters.AddWithValue("@user_password", sNewPassword);
                objCmd.Parameters.AddWithValue("@user_name", sUsername);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage += "Password set failed.  Contact Administrator";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return false;
            }
        }
        public bool authenticateUserID(string sUserID)
        {

            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM tbl_trcn_user WHERE [userID]=@userID";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@userID", sUserID);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid User. Contact Administrator.";
                    return false;
                }
                userID = ds.Tables[0].Rows[0]["registration_no"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }
        public DataSet reportSearch(string stbl, string sStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'') + '   ' + ISNULL(st.firstname,'') + '    ' + ISNULL(st.middlename,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + sStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet searchAllTeachIntelligence(string stbl, string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'') + '   ' + ISNULL(st.firstname,'') + '    ' + ISNULL(st.middlename,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_no='" + Search + "' or st.title='" + Search + "' or st.form_no='" + Search + "' or st.pqe_number='" + Search + "' or st.surname='" + Search + "' or st.firstname='" + Search + "' or st.middlename='" + Search + "' or st.marital_status='" + Search + "' or st.sex='" + Search + "' or st.dob='" + Search + "' or st.state_id='" + Search + "' or st.phone_no='" + Search + "' or st.address='" + Search + "' or st.lga_id='" + Search + "' or st.state_of_origin='" + Search + "' or st.lga_origin='" + Search + "' or st.year_obtained='" + Search + "' or st.pqe_number='" + Search + "' or st.any_qualification_in_education='" + Search + "' or st.nationality='" + Search + "' or st.category='" + Search + "' or st.current_employer='" + Search + "' or st.employment_date='" + Search + "' or st.education_level='" + Search + "' or st.institution_attended='" + Search + "' or st.pqe_number='" + Search + "' or st.amount_paid='" + Search + "' or st.bank_name='" + Search + "' or st. date_paid='" + Search + "' or st.school_one='" + Search + "' or st.application_date='" + Search + "' or st.years_of_Experience='" + Search + "' or st.area_of_discipline='" + Search + "' or st.registration_date='" + Search + "' or st.email='" + Search + "' or st.school_type='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet searchAllIntelligenceByStatus(string stbl, string Search, string sType, string sNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin where (st." + sType + "='" + sNo + "') AND (st.registration_no='" + Search + "' or st.title='" + Search + "' or st.form_no='" + Search + "' or st.surname='" + Search + "' or st.firstname='" + Search + "' or st.middlename='" + Search + "' or st.marital_status='" + Search + "' or st.sex='" + Search + "' or st.dob='" + Search + "' or st.pqe_number='" + Search + "' or st.state_id='" + Search + "' or st.phone_no='" + Search + "' or st.address='" + Search + "' or st.lga_id='" + Search + "' or st.state_of_origin='" + Search + "' or st.lga_origin='" + Search + "' or st.pqe_number='" + Search + "' or st.year_obtained='" + Search + "' or st.any_qualification_in_education='" + Search + "' or st.nationality='" + Search + "' or st.category='" + Search + "' or st.current_employer='" + Search + "' or st.employment_date='" + Search + "' or st.education_level='" + Search + "' or st.institution_attended='" + Search + "' or st.amount_paid='" + Search + "' or st.bank_name='" + Search + "' or st. date_paid='" + Search + "' or st.school_one='" + Search + "' or st.application_date='" + Search + "' or st.years_of_Experience='" + Search + "' or st.area_of_discipline='" + Search + "' or st.registration_date='" + Search + "' or st.email='" + Search + "' or st.school_type='" + Search + "')";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet SearchResult(string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], names as [TEACHER' NAME], pqe_number as [PQE NUMBER], exam_type as [EXAM TYPE], ISNULL(nin_no,'') as [NIN NUMBER], state_id as [STATE], category as [CATEGORY], statue as [STATUS], gender as [GENDER], year as [YEAR] from result where pqe_number='" + Search + "' or names='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet SearchAllResult(string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], names as [TEACHER' NAME], pqe_number as [PQE NUMBER], exam_type as [EXAM TYPE], ISNULL(nin_no,'') as [NIN NUMBER], state_id as [STATE], category as [CATEGORY], statue as [STATUS], gender as [GENDER], year as [YEAR] from result where  names= '" + Search + "' or pqe_number='" + Search + "' or exam_type='" + Search + "' or state_id='" + Search + "' or category='" + Search + "' or statue='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet intelligentSearch(string stbl, string sSearch)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select st.rec_id as [ID], st.registration_no as [Registration_no], st.form_no as [RRR Number], st.surname + '   ' + st.firstname + '    ' + st.middlename as [Teacher Names], st.marital_status as [Marital Status], st.sex as [Gender], st.dob as [Date of Birth], st.state_id as [State], st.phone_no as [Telephone Number], address as [Address], st.lga_id as [L.G.A.], st.state_of_origin as [State of Origin], st.nationality as [Nationality], st.category as [Category], st.current_employer as [Current Employer], st.employment_date as [Employment Date], st.education_level as [Educational Level], st.institution_attended as [Institution Attended], st.amount_paid as [Amount Paid], st.bank_teller as [Bank Teller], st.bank_name as [Bank Name], st.date_paid as [Date paid], st.application_date as [Application Date], st.years_of_Experience as [Years of Experience], st.area_of_discipline as [Area of discipline], st.registration_date as [Registration Date], st.registration_status as [Status], st.printing_status as [Printing Status], st.email as [Email Address], st.teacher_signature as [Teacher Signature], st.licensed_date as [Licensed Date], st.licensed_expiring_date as [Licensed Expiration Date], st.licensed_status as [Licensed Status], ad.administrator_name as [Administrator Name], ad.administrator_signature as [Administrator Signature], st.pic_filename as [Picture], st.guid_no as [Identity] from " + stbl + " st join (select *from administrator) ad on ad.status = st.admin_no where st.rec_id like '" + "%" + sSearch + "%" + "' or st.registration_no like '" + "%" + sSearch + "%" + "' or st.form_no like '" + "%" + sSearch + "%" + "' or st.surname like '" + "%" + sSearch + "%" + "' or st.firstname like '" + "%" + sSearch + "%" + "' or st.middlename like '" + "%" + sSearch + "%" + "' or st.marital_status like '" + "%" + sSearch + "%" + "' or st.sex like '" + "%" + sSearch + "%" + "' or st.dob like '" + "%" + sSearch + "%" + "' or st.state_id like '" + "%" + sSearch + "%" + "' or st.phone_no like '" + "%" + sSearch + "%" + "' or st.address like '" + "%" + sSearch + "%" + "' or st.lga_id like '" + "%" + sSearch + "%" + "' or st.state_of_origin like '" + "%" + sSearch + "%" + "' or st.nationality like '" + "%" + sSearch + "%" + "' or st.category like '" + "%" + sSearch + "%" + "' or st.current_employer like '" + "%" + sSearch + "%" + "' or st.employment_date like '" + "%" + sSearch + "%" + "' or st.education_level like '" + "%" + sSearch + "%" + "' or st.institution_attended like '" + "%" + sSearch + "%" + "' or st.amount_paid like '" + "%" + sSearch + "%" + "' or st.bank_teller like '" + "%" + sSearch + "%" + "' or st.bank_name like '" + "%" + sSearch + "%" + "' or st.date_paid like '" + "%" + sSearch + "%" + "' or st.application_date like '" + "%" + sSearch + "%" + "' or st.years_of_Experience like '" + "%" + sSearch + "%" + "' or st.area_of_discipline like '" + "%" + sSearch + "%" + "' or st.registration_date like '" + "%" + sSearch + "%" + "' or st.registration_status like '" + "%" + sSearch + "%" + "' or st.printing_status like '" + "%" + sSearch + "%" + "' or st.admin_no like '" + "%" + sSearch + "%" + "' or st.guid_no like '" + "%" + sSearch + "%" + "' or st.pic_filename like '" + "%" + sSearch + "%" + "' or st.email like '" + "%" + sSearch + "%" + "' or st.pic_no like '" + "%" + sSearch + "%" + "' or st.teacher_signature like '" + "%" + sSearch + "%" + "' or st.licensed_status like '" + "%" + sSearch + "%" + "' or st.licensed_date like '" + "%" + sSearch + "%" + "' or st.licensed_expiring_date like '" + "%" + sSearch + "%" + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public void SerialiseSchoolType(string sState)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
            con.Open();
            SqlCommand comm = new SqlCommand("select school_type as name, count(*) as y from " + sState + " group by school_type order by count(school_type)", con);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            chartData = JsonConvert.SerializeObject(dt);
        }
        public void serializeCategory(string sState)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
            con.Open();
            SqlCommand comm = new SqlCommand("select category as name, count(*) as y from " + sState + " group by category order by count(category)", con);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            chartCategory = JsonConvert.SerializeObject(dt);
        }
        public void serializeGenderType(string sState)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
            con.Open();
            SqlCommand comm = new SqlCommand("select sex as name, count(*) as y from " + sState + " group by sex order by count(sex)", con);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            chartGender = JsonConvert.SerializeObject(dt);
        }

        public void serialiseResultByStatus(string sState)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
            con.Open();
            SqlCommand comm = new SqlCommand("select statue as name, count(*) as y from result where state_id='" + sState + "' group by statue order by count(statue)", con);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            sChartResult = JsonConvert.SerializeObject(dt);
        }

        public void serialiseResultByExamType(string sState)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString());
            con.Open();
            SqlCommand comm = new SqlCommand("select exam_type as name, count(*) as y from result where state_id='" + sState + "' group by exam_type order by count(exam_type)", con);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            sExamType = JsonConvert.SerializeObject(dt);
        }
        public DataSet getTeacherIDRange(string Search)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT row_number() over(order by RegNo) as [S/N], RegNo as [TRCN_Teacher_Registration_Number], firstname + ' ' + middlename + ' ' + surname as  [Teacher_Names], Gender as [Gender], StateLocation as [State_of_Location], RegistrationDate as [Application_Date], qualification as [Highest_Qualification], category as [Category], startYear as [Teaching_Start_Year], CurrentEmployer as [Current_Employer], AreaofSpecialisation as [Area_of_Discipline] FROM (SELECT ISNULL(abi.registration_no,'') as [RegNo], ISNULL(abi.firstname, '') AS[firstname], ISNULL(abi.middlename, ' ') as [middlename], ISNULL(abi.surname, '') as [surname], ISNULL(abi.sex,'') as [Gender], ISNULL(abi.state_id,'') as [StateLocation], ISNULL(abi.application_date,'') as [RegistrationDate], ISNULL(abi.education_level,'') as [qualification], ISNULL(ABI.registration_status,'') as [RegistrationStatus], ISNULL(ABI.licensed_status,'') as [licensedStatus], ISNULL(ABI.licensed_date,'') as [LicensedDate], ISNULL(ABI.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ABI.printing_status,'') as [printingStatus], ISNULL(abi.category,'') as [category], ISNULL(abi.employment_date,'') as [startYear], ISNULL(ABI.current_employer,'') as [CurrentEmployer], ISNULL(ABI.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ABI.licensed_date, abi.licensed_expiring_date)  AS [licensed_validation] FROM ABIA abi  UNION ALL SELECT ISNULL(ABU.registration_no,'') as [RegNo], ISNULL(ABU.firstname, '') AS[firstname], ISNULL(ABU.middlename, ' ') as [middlename], ISNULL(ABU.surname, '') as [surname], ISNULL(ABU.sex,'') as [Gender], ISNULL(ABU.state_id,'') as [StateLocation], ISNULL(ABU.application_date,'') as [RegistrationDate], ISNULL(ABU.education_level,'') as [qualification], ISNULL(ABU.registration_status,'') as [RegistrationStatus], ISNULL(ABU.licensed_status,'') as [licensedStatus], ISNULL(ABU.licensed_date,'') as [LicensedDate], ISNULL(ABU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ABU.printing_status,'') as [printingStatus], ISNULL(ABU.category,'') as [category], ISNULL(ABU.employment_date,'') as [startYear], ISNULL(ABU.current_employer,'') as [CurrentEmployer], ISNULL(ABU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ABU.licensed_date, ABU.licensed_expiring_date)  AS [licensed_validation] FROM ABUJA ABU  UNION ALL SELECT ISNULL(ADA.registration_no,'') as [RegNo], ISNULL(ADA.firstname, '') AS[firstname], ISNULL(ADA.middlename, ' ') as [middlename], ISNULL(ADA.surname, '') as [surname], ISNULL(ADA.sex,'') as [Gender], ISNULL(ADA.state_id,'') as [StateLocation], ISNULL(ADA.application_date,' ') as [RegistrationDate], ISNULL(ADA.education_level,'') as [qualification], ISNULL(ADA.registration_status,'') as [RegistrationStatus], ISNULL(ADA.licensed_status,'') as [licensedStatus], ISNULL(ADA.licensed_date,'') as [LicensedDate], ISNULL(ADA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ADA.printing_status,'') as [printingStatus], ISNULL(ADA.category,'') as [category], ISNULL(ADA.employment_date,'') as [startYear], ISNULL(ADA.current_employer,'') as [CurrentEmployer], ISNULL(ADA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ADA.licensed_date, ADA.licensed_expiring_date)  AS [licensed_validation] FROM ADAMAWA ADA  UNION ALL SELECT ISNULL(AKW.registration_no,'') as [RegNo], ISNULL(AKW.firstname, '') AS[firstname], ISNULL(AKW.middlename, ' ') as [middlename], ISNULL(AKW.surname, '') as [surname], ISNULL(AKW.sex,'') as [Gender], ISNULL(AKW.state_id,'') as [StateLocation], ISNULL(AKW.application_date,' ') as [RegistrationDate], ISNULL(AKW.education_level,'') as [qualification], ISNULL(AKW.registration_status,'') as [RegistrationStatus], ISNULL(AKW.licensed_status,'') as [licensedStatus], ISNULL(AKW.licensed_date,'') as [LicensedDate], ISNULL(AKW.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(AKW.printing_status,'') as [printingStatus], ISNULL(AKW.category,'') as [category], ISNULL(AKW.employment_date,'') as [startYear], ISNULL(AKW.current_employer,'') as [CurrentEmployer], ISNULL(AKW.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, AKW.licensed_date, AKW.licensed_expiring_date)  AS [licensed_validation] FROM AKWAIBOM AKW  UNION ALL SELECT ISNULL(ANA.registration_no,'') as [RegNo], ISNULL(ANA.firstname, '') AS[firstname], ISNULL(ANA.middlename, ' ') as [middlename], ISNULL(ANA.surname, '') as [surname], ISNULL(ANA.sex,'') as [Gender], ISNULL(ANA.state_id,'') as [StateLocation], ISNULL(ANA.application_date,' ') as [RegistrationDate], ISNULL(ANA.education_level,'') as [qualification], ISNULL(ANA.registration_status,'') as [RegistrationStatus], ISNULL(ANA.licensed_status,'') as [licensedStatus], ISNULL(ANA.licensed_date,'') as [LicensedDate], ISNULL(ANA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ANA.printing_status,'') as [printingStatus], ISNULL(ANA.category,'') as [category], ISNULL(ANA.employment_date,'') as [startYear], ISNULL(ANA.current_employer,'') as [CurrentEmployer], ISNULL(ANA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ANA.licensed_date, ANA.licensed_expiring_date)  AS [licensed_validation] FROM ANAMBRA ANA  UNION ALL SELECT ISNULL(BAU.registration_no,'') as [RegNo], ISNULL(BAU.firstname, '') AS[firstname], ISNULL(BAU.middlename, ' ') as [middlename], ISNULL(BAU.surname, '') as [surname], ISNULL(BAU.sex,'') as [Gender], ISNULL(BAU.state_id,'') as [StateLocation], ISNULL(BAU.application_date,'') as [RegistrationDate], ISNULL(BAU.education_level,'') as [qualification], ISNULL(BAU.registration_status,'') as [RegistrationStatus], ISNULL(BAU.licensed_status,'') as [licensedStatus], ISNULL(BAU.licensed_date,'') as [LicensedDate], ISNULL(BAU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BAU.printing_status,'') as [printingStatus], ISNULL(BAU.category,'') as [category], ISNULL(BAU.employment_date,'') as [startYear], ISNULL(BAU.current_employer,'') as [CurrentEmployer], ISNULL(BAU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BAU.licensed_date, BAU.licensed_expiring_date)  AS [licensed_validation] FROM BAUCHI BAU  UNION ALL SELECT ISNULL(BAY.registration_no,'') as [RegNo], ISNULL(BAY.firstname, '') AS[firstname], ISNULL(BAY.middlename, ' ') as [middlename], ISNULL(BAY.surname, '') as [surname], ISNULL(BAY.sex,'') as [Gender], ISNULL(BAY.state_id,'') as [StateLocation], ISNULL(BAY.application_date,'') as [RegistrationDate], ISNULL(BAY.education_level,'') as [qualification], ISNULL(BAY.registration_status,'') as [RegistrationStatus], ISNULL(BAY.licensed_status,'') as [licensedStatus], ISNULL(BAY.licensed_date,'') as [LicensedDate], ISNULL(BAY.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BAY.printing_status,'') as [printingStatus], ISNULL(BAY.category,'') as [category], ISNULL(BAY.employment_date,'') as [startYear], ISNULL(BAY.current_employer,'') as [CurrentEmployer], ISNULL(BAY.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BAY.licensed_date, BAY.licensed_expiring_date)  AS [licensed_validation] FROM BAYELSA BAY  UNION ALL SELECT ISNULL(BEN.registration_no,'') as [RegNo], ISNULL(BEN.firstname, '') AS[firstname], ISNULL(BEN.middlename, ' ') as [middlename], ISNULL(BEN.surname, '') as [surname], ISNULL(BEN.sex,'') as [Gender], ISNULL(BEN.state_id,'') as [StateLocation], ISNULL(BEN.application_date,'') as [RegistrationDate], ISNULL(BEN.education_level,'') as [qualification], ISNULL(BEN.registration_status,'') as [RegistrationStatus], ISNULL(BEN.licensed_status,'') as [licensedStatus], ISNULL(BEN.licensed_date,'') as [LicensedDate], ISNULL(BEN.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BEN.printing_status,'') as [printingStatus], ISNULL(BEN.category,'') as [category], ISNULL(BEN.employment_date,'') as [startYear], ISNULL(BEN.current_employer,'') as [CurrentEmployer], ISNULL(BEN.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BEN.licensed_date, BEN.licensed_expiring_date)  AS [licensed_validation] FROM BENUE BEN  UNION ALL SELECT ISNULL(BOR.registration_no,'') as [RegNo], ISNULL(BOR.firstname, '') AS[firstname], ISNULL(BOR.middlename, ' ') as [middlename], ISNULL(BOR.surname, '') as [surname], ISNULL(BOR.sex,'') as [Gender], ISNULL(BOR.state_id,'') as [StateLocation], ISNULL(BOR.application_date,'') as [RegistrationDate], ISNULL(BOR.education_level,'') as [qualification], ISNULL(BOR.registration_status,'') as [RegistrationStatus], ISNULL(BOR.licensed_status,'') as [licensedStatus], ISNULL(BOR.licensed_date,'') as [LicensedDate], ISNULL(BOR.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BOR.printing_status,'') as [printingStatus], ISNULL(BOR.category,'') as [category], ISNULL(BOR.employment_date,'') as [startYear], ISNULL(BOR.current_employer,'') as [CurrentEmployer], ISNULL(BOR.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BOR.licensed_date, BOR.licensed_expiring_date)  AS [licensed_validation] FROM BORNO BOR  UNION ALL SELECT ISNULL(CRO.registration_no,'') as [RegNo], ISNULL(CRO.firstname, '') AS[firstname], ISNULL(CRO.middlename, ' ') as [middlename], ISNULL(CRO.surname, '') as [surname], ISNULL(CRO.sex,'') as [Gender], ISNULL(CRO.state_id,'') as [StateLocation], ISNULL(CRO.application_date,'') as [RegistrationDate], ISNULL(CRO.education_level,'') as [qualification], ISNULL(CRO.registration_status,'') as [RegistrationStatus], ISNULL(CRO.licensed_status,'') as [licensedStatus], ISNULL(CRO.licensed_date,'') as [LicensedDate], ISNULL(CRO.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(CRO.printing_status,'') as [printingStatus], ISNULL(CRO.category,'') as [category], ISNULL(CRO.employment_date,'') as [startYear], ISNULL(CRO.current_employer,'') as [CurrentEmployer], ISNULL(CRO.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, CRO.licensed_date, CRO.licensed_expiring_date)  AS [licensed_validation] FROM CROSSRIVER CRO UNION ALL SELECT ISNULL(DEL.registration_no,'') as [RegNo], ISNULL(DEL.firstname, '') AS[firstname], ISNULL(DEL.middlename, ' ') as [middlename], ISNULL(DEL.surname, '') as [surname], ISNULL(DEL.sex,'') as [Gender], ISNULL(DEL.state_id,'') as [StateLocation], ISNULL(DEL.application_date,'') as [RegistrationDate], ISNULL(DEL.education_level,'') as [qualification], ISNULL(DEL.registration_status,'') as [RegistrationStatus], ISNULL(DEL.licensed_status,'') as [licensedStatus], ISNULL(DEL.licensed_date,'') as [LicensedDate], ISNULL(DEL.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(DEL.printing_status,'') as [printingStatus], ISNULL(DEL.category,'') as [category], ISNULL(DEL.employment_date,'') as [startYear], ISNULL(DEL.current_employer,'') as [CurrentEmployer], ISNULL(DEL.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, DEL.licensed_date, DEL.licensed_expiring_date)  AS [licensed_validation] FROM DELTA DEL UNION ALL SELECT ISNULL(EBO.registration_no,'') as [RegNo], ISNULL(EBO.firstname, '') AS[firstname], ISNULL(EBO.middlename, ' ') as [middlename], ISNULL(EBO.surname, '') as [surname], ISNULL(EBO.sex,'') as [Gender], ISNULL(EBO.state_id,'') as [StateLocation], ISNULL(EBO.application_date,'') as [RegistrationDate], ISNULL(EBO.education_level,'') as [qualification], ISNULL(EBO.registration_status,'') as [RegistrationStatus], ISNULL(EBO.licensed_status,'') as [licensedStatus], ISNULL(EBO.licensed_date,'') as [LicensedDate], ISNULL(EBO.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EBO.printing_status,'') as [printingStatus], ISNULL(EBO.category,'') as [category], ISNULL(EBO.employment_date,'') as [startYear], ISNULL(EBO.current_employer,'') as [CurrentEmployer], ISNULL(EBO.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EBO.licensed_date, EBO.licensed_expiring_date)  AS [licensed_validation] FROM EBONYI EBO UNION ALL SELECT ISNULL(EDU.registration_no,'') as [RegNo], ISNULL(EDU.firstname, '') AS[firstname], ISNULL(EDU.middlename, ' ') as [middlename], ISNULL(EDU.surname, '') as [surname], ISNULL(EDU.sex,'') as [Gender], ISNULL(EDU.state_id,'') as [StateLocation], ISNULL(EDU.application_date,'') as [RegistrationDate], ISNULL(EDU.education_level,'') as [qualification], ISNULL(EDU.registration_status,'') as [RegistrationStatus], ISNULL(EDU.licensed_status,'') as [licensedStatus], ISNULL(EDU.licensed_date,'') as [LicensedDate], ISNULL(EDU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EDU.printing_status,'') as [printingStatus], ISNULL(EDU.category,'') as [category], ISNULL(EDU.employment_date,'') as [startYear], ISNULL(EDU.current_employer,'') as [CurrentEmployer], ISNULL(EDU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EDU.licensed_date, EDU.licensed_expiring_date)  AS [licensed_validation] FROM EDO EDU UNION ALL SELECT ISNULL(EK.registration_no,'') as [RegNo], ISNULL(EK.firstname, '') AS[firstname], ISNULL(EK.middlename, ' ') as [middlename], ISNULL(EK.surname, '') as [surname], ISNULL(EK.sex,'') as [Gender], ISNULL(EK.state_id,'') as [StateLocation], ISNULL(EK.application_date,'') as [RegistrationDate], ISNULL(EK.education_level,'') as [qualification], ISNULL(EK.registration_status,'') as [RegistrationStatus], ISNULL(EK.licensed_status,'') as [licensedStatus], ISNULL(EK.licensed_date,'') as [LicensedDate], ISNULL(EK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EK.printing_status,'') as [printingStatus], ISNULL(EK.category,'') as [category], ISNULL(EK.employment_date,'') as [startYear], ISNULL(EK.current_employer,'') as [CurrentEmployer], ISNULL(EK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EK.licensed_date, EK.licensed_expiring_date)  AS [licensed_validation] FROM EKITI EK UNION ALL SELECT ISNULL(ENU.registration_no,'') as [RegNo], ISNULL(ENU.firstname, '') AS[firstname], ISNULL(ENU.middlename, ' ') as [middlename], ISNULL(ENU.surname, '') as [surname], ISNULL(ENU.sex,'') as [Gender], ISNULL(ENU.state_id,'') as [StateLocation], ISNULL(ENU.application_date,'') as [RegistrationDate], ISNULL(ENU.education_level,'') as [qualification], ISNULL(ENU.registration_status,'') as [RegistrationStatus], ISNULL(ENU.licensed_status,'') as [licensedStatus], ISNULL(ENU.licensed_date,'') as [LicensedDate], ISNULL(ENU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ENU.printing_status,'') as [printingStatus], ISNULL(ENU.category,'') as [category], ISNULL(ENU.employment_date,'') as [startYear], ISNULL(ENU.current_employer,'') as [CurrentEmployer], ISNULL(ENU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ENU.licensed_date, ENU.licensed_expiring_date)  AS [licensed_validation] FROM ENUGU ENU UNION ALL SELECT ISNULL(GOM.registration_no,'') as [RegNo], ISNULL(GOM.firstname, '') AS[firstname], ISNULL(GOM.middlename, ' ') as [middlename], ISNULL(GOM.surname, '') as [surname], ISNULL(GOM.sex,'') as [Gender], ISNULL(GOM.state_id,'') as [StateLocation], ISNULL(GOM.application_date,'') as [RegistrationDate], ISNULL(GOM.education_level,'') as [qualification], ISNULL(GOM.registration_status,'') as [RegistrationStatus], ISNULL(GOM.licensed_status,'') as [licensedStatus], ISNULL(GOM.licensed_date,'') as [LicensedDate], ISNULL(GOM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(GOM.printing_status,'') as [printingStatus], ISNULL(GOM.category,'') as [category], ISNULL(GOM.employment_date,'') as [startYear], ISNULL(GOM.current_employer,'') as [CurrentEmployer], ISNULL(GOM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, GOM.licensed_date, GOM.licensed_expiring_date)  AS [licensed_validation] FROM GOMBE GOM UNION ALL SELECT ISNULL(IM.registration_no,'') as [RegNo], ISNULL(IM.firstname, '') AS[firstname], ISNULL(IM.middlename, ' ') as [middlename], ISNULL(IM.surname, '') as [surname], ISNULL(IM.sex,'') as [Gender], ISNULL(IM.state_id,'') as [StateLocation], ISNULL(IM.application_date,'') as [RegistrationDate], ISNULL(IM.education_level,'') as [qualification], ISNULL(IM.registration_status,'') as [RegistrationStatus], ISNULL(IM.licensed_status,'') as [licensedStatus], ISNULL(IM.licensed_date,'') as [LicensedDate], ISNULL(IM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(IM.printing_status,'') as [printingStatus], ISNULL(IM.category,'') as [category], ISNULL(IM.employment_date,'') as [startYear], ISNULL(IM.current_employer,'') as [CurrentEmployer], ISNULL(IM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, IM.licensed_date, IM.licensed_expiring_date)  AS [licensed_validation] FROM IMO IM UNION ALL SELECT ISNULL(JIG.registration_no,'') as [RegNo], ISNULL(JIG.firstname, '') AS[firstname], ISNULL(JIG.middlename, ' ') as [middlename], ISNULL(JIG.surname, '') as [surname], ISNULL(JIG.sex,'') as [Gender], ISNULL(JIG.state_id,'') as [StateLocation], ISNULL(JIG.application_date,'') as [RegistrationDate], ISNULL(JIG.education_level,'') as [qualification], ISNULL(JIG.registration_status,'') as [RegistrationStatus], ISNULL(JIG.licensed_status,'') as [licensedStatus], ISNULL(JIG.licensed_date,'') as [LicensedDate], ISNULL(JIG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(JIG.printing_status,'') as [printingStatus], ISNULL(JIG.category,'') as [category], ISNULL(JIG.employment_date,'') as [startYear], ISNULL(JIG.current_employer,'') as [CurrentEmployer], ISNULL(JIG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, JIG.licensed_date, JIG.licensed_expiring_date)  AS [licensed_validation] FROM JIGAWA JIG UNION ALL SELECT ISNULL(KAD.registration_no,'') as [RegNo], ISNULL(KAD.firstname, '') AS[firstname], ISNULL(KAD.middlename, ' ') as [middlename], ISNULL(KAD.surname, '') as [surname], ISNULL(KAD.sex,'') as [Gender], ISNULL(KAD.state_id,'') as [StateLocation], ISNULL(KAD.application_date,'') as [RegistrationDate], ISNULL(KAD.education_level,'') as [qualification], ISNULL(KAD.registration_status,'') as [RegistrationStatus], ISNULL(KAD.licensed_status,'') as [licensedStatus], ISNULL(KAD.licensed_date,'') as [LicensedDate], ISNULL(KAD.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAD.printing_status,'') as [printingStatus], ISNULL(KAD.category,'') as [category], ISNULL(KAD.employment_date,'') as [startYear], ISNULL(KAD.current_employer,'') as [CurrentEmployer], ISNULL(KAD.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAD.licensed_date, KAD.licensed_expiring_date)  AS [licensed_validation] FROM KADUNA KAD UNION ALL SELECT ISNULL(KAN.registration_no,'') as [RegNo], ISNULL(KAN.firstname, '') AS[firstname], ISNULL(KAN.middlename, ' ') as [middlename], ISNULL(KAN.surname, '') as [surname], ISNULL(KAN.sex,'') as [Gender], ISNULL(KAN.state_id,'') as [StateLocation], ISNULL(KAN.application_date,'') as [RegistrationDate], ISNULL(KAN.education_level,'') as [qualification], ISNULL(KAN.registration_status,'') as [RegistrationStatus], ISNULL(KAN.licensed_status,'') as [licensedStatus], ISNULL(KAN.licensed_date,'') as [LicensedDate], ISNULL(KAN.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAN.printing_status,'') as [printingStatus], ISNULL(KAN.category,'') as [category], ISNULL(KAN.employment_date,'') as [startYear], ISNULL(KAN.current_employer,'') as [CurrentEmployer], ISNULL(KAN.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAN.licensed_date, KAN.licensed_expiring_date)  AS [licensed_validation] FROM KANO KAN UNION ALL SELECT ISNULL(KAT.registration_no,'') as [RegNo], ISNULL(KAT.firstname, '') AS[firstname], ISNULL(KAT.middlename, ' ') as [middlename], ISNULL(KAT.surname, '') as [surname], ISNULL(KAT.sex,'') as [Gender], ISNULL(KAT.state_id,'') as [StateLocation], ISNULL(KAT.application_date,'') as [RegistrationDate], ISNULL(KAT.education_level,'') as [qualification], ISNULL(KAT.registration_status,'') as [RegistrationStatus], ISNULL(KAT.licensed_status,'') as [licensedStatus], ISNULL(KAT.licensed_date,'') as [LicensedDate], ISNULL(KAT.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAT.printing_status,'') as [printingStatus], ISNULL(KAT.category,'') as [category], ISNULL(KAT.employment_date,'') as [startYear], ISNULL(KAT.current_employer,'') as [CurrentEmployer], ISNULL(KAT.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAT.licensed_date, KAT.licensed_expiring_date)  AS [licensed_validation] FROM KATSINA KAT UNION ALL SELECT ISNULL(KEB.registration_no,'') as [RegNo], ISNULL(KEB.firstname, '') AS[firstname], ISNULL(KEB.middlename, ' ') as [middlename], ISNULL(KEB.surname, '') as [surname], ISNULL(KEB.sex,'') as [Gender], ISNULL(KEB.state_id,'') as [StateLocation], ISNULL(KEB.application_date,'') as [RegistrationDate], ISNULL(KEB.education_level,'') as [qualification], ISNULL(KEB.registration_status,'') as [RegistrationStatus], ISNULL(KEB.licensed_status,'') as [licensedStatus], ISNULL(KEB.licensed_date,'') as [LicensedDate], ISNULL(KEB.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KEB.printing_status,'') as [printingStatus], ISNULL(KEB.category,'') as [category], ISNULL(KEB.employment_date,'') as [startYear], ISNULL(KEB.current_employer,'') as [CurrentEmployer], ISNULL(KEB.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KEB.licensed_date, KEB.licensed_expiring_date)  AS [licensed_validation] FROM KEBBI KEB  UNION ALL SELECT ISNULL(KOG.registration_no,'') as [RegNo], ISNULL(KOG.firstname, '') AS[firstname], ISNULL(KOG.middlename, ' ') as [middlename], ISNULL(KOG.surname, '') as [surname], ISNULL(KOG.sex,'') as [Gender], ISNULL(KOG.state_id,'') as [StateLocation], ISNULL(KOG.application_date,'') as [RegistrationDate], ISNULL(KOG.education_level,'') as [qualification], ISNULL(KOG.registration_status,'') as [RegistrationStatus], ISNULL(KOG.licensed_status,'') as [licensedStatus], ISNULL(KOG.licensed_date,'') as [LicensedDate], ISNULL(KOG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KOG.printing_status,'') as [printingStatus], ISNULL(KOG.category,'') as [category], ISNULL(KOG.employment_date,'') as [startYear], ISNULL(KOG.current_employer,'') as [CurrentEmployer], ISNULL(KOG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KOG.licensed_date, KOG.licensed_expiring_date)  AS [licensed_validation] FROM KOGI KOG  UNION ALL SELECT ISNULL(KWA.registration_no,'') as [RegNo], ISNULL(KWA.firstname, '') AS[firstname], ISNULL(KWA.middlename, ' ') as [middlename], ISNULL(KWA.surname, '') as [surname], ISNULL(KWA.sex,'') as [Gender], ISNULL(KWA.state_id,'') as [StateLocation], ISNULL(KWA.application_date,'') as [RegistrationDate], ISNULL(KWA.education_level,'') as [qualification], ISNULL(KWA.registration_status,'') as [RegistrationStatus], ISNULL(KWA.licensed_status,'') as [licensedStatus], ISNULL(KWA.licensed_date,'') as [LicensedDate], ISNULL(KWA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KWA.printing_status,'') as [printingStatus], ISNULL(KWA.category,'') as [category], ISNULL(KWA.employment_date,'') as [startYear], ISNULL(KWA.current_employer,'') as [CurrentEmployer], ISNULL(KWA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KWA.licensed_date, KWA.licensed_expiring_date)  AS [licensed_validation] FROM KWARA KWA  UNION ALL SELECT ISNULL(LAG.registration_no,'') as [RegNo], ISNULL(LAG.firstname, '') AS[firstname], ISNULL(LAG.middlename, ' ') as [middlename], ISNULL(LAG.surname, '') as [surname], ISNULL(LAG.sex,'') as [Gender], ISNULL(LAG.state_id,'') as [StateLocation], ISNULL(LAG.application_date,'') as [RegistrationDate], ISNULL(LAG.education_level,'') as [qualification], ISNULL(LAG.registration_status,'') as [RegistrationStatus], ISNULL(LAG.licensed_status,'') as [licensedStatus], ISNULL(LAG.licensed_date,'') as [LicensedDate], ISNULL(LAG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(LAG.printing_status,'') as [printingStatus], ISNULL(LAG.category,'') as [category], ISNULL(LAG.employment_date,'') as [startYear], ISNULL(LAG.current_employer,'') as [CurrentEmployer], ISNULL(LAG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, LAG.licensed_date, LAG.licensed_expiring_date)  AS [licensed_validation] FROM LAGOS LAG  UNION ALL SELECT ISNULL(NAS.registration_no,'') as [RegNo], ISNULL(NAS.firstname, '') AS[firstname], ISNULL(NAS.middlename, ' ') as [middlename], ISNULL(NAS.surname, '') as [surname], ISNULL(NAS.sex,'') as [Gender], ISNULL(NAS.state_id,'') as [StateLocation], ISNULL(NAS.application_date,'') as [RegistrationDate], ISNULL(NAS.education_level,'') as [qualification], ISNULL(NAS.registration_status,'') as [RegistrationStatus], ISNULL(NAS.licensed_status,'') as [licensedStatus], ISNULL(NAS.licensed_date,'') as [LicensedDate], ISNULL(NAS.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(NAS.printing_status,'') as [printingStatus], ISNULL(NAS.category,'') as [category], ISNULL(NAS.employment_date,'') as [startYear], ISNULL(NAS.current_employer,'') as [CurrentEmployer], ISNULL(NAS.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, NAS.licensed_date, NAS.licensed_expiring_date)  AS [licensed_validation] FROM NASARAWA NAS  UNION ALL SELECT ISNULL(NAS.registration_no,'') as [RegNo], ISNULL(NAS.firstname, '') AS[firstname], ISNULL(NAS.middlename, ' ') as [middlename], ISNULL(NAS.surname, '') as [surname], ISNULL(NAS.sex,'') as [Gender], ISNULL(NAS.state_id,'') as [StateLocation], ISNULL(NAS.application_date,'') as [RegistrationDate], ISNULL(NAS.education_level,'') as [qualification], ISNULL(NAS.registration_status,'') as [RegistrationStatus], ISNULL(NAS.licensed_status,'') as [licensedStatus], ISNULL(NAS.licensed_date,'') as [LicensedDate], ISNULL(NAS.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(NAS.printing_status,'') as [printingStatus], ISNULL(NAS.category,'') as [category], ISNULL(NAS.employment_date,'') as [startYear], ISNULL(NAS.current_employer,'') as [CurrentEmployer], ISNULL(NAS.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, NAS.licensed_date, NAS.licensed_expiring_date)  AS [licensed_validation] FROM NASARAWA NAS UNION ALL SELECT ISNULL(OGU.registration_no,'') as [RegNo], ISNULL(OGU.firstname, '') AS[firstname], ISNULL(OGU.middlename, ' ') as [middlename], ISNULL(OGU.surname, '') as [surname], ISNULL(OGU.sex,'') as [Gender], ISNULL(OGU.state_id,'') as [StateLocation], ISNULL(OGU.application_date,'') as [RegistrationDate], ISNULL(OGU.education_level,'') as [qualification], ISNULL(OGU.registration_status,'') as [RegistrationStatus], ISNULL(OGU.licensed_status,'') as [licensedStatus], ISNULL(OGU.licensed_date,'') as [LicensedDate], ISNULL(OGU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OGU.printing_status,'') as [printingStatus], ISNULL(OGU.category,'') as [category], ISNULL(OGU.employment_date,'') as [startYear], ISNULL(OGU.current_employer,'') as [CurrentEmployer], ISNULL(OGU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OGU.licensed_date, OGU.licensed_expiring_date)  AS [licensed_validation] FROM OGUN OGU UNION ALL SELECT ISNULL(OND.registration_no,'') as [RegNo], ISNULL(OND.firstname, '') AS[firstname], ISNULL(OND.middlename, ' ') as [middlename], ISNULL(OND.surname, '') as [surname], ISNULL(OND.sex,'') as [Gender], ISNULL(OND.state_id,'') as [StateLocation], ISNULL(OND.application_date,'') as [RegistrationDate], ISNULL(OND.education_level,'') as [qualification], ISNULL(OND.registration_status,'') as [RegistrationStatus], ISNULL(OND.licensed_status,'') as [licensedStatus], ISNULL(OND.licensed_date,'') as [LicensedDate], ISNULL(OND.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OND.printing_status,'') as [printingStatus], ISNULL(OND.category,'') as [category], ISNULL(OND.employment_date,'') as [startYear], ISNULL(OND.current_employer,'') as [CurrentEmployer], ISNULL(OND.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OND.licensed_date, OND.licensed_expiring_date)  AS [licensed_validation] FROM ONDO OND UNION ALL SELECT ISNULL(OSIK.registration_no,'') as [RegNo], ISNULL(OSIK.firstname, '') AS[firstname], ISNULL(OSIK.middlename, ' ') as [middlename], ISNULL(OSIK.surname, '') as [surname], ISNULL(OSIK.sex,'') as [Gender], ISNULL(OSIK.state_id,'') as [StateLocation], ISNULL(OSIK.application_date,'') as [RegistrationState], ISNULL(OSIK.education_level,'') as [qualification], ISNULL(OSIK.registration_status,'') as [RegistrationStatus], ISNULL(OSIK.licensed_status,'') as [licensedStatus], ISNULL(OSIK.licensed_date,'') as [LicensedDate], ISNULL(OSIK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OSIK.printing_status,'') as [printingStatus], ISNULL(OSIK.category,'') as [category], ISNULL(OSIK.employment_date,'') as [startYear], ISNULL(OSIK.current_employer,'') as [CurrentEmployer], ISNULL(OSIK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OSIK.licensed_date, OSIK.licensed_expiring_date)  AS [licensed_validation] FROM OSUN OSIK UNION ALL SELECT ISNULL(OY.registration_no,'') as [RegNo], ISNULL(OY.firstname, '') AS[firstname], ISNULL(OY.middlename, ' ') as [middlename], ISNULL(OY.surname, '') as [surname], ISNULL(OY.sex,'') as [Gender], ISNULL(OY.state_id,'') as [StateLocation], ISNULL(OY.application_date,'') as [RegistrationState], ISNULL(OY.education_level,'') as [qualification], ISNULL(OY.registration_status,'') as [RegistrationStatus], ISNULL(OY.licensed_status,'') as [licensedStatus], ISNULL(OY.licensed_date,'') as [LicensedDate], ISNULL(OY.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OY.printing_status,'') as [printingStatus], ISNULL(OY.category,'') as [category], ISNULL(OY.employment_date,'') as [startYear], ISNULL(OY.current_employer,'') as [CurrentEmployer], ISNULL(OY.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OY.licensed_date, OY.licensed_expiring_date)  AS [licensed_validation] FROM OYO OY UNION ALL SELECT ISNULL(PLA.registration_no,'') as [RegNo], ISNULL(PLA.firstname, '') AS[firstname], ISNULL(PLA.middlename, ' ') as [middlename], ISNULL(PLA.surname, '') as [surname], ISNULL(PLA.sex,'') as [Gender], ISNULL(PLA.state_id,'') as [StateLocation], ISNULL(PLA.application_date,'') as [RegistrationState], ISNULL(PLA.education_level,'') as [qualification], ISNULL(PLA.registration_status,'') as [RegistrationStatus], ISNULL(PLA.licensed_status,'') as [licensedStatus], ISNULL(PLA.licensed_date,'') as [LicensedDate], ISNULL(PLA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(PLA.printing_status,'') as [printingStatus], ISNULL(PLA.category,'') as [category], ISNULL(PLA.employment_date,'') as [startYear], ISNULL(PLA.current_employer,'') as [CurrentEmployer], ISNULL(PLA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, PLA.licensed_date, PLA.licensed_expiring_date)  AS [licensed_validation] FROM PLATEAU PLA UNION ALL SELECT ISNULL(RIV.registration_no,'') as [RegNo], ISNULL(RIV.firstname, '') AS[firstname], ISNULL(RIV.middlename, ' ') as [middlename], ISNULL(RIV.surname, '') as [surname], ISNULL(RIV.sex,'') as [Gender], ISNULL(RIV.state_id,'') as [StateLocation], ISNULL(RIV.application_date,'') as [RegistrationState], ISNULL(RIV.education_level,'') as [qualification], ISNULL(RIV.registration_status,'') as [RegistrationStatus], ISNULL(RIV.licensed_status,'') as [licensedStatus], ISNULL(RIV.licensed_date,'') as [LicensedDate], ISNULL(RIV.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(RIV.printing_status,'') as [printingStatus], ISNULL(RIV.category,'') as [category], ISNULL(RIV.employment_date,'') as [startYear], ISNULL(RIV.current_employer,'') as [CurrentEmployer], ISNULL(RIV.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, RIV.licensed_date, RIV.licensed_expiring_date)  AS [licensed_validation] FROM RIVERS RIV UNION ALL SELECT ISNULL(SOK.registration_no,'') as [RegNo], ISNULL(SOK.firstname, '') AS[firstname], ISNULL(SOK.middlename, ' ') as [middlename], ISNULL(SOK.surname, '') as [surname], ISNULL(SOK.sex,'') as [Gender], ISNULL(SOK.state_id,'') as [StateLocation], ISNULL(SOK.application_date,'') as [RegistrationState], ISNULL(SOK.education_level,'') as [qualification], ISNULL(SOK.registration_status,'') as [RegistrationStatus], ISNULL(SOK.licensed_status,'') as [licensedStatus], ISNULL(SOK.licensed_date,'') as [LicensedDate], ISNULL(SOK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(SOK.printing_status,'') as [printingStatus], ISNULL(SOK.category,'') as [category], ISNULL(SOK.employment_date,'') as [startYear], ISNULL(SOK.current_employer,'') as [CurrentEmployer], ISNULL(SOK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, SOK.licensed_date, SOK.licensed_expiring_date)  AS [licensed_validation] FROM SOKOTO SOK UNION ALL SELECT ISNULL(TAR.registration_no,'') as [RegNo], ISNULL(TAR.firstname, '') AS[firstname], ISNULL(TAR.middlename, ' ') as [middlename], ISNULL(TAR.surname, '') as [surname], ISNULL(TAR.sex,'') as [Gender], ISNULL(TAR.state_id,'') as [StateLocation], ISNULL(TAR.application_date,'') as [RegistrationState], ISNULL(TAR.education_level,'') as [qualification], ISNULL(TAR.registration_status,'') as [RegistrationStatus], ISNULL(TAR.licensed_status,'') as [licensedStatus], ISNULL(TAR.licensed_date,'') as [LicensedDate], ISNULL(TAR.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(TAR.printing_status,'') as [printingStatus], ISNULL(TAR.category,'') as [category], ISNULL(TAR.employment_date,'') as [startYear], ISNULL(TAR.current_employer,'') as [CurrentEmployer], ISNULL(TAR.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, TAR.licensed_date, TAR.licensed_expiring_date)  AS [licensed_validation] FROM TARABA TAR  UNION ALL SELECT ISNULL(YK.registration_no,'') as [RegNo], ISNULL(YK.firstname, '') AS[firstname], ISNULL(YK.middlename, ' ') as [middlename], ISNULL(YK.surname, '') as [surname], ISNULL(YK.sex,'') as [Gender], ISNULL(YK.state_id,'') as [StateLocation], ISNULL(YK.application_date,'') as [RegistrationState], ISNULL(YK.education_level,'') as [qualification], ISNULL(YK.registration_status,'') as [RegistrationStatus], ISNULL(YK.licensed_status,'') as [licensedStatus], ISNULL(YK.licensed_date,'') as [LicensedDate], ISNULL(YK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(YK.printing_status,'') as [printingStatus], ISNULL(YK.category,'') as [category], ISNULL(YK.employment_date,'') as [startYear], ISNULL(YK.current_employer,'') as [CurrentEmployer], ISNULL(YK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, YK.licensed_date, YK.licensed_expiring_date)  AS [licensed_validation] FROM YOBE YK  UNION ALL SELECT ISNULL(ZAM.registration_no,'') as [RegNo], ISNULL(ZAM.firstname, '') AS[firstname], ISNULL(ZAM.middlename, ' ') as [middlename], ISNULL(ZAM.surname, '') as [surname], ISNULL(ZAM.sex,'') as [Gender], ISNULL(ZAM.state_id,'') as [StateLocation], ISNULL(ZAM.application_date,'') as [RegistrationState], ISNULL(ZAM.education_level,'') as [qualification], ISNULL(ZAM.registration_status,'') as [RegistrationStatus], ISNULL(ZAM.licensed_status,'') as [licensedStatus], ISNULL(ZAM.licensed_date,'') as [LicensedDate], ISNULL(ZAM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ZAM.printing_status,'') as [printingStatus], ISNULL(ZAM.category,'') as [category], ISNULL(ZAM.employment_date,'') as [startYear], ISNULL(ZAM.current_employer,'') as [CurrentEmployer], ISNULL(ZAM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ZAM.licensed_date, ZAM.licensed_expiring_date)  AS [licensed_validation] FROM ZAMFARA ZAM ) AS tblAllState WHERE regno='" + Search + "' or firstname='" + Search + "' or middlename='" + Search + "' or surname='" + Search + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public bool checkRegStatus(string sSearch)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT row_number() over(order by RegNo) as [S/N], RegNo as [TRCN_Teacher_Registration_Number], firstname + ' ' + middlename + ' ' + surname as  [Teacher_Names], Gender as [Gender], StateLocation as [State_of_Location], RegistrationDate as [Application_Date], qualification as [Highest_Qualification], category as [Category], startYear as [Teaching_Start_Year], RegistrationStatus as [Registration_Status], licensedStatus as [Licensed_Status], LicensedDate as [Licensed_date], ExpiringDate as [Expiring_Date], CurrentEmployer as [Current_Employer], AreaofSpecialisation as [Area_of_Discipline], CASE WHEN licensed_validation <=0 THEN 'NOT VALID' ELSE 'VALID' END  as [Valid_License], printingStatus as [Printing_Status]  FROM(SELECT ISNULL(abi.registration_no,'') as [RegNo], ISNULL(abi.firstname, '') AS[firstname], ISNULL(abi.middlename, ' ') as [middlename], ISNULL(abi.surname, '') as [surname], ISNULL(abi.sex,'') as [Gender], ISNULL(abi.state_id,'') as [StateLocation], ISNULL(abi.application_date,'') as [RegistrationDate], ISNULL(abi.education_level,'') as [qualification], ISNULL(ABI.registration_status,'') as [RegistrationStatus], ISNULL(ABI.licensed_status,'') as [licensedStatus], ISNULL(ABI.licensed_date,'') as [LicensedDate], ISNULL(ABI.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ABI.printing_status,'') as [printingStatus], ISNULL(abi.category,'') as [category], ISNULL(abi.employment_date,'') as [startYear], ISNULL(ABI.current_employer,'') as [CurrentEmployer], ISNULL(ABI.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ABI.licensed_date, abi.licensed_expiring_date)  AS [licensed_validation] FROM ABIA abi  UNION ALL SELECT ISNULL(ABU.registration_no,'') as [RegNo], ISNULL(ABU.firstname, '') AS[firstname], ISNULL(ABU.middlename, ' ') as [middlename], ISNULL(ABU.surname, '') as [surname], ISNULL(ABU.sex,'') as [Gender], ISNULL(ABU.state_id,'') as [StateLocation], ISNULL(ABU.application_date,'') as [RegistrationDate], ISNULL(ABU.education_level,'') as [qualification], ISNULL(ABU.registration_status,'') as [RegistrationStatus], ISNULL(ABU.licensed_status,'') as [licensedStatus], ISNULL(ABU.licensed_date,'') as [LicensedDate], ISNULL(ABU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ABU.printing_status,'') as [printingStatus], ISNULL(ABU.category,'') as [category], ISNULL(ABU.employment_date,'') as [startYear], ISNULL(ABU.current_employer,'') as [CurrentEmployer], ISNULL(ABU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ABU.licensed_date, ABU.licensed_expiring_date)  AS [licensed_validation] FROM ABUJA ABU  UNION ALL SELECT ISNULL(ADA.registration_no,'') as [RegNo], ISNULL(ADA.firstname, '') AS[firstname], ISNULL(ADA.middlename, ' ') as [middlename], ISNULL(ADA.surname, '') as [surname], ISNULL(ADA.sex,'') as [Gender], ISNULL(ADA.state_id,'') as [StateLocation], ISNULL(ADA.application_date,' ') as [RegistrationDate], ISNULL(ADA.education_level,'') as [qualification], ISNULL(ADA.registration_status,'') as [RegistrationStatus], ISNULL(ADA.licensed_status,'') as [licensedStatus], ISNULL(ADA.licensed_date,'') as [LicensedDate], ISNULL(ADA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ADA.printing_status,'') as [printingStatus], ISNULL(ADA.category,'') as [category], ISNULL(ADA.employment_date,'') as [startYear], ISNULL(ADA.current_employer,'') as [CurrentEmployer], ISNULL(ADA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ADA.licensed_date, ADA.licensed_expiring_date)  AS [licensed_validation] FROM ADAMAWA ADA  UNION ALL SELECT ISNULL(AKW.registration_no,'') as [RegNo], ISNULL(AKW.firstname, '') AS[firstname], ISNULL(AKW.middlename, ' ') as [middlename], ISNULL(AKW.surname, '') as [surname], ISNULL(AKW.sex,'') as [Gender], ISNULL(AKW.state_id,'') as [StateLocation], ISNULL(AKW.application_date,' ') as [RegistrationDate], ISNULL(AKW.education_level,'') as [qualification], ISNULL(AKW.registration_status,'') as [RegistrationStatus], ISNULL(AKW.licensed_status,'') as [licensedStatus], ISNULL(AKW.licensed_date,'') as [LicensedDate], ISNULL(AKW.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(AKW.printing_status,'') as [printingStatus], ISNULL(AKW.category,'') as [category], ISNULL(AKW.employment_date,'') as [startYear], ISNULL(AKW.current_employer,'') as [CurrentEmployer], ISNULL(AKW.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, AKW.licensed_date, AKW.licensed_expiring_date)  AS [licensed_validation] FROM AKWAIBOM AKW  UNION ALL SELECT ISNULL(ANA.registration_no,'') as [RegNo], ISNULL(ANA.firstname, '') AS[firstname], ISNULL(ANA.middlename, ' ') as [middlename], ISNULL(ANA.surname, '') as [surname], ISNULL(ANA.sex,'') as [Gender], ISNULL(ANA.state_id,'') as [StateLocation], ISNULL(ANA.application_date,' ') as [RegistrationDate], ISNULL(ANA.education_level,'') as [qualification], ISNULL(ANA.registration_status,'') as [RegistrationStatus], ISNULL(ANA.licensed_status,'') as [licensedStatus], ISNULL(ANA.licensed_date,'') as [LicensedDate], ISNULL(ANA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ANA.printing_status,'') as [printingStatus], ISNULL(ANA.category,'') as [category], ISNULL(ANA.employment_date,'') as [startYear], ISNULL(ANA.current_employer,'') as [CurrentEmployer], ISNULL(ANA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ANA.licensed_date, ANA.licensed_expiring_date)  AS [licensed_validation] FROM ANAMBRA ANA  UNION ALL SELECT ISNULL(BAU.registration_no,'') as [RegNo], ISNULL(BAU.firstname, '') AS[firstname], ISNULL(BAU.middlename, ' ') as [middlename], ISNULL(BAU.surname, '') as [surname], ISNULL(BAU.sex,'') as [Gender], ISNULL(BAU.state_id,'') as [StateLocation], ISNULL(BAU.application_date,'') as [RegistrationDate], ISNULL(BAU.education_level,'') as [qualification], ISNULL(BAU.registration_status,'') as [RegistrationStatus], ISNULL(BAU.licensed_status,'') as [licensedStatus], ISNULL(BAU.licensed_date,'') as [LicensedDate], ISNULL(BAU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BAU.printing_status,'') as [printingStatus], ISNULL(BAU.category,'') as [category], ISNULL(BAU.employment_date,'') as [startYear], ISNULL(BAU.current_employer,'') as [CurrentEmployer], ISNULL(BAU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BAU.licensed_date, BAU.licensed_expiring_date)  AS [licensed_validation] FROM BAUCHI BAU  UNION ALL SELECT ISNULL(BAY.registration_no,'') as [RegNo], ISNULL(BAY.firstname, '') AS[firstname], ISNULL(BAY.middlename, ' ') as [middlename], ISNULL(BAY.surname, '') as [surname], ISNULL(BAY.sex,'') as [Gender], ISNULL(BAY.state_id,'') as [StateLocation], ISNULL(BAY.application_date,'') as [RegistrationDate], ISNULL(BAY.education_level,'') as [qualification], ISNULL(BAY.registration_status,'') as [RegistrationStatus], ISNULL(BAY.licensed_status,'') as [licensedStatus], ISNULL(BAY.licensed_date,'') as [LicensedDate], ISNULL(BAY.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BAY.printing_status,'') as [printingStatus], ISNULL(BAY.category,'') as [category], ISNULL(BAY.employment_date,'') as [startYear], ISNULL(BAY.current_employer,'') as [CurrentEmployer], ISNULL(BAY.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BAY.licensed_date, BAY.licensed_expiring_date)  AS [licensed_validation] FROM BAYELSA BAY  UNION ALL SELECT ISNULL(BEN.registration_no,'') as [RegNo], ISNULL(BEN.firstname, '') AS[firstname], ISNULL(BEN.middlename, ' ') as [middlename], ISNULL(BEN.surname, '') as [surname], ISNULL(BEN.sex,'') as [Gender], ISNULL(BEN.state_id,'') as [StateLocation], ISNULL(BEN.application_date,'') as [RegistrationDate], ISNULL(BEN.education_level,'') as [qualification], ISNULL(BEN.registration_status,'') as [RegistrationStatus], ISNULL(BEN.licensed_status,'') as [licensedStatus], ISNULL(BEN.licensed_date,'') as [LicensedDate], ISNULL(BEN.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BEN.printing_status,'') as [printingStatus], ISNULL(BEN.category,'') as [category], ISNULL(BEN.employment_date,'') as [startYear], ISNULL(BEN.current_employer,'') as [CurrentEmployer], ISNULL(BEN.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BEN.licensed_date, BEN.licensed_expiring_date)  AS [licensed_validation] FROM BENUE BEN  UNION ALL SELECT ISNULL(BOR.registration_no,'') as [RegNo], ISNULL(BOR.firstname, '') AS[firstname], ISNULL(BOR.middlename, ' ') as [middlename], ISNULL(BOR.surname, '') as [surname], ISNULL(BOR.sex,'') as [Gender], ISNULL(BOR.state_id,'') as [StateLocation], ISNULL(BOR.application_date,'') as [RegistrationDate], ISNULL(BOR.education_level,'') as [qualification], ISNULL(BOR.registration_status,'') as [RegistrationStatus], ISNULL(BOR.licensed_status,'') as [licensedStatus], ISNULL(BOR.licensed_date,'') as [LicensedDate], ISNULL(BOR.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(BOR.printing_status,'') as [printingStatus], ISNULL(BOR.category,'') as [category], ISNULL(BOR.employment_date,'') as [startYear], ISNULL(BOR.current_employer,'') as [CurrentEmployer], ISNULL(BOR.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, BOR.licensed_date, BOR.licensed_expiring_date)  AS [licensed_validation] FROM BORNO BOR  UNION ALL SELECT ISNULL(CRO.registration_no,'') as [RegNo], ISNULL(CRO.firstname, '') AS[firstname], ISNULL(CRO.middlename, ' ') as [middlename], ISNULL(CRO.surname, '') as [surname], ISNULL(CRO.sex,'') as [Gender], ISNULL(CRO.state_id,'') as [StateLocation], ISNULL(CRO.application_date,'') as [RegistrationDate], ISNULL(CRO.education_level,'') as [qualification], ISNULL(CRO.registration_status,'') as [RegistrationStatus], ISNULL(CRO.licensed_status,'') as [licensedStatus], ISNULL(CRO.licensed_date,'') as [LicensedDate], ISNULL(CRO.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(CRO.printing_status,'') as [printingStatus], ISNULL(CRO.category,'') as [category], ISNULL(CRO.employment_date,'') as [startYear], ISNULL(CRO.current_employer,'') as [CurrentEmployer], ISNULL(CRO.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, CRO.licensed_date, CRO.licensed_expiring_date)  AS [licensed_validation] FROM CROSSRIVER CRO UNION ALL SELECT ISNULL(DEL.registration_no,'') as [RegNo], ISNULL(DEL.firstname, '') AS[firstname], ISNULL(DEL.middlename, ' ') as [middlename], ISNULL(DEL.surname, '') as [surname], ISNULL(DEL.sex,'') as [Gender], ISNULL(DEL.state_id,'') as [StateLocation], ISNULL(DEL.application_date,'') as [RegistrationDate], ISNULL(DEL.education_level,'') as [qualification], ISNULL(DEL.registration_status,'') as [RegistrationStatus], ISNULL(DEL.licensed_status,'') as [licensedStatus], ISNULL(DEL.licensed_date,'') as [LicensedDate], ISNULL(DEL.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(DEL.printing_status,'') as [printingStatus], ISNULL(DEL.category,'') as [category], ISNULL(DEL.employment_date,'') as [startYear], ISNULL(DEL.current_employer,'') as [CurrentEmployer], ISNULL(DEL.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, DEL.licensed_date, DEL.licensed_expiring_date)  AS [licensed_validation] FROM DELTA DEL UNION ALL SELECT ISNULL(EBO.registration_no,'') as [RegNo], ISNULL(EBO.firstname, '') AS[firstname], ISNULL(EBO.middlename, ' ') as [middlename], ISNULL(EBO.surname, '') as [surname], ISNULL(EBO.sex,'') as [Gender], ISNULL(EBO.state_id,'') as [StateLocation], ISNULL(EBO.application_date,'') as [RegistrationDate], ISNULL(EBO.education_level,'') as [qualification], ISNULL(EBO.registration_status,'') as [RegistrationStatus], ISNULL(EBO.licensed_status,'') as [licensedStatus], ISNULL(EBO.licensed_date,'') as [LicensedDate], ISNULL(EBO.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EBO.printing_status,'') as [printingStatus], ISNULL(EBO.category,'') as [category], ISNULL(EBO.employment_date,'') as [startYear], ISNULL(EBO.current_employer,'') as [CurrentEmployer], ISNULL(EBO.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EBO.licensed_date, EBO.licensed_expiring_date)  AS [licensed_validation] FROM EBONYI EBO UNION ALL SELECT ISNULL(EDU.registration_no,'') as [RegNo], ISNULL(EDU.firstname, '') AS[firstname], ISNULL(EDU.middlename, ' ') as [middlename], ISNULL(EDU.surname, '') as [surname], ISNULL(EDU.sex,'') as [Gender], ISNULL(EDU.state_id,'') as [StateLocation], ISNULL(EDU.application_date,'') as [RegistrationDate], ISNULL(EDU.education_level,'') as [qualification], ISNULL(EDU.registration_status,'') as [RegistrationStatus], ISNULL(EDU.licensed_status,'') as [licensedStatus], ISNULL(EDU.licensed_date,'') as [LicensedDate], ISNULL(EDU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EDU.printing_status,'') as [printingStatus], ISNULL(EDU.category,'') as [category], ISNULL(EDU.employment_date,'') as [startYear], ISNULL(EDU.current_employer,'') as [CurrentEmployer], ISNULL(EDU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EDU.licensed_date, EDU.licensed_expiring_date)  AS [licensed_validation] FROM EDO EDU UNION ALL SELECT ISNULL(EK.registration_no,'') as [RegNo], ISNULL(EK.firstname, '') AS[firstname], ISNULL(EK.middlename, ' ') as [middlename], ISNULL(EK.surname, '') as [surname], ISNULL(EK.sex,'') as [Gender], ISNULL(EK.state_id,'') as [StateLocation], ISNULL(EK.application_date,'') as [RegistrationDate], ISNULL(EK.education_level,'') as [qualification], ISNULL(EK.registration_status,'') as [RegistrationStatus], ISNULL(EK.licensed_status,'') as [licensedStatus], ISNULL(EK.licensed_date,'') as [LicensedDate], ISNULL(EK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(EK.printing_status,'') as [printingStatus], ISNULL(EK.category,'') as [category], ISNULL(EK.employment_date,'') as [startYear], ISNULL(EK.current_employer,'') as [CurrentEmployer], ISNULL(EK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, EK.licensed_date, EK.licensed_expiring_date)  AS [licensed_validation] FROM EKITI EK UNION ALL SELECT ISNULL(ENU.registration_no,'') as [RegNo], ISNULL(ENU.firstname, '') AS[firstname], ISNULL(ENU.middlename, ' ') as [middlename], ISNULL(ENU.surname, '') as [surname], ISNULL(ENU.sex,'') as [Gender], ISNULL(ENU.state_id,'') as [StateLocation], ISNULL(ENU.application_date,'') as [RegistrationDate], ISNULL(ENU.education_level,'') as [qualification], ISNULL(ENU.registration_status,'') as [RegistrationStatus], ISNULL(ENU.licensed_status,'') as [licensedStatus], ISNULL(ENU.licensed_date,'') as [LicensedDate], ISNULL(ENU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ENU.printing_status,'') as [printingStatus], ISNULL(ENU.category,'') as [category], ISNULL(ENU.employment_date,'') as [startYear], ISNULL(ENU.current_employer,'') as [CurrentEmployer], ISNULL(ENU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ENU.licensed_date, ENU.licensed_expiring_date)  AS [licensed_validation] FROM ENUGU ENU UNION ALL SELECT ISNULL(GOM.registration_no,'') as [RegNo], ISNULL(GOM.firstname, '') AS[firstname], ISNULL(GOM.middlename, ' ') as [middlename], ISNULL(GOM.surname, '') as [surname], ISNULL(GOM.sex,'') as [Gender], ISNULL(GOM.state_id,'') as [StateLocation], ISNULL(GOM.application_date,'') as [RegistrationDate], ISNULL(GOM.education_level,'') as [qualification], ISNULL(GOM.registration_status,'') as [RegistrationStatus], ISNULL(GOM.licensed_status,'') as [licensedStatus], ISNULL(GOM.licensed_date,'') as [LicensedDate], ISNULL(GOM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(GOM.printing_status,'') as [printingStatus], ISNULL(GOM.category,'') as [category], ISNULL(GOM.employment_date,'') as [startYear], ISNULL(GOM.current_employer,'') as [CurrentEmployer], ISNULL(GOM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, GOM.licensed_date, GOM.licensed_expiring_date)  AS [licensed_validation] FROM GOMBE GOM UNION ALL SELECT ISNULL(IM.registration_no,'') as [RegNo], ISNULL(IM.firstname, '') AS[firstname], ISNULL(IM.middlename, ' ') as [middlename], ISNULL(IM.surname, '') as [surname], ISNULL(IM.sex,'') as [Gender], ISNULL(IM.state_id,'') as [StateLocation], ISNULL(IM.application_date,'') as [RegistrationDate], ISNULL(IM.education_level,'') as [qualification], ISNULL(IM.registration_status,'') as [RegistrationStatus], ISNULL(IM.licensed_status,'') as [licensedStatus], ISNULL(IM.licensed_date,'') as [LicensedDate], ISNULL(IM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(IM.printing_status,'') as [printingStatus], ISNULL(IM.category,'') as [category], ISNULL(IM.employment_date,'') as [startYear], ISNULL(IM.current_employer,'') as [CurrentEmployer], ISNULL(IM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, IM.licensed_date, IM.licensed_expiring_date)  AS [licensed_validation] FROM IMO IM UNION ALL SELECT ISNULL(JIG.registration_no,'') as [RegNo], ISNULL(JIG.firstname, '') AS[firstname], ISNULL(JIG.middlename, ' ') as [middlename], ISNULL(JIG.surname, '') as [surname], ISNULL(JIG.sex,'') as [Gender], ISNULL(JIG.state_id,'') as [StateLocation], ISNULL(JIG.application_date,'') as [RegistrationDate], ISNULL(JIG.education_level,'') as [qualification], ISNULL(JIG.registration_status,'') as [RegistrationStatus], ISNULL(JIG.licensed_status,'') as [licensedStatus], ISNULL(JIG.licensed_date,'') as [LicensedDate], ISNULL(JIG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(JIG.printing_status,'') as [printingStatus], ISNULL(JIG.category,'') as [category], ISNULL(JIG.employment_date,'') as [startYear], ISNULL(JIG.current_employer,'') as [CurrentEmployer], ISNULL(JIG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, JIG.licensed_date, JIG.licensed_expiring_date)  AS [licensed_validation] FROM JIGAWA JIG UNION ALL SELECT ISNULL(KAD.registration_no,'') as [RegNo], ISNULL(KAD.firstname, '') AS[firstname], ISNULL(KAD.middlename, ' ') as [middlename], ISNULL(KAD.surname, '') as [surname], ISNULL(KAD.sex,'') as [Gender], ISNULL(KAD.state_id,'') as [StateLocation], ISNULL(KAD.application_date,'') as [RegistrationDate], ISNULL(KAD.education_level,'') as [qualification], ISNULL(KAD.registration_status,'') as [RegistrationStatus], ISNULL(KAD.licensed_status,'') as [licensedStatus], ISNULL(KAD.licensed_date,'') as [LicensedDate], ISNULL(KAD.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAD.printing_status,'') as [printingStatus], ISNULL(KAD.category,'') as [category], ISNULL(KAD.employment_date,'') as [startYear], ISNULL(KAD.current_employer,'') as [CurrentEmployer], ISNULL(KAD.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAD.licensed_date, KAD.licensed_expiring_date)  AS [licensed_validation] FROM KADUNA KAD UNION ALL SELECT ISNULL(KAN.registration_no,'') as [RegNo], ISNULL(KAN.firstname, '') AS[firstname], ISNULL(KAN.middlename, ' ') as [middlename], ISNULL(KAN.surname, '') as [surname], ISNULL(KAN.sex,'') as [Gender], ISNULL(KAN.state_id,'') as [StateLocation], ISNULL(KAN.application_date,'') as [RegistrationDate], ISNULL(KAN.education_level,'') as [qualification], ISNULL(KAN.registration_status,'') as [RegistrationStatus], ISNULL(KAN.licensed_status,'') as [licensedStatus], ISNULL(KAN.licensed_date,'') as [LicensedDate], ISNULL(KAN.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAN.printing_status,'') as [printingStatus], ISNULL(KAN.category,'') as [category], ISNULL(KAN.employment_date,'') as [startYear], ISNULL(KAN.current_employer,'') as [CurrentEmployer], ISNULL(KAN.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAN.licensed_date, KAN.licensed_expiring_date)  AS [licensed_validation] FROM KANO KAN UNION ALL SELECT ISNULL(KAT.registration_no,'') as [RegNo], ISNULL(KAT.firstname, '') AS[firstname], ISNULL(KAT.middlename, ' ') as [middlename], ISNULL(KAT.surname, '') as [surname], ISNULL(KAT.sex,'') as [Gender], ISNULL(KAT.state_id,'') as [StateLocation], ISNULL(KAT.application_date,'') as [RegistrationDate], ISNULL(KAT.education_level,'') as [qualification], ISNULL(KAT.registration_status,'') as [RegistrationStatus], ISNULL(KAT.licensed_status,'') as [licensedStatus], ISNULL(KAT.licensed_date,'') as [LicensedDate], ISNULL(KAT.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KAT.printing_status,'') as [printingStatus], ISNULL(KAT.category,'') as [category], ISNULL(KAT.employment_date,'') as [startYear], ISNULL(KAT.current_employer,'') as [CurrentEmployer], ISNULL(KAT.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KAT.licensed_date, KAT.licensed_expiring_date)  AS [licensed_validation] FROM KATSINA KAT UNION ALL SELECT ISNULL(KEB.registration_no,'') as [RegNo], ISNULL(KEB.firstname, '') AS[firstname], ISNULL(KEB.middlename, ' ') as [middlename], ISNULL(KEB.surname, '') as [surname], ISNULL(KEB.sex,'') as [Gender], ISNULL(KEB.state_id,'') as [StateLocation], ISNULL(KEB.application_date,'') as [RegistrationDate], ISNULL(KEB.education_level,'') as [qualification], ISNULL(KEB.registration_status,'') as [RegistrationStatus], ISNULL(KEB.licensed_status,'') as [licensedStatus], ISNULL(KEB.licensed_date,'') as [LicensedDate], ISNULL(KEB.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KEB.printing_status,'') as [printingStatus], ISNULL(KEB.category,'') as [category], ISNULL(KEB.employment_date,'') as [startYear], ISNULL(KEB.current_employer,'') as [CurrentEmployer], ISNULL(KEB.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KEB.licensed_date, KEB.licensed_expiring_date)  AS [licensed_validation] FROM KEBBI KEB  UNION ALL SELECT ISNULL(KOG.registration_no,'') as [RegNo], ISNULL(KOG.firstname, '') AS[firstname], ISNULL(KOG.middlename, ' ') as [middlename], ISNULL(KOG.surname, '') as [surname], ISNULL(KOG.sex,'') as [Gender], ISNULL(KOG.state_id,'') as [StateLocation], ISNULL(KOG.application_date,'') as [RegistrationDate], ISNULL(KOG.education_level,'') as [qualification], ISNULL(KOG.registration_status,'') as [RegistrationStatus], ISNULL(KOG.licensed_status,'') as [licensedStatus], ISNULL(KOG.licensed_date,'') as [LicensedDate], ISNULL(KOG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KOG.printing_status,'') as [printingStatus], ISNULL(KOG.category,'') as [category], ISNULL(KOG.employment_date,'') as [startYear], ISNULL(KOG.current_employer,'') as [CurrentEmployer], ISNULL(KOG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KOG.licensed_date, KOG.licensed_expiring_date)  AS [licensed_validation] FROM KOGI KOG  UNION ALL SELECT ISNULL(KWA.registration_no,'') as [RegNo], ISNULL(KWA.firstname, '') AS[firstname], ISNULL(KWA.middlename, ' ') as [middlename], ISNULL(KWA.surname, '') as [surname], ISNULL(KWA.sex,'') as [Gender], ISNULL(KWA.state_id,'') as [StateLocation], ISNULL(KWA.application_date,'') as [RegistrationDate], ISNULL(KWA.education_level,'') as [qualification], ISNULL(KWA.registration_status,'') as [RegistrationStatus], ISNULL(KWA.licensed_status,'') as [licensedStatus], ISNULL(KWA.licensed_date,'') as [LicensedDate], ISNULL(KWA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(KWA.printing_status,'') as [printingStatus], ISNULL(KWA.category,'') as [category], ISNULL(KWA.employment_date,'') as [startYear], ISNULL(KWA.current_employer,'') as [CurrentEmployer], ISNULL(KWA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, KWA.licensed_date, KWA.licensed_expiring_date)  AS [licensed_validation] FROM KWARA KWA  UNION ALL SELECT ISNULL(LAG.registration_no,'') as [RegNo], ISNULL(LAG.firstname, '') AS[firstname], ISNULL(LAG.middlename, ' ') as [middlename], ISNULL(LAG.surname, '') as [surname], ISNULL(LAG.sex,'') as [Gender], ISNULL(LAG.state_id,'') as [StateLocation], ISNULL(LAG.application_date,'') as [RegistrationDate], ISNULL(LAG.education_level,'') as [qualification], ISNULL(LAG.registration_status,'') as [RegistrationStatus], ISNULL(LAG.licensed_status,'') as [licensedStatus], ISNULL(LAG.licensed_date,'') as [LicensedDate], ISNULL(LAG.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(LAG.printing_status,'') as [printingStatus], ISNULL(LAG.category,'') as [category], ISNULL(LAG.employment_date,'') as [startYear], ISNULL(LAG.current_employer,'') as [CurrentEmployer], ISNULL(LAG.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, LAG.licensed_date, LAG.licensed_expiring_date)  AS [licensed_validation] FROM LAGOS LAG  UNION ALL SELECT ISNULL(NAS.registration_no,'') as [RegNo], ISNULL(NAS.firstname, '') AS[firstname], ISNULL(NAS.middlename, ' ') as [middlename], ISNULL(NAS.surname, '') as [surname], ISNULL(NAS.sex,'') as [Gender], ISNULL(NAS.state_id,'') as [StateLocation], ISNULL(NAS.application_date,'') as [RegistrationDate], ISNULL(NAS.education_level,'') as [qualification], ISNULL(NAS.registration_status,'') as [RegistrationStatus], ISNULL(NAS.licensed_status,'') as [licensedStatus], ISNULL(NAS.licensed_date,'') as [LicensedDate], ISNULL(NAS.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(NAS.printing_status,'') as [printingStatus], ISNULL(NAS.category,'') as [category], ISNULL(NAS.employment_date,'') as [startYear], ISNULL(NAS.current_employer,'') as [CurrentEmployer], ISNULL(NAS.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, NAS.licensed_date, NAS.licensed_expiring_date)  AS [licensed_validation] FROM NASARAWA NAS  UNION ALL SELECT ISNULL(NAS.registration_no,'') as [RegNo], ISNULL(NAS.firstname, '') AS[firstname], ISNULL(NAS.middlename, ' ') as [middlename], ISNULL(NAS.surname, '') as [surname], ISNULL(NAS.sex,'') as [Gender], ISNULL(NAS.state_id,'') as [StateLocation], ISNULL(NAS.application_date,'') as [RegistrationDate], ISNULL(NAS.education_level,'') as [qualification], ISNULL(NAS.registration_status,'') as [RegistrationStatus], ISNULL(NAS.licensed_status,'') as [licensedStatus], ISNULL(NAS.licensed_date,'') as [LicensedDate], ISNULL(NAS.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(NAS.printing_status,'') as [printingStatus], ISNULL(NAS.category,'') as [category], ISNULL(NAS.employment_date,'') as [startYear], ISNULL(NAS.current_employer,'') as [CurrentEmployer], ISNULL(NAS.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, NAS.licensed_date, NAS.licensed_expiring_date)  AS [licensed_validation] FROM NASARAWA NAS UNION ALL SELECT ISNULL(OGU.registration_no,'') as [RegNo], ISNULL(OGU.firstname, '') AS[firstname], ISNULL(OGU.middlename, ' ') as [middlename], ISNULL(OGU.surname, '') as [surname], ISNULL(OGU.sex,'') as [Gender], ISNULL(OGU.state_id,'') as [StateLocation], ISNULL(OGU.application_date,'') as [RegistrationDate], ISNULL(OGU.education_level,'') as [qualification], ISNULL(OGU.registration_status,'') as [RegistrationStatus], ISNULL(OGU.licensed_status,'') as [licensedStatus], ISNULL(OGU.licensed_date,'') as [LicensedDate], ISNULL(OGU.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OGU.printing_status,'') as [printingStatus], ISNULL(OGU.category,'') as [category], ISNULL(OGU.employment_date,'') as [startYear], ISNULL(OGU.current_employer,'') as [CurrentEmployer], ISNULL(OGU.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OGU.licensed_date, OGU.licensed_expiring_date)  AS [licensed_validation] FROM OGUN OGU UNION ALL SELECT ISNULL(OND.registration_no,'') as [RegNo], ISNULL(OND.firstname, '') AS[firstname], ISNULL(OND.middlename, ' ') as [middlename], ISNULL(OND.surname, '') as [surname], ISNULL(OND.sex,'') as [Gender], ISNULL(OND.state_id,'') as [StateLocation], ISNULL(OND.application_date,'') as [RegistrationDate], ISNULL(OND.education_level,'') as [qualification], ISNULL(OND.registration_status,'') as [RegistrationStatus], ISNULL(OND.licensed_status,'') as [licensedStatus], ISNULL(OND.licensed_date,'') as [LicensedDate], ISNULL(OND.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OND.printing_status,'') as [printingStatus], ISNULL(OND.category,'') as [category], ISNULL(OND.employment_date,'') as [startYear], ISNULL(OND.current_employer,'') as [CurrentEmployer], ISNULL(OND.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OND.licensed_date, OND.licensed_expiring_date)  AS [licensed_validation] FROM ONDO OND UNION ALL SELECT ISNULL(OSIK.registration_no,'') as [RegNo], ISNULL(OSIK.firstname, '') AS[firstname], ISNULL(OSIK.middlename, ' ') as [middlename], ISNULL(OSIK.surname, '') as [surname], ISNULL(OSIK.sex,'') as [Gender], ISNULL(OSIK.state_id,'') as [StateLocation], ISNULL(OSIK.application_date,'') as [RegistrationState], ISNULL(OSIK.education_level,'') as [qualification], ISNULL(OSIK.registration_status,'') as [RegistrationStatus], ISNULL(OSIK.licensed_status,'') as [licensedStatus], ISNULL(OSIK.licensed_date,'') as [LicensedDate], ISNULL(OSIK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OSIK.printing_status,'') as [printingStatus], ISNULL(OSIK.category,'') as [category], ISNULL(OSIK.employment_date,'') as [startYear], ISNULL(OSIK.current_employer,'') as [CurrentEmployer], ISNULL(OSIK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OSIK.licensed_date, OSIK.licensed_expiring_date)  AS [licensed_validation] FROM OSUN OSIK UNION ALL SELECT ISNULL(OY.registration_no,'') as [RegNo], ISNULL(OY.firstname, '') AS[firstname], ISNULL(OY.middlename, ' ') as [middlename], ISNULL(OY.surname, '') as [surname], ISNULL(OY.sex,'') as [Gender], ISNULL(OY.state_id,'') as [StateLocation], ISNULL(OY.application_date,'') as [RegistrationState], ISNULL(OY.education_level,'') as [qualification], ISNULL(OY.registration_status,'') as [RegistrationStatus], ISNULL(OY.licensed_status,'') as [licensedStatus], ISNULL(OY.licensed_date,'') as [LicensedDate], ISNULL(OY.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(OY.printing_status,'') as [printingStatus], ISNULL(OY.category,'') as [category], ISNULL(OY.employment_date,'') as [startYear], ISNULL(OY.current_employer,'') as [CurrentEmployer], ISNULL(OY.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, OY.licensed_date, OY.licensed_expiring_date)  AS [licensed_validation] FROM OYO OY UNION ALL SELECT ISNULL(PLA.registration_no,'') as [RegNo], ISNULL(PLA.firstname, '') AS[firstname], ISNULL(PLA.middlename, ' ') as [middlename], ISNULL(PLA.surname, '') as [surname], ISNULL(PLA.sex,'') as [Gender], ISNULL(PLA.state_id,'') as [StateLocation], ISNULL(PLA.application_date,'') as [RegistrationState], ISNULL(PLA.education_level,'') as [qualification], ISNULL(PLA.registration_status,'') as [RegistrationStatus], ISNULL(PLA.licensed_status,'') as [licensedStatus], ISNULL(PLA.licensed_date,'') as [LicensedDate], ISNULL(PLA.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(PLA.printing_status,'') as [printingStatus], ISNULL(PLA.category,'') as [category], ISNULL(PLA.employment_date,'') as [startYear], ISNULL(PLA.current_employer,'') as [CurrentEmployer], ISNULL(PLA.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, PLA.licensed_date, PLA.licensed_expiring_date)  AS [licensed_validation] FROM PLATEAU PLA UNION ALL SELECT ISNULL(RIV.registration_no,'') as [RegNo], ISNULL(RIV.firstname, '') AS[firstname], ISNULL(RIV.middlename, ' ') as [middlename], ISNULL(RIV.surname, '') as [surname], ISNULL(RIV.sex,'') as [Gender], ISNULL(RIV.state_id,'') as [StateLocation], ISNULL(RIV.application_date,'') as [RegistrationState], ISNULL(RIV.education_level,'') as [qualification], ISNULL(RIV.registration_status,'') as [RegistrationStatus], ISNULL(RIV.licensed_status,'') as [licensedStatus], ISNULL(RIV.licensed_date,'') as [LicensedDate], ISNULL(RIV.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(RIV.printing_status,'') as [printingStatus], ISNULL(RIV.category,'') as [category], ISNULL(RIV.employment_date,'') as [startYear], ISNULL(RIV.current_employer,'') as [CurrentEmployer], ISNULL(RIV.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, RIV.licensed_date, RIV.licensed_expiring_date)  AS [licensed_validation] FROM RIVERS RIV UNION ALL SELECT ISNULL(SOK.registration_no,'') as [RegNo], ISNULL(SOK.firstname, '') AS[firstname], ISNULL(SOK.middlename, ' ') as [middlename], ISNULL(SOK.surname, '') as [surname], ISNULL(SOK.sex,'') as [Gender], ISNULL(SOK.state_id,'') as [StateLocation], ISNULL(SOK.application_date,'') as [RegistrationState], ISNULL(SOK.education_level,'') as [qualification], ISNULL(SOK.registration_status,'') as [RegistrationStatus], ISNULL(SOK.licensed_status,'') as [licensedStatus], ISNULL(SOK.licensed_date,'') as [LicensedDate], ISNULL(SOK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(SOK.printing_status,'') as [printingStatus], ISNULL(SOK.category,'') as [category], ISNULL(SOK.employment_date,'') as [startYear], ISNULL(SOK.current_employer,'') as [CurrentEmployer], ISNULL(SOK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, SOK.licensed_date, SOK.licensed_expiring_date)  AS [licensed_validation] FROM SOKOTO SOK UNION ALL SELECT ISNULL(TAR.registration_no,'') as [RegNo], ISNULL(TAR.firstname, '') AS[firstname], ISNULL(TAR.middlename, ' ') as [middlename], ISNULL(TAR.surname, '') as [surname], ISNULL(TAR.sex,'') as [Gender], ISNULL(TAR.state_id,'') as [StateLocation], ISNULL(TAR.application_date,'') as [RegistrationState], ISNULL(TAR.education_level,'') as [qualification], ISNULL(TAR.registration_status,'') as [RegistrationStatus], ISNULL(TAR.licensed_status,'') as [licensedStatus], ISNULL(TAR.licensed_date,'') as [LicensedDate], ISNULL(TAR.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(TAR.printing_status,'') as [printingStatus], ISNULL(TAR.category,'') as [category], ISNULL(TAR.employment_date,'') as [startYear], ISNULL(TAR.current_employer,'') as [CurrentEmployer], ISNULL(TAR.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, TAR.licensed_date, TAR.licensed_expiring_date)  AS [licensed_validation] FROM TARABA TAR  UNION ALL SELECT ISNULL(YK.registration_no,'') as [RegNo], ISNULL(YK.firstname, '') AS[firstname], ISNULL(YK.middlename, ' ') as [middlename], ISNULL(YK.surname, '') as [surname], ISNULL(YK.sex,'') as [Gender], ISNULL(YK.state_id,'') as [StateLocation], ISNULL(YK.application_date,'') as [RegistrationState], ISNULL(YK.education_level,'') as [qualification], ISNULL(YK.registration_status,'') as [RegistrationStatus], ISNULL(YK.licensed_status,'') as [licensedStatus], ISNULL(YK.licensed_date,'') as [LicensedDate], ISNULL(YK.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(YK.printing_status,'') as [printingStatus], ISNULL(YK.category,'') as [category], ISNULL(YK.employment_date,'') as [startYear], ISNULL(YK.current_employer,'') as [CurrentEmployer], ISNULL(YK.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, YK.licensed_date, YK.licensed_expiring_date)  AS [licensed_validation] FROM YOBE YK  UNION ALL SELECT ISNULL(ZAM.registration_no,'') as [RegNo], ISNULL(ZAM.firstname, '') AS[firstname], ISNULL(ZAM.middlename, ' ') as [middlename], ISNULL(ZAM.surname, '') as [surname], ISNULL(ZAM.sex,'') as [Gender], ISNULL(ZAM.state_id,'') as [StateLocation], ISNULL(ZAM.application_date,'') as [RegistrationState], ISNULL(ZAM.education_level,'') as [qualification], ISNULL(ZAM.registration_status,'') as [RegistrationStatus], ISNULL(ZAM.licensed_status,'') as [licensedStatus], ISNULL(ZAM.licensed_date,'') as [LicensedDate], ISNULL(ZAM.licensed_Expiring_date,'') as [ExpiringDate], ISNULL(ZAM.printing_status,'') as [printingStatus], ISNULL(ZAM.category,'') as [category], ISNULL(ZAM.employment_date,'') as [startYear], ISNULL(ZAM.current_employer,'') as [CurrentEmployer], ISNULL(ZAM.area_of_discipline,'') as [AreaofSpecialisation], DATEDIFF(DAY, ZAM.licensed_date, ZAM.licensed_expiring_date)  AS [licensed_validation] FROM ZAMFARA ZAM ) AS tblAllState WHERE RegNo='" + sSearch + "'";


                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }

                sRegStatue = ds.Tables[0].Rows[0]["Registration_Status"].ToString();
                sRegNo = ds.Tables[0].Rows[0]["TRCN_Teacher_Registration_Number"].ToString();
                sRegName = ds.Tables[0].Rows[0]["Teacher_Names"].ToString();
                sCertificate = ds.Tables[0].Rows[0]["Printing_Status"].ToString();
                sLicensedStatus = ds.Tables[0].Rows[0]["Licensed_Status"].ToString();
                sValidLicensed = ds.Tables[0].Rows[0]["Valid_License"].ToString();
                sStateLocation = ds.Tables[0].Rows[0]["State_of_Location"].ToString();

                sCategory = ds.Tables[0].Rows[0]["Category"].ToString();
                sHighestQualification = ds.Tables[0].Rows[0]["Highest_Qualification"].ToString();
                sLicensedDate = ds.Tables[0].Rows[0]["Licensed_date"].ToString();
                sExpiringDate = ds.Tables[0].Rows[0]["Expiring_Date"].ToString();
                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getUserID(string sSearch)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT userID from tbl_trcn_user where registration_no='" + sSearch + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }

                sRegStatue = ds.Tables[0].Rows[0]["userID"].ToString();
                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getClientProfile(string username, string sPassword)
        {

            try
            {
                string sPasswordDB = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM user_management WHERE [username]=@username ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@username", username);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid User. Contact Administrator.";
                    return false;
                }
                sPasswordDB = ds.Tables[0].Rows[0]["password"].ToString();
                if (sPasswordDB.Trim() == string.Empty)
                {
                    ErrorMessage = "Password Not found in the database.";

                }
                else
                {

                    //sPasswordDB = Decrypt(sPasswordDB, true);
                    if (sPassword != sPasswordDB)
                    {
                        ErrorMessage = "Invalid password.";
                        return false;
                    }
                }

                sUsername = ds.Tables[0].Rows[0]["username"].ToString();
                recordManager = ds.Tables[0].Rows[0]["record_manager"].ToString();
                directorate = ds.Tables[0].Rows[0]["directorate"].ToString();
                administrtaor = ds.Tables[0].Rows[0]["administrator"].ToString();
                account = ds.Tables[0].Rows[0]["account"].ToString();
                accounthead = ds.Tables[0].Rows[0]["account_head"].ToString();
                Scertification = ds.Tables[0].Rows[0]["certification"].ToString();
                sPassword = ds.Tables[0].Rows[0]["password"].ToString();
                Licensed = ds.Tables[0].Rows[0]["licensed"].ToString();
                sState = ds.Tables[0].Rows[0]["state_id"].ToString();
                States = ds.Tables[0].Rows[0]["state"].ToString();
                stat = ds.Tables[0].Rows[0]["stat"].ToString();


                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }
        public bool getUserLogin(string username, string sPassword)
        {

            try
            {
                string sPasswordDB = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM tbl_teacher WHERE [userID]=@username ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@username", username);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid email. Contact Administrator.";
                    return false;
                }
                sPasswordDB = ds.Tables[0].Rows[0]["user_password"].ToString();
                if (sPasswordDB.Trim() == string.Empty)
                {
                    ErrorMessage = "Password Not found in the database.";

                }
                else
                {

                    //sPasswordDB = Decrypt(sPasswordDB, true);
                    if (sPassword != sPasswordDB)
                    {
                        ErrorMessage = "Invalid password.";
                        return false;
                    }
                }
                sUsername = ds.Tables[0].Rows[0]["registration_no"].ToString();


                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }
        public bool AllTeachers(string sModule)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT total from qry_teacher_count where module='" + sModule + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool UpdateQualificationAndSchool(string sRegistration_no, string OldRegistrationNo)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "update tbl_qualification set registration_no='" + sRegistration_no + "' where registration_no='" + OldRegistrationNo + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                ExecuteNonQuery(objCmd);
                ds = new DataSet();
                sSQL = "update tbl_School set registration_no='" + sRegistration_no + "' where registration_no='" + OldRegistrationNo + "'";
                objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                ExecuteNonQuery(objCmd);
                return true;



            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool addTypeNumber(string tbl, string sRegistrationNo, string sPqeNumber)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "insert into " + tbl + "(registration_no, pqe_number)values('" + sRegistrationNo + "', '" + sPqeNumber + "')";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                ExecuteNonQuery(objCmd);

                return true;



            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool setClientPassword(string email, string sNewPassword)
        {
            try
            {
                string sSQL = "UPDATE user_management SET [password]=@password " +
                    " WHERE [username]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                //sNewPassword = Encrypt(sNewPassword, true);
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.Parameters.AddWithValue("@password", sNewPassword);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Password set failed.  Contact Administrator";
                    return false;
                }
                ErrorMessage = "Password has been successfully changed";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool setTeacherPassword(string userID, string sNewPassword)
        {
            try
            {
                string sSQL = "UPDATE tbl_teacher SET [user_password]=@user_password " +
                    " WHERE [userID]=@userID ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                //sNewPassword = Encrypt(sNewPassword, true);
                objCmd.Parameters.AddWithValue("@userID", userID);
                objCmd.Parameters.AddWithValue("@user_password", sNewPassword);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Password set failed.  Contact Administrator";
                    return false;
                }
                ErrorMessage = "Password has been successfully changed";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        public bool checkPasswordExist(string email, string sPassword)
        {
            try
            {
                string sPasswordDB = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM user_management WHERE [username]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid ID. Contact Administrator.";
                    return false;
                }
                sPasswordDB = ds.Tables[0].Rows[0]["password"].ToString();
                if (sPasswordDB.Trim() == string.Empty)
                {
                    ErrorMessage = "Password Not found in the database.";
                    return false;
                }
                else
                {

                    if (sPassword != sPasswordDB)
                    {
                        ErrorMessage = "Invalid password.";
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.ToString();
                return false;
            }

        }

        public bool checkUserIDExist(string userID, string sPassword)
        {
            try
            {
                string sPasswordDB = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM tbl_teacher WHERE [userID]=@userID ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@userID", userID);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid ID. Contact Administrator.";
                    return false;
                }
                sPasswordDB = ds.Tables[0].Rows[0]["user_password"].ToString();
                if (sPasswordDB.Trim() == string.Empty)
                {
                    ErrorMessage = "Password Not found in the database.";
                    return false;
                }
                else
                {

                    if (sPassword != sPasswordDB)
                    {
                        ErrorMessage = "Invalid password.";
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.ToString();
                return false;
            }

        }
        public bool checkPass(string pass, string ConfirmPass)
        {
            if (pass != ConfirmPass)
            {
                ErrorMessage = "Password does not match Confirm Password.";
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool getServerDetails()
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT * FROM tbl_mail_server ORDER BY rec_id ";
                objCmd.CommandText = sSQL;
                DataSet ds = ExecuteDataSet(objCmd);
                sMailServer = ds.Tables[0].Rows[0]["smtp_server"].ToString();
                sPort = int.Parse(ds.Tables[0].Rows[0]["smtp_port"].ToString());
                if (ds.Tables[0].Rows[0]["ssl_support"].ToString() != "0")
                {
                    bSSL = true;
                }

                stmpUsername = ds.Tables[0].Rows[0]["smtp_username"].ToString();
                stmpPassword = ds.Tables[0].Rows[0]["smtp_password"].ToString();
                stmpAddressFrom = ds.Tables[0].Rows[0]["default_address"].ToString();
                return true;

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return false;
            }
        }
        public bool getUrl()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT * FROM tbl_sys_config where rec_id=2";
                objCmd.CommandText = sSQL;
                DataSet ds = ExecuteDataSet(objCmd);
                sUrl = ds.Tables[0].Rows[0]["document_path"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        public bool getWebUrl()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT * FROM tbl_sys_config where rec_id=1";
                objCmd.CommandText = sSQL;
                DataSet ds = ExecuteDataSet(objCmd);
                sUrl = ds.Tables[0].Rows[0]["document_path"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        public bool sendPassword(string sAddressTo, string fullname, string sCode, string sUsername)
        {
            try
            {
                if (getUrl() == true)
                {
                    if (getServerDetails() == true)
                    {
                        string lk = "<a style='background-color:blue; color:white; border:3px solid white; width:100px; height:50px' href = '" + (sUrl + sUsername + "&password=" + sCode) + "'>Click here to Automatically login</a>";
                        MailAddress addressFrom = new MailAddress("info@govtportal.net", "Teachers Registration Council of Nigeria");
                        MailAddress addressTo = new MailAddress(sAddressTo);
                        MailMessage message = new MailMessage("info@govtportal.net", sAddressTo);
                        message.Subject = "TRCN";
                        string sBody = @"<html><body><p><h3>Teachers Registration Council of Nigeria</h3></p><hr/><br/><p>Dear " + " " + fullname + " </p><p>" + lk + "</p><p><h4>Your New Password</h4></p><p> " + sCode + "</p><br/><p style='color:red;'>This email contains confidential information from TRCN, which is intended only for the person or entity whose address is listed above.</p><p style='color:red;'>Any use of this information contained herein in any way (including, but not limited to, total or partial disclosure, reproduction, or dissemination) by persons other than the intended recipients is prohibited.</p><p>If this email is not for you, please notify the sender by phone or email immediately and delete it.<p><hr/><br/><p>Thank You!</p><p><h4>TRCN</h4></p><hr/></body></html>";
                        message.Body = sBody;
                        message.IsBodyHtml = true;
                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Host = "mail.govtportal.net";
                        SmtpServer.Port = sPort;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("info@govtportal.net", "HEN2019ry");
                        SmtpServer.EnableSsl = bSSL;
                        SmtpServer.Send(message);
                        ErrorMessage = "An Activation process has been sent to" + " " + sAddressTo;
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "An error found while trying to fetch Email Details.";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "An Error occurred. RecID Not found.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public void updatePassword(string email, string user_password)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "";
                sSQL = "UPDATE user_management SET [password]=@password WHERE [email]=@email ";
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.Parameters.AddWithValue("@password", user_password);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Update Failed";

                }
                ErrorMessage = "activation  updated.";

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();

            }
        }
        public bool updateBackUps(string backupurl, string rec_id)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "";
                sSQL = "UPDATE backupRestoreDatabase SET backupUrl='" + backupurl + "', restore_date='" + DateTime.Now.ToString() + "', checkUrl='" + "1" + "' WHERE [rec_id]=@rec_id ";
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Update Failed";
                    return false;
                }
                ErrorMessage = "backup Restored successfully.";
                return true;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool forgetPassword(string email)
        {
            try
            {
                string sEmail = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM user_management WHERE [email]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage += "Email ID not found. Contact Administrator.";
                    return false;
                }
                Surname = ds.Tables[0].Rows[0]["surname"].ToString();
                Othernames = ds.Tables[0].Rows[0]["othernames"].ToString();
                sUsername = ds.Tables[0].Rows[0]["username"].ToString();
                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool forgetTeacherPassword(string email)
        {
            try
            {
                string sEmail = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM tbl_trcn_user WHERE [email]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage += "Email ID not found. Contact Administrator.";
                    return false;
                }
                Surname = ds.Tables[0].Rows[0]["userID"].ToString();
                Othernames = ds.Tables[0].Rows[0]["userpassword"].ToString();
                ;
                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }


        public bool changePassword(string sUsername, string sNewPassword)
        {
            try
            {
                string sSQL = "UPDATE user_management SET [password]=@userpassword " +
                    " WHERE [email]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                //sNewPassword = Encrypt(sNewPassword, true);
                objCmd.Parameters.AddWithValue("@userpassword", sNewPassword);
                objCmd.Parameters.AddWithValue("@email", sUsername);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage += "Password change failed.  Contact Administrator";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return false;
            }
        }

        public bool forgetUserPassword(string email)
        {
            try
            {
                string sEmail = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM user_management WHERE [email]=@email ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage += "Email ID not found. Contact Administrator.";
                    return false;
                }
                Surname = ds.Tables[0].Rows[0]["username"].ToString();
                Othernames = ds.Tables[0].Rows[0]["password"].ToString();
                ;
                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool countforAdministrator(string sTable)
        {
            try
            {
                string sEmail = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT count(*) as [number] FROM " + sTable + "";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage += "Not found.";
                    return false;
                }
                allCount = ds.Tables[0].Rows[0]["number"].ToString();

                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool countBackUpsa(string sTable, string sCheck)
        {
            try
            {
                string sEmail = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "SELECT count(*) as [number] FROM " + sTable + " where checkUrl='" + sCheck + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage += "Not found.";
                    return false;
                }
                allCount = ds.Tables[0].Rows[0]["number"].ToString();

                return true;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        public string getguid()
        {
            Guid guid = Guid.NewGuid();
            string g = guid.ToString();
            return g;
        }


        public bool updateUserManagement(string sUsername, string sToken)
        {
            try
            {
                string sSQL = "UPDATE user_management set guid_no='" + sToken + "' where username='" + sUsername + "'";

                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }
        public bool deleteTrcnRecord(string rec_id, string tbl_name)
        {
            try
            {
                string sSQL = "DELETE FROM  " + tbl_name + "  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to delete transaction";
                    return false;
                }
                ErrorMessage = "Record successfully deleted.";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool deleteByRegistrationId(string registration_no, string tbl_name)
        {
            try
            {
                string sSQL = "DELETE FROM  " + tbl_name + "  WHERE registration_no=@registration_no";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@registration_no", registration_no);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to delete transaction";
                    return false;
                }
                ErrorMessage = "Record successfully deleted.";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool UpdateCheckedRecords(string sRegistrationStatus, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='1'  WHERE rec_id=@registration_status";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@registration_status", sRegistrationStatus);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool UnverifiedCheckRecord(string sRegistrationStatus, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='0', licensed_status=''  WHERE rec_id=@registration_status";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@registration_status", sRegistrationStatus);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool updateTeacherRecordSignatureandPicture(string recID, string tbl_name, string teacherSignature, string teacherPic, string sPicNo)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET teacher_signature='" + teacherSignature + "', pic_no='" + sPicNo + "', pic_filename='" + teacherPic + "'  WHERE rec_id='" + recID + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool updateIntTeacher(int recID, string tbl_name, string teacherSignature, string teacherPic)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET pic_filename=@pic_filename, teacher_signature=@teacher_signature WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", recID);
                objCmd.Parameters.AddWithValue("@teacher_signature", teacherSignature);
                objCmd.Parameters.AddWithValue("@pic_filename", teacherPic);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool intUpdateCheckedRecords(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='1'  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", iRecID);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool intUnverifiedRecords(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='0' WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", iRecID);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }


        public bool docDelete(string stbl, int iRecID)
        {
            try
            {
                string sSQL = "delete from " + stbl + " where rec_id='" + iRecID + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to delete transaction";
                    return false;
                }
                ErrorMessage = "Record delete successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool docDeleteAll(string stbl)
        {
            try
            {
                string sSQL = "delete from " + stbl + "";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Deleted successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool verifyAllRecords(string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='1', licensed_status='NOT', pic_no='0' where registration_status='0'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool UnverifyAllRecords(string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='0' where registration_status='1'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool verifyAccountLog(string tbl_name)
        {
            try
            {
                string sDate = DateTime.UtcNow.ToString();
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='1', verified_teacher_date='" + sDate + "' where registration_status='0'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool updatePrintedCheckedRecords(string sRegistrationStatus, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='1'  WHERE printing_status=@printing_status";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@printing_status", sRegistrationStatus);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }


        public bool updatePrintedRecord(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='1'  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", iRecID);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool updatePrintingRecord(string rec_id, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='1'  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }


        public bool getLicensed(string rec_id, string tbl_name, string sLicensedDate, string sExpirationDate)
        {
            try
            {

                string sSQL = "UPDATE " + tbl_name + " SET licensed_status='2', licensed_date='" + sLicensedDate + "', licensed_expiring_date='" + sExpirationDate + "'  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }

                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }



        public bool updatePrintingRecordSingleRow(int iRecID, string tbl_name)
        {
            try
            {
                string sDate = DateTime.UtcNow.ToString();
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='1', printed_certificate_date='" + sDate + "'   WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", iRecID);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool unPrintRecords(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='0'  WHERE rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = sSQL;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", iRecID);
                if (ExecuteNonQuery(objCmd) <= 0)
                {
                    ErrorMessage = "Unable to Update transaction";
                    return false;
                }
                ErrorMessage = "Record Updated successfully .";
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getUserRecID(string rec_id)
        {
            try
            {
                string sSQL = "select * from user_management where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sUsername = ds.Tables[0].Rows[0]["username"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getAdministrator(string rec_id)
        {
            try
            {
                string sSQL = "select * from administrator where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sUsername = ds.Tables[0].Rows[0]["administrator_name"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool getTeacherID(string stbl, string rec_id)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sTeacherName = ds.Tables[0].Rows[0]["surname"].ToString() + "  " + ds.Tables[0].Rows[0]["firstname"].ToString() + "    " + ds.Tables[0].Rows[0]["middlename"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getTeacherName(string stbl, string rec_id)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sTeacherName = ds.Tables[0].Rows[0]["names"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        public bool getTeacherSchool(string stbl, string rec_id)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sTeacherName = ds.Tables[0].Rows[0]["school"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getTeacherQua(string stbl, string rec_id)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where rec_id=@rec_id";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sTeacherName = ds.Tables[0].Rows[0]["qualification"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool getTeacherRecID(string stbl, string sRegNo)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where registration_no=@registration_no";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@registration_no", sRegNo);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "ID does not exist.";
                    return false;
                }
                sTeacherName = ds.Tables[0].Rows[0]["rec_id"].ToString();
                sLicensedNumber = ds.Tables[0].Rows[0]["form_no"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }
        public bool checkCurrentRecID(string sRegistrationNo, string stbl)
        {
            try
            {
                string sSQL = "select * from " + stbl + " where registration_no=@registration_no";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@registration_no", sRegistrationNo);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        private void OpenConnection(SqlConnection con)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void CloseConnection(SqlConnection con)
        {
            con.Close();
        }
        public string AutoIncrementID(string sTbl)
        {
            SqlConnection con = new SqlConnection();
            OpenConnection(con);
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(rec_id),0) + 1 from " + sTbl + "", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string id = null;
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            CloseConnection(con);
            return id;
        }
        //The function ZeroAppend is used to append “0” after the prefix to the code.  
        public string ZeroAppend(string data, int idLimit)
        {
            return data.Substring(data.Length - idLimit);
        }
        public bool getTeacherID(string stbl)
        {
            try
            {
                string sSQL = "select max(ID + 1) as TeacherCode from " + stbl + " group by ID order by ID desc";
                SqlCommand objCmd = new SqlCommand();
                DataSet ds = new DataSet();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    sLastRecID = ds.Tables[0].Rows[0]["TeacherCode"].ToString();

                    return true;
                }
                else
                {

                    sLastRecID = " 00001";
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet getTeacherIDRange(string tbl, string one, string two)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT * FROM " + tbl + " WHERE registration_no LIKE '% " + one + "%' AND registration_no like  '%" + two + "%'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet getTeacherIDRangeVerifiedandUnverified(string tbl, string sRegistrationStatus, string one, string two)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_no between '" + one + " ' AND '" + two + "' AND st.registration_statuS='" + sRegistrationStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataTable getTemplateForAllRegistration(string tbl)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_origin,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no", conn))

            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }
        public DataTable getTemplateForStateAllRegistration(string tbl)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_origin,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no", conn))

            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public DataTable generateTemplateForRegistration(string tbl, string sRegistrationStatus)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_origin,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no WHERE st.registration_status='" + sRegistrationStatus + "'", conn))

            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public DataTable getTemplateForNonVerifiedTeacher(string tbl, string stateID, string sRegistrationStatus)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT st.rec_id as [ID], st.registration_no as [Registration Number], st.form_no as [Form No], st.surname as [Surname], st.firstname as [First Name], st.middlename as [Middle Name], st.marital_status as [Marital Status], st.sex as [Gender], st.dob as [DoB], st.state_id as [State], st.phone_no as [Mobile Number], address as [Address], st.lga_id as [LGA], st.state_of_origin as [Birth State], st.nationality as [Country], st.category as [Category], st.current_employer as [Current Employer], st.employment_date as [Employment Date], st.education_level as [Education Level], st.institution_attended as [Institution], st.amount_paid as [Amount], st.bank_teller as [Teller], st.bank_name as [Bank], st.date_paid as [Date Paid], st.application_date as [Application Date], st.years_of_Experience as [Yrs_Of_Exp], st.area_of_discipline as [Area of Discipline], st.application_date as [Registration Date], st.registration_status as [Status], st.printing_status as [Printing Status], st.email as [Email Address], st.teacher_signature as [Teacher Signature], st.licensed_date as [Licensed Date], st.licensed_expiring_date as [Licensed Expiration Date], st.licensed_status as [Licensed Status], ad.administrator_name as [Administrator Name], ad.administrator_signature as [Administrator Signature] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.state_id='" + stateID + "' AND st.registration_status='" + sRegistrationStatus + "' ", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        //export user management to Excel
        public DataTable getGenerealTemplate(string sTbl)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select * from " + sTbl + "", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }
        public DataTable getResultTemp(string sTbl, string sStateID, string sExamType)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select * from " + sTbl + " where state_id='" + sStateID + "' AND exam_type='" + sExamType + "'", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }


        public DataTable getTemplateForNonPrintedRecord(string tbl, string stateID, string sRegistrationStatus, string sPrintedStatus)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT st.rec_id as [ID], st.registration_no as [Registration Number], st.form_no as [Form No], st.surname as [Surname], st.firstname as [First Name], st.middlename as [Middle Name], st.marital_status as [Marital Status], st.sex as [Gender], st.dob as [DoB], st.state_id as [State], st.phone_no as [Mobile Number], address as [Address], st.lga_id as [LGA], st.state_of_origin as [Birth State], st.nationality as [Country], st.category as [Category], st.current_employer as [Current Employer], st.employment_date as [Employment Date], st.education_level as [Education Level], st.institution_attended as [Institution], st.amount_paid as [Amount], st.bank_teller as [Teller], st.bank_name as [Bank], st.date_paid as [Date Paid], st.application_date as [Application Date], st.years_of_Experience as [Yrs_Of_Exp], st.area_of_discipline as [Area of Discipline], st.application_date as [Registration Date], st.registration_status as [Status], st.printing_status as [Printing Status], st.email as [Email Address], st.teacher_signature as [Teacher Signature], st.licensed_date as [Licensed Date], st.licensed_expiring_date as [Licensed Expiration Date], st.licensed_status as [Licensed Status], ad.administrator_name as [Administrator Name], ad.administrator_signature as [Administrator Signature] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.state_id='" + stateID + "' AND st.registration_status='" + sRegistrationStatus + "' AND printing_status='" + sPrintedStatus + "' ", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }




        public DataSet getStateOfficeTeacherNotIssuedpictureandSignature(string tbl, string sRegistrationStatus, string one, string two, string sPicNo)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT st.rec_id as [ID], st.registration_no as [Registration_no], st.form_no as [RRR Number], st.surname + '   ' + st.firstname + '    ' + st.middlename as [Teacher Names], st.marital_status as [Marital Status], st.sex as [Gender], st.dob as [Date of Birth], st.state_id as [State], st.phone_no as [Telephone Number], address as [Address], st.lga_id as [L.G.A.], st.state_id as [State of Origin], st.nationality as [Nationality], st.category as [Category], st.current_employer as [Current Employer], st.employment_date as [Employment Date], st.education_level as [Educational Level], st.institution_attended as [Institution Attended], st.amount_paid as [Amount Paid], st.bank_teller as [Bank Teller], st.bank_name as [Bank Name], st.date_paid as [Date paid], st.application_date as [Application Date], st.years_of_Experience as [Years of Experience], st.area_of_discipline as [Area of discipline], st.application_date as [Registration Date], st.registration_status as [Status], st.printing_status as [Printing Status], st.email as [Email Address], st.teacher_signature as [Teacher Signature], st.licensed_date as [Licensed Date], st.licensed_expiring_date as [Licensed Expiration Date], st.licensed_status as [Licensed Status], ad.administrator_name as [Administrator Name], ad.administrator_signature as [Administrator Signature] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_no between '" + one + " ' AND '" + two + "' AND st.registration_statuS='" + sRegistrationStatus + "' AND pic_no='" + sPicNo + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet getTeacherIDRangeVerified(string tbl, string one, string two)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();

                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_no between convert( nvarchar, '" + one + "') and   convert(nvarchar, '" + two + "') order by st.registration_no asc";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet getTeacherIDRangePrintedStatus(string tbl, string sPrintedStatus, string one, string two, string sRegistrationStatus)
        {

            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.form_no,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.bank_teller,'') as [Bank Teller], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date], ISNULL(st.registration_status,'') as [Status], ISNULL(st.printing_status,'') as [Printing Status], ISNULL(st.email,'') as [Email Address], ISNULL(st.teacher_signature,'') as [Teacher Signature], ISNULL(st.licensed_date,'') as [Licensed Date], ISNULL(st.licensed_expiring_date,'') as [Licensed Expiration Date], ISNULL(st.licensed_status,'') as [Licensed Status], ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number] FROM " + tbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_no between '" + one + "' AND '" + two + "' AND st.registration_status='" + sRegistrationStatus + "' AND st.printing_status='" + sPrintedStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }


        public DataSet getTeacherDetails(string stbl, string rec_id)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select surname + '  ' + firstname + '  ' + middlename as [Names], registration_no as [Registration_nos], state_id as [adminSignature] from " + stbl + " where [rec_id]=@rec_id";
                objCmd.CommandText = sSQL;
                objCmd.Parameters.AddWithValue("@rec_id", rec_id);
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet teacherDetailsByChecked(string stbl, string sRegistrationStatus, string sPrintingStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT * FROM " + stbl + " tch join(select * from administrator) as ad on ad.status = tch.registration_status where tch.registration_status=@registration_status AND tch.printing_status=@printingStatus";
                objCmd.CommandText = sSQL;
                objCmd.Parameters.AddWithValue("@registration_status", sRegistrationStatus);
                objCmd.Parameters.AddWithValue("@printingStatus", sPrintingStatus);
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet showCheckedPrintedDetails(string stbl, int sPrintingStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT * FROM " + stbl + " tch join(select * from administrator) as ad on ad.status = tch.registration_status where  tch.printing_status=@printingStatus";
                objCmd.CommandText = sSQL;

                objCmd.Parameters.AddWithValue("@printingStatus", sPrintingStatus);
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }








    }

