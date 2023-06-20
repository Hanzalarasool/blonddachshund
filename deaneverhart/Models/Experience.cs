namespace deaneverhart.Models
{
    public class Experience
    {


        public int Id { get; set; }

        public string? Item { get; set; }

        // ______________________________________

        public string? Tag { get; set; }

        public int? Sort1 { get; set; }

        public int? Sort2 { get; set; }

        public bool? Publish { get; set; }

        public bool? Inactive { get; set; }

        // ______________________________________

        public ICollection<Technology>? Technologies { get; set; }
    }
}
