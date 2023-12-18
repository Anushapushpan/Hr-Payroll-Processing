using BusinessLayer.Master.CodesMaster;
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
    public partial class CodesMaster : System.Web.UI.Page
    {
        CodeMasterManager cm = new CodeMasterManager();
        CodeMasterEntity objCmEntity = new CodeMasterEntity();
        DataTable dt = new DataTable();
        ErrorCodeMasterManager objErrorManager = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayCodesMaster();
            if (!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["cmCode"])))
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    txtxCmCode.ReadOnly = true;
                    txtcmType.ReadOnly = true;
                    txtxCmCode.Enabled = false;
                    txtcmType.Enabled = false;
                    dt = cm.FetchCodesMaster(Request.QueryString["cmCode"].ToString(), Request.QueryString["cmType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt.Rows)
                        {
                            txtxCmCode.Text = ds["CM_CODE"].ToString();
                            txtcmType.Text = ds["CM_TYPE"].ToString();
                            txtCmDesc.Text = ds["CM_DESC"].ToString();
                            txtCmValue.Text = ds["CM_VALUE"].ToString();
                            
                            if (ds["CM_ACTIVE_YN"].ToString() == "Y")
                            {
                                chkCmActive.Checked = true;
                            }
                            else
                            {
                                chkCmActive.Checked = false;
                            }

                        }                      
                    }
                }
                DisplayCodesMaster();
            }
        }

        protected void DisplayCodesMaster()
        {
            gvCodesmaster.DataSource = cm.FetchCodesMaster();
            gvCodesmaster.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string cmCode = txtxCmCode.Text;
            string cmType = txtcmType.Text;
            string cmDesc = txtCmDesc.Text;
            int cmValue = Convert.ToInt32(txtCmValue.Text);
            string cmActiveYn = "";
            if (chkCmActive.Checked)
            {
                cmActiveYn = "Y";
            }
            else
            {
                cmActiveYn = "N";
            }
            objCmEntity.cmCrBy = Session["USERNAME"].ToString();
            //objCmEntity.cmCrBy = Session["username"].ToString();
            string cmCrBy = objCmEntity.cmCrBy;
            objCmEntity.cmCrDt = System.DateTime.Now;
            DateTime cmCrDt = objCmEntity.cmCrDt;

            if(cm.isValidateUnique(cmCode, cmType))
            {
                objCmEntity.cmUpBy = Session["USERNAME"].ToString();
                string cmUpBy = objCmEntity.cmUpBy;
                DateTime cmupDt = objCmEntity.cmUpDt;
                string cmUpDt = DateTime.Now.ToString("dd MMMM yyyy");
                int updatedRows = cm.UpdateCodeMaster(cmCode, cmType, cmDesc, cmValue, cmUpBy, cmUpDt, cmActiveYn);
                if (updatedRows>0)
                {
                    
                    DisplayCodesMaster();
                }
                else
                {
                    lblAlert.Text = "Cm Code must be unique!!!";
                    txtxCmCode.Style.Add("border-color", "red");
                    
                }
            }
            else
            {
                int rows = cm.InsertCodesMasterToDb(cmCode, cmType, cmDesc, cmValue, cmCrBy, cmCrDt, cmActiveYn);
                if (rows > 0)
                {
                    txtxCmCode.Text = "";
                    txtcmType.Text = "";
                    txtCmDesc.Text = "";
                    txtCmValue.Text = "";
                    DataTable dt = new DataTable();
                    dt = objErrorManager.SavedSuccessfully();
                    string message = dt.Rows[0]["ERR_DESC"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('"+ message +
                    "');", true);
                    DisplayCodesMaster();

                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CodesMaster.aspx");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string cmCode = btn.CommandArgument;
            int rows = cm.DeleteCodesMaster(cmCode);
            if (rows > 0)
            {
                DataTable dt = new DataTable();
                dt = objErrorManager.FetchDeletion();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('"+ message +"');", true);
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtxCmCode.Text = "";
                txtCmValue.Text = "";
                txtcmType.Text = "";
                txtCmDesc.Text = "";
                this.DisplayCodesMaster();

            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)(sender);
                string cmCode = btn.CommandArgument;
                string cmType = btn.CommandName;
                Response.Redirect("CodesMaster.aspx?cmCode=" + cmCode+ "&&cmType=" + cmType);                             
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Some Error Occured!!!');", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objCmEntity.cmCode = txtxCmCode.Text;
            objCmEntity.cmType = txtcmType.Text;
            objCmEntity.cmDesc = txtCmDesc.Text;
            objCmEntity.cmValue = Convert.ToInt32(txtCmValue.Text);
            objCmEntity.cmActiveYn = "";
            objCmEntity.cmActiveYn = "";
            if (chkCmActive.Checked)
            {
                objCmEntity.cmActiveYn = "Y";
            }
            else
            {
                objCmEntity.cmActiveYn = "N";
            }
            objCmEntity.cmUpBy = Session["USERNAME"].ToString();
            objCmEntity.cmUpDt = System.DateTime.Now;
            int rows = cm.UpdateCodesMaster(objCmEntity);
            if (rows > 0)
            {
                dt = objErrorManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);             
                txtCmDesc.Text = "";
                txtcmType.Text = "";
                txtCmValue.Text = "";
                txtxCmCode.Text = "";
                txtxCmCode.ReadOnly = false;
                txtcmType.ReadOnly = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                this.DisplayCodesMaster();
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void txtcmType_TextChanged(object sender, EventArgs e)
        {
            string cmcode = txtxCmCode.Text;
            string cmtype = txtcmType.Text;
            if (cm.isValidateUnique(cmcode, cmtype))
            {
                lblAlert.Text = "Cmcode and CmType already Exists!!!";
                txtxCmCode.Style.Add("border-color", "red");
                txtcmType.Style.Add("border-color", "red");
                
            }
            else
            {
                lblAlert.Text = "";
                txtxCmCode.Style.Add("border-color", "green");
                txtcmType.Style.Add("border-color", "green");
            }
        }

        protected void gvCodesmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCodesmaster.PageIndex = e.NewPageIndex;
            this.DisplayCodesMaster();
        }
    }
}