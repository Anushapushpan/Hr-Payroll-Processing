using BusinessLayer.Transaction.PrEmployeeAttendence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class EditAttendence : System.Web.UI.Page
    {
        PrEmployeeAttendenceEntity objAttendencEntity = new PrEmployeeAttendenceEntity();
        PrEmployeeAttendenceManager objAttendencManager = new PrEmployeeAttendenceManager();
        Attendence objAttndnc = new Attendence();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtEmpNo.Text = Convert.ToString(Request.QueryString["ehEmpNo"]);
            }
           
        }

        protected void calculatePresentDays(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                //int totalDays = 0;
                objAttendencEntity.attEmpNo = Convert.ToString(Request.QueryString["ehEmpNo"]);
                objAttendencEntity.attYyyyMm= Convert.ToString(Request.QueryString["yyyymm"]);
                string month = Convert.ToString(Request.QueryString["month"]);
                string year = Convert.ToString(Request.QueryString["year"]);
                int totdays = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
                dt = objAttendencManager.FetchPresentDays(objAttendencEntity.attEmpNo, objAttendencEntity.attYyyyMm);
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        totalDays = Convert.ToInt32(dr["ATT_DAYS_PRESENT"]);
                //    }
                //}

                int absentDays = Convert.ToInt32(txtAbsent.Text);
                int presentDays = totdays - absentDays;
                if(presentDays<0 || absentDays<0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Enter Valid Number of Days!!!');", true);
                    txtAbsent.Text = "";
                }
                else
                {
                    txtPresent.Text = presentDays.ToString();
                }
                   
                
                
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Some Error Occured!!!');", true);
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objAttendencEntity.attEmpNo = Convert.ToString(Request.QueryString["ehEmpNo"]);
                string ehEmpNo = objAttendencEntity.attEmpNo;
                string yyyymm= Convert.ToString(Request.QueryString["yyyymm"]);
                string month= Convert.ToString(Request.QueryString["month"]);
                string year = Convert.ToString(Request.QueryString["year"]);
                objAttendencEntity.attYyyyMm = yyyymm;
                objAttendencEntity.attDaysAbsent = Convert.ToInt32(txtAbsent.Text);
                objAttendencEntity.attDaysPresent = Convert.ToInt32(txtPresent.Text);
                objAttendencEntity.attCrBy = Session["USERNAME"].ToString();
                objAttendencEntity.attCrDt = System.DateTime.Now;
                objAttendencEntity.attUpBy= Session["USERNAME"].ToString();
                objAttendencEntity.attUpDt= System.DateTime.Now;
                if (objAttendencManager.isValidUnique(ehEmpNo, objAttendencEntity.attYyyyMm))
                {
                    int rows = objAttendencManager.InsertAttendenceToDb(objAttendencEntity);
                    if (rows > 0)
                    {
                        Response.Redirect("AttendenceDetails.aspx?&&yyyymm=" + yyyymm + "&&month=" + month + "&&year=" + year);
                    }
                }
                else
                {
                    int rows = objAttendencManager.UpdateAttendence(objAttendencEntity);
                    if (rows > 0)
                    {
                        //Response.Redirect("AttendenceDetails.aspx");
                        Response.Redirect("AttendenceDetails.aspx?&&yyyymm=" + yyyymm + "&&month=" + month + "&&year=" + year);
                        //Response.Redirect("AttendenceDetails.aspx?yyyymm=" + yyyymm);
                    }
                }
                    
            }
            catch (Exception)
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "WarningAlert", "showWarningMessage('Sorry!','Some Error Occured!!!');", true);
            }

        }

        protected void btnAddEmployee_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("AttendenceDetails.aspx");
        }
    }
}