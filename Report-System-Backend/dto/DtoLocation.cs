using System.ComponentModel.DataAnnotations;

namespace Report_System_Backend.dto;

public class DtoLocation
{
    [Required]
    [Range(-90,90)]
    public double Lat { get; set; }
    
    [Required]
    [Range(-180, 180)]
    public double Lng { get; set; }
}