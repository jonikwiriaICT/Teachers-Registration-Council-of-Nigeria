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


        public DataTable getLicensedexcelTemplate(string stbl, string sRegistrationStatus, string sPrintedStatus, string sLicensedStatus, string sPicNo)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + sRegistrationStatus + "' AND st.printing_status='" + sPrintedStatus + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "'", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public DataTable getLicensedDueTemplate(string stbl, string sRegistrationStatus, string sPrintedStatus, string sLicensedStatus, string sPicNo, int LicensedDueNo)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + sRegistrationStatus + "' AND st.printing_status='" + sPrintedStatus + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "' AND DATEDIFF(DAY,st.licensed_date, st.licensed_new_expiring) <=" + LicensedDueNo + "", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var teacher = new DataTable();
                adapter.Fill(teacher);
                return teacher;
            }
        }

        public DataSet showLicensedDueRecord(string stbl, string showRegistrationStatus, string sPrintingStatus, string sLicensedStatus, string sPicNo, int iLcensedNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + showRegistrationStatus + "' AND st.printing_status='" + sPrintingStatus + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "' AND DATEDIFF(DAY,st.licensed_date, st.licensed_new_expiring) <=" + iLcensedNo + "";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet showTeacherIDByLicensedDue(string stbl, string showRegistrationStatus, string sPrintingStatus, string sRegNo, string sLicensedStatus, string sPicNo, int iLicensedNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where st.registration_status='" + showRegistrationStatus + "' st.printing_status='" + sPrintingStatus + "' AND st.registration_no='" + sRegNo + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "' AND DATEDIFF(DAY,st.licensed_date, st.licensed_new_expiring) <=" + iLicensedNo + "";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet showLicensedDueRange(string stbl, string sRegistrationStatus, string sRange1, string sRange2, string printingStatus, string sLicensedStatus, string sPicNo, int iLicensedNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where (st.printing_status='" + printingStatus + "' AND st.registration_status='" + sRegistrationStatus + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "' AND DATEDIFF(DAY,st.licensed_date, st.licensed_new_expiring) <=" + iLicensedNo + "  ) AND st.registration_no BETWEEN '" + sRange1 + "' AND '" + sRange2 + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet searchallIntelligenceDue(string stbl, string Search, string sRegistrationStatus, string sPrintingStatus, string sLicensed, string sPicNo, int iLicensedNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "SELECT ISNULL (st.rec_id,'') as [ID], ISNULL(st.registration_no,'') as [Registration_no], ISNULL(st.licensed_bank_teller,'') as [RRR Number], ISNULL (st.surname,'')  as [Surname], ISNULL(st.firstname,'') as [First Name], ISNULL(st.middlename,'') as [Middle Name], ISNULL(st.marital_status,'') as [Marital Status], ISNULL(st.sex,'') as [Gender], ISNULL(st.dob,'') as [Date of Birth], ISNULL(st.state_id,'') as [State], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.phone_no,'') as [Telephone Number], ISNULL(address,'') as [Office Address], ISNULL(st.lga_id,'') as [L.G.A.], ISNULL(st.state_of_origin,'') as [State of Origin], ISNULL(st.nationality,'') as [Nationality], ISNULL(st.category,'') as [Category], ISNULL(st.current_employer,'') as [Current Employer], ISNULL(st.employment_date,'') as [Employment Date], ISNULL(st.education_level,'') as [Educational Level], ISNULL(st.institution_attended,'') as [Institution Attended], ISNULL(st.amount_paid,'') as [Amount Paid], ISNULL(st.form_no,'') as [Form Number], ISNULL(st.bank_name,'') as [Bank Name], ISNULL(st.date_paid,'') as [Date paid], ISNULL(st.application_date,'') as [Application Date], ISNULL(st.years_of_Experience,'') as [Years of Experience], ISNULL(st.area_of_discipline,'') as [Area of discipline],  ISNULL(st.email,'') as [Email Address],  ISNULL(st.pic_filename,'') as [Picture], ISNULL(st.pqe_number,'') as [PQE Number], ISNULL(st.licensed_paid,'') as [Licensed Paid], st.guid_no as [Licensed Number], st.printed_certificate_date as [Printed Certificate Date], st.re_printed_certificate_date as [RePrinted Certificate Date], ad.administrator_signature as [Administrator Signature], st.licensed_new_expiring as [Licensed Expiring Date], st.teacher_signature as [Teacher Signature], st.phone_no as [TelephoneNo] FROM " + stbl + " st join (select * from administrator) as ad on ad.status=st.admin_no where (st.printing_status='" + sPrintingStatus + "' AND st.registration_status='" + sRegistrationStatus + "' AND st.licensed_status='" + sLicensedStatus + "' AND st.pic_no='" + sPicNo + "' AND DATEDIFF(DAY,st.licensed_date, st.licensed_new_expiring) <=" + iLicensedNo + ") AND st.teacher_names='" + Search + "' or st.registration_no='" + Search + "' or st.title='" + Search + "' or st.form_no='" + Search + "' or st.surname='" + Search + "' or st.firstname='" + Search + "' or st.middlename='" + Search + "' or st.marital_status='" + Search + "' or st.sex='" + Search + "' or st.dob='" + Search + "' or st.pqe_number='" + Search + "' or  st.licensed_bank_teller='" + Search + "' or st.state_id='" + Search + "' or st.phone_no='" + Search + "' or st.address='" + Search + "' or st.lga_id='" + Search + "' or st.state_of_origin='" + Search + "' or st.lga_origin='" + Search + "' or st.year_obtained='" + Search + "' or st.any_qualification_in_education='" + Search + "' or st.nationality='" + Search + "' or st.category='" + Search + "' or st.current_employer='" + Search + "' or st.employment_date='" + Search + "' or st.education_level='" + Search + "' or st.institution_attended='" + Search + "' or st.amount_paid='" + Search + "' or st.bank_name='" + Search + "' or st. date_paid='" + Search + "' or st.school_one='" + Search + "' or st.application_date='" + Search + "' or st.years_of_Experience='" + Search + "' or st.area_of_discipline='" + Search + "' or st.registration_date='" + Search + "' or st.email='" + Search + "' or st.school_type='" + Search + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }


        public DataSet showSearchLicensed(string stbl, string sRegistrationStatus, string sPrintingStatus, string sLicensedStatus, string sPicNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select ROW_NUMBER() over (order by rec_id) as [S/N], rec_id as [RecID], ISNULL(registration_no,'') as [Registration No.], ISNULL(pqe_number,'') as [PQE Number], ISNULL(guid_no,'') as [Licensed No.], ISNULL(nin_no,'') as [NIN No.], ISNULL(form_no,'') as [Form No.], isnull(licensed_bank_teller,'') as [RRR Number], ISNULL(teacher_names,'') as [Teacher Names], ISNULL(category,'') as [Category], ISNULL(nationality,'') as [Nationality], ISNULL(state_id,'') as [State], ISNULL(lga_id,'') as [L.G.A.], ISNULL(state_of_origin,'') as [State Of Origin], ISNULL(lga_origin,'') as [L.G.A. Origin], ISNULL(dob,'') as [Date Of Birth], ISNULL(email,'') as [Email], ISNULL(phone_no,'') as [Telephone No.], ISNULL(sex,'') as [Gender], ISNULL(marital_status,'') as [Marital Status], ISNULL(area_of_discipline,'') as [Area Of Discipline], ISNULL(years_of_experience,'') as [Years Of Experience], ISNULL(institution_attended,'') as [Institution Attended], ISNULL(education_level,'') as [Education Level], ISNULL(current_employer,'') as [Current Employer], ISNULL(employment_date,'') as [Employment Date], ISNULL(school_type,'') as [School Type], ISNULL(address, '') as [Address] from " + stbl + " where registration_status='" + sRegistrationStatus + "' and printing_status='" + sPrintingStatus + "' and pic_no='" + sPicNo + "' AND licensed_status='" + sLicensedStatus + "' ";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet showLicensedTeacherID(string stbl, string sRegistraionStatus, string sPrintingStatus, string sRegNo, string sLicensedStatus, string sPicNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select ROW_NUMBER() over (order by rec_id) as [S/N], rec_id as [RecID], ISNULL(registration_no,'') as [Registration No.], ISNULL(pqe_number,'') as [PQE Number], ISNULL(guid_no,'') as [Licensed No.], ISNULL(nin_no,'') as [NIN No.], ISNULL(form_no,'') as [Form No.], isnull(licensed_bank_teller,'') as [RRR Number], ISNULL(teacher_names,'') as [Teacher Names], ISNULL(category,'') as [Category], ISNULL(nationality,'') as [Nationality], ISNULL(state_id,'') as [State], ISNULL(lga_id,'') as [L.G.A.], ISNULL(state_of_origin,'') as [State Of Origin], ISNULL(lga_origin,'') as [L.G.A. Origin], ISNULL(dob,'') as [Date Of Birth], ISNULL(email,'') as [Email], ISNULL(phone_no,'') as [Telephone No.], ISNULL(sex,'') as [Gender], ISNULL(marital_status,'') as [Marital Status], ISNULL(area_of_discipline,'') as [Area Of Discipline], ISNULL(years_of_experience,'') as [Years Of Experience], ISNULL(institution_attended,'') as [Institution Attended], ISNULL(education_level,'') as [Education Level], ISNULL(current_employer,'') as [Current Employer], ISNULL(employment_date,'') as [Employment Date], ISNULL(school_type,'') as [School Type], ISNULL(address, '') as [Address] from " + stbl + " where registration_status='" + sRegistraionStatus + "' and printing_status='" + sPrintingStatus + "' and pic_no='" + sPicNo + "' AND registration_no='" + sRegNo + "' AND licensed_status='" + sLicensedStatus + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet showLicensedRange(string stbl, string sRegistrationStatus, string sRange1, string sRange2, string sPrintingStatus, string sLicensedStatus, string sPicNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select ROW_NUMBER() over (order by rec_id) as [S/N], rec_id as [RecID], ISNULL(registration_no,'') as [Registration No.], ISNULL(pqe_number,'') as [PQE Number], ISNULL(guid_no,'') as [Licensed No.], ISNULL(nin_no,'') as [NIN No.], ISNULL(form_no,'') as [Form No.], isnull(licensed_bank_teller,'') as [RRR Number], ISNULL(teacher_names,'') as [Teacher Names], ISNULL(category,'') as [Category], ISNULL(nationality,'') as [Nationality], ISNULL(state_id,'') as [State], ISNULL(lga_id,'') as [L.G.A.], ISNULL(state_of_origin,'') as [State Of Origin], ISNULL(lga_origin,'') as [L.G.A. Origin], ISNULL(dob,'') as [Date Of Birth], ISNULL(email,'') as [Email], ISNULL(phone_no,'') as [Telephone No.], ISNULL(sex,'') as [Gender], ISNULL(marital_status,'') as [Marital Status], ISNULL(area_of_discipline,'') as [Area Of Discipline], ISNULL(years_of_experience,'') as [Years Of Experience], ISNULL(institution_attended,'') as [Institution Attended], ISNULL(education_level,'') as [Education Level], ISNULL(current_employer,'') as [Current Employer], ISNULL(employment_date,'') as [Employment Date], ISNULL(school_type,'') as [School Type], ISNULL(address, '') as [Address] from " + stbl + " where registration_status='" + sRegistrationStatus + "' and printing_status='" + sPrintingStatus + "' and pic_no='" + sPicNo + "' AND licensed_status='" + sLicensedStatus + "' AND registration_no between '" + sRange1 + "' AND '" + sRange2 + "' ";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet SearchIntelligenceLicensed(string stbl, string Search, string sRegistrationStatus, string sPrintingStatus, string sLicensed, string sPicNo)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select ROW_NUMBER() over(order by rec_id) as [S / N], rec_id as [RecID], ISNULL(registration_no, '') as [Registration No.], ISNULL(pqe_number, '') as [PQE Number], ISNULL(guid_no, '') as [Licensed No.], ISNULL(licensed_bank_teller,'') as [RRR Number], ISNULL(nin_no, '') as [NIN No.], ISNULL(form_no, '') as [Form No.], ISNULL(teacher_names, '') as [Teacher Names], ISNULL(category, '') as [Category], ISNULL(nationality, '') as [Nationality], ISNULL(state_id, '') as [State], ISNULL(lga_id, '') as [L.G.A.], ISNULL(state_of_origin, '') as [State Of Origin], ISNULL(lga_origin, '') as [L.G.A.Origin], ISNULL(dob, '') as [Date Of Birth], ISNULL(email, '') as [Email], ISNULL(phone_no, '') as [Telephone No.], ISNULL(sex, '') as [Gender], ISNULL(marital_status, '') as [Marital Status], ISNULL(area_of_discipline, '') as [Area Of Discipline], ISNULL(years_of_experience, '') as [Years Of Experience], ISNULL(institution_attended, '') as [Institution Attended], ISNULL(education_level, '') as [Education Level], ISNULL(current_employer, '') as [Current Employer], ISNULL(employment_date, '') as [Employment Date], ISNULL(school_type, '') as [School Type], ISNULL(address, '') as [Address] from " + stbl + " where registration_no = '" + Search + "' or title = '" + Search + "' or form_no = '" + Search + "' or surname = '" + Search + "' or firstname = '" + Search + "' or middlename = '" + Search + "' or marital_status = '" + Search + "' or verified_date = '" + Search + "' or sex = '" + Search + "' or teacher_names = '" + Search + "' or dob = '" + Search + "' or state_id = '" + Search + "' or phone_no = '" + Search + "' or address = '" + Search + "' or lga_id = '" + Search + "' or state_of_origin = '" + Search + "' or lga_origin = '" + Search + "' or year_obtained = '" + Search + "' or nationality = '" + Search + "' or category = '" + Search + "' or current_employer = '" + Search + "' or employment_date = '" + Search + "' or education_level = '" + Search + "' or institution_attended = '" + Search + "' or nin_no = '" + Search + "' or school_one = '" + Search + "' or years_of_Experience = '" + Search + "' or area_of_discipline = '" + Search + "' or pqe_number = '" + Search + "' or email = '" + Search + "' or school_type = '" + Search + "' or form_no = '" + Search + "' or licensed_bank_teller='" + Search + "' AND (registration_status = '" + sRegistrationStatus + "' AND licensed_status='" + sLicensedStatus + "' AND printing_status = '" + sPrintingStatus + "' AND pic_no='" + sPicNo + "') ";

                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public bool PrintLicensed(int iRecID, string tbl_name, string sExpringDate, string sLicensedDate)
        {
            try
            {

                DateTime sDate = DateTime.UtcNow;
                DateTime sExpiring = DateTime.UtcNow;
                string sExpiringDate = sExpiring.Date.AddYears(2).ToString();
                string SSdATE = sDate.Date.ToString();
                string sSQL = "UPDATE " + tbl_name + " SET  licensed_status='3', licensed_new_expiring='" + sExpiringDate + "', licensed_date='" + sLicensedDate + "'  WHERE rec_id=@rec_id";
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


        public bool UpdateSms(string sRecID, string SourceID, string user)
        {
            try
            {
                string sSQL = "update tbl_sms set source_id='" + SourceID + "', sms_message='" + user + "' where rec_id='" + sRecID + "'";
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
        public bool uploadLicensedNumber(string recID, string stbl, string LicensedNumber)
        {
            try
            {
                DateTime sDate = DateTime.UtcNow;
                string sLicensedDate = sDate.Date.ToString();
                string sExpiringDate = sDate.Date.AddYears(2).ToString();
                DateTime sDaNow = DateTime.Parse(sExpiringDate);
                DateTime sDateTimeLicensed = DateTime.Parse(sLicensedDate);
                string sSQL = "update " + stbl + " set guid_no='" + LicensedNumber + "', licensed_status='2' where rec_id='" + recID + "'";
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

        public bool CheckValidLicensedNumber(string tbl, string sLicensedNumber)
        {

            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT * FROM " + tbl + " WHERE [guid_no]=@guidNo";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@guidNo", sLicensedNumber);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Not Found. Contact Administrator.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }

    }

