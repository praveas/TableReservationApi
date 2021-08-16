
using System.Collections.Generic;
using AutoMapper;
using Commander.Data.Interface;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    /// api/tables
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITable _repository;
        private readonly IMapper _mapper;

        public TablesController(ITable repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/reservations
        [HttpGet]
        public ActionResult<IEnumerable<Table>> GetAllTable()
        {
            var tableItems = _repository.GetAllTable();

            return Ok(tableItems);
        }
    }

}