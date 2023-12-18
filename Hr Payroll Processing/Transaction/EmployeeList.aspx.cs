using BusinessLayer.Master.CodesMaster;
using BusinessLayer.Master.ErrorCodeMaster;
using BusinessLayer.Transaction.PrEmployee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        PrEmployeeManager objPrEmpManager = new PrEmployeeManager();
        DataTable dt = new DataTable();
        ErrorCodeMasterManager objErrManager = new ErrorCodeMasterManager();
        CodeMasterManager objCodeMasterMgr = new CodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gvEmployeeGrid.Visible = true;
                imgNotFound.Visible = false;               
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                DisplayEmployeeDetails();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Columns.Add("CM_DESC");
                dt.Columns.Add("CM_CODE");
                dt.Rows.Add("All", "All");
                dt1 = objCodeMasterMgr.FetchDesignation();
                dt.Merge(dt1);
                ddlSortEmployees.DataSource = dt;
                ddlSortEmployees.DataTextField = "CM_DESC";
                ddlSortEmployees.DataValueField = "CM_CODE";
                ddlSortEmployees.DataBind();
            }
            gvEmployeeGrid.Visible = true;
            imgNotFound.Visible = false;
        }

        //default grid for displaying all employees
        protected void DisplayEmployeeDetails()
        {
            gvEmployeeGrid.DataSource = objPrEmpManager.FetchEmployeeDetails();
            gvEmployeeGrid.DataBind();
        }
        //Display grid for Search
        protected void DisplayEmployeeDetails(string empName)
        {
            gvEmployeeGrid.DataSource = objPrEmpManager.FetchEmployee(empName);
            gvEmployeeGrid.DataBind();
        }
        //Display all Managers
        protected void DisplayManagerDetails(string choice)
        {
            var data= objPrEmpManager.FetchManagerDetails(choice);
            if (data != null && data.Rows.Count > 0)
            {
                gvEmployeeGrid.DataSource = data;
                gvEmployeeGrid.DataBind();
            }
            else
            {
                gvEmployeeGrid.EmptyDataText = "No Employees";
            }

        }
    
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string empNo= btn.CommandArgument;
            Response.Redirect("Employee.aspx?ehEmpNo=" +empNo);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string empNo = btn.CommandArgument;
                int rows = objPrEmpManager.DeleteEmployee(empNo);
                if (rows > 0)
                {
                    dt = objErrManager.FetchDeletion();
                    string message = dt.Rows[0]["ERR_DESC"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message + "');", true);
                    this.DisplayEmployeeDetails();

                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Some Error Occured!!!');", true);
            }
        }

        protected void btnAddEmployee_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void gvEmployeeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeGrid.PageIndex = e.NewPageIndex;
            this.DisplayEmployeeDetails();
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected string CommaSeparated(double amount)
        {
            string result = amount.ToString("#,000.00");
            return result;
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string empName = txtSearchEmp.Text;
            if(objPrEmpManager.IsEmpExist(empName))
            {
                gvEmployeeGrid.Visible = true;
                imgNotFound.Visible = false;
                this.DisplayEmployeeDetails(empName);
            }
            else
            {
                gvEmployeeGrid.Visible = false;
                imgNotFound.Visible = true;              
                //ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','No Employee to display');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchEmp.Text = "";
            gvEmployeeGrid.Visible = true;
            imgNotFound.Visible = false;
            
            DisplayEmployeeDetails();
            
        }

        protected void ddlSortEmployees_TextChanged(object sender, EventArgs e)
        {
            string choice = ddlSortEmployees.SelectedValue;
            if(choice=="All")
            {
                DisplayEmployeeDetails();
            }
            else if(choice==ddlSortEmployees.SelectedValue)
            {
                DisplayManagerDetails(ddlSortEmployees.SelectedValue);
            }           
        }
    }
}