using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsVG
{
    public class Course
    {
        public Course()
        {

        }

        public Course(string title, string description, int score, string teacher)
        {
            Title = title;
            Description = description;
            Score = score;
            Teacher = teacher;
        }

        public int Id { get; set; }

        public Teacher Teachers { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public string Teacher { get; set; }
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
