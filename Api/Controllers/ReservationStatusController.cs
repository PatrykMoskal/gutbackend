﻿using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationStatusController : ControllerBase
    {
        private readonly IReservationStatusService _reservationStatusService;

        public ReservationStatusController(IReservationStatusService reservationStatusService)
        {
            _reservationStatusService = reservationStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationStatus>>> GetAllAsync()
        {
            var reservationStatuses = await _reservationStatusService.GetAllAsync();
            return Ok(reservationStatuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationStatus>> GetByIdAsync(int id)
        {
            var reservationStatus = await _reservationStatusService.GetByIdAsync(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }
            return Ok(reservationStatus);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(ReservationStatus reservationStatus)
        {
            await _reservationStatusService.AddAsync(reservationStatus);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = reservationStatus.Id }, reservationStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ReservationStatus reservationStatus)
        {
            if (id != reservationStatus.Id)
            {
                return BadRequest();
            }
            await _reservationStatusService.UpdateAsync(reservationStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reservationStatusService.DeleteAsync(id);
            return NoContent();
        }
    }
}
