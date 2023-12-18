using BusinessLayer.Master.UserMaster;
using BusinessLayer.Transaction.PrEmployee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr_Payroll_Processing.Master
{
    public partial class UserMaster : System.Web.UI.Page
    {
        UserMasterManager objUserManager = new UserMasterManager();
        PrEmployeeManager objPrEmployee = new PrEmployeeManager();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime date = System.DateTime.Now;
            //lblDate.Text = date.ToString("dd/MMM/yyyy");
            //lblDay.Text = date.DayOfWeek.ToString();
           

            if (!IsPostBack)
            {
               //Count of Total Employees
               if(string.IsNullOrEmpty(Convert.ToString(objPrEmployee.FetchEmpCount())))
                {
                    lblTotalEmployee.Text = "0";
                }
               else
                {
                    lblTotalEmployee.Text = Convert.ToString(objPrEmployee.FetchEmpCount());
                }

               //Count of active employees
                if (string.IsNullOrEmpty(Convert.ToString(objPrEmployee.FetchActiveEmpCount())))
                {
                    lblActiveEmp.Text = "0";
                }
                else
                {
                    lblActiveEmp.Text = Convert.ToString(objPrEmployee.FetchActiveEmpCount());
                }

                //Count of Total Managers
                if (string.IsNullOrEmpty(Convert.ToString(objPrEmployee.FetchManagerCount())))
                {
                    lblTotalManagers.Text = "0";
                }
                else
                {
                    lblTotalManagers.Text = Convert.ToString(objPrEmployee.FetchManagerCount());
                }

                //Count of Active managers
                if (string.IsNullOrEmpty(Convert.ToString(objPrEmployee.FetchActiveManagerCount())))
                {
                    lblActiveManagers.Text = "0";
                }
                else
                {
                    lblActiveManagers.Text = Convert.ToString(objPrEmployee.FetchActiveManagerCount());
                }

                //To find max month of salary processed
                if (string.IsNullOrEmpty(Convert.ToString(objPrEmployee.FetchMaxMonthOfSalaryoProcessed())))
                {
                    lblMaxMonth.Text = "Currently No Salary Processed in this Year";
                    lblMonthAndYear.Text = "Currently No Salary Processed in this Year";
                    lblCalenderDays.Text = "0";
                    lblEmpCount.Text = "";
                    lblTotPayrollCost.Text = "0";
                }
                else
                {
                    string max = Convert.ToString(objPrEmployee.FetchMaxMonthOfSalaryoProcessed());
                    
                    int year = int.Parse(max.Substring(0, 4));
                    int month = int.Parse(max.Substring(4, 2));

                    DateTime date = new DateTime(year, month, 30);
                    
                    string monthName = date.ToString("MMMM");
                    string mmName = date.ToString("MMM");
                    lblMaxMonth.Text = $"Salary in {monthName} Processed.";
                    //Latest Payroll card
                    int countOfDays = DateTime.DaysInMonth(year, month);
                    lblCalenderDays.Text = countOfDays.ToString();
                    lblMonthAndYear.Text = mmName + " " + Convert.ToInt32(year)+ " Payroll";
                    lblEmpCount.Text= Convert.ToString(objPrEmployee.FetchEmpCountWRTAttendence(max)) +"/"+ Convert.ToString(objPrEmployee.FetchActiveEmpCount());
                    
                    double TotSum = objPrEmployee.TotalPayrollSum(max);
                    string commaSeparated = TotSum.ToString("#,000.00");
                    lblTotPayrollCost.Text = commaSeparated;
                }
            }
            
        }

        
    }
}