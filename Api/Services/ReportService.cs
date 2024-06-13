using Api.Models;
using Api.Repositories;

namespace Api.Services;

public class ReportService: IReportService
{
    
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _reportRepository.GetAllAsync();
    }

    public async Task<PdfFile> GetByIdAsync(int id)
    {
        return await _reportRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Report report)
    {
        await _reportRepository.AddAsync(report);
    }

    public async Task UpdateAsync(Report report)
    {
        await _reportRepository.UpdateAsync(report);
    }

    public async Task DeleteAsync(int id)
    {
        await _reportRepository.DeleteAsync(id);
    }
}