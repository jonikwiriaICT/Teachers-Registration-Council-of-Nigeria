using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Documentation_Documentation : System.Web.UI.Page
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
    protected void reportClicked(object sender, EventArgs e)
    {
        try
        {

            if (sender.Equals(lnkRegistration))
            {
                Response.Redirect("Teacher-Reg");
            }
            if (sender.Equals(lnkDocAccountVerified))
            {
                Response.Redirect("Doc-Account-Verified");
            }
            if (sender.Equals(lnkDocAccountNotVerified))
            {
                Response.Redirect("Doc-Account-Not-Verified");
            }
           

        }
        catch (Exception ex)
        {

        }
    }

}