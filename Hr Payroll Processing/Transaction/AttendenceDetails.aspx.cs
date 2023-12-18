using BusinessLayer.Master.ErrorCodeMaster;
using BusinessLayer.Transaction.PrEmployeeAttendence;
using BusinessLayer.Transaction.PrEmployeePayroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class Attendence : System.Web.UI.Page
    {
        PrEmployeeAttendenceEntity objAttendencEntity = new PrEmployeeAttendenceEntity();
        PrEmployeeAttendenceManager objAttendencManager = new PrEmployeeAttendenceManager();
        PrEmployeePayrollManager objPayrollManager = new PrEmployeePayrollManager();
        ErrorCodeMasterManager objErrMananger = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString(); //backButton
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["yyyymm"])))
                {

                    string yyyymm = Convert.ToString(Request.QueryString["yyyymm"]);
                   
                    ddlMonth.SelectedValue = Convert.ToString(Request.QueryString["month"]);
                    ddlyear.SelectedValue = Convert.ToString(Request.QueryString["year"]);
                    int days = DateTime.DaysInMonth(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
                    DisplayEmpNo(yyyymm, days);
                    //Disabling Process Attendence button if attendence already procerssed
                    if (objPayrollManager.IsPayrollProcessed(yyyymm))
                    {
                        btnProcessAttendence.Enabled = false;
                    }
                    else
                    {
                        btnProcessAttendence.Enabled = true;
                    }
                }
                else
                {
                    int currentMonth = DateTime.Now.Month;
                    int currentYear = DateTime.Now.Year;
                    ddlMonth.SelectedValue = currentMonth.ToString();
                    ddlyear.SelectedValue = currentYear.ToString();
                    string yyyymm = ddlMonth.SelectedValue + ddlyear.SelectedValue;
                    //Disabling Process Attendence button if attendence already procerssed
                    if (objPayrollManager.IsPayrollProcessed(yyyymm))
                    {
                        btnProcessAttendence.Visible = false;

                    }
                    else
                    {
                        btnProcessAttendence.Visible = true;
                    }
                    
                    DisplayEmpNo();
                }
            }
            else
            {
                DisplayEmpNo();
            }

        }

        //Gridview for displaying attendence
        protected void DisplayEmpNo()
        {
            try
            {
                string month = ddlMonth.SelectedValue;
                string year = ddlyear.SelectedValue;
                string attyyyymm = year + month;
                int year1 = Convert.ToInt32(ddlyear.SelectedValue);
                int months = Convert.ToInt32(ddlMonth.SelectedValue);
                int days = DateTime.DaysInMonth(year1, months);
                   


               
                var data = objAttendencManager.FetchGridDetails(attyyyymm,days);
                if (data != null && data.Rows.Count > 0)
                {
                    gvAttendence.DataSource = data;
                    gvAttendence.DataBind();
                }
                else
                {
                    gvAttendence.EmptyDataText = "No Employees";
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Salary Already Processed in this Month!!!');", true);
            }
        }

        protected void DisplayEmpNo(string yyyymm,int days)
        {
            try
            {
                
                gvAttendence.DataSource = objAttendencManager.FetchGridDetails(yyyymm,days);
                gvAttendence.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
                //ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Salary Already Processed in this Month!!!');", true);

            }
        }

        protected void DisplayAttendenceWRTDate()
        {
            try
            {
                string month = ddlMonth.SelectedValue;
                string year = ddlyear.SelectedValue;
                string attyyyymm = year + month;
                gvAttendence.DataSource = objAttendencManager.FetchAttendencWRTDate(attyyyymm);
                gvAttendence.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string ehEmpNo = btn.CommandArgument;
                string month = ddlMonth.SelectedValue;
                string year = ddlyear.SelectedValue;               
                objAttendencEntity.attEmpNo = ehEmpNo;
                objAttendencEntity.attYyyyMm = year + month;
                string yyyymm = objAttendencEntity.attYyyyMm;              
                if (objPayrollManager.IsPayrollProcessed(yyyymm))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "warningAlert", "showWarningMessage('Failed','Cannot Edit Attendence After Payroll!!!');", true);
                }
                else
                {
                    Response.Redirect("EditAttendence.aspx?ehEmpNo=" + ehEmpNo + "&&yyyymm=" + yyyymm + "&&month=" + month + "&&year=" + year);      
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendence.PageIndex = e.NewPageIndex;
            this.DisplayEmpNo(); //binding grid
        }

        protected void btnProcessAttendence_Click(object sender, EventArgs e)
        {
            string month = ddlMonth.SelectedValue;
            string year = ddlyear.SelectedValue;
            string yyyymm = year + month;
            int days = DateTime.DaysInMonth(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
            string created_by = Session["USERNAME"].ToString();
            objAttendencEntity.attYyyyMm = year + month;
            int status = objAttendencManager.ProcessAttendence(objAttendencEntity.attYyyyMm, days, created_by);
            if (status == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('Attendence Processed Successfully');", true);
                Response.Redirect("AttendenceDetails.aspx?&&yyyymm=" + yyyymm + "&&month=" + month + "&&year=" + year);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showErrorMessage('Failed!!!');", true);
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string month = ddlMonth.SelectedValue;
            string year = ddlyear.SelectedValue;
            objAttendencEntity.attYyyyMm = year + month;
            DataTable dt = new DataTable();
            dt = objPayrollManager.CheckPayroll(objAttendencEntity.attYyyyMm);
            int count = 0;
            foreach (DataRow ds in dt.Rows)
            {
                count = Convert.ToInt32(ds["COUNT"]);
            }
            int year1 = int.Parse(ddlyear.SelectedValue);
            int month1 = int.Parse(ddlMonth.SelectedValue);
            DateTime date = new DateTime(year1, month1, 1);
            if (System.DateTime.Now <= date)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Cannot Process Future Attendence');", true);
            }
            else
            {
                if (count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "warningAlert", "showWarningMessage('Failed!','Salary Already Processed in this Month!!!');", true);
                    btnProcessAttendence.Enabled = false;



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('Salary not Processed in this Month!!!');", true);
                    DisplayEmpNo();
                    btnProcessAttendence.Enabled = true;

                }
            }
            
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }



        protected void ddlyear_TextChanged(object sender, EventArgs e)
        {
            string month = ddlMonth.SelectedValue;
            string year = ddlyear.SelectedValue;
            string yyyymm = year + month;
            int days = DateTime.DaysInMonth(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
            DisplayEmpNo(yyyymm, days);
          
        }

        protected void gvAttendence_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                string month = ddlMonth.SelectedValue;
                string year = ddlyear.SelectedValue;
                string yyyymm = year + month;
                LinkButton lnk2 = (LinkButton)e.Row.FindControl("lnkEdit");
                int year1 = int.Parse(ddlyear.SelectedValue);
                int month1 = int.Parse(ddlMonth.SelectedValue);
                DateTime date = new DateTime(year1, month1, 1) ;
                if (objPayrollManager.IsPayrollProcessed(yyyymm) || System.DateTime.Now <= date)
                {
                    
                    lnk2.Enabled = false;

                }
                else
                {
                    lnk2.Enabled = true;
                }
                
                

                
                
                
            }
        }
    }
}