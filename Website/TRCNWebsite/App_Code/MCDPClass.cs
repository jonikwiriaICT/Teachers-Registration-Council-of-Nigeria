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
        public string QryAllView(string sModule)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT total from qry_mcdp where module='" + sModule + "'";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return ErrorMessage;
                }
                teachCount = ds.Tables[0].Rows[0]["total"].ToString();
                return teachCount;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return ErrorMessage;
            }
        }
        public DataTable GetTemplateMCPDForm()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("select md.rec_id as [ID], md.participant_name as [Participant Name], md.registration_no as [Registration Number], md.license_number as [Licensed Number], md.school_address as [School Address], md.residential_address as [Residential Address], md.phone_no as [Phone Number], md.email as [Email], md.dob as [Date of Birth], md.qualification as [Qualification], md.subject_area as [Subject Area], md.years_of_teaching_experience as [Years of Teaching Experience], md.lga as [L.G.A.], md.state_of_origin as [State of Origin], md.gender as [Gender], md.area_of_specialisation as [Area of Specialisation], md.training_Center as [Training Center], md.service_provider as [Service Provider], md.theme_of_programme as [Theme of Programme], md.have_you_attended_any_mcpd_training as [Have you attended any MCPD Training ?], md.mcpd_training_type as [MCPD Training Type], md.mcpd_title as [MCPD Title], md.mcpd_organisers as [MCPD Organisers], md.mcpd_year_of_training as [MCPD Year of Training], md.duration_of_mcpd as [Duration of MCPD], md.are_you_licensed_teacher as [Are you licensed Teacher ?], se.provider_name as [Provider Name], se.training_type as [Training Type], se.training_title as [Training Title], se.no_of_days as [Number of Days of Training], se.no_of_trained_teachers as [Number of Trained Teachers], se.participant_list as [Participant List] from tbl_MCDP md join tbl_service_provider se on se.registration_no = md.registration_no", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public DataSet ShowMCDPGrid()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select md.rec_id as [ID], md.participant_name as [Participant Name], md.registration_no as [Registration Number], md.license_number as [Licensed Number], md.school_address as [School Address], md.residential_address as [Residential Address], md.phone_no as [Phone Number], md.email as [Email], md.dob as [Date of Birth], md.qualification as [Qualification], md.subject_area as [Subject Area], md.years_of_teaching_experience as [Years of Teaching Experience], md.lga as [L.G.A.], md.state_of_origin as [State of Origin], md.gender as [Gender], md.area_of_specialisation as [Area of Specialisation], md.training_Center as [Training Center], md.service_provider as [Service Provider], md.theme_of_programme as [Theme of Programme], md.have_you_attended_any_mcpd_training as [Have you attended any MCPD Training ?], md.mcpd_training_type as [MCPD Training Type], md.mcpd_title as [MCPD Title], md.mcpd_organisers as [MCPD Organisers],md.mcpd_year_of_training as [MCPD Year of Training], md.duration_of_mcpd as [Duration of MCPD], md.are_you_licensed_teacher as [Are you licensed Teacher ?],se.provider_name as [Provider Name], se.training_type as [Training Type], se.training_title as [Training Title], se.no_of_days as [Number of Days of Training], se.no_of_trained_teachers as [Number of Trained Teachers], se.participant_list as [Participant List] from tbl_MCDP md join tbl_service_provider se on se.registration_no = md.registration_no";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet ShowMCDPGridByTeacherID(string sRegistrationNumber)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select md.rec_id as [ID], md.participant_name as [Participant Name], md.registration_no as [Registration Number], md.license_number as [Licensed Number], md.school_address as [School Address], md.residential_address as [Residential Address], md.phone_no as [Phone Number], md.email as [Email], md.dob as [Date of Birth], md.qualification as [Qualification], md.subject_area as [Subject Area], md.years_of_teaching_experience as [Years of Teaching Experience], md.lga as [L.G.A.], md.state_of_origin as [State of Origin], md.gender as [Gender], md.area_of_specialisation as [Area of Specialisation], md.training_Center as [Training Center], md.service_provider as [Service Provider], md.theme_of_programme as [Theme of Programme], md.have_you_attended_any_mcpd_training as [Have you attended any MCPD Training ?], md.mcpd_training_type as [MCPD Training Type], md.mcpd_title as [MCPD Title], md.mcpd_organisers as [MCPD Organisers],md.mcpd_year_of_training as [MCPD Year of Training], md.duration_of_mcpd as [Duration of MCPD], md.are_you_licensed_teacher as [Are you licensed Teacher ?],se.provider_name as [Provider Name], se.training_type as [Training Type], se.training_title as [Training Title], se.no_of_days as [Number of Days of Training], se.no_of_trained_teachers as [Number of Trained Teachers], se.participant_list as [Participant List] from tbl_MCDP md join tbl_service_provider se on se.registration_no = md.registration_no WHERE md.registration_no='" + sRegistrationNumber + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet ShowRangeOfMCDPForm(string sRange1, string sRange2)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select md.rec_id as [ID], md.participant_name as [Participant Name], md.registration_no as [Registration Number], md.license_number as [Licensed Number], md.school_address as [School Address], md.residential_address as [Residential Address], md.phone_no as [Phone Number], md.email as [Email], md.dob as [Date of Birth], md.qualification as [Qualification], md.subject_area as [Subject Area], md.years_of_teaching_experience as [Years of Teaching Experience], md.lga as [L.G.A.], md.state_of_origin as [State of Origin], md.gender as [Gender], md.area_of_specialisation as [Area of Specialisation], md.training_Center as [Training Center], md.service_provider as [Service Provider], md.theme_of_programme as [Theme of Programme], md.have_you_attended_any_mcpd_training as [Have you attended any MCPD Training ?], md.mcpd_training_type as [MCPD Training Type], md.mcpd_title as [MCPD Title], md.mcpd_organisers as [MCPD Organisers],md.mcpd_year_of_training as [MCPD Year of Training], md.duration_of_mcpd as [Duration of MCPD], md.are_you_licensed_teacher as [Are you licensed Teacher ?],se.provider_name as [Provider Name], se.training_type as [Training Type], se.training_title as [Training Title], se.no_of_days as [Number of Days of Training], se.no_of_trained_teachers as [Number of Trained Teachers], se.participant_list as [Participant List] from tbl_MCDP md join tbl_service_provider se on se.registration_no = md.registration_no where md.registration_no between '" + sRange1 + "' AND '" + sRange2 + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet SearchAllMCDPFORMIntelligence(string Search)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select md.rec_id as [ID], md.participant_name as [Participant Name], md.registration_no as [Registration Number], md.license_number as [Licensed Number], md.school_address as [School Address], md.residential_address as [Residential Address], md.phone_no as [Phone Number], md.email as [Email], md.dob as [Date of Birth], md.qualification as [Qualification], md.subject_area as [Subject Area], md.years_of_teaching_experience as [Years of Teaching Experience], md.lga as [L.G.A.], md.state_of_origin as [State of Origin], md.gender as [Gender], md.area_of_specialisation as [Area of Specialisation], md.training_Center as [Training Center], md.service_provider as [Service Provider], md.theme_of_programme as [Theme of Programme], md.have_you_attended_any_mcpd_training as [Have you attended any MCPD Training ?], md.mcpd_training_type as [MCPD Training Type], md.mcpd_title as [MCPD Title], md.mcpd_organisers as [MCPD Organisers],md. mcpd_year_of_training as [MCPD Year of Training], md.duration_of_mcpd as [Duration of MCPD], md.are_you_licensed_teacher as [Are you licensed Teacher?],se.provider_name as [Provider Name], se.training_type as [Training Type], se.training_title as [Training Title], se.no_of_days as [Number of Days of Training], se.no_of_trained_teachers as [Number of Trained Teachers], se.participant_list as [Participant List] from tbl_MCDP md join tbl_service_provider se on se.registration_no=md.registration_no where  md.participant_name='" + Search + "' or md.registration_no='" + Search + "' or md.license_number='" + Search + "' or md.school_address='" + Search + "' or md.residential_address='" + Search + "' or md.phone_no='" + Search + "' or md.email='" + Search + "' or md.email='" + Search + "' or md.dob='" + Search + "' or md.qualification='" + Search + "' or md.subject_area='" + Search + "' or md.years_of_teaching_experience='" + Search + "' or md.lga='" + Search + "' or md.state_of_origin='" + Search + "' or md.gender ='" + Search + "' or md.area_of_specialisation='" + Search + "' or md.training_center='" + Search + "' or md.service_provider='" + Search + "' or md.theme_of_programme='" + Search + "' or md.have_you_attended_any_mcpd_training='" + Search + "' or md.mcpd_training_type='" + Search + "' or md.mcpd_title='" + Search + "' or md.mcpd_organisers='" + Search + "' or md.mcpd_year_of_training='" + Search + "' or md.duration_of_mcpd='" + Search + "' or md.are_you_licensed_teacher='" + Search + "' or md.mcpd_declaration='" + Search + "' or md.head_of_teachers_name='" + Search + "' or md.head_of_teacher_signature='" + Search + "' or md.head_of_teacher_date='" + Search + "' or se.provider_name='" + Search + "' or se.training_type='" + Search + "' or se.training_title='" + Search + "' or se.no_of_days='" + Search + "' or se.no_of_trained_teachers='" + Search + "' or se.participant_list='" + Search + "' ";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public bool getMCDPFormRecID(string stbl, string rec_id)
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
                sTeacherName = ds.Tables[0].Rows[0]["participant_name"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }


    }

