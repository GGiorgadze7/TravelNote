using System.ComponentModel.DataAnnotations;

namespace TravelerNotes.Models.Place
{
    public class PlaceRequest
    {
        [Required]
        public required string Name { get; set; }

        public string? LocationUrl { get; set; }

        public string? WorkStartTime { get; set; }

        public string? WorkEndTime { get; set; }

        public int CountryId { get; set; }
    }
}
