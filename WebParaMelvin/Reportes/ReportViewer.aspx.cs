using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebParaMelvin.Models;

namespace WebParaMelvin.Reportes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configure local report
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                // Or configure remote SSRS report
                // ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                // ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://your-ssrs-server/reportserver");
                // ReportViewer1.ServerReport.ReportPath = "/YourReports/YourReport";

                LoadReport();
            }
        }

        private void LoadReport()
        {
            try
            {
                // Example with local report
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reportes/Report1.rdlc");

                // Add data source
                var data = GetReportData(); // Your data retrieval method
                ReportDataSource rds = new ReportDataSource("DataSet1", data);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);

                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }

        private object GetReportData()
        {
            List<Employee> employees = new List<Employee>()
            {
                 new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 50000, HireDate = new DateTime(2020, 1, 15) },
            new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 45000, HireDate = new DateTime(2019, 5, 20) },
            new Employee { Id = 3, Name = "Bob Johnson", Department = "Finance", Salary = 60000, HireDate = new DateTime(2021, 3, 10) }
            };
            // Return your data here (DataTable, List, etc.)
            // return new List<YourModel>();
            return employees;
        }
    }
}