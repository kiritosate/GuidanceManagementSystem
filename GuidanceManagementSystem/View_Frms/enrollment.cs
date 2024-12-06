using GuidanceManagementSystem.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GuidanceManagementSystem.methods.MyMethods;
using static GuidanceManagementSystem.StudentRecord;
using System.Drawing;
using Org.BouncyCastle.Asn1.Cmp;
using static GuidanceManagementSystem.View_Frms.registration_view;
using System.Windows.Controls.Primitives;
using CrystalDecisions.ReportAppServer.Prompting;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Diagnostics.Eventing.Reader;
using System.IO;



namespace GuidanceManagementSystem
{
    public partial class enrollment : Form
    {
        private DataGridView dataGridView1;

        public string SavedStudentID { get; private set; }

        //private List<TextBox> siblingNameTextBoxes = new List<TextBox>();
        //private List<TextBox> siblingAgeTextBoxes = new List<TextBox>();
        // Add more lists as needed for other fields

        //private int SiblingCount = 0; // Initialize counte

        // private int SiblingCount = 0; // Initialize counter


        private bool isIndividualRecordSaved = false;

        MyMethods methods = new MyMethods();
        public void LoadIndividualRecord(string studentId)
        {
            DataAccess dataAccess = new DataAccess();
            PersonalData studentData = dataAccess.GetPersonalData(studentId);
            IndividualRecord record = dataAccess.GetIndividualRecord(studentId);

            if (record != null)
            {
                txtStudentID.Text = record.studentID;
                cmbCourse.Text = record.Course;
                cmbYear.Text = record.Year.ToString();
                if (record != null)
                {
                    // Set the radio button based on the StudentStatus value
                    switch (record.StudentStatus)
                    {
                        case "New Student":
                            rbIsNewStudent.Checked = true;
                            break;
                        case "Re-entry":
                            rbIsReEntry.Checked = true;
                            break;
                        case "Shifter":
                            rbisShifter.Checked = true;
                            break;
                        case "Transferee":
                            rbIsTransferee.Checked = true;
                            break;
                        default:
                            // Optional: Clear all radio buttons if the value is unexpected
                            rbIsNewStudent.Checked = false;
                            rbIsReEntry.Checked = false;
                            rbisShifter.Checked = false;
                            rbIsTransferee.Checked = false;
                            break;
                    }
                }
              
            }
            else
            {
                MessageBox.Show("Record not found!");
            }
             }
 

