using BusinessLayer.Transaction.PrEmployeeAttendence;
using BusinessLayer.Transaction.PrEmployeePayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class PayrollProcessing : System.Web.UI.Page
    {
        PrEmployeePayrollEntity objPayrollEntity = new PrEmployeePayrollEntity();
        PrEmployeePayrollManager objPayrollmanager = new PrEmployeePayrollManager();
        PrEmployeeAttendenceManager objAttendenceManager = new PrEmployeeAttendenceManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString(); //backButton
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                ddlMonth.SelectedValue = currentMonth.ToString();
                ddlyear.SelectedValue = currentYear.ToString();
                DisplayPayroll();

            }
            else
            {
                DisplayPayroll();
            }
            
        }

        protected void DisplayPayroll()
        {
            string yyyymm = ddlyear.SelectedValue + ddlMonth.SelectedValue;
            var data = objPayrollmanager.FetchPayrollDetails(yyyymm);
            if (data != null && data.Rows.Count > 0)
            {
                gvPayroll.DataSource = data;
                gvPayroll.DataBind();
            }
            else
            {
                gvPayroll.EmptyDataText = "Payroll Not Processed in this Month!";
            }
        }

        protected void DisplayPayroll(string yyyymm)
        {
            
            gvPayroll.DataSource = objPayrollmanager.FetchPayrollDetails(yyyymm);
            gvPayroll.DataBind();
        }

        protected void btnPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                string month = ddlMonth.SelectedValue;
                string year = ddlyear.SelectedValue;
                int days = DateTime.DaysInMonth(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
                string created_by = Session["USERNAME"].ToString();
                objPayrollEntity.prYyyMm = year + month;
                string yyyymm= year + month;
               
                    if(objPayrollmanager.IsPayrollProcessed(yyyymm))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!!!','Salary Already Processed in this month');", true);
                        
                    }
                    else
                    {
                        if (objAttendenceManager.IsAttendenceProcessed(yyyymm, days))
                        {
                            if (objPayrollmanager.IsPreviousMonthPayrollProcessed(yyyymm))
                            {
                                int status = objPayrollmanager.ProcessPayroll(objPayrollEntity.prYyyMm, days, created_by);
                                if (status == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('Payroll Processed Successfully');", true);
                                    DisplayPayroll();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!!!');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!!!','Salary Cannot Process Before Processing Previous Month!!!');", true);
                            }
                        }                       
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!!!','Salary Cannot Process Before Processing Attendence of this Month!!!');", true);
                        }
                    }
                    
                
                
                
            }
            catch (Exception ex)
            {
                throw ex;
                //ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Salary can be process only once!!!');", true);

            }
        }

        protected void gvPayroll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPayroll.PageIndex = e.NewPageIndex;
            this.DisplayPayroll();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

        //protected void btnBack_ServerClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("AttendenceDetails.aspx");
        //}

        protected void btnBack_ServerClick1(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void ddlMonth_TextChanged(object sender, EventArgs e)
        {
            string month = ddlMonth.SelectedValue;
            string year = ddlyear.SelectedValue;
            string yyyymm = year + month;
            DisplayPayroll(yyyymm);
        }
    }
}