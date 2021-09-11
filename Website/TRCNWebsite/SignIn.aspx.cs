using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
               
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/en");
        }
    }
    public enum MsgType
    {
        Error = 0,
        Success = 1,
        Warning = 2
    }
    public void DisplayMessage(String sMessage, MsgType type)
    {
        try
        {
            if (sMessage.Trim() == "")
            {
                pnlAlert.Visible = false;
            }
            else
            {
                lblMsg.Text = sMessage;
                if (type == MsgType.Success)
                {
                    pnlAlert.CssClass = "alert alert-success alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-check-circle-o'></i>";
                }
                else if (type == MsgType.Warning)
                {
                    pnlAlert.CssClass = "alert alert-warning alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-exclamation-triangle'></i>";
                }
                else
                {
                    pnlAlert.CssClass = "alert alert-danger alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-exclamation-circle'></i>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "displayMsg", "alert('" + sMessage + "');", true);
                }
                pnlAlert.Visible = true;
                //ClientScript.RegisterStartupScript(this.GetType(), "displayMsg", "alert('" + sMessage + "');", true);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            pnlAlert.Visible = true;
        }
    }
    protected void navigateForgetPassword(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/forgetPassword_");
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
    protected void loginClick(object sender, EventArgs e)
    {
        try
        {

            if (username.Value == "")
            {
                DisplayMessage("Please enter your username", MsgType.Error);
            }
            else if (password.Value == "")
            {
                DisplayMessage("Please enter your Password", MsgType.Error);
            }
            else
            {
                if (trcn.getClientProfile(username.Value, password.Value))
                {
                    Session["audit_username"] = trcn.sUsername;
                    Session["password"] = password.Value;
                    Session["recordmanager"] = trcn.recordManager;
                    Session["directorate"] = trcn.directorate;
                    Session["administrator"] = trcn.administrtaor;
                    Session["account"] = trcn.account;
                    Session["accounthead"] = trcn.accounthead;
                    Session["certification"] = trcn.Scertification;
                    Session["licensed"] = trcn.Licensed;
                    Session["state"] = trcn.sState;
                    Session["states"] = trcn.States;
                    Response.Redirect("~/Dashboard");
                }
                else
                {
                    DisplayMessage(trcn.ErrorMessage, MsgType.Error);
                }
            }




        }
        catch (Exception ex)
        {

        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

}