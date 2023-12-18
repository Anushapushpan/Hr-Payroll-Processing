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
    public partial class ErrorCodeMaster : System.Web.UI.Page
    {
        ErrorCodeMasterEntity objErrEntity = new ErrorCodeMasterEntity();
        ErrorCodeMasterManager objErrManager = new ErrorCodeMasterManager();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["errCode"])))
                {
                    btnSaveErrorMaster.Visible = false;
                    btnUpdate.Visible = true;
                    txtErrCode.ReadOnly = true;
                    txtErrCode.Enabled = false;
                    dt = objErrManager.FetchErrorMaster(Request.QueryString["errCode"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt.Rows)
                        {
                            txtErrCode.Text = Request.QueryString["errCode"].ToString();
                            txtErrType.Text = ds["ERR_TYPE"].ToString();
                            txtErrDesc.Text = ds["ERR_DESC"].ToString();
                        }
                    }
                }               
                DisplayErrorMaster();
            }
            
            DisplayErrorMaster();
        }

        protected void DisplayErrorMaster()
        {
            gvErrorMaster.DataSource = objErrManager.FetchErrorGrid();
            gvErrorMaster.DataBind();
        }
        protected void btnSaveErrorMaster_Click(object sender, EventArgs e)
        {
            objErrEntity.errCode = txtErrCode.Text;
            objErrEntity.errType = txtErrType.Text;
            objErrEntity.errDesc = txtErrDesc.Text;
            objErrEntity.errCrBy = Session["USERNAME"].ToString();
            objErrEntity.errCrDt = DateTime.Now;
            if(objErrManager.IsUnique(objErrEntity.errCode))
            {
                if (objErrManager.IsInsertErrorMaster(objErrEntity))
                {
                    dt = objErrManager.SavedSuccessfully();
                    string message = dt.Rows[0]["ERR_DESC"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                    "');", true);
                    txtErrCode.Text = string.Empty;
                    txtErrDesc.Text = string.Empty;
                    txtErrType.Text = string.Empty;
                    DisplayErrorMaster();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Failed to Save');", true);
                    DisplayErrorMaster();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Error Code Already Exists. Try Another One!!!');", true);
                DisplayErrorMaster();
            }
            
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string errCode = btn.CommandArgument;
            if(objErrManager.IsRowDeleted(errCode))
            {
                dt = objErrManager.FetchDeletion();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message + "');", true);
                DisplayErrorMaster();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Try Again!');", true);
                DisplayErrorMaster();
            }

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string errCode = btn.CommandArgument;
            Response.Redirect("ErrorCodeMaster.aspx?errCode=" + errCode);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objErrEntity.errCode = txtErrCode.Text;
            objErrEntity.errType = txtErrType.Text;
            objErrEntity.errDesc = txtErrDesc.Text;           
            objErrEntity.errUpBy = Session["USERNAME"].ToString();
            objErrEntity.errUpDt = System.DateTime.Now;
            int rows = objErrManager.UpdateErrorMaster(objErrEntity);
            if (rows > 0)
            {
                dt = objErrManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);
                txtErrCode.Text = "";
                txtErrType.Text = "";
                txtErrDesc.Text = "";
                txtErrCode.ReadOnly = false;
                btnSaveErrorMaster.Visible = true;
                btnUpdate.Visible = false;
                this.DisplayErrorMaster();
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void txtErrCode_TextChanged(object sender, EventArgs e)
        {
            string errCode = txtErrCode.Text;
            if (objErrManager.IsUnique(errCode))
            {
                lblAlert.Text = "";
                txtErrCode.Style.Add("border-color", "green");
            }
            else
            {
                lblAlert.Text = "Error Code Already Exists!";
                txtErrCode.Style.Add("border-color", "red");
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ErrorCodeMaster.aspx");
        }
    }
}