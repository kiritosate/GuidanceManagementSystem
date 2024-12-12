using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using GuidanceManagementSystem.methods;

namespace GuidanceManagementSystem
{

    internal class StudentRecord
    {
        // A. Personal Data
        public PersonalData PersonalInfo { get; set; }

        // B. Family Data
        public FamilyData father { get; set; }
        public FamilyData mother { get; set; }
        public Sibling sibling { get; set; }

        // C. Educational Data
        public EducationalData Education { get; set; }

        // D. Health Data
        public HealthData Health { get; set; }

        // E. Additional Profile
        public AdditionalProfile AdditionalInfo { get; set; }

        // F. Individual Record
        public IndividualRecord IndividualInfo { get; set; }
        public AdminAccount admin { get; set; }

        public StudentRecord()
        {
            PersonalInfo = new PersonalData();
            father = new FamilyData();
            mother = new FamilyData();
            Education = new EducationalData();
            sibling = new Sibling();
            Health = new HealthData();
            AdditionalInfo = new AdditionalProfile();
            IndividualInfo = new IndividualRecord();
        }
        public class AdminAccount
        {
            public int AdminId { get; set; }
            public string AdminName { get; set; }
            public string AdminPassword { get; set; }
        }
        public class IndividualRecord
        {

            public string studentID { get; set; }
            public string Course { get; set; }
            public int? Year{ get; set; }
            public string StudentStatus { get; set; }
            //public int PersonalDataID { get; set; }
            //public int FamilyDataID { get; set; }
            //public int SiblingsID { get; set; }
            //public int EducationalID { get; set; }
            //public int AdditionalProfileID { get; set; }
            //public int HealthDataID { get; set; }
             public bool Status { get; set; }
        }
       

        public class DataAccess
        {
           
