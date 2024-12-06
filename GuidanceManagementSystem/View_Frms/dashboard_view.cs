using GuidanceManagementSystem.methods;
using LiveCharts.Wpf;
using LiveCharts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;


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
            //LoadStatistics("courseStatistics");
            //GetTotalStudents();
            //LoadCivilStatusPieChart();
            //LoadStudentStatusPieChart();
            //GetStudentCountByCollege();
            //LoadPendingCount();
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

        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    var _course_ttl_counts = MyFetch.CountPopulationPerCourse();

        //    // Assuming you have labels like:
        //    // lblCICS, lblCOA, lblCTED, lblCHM for course total counts.

        //    // Displaying CICS course population
        //    if (_course_ttl_counts.ContainsKey("CICS"))
        //    {
        //        coa.Content = _course_ttl_counts["CICS"].ToString();
        //    }

        //    // Displaying COA course population
        //    if (_course_ttl_counts.ContainsKey("COA"))
        //    {
        //        _coaTtl.Content = _course_ttl_counts["COA"].ToString();
        //    }

        //    // Displaying CTED course population
        //    if (_course_ttl_counts.ContainsKey("CTED"))
        //    {
        //        _ctedTtl.Content = _course_ttl_counts["CTED"].ToString();
        //    }

        //    // Displaying CHM course population
        //    if (_course_ttl_counts.ContainsKey("CHM"))
        //    {
        //        _chmTtl.Content = _course_ttl_counts["CHM"].ToString();
        //    }
        //}

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        private void LoadStatistics(string type = "courseStatistics")
        {
           
            try
            {
                string query = "";

                switch (type)
                {
                    case "courseStatistics":
                        query = @"
                SELECT 
                    tbl_individual_record.Course, 
                    COUNT(tbl_personal_data.Student_ID) AS TotalStudents
                FROM tbl_personal_data
                INNER JOIN tbl_individual_record 
                    ON tbl_personal_data.Student_ID = tbl_individual_record.Student_ID
                GROUP BY tbl_individual_record.Course;";
                        break;

                    case "yearStatistics":
                        query = @"
                SELECT 
                    tbl_individual_record.Year,
                    COUNT(tbl_personal_data.Student_ID) AS TotalStudents
                FROM tbl_personal_data
                INNER JOIN tbl_individual_record 
                    ON tbl_personal_data.Student_ID = tbl_individual_record.Student_ID
                GROUP BY tbl_individual_record.Year;";
                        break;

                    case "genderPerCourse":
                        query = @"
                SELECT 
                    tbl_individual_record.Course,
                    SUM(CASE WHEN tbl_personal_data.Sex = 'Male' THEN 1 ELSE 0 END) AS TotalMales,
                    SUM(CASE WHEN tbl_personal_data.Sex = 'Female' THEN 1 ELSE 0 END) AS TotalFemales
                FROM tbl_personal_data
                INNER JOIN tbl_individual_record 
                    ON tbl_personal_data.Student_ID = tbl_individual_record.Student_ID
                GROUP BY tbl_individual_record.Course;";
                        break;

                    default:
                        throw new Exception("Invalid statistics type.");
                }


                {
                    MySqlCommand cmd = new MySqlCommand(query, MyCon.GetConnection());
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string> labels = new List<string>();
                    List<double> values1 = new List<double>();
                    List<double> values2 = new List<double>();

                    if (type == "courseStatistics" || type == "yearStatistics")
                    {
                        while (reader.Read())
                        {
                            labels.Add(reader[type == "courseStatistics" ? "Course" : "Year"].ToString());
                            values1.Add(Convert.ToDouble(reader["TotalStudents"]));
                        }

                        cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Total Students",
                        Values = new ChartValues<double>(values1)
                    }
                };

                        cartesianChart1.AxisX.Clear();
                        cartesianChart1.AxisX.Add(new Axis
                        {
                            Title = type == "courseStatistics" ? "Courses" : "Years",
                            Labels = labels.ToArray()
                        });

                        cartesianChart1.AxisY.Clear();
                        cartesianChart1.AxisY.Add(new Axis
                        {
                            Title = "Total Students",
                            LabelFormatter = value => value.ToString("N0")
                        });
                    }
                    else if (type == "genderPerCourse")
                    {
                        while (reader.Read())
                        {
                            labels.Add(reader["Course"].ToString());
                            values1.Add(Convert.ToDouble(reader["TotalMales"]));
                            values2.Add(Convert.ToDouble(reader["TotalFemales"]));
                        }

                        cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Males",
                        Values = new ChartValues<double>(values1)
                    },
                    new ColumnSeries
                    {
                        Title = "Females",
                        Values = new ChartValues<double>(values2)
                    }
                };

                        cartesianChart1.AxisX.Clear();
                        cartesianChart1.AxisX.Add(new Axis
                        {
                            Title = "Courses",
                            Labels = labels.ToArray()
                        });

                        cartesianChart1.AxisY.Clear();
                        cartesianChart1.AxisY.Add(new Axis
                        {
                            Title = "Total Students",
                            LabelFormatter = value => value.ToString("N0")
                        });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetStudentCountByCollege()
        {
        
            string query = @"
        SELECT Course, COUNT(*) AS TotalStudents
        FROM tbl_individual_record
        WHERE Status = 1
        GROUP BY Course";

            try
            {
             

                    using (MySqlCommand cmd = new MySqlCommand(query, MyCon.GetConnection()))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Loop through the results and assign to respective labels
                            while (reader.Read())
                            {
                                string course = reader["Course"].ToString();
                                int studentCount = Convert.ToInt32(reader["TotalStudents"]);

                                // Display the count in labels for each college
                                if (course == "COA")
                                {
                                    coa.Text =  $"{studentCount}";
                                }
                                else if (course == "CHM")
                                {
                                    chm.Text = $"{studentCount}";
                                }
                                else if (course == "CICS")
                                {
                                    cics.Text = $"{studentCount}";
                                }
                                else if (course == "CTED")
                                {
                                    cted.Text = $"{studentCount}";
                                }
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPendingCount()
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
            string query = "SELECT COUNT(*) FROM tbl_individual_record WHERE Status = 0"; // 0 represents Pending

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        int pendingCount = result != null ? Convert.ToInt32(result) : 0;

                        // Display the count in the label
                        lblPendingCount.Text = $"{pendingCount}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending count: {ex.Message}");
            }
        }

        private void GetTotalStudents()
        {
    
            string query = "SELECT COUNT(*) AS TotalStudents FROM tbl_individual_record WHERE Status = 1";
            try
            {
              
                    using (MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection()))
                    {
                        object result = command.ExecuteScalar();
                        int totalStudents = result != null ? Convert.ToInt32(result) : 0;

                        // Assign the total to a label
                        lblTotalStudents.Text = $"{totalStudents}";
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCivilStatusPieChart()
        {

            string query = @"
            SELECT Civil_Status, COUNT(*) AS Total
            FROM tbl_personal_data
            WHERE Civil_Status IN ('Married', 'Single', 'Widowed')
            GROUP BY Civil_Status";

            try
            {
                
                   
                    using (MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection()))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Lists to hold labels and values for the Pie Chart
                            ChartValues<double> statusCounts = new ChartValues<double>();
                            List<string> statusLabels = new List<string>();

                            while (reader.Read())
                            {
                                statusLabels.Add(reader["Civil_Status"].ToString());
                                statusCounts.Add(Convert.ToDouble(reader["Total"]));
                            }

                            // Populate the pie chart
                            pieChart1.Series = new SeriesCollection
                        {
                            new PieSeries
                            {
                                Title = "Married",
                                Values = new ChartValues<double> { statusLabels.Contains("Married") ? statusCounts[statusLabels.IndexOf("Married")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            },
                            new PieSeries
                            {
                                Title = "Single",
                                Values = new ChartValues<double> { statusLabels.Contains("Single") ? statusCounts[statusLabels.IndexOf("Single")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            },
                            new PieSeries
                            {
                                Title = "Widowed",
                                Values = new ChartValues<double> { statusLabels.Contains("Widowed") ? statusCounts[statusLabels.IndexOf("Widowed")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            }
                        };

                            // Optional: Set the chart legend position
                            pieChart1.LegendLocation = LegendLocation.Bottom;
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudentStatusPieChart()
        {
          
            string query = @"
            SELECT Student_Status, COUNT(*) AS Total
            FROM tbl_individual_record
            WHERE Student_Status IN ('New Student', 'Re-Entry', 'Transferee', 'Shifter')
            GROUP BY Student_Status";

            try
            {
               
                  
                    using (MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection()))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Lists to hold labels and values for the Pie Chart
                            ChartValues<double> statusCounts = new ChartValues<double>();
                            List<string> statusLabels = new List<string>();

                            // Read the data from the database and populate the Pie chart
                            while (reader.Read())
                            {
                                statusLabels.Add(reader["Student_Status"].ToString());
                                statusCounts.Add(Convert.ToDouble(reader["Total"]));
                            }

                            // Populate the pie chart
                            pieChart2.Series = new SeriesCollection
                        {
                            new PieSeries
                            {
                                Title = "New Student",
                                Values = new ChartValues<double> { statusLabels.Contains("New Student") ? statusCounts[statusLabels.IndexOf("New Student")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            },
                            new PieSeries
                            {
                                Title = "Re-Entry",
                                Values = new ChartValues<double> { statusLabels.Contains("Re-Entry") ? statusCounts[statusLabels.IndexOf("Re-Entry")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            },
                            new PieSeries
                            {
                                Title = "Transferee",
                                Values = new ChartValues<double> { statusLabels.Contains("Transferee") ? statusCounts[statusLabels.IndexOf("Transferee")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            },
                            new PieSeries
                            {
                                Title = "Shifter",
                                Values = new ChartValues<double> { statusLabels.Contains("Shifter") ? statusCounts[statusLabels.IndexOf("Shifter")] : 0 },
                                DataLabels = true,
                                LabelPoint = point => $"{point.Y} {point.Participation:P}"
                            }
                        };

                            // Optional: Set the chart legend position
                            pieChart2.LegendLocation = LegendLocation.Bottom;
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStatistics("yearStatistics");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStatistics("courseStatistics");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadStatistics("genderPerCourse");
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void lblTotalStudents_Click(object sender, EventArgs e)
        {

        }

        private void cuiLabel2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            GetTotalStudents();
            LoadPendingCount();
        }

        private void lblPendingCount_TextChanged(object sender, EventArgs e)
        {
            LoadCivilStatusPieChart();
            LoadStudentStatusPieChart();
            GetStudentCountByCollege();
            LoadStatistics("courseStatistics");
        }
    }
}