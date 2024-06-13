using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllAsync()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetByIdAsync(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CarDto carDto)
        {
            var car = new Car
            {
                Make = carDto.Make,
                Model = carDto.Model,
                Year = carDto.Year,
                LicensePlate = carDto.LicensePlate,
                PricePerDay = carDto.pricePerDay,
                StatusId = carDto.statusId,
                ReservationStatus = carDto.reservationStatusId
                
                
                // Initialize other properties if necessary
            };

            await _carService.AddAsync(car);
            return Ok(new PostResult() { Id = car.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, CarDto carDto)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.Make = carDto.Make;
            car.Model = carDto.Model;
            car.Year = carDto.Year;
            car.ReservationStatus = carDto.reservationStatusId;
            car.StatusId = carDto.statusId;
            car.PricePerDay = carDto.pricePerDay;
            car.LicensePlate = carDto.LicensePlate;
            
            // Update other properties if necessary

            await _carService.UpdateAsync(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _carService.DeleteAsync(id);
            return NoContent();
        }
    }
}
