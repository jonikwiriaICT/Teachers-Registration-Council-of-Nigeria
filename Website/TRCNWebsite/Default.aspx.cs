using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SysAdminModel objAdm = new SysAdminModel();
    public string ChatWelcome = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!this.IsPostBack)
            {
                ChatWelcome = "This is Henry Bot built to help you to manually use this Certificate Application";
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {

    }
    protected void NavigateClicked(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Signin");
        }
        catch(Exception ex)
        {

        }
    }
}