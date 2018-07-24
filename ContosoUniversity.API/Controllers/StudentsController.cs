using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.API.Data;
using ContosoUniversity.API.Models;
using ContosoUniversity.API.ViewModel;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ContosoUniversityAPIContext _context;

        private ViewModel.Student ExecuteTransform(Models.Student student)
        {
            ViewModel.Student s = new ViewModel.Student();
            s.ID = student.ID;
            s.LastName = student.LastName;
            s.FirstName = student.FirstName;
            s.EnrollmentDate = student.EnrollmentDate;

            List<ViewModel.Course> lc = new List<ViewModel.Course>();
            foreach (var course in student.StudentCourse)
            {
                ViewModel.Course c = new ViewModel.Course();
                c.ID = course.Course.ID;
                c.Title = course.Course.Title;
                c.Credits = course.Course.Credits;
                lc.Add(c);
            }
            s.Courses = lc;

            return s;
        }

        private StudentCourseResult Transform(IQueryable<Models.Student> students)
        {
            StudentCourseResult result = new StudentCourseResult();
            result.Count = students.Count();
            List<ViewModel.Student> lst = new List<ViewModel.Student>();
            
            foreach (Models.Student student in students)
            {
                lst.Add(ExecuteTransform(student));
            }
            result.Students = lst;
            return result;
        }

        private ViewModel.Student Transform(Models.Student student)
        {
            StudentCourseResult result = new StudentCourseResult();
            result.Count = 1;
            return ExecuteTransform(student);
        }
        
        public StudentsController(ContosoUniversityAPIContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public StudentCourseResult GetStudent()
        {
            var students = _context.Student
                .Include(s => s.StudentCourse)
                .ThenInclude(s => s.Course)
                .AsNoTracking();

            return this.Transform(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student
                .Include(s => s.StudentCourse)
                .ThenInclude(s => s.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(this.Transform(student));
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] Models.Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Models.Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}