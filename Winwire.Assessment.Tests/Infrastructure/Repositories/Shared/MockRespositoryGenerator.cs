using Winwire.Assessment.API.Repository.Interface;
using Winwire.Assessment.API.Repository.Services;
using Winwire.Assessment.Tests.Infrastructure.Repositories.ImmemoryDatabaseGenerator;

namespace Winwire.Assessment.Tests.Infrastructure.Repositories.Shared
{
    /// <summary>
    /// Mocking Repository
    /// </summary>
    public static class MockRespositoryGenerator
    {
        /// <summary>
        /// Get the Project DataService Repository
        /// </summary>
        /// <returns>Returns Db Context</returns>
        public static IProjectDataServiceRepository GetProjectDataServiceRepository()
        {
            var context = MockDatabaseContextGenerator.GenerateMockDbContext ();
            var repository = new ProjectDataServiceRepository(context);
            return repository;
        }
    }
}
