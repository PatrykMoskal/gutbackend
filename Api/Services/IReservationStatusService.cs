using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IReservationStatusService
    {
        Task<IEnumerable<ReservationStatus>> GetAllAsync();
        Task<ReservationStatus> GetByIdAsync(int id);
        Task AddAsync(ReservationStatus reservationStatus);
        Task UpdateAsync(ReservationStatus reservationStatus);
        Task DeleteAsync(int id);
    }
}