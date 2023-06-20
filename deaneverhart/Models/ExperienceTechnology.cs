using System.Diagnostics;

namespace deaneverhart.Models
{
    public class ExperienceTechnology
    {
        public int ExperienceTechnologyID { get; set; }
        public int ExperienceID { get; set; }
        public int TechnologyID { get; set; }

        // _________________________________________________

        public Experience? Experience { get; set; }
        public Technology? Technology { get; set; }
    }
}
