using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;
using MessagingToolkit.QRCode.Codec;
using QRCoder;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing.Imaging;
using System.Drawing;
public partial class StateOffice_UploadedPictureAndSignatureLogLicensed : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    public static string sPrintedRecord = "1";
    public static string sRegistrationStatus = "1";
    public static string sRecValue = "";
    public static int iRecID;
    public static int iChangeMode = 0;
    public static string sLicensedStatus = "1";
    public static string sPicNo = "1";
    public static string DB = "LICENSED";
    QRCodeEncoder encoder = new QRCodeEncoder();
    public string Administrator()
    {
        try
        {
            string username = ((TrcnMaster)this.Master).Administrator;
            return username;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    private void getState()
    {
        try
        {
            if (Administrator () == "1")
            {
                trcn.PopulateLists(ref ddlStateID, "GET_STATE");
            }
            else
            {
                ddlStateID.Items.Add(Session["state"].ToString());
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIACOMMAND(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("upload"))
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString().Trim());

                GridViewRow row = ABIA.Rows[rowIndex];
                string ID = row.Cells[5].Text;
                FileUpload fileupload = (FileUpload)ABIA.Rows[rowIndex].FindControl("fileSignature");
                HiddenField sSignature = (HiddenField)ABIA.Rows[rowIndex].FindControl("signature");
                HiddenField sPicture = (HiddenField)ABIA.Rows[rowIndex].FindControl("pictures");
                string stbl = DB + ddlStateID.SelectedValue;
                string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();

                if (fileupload.HasFiles)
                {
                    fileupload.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + fileupload.FileName);
                    string URL3 = "~/upload/" + sYearMonthDay + fileupload.FileName;
                    sSignature.Value = URL3;
                }
                FileUpload fileupload2 = (FileUpload)ABIA.Rows[rowIndex].FindControl("filePicture");
                if (fileupload2.HasFiles)
                {
                    fileupload2.SaveAs(HttpContext.Current.Server.MapPath("~/upload/") + sYearMonthDay + fileupload2.FileName);
                    string URL4 = "~/upload/" + sYearMonthDay + fileupload2.FileName;
                    sPicture.Value = URL4;
                }
                string pic_no = "1";
                if (trcn.updateTeacherRecordSignatureandPicture(ID, stbl, sSignature.Value, sPicture.Value, pic_no) == true)
                {
                    DisplaySuccess("Record Uploaded successfully.");
                    loadGrid();
                }
                else
                {
                    DisplayError("Error Updating Record.");
                    loadGrid();
                }

            }

        }
        catch (Exception ex)
        {
            DisplayError(ex.ToString());
        }
    }
    protected void intelligentQuery(object sender, EventArgs e)
    {
        try
        {
            string stbl = DB + ddlStateID.SelectedValue;
            DataSet ds = trcn.ShowStateOfficeIntelligence(stbl, Search.Value, sRegistrationStatus, sPrintedRecord, sLicensedStatus, sPicNo);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex_)
        {

        }
    }
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = DB + ddlStateID.SelectedValue;
        var products = trcn.StateOfficeTemplate(sTbl, sRegistrationStatus, sPrintedRecord, sLicensedStatus, sPicNo);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("teacher");
        var totalCols = products.Columns.Count;
        var totalRows = products.Rows.Count;
        for (var col = 1; col <= totalCols; col++)
        {
            workSheet.Cells[1, col].Value = products.Columns[col - 1].ColumnName;
        }
        for (var row = 1; row <= totalRows; row++)
        {
            for (var col = 0; col < totalCols; col++)
            {
                workSheet.Cells[row + 1, col + 1].Value = products.Rows[row - 1][col];
            }
        }
        using (var memoryStream = new MemoryStream())
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Teacher.xlsx");
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void ExportToExcel()
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=verifiedLog.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divContent.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ExportExcel(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            lblCheck.Text = "Check";
            int i = ABIA.PageIndex + 1;
            if (i <= ABIA.PageCount)
            {
                ABIA.PageIndex = i;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }

            if (ABIA.PageCount - 1 == ABIA.PageIndex)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            lblCheck.Text = "Check";
            int i = ABIA.PageCount;
            if (ABIA.PageIndex > 0)
            {

                ABIA.PageIndex = ABIA.PageIndex - 1;
                btnLast.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }

            if (ABIA.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
            if (ABIA.PageCount - 1 == ABIA.PageIndex + 1)
            {
                btnNext.Enabled = true;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
            if (ABIA.PageIndex == 0)
            {
                btnPrevious.Enabled = false;
                if (iChangeMode == 0)
                {
                    loadGrid();
                }
                if (iChangeMode == 1)
                {
                    searchforTeacherID();
                }
                if (iChangeMode == 2)
                {
                    changeLoad();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnlast_Click(object sender, EventArgs e)
    {
        try
        {
            lblCheck.Text = "Check";
            ABIA.PageIndex = ABIA.PageCount;
            btnLast.Enabled = false;
            btnFirst.Enabled = true;
            if (iChangeMode == 0)
            {
                loadGrid();
            }
            if (iChangeMode == 1)
            {
                searchforTeacherID();
            }
            if (iChangeMode == 2)
            {
                changeLoad();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {
        try
        {
            lblCheck.Text = "Check";
            ABIA.PageIndex = 0;
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            if (iChangeMode == 0)
            {
                loadGrid();
            }
            if (iChangeMode == 1)
            {
                searchforTeacherID();
            }
            if (iChangeMode == 2)
            {
                changeLoad();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void verifyByRange(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chk = (CheckBox)grow.FindControl("CHKABIA");
                chk.Checked = true;


            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ABIACHANGING(object sender, GridViewPageEventArgs e)
    {

        ABIA.PageIndex = e.NewPageIndex;
        if (iChangeMode == 0)
        {
            loadGrid();
        }
        if (iChangeMode == 1)
        {
            searchforTeacherID();
        }
        if (iChangeMode == 2)
        {
            changeLoad();
        }

    }
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
    protected void printByCheck(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { printRecord(); });", true);

        }
        catch (Exception ex)
        {

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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session["licensed"].ToString() == "1" || Session["administrator"].ToString() == "1")
            //{
            if (!this.IsPostBack)
            {
                Session["audit_username"] = "trcn";
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                lblCheck.Text = "Check";
                getState();
                trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
                ddlLga.SelectedValue = "ALL";
                loadGrid();
            }
            lblCheck.Text = "Check";
            //}
            //else
            //{

            //}
        }
        catch (Exception ex)
        {

        }
    }

    protected void checkAll(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("CHKABIA");
                if (chkVerified.Checked == false)
                {
                    chkVerified.Checked = true;
                    lblCheck.Text = "Uncheck";
                }
                else
                {
                    chkVerified.Checked = false;
                    lblCheck.Text = "Check";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void chkVerified(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow grow in ABIA.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("CHKABIA");
                if (chkVerified.Checked)
                {
                    string stbl = ddlStateID.SelectedValue;
                    string recID = grow.Cells[5].Text;
                    FileUpload fileupload = (FileUpload)grow.FindControl("fileSignature");
                    HiddenField sSignature = (HiddenField)grow.FindControl("signature");
                    HiddenField sPicture = (HiddenField)grow.FindControl("pictures");
                    if (fileupload.HasFiles)
                    {
                        fileupload.SaveAs(HttpContext.Current.Server.MapPath("assets/") + fileupload.FileName);
                        string URL3 = "assets/" + fileupload.FileName;
                        sSignature.Value = URL3;
                    }
                    FileUpload fileupload2 = (FileUpload)grow.FindControl("filePicture");
                    if (fileupload2.HasFiles)
                    {
                        fileupload2.SaveAs(HttpContext.Current.Server.MapPath("assets/") + fileupload2.FileName);
                        string URL4 = "assets/" + fileupload2.FileName;
                        sPicture.Value = URL4;
                    }
                    string pic_no = "1";
                    if (trcn.updateTeacherRecordSignatureandPicture(recID, stbl, sSignature.Value, sPicture.Value, pic_no) == true)
                    {
                        DisplaySuccess("Record Uploaded successfully.");
                        loadGrid();
                    }
                    else
                    {
                        DisplayError("Error Updating Record.");
                        loadGrid();
                    }

                }
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void ABIACHANGED(object sender, EventArgs e)
    {
        try
        {
            //string stbl = ddlStateID.SelectedValue;
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[11] { new DataColumn("adminSignature"), new DataColumn("Date"), new DataColumn("Expiration_date"), new DataColumn("formNo"), new DataColumn("PQENumber"), new DataColumn("category"), new DataColumn("Names"), new DataColumn("registration_nos"), new DataColumn("TeacherPhoto"), new DataColumn("signature"), new DataColumn("identity") });
            //GridViewRow dgi = ABIA.SelectedRow;
            //iRecID = Convert.ToInt32(dgi.Cells[trcn.getColumnIndexByName(ABIA, "ID")].Text);
            //string sRegNo = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Registration_no")].Text;
            //string sSurname = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Surname")].Text;
            //string sFirstName = dgi.Cells[trcn.getColumnIndexByName(ABIA, "First Name")].Text;
            //string sDate = DateTime.Now.ToString("MMMM dd,  yyyy");
            //string sLastName = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Middle Name")].Text;
            //string sName1 = sSurname.Substring(0, 1).ToUpper() + sSurname.Substring(1).ToLower();
            //string sName2 = sFirstName.Substring(0, 1).ToUpper() + sFirstName.Substring(1).ToLower();
            //string sName3 = sLastName.Substring(0, 1).ToUpper() + sLastName.Substring(1).ToLower();
            //string sTeacherName = sName1 + "  " + sName2 + "   " + sName3;
            //string sPqeNumber = dgi.Cells[trcn.getColumnIndexByName(ABIA, "PQE Number")].Text;
            //string sLicensedNo = dgi.Cells[trcn.getColumnIndexByName(ABIA, "GUIDNo")].Text;
            //string sCategory = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Category")].Text;
            //string sLicensedExpiringDate = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Licensed Expiring Date")].Text;
            //string sPhoto = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Picture")].Text;
            //string sTeacherSignature = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Teacher Signature")].Text;
            //string sAdminSignature = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Administrator Signature")].Text;
            //Bitmap img = encoder.Encode(sTeacherName + ", " + sRegNo + "," + sPqeNumber + "," + sLicensedNo);
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //    byte[] byteImage = ms.ToArray();
            //    string Identity = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            //    if (trcn.PrintLicensed(iRecID, stbl) == true)
            //    {
            //    }
            //    dt.Rows.Add(sAdminSignature, sDate, sLicensedExpiringDate, sLicensedNo, sPqeNumber, sCategory, sTeacherName, sRegNo, sPhoto, sTeacherSignature, Identity);
            //}

            //dtPrint.DataSource = dt;
            //dtPrint.DataBind();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { modDelete(); });", true);
            //DisplaySuccess("Record Printed successfully.");
            //loadGrid();
        }
        catch (Exception ex)
        {

        }
    }


    protected void ABIADELETE(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = ABIA.Rows[e.RowIndex];
            sRecValue = dgi.Cells[trcn.getColumnIndexByName(ABIA, "ID")].Text;
            string stbl = DB + ddlStateID.SelectedValue;
            if (trcn.getTeacherID(stbl, sRecValue) == true)
            {
                lblTransID.ForeColor = System.Drawing.Color.DarkRed;
                lblTransID.Text = "Are you sure that you want to delete user With User Name:" + " " + trcn.sTeacherName;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showDelete(); });", true);
            }
            else
            {
                DisplayError("something went wrong.");
            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void searchTeacher(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 1;
            searchforTeacherID();
        }
        catch (Exception ex)
        {

        }
    }

    private void searchforTeacherID()
    {
        try
        {
            string sRegNo = teacherID.Text;
            string stbl = DB + ddlStateID.SelectedValue;
            DataSet ds = trcn.showStateOfficeTeacherID(stbl, sRegistrationStatus, sPrintedRecord, sRegNo, sLicensedStatus, sPicNo);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }


    private void queryLgaCommunity()
    {
        try
        {
            string stbl = DB + ddlStateID.SelectedValue;
            DataSet ds = trcn.showStateOfficeState(stbl, sRegistrationStatus, sPrintedRecord, sLicensedStatus, sPicNo);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }
    protected void viewState(object sender, EventArgs e)
    {
        try
        {
            iChangeMode = 0;
            trcn.PopulateLists(ref ddlLga, "GET_LGA_BY_STATE", ddlStateID.SelectedValue);
            ddlLga.SelectedValue = "ALL";
            queryLgaCommunity();

        }
        catch (Exception ex)
        {
            DisplayError(ex.ToString());
        }
    }

    protected void viewLga(object sender, EventArgs e)
    {
        try
        {
            if (Session["licensed"].ToString() == "1" || Session["administrator"].ToString() == "1")
            {
                iChangeMode = 0;
                queryLgaCommunity();
            }
            else
            {
                DisplayError(trcn.sNotAuthorizedUsed);
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void loadGrid()
    {
        try
        {
            queryLgaCommunity();
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

    protected void lbDeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string sTbl = ddlStateID.SelectedValue;
            if (trcn.deleteTrcnRecord(sRecValue, sTbl) == true)
            {
                DisplaySuccess("Record deleted successfully.");
                loadGrid();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
    private void changeLoad()
    {
        try
        {
            string tbl = DB + ddlStateID.SelectedValue;
            string one = RangeFrom.Text;
            string two = RangeTo.Text;
            DataSet ds = trcn.showCertificateRange(tbl, sRegistrationStatus, one, two, sPrintedRecord);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }



    protected void viewByRange(object sender, EventArgs e)
    {
        try
        {
            string tbl = DB + ddlStateID.SelectedValue;
            string one = RangeFrom.Text;
            string two = RangeTo.Text;
            DataSet ds = trcn.showStateOfficeRange(tbl, sRegistrationStatus, one, two, sPrintedRecord, sLicensedStatus, sPicNo);
            ABIA.DataSource = ds;
            ABIA.DataBind();
            ABIA.UseAccessibleHeader = true;
            ABIA.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex) { }
    }

}