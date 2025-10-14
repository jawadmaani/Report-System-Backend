using Microsoft.AspNetCore.Mvc;
using Report_System_Backend.dto;
using Report_System_Backend.service;

namespace Report_System_Backend.controller;

[ApiController]
[Route("api/Report")]
public class ReportController:ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] DtoReportRequest dtoReportRequest)
    {
        var reports = await _reportService.CreateReport(dtoReportRequest);
        return Ok(reports);
    }

    
    [HttpGet]
    public async Task<ActionResult<List<DtoReportResponse>>> GetReports()
    {
        var reports = await _reportService.GetAll();
        return Ok(reports);
        
    }
    
}