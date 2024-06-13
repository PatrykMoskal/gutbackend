using Api.Models;

namespace Api.Services;

public interface IReportService
{
        
        Task<IEnumerable<Report>> GetAllAsync();
        Task<PdfFile> GetByIdAsync(int id);
        Task AddAsync(Report report);
        Task UpdateAsync(Report report);
        Task DeleteAsync(int id);
}