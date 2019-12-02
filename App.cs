using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HogwartsVG
{
    class App
    {
        Context context = new Context();
        public void RegisterStudent()
        {
            Console.Clear();

            Console.Write("First name: ");

            string firstName = Console.ReadLine();

            Console.Write("Last name: ");

            string lastName = Console.ReadLine();

            Console.Write("Social security number: ");

            string socialSecurityNumber = Console.ReadLine();

            Console.Write("Street: ");

            string street = Console.ReadLine();

            Console.Write("City: ");

            string city = Console.ReadLine();

            Console.Write("Area code: ");

            string areaCode = Console.ReadLine();

            Console.WriteLine("\n\nIs this correct? (Y)es (N)o");

            string userInput = Console.ReadLine();

            Console.Clear();

            Student checkIfStudentExcists = FetchStudent(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (checkIfStudentExcists != null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Student already registered");
                Thread.Sleep(2000);
            }
            else if (userInput == "N" || userInput == "n")
            {
                RegisterStudent();
            }
            else
            {
                Adress adress = new Adress(street, city, areaCode);
                Student student = new Student(firstName, lastName, socialSecurityNumber, adress);

                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student added");

                Thread.Sleep(2000);
            }
        }

        public void ListStudents()
        {
            Console.Clear();

            List<Student> studentList = context.Students.Include(x => x.Adress).ToList();

            Console.WriteLine("Name                                                 Adress");
            Console.WriteLine("------------------------------------------------------------");

            foreach (var student in studentList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, {student.SocialSecurityNumber}                  {student.Adress.Street} {student.Adress.City} {student.Adress.AreaCode}");
            }

            Console.ReadLine();
        }


        public void RegisterTeacher()
        {
            Console.Clear();

            Console.Write("First name: ");

            string firstName = Console.ReadLine();

            Console.Write("Last name: ");

            string lastName = Console.ReadLine();

            Console.Write("Social security number: ");

            string socialSecurityNumber = Console.ReadLine();

            Console.WriteLine("\n\nIs this correct (Y)es (N)o");

            string userInput = Console.ReadLine();

            Console.Clear();

            Teacher checkIfTeacherExcists = FetchTeacher(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (checkIfTeacherExcists != null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Teacher already excists");
                Thread.Sleep(2000);
            }
            else if (userInput == "N" || userInput == "n")
            {
                RegisterTeacher();
            }
            else
            {
                Teacher teacher = new Teacher(firstName, lastName, socialSecurityNumber);
                context.Teachers.Add(teacher);
                context.SaveChanges();

                Console.WriteLine("Teacher registered");
                Thread.Sleep(2000);
            }


        }

        public void AddCourse()
        {
            Console.Clear();

            Console.Write("Title: ");

            string title = Console.ReadLine();

            Console.Write("Description: ");

            string description = Console.ReadLine();

            Console.Write("Score: ");

            int score = int.Parse(Console.ReadLine());

            Console.Write("Teacher: ");

            string teacher = Console.ReadLine();

            
            Console.WriteLine("\n\nIs this correct? (Y)es (N)o");

            string userInput = Console.ReadLine();


            Console.Clear();

            Teacher checkIfTeacherExcists = FetchTeacher(x => x.SocialSecurityNumber == teacher);
            Course checkIfCourseExcists = FetchCourse(x => x.Title == title);

            if (checkIfTeacherExcists == null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Teacher doesn't excist");
                Thread.Sleep(2000);
            }

            else if (checkIfCourseExcists != null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Course already excists");
                Thread.Sleep(2000);
            }
            else if (userInput == "N" || userInput == "n")
            {
                AddCourse();
            }

            else
            {
                Course course = new Course(title, description, score, teacher);

                context.Courses.Add(course);
                context.SaveChanges();

                Console.WriteLine("Course added");
                Thread.Sleep(2000);
            }


        }

        public void AddStudentToCourse()
        {
            Console.Clear();

            Console.Write("Student: ");

            string socialSecurityNumber = Console.ReadLine();

            Console.Write("Course: ");

            string title = Console.ReadLine();

            Console.WriteLine("\n\nIs this correct? (Y)es (N)o");


            string userInput = Console.ReadLine();

            Console.Clear();

            Student student = FetchStudent(x => x.SocialSecurityNumber == socialSecurityNumber);
            Course course = FetchCourse(x => x.Title == title);

            if(student == null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Student doesn't excist");
                Thread.Sleep(2000);
            }
            else if(course == null && userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Course doesn't excist");
                Thread.Sleep(2000);
            }
            else
            {
                StudentCourse studentCourse = new StudentCourse(student.Id);

                course.StudentCourses.Add(studentCourse);
                context.SaveChanges();

                Console.WriteLine("Student added to course");
                Thread.Sleep(2000);
            }

        }

        public void ListCourses()
        {
            Console.Clear();

            List<Course> courseList = context.Courses
                .Include(x => x.Teachers)
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Student)
                .ThenInclude(x => x.Adress)
                .ToList();

            Console.WriteLine("-------------------------------------------------------------");

            foreach (var course in courseList)

            {
                Console.WriteLine($"Title: {course.Title}\nDescription: {course.Description}\nScore: {course.Score}");
                Console.WriteLine("Students:");
                foreach (var student in course.StudentCourses)
                {
                    
                    Console.WriteLine($"{student.Student.FirstName} {student.Student.LastName}");


                }

                Console.WriteLine("-------------------------------------------------------------");
            }

            Console.ReadLine();


        }



        public Student FetchStudent(Func<Student, bool> customerFilter)
        {
            return context.Students
                .Include(x => x.Adress)
                .FirstOrDefault(customerFilter);
        }



        public Teacher FetchTeacher(Func<Teacher, bool> customerFilter)
        {
            return context.Teachers
                .Include(x => x.Courses)
                .FirstOrDefault(customerFilter);
        }



        public Course FetchCourse(Func<Course, bool> customerFilter)
        {
            return context.Courses
                .Include(x => x.Teachers)
                .FirstOrDefault(customerFilter);
        }
    }
}
