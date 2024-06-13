using Api.Models;
using Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ReservationStatusService : IReservationStatusService
    {
        private readonly IReservationStatusRepository _reservationStatusRepository;

        public ReservationStatusService(IReservationStatusRepository reservationStatusRepository)
        {
            _reservationStatusRepository = reservationStatusRepository;
        }

        public async Task<IEnumerable<ReservationStatus>> GetAllAsync()
        {
            return await _reservationStatusRepository.GetAllAsync();
        }

        public async Task<ReservationStatus> GetByIdAsync(int id)
        {
            return await _reservationStatusRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ReservationStatus reservationStatus)
        {
            await _reservationStatusRepository.AddAsync(reservationStatus);
        }

        public async Task UpdateAsync(ReservationStatus reservationStatus)
        {
            await _reservationStatusRepository.UpdateAsync(reservationStatus);
        }

        public async Task DeleteAsync(int id)
        {
            await _reservationStatusRepository.DeleteAsync(id);
        }
    }
}