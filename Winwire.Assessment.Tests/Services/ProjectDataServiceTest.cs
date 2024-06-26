using Moq;
using Winwire.Assessment.API.Repository.Interface;
using Winwire.Assessment.API.Repository.Services;

namespace Winwire.Assessment.Tests.Services
{
    public class ProjectDataServiceTest
    {
        private Mock<IProjectDataService> _mockService;
        private ProjectDataService _dataService;

        private void LoadServices()
        {
            _mockService = new Mock<IProjectDataService>();
            //_dataService = new ProjectDataService();
        }
    }
}
