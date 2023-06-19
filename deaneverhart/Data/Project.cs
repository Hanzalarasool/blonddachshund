namespace deaneverhart.Data
{
    public class Project
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public string Description { get; set; }

        public string GitHub { get; set; }

        public string URL { get; set; }

        // _________________________________

        public int? Sort1 { get; set; }

        public int? Sort2 { get; set; }

        public bool? Publish { get; set; }

        public bool? Inactive { get; set; }

        // _________________________________

    }
}
