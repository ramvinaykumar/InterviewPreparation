using Microsoft.EntityFrameworkCore;
using Winwire.Assessment.API.Models.Entities;

namespace Winwire.Assessment.API.Data.Db
{
    public class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options) 
        { 
            
        }   

        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
