using BlazorCrud.API.Data;
using BlazorCrud.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazorCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var std = await _context.tblStudents.ToListAsync();
            return Ok(std);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var std = await _context.tblStudents.FindAsync(id);
            return Ok(std);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            await _context.tblStudents.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok("Create Successfully...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Student student)
        {
            if (student == null || student.Id < 1)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var std = await _context.tblStudents.FindAsync(student.Id);

                if (std == null)
                {
                    return NotFound();
                }

                std.Name = student.Name;
                std.FatherName = student.FatherName;
                std.MobileNumber = student.MobileNumber;
                std.Semester = student.Semester;
                std.Email = student.Email;
                std.RollNo = student.RollNo;

                _context.tblStudents.Update(std);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, $"An error occurred while updating record: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var std = await _context.tblStudents.FindAsync(id);
            _context.tblStudents.Remove(std);
            await _context.SaveChangesAsync();
            return Ok("Deleted Successfully...");
        }
    }
}
