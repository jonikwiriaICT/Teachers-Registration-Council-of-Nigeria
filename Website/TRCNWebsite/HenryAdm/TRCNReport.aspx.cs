using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

public partial class HenryAdm_TRCNReport : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public string chartData = "";
    public string genderData = "";
    public string categoryChart = "";
    public string sChartResult = "";
    protected void ExportReport(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            switch (lnk.CommandArgument)
            {
                case "word":
                    WordExport();
                    break;
                case "excel":
                    ExcelExport();
                    break;

                case "pdf":
                    PDFExport();
                    break;
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void showDataListReport()
    {
        try
        {
            string sNameType = ddlQuery.SelectedValue;
            string sState = ddlStateID.SelectedValue;
            DataSet ds = trcn.allReportDataQuery(sNameType, sState);
            gvQuery.DataSource = ds;
            gvQuery.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvReportPaging(object sender, GridViewPageEventArgs e)
    {

        gvReports.PageIndex = e.NewPageIndex;
        mainReport();

    }
    private void DisplaySuccess(String sMessage)
    {
        try
        {
            (this.Master as TrcnMaster ).DisplayMessage(sMessage, TrcnMaster.MsgType.Success);
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
            if (!this.IsPostBack)
            {

                if (Administrator() == "1")
                {
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    report6.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;

                }
                else
                {
                    Response.Redirect("504");
                }


                ////trcn.SerialiseSchoolType ()
            }
        }
        catch (Exception)
        {

        }
    }

    private void showAllTotal()
    {
        try
        {
            string sTbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.allTotalCount(sTbl);
            gvTotal.DataSource = ds;
            gvTotal.DataBind();
        }
        catch (Exception ex)
        {

        }

    }
    private void allQueryStatus()
    {
        try
        {
            DataSet ds = trcn.allQueryStatus(ddlStateID.SelectedValue);
            gvQuery.DataSource = ds;
            gvQuery.DataBind();
        }
        catch (Exception ex)
        {

        }

    }

    private void mainReport()
    {
        try
        {
            string sTbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.getReport(sTbl);
            gvReports.DataSource = ds;
            gvReports.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public void sQueryByStatus(string sStatus, string sNo)
    {
        try
        {
            string sTbl = ddlStateID.SelectedValue;
            DataSet ds = trcn.QueryByStatus(sTbl, sStatus, sNo);
            gvQuery.DataSource = ds;
            gvQuery.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
    public void sQueryResult(string sStatus, string sNo)
    {
        try
        {
            string sTbl = "result";
            DataSet ds = trcn.QueryByStatus(sTbl, sStatus, sNo);
            gvQuery.DataSource = ds;
            gvQuery.DataBind();

        }
        catch (Exception ex)
        {

        }
    }

    private void allTeacherRecordByStatus(string sStatus, string sNo)
    {
        try
        {
            DataSet ds = trcn.allTotalCountByTeachers(ddlStateID.SelectedValue, sStatus, sNo);
            gvTotal.DataSource = ds;
            gvTotal.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    private void allResultTotal(string sStatus, string sNo)
    {
        try
        {
            DataSet ds = trcn.allTotalCountByTeachers("result", sStatus, sNo);
            gvTotal.DataSource = ds;
            gvTotal.DataBind();
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

    private void queryStatusByType(string type, string sNo)
    {
        try
        {
            DataSet ds = trcn.allQueryStatusByType(ddlStateID.SelectedValue, type, sNo);
            gvReports.DataSource = ds;
            gvReports.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    private void queryResultType(string type, string sNo)
    {
        try
        {
            DataSet ds = trcn.allQueryResult("result", type, sNo);
            gvReports.DataSource = ds;
            gvReports.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void RefreshPage(object sender, EventArgs e)
    {
        try
        {

            if (Session["administrator"].ToString() == "1")
            {
                if (ddlQuery.SelectedValue == "category")
                {
                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = true;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    showDataListReport();
                    showAllTotal();
                    mainReport();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "Category Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "sex")
                {
                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = true;
                    report6.Visible = false;
                    showDataListReport();
                    showAllTotal();
                    mainReport();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "Gender Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "school_type")
                {
                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = true;
                    report5.Visible = false;
                    report6.Visible = false;
                    showDataListReport();
                    showAllTotal();
                    mainReport();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "School Type Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "2")
                {

                    report.Visible = true;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    allQueryStatus();
                    showAllTotal();
                    mainReport();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Teachers Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();

                }
                if (ddlQuery.SelectedValue == "3")
                {



                    report.Visible = true;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("registration_status", "1");
                    allTeacherRecordByStatus("registration_status", "1");
                    queryStatusByType("registration_status", "1");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Verified Teachers Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "4")
                {



                    report.Visible = true;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("registration_status", "0");
                    allTeacherRecordByStatus("registration_status", "0");
                    queryStatusByType("registration_status", "0");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Not Verified Teachers Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "5")
                {



                    report.Visible = false;
                    report1.Visible = true;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("printing_status", "1");
                    allTeacherRecordByStatus("printing_status", "1");
                    queryStatusByType("printing_status", "1");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Printed Certificates Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "6")
                {



                    report.Visible = false;
                    report1.Visible = true;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("printing_status", "0");
                    allTeacherRecordByStatus("printing_status", "0");
                    queryStatusByType("printing_status", "0");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Not Printed Certificates Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "7")
                {



                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = true;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("licensed_status", "NOT");
                    allTeacherRecordByStatus("licensed_status", "NOT");
                    queryStatusByType("licensed_status", "NOT");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Not Applied Licensed Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "8")
                {



                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = true;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("licensed_status", "0");
                    allTeacherRecordByStatus("licensed_status", "0");
                    queryStatusByType("licensed_status", "0");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All  Applied Licensed Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "9")
                {



                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = true;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = false;
                    sQueryByStatus("licensed_status", "1");
                    allTeacherRecordByStatus("licensed_status", "1");
                    queryStatusByType("licensed_status", "1");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All  Printed Licensed Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }
                if (ddlQuery.SelectedValue == "10")
                {
                    report.Visible = false;
                    report1.Visible = false;
                    report2.Visible = false;
                    report3.Visible = false;
                    report4.Visible = false;
                    report5.Visible = false;
                    report6.Visible = true;
                    sQueryResult("state_id", ddlStateID.SelectedValue);
                    allResultTotal("state_id", ddlStateID.SelectedValue);
                    queryResultType("state_id", ddlStateID.SelectedValue);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    lblReportTitle.Text = ddlStateID.SelectedValue + "  " + "All Result Report";
                    lblDate.Text = "Date of Report:" + "  " + DateTime.Now.ToString();
                }

            }
            else
            {
                DisplayError(trcn.sAuth);
            }

        }
        catch (Exception ex)
        {

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private void WordExport()
    {
        try
        {
            gvReports.AllowPaging = false;
            image1.Src = this.GetUrl(image1.Src);
            image1.Width = 100;
            image1.Height = 100;
            image1.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=trcn.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            divContent.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    private void ExcelExport()
    {
        gvReports.AllowPaging = false;

        image1.Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=trcn.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        for (int i = 0; i < gvReports.Rows.Count; i++)
        {
            GridViewRow row = gvReports.Rows[i];
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
        }
        divContent.RenderControl(hw);
        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();


    }
    private void PDFExport()
    {
        gvReports.AllowPaging = false;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=trcn.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        divContent.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected string GetUrl(string imagepath)
    {
        string[] splits = Request.Url.AbsoluteUri.Split('/');
        if (splits.Length >= 2)
        {
            string url = splits[0] + "//";
            for (int i = 2; i < splits.Length - 1; i++)
            {
                url += splits[i];
                url += "/";
            }
            return url + imagepath;
        }
        return imagepath;
    }
}