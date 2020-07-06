using ContosoUniversity.API.Data;
using ContosoUniversity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.XUnitTest.Data
{
    public class DatabaseSeeder
    {
        public DatabaseSeeder(ContosoUniversityAPIContext c)
        {
            context = c;
        }

        public ContosoUniversityAPIContext context { get; }

        public void Seed()
        {
            context.Database.EnsureCreated();

            // Look for valeus.
            if (context.Instructors.Any())
            {
                return;   // DB has been seeded
            }

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Instructor 1", LastName = "LastName 1", HireDate = DateTime.Parse("11/03/1995") },
                new Instructor { FirstName = "Instructor 2", LastName = "LastName 2", HireDate = DateTime.Parse("06/07/2002") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Department 1", Budget = 350000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.FirstName == "Instructor 1") },
                new Department { Name = "Department 2", Budget = 100000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.FirstName == "Instructor 2") }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course {Title = "Course 01",  Credits = 3, Department = departments.Single( s => s.Name == "Department 1") },
                new Course {Title = "Course 02", Credits = 3, Department = departments.Single( s => s.Name == "Department 2") }
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var students = new Student[]
            {
                new Student { FirstName = "Student 01", LastName = "LastName 01", EnrollmentDate = DateTime.Parse("01/09/2010")},
                new Student { FirstName = "Student 02", LastName = "LastName 02", EnrollmentDate = DateTime.Parse("01/09/2012") }
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var studentCourse = new StudentCourse[]
            {
                new StudentCourse {
                    StudentID = students.Single(s => s.FirstName == "Student 01").ID,
                    CourseID = courses.Single(c => c.Title == "Course 01" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.FirstName  == "Student 01").ID,
                    CourseID = courses.Single(c => c.Title == "Course 02" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.FirstName == "Student 02").ID,
                    CourseID = courses.Single(c => c.Title == "Course 01" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.FirstName == "Student 02").ID,
                    CourseID = courses.Single(c => c.Title == "Course 02" ).ID
                }
            };

            foreach (StudentCourse e in studentCourse)
            {
                var enrollmentInDataBase = context.StudentCourse.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.ID == e.CourseID).SingleOrDefault();

                if (enrollmentInDataBase == null)
                {
                    context.StudentCourse.Add(e);
                }
            }

            context.SaveChanges();
        }
    }
}