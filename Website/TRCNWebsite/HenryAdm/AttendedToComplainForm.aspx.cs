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

public partial class HenryAdm_AttendedToComplainForm : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public int iChangeMode;
    public static string sRecValue = "";
    public static int iCheck;
    public static string sOldValue = "";
    public static string sSchoolType = "";
    public static string sNo = "1";

    protected void lnk_SettingsClicked(object sender, EventArgs e)
    {
        try
        {
            if (sender.Equals(lnkOriginalEvidencePayment))
            {
                Download_File(original_evidence_payment.Text);
            }
            if (sender.Equals(lnkOtherCredentials))
            {
                Download_File(other_credentials.Text);
            }
            if (sender.Equals(lnkOfficialComplainLetter))
            {
                Download_File(official_complain_letter.Text);
            }
            if (sender.Equals(lnkSignature))
            {
                Download_File(signature.Text);
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void DisplayError(String sMessage)
    {
        try
        {
            (this.Master as TrcnMaster ).DisplayMessage(sMessage, TrcnMaster.MsgType.Error);
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
    public string Administrator()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).Administrator;
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
            if (Administrator() == "1")
            {
                if (!this.IsPostBack)
                {
                    teacherRegistrationInformation.Visible = true;
                    TeacherForm.Visible = false;
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    trcn.PopulateLists(ref ddlStateofOrigin, "GET_STATE");
                    trcn.PopulateLists(ref ddlstate, "GET_STATE");
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
                    trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);
                    ddlLga.SelectedValue = "ALL";

                    allbuttons.Visible = true;
                    loadGrid();
                    iCheck = 2;
                    //lnkUpdate.Visible = false;
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

    protected void countryCheck(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }

    protected void getLgaByStateofOrigin(object sender, EventArgs e)
    {

        trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);


    }


    protected void changeLga(object sender, EventArgs e)
    {
        try
        {

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
    protected void mavigateToKnew(object sender, EventArgs e)
    {
        try
        {
            teacherRegistrationInformation.Visible = false;
            TeacherForm.Visible = true;

            trcn.clearPanel(pnlComplainform);





        }
        catch (Exception ex)
        {

        }
    }
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = ddlStateID.SelectedValue;
        var products = trcn.GetTemplateComplainForm(sNo);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("ComplainFormNotAttendedTo");
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
            DataSet ds = trcn.ShowComplainFormGrid(sNo);
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
                    string stbl = "tbl_complainform";
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
            string stbl = "tbl_complainform";

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
            string sRegNo = teacherID.Text;
            DataSet ds = trcn.showComplainFormGridByTeacherID(sNo, sRegNo);
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
            string stbl = ddlStateID.SelectedValue;
            string sRange1 = RangeFrom.Text;
            string sRange2 = RangeTo.Text;
            DataSet ds = trcn.ShowRangeComplainForm(sRange1, sRange2);
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
            string sTbl = ddlStateID.SelectedValue;
            string sSearch = Search.Value;
            DataSet ds = trcn.SearchComplainFormIntelligence(sNo, sSearch);
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
            //lnkUpdate.Visible = true;
            lnkSave.Visible = true;
            trcn.PopulateLists(ref ddlStateofOrigin, "GET_STATE");
            GridViewRow dgi = gvList.SelectedRow;
            rec_id.Value = dgi.Cells[trcn.getColumnIndexByName(gvList, "ID")].Text;
            trcn.getPanelByRecID(pnlComplainform);
            ddlStateofOrigin.SelectedValue = state_of_origin.Value;
            trcn.PopulateLists(ref ddlLga0fOrigin, "GET_LGA_BY_STATE", ddlStateofOrigin.SelectedValue);
            imgTeacherPhoto.Src = passport_photo.Value;
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
            string sTbl = "tbl_complainform";
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
    protected void lbDeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string sTbl = "tbl_complainform";

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

            state_of_origin.Value = ddlStateofOrigin.SelectedValue;
            lga_id.Value = ddlLga0fOrigin.SelectedValue;
            hdRegName.Value = registration_no.Text;
            admin_attend.Value = "0";
            date_of_registration.Value = DateTime.Now.ToString("YYYY/MM/DD");
            if (trcn.checkRegStatus(hdRegName.Value) == true)
            {
                if (trcn.savePanel(pnlComplainform, true) == true)
                {
                    DisplaySuccess("Complain form attended to.");
                    loadGrid();
                }
                else
                {
                    DisplayError(trcn.ErrorMessage);
                    loadGrid();
                }
            }
            else
            {
                DisplayError(trcn.ErrorMessage);
                loadGrid();
            }

        }
        catch (Exception ex)
        {

        }
    }

}