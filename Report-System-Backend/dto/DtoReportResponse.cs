using Report_System_Backend.model;

namespace Report_System_Backend.dto;

public class DtoReportResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Location Location { get; set; }
    public string Description { get; set; }
    public ReportImportance Importance { get; set; }
    public ReportType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}