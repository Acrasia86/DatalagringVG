using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsVG
{
    public class Teacher
    {
        public Teacher()
        {

        }

       

        public Teacher(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
      
    }
}
