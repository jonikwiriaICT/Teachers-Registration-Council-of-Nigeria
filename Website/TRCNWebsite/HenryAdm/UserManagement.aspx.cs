using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

public partial class HenryAdm_UserManagement : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();

    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = "user_management";
        var products = trcn.getGenerealTemplate(sTbl);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("usermanagement");
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
            Response.AddHeader("content-disposition", "attachment;  filename=usermanagement.xlsx");
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
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
    protected void ABIACHANGING(object sender, GridViewPageEventArgs e)
    {

        gvuserManagement.PageIndex = e.NewPageIndex;

        loadGrid();



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
            if (Administrator () == "1")
            {
                if (!this.IsPostBack)
                {
                    loadGrid();
                    trcn.PopulateLists(ref state_id, "GET_STATE");

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
    protected void checkDelete(object sender, EventArgs e)
    {
        try
        {
            if (Administrator () == "1")
            {
                foreach (GridViewRow grow in gvuserManagement.Rows)
                {
                    //Searching CheckBox("chkDel") in an individual row of Grid  
                    CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                    //If CheckBox is checked than delete the record with particular empid  
                    if (chkdel.Checked == true)
                    {

                        string rec_id = grow.Cells[3].Text;
                        string stbl = "user_management";
                        if (trcn.deleteTrcnRecord(rec_id, stbl) == true)
                        {
                            DisplaySuccess("Checked row(s) was deleted successfully");
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
                        DisplayError("No row was checked.");
                        loadGrid();
                    }
                }
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

    protected void openNewTrcn(object sender, EventArgs e)
    {
        try
        {
            if (Administrator () == "1")
            {
                trcn.clearPanel(pnlUsermanagement);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showTrcn(); });", true);
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
    private void check()
    {
        try
        {
            if (chkAccount.Checked)
            {
                account.Value = "1";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "0";
            }
            if (chkAccountHead.Checked)
            {
                account.Value = "0";
                account_head.Value = "1";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "0";
            }
            if (chkAdministrator.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "1";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "0";

            }
            if (chkCertification.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "1";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "0";

            }
            if (chkDirectorate.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "1";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "0";

            }
            if (recordmanager.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "1";
                licensed.Value = "0";
                state.Value = "0";
            }
            if (chkLicensed.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "1";
                state.Value = "0";
            }
            if (chkStateOffice.Checked)
            {
                account.Value = "0";
                account_head.Value = "0";
                administrator.Value = "0";
                certification.Value = "0";
                directorate.Value = "0";
                record_manager.Value = "0";
                licensed.Value = "0";
                state.Value = "1";
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void saveTrcn(object sender, EventArgs e)
    {
        try
        {
            if (Administrator() == "1")
            {
                check();

                if (trcn.savePanel(pnlUsermanagement, true) != true)
                {
                    DisplayError(trcn.ErrorMessage);
                    trcn.clearPanel(pnlUsermanagement);
                    loadGrid();
                }
                else
                {
                    DisplaySuccess("Record saved successfully");
                    trcn.clearPanel(pnlUsermanagement);
                    loadGrid();
                }
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
    protected void gvList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Administrator () == "1")
            {
                GridViewRow dgi = gvuserManagement.SelectedRow;
                rec_id.Value = dgi.Cells[trcn.getColumnIndexByName(gvuserManagement, "ID")].Text;
                trcn.getPanelByRecID(pnlUsermanagement);
                if (record_manager.Value == "1")
                {
                    recordmanager.Checked = true;
                }
                if (directorate.Value == "1")
                {
                    chkDirectorate.Checked = true;
                }
                if (administrator.Value == "1")
                {
                    chkAdministrator.Checked = true;
                }
                if (account.Value == "1")
                {
                    chkAccount.Checked = true;
                }
                if (account_head.Value == "1")
                {
                    chkAccountHead.Checked = true;
                }
                if (certification.Value == "1")
                {
                    chkCertification.Checked = true;
                }
                if (licensed.Value == "1")
                {
                    chkLicensed.Checked = true;
                }
                if (state.Value == "1")
                {
                    chkStateOffice.Checked = true;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showTrcn(); });", true);
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
    protected void gvList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Administrator  () == "1")
            {
                GridViewRow dgi = gvuserManagement.Rows[e.RowIndex];
                hdValue.Value = dgi.Cells[trcn.getColumnIndexByName(gvuserManagement, "ID")].Text;

                if (trcn.getUserRecID(hdValue.Value) == true)
                {
                    lblTransID.ForeColor = System.Drawing.Color.DarkRed;
                    lblTransID.Text = "Are you sure that you want to delete user With User Name:" + " " + trcn.sUsername;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showDelete(); });", true);
                }
                else
                {
                    DisplayError("something went wrong.");
                }
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
            string sWhereClause = string.Empty;
            trcn.getNonTemplateGrid(gvuserManagement, sWhereClause);
            gvuserManagement.UseAccessibleHeader = true;
            gvuserManagement.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            string sTbl = "user_management";
            if (trcn.deleteTrcnRecord(hdValue.Value, sTbl) == true)
            {
                DisplaySuccess("Record deleted successfully.");
                loadGrid();
            }
            else
            {
                DisplayError(trcn.ErrorMessage);
            }

        }
        catch (Exception ex)
        {

        }
    }
}