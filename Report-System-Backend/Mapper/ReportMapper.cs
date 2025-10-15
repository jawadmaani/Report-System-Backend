using Report_System_Backend.dto;
using Report_System_Backend.model;

namespace Report_System_Backend.Mapper;

public class ReportMapper
{
    public static DtoReportResponse ToDto(Report report)
    {
        return new DtoReportResponse
        {
            Id = report.Id,
            Title = report.Title,
            Location = new DtoLocation
            {
                Lat = report.Location.Lat,
                Lng = report.Location.Lng
            },
            Description = report.Description,
            Importance = report.Importance,
            Type = report.Type,
            CreatedAt = report.CreatedAt,
        };

    }
    public static List<DtoReportResponse> ToDtoList(IEnumerable<Report> reports)
    {
        return reports.Select(ToDto).ToList();
    }
    
    
}