using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class HenryAdm_UploadResult : System.Web.UI.Page
{
    SysAdminModel trcn = new SysAdminModel();
    protected void gvResultChanging(object sender, GridViewPageEventArgs e)
    {

        result.PageIndex = e.NewPageIndex;
        loadGrid();


    }

    //protected void gvResultChanged(object sender, EventArgs e)
    //{
    //    try
    //    {


    //        pnlRegister.ID = "ABIA";
    //        GridViewRow dgi = ABIA.SelectedRow;
    //        rec_id.Value = dgi.Cells[trcn.getColumnIndexByName(ABIA, "ID")].Text;
    //        Session["sRegNo"] = dgi.Cells[trcn.getColumnIndexByName(ABIA, "Registration_no")].Text;
    //        Session["sState"] = dgi.Cells[trcn.getColumnIndexByName(ABIA, "State")].Text;

    //        Response.Redirect("~/trcnRegister");
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void saveResultNew(object sender, EventArgs e)
    {
        try
        {
            if (trcn.savePanel(pnlResult, true) == true)
            {
                DisplaySuccess("Uploaded successfully.");
                loadGrid();
            }
            else
            {
                DisplayError(trcn.ErrorMessage);
            }

        }
        catch (Exception ex)
        {

        }
    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                if (Administrator() == "1")
                {
                    trcn.PopulateLists(ref ddlStateID, "GET_STATE");
                    trcn.PopulateLists(ref state_id, "GET_STATE");
                    trcn.PopulateLists(ref examType, "GET_EXAMTYPE");
                    trcn.PopulateLists(ref category, "GET_EXAMCATEGORY");
                    trcn.PopulateLists(ref exam_type, "GET_EXAMTYPE");
                    trcn.PopulateLists(ref category_, "GET_EXAMCATEGORY");
                    loadGrid();
                }
                else
                {
                    Response.Redirect("504");
                }
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
    protected void lbDeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string sTbl = "result";
            if (trcn.deleteTrcnRecord(hdValue.Value, sTbl) == true)
            {
                DisplaySuccess("Record deleted successfully.");
                loadGrid();
            }
            else
            {
                DisplayError(trcn.ErrorMessage);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void gvResultDelete(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow dgi = result.Rows[e.RowIndex];
            hdValue.Value = dgi.Cells[trcn.getColumnIndexByName(result, "ID")].Text;
            string stbl = "result";

            if (trcn.getTeacherName(stbl, hdValue.Value) == true)
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


    protected void NewResult_Clicked(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showTeacher(); });", true);
        }
        catch (Exception ex)
        {

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
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        string sTbl = "result";
        var products = trcn.getResultTemp(sTbl, ddlStateID.SelectedValue, examType.SelectedValue);
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("result");
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
            Response.AddHeader("content-disposition", "attachment;  filename=result.xlsx");
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    protected void query(object sender, EventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {

        }
    }

    protected void checkDelete(object sender, EventArgs e)
    {
        try
        {
            if (Administrator () == "1")
            {
                foreach (GridViewRow grow in result.Rows)
                {
                    if (grow.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkrow = (grow.Cells[0].FindControl("CHKANAMBRA") as CheckBox);
                        if (chkrow.Checked)
                        {
                            string iRecID = grow.Cells[2].Text;
                            if (trcn.deleteTrcnRecord(iRecID, "result") == true)
                            {
                                DisplaySuccess("Records deleted successfully.");
                                loadGrid();
                            }
                            else
                            {
                                DisplayError("Records not deleted .");
                                loadGrid();
                            }

                        }
                        else
                        {
                            DisplayError("Not checked.");
                            loadGrid();
                        }

                    }
                }
            }
            else
            {
                DisplayError(trcn.sAuth);
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void checkAll(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grow in result.Rows)
            {
                CheckBox chkVerified = (CheckBox)grow.FindControl("CHKANAMBRA");
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
    private void loadGrid()
    {
        try
        {
            string sWhereClause = "state_id='" + ddlStateID.SelectedValue + "' AND " + "exam_type='" + examType.SelectedValue + "'";
            trcn.getNonTemplateGrid(result, sWhereClause);
            result.UseAccessibleHeader = true;
            result.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {

        }
    }

    protected void Migration(object sender, EventArgs e)
    {
        try
        {

            string connectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ConnectionString;
            SqlConnection source = new SqlConnection(connectionString);
            // Create destination connection
            SqlConnection destination = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            source.Open();
            destination.Open();
            // Select data from Products table
            cmd = new SqlCommand("SELECT rec_id,  pqe_number, category FROM result ", source);
            // Execute reader
            SqlDataReader reader = cmd.ExecuteReader();
            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            // Set destination table name
            bulkData.DestinationTableName = "meme";
            // Write data
            bulkData.WriteToServer(reader);
            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();
            DisplaySuccess("Records migrated successfully.");
        }
        catch (Exception ex)
        {

        }
    }

    protected void downloadResultTemplate(object sender, EventArgs e)
    {
        try
        {
            Download_File("~/upload/resultTemplate.xlsx");
        }
        catch (Exception ex)
        {

        }
    }


    protected void InsertExcelRecords(object sender, EventArgs e)
    {

        try
        {


            string sTbl = ddlStateID.SelectedValue;
            if (FileUpload1.HasFile == false)
            {
                DisplayError("Please, select the file to upload.");
                return;
            }
            string sYearMonthDay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            string path = Server.MapPath("~/upload/" + sYearMonthDay + FileUpload1.FileName);
            FileUpload1.SaveAs(path);
            //  ExcelConn(_path);  
            OleDbConnection Econ;
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            Econ = new OleDbConnection(constr);
            string Query = string.Format("Select [Name],[PQE NUMBER],[STATUS],[Category],[ExamType],[State],[Year],[Institution Name] FROM [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];

            for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
            {
                //Exceldt.Rows[i]["Employee Name"] == DBNull.Value || Exceldt.Rows[i]["Email"] == DBNull.Value)
                //{
                //    Exceldt.Rows[i].Delete();
                //}

                Exceldt.Rows[i]["State"] = ddlStateID.SelectedValue;
                //Exceldt.Rows[i]["Category"] = category.SelectedValue;
                Exceldt.Rows[i]["ExamType"] = examType.SelectedValue;
            }
            Exceldt.AcceptChanges();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnectionString"].ToString(); //Connection Details    
            sqlConnection.Open();
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
            //assigning Destination table name      
            objbulk.DestinationTableName = "result";
            //Mapping Table column    
            objbulk.ColumnMappings.Add("Name", "names");
            objbulk.ColumnMappings.Add("PQE NUMBER", "pqe_number");
            objbulk.ColumnMappings.Add("STATUS", "statue");
            objbulk.ColumnMappings.Add("State", "state_id");
            objbulk.ColumnMappings.Add("Category", "category");
            objbulk.ColumnMappings.Add("ExamType", "exam_type");
            objbulk.ColumnMappings.Add("Year", "year");
            objbulk.ColumnMappings.Add("Institution Name", "institution_name");
            //inserting Datatable Records to DataBase   

            objbulk.WriteToServer(Exceldt);
            sqlConnection.Close();
            DisplaySuccess("Record migrated  successfully.");
            loadGrid();

        }
        catch (Exception ex)
        {
            DisplayError("Data has not been Imported due to :{0}" + " " + "Not Imported" + "  " + ex.ToString());


        }

    }
    protected void intelligentSearch(object sender, EventArgs e)
    {
        try
        {
            if (Search.Value == "")
            {
                DisplayError("Please enter a search value.");
            }
            else
            {
                DataSet ds = trcn.SearchAllResult(Search.Value);
                result.DataSource = ds;
                result.DataBind();
                result.UseAccessibleHeader = true;
                result.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void Download_File(string FilePath)
    {
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
        Response.WriteFile(FilePath);
        Response.End();
    }
}