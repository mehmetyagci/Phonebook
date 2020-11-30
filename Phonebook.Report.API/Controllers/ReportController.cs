using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Domain;
using Phonebook.Dto;
using Phonebook.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phonebook.Web.API.Models;

namespace Phonebook.Report.API.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly ILogger<ReportController> _logger;

        public ReportController(
           IReportService reportService,
           IMapper mapper,
           ILogger<ReportController> logger)
        {
            _reportService = reportService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("get")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var reports = await _reportService.GetAllAsync();
                var reportDtos = _mapper.Map<IEnumerable<ReportResponse>>(reports);
                return Ok(reportDtos);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. ReportController.GetAll method.");

                return BadRequest(error);
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<ReportResponse>> Create(string reportName)
        {
            try
            {
                Phonebook.Domain.Report report = new Phonebook.Domain.Report();
                report.Name = reportName;
                await _reportService.SaveAsync(report);
                var result = _mapper.Map<ReportResponse>(report);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = (new CustomBadRequest
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.ToString(),
                });

                _logger.LogError(ex, "Exception Caught. ReportController.Create method.");

                return BadRequest(error);
            }
        }
    }
}
