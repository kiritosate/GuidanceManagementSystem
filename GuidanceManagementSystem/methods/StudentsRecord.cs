using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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
            public int Year { get; set; }
            public string StudentStatus { get; set; }
            public int PersonalDataID { get; set; }
            public int FamilyDataID { get; set; }
            public int SiblingsID { get; set; }
            public int EducationalID { get; set; }
            public int AdditionalProfileID { get; set; }
            public int HealthDataID { get; set; }
            public bool Status { get; set; }
        }

        // A. Personal Data
        public class PersonalData
        {
           
            public int PersonalDataID { get; set; }
            public string studentID { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Nickname { get; set; } // Optional field
            public string Sex { get; set; } // "Male" or "Female"
            public int Age { get; set; } // Age in years
            public string Nationality { get; set; }
            public string Citizenship { get; set; }
            public string SpouseName { get; set; } // Nullable if not married
            public int NumberOfChildren { get; set; } // Changed to int for consistency
            public DateTime DateOfBirth { get; set; }
            public string PlaceOfBirth { get; set; }
            public string CivilStatus { get; set; } // e.g., "Single", "Married", etc.
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
            public string Parents { get; set; }
            public string Name { get; set; }
            public string TelCellNo { get; set; }
            public string Nationality { get; set; }
            public string EducationalAttainment { get; set; }
            public string Occupation { get; set; }
            public string EmployerAgency { get; set; }
            public string WorkingAbroad { get; set; }
            public string MaritalStatus { get; set; }
            public string MonthlyIncome { get; set; }
            public int NoOfChildren { get; set; }
            public int StudentsBirthOrder { get; set; }
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

}

