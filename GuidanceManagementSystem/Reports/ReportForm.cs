using GuidanceManagementSystem.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace GuidanceManagementSystem.Reports
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public void LoadReport(string course = null)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(@"C:\Users\malvin\Source\Repos\GuidanceManagementSystem\GuidanceManagementSystem\Reports\CrystalReport1.rpt");

                // Set database connection
                ConnectionInfo connectionInfo = new ConnectionInfo
                {
                    ServerName = "localhost",
                    DatabaseName = "guidancedb",
                    UserID = "root",
                    Password = ""
                };

                foreach (Table table in reportDocument.Database.Tables)
                {
                    TableLogOnInfo logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                // Clear any previous selection formula
                reportDocument.RecordSelectionFormula = "";

                // Apply the course filter if provided
                if (!string.IsNullOrEmpty(course))
                {
                    reportDocument.RecordSelectionFormula = $"{{tbl_individual_record.Course}} = '{course}'";
                }

                // Refresh and load the report with the applied filter
                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}");
            }
        }
    }
}