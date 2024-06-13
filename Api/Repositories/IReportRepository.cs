using Api.Models;

namespace Api.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> GetAllAsync();
    Task<PdfFile> GetByIdAsync(int id);
    Task AddAsync(Report report);
    Task UpdateAsync(Report report);
    Task DeleteAsync(int id);
}