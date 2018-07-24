﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.API.Models;

namespace ContosoUniversity.API.Data
{
    public class ContosoUniversityAPIContext : DbContext
    {
        public ContosoUniversityAPIContext (DbContextOptions<ContosoUniversityAPIContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("tbl_Course");
            modelBuilder.Entity<Student>().ToTable("tbl_Student");
            modelBuilder.Entity<Department>().ToTable("tbl_Department");
            modelBuilder.Entity<Instructor>().ToTable("tbl_Instructor");
            modelBuilder.Entity<StudentCourse>().ToTable("tbl_StudentCourse");

            modelBuilder.Entity<StudentCourse>().HasKey(c => new { c.CourseID, c.StudentID });
        }
    }
}