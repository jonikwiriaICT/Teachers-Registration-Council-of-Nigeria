using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public string chartData = "";
    public string genderData = "";
    public string categoryChart = "";
    public string sChartResult = "";
    public string sExamType = "";
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
                if (Administrator () == "1")
                {
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
                    trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
                    trcn.serializeGenderType(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
                    trcn.serializeCategory(ddlStateID.SelectedValue);
                    trcn.serialiseResultByExamType(ddlStateID.SelectedValue);
                    trcn.serialiseResultByStatus(ddlStateID.SelectedValue);

                    chartData = trcn.chartData;
                    genderData = trcn.chartGender;
                    categoryChart = trcn.chartCategory;
                    sChartResult = trcn.sChartResult;
                    sExamType = trcn.sExamType;

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

    protected void RefreshPage(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { getChart(); });", true);
            trcn.SerialiseSchoolType(ddlStateID.SelectedValue);
            trcn.serializeGenderType(ddlStateID.SelectedValue);
            trcn.serialiseResultByStatus(ddlStateID.SelectedValue);
            trcn.serialiseResultByExamType(ddlStateID.SelectedValue);
            trcn.serializeCategory(ddlStateID.SelectedValue);
            chartData = trcn.chartData;
            genderData = trcn.chartGender;
            categoryChart = trcn.chartCategory;
            sChartResult = trcn.sChartResult;
            sExamType = trcn.sExamType;

        }
        catch (Exception ex)
        {

        }
    }
}