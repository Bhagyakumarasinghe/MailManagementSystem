
using MailManagementSystem0004.Data;
using MailManagementSystem0004.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailManagementSystem0004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController0004 : ControllerBase
    {
        private readonly AppDbContext0004 _context;

        public MailsController0004(AppDbContext0004 context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail0004>>> GetMails0004([FromQuery] int? senderDepartmentId, [FromQuery] int? recipientDepartmentId)
        {
            var query = _context.Mails0004
                .Include(m => m.SenderDepartment)
                .Include(m => m.RecipientDepartment)
                .AsQueryable();

            if (senderDepartmentId.HasValue)
            {
                query = query.Where(m => m.SenderDepartmentId == senderDepartmentId.Value);
            }

            if (recipientDepartmentId.HasValue)
            {
                query = query.Where(m => m.RecipientDepartmentId == recipientDepartmentId.Value);
            }

            return await query.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Mail0004>> GetMail0004(int id)
        {
            var mail = await _context.Mails0004
                .Include(m => m.SenderDepartment)
                .Include(m => m.RecipientDepartment)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMail0004(int id, Mail0004 mail)
        {
            if (id != mail.Id)
            {
                return BadRequest();
            }

            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists0004(id))
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
        public async Task<ActionResult<Mail0004>> PostMail0004(Mail0004 mail)
        {
            
            mail.Status = MailStatus0004.InTransit;

            _context.Mails0004.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail0004", new { id = mail.Id }, mail);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMail0004(int id)
        {
            var mail = await _context.Mails0004.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mails0004.Remove(mail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpGet("{id}/status")]
        public async Task<ActionResult<MailStatus0004>> GetMailStatus0004(int id)
        {
            var mail = await _context.Mails0004.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail.Status;
        }

        
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutMailStatus0004(int id, [FromBody] MailStatus0004 status)
        {
            var mail = await _context.Mails0004.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            mail.Status = status;
            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists0004(id))
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

        private bool MailExists0004(int id)
        {
            return _context.Mails0004.Any(e => e.Id == id);
        }
    }
}