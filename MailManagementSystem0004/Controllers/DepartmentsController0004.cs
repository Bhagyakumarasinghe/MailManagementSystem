
using MailManagementSystem0004.Data;
using MailManagementSystem0004.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailManagementSystem0004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController0004 : ControllerBase
    {
        private readonly AppDbContext0004 _context;

        public DepartmentsController0004(AppDbContext0004 context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department0004>>> GetDepartments0004()
        {
            return await _context.Departments0004.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Department0004>> GetDepartment0004(int id)
        {
            var department = await _context.Departments0004.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment0004(int id, Department0004 department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists0004(id))
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

        
        [HttpPost]
        public async Task<ActionResult<Department0004>> PostDepartment0004(Department0004 department)
        {
            _context.Departments0004.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment0004", new { id = department.Id }, department);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment0004(int id)
        {
            var department = await _context.Departments0004.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments0004.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists0004(int id)
        {
            return _context.Departments0004.Any(e => e.Id == id);
        }
    }
}