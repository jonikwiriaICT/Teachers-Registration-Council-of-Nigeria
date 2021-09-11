using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Certificate_Certificate : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
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
        
    }
    protected void reportClicked(object sender, EventArgs e)
    {
        try
        {


            if (sender.Equals(lnkPrintedCertificate))
            {
                Response.Redirect("certPrintedRecords");
            }
            if (sender.Equals(lnkNotPrintedCertificate))
            {
                Response.Redirect("CertificateNotPrinted");
            }
           


        }
        catch (Exception ex)
        {

        }
    }
}