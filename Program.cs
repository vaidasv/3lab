using System;
using System.Collections.Generic;

namespace _3lab
{
    class Student
    {
        public string sureName { get; set; }
        public string name { get; set; }

        public List<double> hw { get; set; }

        public double finalAvg { get; set; }

        public double finalMed { get; set; }

        public double examResult { get; set; }
        public object Set { get; set; }

        public Student() { }
        public Student(string sureName, string name, List<double> hw)
        {
            this.sureName = sureName;
            this.name = name;
            this.hw = hw;

        }
        public Student(string sureName, string name, List<double> hw, double finalAvg, double finalMed, double examResult)
        {
            this.sureName = sureName;
            this.name = name;
            this.hw = hw;
            this.finalAvg = finalAvg;
            this.finalMed = finalMed;
        }
        public void addStudentGrades(List<Student> studList)
        {
            int studentID;
            int n;
            Console.Write("enter id of the student to add grades: ");
            studentID = int.Parse(Console.ReadLine());
            Console.Write("enter number of homework: ");
            n = int.Parse(Console.ReadLine());

            /*
            studList[studentID].hw.Add(3);
            studList[studentID].hw.Add(4);
            studList[studentID].hw.Add(1);
            studList[studentID].hw.Add(1);
            studList[studentID].hw.Add(8);
            studList[studentID].hw.Add(3);
           */

            for (int i = 0; i < n; i++)
            {
                int hwNum = i + 1;
                Console.Write("enter homeworks " + hwNum + " grade: ");
                studList[studentID].hw.Add(double.Parse(Console.ReadLine()));
            }

            Console.Write("enter exam result: ");
            studList[studentID].examResult = double.Parse(Console.ReadLine());

            calculateAverage(studList, studentID);
            calculateMedian(studList, studentID);

        }
        public void printListWithHw(List<Student> studList)
        {
            int hwListSize;
            int index = 0;
            foreach (var student in studList)
            {
                Console.WriteLine("studID: " + index);
                Console.WriteLine("{0} {1}", student.name, student.sureName, student + " ");

                hwListSize = student.hw.Count;
                index++;
                //printina visus homework
                if (hwListSize > 0)
                {
                    for (int i = 0; i < hwListSize; i++)
                    {

                        Console.WriteLine("hw " + i + ": " + student.hw[i]);
                    }

                }
                Console.WriteLine("examRes: " + student.examResult);
                Console.WriteLine("FinalAvg: " + student.finalAvg);
                Console.WriteLine("FinalMed: " + student.finalMed);
                Console.WriteLine("---------------------------------");
            }
        }
        public void calculateMedian(List<Student> studList, int studentID)
        {

            //calc hw median
            //double[] sortedHw = new double[n];
            List<double> sortedHw = new List<double>();
            int n = studList[studentID].hw.Count;
            for (int i = 0; i < n; i++)
            {
                sortedHw.Add(studList[studentID].hw[i]);
                //sortedHw[i] = hw[i];
            }
            // Array.Sort(sortedHw);
            sortedHw.Sort();
            // print sorted array
            /*
             for (int i = 0; i < n; i++)
             {
                 Console.WriteLine("hw : " + sortedHw[i]);
             } 
            */
            double median = 0;
            double middleArrayIndex;

            if (n % 2 == 1) // jei nelyginis skaicius hw medianos liste
            {
                middleArrayIndex = (int)(n / 2 + 0.5);
                median = sortedHw[Convert.ToInt32(middleArrayIndex)];
                //Console.WriteLine("middle array index : " + middleArrayIndex);
            }
            if (n % 2 == 0) // jei lyginis skaicius hw medianos liste
            {
                //mazesne vidurio reiksme
                middleArrayIndex = (int)(n / 2 + 0.5);
                median = median + sortedHw[Convert.ToInt32(middleArrayIndex)];
                //didesne vidurio reiksme
                middleArrayIndex = (int)(n / 2 - 0.5);
                median = (median + sortedHw[Convert.ToInt32(middleArrayIndex)]) / 2;
                // Console.WriteLine("middle array index : " + middleArrayIndex);

            }

            studList[studentID].finalMed = Math.Round((0.3 * median + 0.7 * studList[studentID].examResult), 2, MidpointRounding.AwayFromZero);

            //Console.WriteLine("final median student grade = " + finalMed);
            //Console.WriteLine("median: " + median );   
            // hw median gautas
        }
        public void calculateAverage(List<Student> studList, int studentID)
        {

            double hwAvg = 0.00;
            int n = studList[studentID].hw.Count;


            for (int i = 0; i < n; i++)
            {
                hwAvg = hwAvg + studList[studentID].hw[i];
            }
            hwAvg = hwAvg / n;

            studList[studentID].finalAvg = Math.Round((0.3 * hwAvg + 0.7 * studList[studentID].examResult), 2, MidpointRounding.AwayFromZero);

            //Console.WriteLine("final average student grade = " + finalAvg);
        }
        public void addStudent(List<Student> studentList)
        {
            string sureName;
            string name;
            List<double> hw = new List<double>();

            Console.Write("enter surename: ");
            sureName = Console.ReadLine();

            Console.Write("enter name: ");
            name = Console.ReadLine();



            Student student = new Student(sureName, name, hw);
            studentList.Add(student);

        }
        public void printStudentListAvg(List<Student> studentList)
        {
            Console.WriteLine("Surename        Name        Final Points (Med.)");
            Console.WriteLine("-----------------------------------------------");
            foreach (var student in studentList)
            {
                Console.WriteLine("{0} {1} {2}", student.sureName, student.name, student.finalAvg + " ");
            }
        }
        public void printStudentListMedian(List<Student> studentList)
        {
            //8 whitespaces between 
            Console.WriteLine("Surename        Name        Final Points (Med.)");
            Console.WriteLine("-----------------------------------------------");
            foreach (var student in studentList)
            {
                Console.WriteLine("{0} {1} {2}", student.sureName, student.name, student.finalMed + " ");
            }
        }
        public void generateRandomResults(List<Student> studList)
        {
            int randomNum;
            Random rnd = new Random();
            int studentID;

            Console.Write("enter id of the student to add grades: ");
            studentID = int.Parse(Console.ReadLine());

            studList[studentID].hw.Clear();

            for (int i = 0; i < 5; i++)
            {
                randomNum = rnd.Next(1, 10);
                studList[studentID].hw.Add(randomNum);
                Console.WriteLine("Random hw res: " + randomNum);
            }

            studList[studentID].examResult = rnd.Next(1, 10);
            Console.WriteLine("random exam result: " + studList[studentID].examResult);
            calculateAverage(studList, studentID);
            calculateMedian(studList, studentID);
        }

    }

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
            studentList.Add(stud1);
            studentList.Add(stud2);
            studentList.Add(stud3);


            do
            {
                Console.WriteLine("0. Exit program");
                Console.WriteLine("1. Add student to list");
                // Console.WriteLine("2. Print stud list");
                Console.WriteLine("3. Add student grades");
                Console.WriteLine("4. Print student list with homework and exam result");
                Console.WriteLine("5. Print student list with avg points");
                Console.WriteLine("6. Print student list with median points");
                Console.WriteLine("7. Generate random student results");


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
                    case 6:
                        // Console.Clear();
                        instance.printStudentListMedian(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 7:
                        // Console.Clear();
                        instance.generateRandomResults(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;

                }

            } while (caseSwitch != 0);

        }
    }
}