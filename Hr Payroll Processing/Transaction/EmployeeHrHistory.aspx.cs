using BusinessLayer.Transaction.PrEmployee;
using BusinessLayer.Transaction.PrEmployeeHr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class EmployeeHrHistory : System.Web.UI.Page
    {
        PrEmployeeHrManager objEmployeeHrManager = new PrEmployeeHrManager();
        PrEmployeeManager objPrEmpManager = new PrEmployeeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString(); //backButton
                DisplayAllowanceHistory();
            }
            gvHistory.Visible = true;
            imgNotFound.Visible = false;
        }

        protected void DisplayAllowanceHistory()
        {
            gvHistory.DataSource = objEmployeeHrManager.FetchAllowanceHistoryDetails();
            gvHistory.DataBind();
        }

        protected void DisplayAllowanceHistory(string empNo)
        {
            gvHistory.DataSource = objEmployeeHrManager.FetchAllowanceHistoryDetails(empNo);
            gvHistory.DataBind();
        }

        protected void gvHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistory.PageIndex = e.NewPageIndex;
            this.DisplayAllowanceHistory();
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string empNo = txtSearchEmp.Text;
            if (objEmployeeHrManager.IsEmpExist(empNo))
            {
                gvHistory.Visible = true;
                imgNotFound.Visible = false;
                this.DisplayAllowanceHistory(empNo);
            }
            else
            {
                gvHistory.Visible = false;
                imgNotFound.Visible = true;
                //ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','No Employee to display');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchEmp.Text = "";
            this.DisplayAllowanceHistory();
        }
    }
}