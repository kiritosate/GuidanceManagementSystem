using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GuidanceManagementSystem.docsFrm
{
    public partial class irfp2 : Form
    {
        public static DataSet dataSet { get; set; }
        public irfp2(DataSet ds)
        {
            InitializeComponent();
            dataSet = ds;
        }

        public static string Cap(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input; // Return as is if the input is null or empty
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        private void irfp2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 97; i++)
            {
                // Use the Label control's name to find the control and set its text to blank
                Label label = (Label)this.Controls["label" + i];
                if (label != null)
                {
                    label.Text = string.Empty; // Clear the text
                }
            }

            DataTable siblingsData = dataSet.Tables[3];
            if (siblingsData.Rows.Count > 0)
            {
                Label[] lrow1 = new Label[] { label1, label2, label3, label4, label5 };
                Label[] lrow2 = new Label[] { label10, label9, label8, label7, label6 };
                Label[] lrow3 = new Label[] { label15, label14, label13, label12, label11 };
                Label[] lrow4 = new Label[] { label20, label19, label18, label17, label16 };
                Label[] lrow5 = new Label[] { label25, label24, label23, label22, label21 };
                Label[] lrow6 = new Label[] { label30, label29, label28, label27, label26 };

                Object[] tblrow = new Object[] { lrow1, lrow2, lrow3, lrow4, lrow5, lrow6 };

                for (int i = 0; i < siblingsData.Rows.Count; i++)
                {
                    if (i == 5)
                    {
                        break;
                    }
                    DataRow siblingsRow = siblingsData.Rows[i];

                    // Cast the object back to Label[]
                    Label[] currentRow = (Label[])tblrow[i];

                    currentRow[0].Text = Cap(siblingsRow["Name"].ToString());
                    currentRow[1].Text = Cap(siblingsRow["Age"].ToString());
                    currentRow[2].Text = Cap(siblingsRow["School"].ToString());
                    currentRow[3].Text = Cap(siblingsRow["Educational_Attainment"].ToString());
                    currentRow[4].Text = Cap(siblingsRow["Employment_Business_Agency"].ToString());
                }
            }

            DataTable educationalData = dataSet.Tables[4];
            if (educationalData.Rows.Count > 0)
            {

                DataRow educationalRow = educationalData.Rows[0];
                label31.Text = Cap(educationalRow["Elementary"].ToString());
                label31.Text = Cap(educationalRow["ElementaryYearGraduated"].ToString());
                label31.Text = Cap(educationalRow["ElementaryHonorAwards"].ToString());

                label36.Text = Cap(educationalRow["Highschool"].ToString());
                label35.Text = Cap(educationalRow["JuniorHighYearGraduated"].ToString());
                label34.Text = Cap(educationalRow["JuniorHighHonorAwards"].ToString());

                label39.Text = Cap(educationalRow["SeniorHighSchool"].ToString());
                label38.Text = Cap(educationalRow["SeniorHighYearGraduated"].ToString());
                label37.Text = Cap(educationalRow["SeniorHighHonorAwards"].ToString());

                label40.Text = Cap(educationalRow["StrandCompleted"].ToString());
                label41.Text = Cap(educationalRow["SHSAverageGrade"].ToString());

                label42.Text = Cap(educationalRow["VocationalTechnical"].ToString());

                label43.Text = Cap(educationalRow["College"].ToString());
                label46.Text = "";//Cap(educationalRow["SeniorHighHonorAwards"].ToString());

                label49.Text = Cap(educationalRow["FavoriteSubject"].ToString());
                label47.Text = Cap(educationalRow["WhyFavoriteSubject"].ToString());

                label50.Text = Cap(educationalRow["LeastFavoriteSubject"].ToString());
                label48.Text = Cap(educationalRow["WhyLeastFavoriteSubject"].ToString());

                label50.Text = Cap(educationalRow["SupportForStudies"].ToString());

                if (Cap(educationalRow["LeftRightHanded"].ToString()) == "Right Handed")
                {
                    label52.Text = "✔";
                }
                else if (Cap(educationalRow["LeftRightHanded"].ToString()) == "Left Handed")
                {
                    label53.Text = "✔";
                }

                label54.Text = Cap(educationalRow["Membership"].ToString());

            }

            DataTable healthData = dataSet.Tables[5];
            if (healthData.Rows.Count > 0)
            {
                DataRow hrow = healthData.Rows[0];
                switch (hrow["Sick_Frequency"].ToString())
                {
                    case "Yes":
                        label55.Text = "✔";
                        break;
                    case "No":
                        label57.Text = "✔";
                        break;
                    case "Seldom":
                        label58.Text = "✔";
                        break;
                    case "Sometimes":
                        label59.Text = "✔";
                        break;
                    case "Never":
                        label60.Text = "✔";
                        break;
                }

                string temp = hrow["Health_Problems"].ToString();

                // Split the string by comma and trim any whitespace
                string[] healthProblems = temp.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(s => s.Trim())
                                               .ToArray();

                // Check if the searchString exists in the array
                label61.Text = healthProblems.Contains("Dysmenorrhea") ? "✔" : "";
                label62.Text = healthProblems.Contains("Headache") ? "✔" : "";
                label63.Text = healthProblems.Contains("Ashtma") ? "✔" : "";
                label66.Text = healthProblems.Contains("Heart Problems") ? "✔" : "";
                label65.Text = healthProblems.Contains("Stomachache") ? "✔" : "";
                label64.Text = healthProblems.Contains("ColdsFlu") ? "✔" : "";
                label69.Text = healthProblems.Contains("Abdominal Pain") ? "✔" : "";
                label68.Text = healthProblems.Contains("Seizure Disorder") ? "✔" : "";
                label67.Text = healthProblems.Contains("Stomachache") ? "✔" : "";

                string temp2 = hrow["Physical_Disabilities"].ToString();

                // Split the string by comma and trim any whitespace
                string[] pdis = temp.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(s => s.Trim())
                                               .ToArray();
                label71.Text = pdis.Contains("Visual Impairment") ? "✔" : "";
                label70.Text = pdis.Contains("Physical Deformities") ? "✔" : "";

                label74.Text = pdis.Contains("Hearing Impairment") ? "✔" : "";
                label73.Text = pdis.Contains("Polio") ? "✔" : "";
                label72.Text = pdis.Contains("Other") ? "✔" : "";

                label77.Text = pdis.Contains("Cleft Palate") ? "✔" : "";
                label76.Text = pdis.Contains("None") ? "✔" : "";
            } 
        
        }
    }
}
