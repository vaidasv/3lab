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
            this.examResult = examResult;
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
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int hwNum = i + 1;
                    Console.WriteLine("enter homeworks " + hwNum + " grade: ");
                    studList[studentID].hw.Add(double.Parse(Console.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Neteisingas studento id");
                return;
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
                Console.WriteLine("name: " + student.name);
                Console.WriteLine("sureName: " + student.sureName);
                //Console.WriteLine("{0} {1}", student.name, student.sureName, student + " ");

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

            Console.WriteLine("1. Print student list with avg points");
            Console.WriteLine("2. Print student list with median points");
            int choice = 0;
            try
            {
                choice =  int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Neteisingas pasirinkimas");
                return;
            }

            string avgMed = null;

            if (choice == 1)
            {
                avgMed = "(Avg.)";
            }
            else avgMed = "(Med)";

            Console.WriteLine("Surename        Name        Final Points " + avgMed);
            Console.WriteLine("-----------------------------------------------");
            int align;
            int align2;

            List<Student> sortedList = new List<Student>(studentList);
            sortedList.Sort((x, y) => x.sureName.CompareTo(y.sureName));

            foreach (var student in sortedList)
            {

                Console.Write(student.sureName);
                align = 16 - student.sureName.Length;
                for (int i = 0; i < align; i++)
                {
                    Console.Write(" ");

                }
                Console.Write(student.name);

                align2 = 41 - align - (student.sureName.Length + student.name.Length);
                for (int i = 0; i < align2; i++)
                {
                    Console.Write(" ");

                }
                if (choice == 1)
                {
                    Console.WriteLine(student.finalAvg);
                }
                else Console.WriteLine(student.finalMed);

            }
        }
        public void generateRandomResults(List<Student> studList)
        {
            int randomNum;
            Random rnd = new Random();
            int studentID;

            Console.Write("enter id of the student to add grades: ");
            studentID = int.Parse(Console.ReadLine());
            
            try
            {
                studList[studentID].hw.Clear();

                for (int i = 0; i < 5; i++)
                {
                    randomNum = rnd.Next(1, 10);
                    studList[studentID].hw.Add(randomNum);
                    Console.WriteLine("Random hw res: " + randomNum);
                }

            } catch (Exception e)
            {
                Console.WriteLine("Neteisingas studento ID");
                return;
            }
            studList[studentID].examResult = rnd.Next(1, 10);
            Console.WriteLine("random exam result: " + studList[studentID].examResult);
            calculateAverage(studList, studentID);
            calculateMedian(studList, studentID);
        }
        public void storeFromCsv(List<Student> studList)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("D:\\3lab\\students.csv");
            bool skipHeader = false;
            //List<double> hwList = new List<double>();

            while ((line = file.ReadLine()) != null)
            {
                List<double> hwList = new List<double>();
                //hwList.Clear();
                if (skipHeader != false)
                {

                    string[] value = line.Split(',');

                    hwList.Add(double.Parse(value[2]));
                    hwList.Add(double.Parse(value[3]));
                    hwList.Add(double.Parse(value[4]));
                    hwList.Add(double.Parse(value[5]));
                    hwList.Add(double.Parse(value[6]));

                    studList.Add(new Student(value[0], value[1], hwList, 0, 0, double.Parse(value[7])));

                    //Console.WriteLine(studList.Count - 1);

                    calculateAverage(studList, studList.Count - 1);
                    calculateMedian(studList, studList.Count - 1);
                }

                skipHeader = true;
            }
            file.Close();
        }
    }
}