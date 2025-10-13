using System.ComponentModel.DataAnnotations;

namespace Report_System_Backend.model;



public class Report
{
    
    public int Id { get; private set; }
    
    [Required]  
    [StringLength(maximumLength:100,MinimumLength = 1)]
    public string Title { get; set; }
    [Required]
    public Location Location { get; set; }
    
    [StringLength(maximumLength:1000,MinimumLength = 1)]
    public string Description { get; set; }
    
    [Required]
    public ReportImportance Importance { get; set; }
    
    [Required]
    public ReportType Type { get; set; }
    
    public DateTime CreatedAt { get; private set; }
    
    
}