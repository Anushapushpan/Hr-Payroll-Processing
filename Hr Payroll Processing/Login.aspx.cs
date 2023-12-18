using BusinessLayer.Master.ErrorCodeMaster;
using BusinessLayer.Master.UserMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing
{
    public partial class Login : System.Web.UI.Page
    {
        UserMasterEntity objUser = new UserMasterEntity();
        UserMasterManager objUserManager = new UserMasterManager();
        ErrorCodeMasterManager objErrorManager = new ErrorCodeMasterManager();
        protected void Page_Load(object sender, EventArgs e)
        {   
            
            if (Request.QueryString["pAction"] != null && Request.QueryString["pAction"] == "Logout")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showSuccessMessage('Logout','Logout completed');", true);

            }
          
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();               
                
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(objUserManager.isLogin(username, password))
            {
                Session["USERNAME"] = username;
                ViewState["USERNAME"] = username;
                Response.Redirect("Master/Home.aspx");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = objErrorManager.FetchLoginError();
                string message = dt.Rows[0]["ERR_DESC"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "successAlert", "showErrorMessage('"+message+"');", true);
                txtUsername.Style.Add("border-color","red");
                txtPassword.Style.Add("border-color", "red");
                
            }
        }
    }
}