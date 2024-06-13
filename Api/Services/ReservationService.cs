using Api.Models;
using Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.QueueSender;

namespace Api.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IQueueSender _sender;

        public ReservationService(IReservationRepository reservationRepository, IQueueSender sender)
        {
            _reservationRepository = reservationRepository;
            _sender = sender;
            
            
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(Reservation reservation)
        {
            await _reservationRepository.AddAsync(reservation);
            var currReservation = await _reservationRepository.GetByIdAsync(reservation.Id);
            var request = new ReservationPdfDto()
            {
                PricePerDay = currReservation.Car.PricePerDay,
                Id = currReservation.Id,
                Make = currReservation.Car.Make,
                Model = currReservation.Car.Model,
                Status = "New",
                Year = currReservation.Car.Year,
                CarId = currReservation.CarId,
                EndDate = currReservation.EndDate,
                StartDate = currReservation.StartDate,
                LicensePlate = currReservation.Car.LicensePlate,
                
                UserId = currReservation.UserId
            };
            await _sender.Send(request);
            return reservation.Id;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }
    }
}