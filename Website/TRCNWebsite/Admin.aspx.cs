using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public static string DB = "LICENSED";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                showAllRecords();
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
    private void showAllRecords()
    {
        try
        {
            
        }
        catch (Exception ex)
        {

        }
    }
    protected void reportClicked(object sender, EventArgs e)
    {
        try
        {
            if (sender.Equals(lnkReport))
            {
                Response.Redirect("TRCN-Report");
            }
            if (sender.Equals(lnkRegistration))
            {
                Response.Redirect("Teacher-Registration");
            }
           
           
            if (sender.Equals(lnkAuditTrailManagementSystem))
            {
                Response.Redirect("Audit-Trail");
            }
            if (sender.Equals(lnkUsermanagement))
            {
                Response.Redirect("User-Management");

            }
            if (sender.Equals(lnkPrintedCertificate))
            {
                Response.Redirect("Certificate-Printed");
            }
            if (sender.Equals(lnkNotPrintedCertificate))
            {
                Response.Redirect("Certificate-Not-Printed");
            }
            if (sender.Equals(lnkVerifiedTeachers))
            {
                Response.Redirect("Verified-Teachers");
            }
            if (sender.Equals(lnkNotVerifiedTeacher))
            {
                Response.Redirect("Not-Verified-Teachers");
            }
            if (sender.Equals(lnkDocAccountVerified))
            {
                Response.Redirect("Verified-Teachers");
            }
            if (sender.Equals(lnkDocAccountNotVerified))
            {
                Response.Redirect("Not-Verified-Teachers");
            }
            if (sender.Equals(lnkSearchResult))
            {
                Response.Redirect("Upload-Result");
            }
            if (sender.Equals(lnkRequestFormNotAttendedTo))
            {
                Response.Redirect("Not-Attended-Complain-Form");
            }
            if (sender.Equals(lnkAttendedRequestForm))
            {
                Response.Redirect("Attended-Complain-Form");
            }
            if(sender.Equals (lnkMCDPForm))
            {
                Response.Redirect("MCDP-Form");
            }
            

        }
        catch (Exception ex)
        {

        }
    }
}