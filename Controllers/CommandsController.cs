using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Data.Implementation;
using Commander.DTO;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// Note: Binding Source docs : https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0

namespace Commander.Controllers
{
    // api/commands
    [Route("api/[controller]")] // or can set hard-coded string
    [ApiController] // attributes that gives default behaviours that controller performs; not mandotory
    public class CommandsController : ControllerBase // ControllerBase is a class of MVC controller with view support
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        // contructor in order to inject dependencies
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;  // dependency injection for automapper IMapper
        }

        // using the implementation class to return data back to application
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo(); // calling a private instance

        // Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands(); // calling methond from MockCommanderRepo
            // return Ok(commandItems); // Ok for 200 success
            return Ok(_mapper.Map<IEnumerable<CommandReadDtos>>(commandItems));
        }

        // Get api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")] 
        public ActionResult<CommandReadDtos> GetCommandById(int id) // id is request pass from binding sources
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                // return Ok(commandItem);
                return Ok(_mapper.Map<CommandReadDtos>(commandItem));
            }
            return NotFound();
        }

        // Post api/commands 
        [HttpPost]
        public ActionResult<CommandCreateDtos> CreateCommand(CommandCreateDtos commandCreateDto) //source
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto); // map to Command Object
            // validation check
            _repository.CreateCommand(commandModel); // calling createcommand method to pass command model
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDtos>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
            // This will return status; 201, and also provide the new url for newly created command
            // return Ok(commandReadDto);
            // return Ok(commandModel);

        }


        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDtos commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo); // source to destination

            _repository.UpdateCommand(commandModelFromRepo); // not necessary

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDtos> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDtos>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
