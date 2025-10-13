using System.ComponentModel.DataAnnotations;

namespace Report_System_Backend.model
{
    public class Location
    {
        [Required]
        [Range(-90, 90)]
        public double Lat { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Lng { get; set; }
        
        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}