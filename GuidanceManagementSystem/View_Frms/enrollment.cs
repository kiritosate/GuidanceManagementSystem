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
                //txtPersonalDataID.Text = record.PersonalDataID?.ToString();
                //txtFamilyDataID.Text = record.FamilyDataID?.ToString();
                //txtSiblingsID.Text = record.SiblingsID?.ToString();
                //txtEducationalID.Text = record.EducationalID?.ToString();
                //txtAdditionalProfileID.Text = record.AdditionalProfileID?.ToString();
                //txtHealthDataID.Text = record.HealthDataID?.ToString();
                // chkStatus.Checked = record.Status;
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
                studentID = txtStudentID.Text,
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
                        MessageBox.Show(result > 0 ? "Family data saved!" : "Family data not saved.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private async Task SaveAllRecordsAsync(
        EducationalData Education
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
                        //string studentID = await SaveIndividualRecord(IndividualInfo, connection, transaction);

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
                        MessageBox.Show(result > 0 ? "Personal data saved!" : "Personal data not saved.");

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
                    MessageBox.Show(result > 0 ? "Educational data saved!" : "Educational data not saved.");
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
                        MessageBox.Show(result > 0 ? "Health data saved!" : "Health data not saved.");
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
                        MessageBox.Show(result > 0 ? "Additional profile saved!" : "Additional profile not saved.");
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
            rbFatherLivingTogether.Checked ? "Living Together" :
            rbFatherSeparated.Checked ? "Separated" :
            rbFatherWithAnotherPartner.Checked ? "Father with Another Partner" :
            "Unknown";

        private string GetMotherMaritalStatus() =>
            rbMotherAnnulled.Checked ? "Annulled" :
            rbMotherWidowed.Checked ? "Widowed" :
            rbMotherWithAnotherPartner.Checked ? "Mother with Another Partner" :
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

        
        private async void button1_Click(object sender, EventArgs e)
        {
             var PersonalInfo = new PersonalData
            {
                studentID = txtStudentID.Text,
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
                CivilStatus = Civilstatus,
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
                DescribeYourself = txtDescribeYourself.Text // // Uncomment if needed

            };
            
            await SaveStudentRecord(PersonalInfo);
            var father = new StudentRecord.FamilyData
            {

                studentID = txtStudentID.Text,
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
                studentID = txtStudentID.Text,
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
            await SaveFamilyData(father);
            await SaveFamilyData(mother);
            var Education = new StudentRecord.EducationalData
            {
                studentID = txtStudentID.Text,
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
            await TestSaveEducationalData(Education);


            var Health = new HealthData
            {
                studentID = SavedStudentID,
                SickFrequency = rbSickOften.Checked ? "Yes" :
                    rbSickNo.Checked ? "No" :
                    rbSickSeldom.Checked ? "Seldom" :
                    rbSickSometimes.Checked ? "Sometimes" :
                    rbSickNever.Checked ? "Never" : null,

                HealthProblems = chkDysmenorrhea.Checked ? "Dysmenoria" : chkHeadache.Checked ? "Headache" :
                                    chkAsthma.Checked ? "Asthma" : chkStomachache.Checked ? "Stomachache" : chkHeartProblems.Checked ? "HeartProblems" :
                                    chkColdsFlu.Checked ? "Colds/Flu" : chkAbdominalPain.Checked ? "Abdominal Pain" : chkSeizureDisorders.Checked ? "Seizure Disorder" : null,

                PhysicalDisabilities = chkVisualImpairment.Checked ? "Visual Impairment" :
                           chkPolio.Checked ? "Polio" :
                           chkHearingImpairment.Checked ? "Hearing Impairment" :
                           chkCleftPalate.Checked ? "Cleft Palate" :
                           chkPhysicalDeformities.Checked ? "Physical Deformities" :
                           chkSeizureDisorders.Checked ? "Seizure Disorder" :
                           null
            };
            if (string.IsNullOrEmpty(SavedStudentID))
            {
                MessageBox.Show("Please save the Individual Record first.");
                return;
            }
            await TestSaveHealthData(Health);


            var AdditionalInfo = new AdditionalProfile
            {
                studentID = SavedStudentID,
                SexualPreference = GetGenderIdentity(),
                ExpressionPresent = GetGenderExpression(),
                GenderSexuallyAttracted = GetGenderSexuallyAttracted(),
                HasScholarship = rbScholarshipYes.Checked ? "Yes" : rbScholarshipNo.Checked ? "No" : null,
                ScholarshipName = txtScholarshipName.Text
            };
            await TestSaveAdditionalProfile(AdditionalInfo);
            var siblingsData = new Sibling
            {

            };


            try
            {
                // Call the async SaveAllRecords method with await
              // await SaveAllRecordsAsync( Education);


                // If all records are saved successfully, show a success message
                MessageBox.Show("Record saved successfully!");
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show($"Await: {ex.Message}");
            }
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

                // Enable the next tab and navigate to it
                int currentTabIndex = tabControl1.SelectedIndex;
                if (currentTabIndex < tabControl1.TabPages.Count - 1)
                {

                    // Enable the next tab page
                    tabControl1.TabPages[currentTabIndex + 1].Enabled = true;

                    // Move to the next tab
                    tabControl1.SelectedIndex = currentTabIndex + 1;
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
            try
            {
                // Step 1: Get the list of sibling data from the DataGridView
                List<Sibling> siblingsData = GetSiblingsDataFromGrid();

                if (siblingsData.Count == 0)
                {
                    MessageBox.Show("No sibling data to save.");
                    return;
                }

                // Step 2: Assuming you have a student ID (from IndividualRecord or other source)
                string studentID = txtStudentID.Text;  // Example of getting the Student ID

                if (string.IsNullOrWhiteSpace(studentID))
                {
                    MessageBox.Show("Please enter a valid Student ID.");
                    return;
                }

                // Step 3: Save each sibling record in the database
                string connectionString = "server=localhost;port=3306;database=guidancedb;user=root;password=;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var transaction = await connection.BeginTransactionAsync())
                    {
                        try
                        {
                            // Loop through each sibling in the list and save it
                            foreach (var sibling in siblingsData)
                            {
                                await SaveSiblingsData(sibling, studentID, connection, transaction);
                            }

                            // Commit the transaction
                            await transaction.CommitAsync();
                            MessageBox.Show("Siblings data saved successfully!");
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
                // Handle any unexpected errors
                MessageBox.Show($"Error: {ex.Message}");
            }
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
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";  // Filter for image files

            // Show the dialog and check if a file is selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path of the selected image
                string filePath = openFileDialog.FileName;

                // Optionally, you can display the image in a PictureBox (if you have one on the form)
                pictureBox1.Image = new System.Drawing.Bitmap(filePath);

                // Optionally, you can store the file path somewhere if you need it later
                textBoxFilePath.Text = filePath; // (Assuming you have a TextBox to show the file path)
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

       

        private void btnaddrow_Click(object sender, EventArgs e)
        {

        }
    }
}



