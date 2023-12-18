using BusinessLayer.Master.CodesMaster;
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
    public partial class AddAlowance : System.Web.UI.Page
    {
        PrEmployeeManager objPrEmpManager = new PrEmployeeManager();
        PrEmployeeEntity objPrEmployeeEntity = new PrEmployeeEntity();
        CodeMasterManager objCodeMasterMgr = new CodeMasterManager();
        PrEmployeeHrEntity objPrEmployeeHr = new PrEmployeeHrEntity();
        PrEmployeeHrManager objPrEmployeeHrMgr = new PrEmployeeHrManager();
        DataTable dt = new DataTable();
        ErrorCodeMasterManager objErrManager = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt = objPrEmpManager.FetchEmpNo();
            string empNo = "";
            foreach (DataRow ds in dt.Rows)
            {
                empNo = ds["EMP_NO"].ToString();
            }
            txtEmpNo.Text = empNo.ToString();
            
            if (!IsPostBack)
            {

                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                //DropDowns
                dt3.Columns.Add("CM_DESC");
                dt3.Columns.Add("CM_CODE");
                dt3.Rows.Add("----SELECT ONE----", "0");
                dt1 = objCodeMasterMgr.FetchDesignationFromCodesMaster();
                dt3.Merge(dt1);
                ddlDesignation.DataSource = dt3;
                ddlDesignation.DataTextField = "CM_DESC";
                ddlDesignation.DataValueField = "CM_CODE";
                ddlDesignation.DataBind();

                dt4.Columns.Add("CM_DESC");
                dt4.Columns.Add("CM_CODE");
                dt4.Rows.Add("----SELECT ONE----", "0");
                dt2 = objCodeMasterMgr.FetchGradesFromCodesMaster();
                dt4.Merge(dt2);
                ddlGrade.DataSource = dt4;
                ddlGrade.DataTextField = "CM_DESC";
                ddlGrade.DataValueField = "CM_CODE";
                ddlGrade.DataBind();
                //Fetch allowance details during update
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ehEmpNo"])))
                {
                    dt = objPrEmployeeHrMgr.FetchAllowanceDetails(Request.QueryString["ehEmpNo"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt.Rows)
                        {
                            btnUpdateDept.Visible = true;
                            btnSaveDept.Visible = false;
                            txtEmpNo.Text = ds["EH_EMP_NO"].ToString();
                            ddlDesignation.Text = ds["EH_DESIGNATION"].ToString();
                            ddlGrade.Text = ds["EH_GRADE"].ToString();
                            txtBasic.Text = ds["EH_BASIC"].ToString();
                            txtHra.Text = ds["EH_HRA"].ToString();
                            txtConv.Text = ds["EH_CONV"].ToString();
                            txtDa.Text = ds["EH_DA"].ToString();
                            txtTds.Text = ds["EH_TDS"].ToString();
                            txtEsi.Text = ds["EH_ESI"].ToString();

                        }
                    }
                }
            }
        }

        protected void btnSaveAllowance_Click(object sender, EventArgs e)
        {

            try
            {
                objPrEmployeeHr.ehEmpNo = txtEmpNo.Text;
                objPrEmployeeHr.ehDesignation = ddlDesignation.Text;
                objPrEmployeeHr.ehGrade = ddlGrade.Text;
                objPrEmployeeHr.ehBasic = Convert.ToDouble(txtBasic.Text);
                objPrEmployeeHr.ehHra = Convert.ToDouble(txtHra.Text);
                objPrEmployeeHr.ehConv = Convert.ToDouble(txtConv.Text);
                objPrEmployeeHr.ehDa = Convert.ToDouble(txtDa.Text);
                objPrEmployeeHr.ehTds = Convert.ToDouble(txtTds.Text);
                objPrEmployeeHr.ehEsi = Convert.ToDouble(txtEsi.Text);
                objPrEmployeeHr.ehCrDt = System.DateTime.Now;
                objPrEmployeeHr.ehCrBy = Session["USERNAME"].ToString();
                objPrEmployeeEntity.empSalary = Convert.ToDouble(txtBasic.Text) + Convert.ToDouble(txtHra.Text) + Convert.ToDouble(txtConv.Text) + Convert.ToDouble(txtDa.Text) - Convert.ToDouble(txtTds.Text) - Convert.ToDouble(txtEsi.Text);
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ehEmpNo"])))
                {
                    if (objPrEmployeeHrMgr.isValidateUnique(Request.QueryString["ehEmpNo"]))
                    {
                        int rows = objPrEmpManager.InsertAllowanceToDbb(Request.QueryString["ehEmpNo"], objPrEmployeeHr);
                        objPrEmpManager.InsertSalaryToEmployee(objPrEmployeeHr.ehEmpNo, objPrEmployeeEntity.empSalary);
                        if (rows > 0)
                        {
                            dt = objErrManager.SavedSuccessfully();
                            string message = dt.Rows[0]["ERR_DESC"].ToString();
                            ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                            "');", true);
                            Response.Redirect("Employee.aspx?ehEmpNo=" + objPrEmployeeHr.ehEmpNo);
                        }
                    }
                    else
                    {
                        objPrEmployeeHr.ehUpBy = Session["USERNAME"].ToString();
                        int rows = objPrEmployeeHrMgr.UpdateAllowanceDetails(objPrEmployeeHr, Request.QueryString["ehEmpNo"].ToString());
                        
                        objPrEmpManager.UpdateSalaryToEmployee(Request.QueryString["ehEmpNo"].ToString(), objPrEmployeeEntity.empSalary, objPrEmployeeHr.ehUpBy);
                        if (rows > 0)
                        {
                            string ehEmpNo = Request.QueryString["ehEmpNo"].ToString();
                            Response.Redirect("Employee.aspx?ehEmpNo=" + ehEmpNo);
                            dt = objErrManager.UpdatedSuccessfully();
                            string message = dt.Rows[0]["ERR_DESC"].ToString();
                            ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                            "');", true);
                        }
                    }
                }
                else
                {
                    int rows = objPrEmpManager.InsertAllowanceToDb(objPrEmployeeHr);
                    objPrEmpManager.InsertSalaryToEmployee(objPrEmployeeHr.ehEmpNo, objPrEmployeeEntity.empSalary);
                    if (rows > 0)
                    {
                        dt = objErrManager.SavedSuccessfully();
                        string message = dt.Rows[0]["ERR_DESC"].ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                        "');", true);
                        Response.Redirect("Employee.aspx?ehEmpNo=" + objPrEmployeeHr.ehEmpNo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
                
            
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }
    }
}