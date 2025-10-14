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
    
    public async Task <List<DtoReportResponse>> GetAllReports()
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

    public async Task<DtoReportResponse> GetReportById(int id)
    {
        var report = await repository.GetByIdAsync(id);
        if (report is null)
        {
            throw new EmptyDatabaseFromReports($"No report found with ID {id}");

        }
        var dtoReport = new DtoReportResponse
        {
            Id = report.Id,
            Title = report.Title,
            Location = report.Location,
            Description = report.Description,
            Importance = report.Importance,
            Type = report.Type,
            CreatedAt = report.CreatedAt,
        };
        return dtoReport;
    }

    
    public async Task<String> DeleteReport(int id)
    {
        var report = await repository.GetByIdAsync(id);
        if (report is null)
        {
            throw new EmptyDatabaseFromReports($"No report found with ID {id}");
        }

        await repository.DeleteAsync(id);
        await repository.SaveAsync();
        return $"Report with ID {id} deleted successfully";
    }

    public async Task<DtoReportResponse> UpdateReport(int id,DtoReportRequest dtoReportRequest)
    {
        var report = await repository.GetByIdAsync(id);
        if (report is null)
        {
            throw new EmptyDatabaseFromReports($"No report found with ID {id}");

        }
        report.Title = dtoReportRequest.Title;
        report.Location = dtoReportRequest.Location;
        report.Description = dtoReportRequest.Description;
        report.Importance = dtoReportRequest.Importance;
        report.Type = dtoReportRequest.Type;

        await repository.UpdateAsync(report);
        await repository.SaveAsync();
        
        var dtoReport = new DtoReportResponse
        {
            Id = report.Id,
            Title = report.Title,
            Location = report.Location,
            Description = report.Description,
            Importance = report.Importance,
            Type = report.Type,
            CreatedAt = report.CreatedAt,
        };
        return dtoReport;


    }
    
    
    
    



}