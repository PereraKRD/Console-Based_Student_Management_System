using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Student
    {
        public Student(int iD, string firstName, string lastName, string dateOfBirth, string address)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }

        public List<Module> Modules = new List<Module>();

        public double CalculateGPA()
        {
            double totalCreditValue = 0;
            double totalGradePoint = 0;
            foreach (Module module in Modules)
            {
                totalCreditValue += module.CreditValue;
                totalGradePoint += module.CreditValue * module.GradePoint;
            }
            return (double)totalGradePoint / totalCreditValue;
        }
    }
}
