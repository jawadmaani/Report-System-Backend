using Report_System_Backend.dto;
using Report_System_Backend.exception;
using Report_System_Backend.model;
using Report_System_Backend.Repository;

namespace Report_System_Backend.service;



public class ReportService
{
    private readonly IRepository<Report> repository;

    public ReportService(IRepository<Report> repository)
    {
        this.repository = repository;

    }

    public async Task<String>  CreateReport(DtoReportRequest dtoReportRequest)
    {
        var report = new Report
        {
            Title = dtoReportRequest.Title,
            Location = dtoReportRequest.Location,
            Description = dtoReportRequest.Description,
            Importance = dtoReportRequest.Importance,
            Type = dtoReportRequest.Type,
        };
            await repository.CreateAsync(report);
            await repository.SaveAsync();

            return "Report created successfully";


    }
    
    public async Task <List<DtoReportResponse>> GetAll()
    {
        var reports = await repository.GetAllAsync();
        if (reports is null || !reports.Any())
        {
            throw new EmptyDatabaseFromReports("No reports found in the database");
        }
        var dtoReports = reports.Select(report => new DtoReportResponse
        {
            Id = report.Id,
            Title = report.Title,
            Location =report.Location,
            Description = report.Description,
            Importance = report.Importance,
            Type = report.Type,
            CreatedAt = report.CreatedAt,
        });
        return dtoReports.ToList();

    }
    
    



}