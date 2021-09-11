using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StateOffice_StateOffice : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public static string DB = "LICENSED";
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
    protected void Page_Init(object sender, EventArgs e)
    {

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

            
            if (sender.Equals(lnkTeacherRegistrationStateOffice))
            {
                Response.Redirect("State-Office-Teacher-Registration");
            }


        }
        catch (Exception ex)
        {

        }
    }


}