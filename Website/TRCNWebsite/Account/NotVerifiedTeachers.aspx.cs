using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

public partial class Account_NotVerifiedTeachers : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public static string sRegistrationStatus = "0";
    public static string sRecValue = "";
    public static int iChangeMode = 0;
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = ddlStateID.SelectedValue;
        var products = trcn.getRegistrationStatus(sTbl, sRegistrationStatus);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("teacher");
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
    private void ExportToExcel()
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=verifiedLog.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divContent.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportExcel(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int i = ABIA.PageIndex + 1;
            if (i <= ABIA.PageCount)
            {
                ABIA.PageIndex = i;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }

            if (ABIA.PageCount - 1 == ABIA.PageIndex)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
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
            int i = ABIA.PageCount;
            if (ABIA.PageIndex > 0)
            {

                ABIA.PageIndex = ABIA.PageIndex - 1;
                btnLast.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }

            if (ABIA.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
            if (ABIA.PageCount - 1 == ABIA.PageIndex + 1)
            {
                btnNext.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
            if (ABIA.PageIndex == 0)
            {
                btnPrevious.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
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
            ABIA.PageIndex = ABIA.PageCount;
            btnLast.Enabled = false;
            btnFirst.Enabled = true;
            if (iChangeMode == 0)
            {
                loadGrid();
            }
            if (iChangeMode == 1)
            {
                searchforTeacherID();
            }
            if (iChangeMode == 2)
            {
                changeLoad();
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
            ABIA.PageIndex = 0;
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
                searchforTeacherID();
            }
            if (iChangeMode == 2)
            {
                changeLoad();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void verifyByRange(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chk = (CheckBox)grow.FindControl("CHKABIA");
                chk.Checked = true;
                chkVerified();

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void checkAll(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("CHKABIA");
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

    protected void verifyBtnClicked(object sender, EventArgs e)
    {
        try
        {
            if (Account() == "1" || AccountHead () == "1" ||Administrator () == "1")
            {
                verifyAllRecords();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void verifyAllRecords()
    {
        try
        {
            string stbl = ddlStateID.SelectedValue;
            if (trcn.verifyAccountLog(stbl) == true)
            {
                DisplaySuccess("All Records have been verified successfully.");
                loadGrid();
            }
            else
            {
                DisplaySuccess("An error has occurred");
                loadGrid();
            }
        }
        catch (Exception ex)
        {

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

    public string Account()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).Account;
            return username;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public string AccountHead()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).AccountHead;
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
            if (Account() == "1" || AccountHead() == "1" || Administrator() == "1")
            {
                if (!this.IsPostBack)
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
                    ddlLga.SelectedValue = "ALL";

                    loadGrid();
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
    protected void ABIACHANGING(object sender, GridViewPageEventArgs e)
    {

        ABIA.PageIndex = e.NewPageIndex;
        if (iChangeMode == 0)
        {
            loadGrid();
        }
        if (iChangeMode == 1)
        {
            searchforTeacherID();
        }
        if (iChangeMode == 2)
        {
            changeLoad();
        }

    }

    private void changeLoad()
    {
        try
        {
            viewByRange();
        }
        catch (Exception ex)
        {

        }
    }

    protected void verifyByChecked(object sender, EventArgs e)
    {
        try
        {
            if (Account() == "1" || AccountHead() == "1" || Administrator() == "1")
            {
                chkVerified();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {

        }
    }

    private void chkVerified()
    {
        try
        {

            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("CHKABIA");
                if (chkVerified.Checked)
                {
                    string stbl = ddlStateID.SelectedValue;
                    int recID = Convert.ToInt32(grow.Cells[3].Text);
                    if (trcn.intverifiedRecords(recID, stbl) == true)
                    {
                        DisplaySuccess("Checked record(s) was verified successfully");
                        loadGrid();
                    }
                    else
                    {

                        loadGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DisplayError(ex.ToString());
        }
    }


    protected void intelligentQuery(object sender, EventArgs e)
    {
        try
        {
            string tbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.searchAllAccountIntelligence(tbl, Search.Value, sRegistrationStatus);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIACHANGED(object sender, EventArgs e)
    {
        try
        {
            GridViewRow dgi = ABIA.SelectedRow;
            sRecValue = dgi.Cells[trcn.getColumnIndexByName(ABIA, "ID")].Text;
            int iRec = int.Parse(sRecValue);
            string stbl = ddlStateID.SelectedValue;

            if (trcn.intverifiedRecords(iRec, stbl) == true)
            {
                DisplaySuccess("Checked record(s) was verified successfully");
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



    protected void ABIADELETE(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = ABIA.Rows[e.RowIndex];
            sRecValue = dgi.Cells[trcn.getColumnIndexByName(ABIA, "ID")].Text;
            string stbl = ddlStateID.SelectedValue;

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


    protected void searchTeacherID(object sender, EventArgs e)
    {
        try
        {
            if (Account() == "1" || AccountHead () == "1" || Administrator () == "1")
            {
                iChangeMode = 1;
                searchforTeacherID();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {

        }
    }

    private void searchforTeacherID()
    {
        try
        {
            string stbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.accountTeacherID(stbl, teacherID.Text);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        catch (Exception ex)
        {

        }
    }
    private void queryLgaCommunity()
    {
        try
        {
            string stbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.showRegistrationStatus(stbl, sRegistrationStatus);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }

    protected void viewState(object sender, EventArgs e)
    {
        try
        {
            if (Account () == "1" || AccountHead () == "1" || Administrator () == "1")
            {
                iChangeMode = 0;
                trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
                ddlLga.SelectedValue = "ALL";
                queryLgaCommunity();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {
            DisplayError(ex.ToString());
        }
    }
    protected void viewLga(object sender, EventArgs e)
    {
        try
        {
            if (Account () == "1" || AccountHead () == "1" || Administrator () == "1")
            {
                iChangeMode = 0;
                queryLgaCommunity();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void loadGrid()
    {
        try
        {
            queryLgaCommunity();

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


    protected void lbDeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string sTbl = ddlStateID.SelectedValue;
            if (trcn.deleteTrcnRecord(sRecValue, sTbl) == true)
            {
                DisplaySuccess("Record deleted successfully.");
                loadGrid();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void viewRange(object sender, EventArgs e)
    {
        try
        {
            if (Account () == "1" || AccountHead () == "1" || Administrator () == "1")
            {
                iChangeMode = 2;
                viewByRange();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void viewByRange()
    {
        try
        {
            string tbl = ddlStateID.SelectedValue;
            string one = RangeFrom.Text;
            string two = RangeTo.Text;
            DataSet ds = trcn.showDocumentationRangeGrid(tbl, one, two, sRegistrationStatus);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }

}