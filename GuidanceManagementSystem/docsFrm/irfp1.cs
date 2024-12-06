using CrystalDecisions.ReportAppServer.DataDefModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataSet = System.Data.DataSet;

namespace GuidanceManagementSystem.docsFrm
{
    public partial class irfp1 : Form
    {
        public static DataSet dataSet { get; set; }
        public irfp1(DataSet ds)
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

        private void irfp1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 72; i++)
            {
                // Use the Label control's name to find the control and set its text to blank
                Label label = (Label)this.Controls["label" + i];
                if (label != null)
                {
                    label.Text = string.Empty; // Clear the text
                }
            }

            DataTable individualTable = dataSet.Tables[0];
            if (individualTable.Rows.Count > 0)
            {
                DataRow individualRow = individualTable.Rows[0];
                label1.Text = individualRow["Student_ID"].ToString();
                label3.Text = individualRow["Course"].ToString() + " - " + individualRow["Year"].ToString();

                switch (individualRow["Student_Status"].ToString())
                {
                    case "New Student":
                        label4.Text = "✔";
                        break;
                    case "Re-Entry":
                        label5.Text = "✔";
                        break;
                    case "Transferee":
                        label2.Text = "✔";
                        break;
                    case "Shifter":
                        label6.Text = "✔";
                        break;
                    default:
                        break;
                }

                // Access Personal Data (Table B)
                DataTable personalDataTable = dataSet.Tables[1];
                if (personalDataTable.Rows.Count > 0)
                {
                    DataRow personalDataRow = personalDataTable.Rows[0];
                    //Console.WriteLine($"Personal Data: {personalDataRow["Firstname"]} {personalDataRow["Lastname"]}");
                    label7.Text = Cap(personalDataRow["Lastname"].ToString());
                    label8.Text = Cap(personalDataRow["Firstname"].ToString());
                    label9.Text = Cap(personalDataRow["Middlename"].ToString());
                    label10.Text = Cap(personalDataRow["Nickname"].ToString());

                    label11.Text = Cap(personalDataRow["Sex"].ToString());
                    label12.Text = Cap(personalDataRow["Age"].ToString());
                    label13.Text = Cap(personalDataRow["Nationality"].ToString());
                    label14.Text = Cap(personalDataRow["Citizenship"].ToString());

                    label15.Text = Cap(personalDataRow["Date_of_Birth"].ToString());
                    label16.Text = Cap(personalDataRow["Place_of_Birth"].ToString());

                    label17.Text = Cap(personalDataRow["Civil_Status"].ToString());

                    if(personalDataRow["Civil_Status"].ToString()=="With Child")
                    {
                        label18.Text = "✔";
                    }
                    else
                    {
                        label19.Text = "✔";
                    }

                    label20.Text = Cap(personalDataRow["Number_of_Children"].ToString());

                    label21.Text = Cap(personalDataRow["Spouse_Name"].ToString());
                    label22.Text = Cap(personalDataRow["E_mail_Address"].ToString());
                    label23.Text = Cap(personalDataRow["Contact_No"].ToString());
                    label24.Text = Cap(personalDataRow["Religion"].ToString());

                    label31.Text = Cap(personalDataRow["Describe_Yourself"].ToString());
                    label25.Text = Cap(personalDataRow["Complete_Home_Address"].ToString());
                    label26.Text = Cap(personalDataRow["Boarding_House_Address"].ToString());
                    label27.Text = Cap(personalDataRow["Landlord_Name"].ToString());
                    label28.Text = Cap(personalDataRow["Person_to_Contact"].ToString());
                    label29.Text = Cap(personalDataRow["Cell_no"].ToString());
                    label30.Text = Cap(personalDataRow["Hobbies_Skills_Talents"].ToString());

                }

                // Access and Loop Through Family Data (Table C)
                DataTable familyDataTable = dataSet.Tables[2];
                foreach (DataRow familyRow in familyDataTable.Rows)
                {
                    //Console.WriteLine($"Family Member: {familyRow["Parents_Name"]}, Type: {familyRow["Parent_Type"]}");
                    if (familyRow["Parent_Type"].ToString() == "Father")
                    {
                        label36.Text = Cap(familyRow["Parents_Name"].ToString());
                        label37.Text = Cap(familyRow["Tel_Cell_No"].ToString());
                        label38.Text = Cap(familyRow["Nationality"].ToString());
                        label39.Text = Cap(familyRow["Educational_Attainment"].ToString());
                        label40.Text = Cap(familyRow["Occupation"].ToString());
                        label41.Text = Cap(familyRow["Employer_Agency"].ToString());

                        if(familyRow["Living_Status"].ToString()=="Living")
                        {
                            label32.Text = "✔";
                        }
                        else
                        {
                            label33.Text = "✔";
                        }

                        if (familyRow["Working_Abroad"].ToString() == "Yes")
                        {
                            label48.Text = "✔";
                        }
                        else
                        {
                            label49.Text = "✔";
                        }

                        if (familyRow["Marital_Status"].ToString() == "Living Together")
                        {
                            label52.Text = "✔";
                        }else if(familyRow["Marital_Status"].ToString() == "Separated")
                        {
                            label54.Text = "✔";
                        }
                        else if(familyRow["Marital_Status"].ToString() == "Father with Another")
                        {
                            label53.Text = "✔";
                        }
                    }else if(familyRow["Parent_Type"].ToString() == "Mother")
                    {
                        label47.Text = Cap(familyRow["Parents_Name"].ToString());
                        label46.Text = Cap(familyRow["Tel_Cell_No"].ToString());
                        label45.Text = Cap(familyRow["Nationality"].ToString());
                        label44.Text = Cap(familyRow["Educational_Attainment"].ToString());
                        label43.Text = Cap(familyRow["Occupation"].ToString());
                        label42.Text = Cap(familyRow["Employer_Agency"].ToString());

                        if (familyRow["Living_Status"].ToString() == "Living")
                        {
                            label34.Text = "✔";
                        }
                        else
                        {
                            label35.Text = "✔";
                        }

                        if (familyRow["Working_Abroad"].ToString() == "Yes")
                        {
                            label50.Text = "✔";
                        }
                        else
                        {
                            label51.Text = "✔";
                        }

                        if (familyRow["Marital_Status"].ToString() == "Living Together")
                        {
                            label55.Text = "✔";
                        }
                        else if (familyRow["Marital_Status"].ToString() == "Separated")
                        {
                            label57.Text = "✔";
                        }
                        else if (familyRow["Marital_Status"].ToString() == "Mother with Another")
                        {
                            label56.Text = "✔";
                        }
                    }
                    
                    switch(familyRow["Marital_Status"].ToString())
                    {
                        case "Below 5000":
                            label63.Text = "✔";
                            break;
                        case "5001 - 10000":
                            label62.Text = "✔";
                            break;
                        case "10001 - 15000":
                            label61.Text = "✔";
                            break;
                        case "15001 - 20000":
                            label60.Text = "✔";
                            break;
                        case "20001 - 25000":
                            label58.Text = "✔";
                            break;
                        case "25000 Above":
                            label59.Text = "✔";
                            break;
                    }

                    label70.Text = familyRow["No_of_Children"].ToString();
                    label71.Text = familyRow["Students_Birth_Order"].ToString();
                    label72.Text = familyRow["Language_Dialect"].ToString();

                    if(familyRow["Family_Structure"].ToString() == "Extended")
                    {
                        label65.Text = "✔";
                    }
                    else if(familyRow["Family_Structure"].ToString() == "Nuclear")
                    {
                        label64.Text = "✔";
                    }

                    if (familyRow["Indigenous_Group"].ToString() == "Yes")
                    {
                        label67.Text = "✔";
                    }
                    else if (familyRow["Indigenous_Group"].ToString() == "No")
                    {
                        label66.Text = "✔";
                    }

                    if (familyRow["4Ps_Beneficiary"].ToString() == "Yes")
                    {
                        label69.Text = "✔";
                    }
                    else if (familyRow["4Ps_Beneficiary"].ToString() == "No")
                    {
                        label68.Text = "✔";
                    }
                }
            }
        }
    }
}
