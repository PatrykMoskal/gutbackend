using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<PdfFile>> GetByIdAsync(int id)
        {
            var report = await _reportService.GetByIdAsync(id);
            
            MemoryStream stream = new MemoryStream();
            stream.Write(report.FileData, 0, report.FileData.Length);

            if (report == null)
            {
                return NotFound();
            }
            return  File(stream.GetBuffer(), "application/pdf", "test.pdf");
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Report report)
        {
            await _reportService.AddAsync(report);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, Report report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }
            await _reportService.UpdateAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reportService.DeleteAsync(id);
            return NoContent();
        }
    }
}