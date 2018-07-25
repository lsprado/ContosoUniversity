using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.API.Data;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ContosoUniversityAPIContext _context;
        
        public StudentsController(ContosoUniversityAPIContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = _context.Student
                .Include(s => s.StudentCourse)
                .ThenInclude(s => s.Course)
                .AsNoTracking();

            //Transform to DTO
            var result = new DTO.StudentCourseResult()
            {
                Students = students.Select(s => new DTO.Student()
                {
                    ID = s.ID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Courses = s.StudentCourse.Select(c => new DTO.Course()
                    {
                        ID = c.Course.ID,
                        Title = c.Course.Title
                    }).ToList()
                }).ToList()
            };

            return Ok(result);
            
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
            
            //Transform to DTO
            var result = new DTO.Student()
            {
                ID = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Courses = student.StudentCourse.Select(c => new DTO.Course()
                {
                    ID = c.Course.ID,
                    Title = c.Course.Title
                }).ToList()
            };

            return Ok(result);
        }

        // PUT: api/Students/5 - Alter
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

        // POST: api/Students - Create
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

        // DELETE: api/Students/5 - Delete
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