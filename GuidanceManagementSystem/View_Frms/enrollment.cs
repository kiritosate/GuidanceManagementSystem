using GuidanceManagementSystem.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GuidanceManagementSystem.methods.MyMethods;
using static GuidanceManagementSystem.StudentRecord;


namespace GuidanceManagementSystem
{
    public partial class enrollment : Form
    {
        //private List<TextBox> siblingNameTextBoxes = new List<TextBox>();
        //private List<TextBox> siblingAgeTextBoxes = new List<TextBox>();
        // Add more lists as needed for other fields

        //private int SiblingCount = 0; // Initialize counte

        // private int SiblingCount = 0; // Initialize counter


        private bool isIndividualRecordSaved = false;

        MyMethods methods = new MyMethods();


        private async Task SaveFamilyData(FamilyData father, FamilyData mother, string studentID, MySqlConnection connection, MySqlTransaction transaction)
        {
            // Save Father's Data
            string query = @"INSERT INTO tbl_family_data (Student_ID,
                        Parents_Name, 
                        Tel_Cell_No, 
                        Nationality, 
                        Educational_Attainment, 
                        Occupation, 
                        Employer_Agency, 
                        Working_Abroad, 
                        Marital_Status, 
                        Monthly_Income, 
                        No_of_Children, 
                        Students_Birth_Order, 
                        Language_Dialect, 
                        Family_Structure, 
                        Indigenous_Group, 
                        Beneficiary_4Ps
                    ) 
                    VALUES 
                    (   @StudentID, 
                        @ParentsName, 
                        @TelCellNo, 
                        @Nationality, 
                        @EducationalAttainment, 
                        @Occupation, 
                        @EmployerAgency, 
                        @WorkingAbroad, 
                        @MaritalStatus, 
                        @MonthlyIncome, 
                        @NoOfChildren, 
                        @StudentsBirthOrder, 
                        @LanguageDialect, 
                        @FamilyStructure, 
                        @IndigenousGroup, 
                        @Beneficiary4Ps
                    );";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
                // Parameter assignments for Father's data
                command.Parameters.AddWithValue("@FamilyDataId", father.FamilyDataId);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@ParentsName", "Father");
                command.Parameters.AddWithValue("@TelCellNo", father.TelCellNo);
                command.Parameters.AddWithValue("@Nationality", father.Nationality);
                command.Parameters.AddWithValue("@EducationalAttainment", father.EducationalAttainment);
                command.Parameters.AddWithValue("@Occupation", father.Occupation);
                command.Parameters.AddWithValue("@EmployerAgency", father.EmployerAgency);
                command.Parameters.AddWithValue("@WorkingAbroad", father.WorkingAbroad);
                command.Parameters.AddWithValue("@MaritalStatus", father.MaritalStatus);
                command.Parameters.AddWithValue("@MonthlyIncome", father.MonthlyIncome);
                command.Parameters.AddWithValue("@NoOfChildren", father.NoOfChildren);
                command.Parameters.AddWithValue("@StudentsBirthOrder", father.StudentsBirthOrder);
                command.Parameters.AddWithValue("@LanguageDialect", father.LanguageDialect);
                command.Parameters.AddWithValue("@FamilyStructure", father.FamilyStructure);
                command.Parameters.AddWithValue("@IndigenousGroup", father.IndigenousGroup);
                command.Parameters.AddWithValue("@Beneficiary4Ps", father.Beneficiary4Ps);

                await command.ExecuteNonQueryAsync();
            }

