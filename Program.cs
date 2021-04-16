using System;
using System.Collections.Generic;

namespace _3lab
{
    class Student
    {
        public string sureName { get; set; }
        public string name { get; set; }

        public double[] hw { get; set; }

        public double finalAvg { get; set; }

        public double finalMed { get; set; }

        public double examResult { get; set; }
        public Student() {}
        public Student(string sureName, string name, double[] hw, double finalAvg, double finalMed, double examResult)
        {
            this.sureName = sureName;
            this.name = name;
            this.hw = hw;
            this.finalAvg = finalAvg;
            this.finalMed = finalMed;
        }

        public void addStudent(List<Student> studentList )
        {
            string sureName;
            string name;
            double finalAvg;
            double finalMed;
            double hwAvg = 0.00; 
            int n;

            Console.Write("enter surename: ");
            sureName = Console.ReadLine();

            Console.Write("enter name: ");
            name = Console.ReadLine();

            Console.Write("enter number of homework: ");
            n = int.Parse(Console.ReadLine());
            double[] hw = new double[n];
            
            for (int i = 0; i < n; i++) 
            {
                int hwNum = i + 1;
                Console.WriteLine("enter homeworks " + hwNum +" grade: ");
                hw[i] = double.Parse(Console.ReadLine());
                hwAvg = hwAvg + hw[i];
            }
            hwAvg = hwAvg / n;

                                              //calc hw median
            double[] sortedHw = new double[n];
            for (int i = 0; i < n; i++)
            {
                sortedHw[i] = hw[i];
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
                middleArrayIndex = (int) (n / 2 + 0.5);
                median = sortedHw[Convert.ToInt32(middleArrayIndex)];
                Console.WriteLine("middle array index : " + middleArrayIndex);
            }
            if (n % 2 == 0) // jei lyginis skaicius hw medianos liste
            {
                //mazesne vidurio reiksme
                middleArrayIndex = (int) (n / 2 + 0.5);
                median = median + sortedHw[Convert.ToInt32(middleArrayIndex)];
                //didesne vidurio reiksme
                middleArrayIndex = (int) (n / 2 - 0.5);
                median = (median + sortedHw[Convert.ToInt32(middleArrayIndex)]) / 2;
                Console.WriteLine("middle array index : " + middleArrayIndex);
            }
            //Console.WriteLine("median: " + median );   
                                           // hw median gautas

            Console.Write("enter exam result: ");
            examResult = double.Parse(Console.ReadLine());

            finalAvg = Math.Round((0.3 * hwAvg + 0.7 * examResult), 2, MidpointRounding.AwayFromZero);
            finalMed = Math.Round((0.3 * median + 0.7 * examResult), 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine("final average student grade = " + finalAvg);
            //Console.WriteLine("final median student grade = " + finalMed);

            Student student = new Student(sureName, name, hw, finalAvg, finalMed, examResult);
            studentList.Add(student);

        }

        public void printStudentList(List<Student> studentList)
        {
            foreach (var stud in studentList)
            {
                Console.WriteLine(stud);
            }
        }

        public override string ToString()
        {
            return "name: " + name + " surename: " + sureName + " Final points (Avg. ): " + finalAvg  ;
        }

    }



    
    class Program
    {
        static void Main(string[] args)
        {

            int caseSwitch;
            var instance = new Student();
            List<Student> studentList = new List<Student>();
            
            do
            {
                Console.WriteLine("0. Exit program");
                Console.WriteLine("1. Add student to list");
                Console.WriteLine("2. Print stud list");
                Console.WriteLine("3. Generate random exam/hw results for student"); 


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
                        instance.printStudentList(studentList);
                        Console.WriteLine();
                        caseSwitch = -1;
                        break;

                }

            } while (caseSwitch != 0);
            
        }
    }
}
