using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Winwire.Assessment.API.Data.Db;
using Winwire.Assessment.API.Models.Entities;

namespace Winwire.Assessment.Tests.Infrastructure.Repositories.ImmemoryDatabaseGenerator
{
    /// <summary>
    /// Creating Database Context for Mocking Purpose
    /// </summary>
    public static class MockDatabaseContextGenerator
    {
        /// <summary>
        /// Generate Mock DbContext
        /// </summary>
        /// <returns>Returns Db Context</returns>
        public static AssessmentDbContext GenerateMockDbContext()
        {
            var options = new DbContextOptionsBuilder<AssessmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString(), _ => _.EnableNullChecks(false))
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new AssessmentDbContext(options);

            // Ensure existing context database is empty before populating data
            context.Database.EnsureDeleted();
            if (context.Database.IsRelational())
            {
                context.Database.Migrate();
            }
            PopulateTestData(context);
            return context;
        }

        #region Private methods

        /// <summary>
        /// Method to populate Test Data
        /// </summary>
        /// <param name="context"></param>
        private static void PopulateTestData(AssessmentDbContext context)
        {
            context.AddProject_MockData();
            context.SaveChanges();
        }

        /// <summary>
        /// Mock Data for Project Dto / Entity
        /// </summary>
        /// <param name="context">DbContext Object AssessmentDbContext </param>
        private static void AddProject_MockData(this AssessmentDbContext context)
        {
            //ProjectEntity projectEntity = new ProjectEntity
            //{
            //    ProjectDescription = "Test Description",
            //    ProjectName = "Test Name",
            //    ProjectType = "Test Type",
            //    ProjectVersion = "Test Version",
            //};
            context.Projects.Add(new ProjectEntity
            {
                ProjectDescription = "Test Description1",
                ProjectName = "Test Name1",
                ProjectType = "Test Type1",
                ProjectVersion = "Test Version1",
            });
            context.Projects.Add(new ProjectEntity
            {
                ProjectDescription = "Test Description2",
                ProjectName = "Test Name2",
                ProjectType = "Test Type2",
                ProjectVersion = "Test Version2",
            });
            context.Projects.Add(new ProjectEntity
            {
                ProjectDescription = "Test Description3",
                ProjectName = "Test Name3",
                ProjectType = "Test Type3",
                ProjectVersion = "Test Version3",
            });
        }

        #endregion
    }
}
