using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetByIdAsync(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(ReservationDto reservation)
        {

            var newReservation = new Reservation()
            {
                UserId = reservation.UserId,
                Status = reservation.Status,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                CarId = reservation.CarId
            };
            var result = await _reservationService.AddAsync(newReservation);
            return Ok(new PostResult(){Id = result});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            await _reservationService.UpdateAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }
    }
}