            // Update with your actual connection string
            public FamilyData LoadFamilyData(string studentId)
            {
                FamilyData familyData = null;

                // Query your database and retrieve family data based on the Student ID
                using (MySqlConnection conn = MyCon.GetConnection())
                {
                  
                    string query = "SELECT * FROM tbl_family_data WHERE Student_ID = @studentId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            familyData = new FamilyData
                            {
                                FamilyDataId = reader.GetInt32("Family_Data_ID"),
                                studentID = reader.GetString("Student_ID"),
                                ParentType = reader.GetString("Parent_Type"),
                                Name = reader.IsDBNull(reader.GetOrdinal("Parents_Name")) ? null : reader.GetString("Parents_Name"),
                                LivingStatus = reader.GetString("Living_Status"),
                                TelCellNo = reader.IsDBNull(reader.GetOrdinal("Tel_Cell_No")) ? null : reader.GetString("Tel_Cell_No"),
                                Nationality = reader.IsDBNull(reader.GetOrdinal("Nationality")) ? null : reader.GetString("Nationality"),
                                EducationalAttainment = reader.IsDBNull(reader.GetOrdinal("Educational_Attainment")) ? null : reader.GetString("Educational_Attainment"),
                                Occupation = reader.IsDBNull(reader.GetOrdinal("Occupation")) ? null : reader.GetString("Occupation"),
                                EmployerAgency = reader.IsDBNull(reader.GetOrdinal("Employer_Agency")) ? null : reader.GetString("Employer_Agency"),
                                WorkingAbroad = reader.IsDBNull(reader.GetOrdinal("Working_Abroad")) ? null : reader.GetString("Working_Abroad"),
                                MaritalStatus = reader.IsDBNull(reader.GetOrdinal("Marital_Status")) ? null : reader.GetString("Marital_Status"),
                                MonthlyIncome = reader.IsDBNull(reader.GetOrdinal("Monthly_Income")) ? null : reader.GetString("Monthly_Income"),    
                                NoOfChildren = reader.IsDBNull(reader.GetOrdinal("No_of_Children"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("No_of_Children")),
                                StudentsBirthOrder = reader.IsDBNull(reader.GetOrdinal("Students_Birth_Order"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("Students_Birth_Order")),
                                LanguageDialect = reader.IsDBNull(reader.GetOrdinal("Language_Dialect")) ? null : reader.GetString("Language_Dialect"),
                                FamilyStructure = reader.IsDBNull(reader.GetOrdinal("Family_Structure")) ? null : reader.GetString("Family_Structure"),
                                IndigenousGroup = reader.IsDBNull(reader.GetOrdinal("Indigenous_Group")) ? null : reader.GetString("Indigenous_Group"),
                                Beneficiary4Ps = reader.IsDBNull(reader.GetOrdinal("4Ps_Beneficiary")) ? null : reader.GetString("4Ps_Beneficiary")
                        };
                            
                        }
                        
                    }
                    conn.Close();
                }

                return familyData;
            }
            public EducationalData GetEducationalDataByStudentId(string studentId)
            {
                EducationalData educationalData = null;

                string query = "SELECT * FROM tbl_educational_data_final WHERE Student_ID = @Student_ID";

               
                    MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection());
                    command.Parameters.AddWithValue("@Student_ID", studentId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            educationalData = new EducationalData
                            {
                                studentID = reader["Student_ID"]?.ToString(),
                                Elementary = reader["Elementary"]?.ToString(),
                                ElementaryHonorAwards = reader["ElementaryHonorAwards"]?.ToString(),
                                ElementaryYearGraduated = reader["ElementaryYearGraduated"]?.ToString(),
                                HighSchool = reader["HighSchool"]?.ToString(),
                                JuniorHighYearGraduated = reader["JuniorHighYearGraduated"]?.ToString(),
                                JuniorHighHonorAwards = reader["JuniorHighHonorAwards"]?.ToString(),
                                SeniorHighSchool = reader["SeniorHighSchool"]?.ToString(),
                                SeniorHighYearGraduated = reader["SeniorHighYearGraduated"]?.ToString(),
                                SeniorHighHonorAwards = reader["SeniorHighHonorAwards"]?.ToString(),
                                StrandCompleted = reader["StrandCompleted"]?.ToString(),
                                VocationalTechnical = reader["VocationalTechnical"]?.ToString(),
                                SHSAverageGrade = reader.IsDBNull(reader.GetOrdinal("SHSAverageGrade"))
                                                    ? 0
                                                    : reader.GetInt32("SHSAverageGrade"),
                                College = reader["College"]?.ToString(),
                                FavoriteSubject = reader["FavoriteSubject"]?.ToString(),
                                WhyFavoriteSubject = reader["WhyFavoriteSubject"]?.ToString(),
                                LeastFavoriteSubject = reader["LeastFavoriteSubject"]?.ToString(),
                                WhyLeastFavoriteSubject = reader["WhyLeastFavoriteSubject"]?.ToString(),
                                SupportForStudies = reader["SupportForStudies"]?.ToString(),
                                Membership = reader["Membership"]?.ToString(),
                                LeftRightHanded = reader["LeftRightHanded"]?.ToString()
                            };
                        }
                    
                }

                return educationalData;
            }

