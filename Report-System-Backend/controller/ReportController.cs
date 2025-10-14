using Microsoft.AspNetCore.Mvc;
using Report_System_Backend.dto;
using Report_System_Backend.service;

namespace Report_System_Backend.controller;

[ApiController]
[Route("api/Report")]
public class ReportController:ControllerBase
{
    private readonly ReportService reportService;

    public ReportController(ReportService reportService)
    {
        this.reportService = reportService;
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] DtoReportRequest dtoReportRequest)
    {
        var reports = await reportService.CreateReport(dtoReportRequest);
        return Ok(reports);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReport(int id)
    {
        var report=await reportService.DeleteReport(id);
        return Ok(report);
    }

    
    [HttpGet]
    public async Task<ActionResult<List<DtoReportResponse>>> GetAllReports()
    {
        var reports = await reportService.GetAllReports();
        return Ok(reports);
        
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReportResponse>> GetReportById(int id)
    {
        var report = await reportService.GetReportById(id);
        return Ok(report);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DtoReportResponse>> UpdateReport(int id, DtoReportRequest dtoReportRequest)
    {
        var report = await reportService.UpdateReport(id, dtoReportRequest);
        return Ok(report);
    }
    
    
    
}