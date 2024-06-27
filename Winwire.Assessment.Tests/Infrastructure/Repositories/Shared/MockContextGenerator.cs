using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Winwire.Assessment.API.Data.Db;
using Winwire.Assessment.API.Models.Entities;

namespace Winwire.Assessment.Tests.Infrastructure.Repositories.Shared
{
    /// <summary>
    /// Mocking Database Context
    /// </summary>
    public static class MockContextGenerator
    {
        /// <summary>
        /// Get Mock DbContext
        /// </summary>
        /// <returns>Returns Db Context</returns>
        public static AssessmentDbContext GetAssessmentDbContext()
        {
            var options = new DbContextOptionsBuilder<AssessmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString(), b => b.EnableNullChecks(false))
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new AssessmentDbContext(options);
            PopulateTestData(context);
            return context;
        }

        #region Private methods

        /// <summary>
        /// Method to populate Test Data
        /// </summary>
        /// <param name="context">DbContext Object : AssessmentDbContext </param>
        private static void PopulateTestData(AssessmentDbContext context)
        {
            context.AddProject_MockData();
        }

        /// <summary>
        /// Mock Data for Project Dto / Entity
        /// </summary>
        /// <param name="context">DbContext Object : AssessmentDbContext </param>
        private static void AddProject_MockData(this AssessmentDbContext context)
        {
            ProjectEntity projectEntity = new ProjectEntity
            {
                ProjectDescription = "Test Description",
                ProjectName = "Test Name",
                ProjectType = "Test Type",
                ProjectVersion = "Test Version",
            };
            context.Projects.Add(projectEntity);
        }

        #endregion
    }
}
