using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebParaMelvin.Models;


namespace WebParaMelvin.Reportes
{
    public partial class ResumenAudiometria : System.Web.UI.Page
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reportes/ResumenAudiometria.rdlc");

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

            List<Models.ResumenAudiometria> resumenAudiometria = db.Database.SqlQuery<Models.ResumenAudiometria>("EXEC [dbo].[ResumenAudiometria]").ToList();
            // Return your data here (DataTable, List, etc.)
            // return new List<YourModel>();
            return resumenAudiometria;
        }
    }
}