        public void LoadHealthDataToForm(string studentId)
             {
            DataAccess dataAccess = new DataAccess();
            HealthData healthData = dataAccess.LoadHealthData(studentId);

            if (healthData != null)
            {
            
                switch (healthData.SickFrequency)
                {
                    case "Yes":
                        rbSickOften.Checked = true;
                        break;
                    case "No":
                        rbSickNo.Checked = true;
                        break;
                    case "Seldom":
                        rbSickSeldom.Checked = true;
                        break;
                    case "Sometimes":
                        rbSickSometimes.Checked = true;
                        break;
                    case "Never":
                        rbSickNever.Checked = true;
                        break;
                    default:
                        // Optional: Clear all radio buttons if the value is unexpected
                        rbSickOften.Checked = false;
                        rbSickNo.Checked = false;
                        rbSickSeldom.Checked = false;
                        rbSickSometimes.Checked = false;
                        rbSickNever.Checked = false;
                        break;
                }

                // Optionally, set the checkboxes for Health Problems and Physical Disabilities
                if (healthData.HealthProblems != null)
                {
                    chkDysmenorrhea.Checked = healthData.HealthProblems.Contains("Dysmenorrhea");
                    chkHeadache.Checked = healthData.HealthProblems.Contains("Headache");
                    chkAsthma.Checked = healthData.HealthProblems.Contains("Asthma");
                    chkStomachache.Checked = healthData.HealthProblems.Contains("Stomachache");
                    chkHeartProblems.Checked = healthData.HealthProblems.Contains("Heart Problems");
                    chkColdsFlu.Checked = healthData.HealthProblems.Contains("Colds/Flu");
                    chkAbdominalPain.Checked = healthData.HealthProblems.Contains("Abdominal Pain");
                    chkSeizureDisorders.Checked = healthData.HealthProblems.Contains("Seizure Disorder");
                }
                if (healthData.PhysicalDisabilities != null)
                {
                    chkVisualImpairment.Checked = healthData.PhysicalDisabilities.Contains("Visual Impairment");
                    chkPolio.Checked = healthData.PhysicalDisabilities.Contains("Polio");
                    chkHearingImpairment.Checked = healthData.PhysicalDisabilities.Contains("Hearing Impairment");
                    chkCleftPalate.Checked = healthData.PhysicalDisabilities.Contains("Cleft Palate");
                    chkPhysicalDeformities.Checked = healthData.PhysicalDisabilities.Contains("Physical Deformities");
                    chkSeizureDisorders.Checked = healthData.PhysicalDisabilities.Contains("Seizure Disorder");
                }
            }
            else
            {
                // If no data is found for the student, show a message
                MessageBox.Show("No health data found for this student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void LoadStudentData(string studentId)
        {
            DataAccess dataAccess = new DataAccess();
            PersonalData studentData = dataAccess.GetPersonalData(studentId);

            if (studentData != null)
            {
                // Fill form controls with the student data
                txtFirstName.Text = studentData.Firstname;
                txtMiddleName.Text = studentData.Middlename;
                txtLastName.Text = studentData.Lastname;
                txtNickname.Text = studentData.Nickname;
                txtAge.Text = studentData.Age.ToString();
                txtNationality.Text = studentData.Nationality;
                txtCitizenship.Text = studentData.Citizenship;
                dtpDateOfBirth.Text = studentData.DateOfBirth.HasValue
                    ? studentData.DateOfBirth.Value.ToString("yyyy-MM-dd")
                    : string.Empty;
                txtPlaceOfBirth.Text = studentData.PlaceOfBirth;
                txtCivilStatus.Text = studentData.CivilStatus;

                if (studentData.Children == "With Child")
                    rbWithChild.Checked = true;
                else if (studentData.Children == "Without Child")
                    rbWithoutChild.Checked = true;

                txtSpouseName.Text = studentData.SpouseName;
                numericUpDownNumberOfChildren.Value = studentData.NumberOfChildren;
                txtReligion.Text = studentData.Religion;
                txtContactNumber.Text = studentData.ContactNumber;
                txtEmailAddress.Text = studentData.EmailAddress;
                txtCompleteHomeAddress.Text = studentData.CompleteHomeAddress;
                txtBoardingHouseAddress.Text = studentData.BoardingHouseAddress;
                txtLandlordName.Text = studentData.LandlordName;
                txtEmergencyContact.Text = studentData.PersonToContact;
                txtGuardianphone.Text = studentData.CellNumber;
                txtHobbies.Text = studentData.Hobbies;
                txtDescribeYourself.Text = studentData.DescribeYourself;

                // Set the gender radio buttons based on the student data
                if (studentData.Sex == "Male")
                    rbMale.Checked = true;
                else if (studentData.Sex == "Female")
                    rbFemale.Checked = true;
            }
            else
            {
                MessageBox.Show("Student data not found.");
            }
        }
        public void LoadFamilyDataToForm(string studentId, string parentType)
        {
            DataAccess dataAccess = new DataAccess();
            FamilyData familyData = dataAccess.GetFamilyData(studentId, parentType);

            if (familyData != null)
            {
                rbBelow5000.Checked = false;
                rb5000To10000.Checked = false;
                rb10001To15000.Checked = false;
                rb15001To20000.Checked = false;
                rb20001To25000.Checked = false;
                rbAbove25000.Checked = false;
                // Populate the text fields with the retrieved data
                txtFatherName.Text = familyData.Name ?? string.Empty;
                txtFatherPhone.Text = familyData.TelCellNo ?? string.Empty;
                txtFatherNationality.Text = familyData.Nationality ?? string.Empty;
                txtFatherEducationalAttainment.Text = familyData.EducationalAttainment ?? string.Empty;
                txtFatherOccupation.Text = familyData.Occupation ?? string.Empty;
                txtFatherEmployerAgency.Text = familyData.EmployerAgency ?? string.Empty;
                txtFatherLanguageDialect.Text = familyData.LanguageDialect ?? string.Empty;
                if (familyData.NoOfChildren.HasValue)
                    txtFatherNoOfChildren.Value = familyData.NoOfChildren.Value;
                if (familyData.StudentsBirthOrder.HasValue)
                    txtFatherBirthOrder.Text = familyData.StudentsBirthOrder.Value.ToString();

                if (familyData.LivingStatus == "Yes")
                    rbliving.Checked = true;
                else if (familyData.LivingStatus == "No")
                    rbdeceased.Checked = true;
                if (familyData.WorkingAbroad == "Yes")
                    rbFatherWorkingAbroadYes.Checked = true;
                else if (familyData.WorkingAbroad == "No")
                    rbFatherWorkingAbroadNo.Checked = true;
                if (familyData.FamilyStructure == "Nuclear")
                    rbNuclear.Checked = true;
                else if (familyData.FamilyStructure == "Extended")
                    rbExtended.Checked = true;
                if (familyData.IndigenousGroup == "Yes")
                    rbIndigenousYes.Checked = true;
                else if (familyData.IndigenousGroup == "No")
                    rbIndigenousNo.Checked = true;
                if (familyData.Beneficiary4Ps == "Yes")
                    rbBeneficiaryYes.Checked = true;
                else if (familyData.Beneficiary4Ps == "No")
                    rbBeneficiaryNo.Checked = true;
                switch (familyData.MaritalStatus)
                {
                    case "Living Together":
                        rbFatherLivingTogether.Checked = true;
                        break;
                    case "Separated":
                        rbFatherSeparated.Checked = true;
                        break;
                    case "Father with Another Partner":
                        rbFatherWithAnotherPartner.Checked = true;
                        break;
                    default:
                        // Optionally clear all radio buttons if the value is unexpected
                        rbFatherLivingTogether.Checked = false;
                        rbFatherSeparated.Checked = false;
                        rbFatherWithAnotherPartner.Checked = false;
                        break;
                }
                // Optionally, set the radio buttons based on Monthly Income or Marital Status
                Console.WriteLine(familyData.MonthlyIncome);
                switch (familyData.MonthlyIncome)
                {
                    case "Below P5000":
                        rbBelow5000.Checked = true;
                        break;
                    case "P5000 - P10000":
                        rb5000To10000.Checked = true;
                        break;
                    case "P10,001 - P15000":
                        rb10001To15000.Checked = true;
                        break;
                    case "P15001 - P20000":
                        rb15001To20000.Checked = true;
                        break;
                    case "P20001 - P25000":
                        rb20001To25000.Checked = true;
                        break;
                    case "P25000 above":
                        rbAbove25000.Checked = true;
                        break;
                    default:
                        // Optional: Handle the case where the income is null or unknown
                        break;
                }
                if (familyData.MaritalStatus == "Living Together")
                    rbFatherLivingTogether.Checked = true;
                else if (familyData.MaritalStatus == "Separated")
                    rbFatherSeparated.Checked = true;
                else if (familyData.MaritalStatus == "Father with Another Partner")
                    rbFatherWithAnotherPartner.Checked = true;
                if (familyData.LivingStatus == "Below 5000")
                    rbBelow5000.Checked = true;
                else if (familyData.LivingStatus == "5000 - 10000")
                    rb5000To10000.Checked = true;
                else if (familyData.LivingStatus == "10001 - 15000")
                    rb10001To15000.Checked = true;
                else if (familyData.LivingStatus == "15001 - 20000")
                    rb15001To20000.Checked = true;
                else if (familyData.LivingStatus == "20001 - 25000")
                    rb20001To25000.Checked = true;
                else if (familyData.LivingStatus == "25000 Above")
                    rbAbove25000.Checked = true;
            }
            else
            {
                MessageBox.Show("No family data found for this student and parent type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Mother Retrive
        public void LoadMotherDataToForm(string studentId, string parentType)
        {
            DataAccess dataAccess = new DataAccess();
            FamilyData motherData = dataAccess.GetFamilyData(studentId, parentType);

            if (motherData != null)
            {
                // Populate the text fields with the retrieved data
                txtMotherName.Text = motherData.Name ?? string.Empty;
                txtMotherTelCellNo.Text = motherData.TelCellNo ?? string.Empty;
                txtMotherNationality.Text = motherData.Nationality ?? string.Empty;
                txtMotherEducationalAttainment.Text = motherData.EducationalAttainment ?? string.Empty;
                txtMotherOccupation.Text = motherData.Occupation ?? string.Empty;
                txtMotherEmployerAgency.Text = motherData.EmployerAgency ?? string.Empty;

                if (motherData.NoOfChildren.HasValue)
                    txtFatherNoOfChildren.Text = motherData.NoOfChildren.Value.ToString();
                if (motherData.StudentsBirthOrder.HasValue)
                    txtFatherBirthOrder.Text = motherData.StudentsBirthOrder.Value.ToString();

                // Set radio button values for Living Status
                if (motherData.LivingStatus == "Yes")
                    mrbliving.Checked = true;
                else if (motherData.LivingStatus == "No")
                    mrbdeceased.Checked = true;

                // Set radio button values for Working Abroad
                if (motherData.WorkingAbroad == "Yes")
                    rbMotherWorkingAbroadYes.Checked = true;
                else if (motherData.WorkingAbroad == "No")
                    rbMotherWorkingAbroadNo.Checked = true;

                // Set radio button values for Family Structure
                if (motherData.FamilyStructure == "Nuclear")
                    rbNuclear.Checked = true;
                else if (motherData.FamilyStructure == "Extended")
                    rbExtended.Checked = true;

                // Set radio button values for Indigenous Group
                if (motherData.IndigenousGroup == "Yes")
                    rbIndigenousYes.Checked = true;
                else if (motherData.IndigenousGroup == "No")
                    rbIndigenousNo.Checked = true;

                // Set radio button values for Beneficiary 4Ps
                if (motherData.Beneficiary4Ps == "Yes")
                    rbBeneficiaryYes.Checked = true;
                else if (motherData.Beneficiary4Ps == "No")
                    rbBeneficiaryNo.Checked = true;

                // Set radio button values for Marital Status
                switch (motherData.MaritalStatus)
                {
                    case "Living Together":
                        rbMotherAnnulled.Checked = true;
                        break;
                    case "Separated":
                        rbMotherWidowed.Checked = true;
                        break;
                    case "Mother with Another Partner":
                        rbMotherWithAnotherPartner.Checked = true;
                        break;
                    default:
                        // Optionally clear all radio buttons if the value is unexpected
                        rbMotherAnnulled.Checked = false;
                        rbMotherWidowed.Checked = false;
                        rbMotherWithAnotherPartner.Checked = false;
                        break;
                }
                if (motherData.MaritalStatus == "Annulled")
                    rbMotherAnnulled.Checked = true;
                else if (motherData.MaritalStatus == "Widowed")
                    rbMotherWidowed.Checked = true;
                else if (motherData.MaritalStatus == "Mother with Another Partner")
                    rbMotherWithAnotherPartner.Checked = true;


                // Set radio button values for Monthly Income
            }
            else
            {
                MessageBox.Show("No family data found for this student and parent type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private PersonalData GetStudentDataFromForm()
        {
            var studentData = new PersonalData
            {
                studentID = SavedStudentID,
                Firstname = txtFirstName.Text,
                Middlename = txtMiddleName.Text,
                Lastname = txtLastName.Text,
                Nickname = txtNickname.Text,
                Sex = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : null,
                Age = int.TryParse(txtAge.Text, out var age) ? age : 0,
                Nationality = txtNationality.Text,
                Citizenship = txtCitizenship.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                PlaceOfBirth = txtPlaceOfBirth.Text,
                CivilStatus = txtCivilStatus.Text,
                Children = rbWithChild.Checked ? "With Child" : rbWithoutChild.Checked ? "Without Child" : null,
                SpouseName = txtCivilStatus.Text == "Married" ? txtSpouseName.Text : null,
                NumberOfChildren = (int)numericUpDownNumberOfChildren.Value,
                Religion = txtReligion.Text,
                ContactNumber = txtContactNumber.Text,
                EmailAddress = txtEmailAddress.Text,
                CompleteHomeAddress = txtCompleteHomeAddress.Text,
                BoardingHouseAddress = txtBoardingHouseAddress.Text,
                LandlordName = txtLandlordName.Text,
                PersonToContact = txtEmergencyContact.Text,
                CellNumber = txtGuardianphone.Text,
                Hobbies = txtHobbies.Text,
                DescribeYourself = txtDescribeYourself.Text
            };

            return studentData;
        }
        public Sibling GetSiblingDataFromDataGridView()
        {
            // Assuming you're retrieving data from the first selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Get the first selected row

                var siblingData = new Sibling
                {
                    SiblingsID = row.Cells["SiblingsID"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["SiblingsID"].Value) : 0,
                    studentID = row.Cells["studentID"].Value != DBNull.Value ? row.Cells["studentID"].Value.ToString() : null,
                    Name = row.Cells["Name"].Value != DBNull.Value ? row.Cells["Name"].Value.ToString() : null,
                    Age = row.Cells["Age"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Age"].Value) : 0,
                    School = row.Cells["School"].Value != DBNull.Value ? row.Cells["School"].Value.ToString() : null,
                    EducationalAttainment = row.Cells["EducationalAttainment"].Value != DBNull.Value ? row.Cells["EducationalAttainment"].Value.ToString() : null,
                    EmploymentBusinessAgency = row.Cells["EmploymentBusinessAgency"].Value != DBNull.Value ? row.Cells["EmploymentBusinessAgency"].Value.ToString() : null
                };

                return siblingData;
            }

            return null; // If no row is selected
        }


        private async Task SaveFamilyData(FamilyData family)
        {
            string connectionString = "server=localhost;port=3306;database=guidancedb;user=root;password=;";
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = @"INSERT INTO tbl_family_data 
                        (Student_ID, Parent_Type,Living_Status,Parents_Name, Tel_Cell_No, Nationality, Educational_Attainment, Occupation, Employer_Agency, Working_Abroad, Marital_Status, Monthly_Income,
                        No_of_Children, Students_Birth_Order, Language_Dialect, Family_Structure, Indigenous_Group, 4Ps_Beneficiary)
                        VALUES
                        (@StudentID, @ParentType, @LivingStatus,@ParentsName, @TelCellNo, @Nationality, @EducationalAttainment, @Occupation, @EmployerAgency, @WorkingAbroad, @MaritalStatus, @MonthlyIncome, @NoOfChildren, @StudentsBirthOrder, @LanguageDialect, @FamilyStructure, @IndigenousGroup, @Beneficiary4Ps);";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Assign parameters
                    command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                    command.Parameters.AddWithValue("@ParentType", family.ParentType);
                    command.Parameters.AddWithValue("@LivingStatus", family.LivingStatus);
                    command.Parameters.AddWithValue("@ParentsName", family.Name);
                    command.Parameters.AddWithValue("@TelCellNo", family.TelCellNo);
                    command.Parameters.AddWithValue("@Nationality", family.Nationality);
                    command.Parameters.AddWithValue("@EducationalAttainment", family.EducationalAttainment);
                    command.Parameters.AddWithValue("@Occupation", family.Occupation);
                    command.Parameters.AddWithValue("@EmployerAgency", family.EmployerAgency);
                    command.Parameters.AddWithValue("@WorkingAbroad", family.WorkingAbroad);
                    command.Parameters.AddWithValue("@MaritalStatus", family.MaritalStatus);
                    command.Parameters.AddWithValue("@MonthlyIncome", family.MonthlyIncome);
                    command.Parameters.AddWithValue("@NoOfChildren", family.NoOfChildren);
                    command.Parameters.AddWithValue("@StudentsBirthOrder", family.StudentsBirthOrder);
                    command.Parameters.AddWithValue("@LanguageDialect", family.LanguageDialect);
                    command.Parameters.AddWithValue("@FamilyStructure", family.FamilyStructure);
                    command.Parameters.AddWithValue("@IndigenousGroup", family.IndigenousGroup);
                    command.Parameters.AddWithValue("@Beneficiary4Ps", family.Beneficiary4Ps);

                    try
                    {
                        int result = await command.ExecuteNonQueryAsync();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private async Task SaveAllRecordsAsync(
           
        PersonalData PersonalInfo,
        HealthData Health,
        AdditionalProfile AdditionalInfo,
        EducationalData Education,
        FamilyData father,
        FamilyData mother
        )
        {
            string connectionString = "server=localhost;port=3306;database=guidancedb;user=root;password=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                // Open the connection asynchronously
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        // Save individual record
                        string studentID = SavedStudentID;
                        //await SaveIndividualRecordAsync(IndividualInfo);
                       //  studentID = await SaveIndividualRecordAsync(indi);
                        await SaveStudentRecord(PersonalInfo);
                        await TestSaveHealthData(Health);
                        await TestSaveAdditionalProfile(AdditionalInfo);
                        await TestSaveEducationalData(Education);
                        await SaveFamilyData(father);
                        await SaveFamilyData(mother);
                        // Save other records asynchronously
                        // await SaveStudentRecord(studentRecord, studentID, connection, transaction);
                        // await SaveEducationalRecord(Education, studentID, connection, transaction);
                        //await TestSaveHealthData(healthData);
                        //await SaveFamilyData(father, mother, studentID, connection, transaction);
                        //await SaveAdditionalProfile(AdditionalInfo, studentID, connection, transaction);
                        // Save siblings with StudentID as a foreign key
                        //foreach (var siblingData in sibling)
                        //{
                        //    await SaveSiblingsData(siblingData, studentID, connection, transaction);
                        //}
                        // Commit the transaction if all inserts succeed
                        await transaction.CommitAsync();
                        //MessageBox.Show("Health data saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction if any insert fails
                        await transaction.RollbackAsync();
                        MessageBox.Show("An error occurred while saving: " + ex.Message);
                    }
                }
            }
        }
        private async Task SaveStudentRecord(PersonalData PersonalInfo)
        {

             // Open the connection asynchronously

                string query = @"
            INSERT INTO tbl_personal_data (
                Student_ID, Firstname, Middlename, Lastname, Nickname, Sex, Age, 
                Nationality, Citizenship, Date_of_Birth, Place_of_Birth, Civil_Status, 
                With_or_Without_Child, Spouse_Name, Number_of_Children, Religion, 
                Contact_No, E_mail_Address, Complete_Home_Address, Boarding_House_Address, 
                Landlord_Name, Person_to_contact, Cell_no, Hobbies_Skills_Talents, Describe_Yourself
            ) 
            VALUES (
                @StudentID, @FirstName, @MiddleName, @LastName, @NickName, @Sex, @Age, 
                @Nationality, @Citizenship, @DateOfBirth, @PlaceOfBirth, @Civil_Status, 
                @Children, @Spouse_Name, @Number_of_Children, @Religion, 
                @Contact_No, @E_mail_Address, @CompleteHomeAddress, @BoardingHouseAddress, 
                @LandlordName, @PersonToContact, @CellNumber, @Hobbies, @DescribeYourself
            );";

                // Use the connection and a command
                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    // Assign parameter values for the query
                   // command.Parameters.AddWithValue("PersonalDataID", PersonalInfo.PersonalDataID);
                    command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                    command.Parameters.AddWithValue("@FirstName", PersonalInfo.Firstname);
                    command.Parameters.AddWithValue("@MiddleName", PersonalInfo.Middlename);
                    command.Parameters.AddWithValue("@LastName", PersonalInfo.Lastname);
                    command.Parameters.AddWithValue("@NickName", PersonalInfo.Nickname);
                    command.Parameters.AddWithValue("@Sex", PersonalInfo.Sex);
                    command.Parameters.AddWithValue("@Age", PersonalInfo.Age);
                    command.Parameters.AddWithValue("@Nationality", PersonalInfo.Nationality);
                    command.Parameters.AddWithValue("@Citizenship", PersonalInfo.Citizenship);
                    command.Parameters.AddWithValue("@DateOfBirth", PersonalInfo.DateOfBirth);
                    command.Parameters.AddWithValue("@PlaceOfBirth", PersonalInfo.PlaceOfBirth);
                    command.Parameters.AddWithValue("@Civil_Status", PersonalInfo.CivilStatus);
                    command.Parameters.AddWithValue("@Children", PersonalInfo.Children); // Match "With Child" or "Without Child"
                    command.Parameters.AddWithValue("@Spouse_Name", PersonalInfo.SpouseName);
                    command.Parameters.AddWithValue("@Number_of_Children", PersonalInfo.NumberOfChildren);
                    command.Parameters.AddWithValue("@Religion", PersonalInfo.Religion);
                    command.Parameters.AddWithValue("@Contact_No", PersonalInfo.ContactNumber);
                    command.Parameters.AddWithValue("@E_mail_Address", PersonalInfo.EmailAddress);
                    command.Parameters.AddWithValue("@CompleteHomeAddress", PersonalInfo.CompleteHomeAddress);
                    command.Parameters.AddWithValue("@BoardingHouseAddress", PersonalInfo.BoardingHouseAddress);
                    command.Parameters.AddWithValue("@LandlordName", PersonalInfo.LandlordName);
                    command.Parameters.AddWithValue("@PersonToContact", PersonalInfo.PersonToContact);
                    command.Parameters.AddWithValue("@CellNumber", PersonalInfo.CellNumber);
                    command.Parameters.AddWithValue("@Hobbies", PersonalInfo.Hobbies);
                    command.Parameters.AddWithValue("@DescribeYourself", PersonalInfo.DescribeYourself);

                    try
                    {
                        int result = await command.ExecuteNonQueryAsync();
                       // MessageBox.Show(result > 0 ? "Personal data saved!" : "Personal data not saved.");

                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine("Error Details: " + ex);
                        MessageBox.Show("Error bobo: " + ex.Message);
                    }
                }
            
        }
        private async Task TestSaveEducationalData(EducationalData Education)
        {
            string query = @"
        INSERT INTO tbl_educational_data_final (
            Student_ID, Elementary, ElementaryHonorAwards, ElementaryYearGraduated, 
            HighSchool, JuniorHighYearGraduated, JuniorHighHonorAwards, SeniorHighSchool, 
            SeniorHighYearGraduated, SeniorHighHonorAwards, StrandCompleted, VocationalTechnical, 
            SHSAverageGrade, College, FavoriteSubject, WhyFavoriteSubject, LeastFavoriteSubject, 
            WhyLeastFavoriteSubject, SupportForStudies, Membership, LeftRightHanded
        )
        VALUES (
            @StudentID, @Elementary, @ElementaryHonorAwards, @ElementaryYearGraduated, 
            @HighSchool, @JuniorHighYearGraduated, @JuniorHighHonorAwards, @SeniorHighSchool, 
            @SeniorHighYearGraduated, @SeniorHighHonorAwards, @StrandCompleted, @VocationalTechnical, 
            @SHSAverageGrade, @College, @FavoriteSubject, @WhyFavoriteSubject, @LeastFavoriteSubject, 
            @WhyLeastFavoriteSubject, @SupportForStudies, @Membership, @LeftRightHanded
        );";

            using (var command = new MySqlCommand(query, MyCon.GetConnection()))
            {
                // Adding parameter values
                command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                command.Parameters.AddWithValue("@Elementary", Education.Elementary);
                command.Parameters.AddWithValue("@ElementaryHonorAwards", Education.ElementaryHonorAwards);
                command.Parameters.AddWithValue("@ElementaryYearGraduated", Education.ElementaryYearGraduated);
                command.Parameters.AddWithValue("@HighSchool", Education.HighSchool);
                command.Parameters.AddWithValue("@JuniorHighYearGraduated", Education.JuniorHighYearGraduated);
                command.Parameters.AddWithValue("@JuniorHighHonorAwards", Education.JuniorHighHonorAwards);
                command.Parameters.AddWithValue("@SeniorHighSchool", Education.SeniorHighSchool);
                command.Parameters.AddWithValue("@SeniorHighYearGraduated", Education.SeniorHighYearGraduated);
                command.Parameters.AddWithValue("@SeniorHighHonorAwards", Education.SeniorHighHonorAwards);
                command.Parameters.AddWithValue("@StrandCompleted", Education.StrandCompleted);
                command.Parameters.AddWithValue("@VocationalTechnical", Education.VocationalTechnical);
                command.Parameters.AddWithValue("@SHSAverageGrade", Education.SHSAverageGrade);
                command.Parameters.AddWithValue("@College", Education.College);
                command.Parameters.AddWithValue("@FavoriteSubject", Education.FavoriteSubject);
                command.Parameters.AddWithValue("@WhyFavoriteSubject", Education.WhyFavoriteSubject);
                command.Parameters.AddWithValue("@LeastFavoriteSubject", Education.LeastFavoriteSubject);
                command.Parameters.AddWithValue("@WhyLeastFavoriteSubject", Education.WhyLeastFavoriteSubject);
                command.Parameters.AddWithValue("@SupportForStudies", Education.SupportForStudies);
                command.Parameters.AddWithValue("@Membership", Education.Membership);
                command.Parameters.AddWithValue("@LeftRightHanded", Education.LeftRightHanded);

                try
                {
                    // Execute the query
                    int result = await command.ExecuteNonQueryAsync();
                    //MessageBox.Show(result > 0 ? "Educational data saved!" : "Educational data not saved.");
                }
                catch (Exception ex)
                {
                    // Catch and display errors
                    MessageBox.Show($"Error message: {ex.Message}");
                }
            }
        }

        private async Task TestSaveHealthData(HealthData Health)
        {
           
                string query = @"INSERT INTO tbl_health_data (Student_ID, Sick_Frequency, Health_Problems, Physical_Disabilities)
                         VALUES (@StudentID, @SickFrequency, @HealthProblems, @PhysicalDisabilities);";

                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                    command.Parameters.AddWithValue("@SickFrequency", Health.SickFrequency);
                    command.Parameters.AddWithValue("@HealthProblems", Health.HealthProblems);
                    command.Parameters.AddWithValue("@PhysicalDisabilities", Health.PhysicalDisabilities);

                    try
                    {
                        int result = await command.ExecuteNonQueryAsync();
                        //MessageBox.Show(result > 0 ? "Health data saved!" : "Health data not saved.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error message: {ex.Message}");
                    }
                }
        }

        private async Task TestSaveAdditionalProfile(AdditionalProfile AdditionalInfo)
        {
           
                string query = @"INSERT INTO tbl_additional_profile (
                            Student_ID, 
                            Sexual_Preference, 
                            Expression_Present, 
                            Gender_Sexually_Attracted,Scholarship,Name_of_Scholarship
                           
                         ) 
                         VALUES (
                            @StudentID, 
                            @SexualPreference, 
                            @ExpressionPresent, 
                            @GenderSexuallyAttracted,
                            @HasScholarship,
                            @ScholarshipName
                         );";

                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                    command.Parameters.AddWithValue("@SexualPreference", AdditionalInfo.SexualPreference);
                    command.Parameters.AddWithValue("@ExpressionPresent", AdditionalInfo.ExpressionPresent);
                    command.Parameters.AddWithValue("@GenderSexuallyAttracted", AdditionalInfo.GenderSexuallyAttracted);
                    command.Parameters.AddWithValue("@HasScholarship", AdditionalInfo.HasScholarship);
                    command.Parameters.AddWithValue("@ScholarshipName", AdditionalInfo.ScholarshipName);

                    try
                    {
                        int result = await command.ExecuteNonQueryAsync();
                      //  MessageBox.Show(result > 0 ? "Additional profile saved!" : "Additional profile not saved.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error tanga: {ex.Message}");
                    }
                }
            }
        
        private async Task SaveIndividualRecordAsync(IndividualRecord IndividualInfo)
        {
            string query = @"INSERT INTO tbl_individual_record (Student_ID, Course, Year,Student_Status) 
                     VALUES (@StudentID, @Course, @Year,@StudentStatus);";

         
              

                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@StudentID", IndividualInfo.studentID);
                    command.Parameters.AddWithValue("@Course", IndividualInfo.Course);
                    command.Parameters.AddWithValue("@Year", IndividualInfo.Year);
                    command.Parameters.AddWithValue("@StudentStatus", IndividualInfo.StudentStatus);

                    await command.ExecuteNonQueryAsync();
                }
            }
        



        private async Task SaveSiblingsData(Sibling sibling, string studentID, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO tbl_brothers_sisters (Student_ID, Name, Age, School, Educational_Attainment, Employment_Business_Agency) VALUES (@StudentID, @Name, @Age, @School, @EducationalAttainment, @EmploymentBusinessAgency)";

            using (var command = new MySqlCommand(query, MyCon.GetConnection(), transaction))
            {
                command.Parameters.AddWithValue("@StudentID", SavedStudentID);
                command.Parameters.AddWithValue("@Name", sibling.Name);
                command.Parameters.AddWithValue("@Age", sibling.Age);
                command.Parameters.AddWithValue("@School", sibling.School);
                command.Parameters.AddWithValue("@EducationalAttainment", sibling.EducationalAttainment);
                command.Parameters.AddWithValue("@EmploymentBusinessAgency", sibling.EmploymentBusinessAgency);

                await command.ExecuteNonQueryAsync();
            }
        }
        public enrollment()
        {
            InitializeComponent();

            MyMethods.ApplyPlaceholder(txtEmailAddress, "example@gmail.com");
            txtEmailAddress.KeyPress += new KeyPressEventHandler(InputValidator.OnKeyPress_EmailValidation);

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetGenderIdentity()
        {
            if (rbMaleindentity.Checked) return "Male";
            if (rbFemaleidentity.Checked) return "Female";
            if (rbLezbian.Checked) return "Lesbian";
            if (rbGay.Checked) return "Gay";
            if (rbBisexual.Checked) return "Bisexual";
            if (rbTransgender.Checked) return "Transgender";

            return null; // Default case
        }

        private string GetGenderExpression()
        {
            if (rbExpressionMasculine.Checked) return "Masculine";
            if (rbExpressionFeminine.Checked) return "Feminine";
            if (rbExpressionAndrogynous.Checked) return "Androgynous";

            return null; // Default case
        }



        private string GetGenderSexuallyAttracted()
        {
            if (rbAttractedToMale.Checked) return "Male";
            if (rbAttractedToFemale.Checked) return "Female";
            if (rbAttractedToLesbian.Checked) return "Lesbian";
            if (rbAttractedToGay.Checked) return "Gay";
            if (rbAttractedToBisexual.Checked) return "Bisexual";
            if (rbAttractedToTransgender.Checked) return "Transgender";


            return null; // Default case
            }
            private string GetFatherMaritalStatus() =>
            rbMotherAnnulled.Checked ? "Annulled" :
            rbMotherWidowed.Checked ? "Widowed" :
            rbFatherWithAnotherPartner.Checked ? "Father with Another Partner" :
            rbFatherLivingTogether.Checked ? "Living Together" :
            rbFatherSeparated.Checked ? "Separated" :
            "Unknown";


        private string GetMotherMaritalStatus() =>
            rbMotherAnnulled.Checked ? "Annulled" :
            rbMotherWidowed.Checked ? "Widowed" :
            rbMotherWithAnotherPartner.Checked ? "Mother with Another Partner" :
            rbFatherLivingTogether.Checked ? "Living Together" :
            rbFatherSeparated.Checked ? "Separated" :
            "Unknown";

       
           private string GetMonthlyIncome() =>
            rbBelow5000.Checked ? "Below 5000" :
            rb5000To10000.Checked ? "5000 - 10,000" :  // Corrected the radio button condition
            rb10001To15000.Checked ? "10,001 - 15,000" :
            rb15001To20000.Checked ? "15,001 - 20,000" :
            rb20001To25000.Checked ? "20,001 - 25,000" :
            rbAbove25000.Checked ? "25,001 above" :
            "Unknown";  // Default if no radio button is checked


        private string GetFamilyStructure() =>
            rbNuclear.Checked ? "Nuclear" :
            rbExtended.Checked ? "Extended" :
            null;

        private string GetIndigenousGroup() =>
            rbIndigenousYes.Checked ? "Yes" :
            rbIndigenousNo.Checked ? "No" :
            null;

        private string GetBeneficiary4Ps() =>
            rbBeneficiaryYes.Checked ? "Yes" :
            rbBeneficiaryNo.Checked ? "No" :
            null;

        private string GetFatherWorkingAbroad() =>
            rbFatherWorkingAbroadYes.Checked ? "Yes" :
            rbFatherWorkingAbroadNo.Checked ? "No" :
            null;

        private string GetMotherWorkingAbroad() =>
            rbMotherWorkingAbroadYes.Checked ? "Yes" :
            rbMotherWorkingAbroadNo.Checked ? "No" :
            null;
        private string GetLivingStatus(string parentType)
        {
            if (parentType == "Father")
                return rbliving.Checked ? "Yes" : rbdeceased.Checked ? "No" : "Unknown";
            if (parentType == "Mother")
                return mrbliving.Checked ? "Yes" : mrbdeceased.Checked ? "No" : "Unknown";
            return "Unknown";
        }
        private string GetSickFrequency()
        {
            if (rbSickOften.Checked) return "Yes";
            if (rbSickNo.Checked) return "No";
            if (rbSickSeldom.Checked) return "Seldom";
            if (rbSickSometimes.Checked) return "Sometimes";
            if (rbSickNever.Checked) return "Never";
            return null; // Default case
        }

            private string GetHealthProblems()
            {
            List<string> selectedProblems = new List<string>();

            if (chkDysmenorrhea.Checked) selectedProblems.Add("Dysmenorrhea");
            if (chkHeadache.Checked) selectedProblems.Add("Headache");
            if (chkAsthma.Checked) selectedProblems.Add("Asthma");
            if (chkStomachache.Checked) selectedProblems.Add("Stomachache");
            if (chkHeartProblems.Checked) selectedProblems.Add("Heart Problems");
            if (chkColdsFlu.Checked) selectedProblems.Add("Colds/Flu");
            if (chkAbdominalPain.Checked) selectedProblems.Add("Abdominal Pain");
            if (chkSeizureDisorders.Checked) selectedProblems.Add("Seizure Disorder");

            return selectedProblems.Count > 0 ? string.Join(",", selectedProblems) : null;
        }

        private string GetPhysicalDisabilities()
        {
            List<string> selectedDisablities = new List<string>();
            if (chkVisualImpairment.Checked) return "Visual Impairment";
            if (chkPolio.Checked) return "Polio";
            if (chkHearingImpairment.Checked) return "Hearing Impairment";
            if (chkCleftPalate.Checked) return "Cleft Palate";
            if (chkPhysicalDeformities.Checked) return "Physical Deformities";
            if (chkSeizureDisorders.Checked) return "Seizure Disorder";
            return selectedDisablities.Count > 0 ? string.Join(",", selectedDisablities) : null;
        }

        private string GetStudentStatus()
        {
            if (rbIsNewStudent.Checked) return "New Student";
            if (rbIsTransferee.Checked) return "Transferee";
            if (rbIsReEntry.Checked) return "Re-entry";
            if (rbisShifter.Checked) return "Shifter";

            return null;
        }
        public string GetGender()
        {
            if (rbMale.Checked)
            {
                return "Male";
            }
            else if (rbFemale.Checked)
            {
                return "Female";
            }
            else
            {
                return null; // Default value if neither is selected
            }
        }
        public string GetChildStatus()
        {
            if (rbWithChild.Checked)
            {
                return "With Child";
            }
            else if (rbWithoutChild.Checked)
            {
                return "Without Child";
            }
            else
            {
                return null; // Default value if neither is selected
            }
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--; 
            return age;
        }
        private string GetScholarshipStatus()
        {
            if (rbScholarshipYes.Checked)
                return "Yes";
            else if (rbScholarshipNo.Checked)
                return "No";
            else
                return null;
        }
        private string GetHanded()
        {
            if (LeftHanded.Checked)
                return "Left";
            else if (RightHanded.Checked)
                return "Right";
            else
                return null;
        }

        public async Task UpdateEducationalData(string studentId)
        {
            MyMethods md = new MyMethods();
            string query = @"UPDATE tbl_educational_data_final
                     SET Elementary = @Elementary, 
                         ElementaryHonorAwards = @ElementaryHonorAwards, 
                         ElementaryYearGraduated = @ElementaryYearGraduated, 
                         HighSchool = @HighSchool, 
                         JuniorHighYearGraduated = @JuniorHighYearGraduated, 
                         JuniorHighHonorAwards = @JuniorHighHonorAwards, 
                         SeniorHighSchool = @SeniorHighSchool, 
                         SeniorHighYearGraduated = @SeniorHighYearGraduated, 
                         SeniorHighHonorAwards = @SeniorHighHonorAwards, 
                         StrandCompleted = @StrandCompleted, 
                         VocationalTechnical = @VocationalTechnical, 
                         SHSAverageGrade = @SHSAverageGrade, 
                         College = @College, 
                         FavoriteSubject = @FavoriteSubject, 
                         WhyFavoriteSubject = @WhyFavoriteSubject, 
                         LeastFavoriteSubject = @LeastFavoriteSubject, 
                         WhyLeastFavoriteSubject = @WhyLeastFavoriteSubject, 
                         SupportForStudies = @SupportForStudies, 
                         Membership = @Membership, 
                         LeftRightHanded = @LeftRightHanded
                     WHERE Student_ID = @StudentID";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@Elementary", Elementary.Text),
                new MySqlParameter("@ElementaryHonorAwards", ElementaryHonorAwards.Text),
                new MySqlParameter("@ElementaryYearGraduated", ElementaryYearGraduated.Text),
                new MySqlParameter("@HighSchool", HighSchool.Text),
                new MySqlParameter("@JuniorHighYearGraduated", JuniorHighYearGraduated.Text),
                new MySqlParameter("@JuniorHighHonorAwards", JuniorHighHonorAwards.Text),
                new MySqlParameter("@SeniorHighSchool", SeniorHighSchool.Text),
                new MySqlParameter("@SeniorHighYearGraduated", SeniorHighYearGraduated.Text),
                new MySqlParameter("@SeniorHighHonorAwards", SeniorHighHonorAwards.Text),
                new MySqlParameter("@StrandCompleted", StrandCompleted.Text),
                new MySqlParameter("@VocationalTechnical", VocationalTechnical.Text),
                new MySqlParameter("@SHSAverageGrade", int.TryParse(SHSAverageGrade.Text, out var average) ? average : 0),
                new MySqlParameter("@College", CollegeIfTransferee.Text),
                new MySqlParameter("@FavoriteSubject", FavoriteSubject.Text),
                new MySqlParameter("@WhyFavoriteSubject", WhyFavoriteSubject.Text),
                new MySqlParameter("@LeastFavoriteSubject", LeastFavoriteSubject.Text),
                new MySqlParameter("@WhyLeastFavoriteSubject", WhyLeastFavoriteSubject.Text),
                new MySqlParameter("@SupportForStudies", SupportForStudies.Text),
                new MySqlParameter("@Membership", Membership.Text),
                new MySqlParameter("@LeftRightHanded", GetHanded())
                    };

            int result = await md.ExecuteUpdateQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Educational data updated successfully!");
            }
        }


        public async Task UpdateIndividualRecord(string studentId)
        {
            MyMethods md = new MyMethods();
            string query = @"UPDATE tbl_individual_record 
                     SET Course = @Course, 
                         Year = @Year, 
                         Student_Status = @StudentStatus
                     WHERE Student_ID = @StudentID";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@Course", cmbCourse.Text),
            new MySqlParameter("@Year", cmbYear.Text),
            new MySqlParameter("@StudentStatus", GetStudentStatus())
            };

