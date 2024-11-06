using GuidanceManagementSystem.methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class dashboard_view : Form
    {
        public dashboard_view()
        {
            InitializeComponent();
        }

        private void dashboard_view_Load(object sender, EventArgs e)
        {
            // Call loadData asynchronously when the form loads
            timer1.Start();
        }

        public static void loadData()
        {
            // Assuming GetPopulationDataByCourseYearAndGender() is asynchronous
            var data = MyFetch.GetPopulationDataByCourseYearAndGender();

            // Arrays to store male and female counts for each course and year
            int[] cicsMaleCounts = new int[4]; // 1st Year, 2nd Year, 3rd Year, 4th Year
            int[] cicsFemaleCounts = new int[4];

            int[] coaMaleCounts = new int[4];
            int[] coaFemaleCounts = new int[4];

            int[] ctedMaleCounts = new int[4];
            int[] ctedFemaleCounts = new int[4];

            int[] chmMaleCounts = new int[4];
            int[] chmFemaleCounts = new int[4];

            // Fill the arrays with data
            for (int year = 0; year < 4; year++)
            {
                cicsMaleCounts[year] = data["CICS"][$"{year + 1}st Year"]["Male"];
                cicsFemaleCounts[year] = data["CICS"][$"{year + 1}st Year"]["Female"];

                coaMaleCounts[year] = data["COA"][$"{year + 1}st Year"]["Male"];
                coaFemaleCounts[year] = data["COA"][$"{year + 1}st Year"]["Female"];

                ctedMaleCounts[year] = data["CTED"][$"{year + 1}st Year"]["Male"];
                ctedFemaleCounts[year] = data["CTED"][$"{year + 1}st Year"]["Female"];

                chmMaleCounts[year] = data["CHM"][$"{year + 1}st Year"]["Male"];
                chmFemaleCounts[year] = data["CHM"][$"{year + 1}st Year"]["Female"];
            }
            /*
            // Example: Updating labels for CICS 1st Year Male and Female counts
            lblCics1stYearMale.Text = $"CICS 1st Year Male: {cicsMaleCounts[0]}";
            lblCics1stYearFemale.Text = $"CICS 1st Year Female: {cicsFemaleCounts[0]}";

            lblCics2ndYearMale.Text = $"CICS 2nd Year Male: {cicsMaleCounts[1]}";
            lblCics2ndYearFemale.Text = $"CICS 2nd Year Female: {cicsFemaleCounts[1]}";

            lblCics3rdYearMale.Text = $"CICS 3rd Year Male: {cicsMaleCounts[2]}";
            lblCics3rdYearFemale.Text = $"CICS 3rd Year Female: {cicsFemaleCounts[2]}";

            lblCics4thYearMale.Text = $"CICS 4th Year Male: {cicsMaleCounts[3]}";
            lblCics4thYearFemale.Text = $"CICS 4th Year Female: {cicsFemaleCounts[3]}";

            // Similarly, update other courses like COA, CTED, CHM in the UI
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            var _course_ttl_counts = MyFetch.CountPopulationPerCourse();

            // Assuming you have labels like:
            // lblCICS, lblCOA, lblCTED, lblCHM for course total counts.

            // Displaying CICS course population
            if (_course_ttl_counts.ContainsKey("CICS"))
            {
                _cicsTtl.Content = _course_ttl_counts["CICS"].ToString();
            }

            // Displaying COA course population
            if (_course_ttl_counts.ContainsKey("COA"))
            {
                _coaTtl.Content = _course_ttl_counts["COA"].ToString();
            }

            // Displaying CTED course population
            if (_course_ttl_counts.ContainsKey("CTED"))
            {
                _ctedTtl.Content = _course_ttl_counts["CTED"].ToString();
            }

            // Displaying CHM course population
            if (_course_ttl_counts.ContainsKey("CHM"))
            {
                _chmTtl.Content = _course_ttl_counts["CHM"].ToString();
            }
        }
    }
}
