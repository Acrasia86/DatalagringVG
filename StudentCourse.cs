using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsVG
{
    public class StudentCourse
    {
        public StudentCourse()
        {

        }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        public StudentCourse(int studentId)
        {
            StudentId = studentId;
        }
    }
}
