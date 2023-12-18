using BusinessLayer.Transaction.PrEmployeePayroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessLayer.Master.CodesMaster;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class Report : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        PrEmployeePayrollManager objPayrollManager = new PrEmployeePayrollManager();
        CodeMasterManager objCodeMasterMgr = new CodeMasterManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                ddlMonth.SelectedValue = currentMonth.ToString();
                ddlyear.SelectedValue = currentYear.ToString();
                string yyyymm = ddlyear.SelectedValue + ddlMonth.SelectedValue;
                dt = objPayrollManager.FetchEmpNo(yyyymm);
                ddlEmpNo.DataSource = dt;
                ddlEmpNo.DataTextField = "ATT_EMP_NO";
                ddlEmpNo.DataValueField = "ATT_EMP_NO";
                ddlEmpNo.DataBind();

                dt = objCodeMasterMgr.FetchYear();
                ddlSortYear.DataSource = dt;
                ddlSortYear.DataTextField = "CM_CODE";
                ddlSortYear.DataValueField = "CM_VALUE";
                ddlSortYear.DataBind();
            }

        }

        protected void DisplayEmpNo(string yyyymm)
        {
            dt = objPayrollManager.FetchEmpNo(yyyymm);
            ddlEmpNo.DataSource = dt;
            ddlEmpNo.DataTextField = "ATT_EMP_NO";
            ddlEmpNo.DataValueField = "ATT_EMP_NO";
            ddlEmpNo.DataBind();
        }
        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PayrollProcessing.aspx");
        }

        protected void btnReport_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string empNo = ddlEmpNo.SelectedValue;
                string year = ddlyear.SelectedValue;
                string month = ddlMonth.SelectedValue;
                string yyyymm = year + month;
                if (objPayrollManager.IsPayrollProcessed(yyyymm))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), Guid.NewGuid().ToString(), "window.open('CrystalReport.aspx?emp=" + empNo + "&&yyyymm=" + yyyymm + "'); ", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Sorry!','Salary Not Processed for this Month!!!');", true);
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Some Error Occured!!!');", true);
            }

        }

        protected void ddlMonth_TextChanged(object sender, EventArgs e)
        {
            string yyyymm = ddlyear.SelectedValue + ddlMonth.SelectedValue;
            DisplayEmpNo(yyyymm);
        }

        protected void btnExcel_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objPayrollManager.ExcelDwd();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=PayrollDetailsList.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                if (dt != null)
                {
                    GridView objGridView = new GridView();
                    objGridView.GridLines = GridLines.Both;
                    objGridView.AutoGenerateColumns = true;
                    objGridView.DataSource = dt;
                    objGridView.DataBind();
                    objGridView.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void ddlSort_TextChanged(object sender, EventArgs e)
        {
            string choice = ddlSort.SelectedValue;
            if(choice=="All")
            {
                lblMonthSort.Visible = false;
                ddlMonthSort.Visible = false;
                lblsortYear.Visible = false;
                ddlSortYear.Visible = false;
                btnExcelAll.Visible = true;
                btnExcelMonth.Visible = false;
                btnExcelYear.Visible = false;
            }
            else if(choice=="Month")
            {
                lblMonthSort.Visible = true;
                ddlMonthSort.Visible = true;
                lblsortYear.Visible = true;
                ddlSortYear.Visible = true;
                btnExcelMonth.Visible = true;
                btnExcelAll.Visible = false;
                btnExcelYear.Visible = false;
            }
            else if(choice=="Year")
            {
                lblMonthSort.Visible = false;
                ddlMonthSort.Visible = false;
                lblsortYear.Visible = true;
                ddlSortYear.Visible = true;
                btnExcelYear.Visible = true;
                btnExcelMonth.Visible = false;
                btnExcelAll.Visible = false;
            }
        }

        protected void btnExcelMonth_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string month = ddlMonthSort.SelectedValue;
                string year = ddlSortYear.SelectedValue;
                string yyyymm = year + month;
                if (objPayrollManager.IsPayrollProcessed(yyyymm))
                {                  
                    DataTable dt = new DataTable();
                    dt = objPayrollManager.ExcelDwdByMonth(yyyymm);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=PayrollDetailsByMonth.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    if (dt != null)
                    {
                        GridView objGridView = new GridView();
                        objGridView.GridLines = GridLines.Both;
                        objGridView.AutoGenerateColumns = true;
                        objGridView.DataSource = dt;
                        objGridView.DataBind();
                        objGridView.RenderControl(hw);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Sorry!','Salary Not Processed for this Month!!!');", true);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void btnExcelYear_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string year = ddlSortYear.SelectedValue;
                if (objPayrollManager.IsPayrollProcessedByYear(year))
                {
                    DataTable dt = new DataTable();
                    dt = objPayrollManager.ExcelDwdByYear(year);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=PayrollDetailsByYear.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    if (dt != null)
                    {
                        GridView objGridView = new GridView();
                        objGridView.GridLines = GridLines.Both;
                        objGridView.AutoGenerateColumns = true;
                        objGridView.DataSource = dt;
                        objGridView.DataBind();
                        objGridView.RenderControl(hw);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Sorry!','Salary Not Processed in this Year!!!');", true);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}


