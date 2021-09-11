using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SD = System.Drawing;

public partial class TrcnMaster : System.Web.UI.MasterPage
{
    SysAdminModel trcn = new SysAdminModel();
    public string username = "";
    public string UserImage = "assets/images/avatar.jpg";
    protected string UploadFolderPath = "~/assets/";
    ConnClass ConnC = new ConnClass();

    protected void changePassword_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (txtOldPassword.Text == txtPassword.Text)
            {
                if (trcn.changePassword(txtemailAddress.Text, txtOldPassword.Text) == false)
                {
                    DisplayMessage(trcn.ErrorMessage, MsgType.Error);
                    return;
                }
                DisplayMessage("Password changed successfully.", MsgType.Success);
            }
            else
            {
                DisplayMessage("New Password does not match confirm password.", 0);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void Signout_Clicked(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("index");
        }
        catch (Exception ex)
        {

        }
    }
    private void allVisible()
    {
        try
        {
            adminDashboard.Visible = false;
            documentation.Visible = false;
            account.Visible = false;
            certificate.Visible = false;
            sysAdministrator.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }

    public string Administrator
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["administrator"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["administrator"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string RecordManager
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["recordmanager"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["recordmanager"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string Directorate
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["directorate"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["directorate"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string Account
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["account"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["account"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string AccountHead
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["accounthead"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["accounthead"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string Certification
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["certification"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["certification"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string States
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["states"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["states"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string UserName
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["audit_username"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["audit_username"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    private void checkUser()
    {
        try
        {
            if (Administrator == "1")
            {
                adminDashboard.Visible = true;
                documentation.Visible = true;
                account.Visible = true;
                certificate.Visible = true;
                sysAdministrator.Visible = true;
                StateOffice.Visible = true;
            }
            if (RecordManager == "1" || Directorate== "1")
            {
                adminDashboard.Visible = true;
                documentation.Visible = true;
                account.Visible = false;
                certificate.Visible = false;
                sysAdministrator.Visible = false;
                StateOffice.Visible = false;
            }
            if (Account == "1" || AccountHead == "1")
            {
                adminDashboard.Visible = true;
                documentation.Visible = false;
                account.Visible = true;
                certificate.Visible = false;
                sysAdministrator.Visible = false;
                StateOffice.Visible = false;
            }
            if (Certification == "1")
            {
                adminDashboard.Visible = true;
                documentation.Visible = false;
                account.Visible = false;
                certificate.Visible = true;
                sysAdministrator.Visible = false;
                StateOffice.Visible = false;
            }
            if (States == "1")
            {
                adminDashboard.Visible = true;
                documentation.Visible = false;
                account.Visible = false;
                certificate.Visible = false;
                sysAdministrator.Visible = false;
                StateOffice.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void showLicensed()
    {
        try
        {
            //string username = Session["audit_username"].ToString();
            //string sPassword = Session["password"].ToString();
            //webapiTrcn.WebServiceSoapClient client = new webapiTrcn.WebServiceSoapClient();
            //webapiTrcn.SecuredTokenWebservice secureToken = new webapiTrcn.SecuredTokenWebservice
            //{
            //    sUserName = username,
            //    Password = sPassword
            //};
            //string sToken = client.AuthenticationUser(secureToken);
            //if (sToken == "Invalid Username or Password")
            //{
            //    DisplayMessage(sToken, 0);
            //}

            //else
            //{
            //    client.updateToken(username, sToken);
            //    if (trcn.getWebUrl() == true)
            //    {
            //        string sUrl = trcn.sUrl;
            //        Response.Redirect(sUrl + sToken);
            //    }

            //}




        }
        catch (Exception ex)
        {
            DisplayMessage(ex.ToString(), 0);
        }
    }
    protected void redirectToLicensed(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            DisplayMessage(ex.ToString(), 0);
        }
    }
    protected void signOut(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/en");
        }
        catch (Exception ex)
        {

        }
    }
    protected void lbChangePassword(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("changePassword");
        }
        catch (Exception ex)
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {

                if (UserName != null)
                {

                    username = UserName;
                    GetUserImage(UserName);
                    checkUser();


                }
                else
                {
                    Response.Redirect("en");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/en");
        }
    }
    public void GetUserImage(string Username)
    {
        if (Username != null)
        {
            string query = "select pic_filename from user_management where username='" + Username + "'";

            string ImageName = ConnC.GetColumnVal(query, "pic_filename");
            if (ImageName != "")
                UserImage = "images/DP/" + ImageName;
        }


    }
    protected void btnChangePicModel_Click(object sender, EventArgs e)
    {

        try
        {
            string serverPath = HttpContext.Current.Server.MapPath("~/");
            //path = serverPath + path;
            if (FileUpload1.HasFile)
            {
                string FileWithPat = serverPath + @"images/DP/" + UserName + FileUpload1.FileName;

                FileUpload1.SaveAs(FileWithPat);
                SD.Image img = SD.Image.FromFile(FileWithPat);
                SD.Image img1 = RezizeImage(img, 151, 150);
                img1.Save(FileWithPat);
                if (File.Exists(FileWithPat))
                {
                    FileInfo fi = new FileInfo(FileWithPat);
                    string ImageName = fi.Name;
                    string query = "update user_management set pic_filename='" + ImageName + "' where username='" + UserName + "'";
                    if (ConnC.ExecuteQuery(query))
                        UserImage = "images/DP/" + ImageName;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    #region Resize Image With Best Qaulity

    private SD.Image RezizeImage(SD.Image img, int maxWidth, int maxHeight)
    {
        if (img.Height < maxHeight && img.Width < maxWidth) return img;
        using (img)
        {
            Double xRatio = (double)img.Width / maxWidth;
            Double yRatio = (double)img.Height / maxHeight;
            Double ratio = Math.Max(xRatio, yRatio);
            int nnx = (int)Math.Floor(img.Width / ratio);
            int nny = (int)Math.Floor(img.Height / ratio);
            Bitmap cpy = new Bitmap(nnx, nny, SD.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(cpy))
            {
                gr.Clear(Color.Transparent);

                // This is said to give best quality when resizing images
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                gr.DrawImage(img,
                    new Rectangle(0, 0, nnx, nny),
                    new Rectangle(0, 0, img.Width, img.Height),
                    GraphicsUnit.Pixel);
            }
            return cpy;
        }

    }

    private MemoryStream BytearrayToStream(byte[] arr)
    {
        return new MemoryStream(arr, 0, arr.Length);
    }
    #endregion
    protected void Page_Init(object sender, EventArgs e)
    {
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
                    pnlAlert.CssClass = "alert alert-success";
                    spIcon.InnerHtml = "<i class='fa fa-check-circle-o'></i>";
                }
                else if (type == MsgType.Warning)
                {
                    pnlAlert.CssClass = "alert alert-warning";
                    spIcon.InnerHtml = "<i class='fa fa-exclamation-triangle'></i>";
                }
                else
                {
                    pnlAlert.CssClass = "alert alert-danger";
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
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
}
