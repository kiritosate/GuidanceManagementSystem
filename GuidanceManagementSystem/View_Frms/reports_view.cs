using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GuidanceManagementSystem.methods;
using GuidanceManagementSystem.Reports;
using System.Drawing.Printing;
using ClosedXML.Excel;



namespace GuidanceManagementSystem.View_Frms
{
    public partial class reports_view : Form
    {
        public reports_view()
        {
            InitializeComponent();
            
        }
       
            
            public void LoadDataToReportView(string course = null)
            {
                try
                {
                     MyFetch fetch = new MyFetch();
                    // Get data from database
                    MySqlDataAdapter dataAdapter = fetch.GetIndividualDataActive(course);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Clear existing columns if any
                    dataGridView1.Columns.Clear();

                    // Ensure auto-generation is off
                    dataGridView1.AutoGenerateColumns = false;

                    // Add columns manually
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Student ID",
                        DataPropertyName = "Student_ID",
                        Name = "colStudentID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Course",
                        DataPropertyName = "Course",
                        Name = "colCourse"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Year",
                        DataPropertyName = "Year",
                        Name = "colYear"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "First Name",
                        DataPropertyName = "Firstname",
                        Name = "colFirstname"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Middle Name",
                        DataPropertyName = "Middlename",
                        Name = "colMiddlename"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Last Name",
                        DataPropertyName = "Lastname",
                        Name = "colLastname"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Sex",
                        DataPropertyName = "Sex",
                        Name = "colSex"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Status",
                        DataPropertyName = "Status",
                        Name = "colStatus"
                    });

                    // Bind the data source
                    dataGridView1.DataSource = dataTable;

                    // Optional: Adjust column width or styling
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }

        private void reports_view_Load(object sender, EventArgs e)
        {
            LoadDataToReportView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.LoadReport(); // Optionally pass a filter like "IT" for course
            reportForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void exportexcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Save as Excel"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Records");
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                        }
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Excel exported successfully!");
                }
            }
        }

        private void exportpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save as PDF"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Add headers
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    // Add rows
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();

                    MessageBox.Show("PDF exported successfully!");
                }
            }

        }
        private void LoadColleges()
        {
            try
            {
                using (var conn = MyCon.GetConnection())
                {
                    // Check if the connection was successfully established
                    if (conn == null)
                    {
                        MessageBox.Show("Failed to connect to the database.");
                        return;
                    }

                    string query = "SELECT DISTINCT CollegeName FROM tbl_individual_record";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbCourses.Items.Add(reader["course"].ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading colleges: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCourse = cmbCourses.SelectedItem?.ToString();  // Get selected course
            

            LoadDataToReportView(selectedCourse);
        }
    }
}

