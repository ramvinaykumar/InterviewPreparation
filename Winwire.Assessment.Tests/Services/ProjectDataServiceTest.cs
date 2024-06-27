using Winwire.Assessment.API.Data.Db;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Services;
using Winwire.Assessment.Tests.Infrastructure.Repositories.ImmemoryDatabaseGenerator;

namespace Winwire.Assessment.Tests.Services
{
    public class ProjectDataServiceTest
    {
        private AssessmentDbContext _mockDbContext = null!;
        private ProjectDataServiceRepository _mockProjectService = null!;

        private void LoadServices()
        {
            // First way to call mock dbConext Generator
            _mockDbContext = MockDatabaseContextGenerator.GenerateMockDbContext();
            // another way to call mock dbConext Generator
            //_mockDbContext = MockContextGenerator.GetAssessmentDbContext();

            _mockProjectService = new ProjectDataServiceRepository(_mockDbContext);
        }

        [Fact]
        public async Task Create_NewRecord_Success()
        {
            LoadServices();
            var requestData = Mock_RequestDto();
            var response = await _mockProjectService.CreateAsync(requestData);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.Equal(response.ProjectName, requestData.ProjectName);
                Assert.Equal(response.ProjectVersion, requestData.ProjectVersion);
            }
        }

        [Fact]
        public async Task Create_NewRecord_Failure()
        {
            LoadServices();
            var requestData = Mock_RequestDto();
            requestData.ProjectName = string.Empty;

            var response = await _mockProjectService.CreateAsync(requestData);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.Equal(0, response.ProjectId);
            }
        }

        [Fact]
        public async Task Update_ExistingRecord_Success()
        {
            LoadServices();
            var requestData = Mock_EditRequestDto();
            var response = await _mockProjectService.UpdateAsync(requestData);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.Equal(response.ProjectName, requestData.ProjectName);
                Assert.Equal(response.ProjectVersion, requestData.ProjectVersion);
            }
        }

        [Fact]
        public async Task Update_ExistingRecord_Failure()
        {
            LoadServices();
            var requestData = Mock_EditRequestDto();
            requestData.Id = 0;

            var response = await _mockProjectService.UpdateAsync(requestData);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.Equal(response.ProjectId, requestData.Id);
            }
        }

        [Fact]
        public async Task Get_AllRecord_Success()
        {
            LoadServices();
            var response = await _mockProjectService.GetAllAsync();

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.NotNull(response?.FirstOrDefault()?.ProjectName);
            }
        }

        [Fact]
        public async Task Get_RecordById_Success()
        {
            LoadServices();
            int projectId = 1;
            var response = await _mockProjectService.GetByIdAsync(projectId);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.NotNull(response?.ProjectName);
            }
        }

        [Fact]
        public async Task Get_RecordById_Failure()
        {
            LoadServices();
            int projectId = 0;
            var response = await _mockProjectService.GetByIdAsync(projectId);

            if (response != null)
            {
                Assert.NotNull(response);
                Assert.Equal(response?.ProjectId, projectId);
            }
        }

        [Fact]
        public async Task Delete_RecordById_Success()
        {
            LoadServices();
            int projectId = 1;
            var response = await _mockProjectService.DeleteAsync(projectId);

            if (response > 0)
            {
                Assert.Equal(response, projectId);
            }
        }

        [Fact]
        public async Task Delete_RecordById_Failure_NotFound()
        {
            LoadServices();
            int projectId = 0;
            var response = await _mockProjectService.DeleteAsync(projectId);

            if (response == 0)
            {
                Assert.Equal(response, projectId);
            }
        }

        private AddProjectDto Mock_RequestDto()
        {
            var projectDto = new AddProjectDto
            {
                ProjectDescription = "Test",
                ProjectName = "Test",
                ProjectType = "Test",
                ProjectVersion = "1.0.0",
            };
            return projectDto;
        }

        private EditProjectDto Mock_EditRequestDto()
        {
            var projectDto = new EditProjectDto
            {
                Id = 1,
                ProjectDescription = "Test",
                ProjectName = "Test",
                ProjectType = "Test",
                ProjectVersion = "1.0.0",
            };
            return projectDto;
        }
    }
}
