using BusinessLayer.Master.CodesMaster;
using BusinessLayer.Master.DepartmentMaster;
using BusinessLayer.Master.ErrorCodeMaster;
using BusinessLayer.Transaction.PrEmployee;
using BusinessLayer.Transaction.PrEmployeeHr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class Employee : System.Web.UI.Page
    {
        CodeMasterManager objCodeMasterMgr = new CodeMasterManager();
        DepartmentMasterManager objDeptMasterMgr = new DepartmentMasterManager();
        PrEmployeeEntity objPrEmpEntity = new PrEmployeeEntity();
        PrEmployeeManager objPrEmpManager = new PrEmployeeManager();
        PrEmployeeHrEntity objPrEmployeeHrEntity = new PrEmployeeHrEntity();
        ErrorCodeMasterManager objErrManager = new ErrorCodeMasterManager();
        PrEmployeeHrManager objHrManager = new PrEmployeeHrManager();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();

                dt4.Columns.Add("CM_DESC");
                dt4.Columns.Add("CM_CODE");
                dt4.Rows.Add("----SELECT ONE----", "0");              
                dt1 = objCodeMasterMgr.FetchEmpStatus();
                dt4.Merge(dt1);
                ddlEmpStatus.DataSource = dt4;            
                ddlEmpStatus.DataTextField = "CM_DESC";
                ddlEmpStatus.DataValueField = "CM_CODE";            
                ddlEmpStatus.DataBind();

                dt5.Columns.Add("DEPT_NAME");
                dt5.Columns.Add("DEPT_NO");
                dt5.Rows.Add("----SELECT ONE----", "0");
                dt2 = objDeptMasterMgr.FetchDeptNo();
                dt5.Merge(dt2);
                ddldeptNo.DataSource = dt5;
                ddldeptNo.DataTextField = "DEPT_NAME";
                ddldeptNo.DataValueField = "DEPT_NO";
                ddldeptNo.DataBind();

                dt6.Columns.Add("EMP_NAME");
                dt6.Columns.Add("EH_EMP_NO");
                dt6.Rows.Add("----SELECT ONE----", "0");
                dt3 = objPrEmpManager.FetchManagerNo();
                dt6.Merge(dt3);
                ddlManagerNo.DataSource = dt6;
                ddlManagerNo.DataTextField = "EMP_NAME";
                ddlManagerNo.DataValueField = "EH_EMP_NO";
                ddlManagerNo.DataBind();

                //Display Salary and empNo using queryString
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ehEmpNo"])))
                {
                    
                    dt3= objPrEmpManager.FetchEmployeeDetails(Request.QueryString["ehEmpNo"].ToString());
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt3.Rows)
                        {
                            BtnUpdateEmp.Visible = true;
                            btnSaveDept.Visible = false;
                            txtEmpNo.Text = ds["EMP_NO"].ToString();   
                                double salary = Convert.ToDouble(ds["EMP_SALARY"]);
                                string CommaSepartedSalary = salary.ToString("#,000.00");
                                txtSalary.Text = CommaSepartedSalary; 
                            txtEmpName.Text = ds["EMP_NAME"].ToString();
                            txtEmpDob.Text = ds["EMP_DOB"].ToString();
                            txtJoinDate.Text = ds["EMP_JOIN_DATE"].ToString();
                            ddldeptNo.Text = ds["EMP_DEPTNO"].ToString();
                            ddlManagerNo.Text = ds["EMP_MGRNO"].ToString();
                            ddlEmpStatus.Text = ds["EMP_STATUS"].ToString();
                            //chkCmActive.Text = ds["EMP_ACTIVE_YN"].ToString();
                            if (ds["EMP_ACTIVE_YN"].ToString() == "Y")
                            {
                                chkCmActive.Checked = true;
                            }
                            else
                            {
                                chkCmActive.Checked = false;
                            }
                            int rows = objHrManager.FetchAllowance(Request.QueryString["ehEmpNo"].ToString());
                            if(rows==0)
                            {
                                btnUpdateAlloowance.Visible = true;
                                lblAllowanceHeading.Visible = false;
                            }
                            else
                            {
                                btnUpdateAlloowance.Visible = false;
                                lblAllowanceHeading.Visible = true;
                            }
                        }
                       
                        //Display Grid
                        gvAllowance.DataSource = objPrEmpManager.FetchAllowanceDetails(Request.QueryString["ehEmpNo"].ToString());
                        gvAllowance.DataBind();
                    }
                    else
                    {
                        txtSalary.Text = "";
                        txtEmpNo.Text = "";
                    }                
                }               
            }
            else
            {
                btnUpdateAlloowance.Style.Add("visibility", "visible");
                ////Display Grid
                //gvAllowance.DataSource = objPrEmpManager.FetchAllowanceDetails(Request.QueryString["ehEmpNo"].ToString());
                //gvAllowance.DataBind();
            }
        }

        protected string CommaSeparated(double amount)
        {
            string result = amount.ToString("#,000.00");
            return result;
        }
        protected void btnCancelDept_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void btnSaveDept_Click(object sender, EventArgs e)
        {
            try
            {
                PrEmployeeEntity prEmployeeEntity = new PrEmployeeEntity();
                prEmployeeEntity.empDob = Convert.ToDateTime(txtEmpDob.Text);
                prEmployeeEntity.empJoinDate = Convert.ToDateTime(txtJoinDate.Text);
                string empName = txtEmpName.Text;
                double empSalary = 0;
                string empDob = txtEmpDob.Text;
                string empJoinDate = txtJoinDate.Text;
                string empDeptNo = ddldeptNo.Text;
                string empMgrNo = ddlManagerNo.Text;
                string empStatus = ddlEmpStatus.Text;
                string empActiveYn = "";
                if (chkCmActive.Checked)
                {
                    empActiveYn = "Y";
                }
                else
                {
                    empActiveYn = "N";
                }
                string empCrBy = Session["USERNAME"].ToString();
                objPrEmpEntity.empCrDt = System.DateTime.Now;
                DateTime empCrDt = objPrEmpEntity.empCrDt;
                string empUpBy = Session["USERNAME"].ToString();
                objPrEmpEntity.empUpDt = System.DateTime.Now;
                DateTime empUpDt = objPrEmpEntity.empUpDt;
                DateTime jd = DateTime.Parse(txtJoinDate.Text);
                string joinYear = jd.ToString("yy");
                string empNo = objPrEmpManager.GenerateEmpNo(joinYear);
                string empPwd = "";
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ehEmpNo"])))
                {
                    string emp = Request.QueryString["ehEmpNo"];
                    int rowss=objPrEmpManager.UpdateEmployee(emp, empName, prEmployeeEntity.empDob, prEmployeeEntity.empJoinDate, empDeptNo, empMgrNo, empStatus, empActiveYn, empUpBy, empUpDt);
                    if(rowss>0)
                    {
                        dt = objErrManager.UpdatedSuccessfully();
                        string message = dt.Rows[0]["ERR_DESC"].ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                        "');", true);
                    }
                }
                else
                {
                    int rows = objPrEmpManager.InsertEmployeeToDb(empNo, empPwd, empName, empSalary, prEmployeeEntity.empDob, prEmployeeEntity.empJoinDate, empDeptNo, empMgrNo, empStatus, empActiveYn, empCrBy, empCrDt);
                    if (rows > 0)
                    {

                        dt = objErrManager.SavedSuccessfully();
                        string message = dt.Rows[0]["ERR_DESC"].ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                        "');", true);
                        btnSaveDept.Visible = false;                       
                        //Response.Redirect("Employee.aspx?empNo="+)
                        DataTable dt1 = new DataTable();
                        dt1 = objPrEmpManager.FetchEmpNo();
                        foreach (DataRow ds in dt1.Rows)
                        {
                            empNo = ds["EMP_NO"].ToString();
                        }
                        txtEmpNo.Text = empNo.ToString();
                        empNo = empNo.ToString();
                        int rowss = objPrEmpManager.InsertIntoUserMaster(empNo, empNo, empNo, empCrBy, empCrDt, empActiveYn);
                        btnUpdateAlloowance.Visible = true;                        
                    }
                }
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "warningAlert", "showWarningMessage('Sorry!','Some Error Occured');", true);
            }


        }
     
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction/AddAlowance.aspx");
        }

        protected void btnUpdateAlloowance_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAlowance.aspx");
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string empNo = btn.CommandArgument;
            Response.Redirect("AddAlowance.aspx?ehEmpNo=" + empNo);
            
        }

        protected void btnAddEmployee_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void BtnUpdateEmp_Click(object sender, EventArgs e)
        {
            objPrEmpEntity.empNo = txtEmpNo.Text;
            objPrEmpEntity.empName = txtEmpName.Text;
            objPrEmpEntity.empDob = Convert.ToDateTime(txtEmpDob.Text);
            objPrEmpEntity.empJoinDate = Convert.ToDateTime(txtJoinDate.Text);
            objPrEmpEntity.empSalary = Convert.ToDouble(txtSalary.Text);
            objPrEmpEntity.empDeptNo = ddldeptNo.SelectedValue;
            objPrEmpEntity.empMgrNo = ddlManagerNo.SelectedValue;
            objPrEmpEntity.empStatus = ddlEmpStatus.SelectedValue;
            objPrEmpEntity.empActiveYn = "";
            if (chkCmActive.Checked)
            {
                objPrEmpEntity.empActiveYn = "Y";
            }
            else
            {
                objPrEmpEntity.empActiveYn = "N";
            }
            objPrEmpEntity.empUpBy = Session["USERNAME"].ToString();
            if(objPrEmpManager.IsEmployeeUpdated(objPrEmpEntity))
            {
                dt = objErrManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Updation Failed');", true);
            }
        }
    }
}

        
    