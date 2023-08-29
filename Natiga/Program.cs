using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natiga
{
    internal class Program
    {
        public static void ContinueOrRestart()
        {
            Console.Write("Do you Want To Do Anything Else ? (Y/N) : ");
            if (Console.ReadLine().ToUpper() == "N")
                Environment.Exit(0);
            Console.Clear();
            StartProgram();
        }
        public static string Reverse(string text)
        {
            if (text == null) return null;
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        public static void GetResult()
        {
            try
            {
                using (Natiga2023Entities2 context = new Natiga2023Entities2())
                {
                    // context.Database.Log  = Console.Write ;
                    Console.Write("PLease Enter Seating Number : ");
                    double SeatingNo = double.Parse(Console.ReadLine());
                    IQueryable<Stage_New_Search> Degrees = context.Stage_New_Search;
                    //  var TargetStudent = Degrees.Where(x => x.seating_no == SeatingNo).ToList().First();
                    var TargetStudent = Degrees.Single(x => x.seating_no == SeatingNo);
                    Console.OutputEncoding = Encoding.Default;
                    Console.WriteLine
                        (
                        $"\nName : {Reverse(TargetStudent.arabic_name)}\n" +
                        $"\nDegree : {TargetStudent.total_degree}\n" +
                        $"\nPercentage : {Math.Round(((double)(TargetStudent.total_degree / 410) * 100), 2)}%\n"
                        );
                    Console.Write("Student case : ");
                    switch (TargetStudent.student_case)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Successfull \"Congratulations!!\"\n");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Failed \"Try Harder Next Time\"\n");
                            break;
                    }

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Seating Number.");
                GetResult();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Do you want to know another result ? (Y/N) : ");
            if (Console.ReadLine().ToUpper() == "N")
                ContinueOrRestart();
            Console.Clear();
            GetResult();

        }

        public static void GetNumbersOfStudentsWithDegrees()
        {
            // Summary: 
            // Get The number of students who obtained grades in a specific range.
            // EX: Number Of Students WHich The Grades Of Them In Range From 200 To 250 .

        }

        public static void GetTopTenStudents()
        {
            // Summary : 
            // Get The Name , Degree , Percentage for Top Ten Students 

            
        }
        public static void GetNumberOfSuccessfulStudents()
        {
            // Summary : 
            // Get The Number Of Successful Students.
        }
        public static void GetNumberOfSecondRoundStudents()
        {
            // Summary : 
            // Get The Number Of Second Round Studnts 
        }
        public static void GetNumberOfFailedStudents()
        {
            // Summary : 
            // Get The Number Of Failed Students.
        }
        public static void ChooseOperation()
        {
            Console.WriteLine("-- The Available Operations --");
            Console.WriteLine("(1) Number of students with grades in a specific range. (Ex:300-320)");
            Console.WriteLine("(2) The Top Ten Students. ");
            Console.WriteLine("(3) Number of successful students.");
            Console.WriteLine("(4) Number Of Second Round Students.");
            Console.WriteLine("(5) Number Of Failed Students.\n");

            Console.Write("Choose The Number Of Operation You Want To do : ");
            int.TryParse(Console.ReadLine(), out int OperationNumber);
            switch (OperationNumber)
            {
                case 1:
                    GetNumbersOfStudentsWithDegrees();
                    break;
                case 2:
                    GetTopTenStudents();
                    break;
                case 3:
                    GetNumberOfSuccessfulStudents();
                    break;
                case 4:
                    GetNumberOfSecondRoundStudents();
                    break;
                case 5:
                    GetNumberOfFailedStudents();
                    break;
                default:
                    Console.WriteLine("Invalid Value! \"Choose Existing Operation Number\"");
                    break;
            }
            //Console.Clear();
            //Console.Write("Do You Want To Do Other Oberation ? (Y/N) : ");
            //if (Console.ReadLine().ToUpper() == "N")
            //    return;

           // ChooseOperation();

        }

        public static void StartProgram()
        {
            Console.Write("To Know Student Result Press \"1\" || To Do Other Operation press \"2\" : ");
            int.TryParse(Console.ReadLine(), out int State);
            switch (State)
            {
                case 1:
                    GetResult();
                    break;

                case 2:
                ChooseOperation();
                    break;
                default:
                    Console.WriteLine("Invalid Value \"Press (1/2)\"");
                    StartProgram();
                    break;
            }
        }
        static void Main(string[] args)
        {
            StartProgram();



        }
    }
}
