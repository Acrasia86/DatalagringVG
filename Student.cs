using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsVG
{
    public class Student
    {
        public Student()
        {

        }
        public Student(string firstName, string lastName, string socialSecurityNumber, Adress adress)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Adress = adress;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public Adress Adress { get; set; }

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