            // Save Mother's Data
            using (var command = new MySqlCommand(query, connection, transaction))
            {
                // Parameter assignments for Mother's data
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@ParentsName", "Mother");
                command.Parameters.AddWithValue("@TelCellNo", mother.TelCellNo);
                command.Parameters.AddWithValue("@Nationality", mother.Nationality);
                command.Parameters.AddWithValue("@EducationalAttainment", mother.EducationalAttainment);
                command.Parameters.AddWithValue("@Occupation", mother.Occupation);
                command.Parameters.AddWithValue("@EmployerAgency", mother.EmployerAgency);
                command.Parameters.AddWithValue("@WorkingAbroad", mother.WorkingAbroad);
                command.Parameters.AddWithValue("@MaritalStatus", mother.MaritalStatus);
                command.Parameters.AddWithValue("@MonthlyIncome", mother.MonthlyIncome);
                command.Parameters.AddWithValue("@NoOfChildren", mother.NoOfChildren);
                command.Parameters.AddWithValue("@StudentsBirthOrder", mother.StudentsBirthOrder);
                command.Parameters.AddWithValue("@LanguageDialect", mother.LanguageDialect);
                command.Parameters.AddWithValue("@FamilyStructure", mother.FamilyStructure);
                command.Parameters.AddWithValue("@IndigenousGroup", mother.IndigenousGroup);
                command.Parameters.AddWithValue("@Beneficiary4Ps", mother.Beneficiary4Ps);

                await command.ExecuteNonQueryAsync();
            }
        }
        private async Task SaveAllRecordsAsync(

        StudentRecord studentRecord,
        EducationalData Education,
        HealthData healthData,
        FamilyData father,
        FamilyData mother)
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                // Open the connection asynchronously
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        // Save individual record
                        string studentID = txtStudentID.Text;
                        //string studentID = await SaveIndividualRecord(IndividualInfo, connection, transaction);

                        // Save other records asynchronously
                        await SaveStudentRecord(studentRecord, studentID, connection, transaction);
                        await SaveEducationalRecord(Education, studentID, connection, transaction);
                        await TestSaveHealthData(healthData);
                        await SaveFamilyData(father, mother, studentID, connection, transaction);
                        //await SaveAdditionalProfile(AdditionalInfo, studentID, connection, transaction);
                        // Save siblings with StudentID as a foreign key
                        //foreach (var siblingData in sibling)
                        //{
                        //    await SaveSiblingsData(siblingData, studentID, connection, transaction);
                        //}
                        // Commit the transaction if all inserts succeed
                        await transaction.CommitAsync();
                        MessageBox.Show("Health data saved successfully!");
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
        private async Task SaveStudentRecord(StudentRecord record, string studentID, MySqlConnection connection, MySqlTransaction transaction)
        {
            try
            {
                // SQL query to insert data into tbl_personal_data
                string query = @"
        INSERT INTO tbl_personal_data (
            Student_ID, Firstname, Middlename, Lastname, Nickname, Sex, Age, 
            Nationality, Citizenship, Date_of_Birth, Place_of_Birth, 
            Civil_Status, Spouse_Name, Number_of_Children, Religion, 
            Contact_No, E_mail_Address, Complete_Home_Address, 
            Boarding_House_Address, Landlord_Name, Person_to_contact, 
            Cell_no, Hobbies_Skills_Talents, Describe_Yourself
        ) 
        VALUES (
            @StudentID, @Firstname, @Middlename, @Lastname, @Nickname, @Sex, @Age, 
            @Nationality, @Citizenship, @DateOfBirth, @PlaceOfBirth, 
            @Civil_Status, @Spouse_Name, @Number_of_Children, @Religion, 
            @Contact_No, @E_mail_Address, @CompleteHomeAddress, 
            @BoardingHouseAddress, @LandlordName, @PersonToContact, 
            @CellNumber, @Hobbies, @DescribeYourself
        ); ";
                // Ensure the connection is open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (var command = new MySqlCommand(query, connection, transaction))
                {
                    // Parameter assignments
                    //command.Parameters.AddWithValue("@PersonalDataID", record.PersonalInfo.PersonalDataID);
                    command.Parameters.AddWithValue("@StudentID", record.PersonalInfo.studentID);
                    command.Parameters.AddWithValue("@Firstname", record.PersonalInfo.FirstName);
                    command.Parameters.AddWithValue("@Middlename", record.PersonalInfo.MiddleName);
                    command.Parameters.AddWithValue("@Lastname", record.PersonalInfo.LastName);
                    command.Parameters.AddWithValue("@Nickname", record.PersonalInfo.Nickname);
                    command.Parameters.AddWithValue("@Sex", record.PersonalInfo.Sex);
                    command.Parameters.AddWithValue("@Age", record.PersonalInfo.Age);
                    command.Parameters.AddWithValue("@Nationality", record.PersonalInfo.Nationality);
                    command.Parameters.AddWithValue("@Citizenship", record.PersonalInfo.Citizenship);
                    command.Parameters.AddWithValue("@DateOfBirth", record.PersonalInfo.DateOfBirth);
                    command.Parameters.AddWithValue("@PlaceOfBirth", record.PersonalInfo.PlaceOfBirth);
                    command.Parameters.AddWithValue("@Civil_Status", record.PersonalInfo.CivilStatus);
                    command.Parameters.AddWithValue("@Spouse_Name", record.PersonalInfo.SpouseName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Number_of_Children", record.PersonalInfo.NumberOfChildren);
                    command.Parameters.AddWithValue("@Religion", record.PersonalInfo.Religion);
                    command.Parameters.AddWithValue("@Contact_No", record.PersonalInfo.ContactNumber);
                    command.Parameters.AddWithValue("@E_mail_Address", record.PersonalInfo.EmailAddress);
                    command.Parameters.AddWithValue("@CompleteHomeAddress", record.PersonalInfo.CompleteHomeAddress);
                    command.Parameters.AddWithValue("@BoardingHouseAddress", record.PersonalInfo.BoardingHouseAddress);
                    command.Parameters.AddWithValue("@LandlordName", record.PersonalInfo.LandlordName);
                    command.Parameters.AddWithValue("@PersonToContact", record.PersonalInfo.PersonToContact);
                    command.Parameters.AddWithValue("@CellNumber", record.PersonalInfo.CellNumber);
                    command.Parameters.AddWithValue("@Hobbies", record.PersonalInfo.Hobbies);
                    command.Parameters.AddWithValue("@DescribeYourself", record.PersonalInfo.DescribeYourself);

                    // Execute the command
                    await command.ExecuteNonQueryAsync();
                    //record.PersonalInfo.PersonalDataID = Convert.ToInt32(new MySqlCommand("SELECT LAST_INSERT_ID();", connection, transaction).ExecuteScalar());
                }

                // Commit the transaction if all went well
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback the transaction if an error occurs
                MessageBox.Show($"Error saving student record: {ex.Message}");
                throw;
            }
        }



        private async Task SaveEducationalRecord(EducationalData Education, string studentID, MySqlConnection connection, MySqlTransaction transaction)
        {
            try
            {
                // SQL query to insert educational record into tbl_educational_data
                string query = @"
            INSERT INTO tbl_educational_data_final(Student_ID, Elementary, ElementaryHonorAwards, ElementaryYearGraduated, HighSchool, JuniorHighYearGraduated, JuniorHighHonorAwards, SeniorHighSchool, SeniorHighYearGraduated, SeniorHighHonorAwards, StrandCompleted, VocationalTechnical, SHSAverageGrade, College, FavoriteSubject, WhyFavoriteSubject, 
        LeastFavoriteSubject, WhyLeastFavoriteSubject, SupportForStudies, Membership, LeftRightHanded)
            VALUES (
                 @StudentID, 
                 @Elementary, 
                 @ElementaryHonorAwards,  
                 @ElementaryYearGraduated, 
                 @HighSchool, 
                 @JuniorHighYearGraduated, 
                 @JuniorHighHonorAwards, 
                 @SeniorHighSchool, 
                 @SeniorHighYearGraduated, 
                 @SeniorHighHonorAwards, 
                 @StrandCompleted, 
                 @VocationalTechnical, 
                 @SHSAverageGrade, 
                 @College, 
                 @FavoriteSubject, 
                 @WhyFavoriteSubject, 
                 @LeastFavoriteSubject, 
                 @WhyLeastFavoriteSubject, 
                 @SupportForStudies, 
                 @Membership, 
                 @LeftRightHanded
            );";

                // Ensure the connection is open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (var command = new MySqlCommand(query, connection, transaction))
                {
                    // Parameter assignments for educational data fields
                    //command.Parameters.AddWithValue("@EducationalID", Education.EducationalID);
                    command.Parameters.AddWithValue("@StudentID", Education.studentID);
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


                    // Execute the command asynchronously
                    await command.ExecuteNonQueryAsync();

                    // Optionally, if you need to fetch the last inserted ID
                    // long lastInsertId = command.LastInsertedId;

                    // Commit the transaction if everything was successful

                }
                transaction.Commit();

            }
            catch (Exception)
            {
                // Rollback the transaction in case of an error
                //MessageBox.Show($": {ex.Message}");
                // transaction.Rollback(); 
                throw;
            }
        }
        private async Task TestSaveHealthData(HealthData Health)
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = @"INSERT INTO tbl_health_data (Student_ID, Sick_Frequency, Health_Problems, Physical_Disabilities)
                         VALUES (@StudentID, @SickFrequency, @HealthProblems, @PhysicalDisabilities);";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", Health.studentID);
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
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private async Task TestSaveAdditionalProfile(AdditionalProfile AdditionalInfo)
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
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

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", AdditionalInfo.studentID);
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
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }
        private async Task SaveIndividualRecordAsync(IndividualRecord IndividualInfo)
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
            string query = @"INSERT INTO tbl_individual_record (Student_ID, Course, Year,Student_Status) 
                     VALUES (@StudentID, @Course, @Year,@StudentStatus);";

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", IndividualInfo.studentID);
                    command.Parameters.AddWithValue("@Course", IndividualInfo.Course);
                    command.Parameters.AddWithValue("@Year", IndividualInfo.Year);
                    command.Parameters.AddWithValue("@StudentStatus", IndividualInfo.StudentStatus);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }



        private async Task SaveSiblingsData(Sibling sibling, string studentID, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO tbl_brothers_sisters (Student_ID, Name, Age, School, Educational_Attainment, Employment_Business_Agency) VALUES (@StudentID, @Name, @Age, @School, @EducationalAttainment, @EmploymentBusinessAgency)";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
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

        private string GetFatherMaritalStatus()
        {
            if (rbFatherLivingTogether.Checked)
                return "Living Together";
            if (rbFatherSeparated.Checked)
                return "Separated";
            if (rbFatherWithAnotherPartner.Checked)
                return "Father with Another Partner";

            return "Unknown"; // Default case
        }


        private string GetMotherMaritalStatus()
        {
            if (rbMotherAnnulled.Checked)
                return "Annulled";
            if (rbMotherWidowed.Checked)
                return "Widowed";
            if (rbMotherWithAnotherPartner.Checked)
                return "Mother with Another Partner";

            return "Unknown"; // Default case
        }
        private string GetMonthlyIncome()
        {
            if (rbBelow5000.Checked)
                return "Below 5000";
            if (rb10001To15000.Checked)
                return "5000 - 10,000";
            if (rb10001To15000.Checked)
                return "10,001 - 15,000";
            if (rb15001To20000.Checked)
                return "15,001 - 20,000";
            if (rb20001To25000.Checked)
                return "20,001 - 25,000";
            if (rbAbove25000.Checked)
                return "25,001 and above";

            return "Unknown"; // Default case
        }
        private string GetFamilyStructure()
        {
            if (rbNuclear.Checked)
                return "Nuclear";
            if (rbExtended.Checked)
                return "Extended";

            return null; // Default case
        }

        private string GetIndigenousGroup()
        {
            if (rbIndigenousYes.Checked)
                return "Yes";
            if (rbIndigenousNo.Checked)
                return "No";

            return null; // Default
        }

        private string GetBeneficiary4Ps()
        {
            if (rbBeneficiaryYes.Checked)
                return "Yes";
            if (rbBeneficiaryNo.Checked)
                return "No";

            return null; // Default
        }
        private string GetFatherWorkingAbroad()
        {
            if (rbFatherWorkingAbroadYes.Checked)
                return "Yes";
            if (rbFatherWorkingAbroadNo.Checked)
                return "No";

            return null; // Default case if neither is checked
        }
        private string GetMotherWorkingAbroad()
        {
            if (rbMotherWorkingAbroadYes.Checked)
                return "Yes";
            if (rbMotherWorkingAbroadNo.Checked)
                return "No";

            return null; // Default case if neither is checked
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var studentRecord = new StudentRecord
            {

                PersonalInfo = new StudentRecord.PersonalData
                {
                    studentID = txtStudentID.Text,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Nickname = txtNickname.Text,
                    Sex = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : null,
                    Age = int.TryParse(txtAge.Text, out var age) ? age : 0,
                    Nationality = txtNationality.Text,
                    Citizenship = txtCitizenship.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    PlaceOfBirth = txtPlaceOfBirth.Text,
                    CivilStatus = txtCivilStatus.Text,
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

                }
            };
            var father = new StudentRecord.FamilyData
            {

                studentID = txtStudentID.Text,
                Parents = "Father",
                Name = txtFatherName.Text,
                TelCellNo = txtFatherPhone.Text,
                Nationality = txtFatherNationality.Text,
                EducationalAttainment = txtFatherEducationalAttainment.Text,
                Occupation = txtFatherOccupation.Text,
                EmployerAgency = txtFatherEmployerAgency.Text,
                WorkingAbroad = GetFatherWorkingAbroad(), // Assuming you have radio buttons
                MaritalStatus = GetFatherMaritalStatus(), // Implement this to return based on your UI
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = int.TryParse(txtFatherNoOfChildren.Text, out var fatherChildren) ? fatherChildren : 0,
                StudentsBirthOrder = int.TryParse(txtFatherBirthOrder.Text, out var fatherBirthOrder) ? fatherBirthOrder : 0,
                LanguageDialect = txtFatherLanguageDialect.Text,
                FamilyStructure = GetFamilyStructure(),
                IndigenousGroup = GetIndigenousGroup(),
                Beneficiary4Ps = GetBeneficiary4Ps(),
            };

            var mother = new StudentRecord.FamilyData
            {
                studentID = txtStudentID.Text,
                Parents = "Mother",
                Name = txtMotherName.Text,
                TelCellNo = txtMotherTelCellNo.Text,
                Nationality = txtMotherNationality.Text,
                EducationalAttainment = txtMotherEducationalAttainment.Text,
                Occupation = txtMotherOccupation.Text,
                EmployerAgency = txtMotherEmployerAgency.Text,
                WorkingAbroad = GetFatherWorkingAbroad(),
                MaritalStatus = GetMotherMaritalStatus(), // Similar function for mother
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = father.NoOfChildren, // Use the same value as the father
                StudentsBirthOrder = father.StudentsBirthOrder, // Use the same value as the father
                LanguageDialect = father.LanguageDialect, // Use the same value as the father
                FamilyStructure = father.FamilyStructure, // Use the same value as the father
                IndigenousGroup = father.IndigenousGroup, // Use the same value as the father
                Beneficiary4Ps = father.Beneficiary4Ps, // Use the same value as the father
            };
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
                await SaveAllRecordsAsync(studentRecord, Education, Health, father, mother);


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

        public string SavedStudentID { get; private set; }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that StudentID is not empty
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    MessageBox.Show("Please enter the Student ID before proceeding.");
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
                    isIndividualRecordSaved = true; // Mark as saved
                    SavedStudentID = txtStudentID.Text; // Store the StudentID globally if needed

                    // Show success message
                    MessageBox.Show("Individual record saved successfully! You can now proceed to the next section.");
                }

                // Enable the next tab and navigate to it
                int currentTabIndex = tabControl1.SelectedIndex;
                if (currentTabIndex < tabControl1.TabPages.Count - 1)
                {
                    tabControl1.TabPages[currentTabIndex + 1].Enabled = true;
                    tabControl1.SelectedIndex = currentTabIndex + 1;
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
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {

                    MessageBox.Show("Please fill in all identification fields.");
                    return;
                }
            }
            else if (tabControl1.SelectedIndex == 1) // FamilyDataTab validation
            {
                // Add validation for FamilyDataTab
                if (string.IsNullOrEmpty(tabPage6.Text))
                {
                    MessageBox.Show("Please fill in all personal data fields.");
                    return;
                }
            }
            else if (tabControl1.SelectedIndex == 2) // FamilyDataTab validation
            {
                // Add validation for FamilyDataTab
                if (string.IsNullOrEmpty(tabPage2.Text))
                {
                    MessageBox.Show("Please fill in all family data fields.");
                    return;
                }
            }
            else if (tabControl1.SelectedIndex == 3) // FamilyDataTab validation
            {
                // Add validation for FamilyDataTab
                if (string.IsNullOrEmpty(tabPage3.Text))
                {
                    MessageBox.Show("Please fill in all family data fields.");
                    return;
                }
            }
            else if (tabControl1.SelectedIndex == 4) // FamilyDataTab validation
            {
                // Add validation for FamilyDataTab
                if (string.IsNullOrEmpty(tabPage2.Text))
                {
                    MessageBox.Show("Please fill in all family data fields.");
                    return;
                }
            }
            // Move to the next tab if validation passes
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
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
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
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
                string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
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

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //    {
        //        checkBox2.Checked = false;
        //    }
        //    else
        //    {
        //        checkBox2.Checked = true;
        //    }
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox2.Checked)
        //    {
        //        checkBox1.Checked = false;
        //    }
        //    else
        //    {
        //        checkBox1.Checked = true;
        //    }
        //}

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
    }
}



