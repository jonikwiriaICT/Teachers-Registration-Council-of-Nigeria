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

        public DataTable getRegistrationStatus(string stbl, string sRegistrationStatus)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date],  ISNULL(st.email,'') as [Email Address],  ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.verification_date as [Verification Date], st.unverification_date as [Unverification Date] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + sRegistrationStatus + "'", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public bool intverifiedRecords(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " set registration_status='1', verification_date= GETDATE() WHERE rec_id=@rec_id";
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

        public bool intUNiverifiedRecords(int iRecID, string tbl_name)
        {
            try
            {
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='0', unverification_date='" + DateTime.UtcNow.ToString() + "' WHERE rec_id=@rec_id";
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

        public DataSet viewAccount(string stbl, string sRegistrationStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date],  ISNULL(st.email,'') as [Email Address],  ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.verification_date as [Verification Date], st.unverification_date as [Unverification Date] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + sRegistrationStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet accountTeacherID(string stbl, string sRegNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date],  ISNULL(st.email,'') as [Email Address],  ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.verification_date as [Verification Date], st.unverification_date as [Unverification Date] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where  st.registration_no='" + sRegNo + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet searchAllAccountIntelligence(string stbl, string Search, string sRegistrationStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL(st.teacher_names,'') as [Teacher Names], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address],  ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline], ISNULL(st.registration_date,'') as [Registration Date],  ISNULL(st.email,'') as [Email Address],  ISNULL(ad.administrator_name,'') as [Administrator Name], ISNULL(ad.administrator_signature,'') as [Administrator Signature], ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.verification_date as [Verification Date], st.unverification_date as [Unverification Date] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no  where(st.registration_status='" + sRegistrationStatus + "') AND st.teacher_names='" + Search + "' or st.registration_no='" + Search + "' or st.title='" + Search + "' or st.form_no='" + Search + "' or st.surname='" + Search + "' or st.firstname='" + Search + "' or st.middlename='" + Search + "' or st.marital_status='" + Search + "' or st.sex='" + Search + "' or st.dob='" + Search + "' or st.bank_teller='" + Search + "' or st.state_id='" + Search + "' or st.phone_no='" + Search + "' or st.address='" + Search + "' or st.lga_id='" + Search + "' or st.state_of_origin='" + Search + "' or st.lga_origin='" + Search + "' or st.year_obtained='" + Search + "' or st.any_qualification_in_education='" + Search + "' or st.nationality='" + Search + "' or st.category='" + Search + "' or st.current_employer='" + Search + "' or st.employment_date='" + Search + "' or st.education_level='" + Search + "' or st.institution_attended='" + Search + "' or st.amount_paid='" + Search + "' or st.bank_name='" + Search + "' or st. date_paid='" + Search + "' or st.school_one='" + Search + "' or st.application_date='" + Search + "' or st.years_of_Experience='" + Search + "' or st.pqe_number='" + Search + "' or st.area_of_discipline='" + Search + "' or st.registration_date='" + Search + "' or st.email='" + Search + "' or st.school_type='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public bool UnverifyAccountLog(string tbl_name)
        {
            try
            {
                string sDate = DateTime.UtcNow.ToString();
                string sSQL = "UPDATE " + tbl_name + " SET registration_status='0', unverification_date='" + sDate + "' where registration_status='1'";
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

    }

