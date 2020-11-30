using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Service;
using Phonebook.Web.API.Models;
using AutoMapper;
using Phonebook.Dto;
using Phonebook.Domain;

namespace Phonebook.Web.API.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonController> _logger;

        public PersonController(
            IPersonService personService,
            IMapper mapper,
            ILogger<PersonController> logger)
        {
            _personService = personService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetAll()
        {
            try
            {
                var persons = await _personService.GetAllAsync();
                var personDtos = _mapper.Map<IEnumerable<PersonResponse>>(persons);
                return Ok(personDtos);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.GetAll method.");

                return BadRequest(error);
            }
        }


        [HttpGet("get/{id:guid}")]
        public async Task<ActionResult<PersonResponse>> Get(Guid id)
        {
            try
            {
                var person = await _personService.GetAsync(id);
                var personDto = _mapper.Map<PersonResponse>(person);
                return Ok(personDto);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.Get method: {@id} .", id);

                return BadRequest(error);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<PersonResponse>> Create(CreatePersonRequest createPersonRequest)
        {
            try
            {
                var person = _mapper.Map<Person>(createPersonRequest);
                await _personService.SaveAsync(person);
                var result = _mapper.Map<PersonResponse>(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.Create method.");

                return BadRequest(error);
            }
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult<PersonResponse>> Update(Guid id, UpdatePersonRequest updatePersonRequest)
        {
            try
            {
                var person = _mapper.Map<Person>(updatePersonRequest);
                person = await _personService.SaveAsync(person);
                var result = _mapper.Map<PersonResponse>(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.Update method.");

                return BadRequest(error);
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _personService.DeleteWithDetails(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.Delete method.");

                return BadRequest(error);
            }
        }

        #region Other Methods

        [HttpGet("getdetails/{id:guid}")]
        public async Task<ActionResult<PersonDetailResponse>> GetDetails(Guid id)
        {
            try
            {
                var personWithCommunicationInfos = await _personService.GetDetails(id);
                var personDetailDto = _mapper.Map<PersonDetailResponse>(personWithCommunicationInfos);
                return Ok(personDetailDto);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. PersonController.Get method: {@id} .", id);

                return BadRequest(error);
            }
        }
        #endregion Other Methods
    }
}
