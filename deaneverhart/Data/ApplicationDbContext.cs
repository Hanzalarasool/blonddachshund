using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using deaneverhart.Models;

namespace deaneverhart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Resume>? Resume { get; set; }
        public DbSet<deaneverhart.Models.Experience>? Experience { get; set; }
        public DbSet<deaneverhart.Models.ResumeExperience>? ResumeExperience { get; set; }
    }
}