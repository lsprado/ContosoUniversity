using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Models.APIViewModels
{
    public class Student
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime enrollmentDate { get; set; }
        public List<CoursesResult> courses { get; set; }
    }

    public class StudentResult
    {
        public int count { get; set; }
        public List<Student> students { get; set; }
    }
}