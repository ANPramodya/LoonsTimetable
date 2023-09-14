using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoonsTimetable.Data;
using LoonsTimetable.Model;
using LoonsTimetable.Services;

namespace LoonsTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamSchedulesController : ControllerBase
    {
        private readonly LoonsTimetableContext _context;
        private readonly IExamScheduleService _service;

        public ExamSchedulesController(LoonsTimetableContext context, IExamScheduleService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/ExamSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamSchedule>>> GetExamSchedule()
        {
          if (_context.ExamSchedule == null)
          {
              return NotFound();
          }
            return await _context.ExamSchedule.ToListAsync();
        }

        // GET: api/ExamSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamSchedule>> GetExamSchedule(int id)
        {
          if (_context.ExamSchedule == null)
          {
              return NotFound();
          }
            var examSchedule = await _context.ExamSchedule.FindAsync(id);

            if (examSchedule == null)
            {
                return NotFound();
            }

            return examSchedule;
        }

        // PUT: api/ExamSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamSchedule(int id, ExamSchedule examSchedule)
        {
            if (id != examSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(examSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamScheduleExists(id))
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

        //// POST: api/ExamSchedules
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ExamSchedule>> PostExamSchedule(ExamSchedule examSchedule)
        //{
        //  if (_context.ExamSchedule == null)
        //  {
        //      return Problem("Entity set 'LoonsTimetableContext.ExamSchedule'  is null.");
        //  }
        //    _context.ExamSchedule.Add(examSchedule);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetExamSchedule", new { id = examSchedule.Id }, examSchedule);
        //}

        // POST: api/ExamSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamSchedule>> GenerateExamScedules([FromBody] List<Exam> exams)
        {
            if (exams == null || exams.Count != 8)
            {
                return Problem("Entity set 'LoonsTimetableContext.ExamSchedule'  is null.");
            }

            var examSchedule = _service.GenerateExamSchedule(exams);

            //var data = new
            //{
            //    Message = "It works",
            //    Status = "OK"
            //};

            return Ok(examSchedule);
        }

        // DELETE: api/ExamSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamSchedule(int id)
        {
            if (_context.ExamSchedule == null)
            {
                return NotFound();
            }
            var examSchedule = await _context.ExamSchedule.FindAsync(id);
            if (examSchedule == null)
            {
                return NotFound();
            }

            _context.ExamSchedule.Remove(examSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamScheduleExists(int id)
        {
            return (_context.ExamSchedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
