using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StateOffice_StateOfficeTeacherRegistration : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public int iChangeMode;
    public static string sRecValue = "";
    public static int iCheck;
    public static string sOldValue = "";
    public static string sSchoolType = "";
    public static string DB = "LICENSED";

    private void DisplayError(String sMessage)
    {
        try
        {
            (this.Master as TrcnMaster).DisplayMessage(sMessage, TrcnMaster.MsgType.Error);
        }
        catch (Exception ex)
        {
            Session["msg"] = ex.Message.ToString();
            Response.Redirect("~/en");
        }
    }
    private void DisplayWarning(String sMessage)
    {
        try
        {
            (this.Master as TrcnMaster).DisplayMessage(sMessage, TrcnMaster.MsgType.Warning);
        }
        catch (Exception ex)
        {
            Session["msg"] = ex.Message.ToString();
            Response.Redirect("~/en");
        }
    }
    private void DisplaySuccess(String sMessage)
    {
        try
        {
            (this.Master as TrcnMaster).DisplayMessage(sMessage, TrcnMaster.MsgType.Success);
        }
        catch (Exception ex)
        {
            Session["msg"] = ex.Message.ToString();
            Response.Redirect("~/en");
        }
    }
    public string States()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).States;
            return username;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public string Administrator()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).Administrator ;
            return username;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (States() == "1" || Administrator () == "1")
            {
                if (!this.IsPostBack)
                {
                    teacherRegistrationInformation.Visible = true;
                    TeacherForm.Visible = false;
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    trcn.PopulateLists(ref nationalityS, "GET_COUNTRY");
                    trcn.PopulateLists(ref ddlStateofOrigin, "GET_STATE");
                    trcn.PopulateLists(ref ddlstate, "GET_STATE");
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    trcn.PopulateLists(ref ddlStateID_, "GET_STATE");
                    trcn.PopulateLists(ref ddlLga_, "GET_LGA_BY_STATE", ddlStateID_.SelectedValue);
                    trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
                    trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);
                    ddlLga.SelectedValue = "ALL";
                    allbuttons.Visible = true;
                    loadGrid();
                    openNewState();
                    loadQualification();
                    loadSchool();
                    nationalityS.SelectedValue = "Nigeria";
                    iCheck = 2;
                    lnkUpdate.Visible = false;
                    lnkSave.Visible = true;
                }

            }
            else
            {
                Response.Redirect("504");
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void savePreviousSchool(object sender, EventArgs e)
    {
        try
        {

            registration_no__.Value = registration_nos.Text;
            if (trcn.savePanel(pnlSchool, true) == true)
            {
                loadSchool();
                DisplaySuccess("School Uploaded successfully.");
                trcn.clearPanel(pnlSchool);
            }
            else
            {

                loadSchool();
                DisplayError(trcn.ErrorMessage);

            }

        }
        catch (Exception ex)
        {

        }
    }
    private void saveLicensed()
    {
        try
        {
            registration_no___.Value = registration_no.Value;
            fullname.Value = firstname.Text + " " + middlename.Text + " " + surname.Text;
            licensed_bank_name_.Value = licensed_bank_name.Text;
            licensed_paid_.Value = licensed_paid.Text;
            licensed_date_paid.Value = licensed_date.Text;
            annual_due_amount_.Value = annual_due_amount.Text;
            annual_bank_name_.Value = annual_bank_name.Text;
            annual_bank_teller.Value = annual_bank_teller_.Text;
            annual_paid_date_.Value = annual_paid_date.Text;
            category_.Value = category.Text;
            phone_no_.Value = phone_no.Text;
            email_.Value = email.Text;
            state_id_.Value = ddlStateID.SelectedValue;
            school_type_.Value = school_types.SelectedValue;
            nin_no_.Value = nin_no.Text;
            pqe_number_.Value = pqe_number.Text;
            licensed_status.Value = "NOT";
            if (trcn.savePanel(LICENSED, true) == true)
            {

            }
            else
            {

                DisplayError("Error in Licensed.");
            }


        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }
    private void loadSchool()
    {
        try
        {
            string sWhereClause = "registration_no ='" + registration_nos.Text + "' ORDER BY rec_id desc ";
            trcn.getNonTemplateGrid(gvSchool, sWhereClause);
            gvSchool.UseAccessibleHeader = true;
            gvSchool.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow dgi = gvQualification.SelectedRow;
            rec_id_.Value = dgi.Cells[trcn.getColumnIndexByName(gvQualification, "ID")].Text;
            trcn.getPanelByRecID(pnlQualification);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showQualification(); });", true);

        }
        catch (Exception ex)
        {

        }
    }
    protected void ifCaution(object sender, EventArgs e)
    {
        try
        {
            string sTbl = ddlStateID_.SelectedValue;
            if (trcn.deleteByRegistrationId(ddlStateID_.SelectedValue, sTbl) == true)
            {
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png" || FileUpload1.PostedFile.ContentType == "image/jpg")
                    {
                        if (FileUpload1.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/images/") + filename);
                            string URL = "~/images/" + FileUpload1.FileName;
                            pic_filename.Value = URL;

                        }
                        else
                            DisplayError("Upload status: The file has to be less than 100 kb!");
                    }
                    else
                        DisplayError("Upload status: Only JPEG/PNG/JPG  files are accepted!");

                }
                lga_id.Value = ddlLga_.SelectedValue;
                Panel1.ID = ddlStateID.SelectedValue;
                if (trcn.savePanel(Panel1, true) == true)
                {
                    DisplaySuccess("Your Record has been migrated to " + " " + ddlStateID.SelectedValue);
                    loadSchool();
                    loadQualification();
                }
                else
                {
                    DisplayError(trcn.ErrorMessage);
                }
            }
            else
            {
                DisplayError("There was an error for record disposal. ");
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void getQueryIdentity(object sender, EventArgs e)
    {
        try
        {

            if (school_type.Value == school_types.SelectedValue)
            {
                if (string.IsNullOrEmpty(sOldValue))
                {
                    openNewState();
                }
                else
                {
                    registration_nos.Text = sOldValue;
                }

            }
            else
            {
                openNewState();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void countryCheck(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    //private void checkCountry()
    //{
    //    try
    //    {
    //        if(nationalityss.SelectedValue == "Nigeria")
    //        {
    //            ddlStateofOrigin.Visible = false;
    //            ddlLgaofOrigin.Visible = false;
    //            otherLga.Visible = true;
    //            otherstate.Visible = true;
    //        }
    //        else
    //        {

    //            ddlStateofOrigin.Visible = true;
    //            ddlLgaofOrigin.Visible = true;
    //            otherLga.Visible = false;
    //            otherstate.Visible = false;
    //        }
    //    }
    //    catch(Exception ex)
    //    {

    //    }
    //}
    //private void checkandAssignValues()
    //{
    //    try
    //    {
    //        if (nationalityss.SelectedValue == "Nigeria")
    //        {
    //            nigeriaLga.Visible = true;
    //            nigeriastate.Visible = true;
    //            otherLga.Visible = false;
    //            otherstate.Visible = false;
    //            state_of_origin.Value=     ddlStateofOrigin.SelectedValue;
    //            lga_origin.Value = ddlLgaofOrigin.SelectedValue;
    //        }
    //        else
    //        {
    //            nigeriaLga.Visible = false;
    //            nigeriastate.Visible = false;
    //            otherLga.Visible = true;
    //            otherstate.Visible = true;
    //            state_of_origin.Value = txtState.Text ;
    //            lga_origin.Value = txtlga.Text ;
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    protected void gvSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow dgi = gvSchool.SelectedRow;
            rec_id__.Value = dgi.Cells[trcn.getColumnIndexByName(gvSchool, "ID")].Text;
            trcn.getPanelByRecID(pnlSchool);
            trcn.PopulateLists(ref ddlStateLocation, "GET_STATE");

            trcn.PopulateLists(ref ddllgaLocation, "GET_LGA_BY_STATE", ddlStateLocation.SelectedValue);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showSchool(); });", true);

        }
        catch (Exception ex)
        {

        }
    }

    protected void deleteQualification(object sender, EventArgs e)
    {
        try
        {
            string sTbl = "tbl_qualification";
            if (trcn.deleteTrcnRecord(rec_id_.Value, sTbl) == true)
            {
                loadQualification();
                trcn.clearPanel(pnlQualification);
            }
            else
            {
                loadQualification();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void deleteSchool(object sender, EventArgs e)
    {
        try
        {
            string sTbl = "tbl_School";
            if (trcn.deleteTrcnRecord(rec_id__.Value, sTbl) == true)
            {
                trcn.clearPanel(pnlSchool);
                loadSchool();
            }
            else
            {
                trcn.clearPanel(pnlSchool);
                loadSchool();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void gvList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = gvQualification.Rows[e.RowIndex];
            rec_id_.Value = dgi.Cells[trcn.getColumnIndexByName(gvQualification, "ID")].Text;
            string stbl = "tbl_qualification";
            if (trcn.getTeacherQua(stbl, rec_id_.Value) == true)
            {
                lblQualification.ForeColor = System.Drawing.Color.Red;
                lblQualification.Text = "Qualification : " + "  " + trcn.sTeacherName;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { deleteRecord(); });", true);

            }

            else
            {
                DisplayError("Something went wrong");
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void gvSchool_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = gvSchool.Rows[e.RowIndex];
            rec_id__.Value = dgi.Cells[trcn.getColumnIndexByName(gvSchool, "ID")].Text;
            string stbl = "tbl_School";
            if (trcn.getTeacherSchool(stbl, rec_id__.Value) == true)
            {
                lblSchoolRecord.ForeColor = System.Drawing.Color.Red;
                lblSchoolRecord.Text = "School Name : " + "  " + trcn.sTeacherName;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { deleteSchoolRecord(); });", true);

            }

            else
            {
                DisplayError("Something went wrong");
            }

        }
        catch (Exception ex)
        {
        }
    }

    private void loadQualification()
    {
        try
        {
            string sWhereClause = "registration_no ='" + registration_nos.Text + "' ORDER BY rec_id desc ";
            trcn.getNonTemplateGrid(gvQualification, sWhereClause);
            gvQualification.UseAccessibleHeader = true;
            gvQualification.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void getLgaLocation(object sender, EventArgs e)
    {
        try
        {
            trcn.PopulateLists(ref ddllgaLocation, "GET_LGA_BY_STATE", ddlStateLocation.SelectedValue);
        }
        catch (Exception ex)
        {

        }
    }
    protected void getLgaByStateofOrigin(object sender, EventArgs e)
    {

        trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);


    }

    protected void saveQualification(object sender, EventArgs e)
    {
        try
        {


            registration_no_.Value = registration_nos.Text;
            if (trcn.savePanel(pnlQualification, true) == true)
            {
                trcn.clearPanel(pnlQualification);
                loadQualification();
                DisplaySuccess("Qualification Upload successfully.");
            }
            else
            {
                trcn.clearPanel(pnlQualification);
                loadQualification();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void changeLga(object sender, EventArgs e)
    {
        try
        {
            trcn.PopulateLists(ref ddlLga_, "GET_LGA_BY_STATE", ddlStateID_.SelectedValue);
            openNewState();
        }
        catch (Exception ex)
        {

        }
    }
    protected void getNewID(object sender, EventArgs e)
    {
        try
        {
            if (rec_id.Value != "")
            {

            }
            else
            {
                openNewState();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void goBacks(object sender, EventArgs e)
    {
        try
        {

            teacherRegistrationInformation.Visible = true;
            TeacherForm.Visible = false;
            loadGrid();
        }
        catch (Exception ex)
        {

        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        try
        {
            trcn.CloseConnection();
        }
        catch (Exception ex)
        {

        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {

    }
    protected void mavigateToKnew(object sender, EventArgs e)
    {
        try
        {
            teacherRegistrationInformation.Visible = false;
            TeacherForm.Visible = true;
            registration_nos.Text = "";
            Panel1.ID = DB + ddlStateID.SelectedValue;
            trcn.clearPanel(Panel1);
            ddlStateID_.SelectedValue = ddlStateID.SelectedValue;
            trcn.PopulateLists(ref ddlLga_, "GET_LGA_BY_STATE", ddlStateID_.SelectedValue);
            getCurrentID(school_types.SelectedValue + ddlStateID.SelectedValue);
            nationalityS.SelectedValue = "Nigeria";



        }
        catch (Exception ex)
        {

        }
    }
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = DB + ddlStateID.SelectedValue;
        var products = trcn.getTemplateForAllRegistration(sTbl);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("teacherTemplate");
        var totalCols = products.Columns.Count;
        var totalRows = products.Rows.Count;

        for (var col = 1; col <= totalCols; col++)
        {
            workSheet.Cells[1, col].Value = products.Columns[col - 1].ColumnName;
        }
        for (var row = 1; row <= totalRows; row++)
        {
            for (var col = 0; col < totalCols; col++)
            {
                workSheet.Cells[row + 1, col + 1].Value = products.Rows[row - 1][col];
            }
        }
        using (var memoryStream = new MemoryStream())
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Teacher.xlsx");
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    protected void exportToExcelNavigagateModal(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { exportData(); });", true);

        }
        catch (Exception ex)
        {

        }
    }
    protected void offlineUpload(object sender, EventArgs e)
    {
        try
        {


            string tbl = DB + ddlStateID.SelectedValue;
            importExcelDatastring();
            //importLicensedRecord();
            uploadSchoolType();
            loadGrid();


        }
        catch (Exception ex)
        {

        }
    }
    private void importExcelDatastring()

    {
        try
        {
            if (FileUpload3.HasFile == false)
            {
                DisplayError("Please upload a file.");
                return;
            }
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            string path = Server.MapPath("~/upload/" + sYearMonthDay + FileUpload3.FileName);
            FileUpload3.SaveAs(path);
            //  ExcelConn(_path);  
            OleDbConnection Econ;
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            Econ = new OleDbConnection(constr);
            string Query = string.Format("Select [Registration No],[Category],[Surname],[Firstname],[Middlename],[Date of Birth],[Sex],[Phone Number],[eMail],[Nationality],[State of Origin],[LGA of Origin],[Current Employer],[Office Address],[Area of Specialization],[Form No],[Institutions Attended],[Work Experience],[Qualification wt Dates],[Bank Name],[Annual Due Amount Paid],[Bank Teller],[Date Paid],[Registration Date],[License Amt Paid],[License Date Paid],[Licensed Bank Teller],[Bank Name for License],[State],[Level],[PQE Number],[NIN Number], [Firstname] & ' ' & [Middlename] & ' ' & [Surname]  as [ALL], '0' as [RegistrationStatus],'1' as [PrintingStatus] FROM [{0}]", "Sheet1$");

            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
            {
                Exceldt.Rows[i]["State"] = ddlStateID.SelectedValue;
                Exceldt.Rows[i]["Level"] = ddlschoolType.SelectedValue;
                DateTime dt = DateTime.UtcNow;
                string sDate = dt.Date.ToString();
                Exceldt.Rows[i]["Registration Date"] = sDate;
            }
            Exceldt.AcceptChanges();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString(); //Connection Details    
            sqlConnection.Open();
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
            //assigning Destination table name      
            objbulk.DestinationTableName = DB + ddlStateID.SelectedValue;
            objbulk.ColumnMappings.Add("Registration No", "registration_no");
            objbulk.ColumnMappings.Add("Category", "category");
            objbulk.ColumnMappings.Add("Surname", "surname");
            objbulk.ColumnMappings.Add("Firstname", "firstname");
            objbulk.ColumnMappings.Add("Middlename", "middlename");
            objbulk.ColumnMappings.Add("Date of Birth", "dob");
            objbulk.ColumnMappings.Add("Sex", "sex");
            objbulk.ColumnMappings.Add("Phone Number", "phone_no");
            objbulk.ColumnMappings.Add("eMail", "email");
            objbulk.ColumnMappings.Add("Nationality", "nationality");
            objbulk.ColumnMappings.Add("State of Origin", "state_of_origin");
            objbulk.ColumnMappings.Add("LGA of Origin", "lga_origin");
            objbulk.ColumnMappings.Add("Current Employer", "current_employer");
            objbulk.ColumnMappings.Add("Office Address", "address");
            objbulk.ColumnMappings.Add("Area of Specialization", "area_of_discipline");
            objbulk.ColumnMappings.Add("Form No", "form_no");
            objbulk.ColumnMappings.Add("Institutions Attended", "institution_attended");
            objbulk.ColumnMappings.Add("Work Experience", "years_of_Experience");
            objbulk.ColumnMappings.Add("Qualification wt Dates", "education_level");
            objbulk.ColumnMappings.Add("Bank Name", "annual_bank_name");
            objbulk.ColumnMappings.Add("Annual Due Amount Paid", "annual_due_amount");
            objbulk.ColumnMappings.Add("Bank Teller", "annual_bank_teller");
            objbulk.ColumnMappings.Add("Date Paid", "annual_paid_date");
            objbulk.ColumnMappings.Add("Registration Date", "registration_date");
            objbulk.ColumnMappings.Add("License Amt Paid", "licensed_paid");
            objbulk.ColumnMappings.Add("License Date Paid", "licensed_date");
            objbulk.ColumnMappings.Add("Licensed Bank Teller", "licensed_bank_teller");
            objbulk.ColumnMappings.Add("Bank Name for License", "licensed_bank_name");
            objbulk.ColumnMappings.Add("State", "state_id");
            objbulk.ColumnMappings.Add("Level", "school_type");
            objbulk.ColumnMappings.Add("PQE Number", "pqe_number");
            objbulk.ColumnMappings.Add("NIN Number", "nin_no");
            objbulk.ColumnMappings.Add("ALL", "teacher_names");
            objbulk.ColumnMappings.Add("RegistrationStatus", "registration_status");
            objbulk.ColumnMappings.Add("PrintingStatus", "printing_status");
            objbulk.WriteToServer(Exceldt);
            sqlConnection.Close();
            DisplaySuccess("Records have been Imported successfully");
            sqlConnection.Close();
            sqlConnection.Dispose();

        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private void importLicensedRecord()
    {
        try
        {
            if (FileUpload3.HasFile == false)
            {
                DisplayError("Please upload a file.");
                return;
            }
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            string path = Server.MapPath("~/upload/" + sYearMonthDay + FileUpload3.FileName);
            FileUpload3.SaveAs(path);
            //  ExcelConn(_path);  
            OleDbConnection Econ;
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            Econ = new OleDbConnection(constr);
            string Query = string.Format("Select [Registration No],[Category],[Phone Number],[eMail],[Bank Name],[Annual Due Amount Paid],[Bank Teller],[Date Paid],[License Amt Paid],[License Date Paid],[Licensed Bank Teller],[Bank Name for License],[State],[Level],[PQE Number],[NIN Number], [Firstname] & ' ' & [Middlename] & ' ' & [Surname]  as [ALL],   '' as [AnnualDueExpirationDate], '' as [LicensedExpirationDate] FROM [{0}]", "Sheet1$");

            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
            {
                Exceldt.Rows[i]["State"] = ddlStateID.SelectedValue;
                Exceldt.Rows[i]["Level"] = ddlschoolType.SelectedValue;
                DateTime dt = DateTime.UtcNow;
                string sDate = dt.Date.ToString();
                Exceldt.Rows[i]["Registration Date"] = sDate;
            }
            Exceldt.AcceptChanges();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString(); //Connection Details    
            sqlConnection.Open();
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
            //assigning Destination table name      
            objbulk.DestinationTableName = "LICENSED";
            objbulk.ColumnMappings.Add("Registration No", "registration_no");
            objbulk.ColumnMappings.Add("Category", "category");
            objbulk.ColumnMappings.Add("Phone Number", "phone_no");
            objbulk.ColumnMappings.Add("eMail", "email");
            objbulk.ColumnMappings.Add("Bank Name", "annual_bank_name");
            objbulk.ColumnMappings.Add("Annual Due Amount Paid", "annual_due_amount");
            objbulk.ColumnMappings.Add("Bank Teller", "annual_bank_teller");
            objbulk.ColumnMappings.Add("Date Paid", "annual_paid_date");
            objbulk.ColumnMappings.Add("License Amt Paid", "licensed_paid");
            objbulk.ColumnMappings.Add("License Date Paid", "licensed_date_paid");
            objbulk.ColumnMappings.Add("Licensed Bank Teller", "licensed_bank_teller");
            objbulk.ColumnMappings.Add("Bank Name for License", "licensed_bank_name");
            objbulk.ColumnMappings.Add("State", "state_id");
            objbulk.ColumnMappings.Add("Level", "school_type");
            objbulk.ColumnMappings.Add("PQE Number", "pqe_number");
            objbulk.ColumnMappings.Add("NIN Number", "nin_no");
            objbulk.ColumnMappings.Add("ALL", "fullname");
            objbulk.WriteToServer(Exceldt);
            sqlConnection.Close();
            DisplaySuccess("Records have been Imported successfully");
            sqlConnection.Close();
            sqlConnection.Dispose();

        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }


    private void uploadSchoolType()

    {
        try
        {

            if (FileUpload3.HasFile == false)
            {
                DisplayError("Please upload a file.");
                return;
            }
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            string path = Server.MapPath("~/upload/" + sYearMonthDay + FileUpload3.FileName);

            FileUpload3.SaveAs(path);
            //  ExcelConn(_path);  
            OleDbConnection Econ;
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            Econ = new OleDbConnection(constr);
            string Query = string.Format("Select [Registration No],[Category],[Surname],[Firstname],[Middlename],[Date of Birth],[Sex],[Phone Number],[eMail],[Nationality],[State of Origin],[LGA of Origin],[Current Employer],[Office Address],[Area of Specialization],[Form No],[Institutions Attended],[Work Experience],[Qualification wt Dates],[Registration Date],[License Amt Paid],[State],[Level],[PQE Number],[NIN Number] FROM [{0}]", "Sheet1$");

            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];

            for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
            {
                Exceldt.Rows[i]["State"] = ddlStateID.SelectedValue;
                Exceldt.Rows[i]["Level"] = ddlschoolType.SelectedValue;
                DateTime dt = DateTime.UtcNow;
                string sDate = dt.Date.ToString();
                Exceldt.Rows[i]["Registration Date"] = sDate;
            }
            Exceldt.AcceptChanges();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString(); //Connection Details    
            sqlConnection.Open();
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
            //assigning Destination table name      
            objbulk.DestinationTableName = ddlschoolType.SelectedValue + ddlStateID.SelectedValue;
            objbulk.ColumnMappings.Add("Registration No", "registration_no");
            objbulk.ColumnMappings.Add("Category", "category");
            objbulk.ColumnMappings.Add("Surname", "surname");
            objbulk.ColumnMappings.Add("Firstname", "firstname");
            objbulk.ColumnMappings.Add("Middlename", "middlename");
            objbulk.ColumnMappings.Add("Date of Birth", "dob");
            objbulk.ColumnMappings.Add("Sex", "sex");
            objbulk.ColumnMappings.Add("Phone Number", "phone_no");
            objbulk.ColumnMappings.Add("eMail", "email");
            objbulk.ColumnMappings.Add("Nationality", "nationality");
            objbulk.ColumnMappings.Add("State of Origin", "state_of_origin");
            objbulk.ColumnMappings.Add("LGA of Origin", "lga_origin");
            objbulk.ColumnMappings.Add("Current Employer", "current_employer");
            objbulk.ColumnMappings.Add("Office Address", "address");
            objbulk.ColumnMappings.Add("Area of Specialization", "area_of_discipline");
            objbulk.ColumnMappings.Add("Form No", "form_no");
            objbulk.ColumnMappings.Add("Institutions Attended", "institution_attended");
            objbulk.ColumnMappings.Add("Work Experience", "years_of_Experience");
            objbulk.ColumnMappings.Add("Qualification wt Dates", "education_level");
            objbulk.ColumnMappings.Add("Registration Date", "registration_date");
            objbulk.ColumnMappings.Add("License Amt Paid", "licensed_paid");
            objbulk.ColumnMappings.Add("State", "state_id");
            objbulk.ColumnMappings.Add("Level", "school_type");
            objbulk.ColumnMappings.Add("PQE Number", "pqe_number");
            objbulk.ColumnMappings.Add("NIN Number", "nin_no");
            objbulk.WriteToServer(Exceldt);
            sqlConnection.Close();
            DisplaySuccess("Records have been Imported successfully");
            sqlConnection.Close();
            sqlConnection.Dispose();

        }
        catch (Exception ex)
        {

        }


    }
    private void loadGrid()
    {
        try
        {
            allbuttons.Visible = true;
            iChangeMode = 0;
            queryLgaCommunity();

        }
        catch (Exception ex)
        {

        }
    }
    private void queryLgaCommunity()
    {
        try
        {
            DataSet ds = trcn.showDocumentationGrid(DB + ddlStateID.SelectedValue);
            gvList.DataSource = ds;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void checkAll(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in gvList.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("chkcheck");
                if (chkVerified.Checked == false)
                {
                    chkVerified.Checked = true;
                    lblCheck.Text = "Uncheck";
                }
                else
                {
                    chkVerified.Checked = false;
                    lblCheck.Text = "Check";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void deleteCheckedRows(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in gvList.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("chkcheck");
                if (chkVerified.Checked)
                {
                    string stbl = DB + ddlStateID.SelectedValue;
                    int recID = Convert.ToInt32(grow.Cells[3].Text);
                    if (trcn.docDelete(stbl, recID) == true)
                    {
                        DisplaySuccess("Checked record(s) was deleted successfully");
                        loadGrid();
                    }
                    else
                    {

                        loadGrid();
                    }
                }
            }
        }
        catch (Exception EX)
        {

        }
    }
    protected void deleteAllRecords(object sender, EventArgs e)
    {
        try
        {
            string stbl = DB + ddlStateID.SelectedValue;
            if (trcn.docDeleteAll(stbl) == true)
            {
                DisplaySuccess("Record(s) was deleted successfully");
                loadGrid();
            }
            else
            {

                loadGrid();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void viewState(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 0;
            queryLgaCommunity();
        }
        catch (Exception ex)
        {

        }
    }
    private void SearchTeacherByID()
    {
        try
        {
            string stbl = DB + ddlStateID.SelectedValue;
            string sRegNo = teacherID.Text;
            DataSet ds = trcn.showDocumentationSearchGrid(stbl, sRegNo);
            gvList.DataSource = ds;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void searchTeacher(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 1;
            SearchTeacherByID();
        }
        catch (Exception ex)
        {

        }
    }
    private void ViewTeacherByRange()
    {
        try
        {
            string stbl = DB + ddlStateID.SelectedValue;
            string sRange1 = RangeFrom.Text;
            string sRange2 = RangeTo.Text;
            DataSet ds = trcn.showRangeGridDoc(stbl, sRange1, sRange2);
            gvList.DataSource = ds;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void viewByRange(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 2;
            ViewTeacherByRange();
        }
        catch (Exception ex)
        {

        }
    }
    private void SearchTeacherIntelligence()
    {
        try
        {
            string sTbl = DB + ddlStateID.SelectedValue;
            string sSearch = Search.Value;
            DataSet ds = trcn.SearchIntelligenceDocument(sTbl, sSearch);
            gvList.DataSource = ds;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void searchIntelligence(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 3;
            SearchTeacherIntelligence();
        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIACHANGED(object sender, EventArgs e)
    {
        try
        {
            teacherRegistrationInformation.Visible = false;
            TeacherForm.Visible = true;
            lnkUpdate.Visible = true;
            lnkSave.Visible = false;
            trcn.PopulateLists(ref ddlStateofOrigin, "GET_STATE");
            trcn.PopulateLists(ref ddlStateID_, "GET_STATE");
            trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);
            GridViewRow dgi = gvList.SelectedRow;
            ddlStateofOrigin.SelectedItem.Text = dgi.Cells[trcn.getColumnIndexByName(gvList, "State of Origin")].Text;
            ddlLga0fOrigin.SelectedItem.Text = dgi.Cells[trcn.getColumnIndexByName(gvList, "L.G.A.")].Text;
            ddlStateID_.SelectedItem.Text = ddlStateID.SelectedValue;
            Panel1.ID = DB + ddlStateID.SelectedValue;
            rec_id.Value = dgi.Cells[trcn.getColumnIndexByName(gvList, "ID")].Text;
            trcn.getPanelByRecID(Panel1);
            trcn.PopulateLists(ref ddlLga_, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
            trcn.getPanelByRecID(Panel1);
            ddlLga_.SelectedItem.Text = lga_id.Value;
            school_types.SelectedItem.Text = school_type.Value;
            registration_nos.Text = registration_no.Value;
            imgTeacherPhoto.Src = pic_filename.Value;
            img1.Src = teacher_signature.Value;
            string sSex = sex.Value;
            if (sSex.Contains("F") == true)
            {
                sexs.SelectedValue = "FEMALE";
            }
            ddlLga0fOrigin.SelectedValue = lga_origin.Value;
            ddlLga_.SelectedValue = lga_id.Value;
            loadQualification();
            loadSchool();
            registration_no_.Value = registration_no.Value;
            registration_no__.Value = registration_no.Value;
            sOldValue = registration_no_.Value;
            sSchoolType = school_type.Value;

            DisplaySuccess("");
        }
        catch (Exception ex)
        {

        }
    }
    private void updateSchoolandQualification(string sRegistration_no, string OldRegistrationNo)
    {
        try
        {

            if (trcn.UpdateQualificationAndSchool(sRegistration_no, OldRegistrationNo) == true)
            {

            }
            else
            {
                DisplayError("Not Updated.");
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIADELETE(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = gvList.Rows[e.RowIndex];
            sRecValue = dgi.Cells[trcn.getColumnIndexByName(gvList, "ID")].Text;
            string stbl = DB + ddlStateID.SelectedValue;

            if (trcn.getTeacherID(stbl, sRecValue) == true)
            {
                lblTransID.ForeColor = System.Drawing.Color.DarkRed;
                lblTransID.Text = "Are you sure that you want to delete user With User Name:" + " " + trcn.sTeacherName;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showDelete(); });", true);
            }
            else
            {
                DisplayError("something went wrong.");
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void lbDeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string sTbl = DB + ddlStateID.SelectedValue;
            if (trcn.deleteTrcnRecord(sRecValue, sTbl) == true)
            {
                DisplaySuccess("Record deleted successfully.");
                loadGrid();
            }
            else
            {
                DisplaySuccess("Record not deleted successfully.");
                loadGrid();
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void loadAll()
    {
        try
        {
            trcn.PopulateLists(ref nationalityS, "GET_COUNTRY");
            trcn.PopulateLists(ref ddlStateofOrigin, "GET_STATE");
            nationalityS.SelectedValue = "Nigeria";
            trcn.PopulateLists(ref ddlStateID, "GET_STATE");
            ddlStateID.SelectedValue = Session["state_id"].ToString();
            openNewState();
            trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);
            trcn.PopulateLists(ref ddlLga_, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
            trcn.PopulateLists(ref ddlStateLocation, "GET_STATE");
            ddlStateLocation.SelectedValue = Session["state_id"].ToString();
            trcn.PopulateLists(ref ddllgaLocation, "GET_LGA_BY_STATE", ddlStateLocation.SelectedValue);
            imgTeacherPhoto.Src = "~/assets/images/avartar.png";
            school_types.Enabled = true;
        }
        catch (Exception ex)
        {

        }
    }
    private void getCurrentID(string stbl)
    {
        try
        {
            string sstate_id = ddlStateID_.Items[ddlStateID.SelectedIndex].Text;
            string sSchoolType = school_types.Items[school_types.SelectedIndex].Text;
            string sTwostate_idChar = new string(sstate_id.Take(2).ToArray());
            string sTwoSchoolTypeChar = new string(sSchoolType.Take(1).ToArray());
            if (sTwoSchoolTypeChar == "O")
            {
                sTwoSchoolTypeChar = "R";
            }
            //if (trcn.AutoIncrementID(stbl) == true)
            //{
            //    registration_no.Text = sTwostate_idChar + "/" + sTwoSchoolTypeChar + "/" + trcn.sLastRecID;
            //}
            //else
            //{
            //    registration_no.Text = sTwostate_idChar + "/" + sTwoSchoolTypeChar + "/" + trcn.sLastRecID;
            //}
            string id = trcn.AutoIncrementID(stbl);
            int idLimit = 5;
            string eno = sTwostate_idChar + "/" + sTwoSchoolTypeChar + "/" + trcn.ZeroAppend("00000" + id, idLimit);
            registration_nos.Text = eno;
        }
        catch (Exception ex)
        {


        }
    }
    private void openNewState()
    {
        try
        {

            string stbl = school_types.SelectedValue + ddlStateID_.SelectedValue;
            getCurrentID(stbl);

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {
        try
        {
            gvList.PageIndex = 0;
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            if (iChangeMode == 0)
            {
                loadGrid();
            }
            if (iChangeMode == 1)
            {
                SearchTeacherByID();
            }
            if (iChangeMode == 2)
            {
                ViewTeacherByRange();
            }
            if (iChangeMode == 3)
            {
                SearchTeacherIntelligence();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int i = gvList.PageIndex + 1;
            if (i <= gvList.PageCount)
            {
                gvList.PageIndex = i;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }

            if (gvList.PageCount - 1 == gvList.PageIndex)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int i = gvList.PageCount;
            if (gvList.PageIndex > 0)
            {

                gvList.PageIndex = gvList.PageIndex - 1;
                btnLast.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }

            if (gvList.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }
            if (gvList.PageCount - 1 == gvList.PageIndex + 1)
            {
                btnNext.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }
            if (gvList.PageIndex == 0)
            {
                btnPrevious.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    SearchTeacherByID();
                }
                if (iChangeMode == 2)
                {
                    ViewTeacherByRange();
                }
                if (iChangeMode == 3)
                {
                    SearchTeacherIntelligence();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnlast_Click(object sender, EventArgs e)
    {
        try
        {
            gvList.PageIndex = gvList.PageCount;
            btnLast.Enabled = false;
            btnFirst.Enabled = true;
            if (iChangeMode == 0)
            {
                loadGrid();
            }
            if (iChangeMode == 1)
            {
                SearchTeacherByID();
            }
            if (iChangeMode == 2)
            {
                ViewTeacherByRange();
            }
            if (iChangeMode == 3)
            {
                SearchTeacherIntelligence();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIACHANGING(object sender, GridViewPageEventArgs e)
    {

        gvList.PageIndex = e.NewPageIndex;
        if (iChangeMode == 0)
        {
            loadGrid();
        }
        if (iChangeMode == 1)
        {
            SearchTeacherByID();
        }
        if (iChangeMode == 2)
        {
            ViewTeacherByRange();
        }
        if (iChangeMode == 3)
        {
            SearchTeacherIntelligence();
        }
    }
    protected void downloadExcelTemplate(object sender, EventArgs e)
    {
        try
        {
            Download_File("~/upload/TRCNTemplate.xlsx");
        }
        catch (Exception ex)
        {

        }
    }
    private void Download_File(string FilePath)
    {
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
        Response.WriteFile(FilePath);
        Response.End();
    }
    //private void check()
    //{
    //    try
    //    {

    //        //source code
    //        List<string> cbText = new List<string>();
    //        if (chknce.Checked==true)
    //        {
    //            cbText.Add(chknce.Text);
    //        }
    //        if (chkbed.Checked==true)
    //        {
    //            cbText.Add(chkbed.Text);
    //        }

    //        if (chkmed.Checked==true)
    //        {
    //            cbText.Add(chkmed.Text);
    //        }

    //        if (chkpdde.Checked==true)
    //        {

    //            cbText.Add(chkpdde.Text);
    //        }
    //        if (chkpde.Checked==true)
    //        {
    //            cbText.Add(chkpde.Text);
    //        }

    //        if (chkpede.Checked==true)
    //        {
    //            cbText.Add(chkpede.Text);
    //        }

    //        if (chkPHD.Checked==true)
    //        {
    //            cbText.Add(chkPHD.Text);
    //        }

    //        string ClientString = String.Empty;

    //        foreach (string cb in cbText)
    //        {
    //            ClientString += cb + " ";
    //            education_level.Value = ClientString;


    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void saveChanges(object sender, EventArgs e)
    {
        try
        {

            DateTime bday = DateTime.Parse(dob.Text);
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            if (age < 15)
            {
                DisplayError("Please you are under 15 years of age. Sorry! You cannot go on with the registration. Contact Administrator.");
                return;
            }
            else
            {
                if (FileUpload2.HasFile)
                {

                    FileUpload2.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + FileUpload2.FileName);
                    string URL3 = "~/upload/" + sYearMonthDay + FileUpload2.FileName;
                    pic_filename.Value = URL3;
                }
                if (FileUploadSignature.HasFile)
                {

                    FileUploadSignature.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + FileUploadSignature.FileName);
                    string URL3 = "~/upload/" + sYearMonthDay + FileUploadSignature.FileName;
                    teacher_signature.Value = URL3;
                }
                teacher_names.Value = firstname.Text + " " + middlename.Text + " " + surname.Text;
                sex.Value = sexs.SelectedValue;
                state_of_origin.Value = ddlStateofOrigin.SelectedItem.Text;
                lga_origin.Value = ddlLga0fOrigin.SelectedItem.Text;
                //check();
                state_id.Value = ddlStateID.SelectedValue;
                lga_id.Value = ddlLga_.SelectedValue;
                school_type.Value = school_types.SelectedValue;
                registration_no.Value = registration_nos.Text;
                registration_status.Value = "0";
                printing_status.Value = "1";
                DateTime dt = DateTime.UtcNow;
                string sDate = dt.Date.ToString();
                registration_date.Value = sDate;
                nationality.Value = "Nigeria";
                Panel1.ID = DB + ddlStateID.SelectedValue;
                string tbl = school_types.SelectedValue + ddlStateID.SelectedValue;
                if (trcn.addTypeNumber(tbl, registration_nos.Text, pqe_number.Text) == true)
                {
                    DisplaySuccess("saved");
                }
                saveLicensed();
                if (trcn.savePanel(Panel1, true) == true)
                {
                    DisplaySuccess("Record saved successfully.");
                    queryLgaCommunity();
                    trcn.clearPanel(Panel1);
                    registration_nos.Text = "";
                    teacherRegistrationInformation.Visible = true;
                    TeacherForm.Visible = false;
                }
                else
                {
                    DisplayError(trcn.ErrorMessage);
                    loadGrid();
                }


            }
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }
    protected void Update(object sender, EventArgs e)
    {
        try
        {

            DateTime bday = DateTime.Parse(dob.Text);
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();

            if (age < 15)
            {
                DisplayError("Please you are under 15 years of age. Sorry! You cannot go on with the registration. Contact Administrator.");
                return;
            }
            else
            {

                if (FileUpload2.HasFile)
                {

                    FileUpload2.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + FileUpload2.FileName);
                    string URL3 = "~/upload/" + sYearMonthDay + FileUpload2.FileName;
                    pic_filename.Value = URL3;
                }
                if (FileUploadSignature.HasFile)
                {

                    FileUploadSignature.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + FileUploadSignature.FileName);
                    string URL3 = "~/upload/" + sYearMonthDay + FileUploadSignature.FileName;
                    teacher_signature.Value = URL3;
                }
                teacher_names.Value = firstname.Text + " " + middlename.Text + " " + surname.Text;
                sex.Value = sexs.SelectedValue;
                state_of_origin.Value = ddlStateofOrigin.SelectedItem.Text;
                lga_origin.Value = ddlLga0fOrigin.SelectedItem.Text;
                //check();
                state_id.Value = ddlStateID.SelectedValue;
                lga_id.Value = ddlLga_.SelectedValue;
                school_type.Value = school_types.SelectedValue;
                registration_no.Value = registration_nos.Text;
                nationality.Value = "Nigeria";
                printing_status.Value = "1";
                DateTime dt = DateTime.UtcNow;
                string sDate = dt.Date.ToString();
                registration_date.Value = sDate;
                saveLicensed();
                Panel1.ID = DB + ddlStateID.SelectedValue;
                if (trcn.savePanel(Panel1, true) == true)
                {
                    updateSchoolandQualification(registration_nos.Text, sOldValue);
                    DisplaySuccess("Record updated successfully.");
                    queryLgaCommunity();
                    trcn.clearPanel(Panel1);
                    registration_nos.Text = "";
                    teacherRegistrationInformation.Visible = true;
                    TeacherForm.Visible = false;
                    lnkUpdate.Visible = false;
                    lnkSave.Visible = true;
                }
                else
                {
                    DisplayError(trcn.ErrorMessage);
                    loadGrid();
                }

            }
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

}