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

        public async Task Seed()
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
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


            //var courses = new Course[]
            //{
            //    new Course {Title = "Chemistry",  Credits = 3, Department = departments.Single( s => s.Name == "Engineering") },
            //    new Course {Title = "Microeconomics", Credits = 3, Department = departments.Single( s => s.Name == "Economics") },
            //    new Course {Title = "Calculus", Credits = 4, Department = departments.Single( s => s.Name == "Mathematics") },
            //    new Course {Title = "Trigonometry", Credits = 4, Department = departments.Single( s => s.Name == "Mathematics") },
            //    new Course {Title = "Composition", Credits = 3, Department = departments.Single( s => s.Name == "English") },
            //    new Course {Title = "Literature", Credits = 4, Department = departments.Single( s => s.Name == "English") },
            //};

            //foreach (Course c in courses)
            //{
            //    context.Courses.Add(c);
            //}
            //context.SaveChanges();


            //var students = new Student[]
            //{
            //    new Student { FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("01/09/2010")},
            //    new Student { FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("01/09/2012") },
            //    new Student { FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("01/09/2013") },
            //    new Student { FirstName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("01/09/2012") },
            //    new Student { FirstName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("01/09/2012") },
            //    new Student { FirstName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("01/09/2011") },
            //    new Student { FirstName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("01/09/2013") },
            //    new Student { FirstName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("01/09/2005") }
            //};

            //foreach (Student s in students)
            //{
            //    context.Student.Add(s);
            //}
            //context.SaveChanges();

            //var studentCourse = new StudentCourse[]
            //{
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Microeconomics" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Calculus" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Trigonometry" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Composition" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Anand").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Anand").ID,
            //        CourseID = courses.Single(c => c.Title == "Microeconomics").ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry").ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Li").ID,
            //        CourseID = courses.Single(c => c.Title == "Composition").ID
            //    },
            //    new StudentCourse {
            //        StudentID = students.Single(s => s.LastName == "Justice").ID,
            //        CourseID = courses.Single(c => c.Title == "Literature").ID
            //    }
            //};


            //foreach (StudentCourse e in studentCourse)
            //{
            //    var enrollmentInDataBase = context.StudentCourse.Where(
            //        s =>
            //                s.Student.ID == e.StudentID &&
            //                s.Course.ID == e.CourseID).SingleOrDefault();

            //    if (enrollmentInDataBase == null)
            //    {
            //        context.StudentCourse.Add(e);
            //    }
            //}

            //context.SaveChanges();
        }

    }
}
