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

            return File(stream.GetBuffer(), "application/pdf", "test.pdf");
        }
    }
}