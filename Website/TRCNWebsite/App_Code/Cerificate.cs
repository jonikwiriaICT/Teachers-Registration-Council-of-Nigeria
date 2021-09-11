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
        public DataTable getExcelTemplateForCertificate(string stbl, string sRegistrationStatus, string sPrintedStatus)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo],st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no  where st.registration_status='" + sRegistrationStatus + "' AND printing_status='" + sPrintedStatus + "' ", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }
        public DataSet showSearchCertificate(string stbl, string showRegistrationStatus, string sPrintingStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + showRegistrationStatus + "' AND st.printing_status='" + sPrintingStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet showCertificateTeacherID(string stbl, string showRegistrationStatus, string sPrintingStatus, string sRegNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + showRegistrationStatus + "' st.printing_status='" + sPrintingStatus + "' AND st.registration_no='" + sRegNo + "";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet showCertificateRange(string stbl, string sRegistrationStatus, string sRange1, string sRange2, string printingStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature] FROM " + stbl + "  st join (select * from administrator) as ad on ad.status=st.admin_no where (st.printing_status='" + printingStatus + "' AND st.registration_status='" + sRegistrationStatus + "') AND st.registration_no BETWEEN '" + sRange1 + "' AND '" + sRange2 + "'";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet SearchIntelligenceCertificate(string stbl, string Search, string sRegistrationStatus, string sPrintingStatus)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [GUIDNo], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where (st.printing_status='" + sPrintingStatus + "' AND st.registration_status='" + sRegistrationStatus + "') AND st.teacher_names='" + Search + "' or st.registration_no='" + Search + "' or st.title='" + Search + "' or st.form_no='" + Search + "' or st.surname='" + Search + "' or st.firstname='" + Search + "' or st.middlename='" + Search + "' or st.marital_status='" + Search + "' or st.sex='" + Search + "' or st.dob='" + Search + "' or st.pqe_number='" + Search + "' or  st.bank_teller='" + Search + "' or st.state_id='" + Search + "' or st.phone_no='" + Search + "' or st.address='" + Search + "' or st.lga_id='" + Search + "' or st.state_of_origin='" + Search + "' or st.lga_origin='" + Search + "' or st.year_obtained='" + Search + "' or st.any_qualification_in_education='" + Search + "' or st.nationality='" + Search + "' or st.category='" + Search + "' or st.current_employer='" + Search + "' or st.employment_date='" + Search + "' or st.education_level='" + Search + "' or st.institution_attended='" + Search + "' or st.amount_paid='" + Search + "' or st.bank_name='" + Search + "' or st. date_paid='" + Search + "' or st.school_one='" + Search + "' or st.application_date='" + Search + "' or st.years_of_Experience='" + Search + "' or st.area_of_discipline='" + Search + "' or st.registration_date='" + Search + "' or st.email='" + Search + "' or st.school_type='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public bool ReprintedCertificate(int iRecID, string tbl_name)
        {
            try
            {
                string sDate = DateTime.UtcNow.ToString();
                string sSQL = "UPDATE " + tbl_name + " SET printing_status='1', re_printed_certificate_date='" + sDate + "'   WHERE rec_id=@rec_id";
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


    }

