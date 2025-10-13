using System.ComponentModel.DataAnnotations;
using Report_System_Backend.model;

namespace Report_System_Backend.dto;

public class DtoReportRequest
{
    [Required]
    [StringLength(100,MinimumLength = 1)]
    public String Title { get; set; }
    [Required]
    public Location Location { get; set; }
    [StringLength(1000,MinimumLength = 1)]
    public string Description { get; set; }
    [Required]
    public ReportImportance  Importance { get; set; }
    [Required]
    public ReportType Type { get; set; }
   

    
}