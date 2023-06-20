using System.Diagnostics;

namespace deaneverhart.Models
{
    public class TechnologyProject
    {
        public int TechnologyProjectID { get; set; }
        public int TechnologyID { get; set; }
        public int ProjectID { get; set; }

        // _________________________________________________

        public Technology? Technology { get; set; }
        public Project? Project { get; set; }
    }
}
