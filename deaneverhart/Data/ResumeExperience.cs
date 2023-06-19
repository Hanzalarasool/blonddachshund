using System.Diagnostics;

namespace deaneverhart.Data
{
    public class ResumeExperience
    {
        {
        public int ResumeExperienceID { get; set; }
        public int ResumeID { get; set; }
        public int ExperienceID { get; set; }

// _________________________________________________

        public Resume? Resume { get; set; }
        public Experience? Experience { get; set; }
    }
}
