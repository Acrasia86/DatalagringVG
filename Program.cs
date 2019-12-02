using System;

namespace HogwartsVG
{
    class Program
    {
        static void Main(string[] args)
        {

            var start = new App();

            bool shouldNotExit = true;

            Console.Clear();

            while (shouldNotExit)
            {
                Console.WriteLine("1. Register student");
                Console.WriteLine("2. List students");
                Console.WriteLine("3. Register teacher");
                Console.WriteLine("4. Add course");
                Console.WriteLine("5. Add student to course");
                Console.WriteLine("6. List courses");
                Console.WriteLine("7. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        start.RegisterStudent();
                        break;
                    case 2:
                        start.ListStudents();
                        break;
                    case 3:
                        start.RegisterTeacher();
                        break;
                    case 4:
                        start.AddCourse();
                        break;
                    case 5:
                        start.AddStudentToCourse();
                        break;
                    case 6:
                        start.ListCourses();
                        break;

                    case 7:
                        shouldNotExit = false;
                        break;



                }

                Console.Clear();
            }
        }
    }
}
