using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

public partial class HenryAdm_AuditTrail : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = "trcn_AuditTrail";
        var products = trcn.getGenerealTemplate(sTbl);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("AuditTrail");
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
            Response.AddHeader("content-disposition", "attachment;  filename=AuditTrail.xlsx");
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

        gvAudit.PageIndex = e.NewPageIndex;

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
            if (Administrator() == "1")
            {
                if (!this.IsPostBack)
                {
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
    private void loadGrid()
    {
        try
        {
            string sWhereClause = string.Empty;
            trcn.getNonTemplateGrid(gvAudit, sWhereClause);
            gvAudit.UseAccessibleHeader = true;
            gvAudit.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
}