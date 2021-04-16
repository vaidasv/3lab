using System;
using System.Collections.Generic;

namespace _3lab
{
    class Student
    {
        public string sureName { get; set; }
        public string name { get; set; }

        public List <double> hw { get; set; }

        public double finalAvg { get; set; }

        public double finalMed { get; set; }

        public double examResult { get; set; }
        public object Set { get; set; }

        public Student() {}
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
            //Console.Write("enter number of homework: ");
            // n = int.Parse(Console.ReadLine());
            studList[studentID].hw.Add(3);
            /*
            for (int i = 0; i < n; i++)
            {
                int hwNum = i + 1;
                Console.Write("enter homeworks " + hwNum + " grade: ");
                studList[studentID].hw.Add(double.Parse(Console.ReadLine()));
            }
            */




            //  Console.Write("enter exam result: ");
            // examResult = double.Parse(Console.ReadLine());

        }
        public void printList(List<Student> studList)
        {
            int hwListSize;
            int index = 0;
            foreach (var student in studList)
            {
                Console.WriteLine("{0} {1}",  "id: " +  index + " " + student.name, student.sureName, student + " " );
                hwListSize = student.hw.Count;
                index++;
                //printina visus homework
                if (hwListSize > 0)
                {
                    for (int i = 0; i < hwListSize; i++)
                    {
                        
                        Console.WriteLine("hw "+ i + ":" + " " +student.hw[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    public void calculateMedian(int n) 
        {
            double finalMed;
            //calc hw median
            double[] sortedHw = new double[n];
            for (int i = 0; i < n; i++)
            {
                //sortedHw[i] = hw[i];
            }
            Array.Sort(sortedHw);

            /* print sorted array
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
                Console.WriteLine("middle array index : " + middleArrayIndex);
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
            finalMed = Math.Round((0.3 * median + 0.7 * examResult), 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine("final median student grade = " + finalMed);
            //Console.WriteLine("median: " + median );   
            // hw median gautas
        }
        public void calculateAverage(int n) 
        {
            double finalAvg;
            double hwAvg = 0.00;
            for (int i = 0; i < n; i++)
            {
                int hwNum = i + 1;
                Console.WriteLine("enter homeworks " + hwNum + " grade: ");
              //  hw[i] = double.Parse(Console.ReadLine());
                //hwAvg = hwAvg + hw[i];
            }
            hwAvg = hwAvg / n;
            finalAvg = Math.Round((0.3 * hwAvg + 0.7 * examResult), 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine("final average student grade = " + finalAvg);
        }

        public void addStudent(List<Student> studentList )
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

        public void printStudentList(List<Student> studentList)
        {
            foreach (var stud in studentList)
            {
                Console.WriteLine(stud);
            }
        }

     //     public override string ToString()
       // {              
         //       return  "name: " + name + " surename: " + sureName + " hw 0: " + hw[0]  /*" exam result:  " + examResult + " Final points (Avg. ): " + finalAvg*/;
        //}
  
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
            Student stud1 = new Student("Bronislovas","Bronius" , hw1);
            Student stud2 = new Student("Cheslovenas", "Cheslovas", hw2);
            studentList.Add(stud1);
            studentList.Add(stud2);


            do
            {
                Console.WriteLine("0. Exit program");
                Console.WriteLine("1. Add student to list");
                Console.WriteLine("2. Print stud list");
                Console.WriteLine("3. Add student grades");
                Console.WriteLine("4. Generate random exam/hw results for student"); 


                caseSwitch = int.Parse(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        Console.Clear();
                        instance.addStudent(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 2:
                        Console.Clear();
                        instance.printStudentList(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 3:
                        Console.Clear();
                        instance.addStudentGrades(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;
                    case 4:
                        Console.Clear();
                        instance.printList(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;


                }

            } while (caseSwitch != 0);
            
        }
    }
}