            public HealthData LoadHealthData(string studentId)
            {
                HealthData healthData = null;

                string query = "SELECT * FROM tbl_health_data WHERE Student_ID = @Student_ID";

                using (MySqlConnection connection = MyCon.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Student_ID", studentId);

                 
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            healthData = new HealthData
                            {
                                HealthDataID = reader.GetInt32("Health_Data_ID"),
                                studentID = reader.GetString("Student_ID"),
                                SickFrequency = reader.IsDBNull(reader.GetOrdinal("Sick_Frequency")) ? null : reader.GetString("Sick_Frequency"),
                                HealthProblems = reader.IsDBNull(reader.GetOrdinal("Health_Problems")) ? null : reader.GetString("Health_Problems"),
                                PhysicalDisabilities = reader.IsDBNull(reader.GetOrdinal("Physical_Disabilities")) ? null : reader.GetString("Physical_Disabilities")
                            };
                        }
                    }
                   
                }

                return healthData;
            }

            public IndividualRecord GetIndividualRecord(string studentId)
            {

                IndividualRecord individualRecord = null;
                string query = "SELECT * FROM tbl_individual_record WHERE Student_ID = @StudentID";
                using (MySqlConnection connection = MyCon.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StudentID", studentId);

                 
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            individualRecord = new IndividualRecord
                            {
                                studentID = reader.GetString("Student_ID"),
                                Course = reader.IsDBNull(reader.GetOrdinal("Course")) ? null : reader.GetString("Course"),
                                Year = reader.IsDBNull(reader.GetOrdinal("Year")) ? (int?)null : reader.GetInt32("Year"),
                                StudentStatus = reader.IsDBNull(reader.GetOrdinal("Student_Status")) ? null : reader.GetString("Student_Status"),
                                //PersonalDataID = reader.IsDBNull(reader.GetOrdinal("Personal_Data_ID")) ? (int?)null : reader.GetInt32("Personal_Data_ID"),
                                //FamilyDataID = reader.IsDBNull(reader.GetOrdinal("Family_Data_ID")) ? (int?)null : reader.GetInt32("Family_Data_ID"),
                                //SiblingsID = reader.IsDBNull(reader.GetOrdinal("Siblings_ID")) ? (int?)null : reader.GetInt32("Siblings_ID"),
                                //EducationalID = reader.IsDBNull(reader.GetOrdinal("Educational_ID")) ? (int?)null : reader.GetInt32("Educational_ID"),
                                //AdditionalProfileID = reader.IsDBNull(reader.GetOrdinal("Additional_Profile_ID")) ? (int?)null : reader.GetInt32("Additional_Profile_ID"),
                                //HealthDataID = reader.IsDBNull(reader.GetOrdinal("Health_Data_ID")) ? (int?)null : reader.GetInt32("Health_Data_ID"),
                                //Status = reader.GetBoolean("Status")
                            };
                        }
                    }
                   
                }

                return individualRecord;
            }

            public PersonalData GetPersonalData(string studentId)
            {
                PersonalData personalData = null;

                // SQL query to get all personal data fields based on Student_ID
                string query = "SELECT * FROM tbl_personal_data WHERE Student_ID = @Student_ID";

                using (MySqlConnection connection = MyCon.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Student_ID", studentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personalData = new PersonalData
                            {
                                PersonalDataID = reader.IsDBNull(reader.GetOrdinal("Personal_Data_ID")) ? 0 : reader.GetInt32("Personal_Data_ID"),
                                studentID = reader.IsDBNull(reader.GetOrdinal("Student_ID")) ? null : reader.GetString("Student_ID"),
                                Firstname = reader.IsDBNull(reader.GetOrdinal("Firstname")) ? null : reader.GetString("Firstname"),
                                Middlename = reader.IsDBNull(reader.GetOrdinal("Middlename")) ? null : reader.GetString("Middlename"),
                                Lastname = reader.IsDBNull(reader.GetOrdinal("Lastname")) ? null : reader.GetString("Lastname"),
                                Nickname = reader.IsDBNull(reader.GetOrdinal("Nickname")) ? null : reader.GetString("Nickname"),
                                Sex = reader.IsDBNull(reader.GetOrdinal("Sex")) ? null : reader.GetString("Sex"),
                                Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32("Age"),
                                Nationality = reader.IsDBNull(reader.GetOrdinal("Nationality")) ? null : reader.GetString("Nationality"),
                                Citizenship = reader.IsDBNull(reader.GetOrdinal("Citizenship")) ? null : reader.GetString("Citizenship"),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("Date_of_Birth")) ? (DateTime?)null : reader.GetDateTime("Date_of_Birth"),
                                PlaceOfBirth = reader.IsDBNull(reader.GetOrdinal("Place_of_Birth")) ? null : reader.GetString("Place_of_Birth"),
                                CivilStatus = reader.IsDBNull(reader.GetOrdinal("Civil_Status")) ? null : reader.GetString("Civil_Status"),
                                Children = reader.IsDBNull(reader.GetOrdinal("With_or_Without_Child")) ? null : reader.GetString("With_or_Without_Child"),
                                SpouseName = reader.IsDBNull(reader.GetOrdinal("Spouse_Name")) ? null : reader.GetString("Spouse_Name"),
                                NumberOfChildren = reader.IsDBNull(reader.GetOrdinal("Number_of_Children")) ? 0 : reader.GetInt32("Number_of_Children"),
                                Religion = reader.IsDBNull(reader.GetOrdinal("Religion")) ? null : reader.GetString("Religion"),
                                ContactNumber = reader.IsDBNull(reader.GetOrdinal("Contact_No")) ? null : reader.GetString("Contact_No"),
                                EmailAddress = reader.IsDBNull(reader.GetOrdinal("E_mail_Address")) ? null : reader.GetString("E_mail_Address"),
                                CompleteHomeAddress = reader.IsDBNull(reader.GetOrdinal("Complete_Home_Address")) ? null : reader.GetString("Complete_Home_Address"),
                                BoardingHouseAddress = reader.IsDBNull(reader.GetOrdinal("Boarding_House_Address")) ? null : reader.GetString("Boarding_House_Address"),
                                LandlordName = reader.IsDBNull(reader.GetOrdinal("Landlord_Name")) ? null : reader.GetString("Landlord_Name"),
                                PersonToContact = reader.IsDBNull(reader.GetOrdinal("Person_to_contact")) ? null : reader.GetString("Person_to_contact"),
                                CellNumber = reader.IsDBNull(reader.GetOrdinal("Cell_no")) ? null : reader.GetString("Cell_no"),
                                Hobbies = reader.IsDBNull(reader.GetOrdinal("Hobbies_Skills_Talents")) ? null : reader.GetString("Hobbies_Skills_Talents"),
                                DescribeYourself = reader.IsDBNull(reader.GetOrdinal("Describe_Yourself")) ? null : reader.GetString("Describe_Yourself")
                            };

                        }
                    }
                    
                }

                return personalData;
            }
            // Method to fetch sibling data from the database (this should already exist, or you can adapt it)
            public HealthData GetHealthDataByStudentId(string studentId)
            {
                HealthData healthData = null;

                string query = "SELECT * FROM tbl_health_data WHERE Student_ID = @Student_ID";
                    MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection());
                    command.Parameters.AddWithValue("@Student_ID", studentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            healthData = new HealthData
                            {
                                studentID = reader["Student_ID"]?.ToString(),
                                SickFrequency = reader["Sick_Frequency"]?.ToString(),
                                HealthProblems = reader["Health_Problems"]?.ToString(),
                                PhysicalDisabilities = reader["Physical_Disabilities"]?.ToString()
                            };
                        }
                    
                }

                return healthData;
            }
            public AdditionalProfile GetAdditionalProfileByStudentId(string studentId)
            {
                AdditionalProfile additionalProfile = null;

                string query = "SELECT * FROM tbl_additional_profile WHERE Student_ID = @Student_ID";

                using (MySqlConnection connection = MyCon.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Student_ID", studentId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            additionalProfile = new AdditionalProfile
                            {
                                studentID = reader["Student_ID"]?.ToString(),
                                SexualPreference = reader["Sexual_Preference"]?.ToString(),
                                ExpressionPresent = reader["Expression_Present"]?.ToString(),
                                GenderSexuallyAttracted = reader["Gender_Sexually_Attracted"]?.ToString(),
                                HasScholarship = reader["Scholarship"]?.ToString(),
                                ScholarshipName = reader["Name_of_Scholarship"]?.ToString()
                            };
                        }
                    }
                    
                }

                return additionalProfile;
            }


            public FamilyData GetFamilyData(string studentId, string parentType)
            {
                FamilyData familyData = null;       
                    string query = "SELECT * FROM tbl_family_data WHERE Student_ID = @studentId AND Parent_Type = @parentType";
                    MySqlCommand cmd = new MySqlCommand(query, MyCon.GetConnection());
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@parentType", parentType);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                        familyData = new FamilyData
                        {
                            FamilyDataId = reader.GetInt32("Family_Data_ID"),
                            studentID = reader.GetString("Student_ID"),
                            ParentType = reader.GetString("Parent_Type"), // Correct assignment
                            Name = reader.IsDBNull(reader.GetOrdinal("Parents_Name")) ? null : reader.GetString("Parents_Name"),
                            LivingStatus = reader.IsDBNull(reader.GetOrdinal("Living_Status")) ? null : reader.GetString("Living_Status"),
                            TelCellNo = reader.IsDBNull(reader.GetOrdinal("Tel_Cell_No")) ? null : reader.GetString("Tel_Cell_No"),
                            Nationality = reader.IsDBNull(reader.GetOrdinal("Nationality")) ? null : reader.GetString("Nationality"),
                            EducationalAttainment = reader.IsDBNull(reader.GetOrdinal("Educational_Attainment")) ? null : reader.GetString("Educational_Attainment"),
                            Occupation = reader.IsDBNull(reader.GetOrdinal("Occupation")) ? null : reader.GetString("Occupation"),
                            EmployerAgency = reader.IsDBNull(reader.GetOrdinal("Employer_Agency")) ? null : reader.GetString("Employer_Agency"),
                            WorkingAbroad = reader.IsDBNull(reader.GetOrdinal("Working_Abroad")) ? null : reader.GetString("Working_Abroad"),
                            MaritalStatus = reader.IsDBNull(reader.GetOrdinal("Marital_Status")) ? null : reader.GetString("Marital_Status"),
                            MonthlyIncome = reader.IsDBNull(reader.GetOrdinal("Monthly_Income")) ? null : reader.GetString("Monthly_Income"),
                            NoOfChildren = reader.IsDBNull(reader.GetOrdinal("No_of_Children")) ? (int?)null : reader.GetInt32("No_of_Children"),
                            StudentsBirthOrder = reader.IsDBNull(reader.GetOrdinal("Students_Birth_Order")) ? (int?)null : reader.GetInt32("Students_Birth_Order"),
                            LanguageDialect = reader.IsDBNull(reader.GetOrdinal("Language_Dialect")) ? null : reader.GetString("Language_Dialect"),
                            FamilyStructure = reader.IsDBNull(reader.GetOrdinal("Family_Structure")) ? null : reader.GetString("Family_Structure"),
                            IndigenousGroup = reader.IsDBNull(reader.GetOrdinal("Indigenous_Group")) ? null : reader.GetString("Indigenous_Group"),
                            Beneficiary4Ps = reader.IsDBNull(reader.GetOrdinal("4Ps_Beneficiary")) ? null : reader.GetString("4Ps_Beneficiary"),
                        };

                    }
                    }
                

                return familyData;
            }
        }



        // A. Personal Data
        public class PersonalData
        {
           
            public int PersonalDataID { get; set; }
            public string studentID { get; set; }
            public string Firstname { get; set; }
            public string Middlename { get; set; }
            public string Lastname { get; set; }
            public string Nickname { get; set; } // Optional field
            public string Sex { get; set; } // "Male" or "Female"
            public int Age { get; set; } // Age in years
            public string Nationality { get; set; }
            public string Citizenship { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string PlaceOfBirth { get; set; }
            public string CivilStatus { get; set; } 
            public string Children { get; set; }
            public string SpouseName { get; set; }
            public int NumberOfChildren { get; set; } // Changed to int for consistency
            public string Religion { get; set; }
            public string ContactNumber { get; set; }
            public string EmailAddress { get; set; }
            public string CompleteHomeAddress { get; set; }
            public string BoardingHouseAddress { get; set; }
            public string LandlordName { get; set; }
            public string PersonToContact { get; set; }
            public string CellNumber { get; set; }// If you want to add a separate emergency contact
            public string Hobbies { get; set; }
            public string DescribeYourself { get; set; }
        }

        // B. Family Data
        public class FamilyData
        {
            public int FamilyDataId { get; set; }
            public string studentID { get; set; }
            public string ParentType { get; set; } // New property for Father or Mother
            public string LivingStatus { get; set; }
            public string Name { get; set; }
            public string TelCellNo { get; set; }
            public string Nationality { get; set; }
            public string EducationalAttainment { get; set; }
            public string Occupation { get; set; }
            public string EmployerAgency { get; set; }
            public string WorkingAbroad { get; set; }
            public string MaritalStatus { get; set; }
            public string MonthlyIncome { get; set; }
            public int? NoOfChildren { get; set; }
            public int? StudentsBirthOrder { get; set; }
            public string LanguageDialect { get; set; }
            public string FamilyStructure { get; set; }
            public string IndigenousGroup { get; set; }
            public string Beneficiary4Ps { get; set; }
            public string FatherStatus { get; set; } // e.g., Living Together, Separated, Father with Another Partner

            // Mother's status
            public string MotherStatus { get; set; } // e.g., Annulled, Widowed, Mother with Another Parent
        }
        public class EducationalData
        {
            public int EducationalID { get; set; }
            public string studentID { get; set; }
            public string Elementary { get; set; }
            public string ElementaryHonorAwards { get; set; }
            public string ElementaryYearGraduated { get; set; }
            
            public string HighSchool { get; set; }
            public string JuniorHighYearGraduated { get; set; }
            public string JuniorHighHonorAwards { get; set; }

            public string SeniorHighSchool { get; set; }
            public string SeniorHighYearGraduated { get; set; }
            public string SeniorHighHonorAwards { get; set; }
          
            public string StrandCompleted { get; set; }
            public string VocationalTechnical { get; set; }
            public decimal? SHSAverageGrade { get; set; }
            public string College { get; set; }
            public string FavoriteSubject { get; set; }
            public string WhyFavoriteSubject { get; set; }
            public string LeastFavoriteSubject { get; set; }
            public string WhyLeastFavoriteSubject { get; set; }
            public string SupportForStudies { get; set; }
            public string Membership { get; set; }
            public string LeftRightHanded { get; set; }
        }
        
    }
    // C. Educational Data
        
        public class Sibling
        {
        public int SiblingsID { get; set; }
        public string studentID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string School { get; set; }
            public string EducationalAttainment { get; set; }
            public string EmploymentBusinessAgency { get; set; }
        }


    // D. Health Data
    public class HealthData
        {
        public int HealthDataID { get; set; }
        public string studentID { get; set; }  
        public string SickFrequency { get; set; }
        public string HealthProblems { get; set; }
        //public string OtherHealthProblems { get; set; }
        public string PhysicalDisabilities { get; set; }
       // public string OtherPhysicalDisabilities { get; set; }
    }

    // E. Additional Profile
    public class AdditionalProfile
    {
        public int AdditionalProfileID { get; set; }
        public string studentID { get; set; }
        public string SexualPreference { get; set; }
        public string ExpressionPresent { get; set; }
        public string GenderSexuallyAttracted { get; set; }
        public string HasScholarship { get; set; }
        public string ScholarshipName { get; set; }
    }

    public class FamilyReport
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string CourseYear { get; set; }
        public string FatherName { get; set; }
        public string LivingStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string EducationalAttainment { get; set; }
        public string Occupation { get; set; }
        public string MonthlyIncome { get; set; }
        public string MaritalStatus { get; set; }
        public string WorkingAbroad { get; set; }
        public string FamilyStructure { get; set; }
        public string IndigenousGroup { get; set; }
        public string Beneficiary4Ps { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

