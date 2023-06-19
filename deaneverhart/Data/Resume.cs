namespace deaneverhart.Data
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

        public string? Title { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string? Item { get; set; }

        public int? Sort1 { get; set; }

        public int? Sort2 { get; set; }

        public bool? Publish { get; set; }

        public bool? Inactive { get; set; }

       // ______________________________________

        public ICollection<Experience>? Experiences { get; set; }
    }
}
