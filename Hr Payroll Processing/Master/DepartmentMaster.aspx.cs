using BusinessLayer.Master.DepartmentMaster;
using BusinessLayer.Master.ErrorCodeMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Master
{
    public partial class DepartmentMaster : System.Web.UI.Page
    {
        DepartmentMasterEntity objDeptEntity = new DepartmentMasterEntity();
        DepartmentMasterManager objDeptManager = new DepartmentMasterManager();
        DataTable dt = new DataTable();
        ErrorCodeMasterManager objErrorManager = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {                 
            DisplayDepartments();
            if (!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["deptNo"])))
                {
                    btnSaveDept.Visible = false;
                    btnUpdate.Visible = true;
                    txtDeptNo.ReadOnly = true;
                    txtDeptNo.Enabled = false;
                    dt = objDeptManager.FetchDepartmentMaster(Request.QueryString["deptNo"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt.Rows)
                        {
                            txtDeptNo.Text = Request.QueryString["deptNo"].ToString();
                            txtDeptName.Text = ds["DEPT_NAME"].ToString();
                        }
                    }
                }
                DisplayDepartments();
            }
        }

        protected void DisplayDepartments()
        {
            gvDepartment.DataSource = objDeptManager.FetDepartmentDetails();
            gvDepartment.DataBind();
        }

        protected void btnSaveDept_Click(object sender, EventArgs e)
        {
            string deptNo = txtDeptNo.Text;
            string deptName = txtDeptName.Text;
            objDeptEntity.deptCrBy = Session["USERNAME"].ToString();
            string deptCrBy = objDeptEntity.deptCrBy;
            objDeptEntity.deptCrDt = System.DateTime.Now;
            DateTime deptCrDt = objDeptEntity.deptCrDt;

            if (objDeptManager.isValidateUnique(deptNo))
            {
                objDeptEntity.deptUpBy = Session["USERNAME"].ToString();
                string deptUpBy = objDeptEntity.deptUpBy;
                string deptUpDt = DateTime.Now.ToString("dd MMMM yyyy");
                int rows = objDeptManager.InsertDeptMasterToDb(deptNo, deptName, deptCrBy, deptCrDt);
                if (rows > 0)
                {
                    dt = objErrorManager.SavedSuccessfully();
                    string message = dt.Rows[0]["ERR_DESC"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                    "');", true);
                    DisplayDepartments();
                }
                else
                {
                    RequiredFieldValidator1.Text = "Dep No already entered!!!";
                    txtDeptNo.Style.Add("border-color", "red");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Department Id Already Exists. Try Another One!!!');", true);

                this.DisplayDepartments();
                
            }
            
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string deptNo = btn.CommandArgument;
            int rows = objDeptManager.DeleteDept(deptNo);
            if (rows > 0)
            {
                dt = objErrorManager.FetchDeletion();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message + "');", true);
                this.DisplayDepartments();

            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string deptNo = btn.CommandArgument;
            Response.Redirect("DepartmentMaster.aspx?deptNo=" + deptNo);
            objDeptEntity.deptName = txtDeptName.Text;
            objDeptEntity.deptUpBy= Session["USERNAME"].ToString();
            int rows = objDeptManager.UpdateDept(deptNo, objDeptEntity.deptName, objDeptEntity.deptUpBy);
            if(rows>0)
            {
                dt = objErrorManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);
                txtDeptName.Text = "";
                txtDeptNo.Text = "";
                this.DisplayDepartments();
            }
        }

        protected void btnCancelDept_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentMaster.aspx");
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objDeptEntity.deptNo = txtDeptNo.Text;
            objDeptEntity.deptName = txtDeptName.Text;
            objDeptEntity.deptUpBy = Session["USERNAME"].ToString();
            objDeptEntity.deptUpDt = System.DateTime.Now;
            int rows = objDeptManager.UpdateDepartment(objDeptEntity);
            if (rows > 0)
            {
                dt = objErrorManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);
                txtDeptNo.Text = "";
                txtDeptName.Text = "";
                txtDeptNo.ReadOnly = false;
                btnUpdate.Visible = false;
                btnSaveDept.Visible = true;
                this.DisplayDepartments();
            }
        }

        protected void txtDeptNo_TextChanged(object sender, EventArgs e)
        {
            string deptNo = txtDeptNo.Text;
            if (objDeptManager.isValidateUnique(deptNo))
            {
                txtDeptNo.Style.Add("border-color", "green");
                lblAlert.Text = "";
            }
            else
            {
                txtDeptNo.Style.Add("border-color", "red");
                lblAlert.Text = "Dept No Already Exists!";
            }
        }
    }
}