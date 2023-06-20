namespace deaneverhart.Models
{
    public class Technology
    {
        public int Id { get; set; }

        public string? Item { get; set; }

        public string? URL { get; set; }

        // _________________________________

        public string? Tag { get; set; }

        public int? Sort1 { get; set; }

        public int? Sort2 { get; set; }

        public bool? Publish { get; set; }

        public bool? Inactive { get; set; }

        // ______________________________________

        public ICollection<Project>? Projects { get; set; }
    }
}
