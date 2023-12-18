using BusinessLayer.Master.UserMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.MasterPages
{
    public partial class Master : System.Web.UI.MasterPage
    {
        UserMasterManager objUserManager = new UserMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["USERNAME"])))
            {               
                Response.Redirect("~/Login.aspx");

            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            
            Response.Redirect("~/Login.aspx");
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            string oldPwd = txtCurrentpwd.Text;
            string newPwd = txtNewPwd.Text;
            string username = Session["USERNAME"].ToString();
            if (objUserManager.isPassword(oldPwd))
            {
                int rows = objUserManager.ChangePwd(newPwd, username);
                if (rows > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('Password Changed Successfully');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "HideChangePasswordModal", "$('#changePasswordModal').modal('hide');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showErrorMessage('Invalid Current Password');", true);
            }
        }
    }
}