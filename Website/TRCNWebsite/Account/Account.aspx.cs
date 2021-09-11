using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Account : System.Web.UI.Page
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
    protected void Page_Init(object sender, EventArgs e)
    {

    }
    protected void reportClicked(object sender, EventArgs e)
    {
        try
        {


            if (sender.Equals(lnkVerifiedTeachers))
            {
                Response.Redirect("Account-Verified-Teachers");
            }
            if (sender.Equals(lnkNotVerifiedTeacher))
            {
                Response.Redirect("Account-Not-Verified-Teachers");
            }
           

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
}