            int result = await md.ExecuteUpdateQuery(query, parameters);
            if (result > 0) MessageBox.Show("Individual record updated successfully!");
        }
        public async Task UpdateHealthData(string studentId)
        {
            MyMethods md = new MyMethods();

            string query = @"UPDATE tbl_health_data 
                     SET Sick_Frequency = @SickFrequency, 
                         Health_Problems = @HealthProblems, 
                         Physical_Disabilities = @PhysicalDisabilities
                     WHERE Student_ID = @StudentID";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@SickFrequency", GetSickFrequency()),
            new MySqlParameter("@HealthProblems", GetHealthProblems()),
            new MySqlParameter("@PhysicalDisabilities", GetPhysicalDisabilities())
            };

            int result = await md.ExecuteUpdateQuery(query, parameters);
            if (result > 0) MessageBox.Show("Health data updated successfully!");
        }
        public async Task UpdateAdditionalProfile(string studentId)
        {
            MyMethods md = new MyMethods();

            // SQL query to update additional profile data
            string query = @"
            UPDATE tbl_additional_profile
            SET Sexual_Preference = @SexualPreference, 
            Expression_Present = @ExpressionPresent, 
            Gender_Sexually_Attracted = @GenderSexuallyAttracted, 
            Scholarship = @HasScholarship,
            Name_of_Scholarship = @ScholarshipName
            WHERE Student_ID = @StudentID";

            // Parameters for the query
            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@SexualPreference", GetGenderIdentity()),
            new MySqlParameter("@ExpressionPresent", GetGenderExpression()),
            new MySqlParameter("@GenderSexuallyAttracted", GetGenderSexuallyAttracted()),
            new MySqlParameter("@HasScholarship", GetScholarshipStatus()),
            new MySqlParameter("@ScholarshipName", txtScholarshipName.Text)
                };

           
                // Execute the update query using MyMethods class and MyCon.GetConnection
                int result = await md.ExecuteUpdateQuery(query, parameters);
            if (result > 0) MessageBox.Show("Health data updated successfully!");
        }
        public async Task UpdateSiblingsDataAsync(string studentId, List<Sibling> siblingsList)
        {
            
            MyMethods md = new MyMethods();

            // SQL query to update sibling data (in case you want to update existing records)
            string query = @"
        INSERT INTO tbl_brothers_sisters (Student_ID, Name, Age, School, Educational_Attainment, Employment_Business_Agency) 
        VALUES (@StudentID, @Name, @Age, @School, @EducationalAttainment, @EmploymentBusinessAgency)";

            // Loop through each sibling record
            foreach (var sibling in siblingsList)
            {
                // Parameters for the query
                MySqlParameter[] parameters = new MySqlParameter[]
                {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@Name", sibling.Name ?? string.Empty),
            new MySqlParameter("@Age", sibling.Age),
            new MySqlParameter("@School", sibling.School ?? string.Empty),
            new MySqlParameter("@EducationalAttainment", sibling.EducationalAttainment ?? string.Empty),
            new MySqlParameter("@EmploymentBusinessAgency", sibling.EmploymentBusinessAgency ?? string.Empty)
                };

                // Execute the insert query using the ExecuteUpdateQuery method
                int result = await md.ExecuteUpdateQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Sibling data updated successfully!");
                }
                else
                {
                    MessageBox.Show("Error updating sibling data.");
                }
            }
        }

        public async Task UpdateFamilyData(string studentId)
        {
            MyMethods md = new MyMethods();

            // SQL query to update family data
            string query = @"
            UPDATE tbl_family_data
            SET 
                Parent_Type = @ParentType,
                Living_Status = @LivingStatus,
                Parents_Name = @Name,
                Tel_Cell_No = @TelCellNo,
                Nationality = @Nationality,
                Educational_Attainment = @EducationalAttainment,
                Occupation = @Occupation,
                Employer_Agency = @EmployerAgency,
                Working_Abroad = @WorkingAbroad,
                Marital_Status = @MaritalStatus,
                Monthly_Income = @MonthlyIncome,
                No_of_Children = @NoOfChildren,
                Students_Birth_Order = @StudentsBirthOrder,
                Language_Dialect = @LanguageDialect,
                Family_Structure = @FamilyStructure,
                Indigenous_Group = @IndigenousGroup,
                4Ps_Beneficiary = @Beneficiary4Ps
            WHERE 
                Student_ID = @StudentID AND Parent_Type = @ParentType;
            ";

            // Parameters for the query for Father
            MySqlParameter[] fatherParameters = new MySqlParameter[]
            {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@ParentType", "Father"),
            new MySqlParameter("@LivingStatus", GetLivingStatus("Father")),
            new MySqlParameter("@Name", txtFatherName.Text ?? string.Empty),
            new MySqlParameter("@TelCellNo", txtFatherPhone.Text ?? string.Empty),
            new MySqlParameter("@Nationality", txtFatherNationality.Text ?? string.Empty),
            new MySqlParameter("@EducationalAttainment", txtFatherEducationalAttainment.Text ?? string.Empty),
            new MySqlParameter("@Occupation", txtFatherOccupation.Text ?? string.Empty),
            new MySqlParameter("@EmployerAgency", txtFatherEmployerAgency.Text ?? string.Empty),
            new MySqlParameter("@WorkingAbroad", GetFatherWorkingAbroad()),
            new MySqlParameter("@MaritalStatus", GetFatherMaritalStatus() ?? (object)DBNull.Value),
            new MySqlParameter("@MonthlyIncome", GetMonthlyIncome() ?? (object)DBNull.Value),
            new MySqlParameter("@NoOfChildren", int.TryParse(txtFatherNoOfChildren.Text, out var fatherChildren) ? fatherChildren : 0),
            new MySqlParameter("@StudentsBirthOrder", int.TryParse(txtFatherBirthOrder.Text, out var fatherBirthOrder) ? fatherBirthOrder : 0),
            new MySqlParameter("@LanguageDialect", txtFatherLanguageDialect.Text ?? string.Empty),
            new MySqlParameter("@FamilyStructure", GetFamilyStructure() ?? (object)DBNull.Value),
            new MySqlParameter("@IndigenousGroup", GetIndigenousGroup() ?? (object)DBNull.Value),
            new MySqlParameter("@Beneficiary4Ps", GetBeneficiary4Ps() ?? (object)DBNull.Value)
            };

            // Parameters for the query for Mother
            MySqlParameter[] motherParameters = new MySqlParameter[]
            {
            new MySqlParameter("@StudentID", studentId),
            new MySqlParameter("@ParentType", "Mother"),
            new MySqlParameter("@LivingStatus", GetLivingStatus("Mother")),
            new MySqlParameter("@Name", txtMotherName.Text ?? string.Empty),
            new MySqlParameter("@TelCellNo", txtMotherTelCellNo.Text ?? string.Empty),
            new MySqlParameter("@Nationality", txtMotherNationality.Text ?? string.Empty),
            new MySqlParameter("@EducationalAttainment", txtMotherEducationalAttainment.Text ?? string.Empty),
            new MySqlParameter("@Occupation", txtMotherOccupation.Text ?? string.Empty),
            new MySqlParameter("@EmployerAgency", txtMotherEmployerAgency.Text ?? string.Empty),
            new MySqlParameter("@WorkingAbroad", GetMotherWorkingAbroad()),
            new MySqlParameter("@MaritalStatus", GetMotherMaritalStatus() ?? (object)DBNull.Value),
            new MySqlParameter("@MonthlyIncome", GetMonthlyIncome() ?? (object)DBNull.Value),
            new MySqlParameter("@NoOfChildren", txtFatherNoOfChildren.Text),
            new MySqlParameter("@StudentsBirthOrder", txtFatherBirthOrder.Text),
            new MySqlParameter("@LanguageDialect", txtFatherLanguageDialect.Text),
            new MySqlParameter("@FamilyStructure", GetFamilyStructure()),
            new MySqlParameter("@IndigenousGroup", GetIndigenousGroup() ),
            new MySqlParameter("@Beneficiary4Ps", GetBeneficiary4Ps() ?? (object)DBNull.Value)
            };

            try
            {
                // Execute the update query for Father
                int fatherResult = await md.ExecuteUpdateQuery(query, fatherParameters);

                // Execute the update query for Mother
                int motherResult = await md.ExecuteUpdateQuery(query, motherParameters);

                // Provide feedback to user
                if (fatherResult > 0 && motherResult > 0)
                {
                    MessageBox.Show("Family data updated successfully!");
                }
                else
                {
                    MessageBox.Show("No records were updated. Please check the input data.");
                }
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show($"An error occurred while updating family data: {ex.Message}");
            }
        }

        public async Task UpdatePersonalData(string studentId)
        {
            MyMethods md = new MyMethods();

            // SQL query to update personal data
            string query = @"
            UPDATE tbl_personal_data
            SET 
                Firstname = @FirstName,
                Middlename = @MiddleName,
                Lastname = @LastName,
                Nickname = @NickName,
                Sex = @Sex,
                Age = @Age,
                Nationality = @Nationality,
                Citizenship = @Citizenship,
                Date_of_Birth = @DateOfBirth,
                Place_of_Birth = @PlaceOfBirth,
                Civil_Status = @CivilStatus,
                With_or_Without_Child = @WithChild,
                Spouse_Name = @SpouseName,
                Number_of_Children = @NumberOfChildren,
                Religion = @Religion,
                Contact_No = @ContactNo,
                E_mail_Address = @Email,
                Complete_Home_Address = @CompleteHomeAddress,
                Boarding_House_Address = @BoardingHouseAddress,
                Landlord_Name = @LandlordName,
                Person_to_contact = @PersonToContact,
                Cell_no = @CellNo,
                Hobbies_Skills_Talents = @Hobbies,
                Describe_Yourself = @DescribeYourself
            WHERE 
                Student_ID = @StudentID;
            ";
                    // Parameters for the query
                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                new MySqlParameter("@StudentID", string.IsNullOrEmpty(studentId) ? DBNull.Value : (object)studentId),
                new MySqlParameter("@FirstName", string.IsNullOrEmpty(txtFirstName.Text) ? DBNull.Value : (object)txtFirstName.Text),
                new MySqlParameter("@MiddleName", string.IsNullOrEmpty(txtMiddleName.Text) ? DBNull.Value : (object)txtMiddleName.Text),
                new MySqlParameter("@LastName", string.IsNullOrEmpty(txtLastName.Text) ? DBNull.Value : (object)txtLastName.Text),
                new MySqlParameter("@NickName", string.IsNullOrEmpty(txtNickname.Text) ? DBNull.Value : (object)txtNickname.Text),
                new MySqlParameter("@Sex", string.IsNullOrEmpty(GetGender()) ? "Not Specified" : GetGender()),
                new MySqlParameter("@Age", CalculateAge(dtpDateOfBirth.Value) > 0 ? (object)CalculateAge(dtpDateOfBirth.Value) : DBNull.Value),
                new MySqlParameter("@Nationality", string.IsNullOrEmpty(txtNationality.Text) ? DBNull.Value : (object)txtNationality.Text),
                new MySqlParameter("@Citizenship", string.IsNullOrEmpty(txtCitizenship.Text) ? DBNull.Value : (object)txtCitizenship.Text),
                new MySqlParameter("@DateOfBirth", dtpDateOfBirth.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@PlaceOfBirth", string.IsNullOrEmpty(txtPlaceOfBirth.Text) ? DBNull.Value : (object)txtPlaceOfBirth.Text),
                new MySqlParameter("@CivilStatus", string.IsNullOrEmpty(txtCivilStatus.SelectedItem?.ToString()) ? DBNull.Value : (object)txtCivilStatus.SelectedItem),
                new MySqlParameter("@WithChild", string.IsNullOrEmpty(GetChildStatus()) ? "Not Specified" : GetChildStatus()),
                new MySqlParameter("@SpouseName", string.IsNullOrEmpty(txtSpouseName.Text) ? DBNull.Value : (object)txtSpouseName.Text),
                new MySqlParameter("@NumberOfChildren", string.IsNullOrEmpty(numericUpDownNumberOfChildren.Text) ? DBNull.Value : (object)numericUpDownNumberOfChildren.Text),
                new MySqlParameter("@Religion", string.IsNullOrEmpty(txtReligion.Text) ? DBNull.Value : (object)txtReligion.Text),
                new MySqlParameter("@ContactNo", string.IsNullOrEmpty(txtContactNumber.Text) ? DBNull.Value : (object)txtContactNumber.Text),
                new MySqlParameter("@Email", string.IsNullOrEmpty(txtEmailAddress.Text) ? DBNull.Value : (object)txtEmailAddress.Text),
                new MySqlParameter("@CompleteHomeAddress", string.IsNullOrEmpty(txtCompleteHomeAddress.Text) ? DBNull.Value : (object)txtCompleteHomeAddress.Text),
                new MySqlParameter("@BoardingHouseAddress", string.IsNullOrEmpty(txtBoardingHouseAddress.Text) ? DBNull.Value : (object)txtBoardingHouseAddress.Text),
                new MySqlParameter("@LandlordName", string.IsNullOrEmpty(txtLandlordName.Text) ? DBNull.Value : (object)txtLandlordName.Text),
                new MySqlParameter("@PersonToContact", string.IsNullOrEmpty(txtEmergencyContact.Text) ? DBNull.Value : (object)txtEmergencyContact.Text),
                new MySqlParameter("@CellNo", string.IsNullOrEmpty(txtGuardianphone.Text) ? DBNull.Value : (object)txtGuardianphone.Text),
                new MySqlParameter("@Hobbies", string.IsNullOrEmpty(txtHobbies.Text) ? DBNull.Value : (object)txtHobbies.Text),
                new MySqlParameter("@DescribeYourself", string.IsNullOrEmpty(txtDescribeYourself.Text) ? DBNull.Value : (object)txtDescribeYourself.Text)
                    };
                    try
                    {
                        // Execute the update query using MyMethods helper class
                        int result = await md.ExecuteUpdateQuery(query, parameters);

                        // Provide feedback based on the execution result
                        if (result > 0)
                        {
                            MessageBox.Show("Personal data updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Please check if the Student_ID exists.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Display a meaningful error message
                        MessageBox.Show($"An error occurred while updating personal data: {ex.Message}");
                    }
                }
        private async Task SaveImageToDatabaseAsync(byte[] imageBytes, string studentID, string imageType)
        {
            try
            {
                using (var connection = MyCon.GetConnection())
                {
                    // Open the connection if not already opened
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    // Define the query for inserting the image
                    string query = "INSERT INTO StudentImages (Student_ID, ImageData, ImageType) " +
                                   "VALUES (@StudentID, @ImageData, @ImageType)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Add parameters for the query
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@ImageData", imageBytes);
                        command.Parameters.AddWithValue("@ImageType", imageType);

                        // Execute the query asynchronously
                        int result = await command.ExecuteNonQueryAsync();

                        // Provide feedback on success or failure
                        if (result > 0)
                        {
                            //MessageBox.Show("Image saved successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save image.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the query execution
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public async Task UpdateStudentImageAsync(string studentID, Image newImage)
        {
            try
            {
                // Convert the image to byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    newImage.Save(ms, newImage.RawFormat);  // Save image in stream
                    byte[] imageBytes = ms.ToArray();

                    // Get image type (e.g., "jpg", "png")
                    string imageType = newImage.RawFormat.ToString().ToLower();

                    // Update the image in the database
                    await UpdateImageInDatabaseAsync(studentID, imageBytes, imageType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating image: {ex.Message}");
            }
        }

        private async Task UpdateImageInDatabaseAsync(string studentID, byte[] imageBytes, string imageType)
        {
            try
            {
                // Database update query
                string query = "UPDATE studentimages SET ImageData = @ImageData, ImageType = @ImageType WHERE Student_ID = @StudentID";

                using (var conn = MyCon.GetConnection()) // Use your existing connection method
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);
                        cmd.Parameters.AddWithValue("@ImageData", imageBytes);
                        cmd.Parameters.AddWithValue("@ImageType", imageType);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Image updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No image found for this student.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating image in database: {ex.Message}");
            }
        }


        private bool isEditMode;
            private async void button1_Click(object sender, EventArgs e)
            {
            if (isEditMode)
            {
                // Update the existing data
                try
                {
                    // Update Individual Record
                    await UpdateIndividualRecord(GlobalData.SavedStudentID);
                    await UpdateHealthData(GlobalData.SavedStudentID);
                    await UpdatePersonalData(GlobalData.SavedStudentID);
                    await UpdateAdditionalProfile(GlobalData.SavedStudentID);
                    await UpdateEducationalData(GlobalData.SavedStudentID);
                    await UpdateFamilyData(GlobalData.SavedStudentID);

                    List<Sibling> siblingsList = GetSiblingsDataFromGrid(); // This method gets the sibling data from the grid

                    // Call the UpdateSiblingsDataAsync method to update the database
                    await UpdateSiblingsDataAsync(GlobalData.SavedStudentID, siblingsList);
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // For saving sibling data, if not in edit mode
                try
                {
                    // Step 1: Get the list of sibling data from the DataGridView
                    List<Sibling> siblingsList = GetSiblingsDataFromGrid();

                    // Check if there is sibling data to save
                    if (siblingsList.Count == 0)
                    {
                        MessageBox.Show("No sibling data to save.");
                        return;
                    }

                    // Step 2: Assuming you have a student ID (from IndividualRecord or other source)
                    string studentID = GlobalData.SavedStudentID;  // Use the globally saved student ID

                    // Check if Student ID is valid
                    if (string.IsNullOrWhiteSpace(studentID))
                    {
                        MessageBox.Show("Please enter a valid Student ID.");
                        return;
                    }

                    // Step 3: Save each sibling record in the database with a transaction
                    string connectionString = "server=localhost;port=3306;database=guidancedb;user=root;password=;";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        using (var transaction = await connection.BeginTransactionAsync())
                        {
                            try
                            {
                                // Loop through each sibling in the list and save it
                                foreach (var sibling in siblingsList)
                                {
                                    await SaveSiblingsData(sibling, studentID, connection, transaction);
                                }

                                // Commit the transaction
                                await transaction.CommitAsync();
                               // MessageBox.Show("Siblings data saved successfully!");
                            }
                            catch (Exception ex)
                            {
                                // If an error occurs, roll back the transaction
                                await transaction.RollbackAsync();
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors in saving process
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            if (picturestudent.Image != null) // Check if there is an image selected
            {
                // Convert image to byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    picturestudent.Image.Save(ms, picturestudent.Image.RawFormat); // Save the image in the stream
                    byte[] imageBytes = ms.ToArray();

                    // Get the file type (e.g., "jpg", "png")
                    string imageType = picturestudent.Image.RawFormat.ToString().ToLower(); // Getting image type

                    // Save the image to the database
                    await SaveImageToDatabaseAsync(imageBytes, SavedStudentID, imageType);
                }
            }

            var PersonalInfo = new PersonalData
            {
                studentID = SavedStudentID,
                Firstname = txtFirstName.Text,
                Middlename = txtMiddleName.Text,
                Lastname = txtLastName.Text,
                Nickname = txtNickname.Text,
                Sex = GetGender(),
                Age = int.TryParse(txtAge.Text, out var age) ? age : 0,
                Nationality = txtNationality.Text,
                Citizenship = txtCitizenship.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                PlaceOfBirth = txtPlaceOfBirth.Text,
                CivilStatus = Civilstatus,
                Children = GetChildStatus(),
                SpouseName = txtCivilStatus.Text == "Married" ? txtSpouseName.Text : null,
                NumberOfChildren = (int)numericUpDownNumberOfChildren.Value,
                Religion = txtReligion.Text,
                ContactNumber = txtContactNumber.Text,
                EmailAddress = txtEmailAddress.Text,
                CompleteHomeAddress = txtCompleteHomeAddress.Text,
                BoardingHouseAddress = txtBoardingHouseAddress.Text,
                LandlordName = txtLandlordName.Text,
                PersonToContact = txtEmergencyContact.Text,
                CellNumber = txtGuardianphone.Text,
                Hobbies = txtHobbies.Text,
                DescribeYourself = txtDescribeYourself.Text // // Uncomment if needed
            };
            
            //await SaveStudentRecord(PersonalInfo);
            var father = new StudentRecord.FamilyData
            {

                studentID = SavedStudentID,
                ParentType = "Father",
                LivingStatus = GetLivingStatus("Father"),
                Name = txtFatherName.Text ?? string.Empty,  // Ensure Name is not null
                TelCellNo = txtFatherPhone.Text ?? string.Empty,  // Ensure phone number is not null
                Nationality = txtFatherNationality.Text ?? string.Empty,  // Ensure nationality is not null
                EducationalAttainment = txtFatherEducationalAttainment.Text ?? string.Empty,  // Ensure educational attainment is not null
                Occupation = txtFatherOccupation.Text ?? string.Empty,  // Ensure occupation is not null
                EmployerAgency = txtFatherEmployerAgency.Text ?? string.Empty,  // Ensure employer agency is not null
                WorkingAbroad = GetFatherWorkingAbroad(),
                MaritalStatus = GetFatherMaritalStatus(),  // Marital Status can return null if no radio button is selected
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = int.TryParse(txtFatherNoOfChildren.Text, out var fatherChildren) ? fatherChildren : 0,
                StudentsBirthOrder = int.TryParse(txtFatherBirthOrder.Text, out var fatherBirthOrder) ? fatherBirthOrder : 0,
                LanguageDialect = txtFatherLanguageDialect.Text ?? string.Empty,  // Ensure language dialect is not null
                FamilyStructure = GetFamilyStructure(),  // Family Structure can return null if no radio button is selected
                IndigenousGroup = GetIndigenousGroup(),  // Indigenous Group can return null if no radio button is selected
                Beneficiary4Ps = GetBeneficiary4Ps()
            };

            var mother = new FamilyData
            {
                studentID = SavedStudentID,
                ParentType = "Mother",
                LivingStatus = GetLivingStatus("Mother"),
                Name = txtMotherName.Text,
                TelCellNo = txtMotherTelCellNo.Text,
                Nationality = txtMotherNationality.Text,
                EducationalAttainment = txtMotherEducationalAttainment.Text,
                Occupation = txtMotherOccupation.Text,
                EmployerAgency = txtMotherEmployerAgency.Text,
                WorkingAbroad = GetMotherWorkingAbroad(),
                MaritalStatus = GetMotherMaritalStatus(), // Similar function for mother
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = father.NoOfChildren, // Use the same value as the father
                StudentsBirthOrder = father.StudentsBirthOrder, // Use the same value as the father
                LanguageDialect = father.LanguageDialect, // Use the same value as the father
                FamilyStructure = father.FamilyStructure, // Use the same value as the father
                IndigenousGroup = father.IndigenousGroup, // Use the same value as the father
                Beneficiary4Ps = GetBeneficiary4Ps() // Us   e the same value as the father
            };
            //await SaveFamilyData(father);
            //await SaveFamilyData(mother);
            var Education = new StudentRecord.EducationalData
            {
                studentID = SavedStudentID,
                Elementary = Elementary.Text,
                ElementaryHonorAwards = ElementaryHonorAwards.Text,
                ElementaryYearGraduated = ElementaryYearGraduated.Text,

                HighSchool = HighSchool.Text,
                JuniorHighYearGraduated = JuniorHighYearGraduated.Text,
                JuniorHighHonorAwards = JuniorHighHonorAwards.Text,
                SeniorHighSchool = SeniorHighSchool.Text,
                SeniorHighYearGraduated = SeniorHighYearGraduated.Text,
                SeniorHighHonorAwards = SeniorHighHonorAwards.Text,

                StrandCompleted = StrandCompleted.Text,
                VocationalTechnical = VocationalTechnical.Text,
                SHSAverageGrade = int.TryParse(SHSAverageGrade.Text, out var average) ? average : 0,
                College = CollegeIfTransferee.Text,
                FavoriteSubject = FavoriteSubject.Text,
                WhyFavoriteSubject = WhyFavoriteSubject.Text,
                LeastFavoriteSubject = LeastFavoriteSubject.Text,
                WhyLeastFavoriteSubject = WhyLeastFavoriteSubject.Text,
                SupportForStudies = SupportForStudies.Text,
                Membership = Membership.Text,
                LeftRightHanded = RightHanded.Checked ? "Right Handed" : LeftHanded.Checked ? "LeftHanded" : null,
            };
            //await TestSaveEducationalData(Education);


            var Health = new HealthData
            {
                studentID = SavedStudentID,
                SickFrequency = GetSickFrequency(),

                HealthProblems = GetHealthProblems(),

                PhysicalDisabilities = GetPhysicalDisabilities()
            };
            if (string.IsNullOrEmpty(SavedStudentID))
            {
                MessageBox.Show("Please save the Individual Record first.");
                return;
            }
           // await TestSaveHealthData(Health);


            var AdditionalInfo = new AdditionalProfile
            {
                studentID = SavedStudentID,
                SexualPreference = GetGenderIdentity(),
                ExpressionPresent = GetGenderExpression(),
                GenderSexuallyAttracted = GetGenderSexuallyAttracted(),
                HasScholarship = rbScholarshipYes.Checked ? "Yes" : rbScholarshipNo.Checked ? "No" : null,
                ScholarshipName = txtScholarshipName.Text
            };
            //await TestSaveAdditionalProfile(AdditionalInfo);
            var siblingsData = new Sibling
            {

            };


            try
            {
                if (string.IsNullOrEmpty(SavedStudentID))
                {
                    // If StudentID is empty, show a message and stop further execution
                    MessageBox.Show("Please save the Individual Record first and ensure the Student ID is filled.");
                    return; // Exit the method, no saving will occur
                }
                // Call the async SaveAllRecords method with await
               await SaveAllRecordsAsync(PersonalInfo, Health, AdditionalInfo,Education,father,mother);
                


                // If all records are saved successfully, show a success message
                MessageBox.Show("Record saved successfully!");
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show($"Await: {ex.Message}");
            }
        }
        private bool ValidateSiblingRow(DataGridViewRow row)
        {
            // Validate the "Name" field
            if (string.IsNullOrWhiteSpace(row.Cells["Name"].Value?.ToString()))
            {
                MessageBox.Show("Name cannot be empty in the sibling's data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate the "School" field
            if (string.IsNullOrWhiteSpace(row.Cells["School"].Value?.ToString()))
            {
                MessageBox.Show("School cannot be empty in the sibling's data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate the "Educational_Attainment" field
            if (string.IsNullOrWhiteSpace(row.Cells["Educational_Attainment"].Value?.ToString()))
            {
                MessageBox.Show("Educational Attainment cannot be empty in the sibling's data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate the "Employment_Business_Agency" field
            if (string.IsNullOrWhiteSpace(row.Cells["Employment_Business_Agency"].Value?.ToString()))
            {
                MessageBox.Show("Employment/Business/Agency cannot be empty in the sibling's data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // All fields are valid
            }
            private bool ValidateSiblingsDataGridView(DataGridView dataGridView)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Skip new rows (if the user hasn't added anything)
                    if (row.IsNewRow) continue;

                    // Validate the current row
                    if (!ValidateSiblingRow(row))
                    {
                        return false; // Stop further validation if one row fails
                    }
                }

                return true; // All rows are valid
            }


        private List<Sibling> GetSiblingsDataFromGrid()
        {
            var siblingsList = new List<Sibling>();

            foreach (DataGridViewRow row in dgvSiblings.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                // Try to get the value for each column
                string name = row.Cells["Name"].Value?.ToString();
                string school = row.Cells["School"].Value?.ToString();
                string educationalAttainment = row.Cells["Educational_Attainment"].Value?.ToString();
                string employmentBusinessAgency = row.Cells["Employment_Business_Agency"].Value?.ToString();

                // Try to get the Age value, handling any invalid data
                int age = 0;
                if (row.Cells["Age"].Value != null && int.TryParse(row.Cells["Age"].Value.ToString(), out age))
                {
                    // Successfully parsed age
                }
                else
                {
                    // Handle invalid age data, maybe set a default or show a warning
                    MessageBox.Show("Invalid age data found.");
                    continue; // Skip this row if age is invalid
                }

                // Create a new Sibling object and add to the list
                var sibling = new Sibling
                {
                    Name = name,
                    Age = age,
                    School = school,
                    EducationalAttainment = educationalAttainment,
                    EmploymentBusinessAgency = employmentBusinessAgency
                };

                siblingsList.Add(sibling);
            }

            return siblingsList;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Check if the tab should be disabled
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true; // Cancel the tab selection
            }
        }

        private async Task<bool> CheckStudentIDExistsAsync(string studentID)
        {
            string connectionString = "server=localhost;port=3306;database=guidancedb;user=root;password=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT COUNT(*) FROM tbl_individual_record WHERE Student_ID = @StudentID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result) > 0; // Return true if the record exists
                }
            }
        }
        public async Task<bool> IsStudentIDExist(string studentID)
        {
            MySqlConnection conn = null;

            try
            {
                // Get the connection object
                conn = MyCon.GetConnection();

                // Open the connection asynchronously
                await conn.OpenAsync();

                string query = "SELECT COUNT(*) FROM tbl_individual_record WHERE Student_ID = @StudentID";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Add the parameter for SQL query
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    // Execute the query and retrieve the count asynchronously
                    var result = await cmd.ExecuteScalarAsync();

                    // Return true if a record was found, otherwise false
                    return Convert.ToInt32(result) > 0;
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions and display the error message
                MessageBox.Show($"Error checking existing Student ID: {ex.Message}");
                return false;
            }
            finally
            {
                // Ensure the connection is closed after the operation
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    await conn.CloseAsync();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that StudentID is not empty
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    lblRequired.Visible = true;
                    return;
                }
               
                //bool studentExists = await CheckStudentIDExistsAsync(txtStudentID.Text);
                //if (studentExists)
                //{
                //    // If the student exists, show a message and do not save again
                //    MessageBox.Show("This Student ID already exists. You cannot save it again.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return; // Prevent further saving
                //}
                if (!ValidateCurrentTabPage())
                {
                    return; // Stop if validation fails
                }

                if (tabControl1.SelectedIndex == 1) // Assuming siblings data is in the second tab
                {
                    if (!ValidateSiblingsDataGridView(dgvSiblings))
                    {
                        return; // Stop if siblings data is invalid
                    }
                }
                // Save Individual Record only if it hasn't been saved yet
                if (!isIndividualRecordSaved)
                {
                    // Create the IndividualRecord object
                    IndividualRecord individualRecord = new IndividualRecord
                    {
                        studentID = txtStudentID.Text,
                        Course = cmbCourse.Text,
                        Year = int.TryParse(cmbYear.Text, out var year) ? year : 0,
                        StudentStatus = rbIsNewStudent.Checked ? "New Student" :
                            rbIsTransferee.Checked ? "Transferee" :
                            rbIsReEntry.Checked ? "Re-entry" :
                            rbisShifter.Checked ? "Shifter" : null,
                    };

                    // Save the Individual Record to the database
                    await SaveIndividualRecordAsync(individualRecord);
                    lblRequired.Visible = false;
                    isIndividualRecordSaved = true; // Mark as saved
                    SavedStudentID = txtStudentID.Text; // Store the StudentID globally if needed
                    
                    // Show success message
                    MessageBox.Show("Individual record saved successfully! You can now proceed to the next section.");
                }
                else
                {
                    // If the IndividualRecord has already been saved, just navigate to the next tab
                    MessageBox.Show("Individual record already saved. Proceeding to next section.");
                }
                // Enable the next tab and navigate to it
                int currentTabIndex = tabControl1.SelectedIndex;
                if (currentTabIndex < tabControl1.TabPages.Count - 1)
                {
                    allowTabChange = true; // Allow tab change
                    tabControl1.SelectedIndex = currentTabIndex + 1; // Navigate to the next tab
                    allowTabChange = false; // Disable tab change again
                }
                else
                {
                    MessageBox.Show("You are already on the last tab page.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors and show a meaningful message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            if (tabControl1.SelectedIndex == 0) // PersonalDataTab validation
            {
                // Add validation for PersonalDataTab
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {

                    MessageBox.Show("Please fill in all identification fields.");
                    return;
                }

                // Move to the next tab if validation passes
                if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
                {
                    tabControl1.SelectedIndex++;
                }
            }
        }
    

        private bool allowTabChange = false; // Default to false

        private bool ValidateSiblingsDataTab()
        {
            // Validate the DataGridView rows for siblings
            if (!ValidateSiblingsDataGridView(dgvSiblings))
            {
                MessageBox.Show("Please complete all sibling data before proceeding.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // All sibling data is valid
        }
        private bool ValidateHealthDataTab()
        {
            // Validate Sick Frequency
            string sickFrequency = GetSickFrequency();
            if (string.IsNullOrEmpty(sickFrequency))
            {
                MessageBox.Show("Please select how often you get sick.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Health Problems
            string healthProblems = GetHealthProblems();
            if (string.IsNullOrEmpty(healthProblems))
            {
                MessageBox.Show("Please select at least one health problem.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Physical Disabilities
            string physicalDisabilities = GetPhysicalDisabilities();
            if (string.IsNullOrEmpty(physicalDisabilities))
            {
                MessageBox.Show("Please select at least one physical disability or confirm if none.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // All validations passed
        }


        private bool ValidateCurrentTabPage()
        {
            // Get the current tab index
            int currentTabIndex = tabControl1.SelectedIndex;

            // Perform validation based on the current tab page
            switch (currentTabIndex)
            {
                case 0: // Individual Form Tab
                    return ValidateIndividualForm();

                case 1: // Family Data Tab
                    return ValidatePersonalDataTab();

                case 2: // Educational Data Tab
                    return ValidateFamilyDataTab();

                case 3: // Additional Profile Data Tab
                    return ValidateSiblingsDataTab(); 

                case 4: // Sibling Data Tab
                    return ValidateEducationalDataTab();
                case 5: // Health Data Tab
                    return ValidateHealthDataTab();
                // Add more cases for other tabs as needed

                default:
                    return true;
            }
        }
        private bool ValidateIndividualForm()
        {
            // Check required fields in the Individual Form tab
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbYear.Text) ||
                (!rbIsNewStudent.Checked && !rbIsTransferee.Checked &&
                 !rbIsReEntry.Checked && !rbisShifter.Checked))
            {
                MessageBox.Show("Please fill in all required fields in the Individual Form tab.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool ValidatePersonalDataTab()
        {
            // Check required fields in the Personal Data tab
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Please fill in all required fields in the Personal Data tab.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateFamilyDataTab()
        {
            // Check required fields in the Family Data tab
            if (string.IsNullOrWhiteSpace(txtFatherName.Text) ||
                string.IsNullOrWhiteSpace(txtMotherName.Text))
            {
                MessageBox.Show("Please fill in all required fields in the Family Data tab.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateEducationalDataTab()
        {
            // Check required fields in the Educational Data tab
            if (string.IsNullOrWhiteSpace(HighSchool.Text) ||
                string.IsNullOrWhiteSpace(SHSAverageGrade.Text))
            {
                MessageBox.Show("Please fill in all required fields in the Educational Data tab.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWithChild.Checked)
            {
                rbWithoutChild.Checked = false;
                numericUpDownNumberOfChildren.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWithoutChild.Checked)
            {
                rbWithChild.Checked = false;
                numericUpDownNumberOfChildren.Enabled = false;
                numericUpDownNumberOfChildren.Value = 0;
            }
        }


        private void enrollment_Load(object sender, EventArgs e)
        {
            //MyMethods methods = new MyMethods();



        }
        private async void cuiButton2_Click_1(object sender, EventArgs e)
        {
        }

        private void rbScholarshipNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMiddleName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtNickname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtNickname_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtContactNumber_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtReligion_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtLandlordName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtEmergencyContact_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtHobbies_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtSpouseName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtDescribeYourself_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtDescribeYourself_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtCompleteHomeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCompleteHomeAddress_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtHobbies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtSpouseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtEmergencyContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtLandlordName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtGuardianphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtFatherEducationalAttainment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherEmployerAgency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherName_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtEmailAddress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMotherEmployerAgency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherEducationalAttainment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtMotherTelCellNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherLanguageDialect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtFatherBirthOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void Elementary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void ElementaryHonorAwards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void HighSchool_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void JuniorHighHonorAwards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void SeniorHighSchool_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void SeniorHighHonorAwards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void StrandCompleted_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void SHSAverageGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void VocationalTechnical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void CollegeIfTransferee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void textBox94_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void FavoriteSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void LeastFavoriteSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void WhyFavoriteSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void WhyLeastFavoriteSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void SupportForStudies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void Membership_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtScholarshipName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void textBox103_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtHealthProblemsOther_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 is the Backspace character
            {
                e.Handled = true;  // Block the key press
            }
        }

        private void txtPhysicalDisabilitiesOther_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCitizenship_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string Civilstatus;
        private void txtCivilStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Civilstatus = txtCivilStatus.SelectedItem?.ToString();

            // Handle the enabling/disabling of the radio buttons
            if (Civilstatus == "Married" || Civilstatus == "Widowed")
            {
                // Enable the radio buttons for "With Child" and "Without Child"
                rbWithChild.Enabled = true;
                rbWithoutChild.Enabled = true;

                txtSpouseName.Enabled = Civilstatus == "Married";

                // Check the state of the radio buttons to manage the NumericUpDown
                if (rbWithoutChild.Checked)
                {
                    numericUpDownNumberOfChildren.Enabled = false; // Disable NumericUpDown for "Without Child"
                    numericUpDownNumberOfChildren.Value = 0;      // Reset the value to 0
                }
                else if (rbWithChild.Checked)
                {
                    numericUpDownNumberOfChildren.Enabled = true; // Enable NumericUpDown for "With Child"
                }

                // Combine CivilStatus with Children status
                string ChildrenStatus = rbWithChild.Checked ? "With Child" :
                                        rbWithoutChild.Checked ? "Without Child" : null;

                if (!string.IsNullOrEmpty(ChildrenStatus))
                {
                    Civilstatus += $" - {ChildrenStatus}";
                }
            }
            else if (Civilstatus == "Single")
            {
                // Disable the radio buttons and NumericUpDown for "Single"
                rbWithChild.Enabled = false;
                rbWithoutChild.Enabled = false;
                rbWithChild.Checked = false;
                rbWithoutChild.Checked = false;

                txtSpouseName.Enabled = false; // Disable spouse name textbox
                txtSpouseName.Text = "";
                numericUpDownNumberOfChildren.Enabled = false; // Disable NumericUpDown
                numericUpDownNumberOfChildren.Value = 0;      // Reset the value to 0

                // For Single, the CivilStatus remains just "Single"
                Civilstatus = "Single";
            }
            else
            {
                // For other cases (if any), reset radio buttons and handle as needed
                rbWithChild.Enabled = false;
                rbWithoutChild.Enabled = false;
                rbWithChild.Checked = false;
                rbWithoutChild.Checked = false;

                txtSpouseName.Enabled = false; // Disable spouse name textbox
                txtSpouseName.Text = "";       // Clear spouse name textbox
                numericUpDownNumberOfChildren.Enabled = false; // Disable NumericUpDown
                numericUpDownNumberOfChildren.Value = 0;      // Reset the value to 0
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select an Image";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load and display the image in the PictureBox
                picturestudent.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void numericUpDownNumberOfChildren_ValueChanged(object sender, EventArgs e)
        {

        }
        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtContactNumber.Text.Length == 11 )
            {
                txtContactNumber.BackColor = Color.White; // Reset background to default
                txtContactNumber.ForeColor = Color.Black; // Reset text color
            }
            else
            {
                txtContactNumber.BackColor = Color.Red;    // Highlight background in red
                txtContactNumber.ForeColor = Color.White; // Change text color for visibility
            }
        }

        private void txtGuardianphone_TextChanged(object sender, EventArgs e)
        {
            if (txtGuardianphone.Text.Length == 11)
            {
                txtGuardianphone.BackColor = Color.White; // Reset background to default
                txtGuardianphone.ForeColor = Color.Black; // Reset text color
            }
            else
            {
                txtGuardianphone.BackColor = Color.Red;    // Highlight background in red
                txtGuardianphone.ForeColor = Color.White; // Change text color for visibility
            }
        }
        private void txtFatherPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtFatherPhone.Text.Length == 11)
            {
                txtFatherPhone.BackColor = Color.White; // Reset background to default
                txtFatherPhone.ForeColor = Color.Black; // Reset text color
            }
            else
            {
                txtFatherPhone.BackColor = Color.Red;    // Highlight background in red
                txtFatherPhone.ForeColor = Color.White; // Change text color for visibility
            }
        }

        private void txtMotherTelCellNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMotherTelCellNo.Text.Length == 11)
            {
                txtMotherTelCellNo.BackColor = Color.White; // Reset background to default
                txtMotherTelCellNo.ForeColor = Color.Black; // Reset text color
            }
            else
            {
                txtMotherTelCellNo.BackColor = Color.Red;    // Highlight background in red
                txtMotherTelCellNo.ForeColor = Color.White; // Change text color for visibility
            }
        }
        // Enrollment Form - Load Existing Siblings Data to dgvSiblings
        public void LoadSiblingsDataToDataGridView(List<Sibling> siblings)
        {
            // Clear any existing rows in dgvSiblings before adding new data
            dgvSiblings.Rows.Clear();
            dgvSiblings.EnableHeadersVisualStyles = false;
            dgvSiblings.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvSiblings.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvSiblings.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvSiblings.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSiblings.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSiblings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          



            // Loop through the list of siblings and add rows to dgvSiblings
            foreach (var sibling in siblings)
            {
                // Add a new row and populate the data
                int rowIndex = dgvSiblings.Rows.Add();
                dgvSiblings.Rows[rowIndex].Cells["Name"].Value = sibling.Name;
                dgvSiblings.Rows[rowIndex].Cells["Age"].Value = sibling.Age;
                dgvSiblings.Rows[rowIndex].Cells["School"].Value = sibling.School;
                dgvSiblings.Rows[rowIndex].Cells["Educational_Attainment"].Value = sibling.EducationalAttainment;
                dgvSiblings.Rows[rowIndex].Cells["Employment_Business_Agency"].Value = sibling.EmploymentBusinessAgency;
            }
        }

        // Method to retrieve sibling data from DataGridView
        private List<Sibling> GetSiblingsFromGrid()
        {
            List<Sibling> siblings = new List<Sibling>();

            // Loop through all rows in dgvSiblings to get sibling data
            foreach (DataGridViewRow row in dgvSiblings.Rows)
            {
                // Skip the new row placeholder (empty row at the bottom)
                if (row.IsNewRow) continue;

                // Retrieve values for each column
                string name = row.Cells["Name"].Value?.ToString();
                int age = row.Cells["Age"].Value != null ? Convert.ToInt32(row.Cells["Age"].Value) : 0;
                string school = row.Cells["School"].Value?.ToString();
                string educationalAttainment = row.Cells["Educational_Attainment"].Value?.ToString();
                string employmentBusinessAgency = row.Cells["Employment_Business_Agency"].Value?.ToString();

                // Create and add sibling object to the list
                siblings.Add(new Sibling
                {
                    Name = name,
                    Age = age,
                    School = school,
                    EducationalAttainment = educationalAttainment,
                    EmploymentBusinessAgency = employmentBusinessAgency
                });
            }

            return siblings;
        }

        // Allow adding new rows to dgvSiblings (already enabled in the DataGridView settings)
        private void EnableAddingRowsInDGV()
        {
            dgvSiblings.AllowUserToAddRows = true; // Allow new rows at the bottom of the DataGridView for adding new sibling data
        }
        public List<Sibling> GetSiblingsByStudentId(string studentId)
        {
            List<Sibling> siblings = new List<Sibling>();

            string query = "SELECT * FROM tbl_brothers_sisters WHERE Student_ID = @Student_ID";

         
                MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection());
                command.Parameters.AddWithValue("@Student_ID", studentId);

               
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        siblings.Add(new Sibling
                        {
                            SiblingsID = !reader.IsDBNull(reader.GetOrdinal("Siblings_ID")) ? reader.GetInt32(reader.GetOrdinal("Siblings_ID")) : 0,
                            studentID = !reader.IsDBNull(reader.GetOrdinal("Student_ID")) ? reader.GetString(reader.GetOrdinal("Student_ID")) : string.Empty,
                            Name = !reader.IsDBNull(reader.GetOrdinal("Name")) ? reader.GetString(reader.GetOrdinal("Name")) : string.Empty,
                            Age = !reader.IsDBNull(reader.GetOrdinal("Age")) ? reader.GetInt32(reader.GetOrdinal("Age")) : 0,
                            School = !reader.IsDBNull(reader.GetOrdinal("School")) ? reader.GetString(reader.GetOrdinal("School")) : string.Empty,
                            EducationalAttainment = !reader.IsDBNull(reader.GetOrdinal("Educational_Attainment")) ? reader.GetString(reader.GetOrdinal("Educational_Attainment")) : string.Empty,
                            EmploymentBusinessAgency = !reader.IsDBNull(reader.GetOrdinal("Employment_Business_Agency")) ? reader.GetString(reader.GetOrdinal("Employment_Business_Agency")) : string.Empty
                        });
                }
                
            }

            return siblings;
        }
        public void LoadEducationalDataToForm(string studentId)
        {
            DataAccess dataAccess = new DataAccess();
            var educationalData = dataAccess.GetEducationalDataByStudentId(studentId);

            if (educationalData != null)
            {
                txtStudentID.Text = educationalData.studentID;
                Elementary.Text = educationalData.Elementary;
                ElementaryHonorAwards.Text = educationalData.ElementaryHonorAwards;
                ElementaryYearGraduated.Text = educationalData.ElementaryYearGraduated;

                HighSchool.Text = educationalData.HighSchool;
                JuniorHighYearGraduated.Text = educationalData.JuniorHighYearGraduated;
                JuniorHighHonorAwards.Text = educationalData.JuniorHighHonorAwards;
                SeniorHighSchool.Text = educationalData.SeniorHighSchool;
                SeniorHighYearGraduated.Text = educationalData.SeniorHighYearGraduated;
                SeniorHighHonorAwards.Text = educationalData.SeniorHighHonorAwards;

                StrandCompleted.Text = educationalData.StrandCompleted;
                VocationalTechnical.Text = educationalData.VocationalTechnical;
                SHSAverageGrade.Text = educationalData.SHSAverageGrade.ToString();
                CollegeIfTransferee.Text = educationalData.College;

                FavoriteSubject.Text = educationalData.FavoriteSubject;
                WhyFavoriteSubject.Text = educationalData.WhyFavoriteSubject;
                LeastFavoriteSubject.Text = educationalData.LeastFavoriteSubject;
                WhyLeastFavoriteSubject.Text = educationalData.WhyLeastFavoriteSubject;
                SupportForStudies.Text = educationalData.SupportForStudies;
                Membership.Text = educationalData.Membership;
                RightHanded.Checked = educationalData.LeftRightHanded == "Right Handed";
                LeftHanded.Checked = educationalData.LeftRightHanded == "Left Handed";
            }
            else
            {
                MessageBox.Show("No educational data found for the student.");
            }
        }
        public void LoadHealthData(string studentId)
        {
            DataAccess dataAccess = new DataAccess();
            HealthData healthData = dataAccess.GetHealthDataByStudentId(studentId);

            if (healthData != null)
            {
                // Populate the form with the retrieved health data
                // Example:
                if (healthData.SickFrequency == "Yes")
                    rbSickOften.Checked = true;
                else if (healthData.SickFrequency == "No")
                    rbSickNo.Checked = true;
                else if (healthData.SickFrequency == "Seldom")
                    rbSickSeldom.Checked = true;
                else if (healthData.SickFrequency == "Sometimes")
                    rbSickSometimes.Checked = true;
                else if (healthData.SickFrequency == "Never")
                    rbSickNever.Checked = true;

                // Set checkboxes for Health Problems
                if (healthData.HealthProblems.Contains("Dysmenorrhea"))
                    chkDysmenorrhea.Checked = true;
                if (healthData.HealthProblems.Contains("Headache"))
                    chkHeadache.Checked = true;
                if (healthData.HealthProblems.Contains("Asthma"))
                    chkAsthma.Checked = true;
                // Add other health problems similarly...

                // Set checkboxes for Physical Disabilities
                if (healthData.PhysicalDisabilities.Contains("Visual Impairment"))
                    chkVisualImpairment.Checked = true;
                if (healthData.PhysicalDisabilities.Contains("Polio"))
                    chkPolio.Checked = true;
                if (healthData.PhysicalDisabilities.Contains("Hearing Impairment"))
                    chkHearingImpairment.Checked = true;
                // Add other physical disabilities similarly...

            }
            else
            {
                MessageBox.Show("No health data found for this student.");
            }
        }
        public void LoadAdditionalProfileData(string studentId)
        {
            DataAccess dataAccess = new DataAccess();   
            var additionalProfile = dataAccess.GetAdditionalProfileByStudentId(studentId);

            if (additionalProfile != null)
            {
                // Populate the form fields with the retrieved data
                // Example:
                txtScholarshipName.Text = additionalProfile.ScholarshipName;

                // Handle HasScholarship
                if (additionalProfile.HasScholarship == "Yes")
                {
                    rbScholarshipYes.Checked = true;
                }
                else if (additionalProfile.HasScholarship == "No")
                {
                    rbScholarshipNo.Checked = true;
                }

                // Handle Gender Identity
                if (additionalProfile.SexualPreference == "Male") rbMaleindentity.Checked = true;
                else if (additionalProfile.SexualPreference == "Female") rbFemaleidentity.Checked = true;
                else if (additionalProfile.SexualPreference == "Lesbian") rbLezbian.Checked = true;
                else if (additionalProfile.SexualPreference == "Gay") rbGay.Checked = true;
                else if (additionalProfile.SexualPreference == "Bisexual") rbBisexual.Checked = true;
                else if (additionalProfile.SexualPreference == "Transgender") rbTransgender.Checked = true;

                // Handle Gender Expression
                if (additionalProfile.ExpressionPresent == "Masculine") rbExpressionMasculine.Checked = true;
                else if (additionalProfile.ExpressionPresent == "Feminine") rbExpressionFeminine.Checked = true;
                else if (additionalProfile.ExpressionPresent == "Androgynous") rbExpressionAndrogynous.Checked = true;

                // Handle Gender Sexually Attracted
                if (additionalProfile.GenderSexuallyAttracted == "Male") rbAttractedToMale.Checked = true;
                else if (additionalProfile.GenderSexuallyAttracted == "Female") rbAttractedToFemale.Checked = true;
                else if (additionalProfile.GenderSexuallyAttracted == "Lesbian") rbAttractedToLesbian.Checked = true;
                else if (additionalProfile.GenderSexuallyAttracted == "Gay") rbAttractedToGay.Checked = true;
                else if (additionalProfile.GenderSexuallyAttracted == "Bisexual") rbAttractedToBisexual.Checked = true;
                else if (additionalProfile.GenderSexuallyAttracted == "Transgender") rbAttractedToTransgender.Checked = true;

            }
            else
            {
                MessageBox.Show("No additional profile data found for this student.");
            }
        }
        public void SetEditMode(string studentId)
        {
            
            txtStudentID.Enabled = false;
            // Load the data for the student
            LoadStudentData(studentId);
            LoadIndividualRecord(studentId);
            LoadHealthDataToForm(studentId);

            // Load father's family data
            LoadFamilyDataToForm(studentId, "Father");

            
            string parenrType = "Mother";
            LoadMotherDataToForm(studentId, parenrType);

            // Load educational and health data
            LoadEducationalDataToForm(studentId);
            LoadHealthData(studentId);

            // Load additional profile data
            LoadAdditionalProfileData(studentId);

            // Load siblings and set them in the data grid
            List<Sibling> siblings = GetSiblingsByStudentId(studentId);
            LoadSiblingsDataToDataGridView(siblings);

            // Update the save button to indicate Edit Mode
            button1.Text = "Update";

            // Set the global edit mode flag
            isEditMode = true;

            // Save the Student ID globally
            GlobalData.SavedStudentID = studentId;
        }
        private void btnaddrow_Click(object sender, EventArgs e)
        {

        }
        //public bool isTabLocked = true; // Initially locked

        //private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (!isTabLocked) return; // Allow clicking if tabs are unlocked

        //    for (int i = 0; i < tabControl1.TabCount; i++)
        //    {
        //        Rectangle tabRect = tabControl1.GetTabRect(i);

        //        // Check if the click is within the tab header
        //        if (tabRect.Contains(e.Location))
        //        {
        //            e = null; // Nullify the click to prevent tab change
        //            break;
        //        }
        //    }
        //}
        private async Task LoadImageFromDatabaseAsync(string studentID, PictureBox pictureBox)
        {
            try
            {
                // Get the connection
                var conn = MyCon.GetConnection(); // Assuming MyCon.GetConnection() returns the correct MySqlConnection

                // Open the connection if it's not already open
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }

                // SQL query to fetch image
                string query = "SELECT ImageData FROM studentimages WHERE Student_ID = @StudentID LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    // Execute the query and retrieve the image data
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            byte[] imageBytes = reader["ImageData"] as byte[];

                            if (imageBytes != null)
                            {
                                // Convert byte[] to an image and set it in the PictureBox
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Image data is empty for this Student ID.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No image found for this Student ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the image: {ex.Message}");
            }
        }
        public async void LLoadStudentData(string studentID,PictureBox pictureBox)
        {
            // Load other student data (like name, course, etc.)

            // Load image from database
             await LoadImageFromDatabaseAsync(studentID,pictureBox);
        }

        //private void tabControl1_Selecting_1(object sender, TabControlCancelEventArgs e)
        //{
        //    if (e.Action == TabControlAction.Selecting && !allowTabChange)
        //    {
        //        e.Cancel = true; // Cancel the manual tab change
        //    }
        //}

    }
}



