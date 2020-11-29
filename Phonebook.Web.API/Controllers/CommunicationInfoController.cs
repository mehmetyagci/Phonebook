using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Domain;
using Phonebook.Dto;
using Phonebook.Service;
using Phonebook.Web.API.Models;
using System;
using System.Threading.Tasks;

namespace Phonebook.Web.API.Controllers
{
    [Route("communicationinfo")]
    [ApiController]
    public class CommunicationInfoController : ControllerBase
    {
        private readonly ICommunicationInfoService _communicationInfoService;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly ILogger<CommunicationInfoController> _logger;

        public CommunicationInfoController(
            ICommunicationInfoService communicationInfoService,
            IPersonService personService,
            IMapper mapper,
            ILogger<CommunicationInfoController> logger)
        {
            _communicationInfoService = communicationInfoService;
            _personService = personService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CommunicationInfoResponse>> Create(CreateCommunicationInfoRequest createCommunicationInfoRequest)
        {
            try
            {
                var communicationInfo = _mapper.Map<CommunicationInfo>(createCommunicationInfoRequest);
                communicationInfo.Person = await _personService.GetAsync(createCommunicationInfoRequest.PersonId);
                await _communicationInfoService.SaveAsync(communicationInfo);
                var result = _mapper.Map<CommunicationInfoResponse>(communicationInfo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. CommunicationInfo.Create method.");

                return BadRequest(error);
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _communicationInfoService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. CommunicationInfo.Delete method.");

                return BadRequest(error);
            }
        }
    }
}
