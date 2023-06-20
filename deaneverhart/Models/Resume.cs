using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace deaneverhart.Models
{
    public class Resume
    {
        public int Id { get; set; }

        public string? Version { get; set; }

        public string? Type1 { get; set; }

        public string? Type2 { get; set; }

        public string? Company { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? CityTown { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        [Display(Name = "Location")]
        public string Location
        {
            get
            {
                return CityTown + ", " + State;
            }
        }

        public string? Title { get; set; }

        [Display(Name = "From")]
        public string? From1 { get; set; }

        [Display(Name = "To")]
        public string? To1 { get; set; }

        [Display(Name = "Dates")]
        public string Dates
        {
            get
            {
                return From1 + "-" + To1;
            }
        }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime? To { get; set; }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime? DateTimeFrom { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime? DateTimeTo { get; set; }

        public string? Item { get; set; }

        // ______________________________________

        public string? Tag { get; set; }

        public int? Sort1 { get; set; }

        public int? Sort2 { get; set; }

        public bool? Publish { get; set; }

        public bool? Inactive { get; set; }

        // ______________________________________

        public ICollection<Experience>? Experiences { get; set; }
        public ICollection<ResumeExperience>? ResumeExperiences { get; set; }
    }
}
