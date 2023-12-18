using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using BusinessLayer.Transaction.PrEmployeePayroll;
using Hr_Payroll_Processing.CrystalReport;

namespace Hr_Payroll_Processing.Transaction
{
    public partial class CrystalReport : System.Web.UI.Page
    {
        PrEmployeePayrollManager objPayrollManager = new PrEmployeePayrollManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["emp"])))
                {
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();

                    string empNo = Request.QueryString["emp"];
                    string yyyymm = Request.QueryString["yyyymm"];
                    dt1 = objPayrollManager.GetEmpDetails(empNo);
                    dt2 = objPayrollManager.GetPayrollDetails(empNo, yyyymm);

                    if (dt2.Rows.Count > 0)
                    {
                        DataSet1 dr = new DataSet1();

                        dr.Tables["PR_EMPLOYEE"].Merge(dt1);
                        dr.Tables["PR_EMPLOYEE_PAYROLL"].Merge(dt2);

                        string reportPath = Server.MapPath("~") + "CrystalReport\\CrystalReport1.rpt";
                        ReportDocument report = new ReportDocument();
                        report.Load(reportPath);
                        report.SetDataSource(dr);
                        report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Payroll");

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}