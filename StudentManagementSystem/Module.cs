using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Module
    {
        public Module(int iD, string name, double creditValue, string grade)
        {
            ID = iD;
            Name = name;
            CreditValue = creditValue;
            Grade = grade;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public double CreditValue { get; set; }
        public double GradePoint { get; set; }


        public double MGPoint(string grd) //Calculate Module Grade Point
        {
            switch (grd)
            {
                case "A+":
                    GradePoint = 4.0;
                    break;
                case "A":
                    GradePoint = 4.0;
                    break;
                case "A-":
                    GradePoint = 3.7;
                    break;
                case "B+":
                    GradePoint = 3.4;
                    break;
                case "B":
                    GradePoint = 3.1;
                    break;
                case "B-":
                    GradePoint = 2.8;   
                    break;
                case "C+":
                    GradePoint = 2.5;
                    break;
                case "C":
                    GradePoint = 2.2;
                    break;
                case "C-":
                    GradePoint = 1.9;
                    break;
                case "E":
                    GradePoint = 0;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Grade!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return GradePoint;
        }
    }
}
