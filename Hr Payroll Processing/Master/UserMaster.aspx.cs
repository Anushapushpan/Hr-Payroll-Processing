using BusinessLayer.Master.ErrorCodeMaster;
using BusinessLayer.Master.UserMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Master
{
    public partial class UserMaster1 : System.Web.UI.Page
    {
        UserMasterManager objUsrMaster = new UserMasterManager();
        UserMasterEntity objUserEntity = new UserMasterEntity();
        DataTable dt = new DataTable();
        ErrorCodeMasterManager objErrManager = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayUserMaster();
            if (!IsPostBack)
            {
                Session["RefferrerUrl"] = Request.UrlReferrer?.ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["userId"])))
                {
                    btnSaveUser.Visible = false;
                    btnUpdateUser.Visible = true;
                    txtUserId.ReadOnly = true;
                    txtUserId.Enabled = false;
                    dt = objUsrMaster.FetchUserMaster(Request.QueryString["userId"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ds in dt.Rows)
                        {
                            txtUserId.Text = Request.QueryString["userId"].ToString();
                            txtUserName.Text = ds["USER_NAME"].ToString();
                            txtUserPwd.Text = ds["USER_PASSWORD"].ToString();
                            if(ds["USER_ACTIVE_YN"].ToString()=="Y")
                            {
                                chkUserActive.Checked = true;
                            }
                            else
                            {
                                chkUserActive.Checked = false;
                            }
                        }
                    }
                }
                DisplayUserMaster();
            }
        }
        protected void DisplayUserMaster()
        {
            gvUserMaster.DataSource = objUsrMaster.FetchUserMaster();
            gvUserMaster.DataBind();
        }      

        protected void gvUserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserMaster.PageIndex = e.NewPageIndex;
            this.DisplayUserMaster();
        }

        protected string HidePassword(string password)
        {
            return new string('*', password.Length);
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            objUserEntity.userId = txtUserId.Text;
            objUserEntity.userName = txtUserName.Text;
            objUserEntity.userPassword = txtUserPwd.Text;
            objUserEntity.userActiveYn = "";          
            if (chkUserActive.Checked)
            {
                objUserEntity.userActiveYn = "Y";
            }
            else
            {
                objUserEntity.userActiveYn = "N";
            }
            objUserEntity.userCrBy = Session["USERNAME"].ToString();
            objUserEntity.userCrDt = System.DateTime.Now;
            if(objUsrMaster.IsUnique(objUserEntity.userId))
            {
                if(objUsrMaster.IsInsertToUserMaster(objUserEntity))
                {
                    dt = objErrManager.SavedSuccessfully();
                    string message = dt.Rows[0]["ERR_DESC"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                    "');", true);
                    txtUserId.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    txtUserPwd.Text = string.Empty;
                    DisplayUserMaster();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','Failed to Save');", true);
                    DisplayUserMaster();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "showErrorMessage('Failed!','User Id Already Exists. Try Another One!!!');", true);
                DisplayUserMaster();
            }
        }

        protected void btnCancelDept_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMaster.aspx");
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string userId = btn.CommandArgument;         
            Response.Redirect("UserMaster.aspx?userId=" + userId);
            
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            objUserEntity.userId = txtUserId.Text;           
            objUserEntity.userName = txtUserName.Text;
            objUserEntity.userPassword = txtUserPwd.Text;
            objUserEntity.userActiveYn = "";
            if (chkUserActive.Checked)
            {
                objUserEntity.userActiveYn = "Y";
            }
            else
            {
                objUserEntity.userActiveYn = "N";
            }
            objUserEntity.userUpBy = Session["USERNAME"].ToString();
            objUserEntity.userUpDt = System.DateTime.Now;
            int rows = objUsrMaster.UpdateUser(objUserEntity);
            if (rows > 0)
            {
                dt = objErrManager.UpdatedSuccessfully();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message +
                "');", true);
                txtUserId.Text = "";
                txtUserName.Text = "";
                txtUserPwd.Text = "";
                txtUserId.ReadOnly = false;
                btnUpdateUser.Visible = false;
                btnSaveUser.Visible = true;
                this.DisplayUserMaster();
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string userId = btn.CommandArgument;
            int rows = objUsrMaster.DeleteUser(userId);
            if (rows > 0)
            {
                dt = objErrManager.FetchDeletion();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('" + message + "');", true);
                this.DisplayUserMaster();

            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Session["RefferrerUrl"] != null)
            {
                Response.Redirect(Session["RefferrerUrl"].ToString());
            }
        }

        protected void txtUserId_TextChanged(object sender, EventArgs e)
        {
            string id = txtUserId.Text;
            if (objUsrMaster.IsUnique(id))
            {
                lblUniqueConstraintAlert.Text = "";
                txtUserId.Style.Add("border-color", "green");
            }
            else
            {
                lblUniqueConstraintAlert.Text = "User Id Already Exists!";
                txtUserId.Style.Add("border-color", "red");
            }
        }
    }
}