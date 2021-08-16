using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data.Interface;
using Commander.DTO;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Commander.Controllers
{
    /// api/commands
    [Route("api/[controller]")] 
    [ApiController] 
    public class ReservationsController : ControllerBase // CB -> MVC controller with view support
    {
        private readonly IReservationRepo _repository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/reservations
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetAllReservation()
        {
            var bookingItems = _repository.GetAllReservation(); 
           
            return Ok(bookingItems);
        }


        // Get: api/reservations/{id}
        [HttpGet("{id}", Name = "GetReservationById")]
        public ActionResult<ReservationReadDto> GetReservationById(int id)
        {
            var reserveItem = _repository.GetReservationById(id);

            if(reserveItem != null)
            {
                return Ok(_mapper.Map<ReservationReadDto>(reserveItem));
            }

            return NotFound();
        }

        // Get: api/reservations/mobile/{mobile}
        [HttpGet("mobile/{mobile}")]
        public ActionResult<ReservationReadDto> GetReservationByMobile(string mobile)
        {
            var reserveItem = _repository.GetReservationByMobile(mobile);
           
            if(reserveItem != null)
            {
                return Ok(_mapper.Map<ReservationReadDto>(reserveItem)); //200
            }

            return NotFound(); //204
        }

        // Get: api/reservations/date/{date}
        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Reservation>>GetAllReservationByDate(DateTime date)
        {
            var reserveItem = _repository.GetAllReservationByDate(date);

            if (reserveItem != null)
            {
                return Ok((reserveItem));
            }
            return NotFound();

        }

        // Post api/reservations
        [HttpPost]
        public ActionResult <ReservationReadDto> CreateReservation(ReservationCreateDto createBookingDto)
        {
            var bookingModel = _mapper.Map<Reservation>(createBookingDto);

           // _repository.CheckTimeRange(bookingModel);
            _repository.CreateReservation(bookingModel);
            _repository.SaveChanges();

            var reservationReadDto = _mapper.Map<ReservationReadDto>(bookingModel);

            return CreatedAtRoute(nameof(GetReservationById), new { Id = reservationReadDto.Id }, reservationReadDto);
        }

        // Put api/reservations/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if(reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationUpdateDto, reservationModelFromRepo); // source to destination

            _repository.UpdateReservation(reservationModelFromRepo); // not necessary

            _repository.SaveChanges();

            return NoContent();
        }



        // PATCH api/reservations/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialReservationUpdate(int id, JsonPatchDocument<ReservationUpdateDto> patchDoc)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if (reservationModelFromRepo == null)
            {
                return NotFound();
            }

            var reservationToPatch = _mapper.Map<ReservationUpdateDto>(reservationModelFromRepo);
            patchDoc.ApplyTo(reservationToPatch, ModelState);

            if (!TryValidateModel(reservationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(reservationToPatch, reservationModelFromRepo);

            _repository.UpdateReservation(reservationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/reservations/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if (reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteReservation(reservationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }


}
