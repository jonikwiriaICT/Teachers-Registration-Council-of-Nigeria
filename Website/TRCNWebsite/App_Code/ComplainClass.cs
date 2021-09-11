using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;


    public partial class SysAdminModel : _Database
    {

        public DataTable GetTemplateComplainForm(string sNo)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select rec_id as [ID], surname as [Surname], othernames as [OtherNames], registration_no as [Registration Number], form_no as [Form Number], dob as [Date of Birth], sex as [Gender], state_of_origin as [State of Origin], lga_id as [L.G.A.], nationality as [Nationality], office_address as [Office Address], current_employer as [Current Employer], institution_name as [Institution Name], qualification as [Qualification], qualification_date_from as [Qualification Date From], qualification_date_to as [Qualification Date To], area_of_specialization as [Area of Specialisation], phone_no as [Phone Number], nature_of_complain as [Nature of Complain], passport_photo as [Passport Photo], original_evidence_payment as [Original Evidence Payment], other_credentials as [Other Credentials], official_complain_letter as [Official Complain Letter], signature as [Signature] from tbl_complainform where admin_attend='" + sNo + "'", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }
        public DataSet ShowComplainFormGrid(string sNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], surname as [Surname], othernames as [OtherNames], registration_no as [Registration Number], form_no as [Form Number], dob as [Date of Birth], sex as [Gender], state_of_origin as [State of Origin], lga_id as [L.G.A.], nationality as [Nationality], office_address as [Office Address], current_employer as [Current Employer], institution_name as [Institution Name], qualification as [Qualification], qualification_date_from as [Qualification Date From], qualification_date_to as [Qualification Date To], area_of_specialization as [Area of Specialisation], phone_no as [Phone Number], nature_of_complain as [Nature of Complain], passport_photo as [Passport Photo], original_evidence_payment as [Original Evidence Payment], other_credentials as [Other Credentials], official_complain_letter as [Official Complain Letter], signature as [Signature] from tbl_complainform WHERE admin_attend='" + sNo + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet showComplainFormGridByTeacherID(string sNo, string sRegistrationNumber)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], surname as [Surname], othernames as [OtherNames], registration_no as [Registration Number], form_no as [Form Number], dob as [Date of Birth], sex as [Gender], state_of_origin as [State of Origin], lga_id as [L.G.A.], nationality as [Nationality], office_address as [Office Address], current_employer as [Current Employer], institution_name as [Institution Name], qualification as [Qualification], qualification_date_from as [Qualification Date From], qualification_date_to as [Qualification Date To], area_of_specialization as [Area of Specialisation], phone_no as [Phone Number], nature_of_complain as [Nature of Complain], passport_photo as [Passport Photo], original_evidence_payment as [Original Evidence Payment], other_credentials as [Other Credentials], official_complain_letter as [Official Complain Letter], signature as [Signature] from tbl_complainform WHERE admin_attend='" + sNo + "' AND registration_no='" + sRegistrationNumber + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet ShowRangeComplainForm(string sRange1, string sRange2)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], surname as [Surname], othernames as [OtherNames], registration_no as [Registration Number], form_no as [Form Number], dob as [Date of Birth], sex as [Gender], state_of_origin as [State of Origin], lga_id as [L.G.A.], nationality as [Nationality], office_address as [Office Address], current_employer as [Current Employer], institution_name as [Institution Name], qualification as [Qualification], qualification_date_from as [Qualification Date From], qualification_date_to as [Qualification Date To], area_of_specialization as [Area of Specialisation], phone_no as [Phone Number], nature_of_complain as [Nature of Complain], passport_photo as [Passport Photo], original_evidence_payment as [Original Evidence Payment], other_credentials as [Other Credentials], official_complain_letter as [Official Complain Letter], signature as [Signature] from tbl_complainform where registration_no between '" + sRange1 + "' AND '" + sRange2 + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet SearchComplainFormIntelligence(string sNo, string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select rec_id as [ID], surname as [Surname], othernames as [OtherNames], registration_no as [Registration Number], form_no as [Form Number], dob as [Date of Birth], sex as [Gender], state_of_origin as [State of Origin], lga_id as [L.G.A.], nationality as [Nationality], office_address as [Office Address], current_employer as [Current Employer], institution_name as [Institution Name], qualification as [Qualification], qualification_date_from as [Qualification Date From], qualification_date_to as [Qualification Date To], area_of_specialization as [Area of Specialisation], phone_no as [Phone Number], nature_of_complain as [Nature of Complain], passport_photo as [Passport Photo], original_evidence_payment as [Original Evidence Payment], other_credentials as [Other Credentials], official_complain_letter as [Official Complain Letter], signature as [Signature] from tbl_complainform where  admin_attend='" + sNo + "' and  (surname='" + Search + "' or othernames='" + Search + "' or registration_no='" + Search + "' or form_no='" + Search + "' or dob='" + Search + "' or sex='" + Search + "' or state_of_origin='" + Search + "' or lga_id='" + Search + "' or nationality='" + Search + "' or office_address='" + Search + "' or current_employer='" + Search + "' or institution_name='" + Search + "' or qualification='" + Search + "' or qualification_date_from='" + Search + "' or qualification_date_to='" + Search + "' or area_of_specialization='" + Search + "' or phone_no='" + Search + "' or nature_of_complain='" + Search + "' or date_of_registration='" + Search + "' or nin_no='" + Search + "' )";
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

