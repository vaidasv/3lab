using System;
using System.Collections.Generic;

namespace _3lab
{

    class Program
    {
        static void Main(string[] args)
        {

            int caseSwitch;
            var instance = new Student();
            List<Student> studentList = new List<Student>();
            List<double> hw1 = new List<double>();
            List<double> hw2 = new List<double>();
            List<double> hw3 = new List<double>();
            Student stud1 = new Student("Bronislovas", "Bronius", hw1);
            Student stud2 = new Student("Frank", "Cola", hw2);
            Student stud3 = new Student("Jay", "Z", hw3);
            /*
               studentList.Add(stud1);
               studentList.Add(stud2);
               studentList.Add(stud3);
            */

            do
            {
                Console.WriteLine("0. Exit program");
                Console.WriteLine("1. Add student to list");
                // Console.WriteLine("2. Print stud list");
                Console.WriteLine("3. Add student grades");
                Console.WriteLine("4. Print student list with homework and exam result");
                Console.WriteLine("5. Print student list with Avg/Med points");
                //Console.WriteLine("6. Print student list with median points");
                Console.WriteLine("7. Generate random student results");
                Console.WriteLine("8. Add students from file");


                caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        //  Console.Clear();
                        instance.addStudent(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 3:
                        //  Console.Clear();
                        instance.addStudentGrades(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 4:
                        //Console.Clear();
                        instance.printListWithHw(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 5:
                        // Console.Clear();
                        instance.printStudentListAvg(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 7:
                        // Console.Clear();
                        instance.generateRandomResults(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 8:
                        // Console.Clear();
                        instance.storeFromCsv(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;

                }

            } while (caseSwitch != 0);

        }
    }
}