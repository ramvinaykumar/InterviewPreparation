using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Services;
using Winwire.Assessment.Tests.Infrastructure.Repositories.Shared;

namespace Winwire.Assessment.Tests.Infrastructure.Repositories
{
    public class ProjectDataServiceRepositoryTest
    {
        ProjectDataServiceRepository _repository;

        public ProjectDataServiceRepositoryTest()
        {
            _repository = (ProjectDataServiceRepository)MockRespositoryGenerator.GetProjectDataServiceRepository();
        }

        [Fact]
        public async Task GetAll_Projects_Success()
        {
            var response = await _repository.GetAllAsync();
            Assert.True(response != null);
        }

        [Fact]
        public async Task ProjectById_RecordNotFound()
        {
            var response = await _repository.GetByIdAsync(5);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ProjectById_FoundRecord_Success()
        {
            var response = await _repository.GetByIdAsync(1);
            Assert.True(response != null);
        }

        [Fact]
        public async Task AddProjectAsync_Success()
        {
            var request = AddProject_Mock();
            
            var reult = await _repository.CreateAsync(request);
            Assert.Equal(request.ProjectName, reult.ProjectName);
        }

        [Fact]
        public async Task AddProjectAsync_Failure()
        {
            var request = AddProject_Mock();
            request = null;

            var reult = await _repository.CreateAsync(request);
            Assert.Equal(0, reult.ProjectId);
        }

        [Fact]
        public async Task UpdateProjectAsync_Success()
        {
            var request = Mock_EditRequestDto();

            var reult = await _repository.UpdateAsync(request);
            Assert.Equal(request.ProjectName, reult.ProjectName);
        }

        [Fact]
        public async Task UpdateProjectAsync_Failure()
        {
            var request = Mock_EditRequestDto();
            request = null;

            var reult = await _repository.UpdateAsync(request);
            Assert.Equal(0, reult.ProjectId);
        }

        [Fact]
        public async Task Delete_ProjectAsync_Success()
        {
            var reult = await _repository.DeleteAsync(1);
            Assert.Equal(1, reult);
        }

        [Fact]
        public async Task Delete_ProjectAsync_Failure()
        {
            var reult = await _repository.DeleteAsync(0);
            Assert.Equal(0, reult);
        }

        private AddProjectDto AddProject_Mock()
        {
            AddProjectDto requestEntity = new AddProjectDto
            {
                ProjectDescription = "Test Description1",
                ProjectName = "",
                ProjectType = "Test Type1",
                ProjectVersion = "Test Version1",
            };

            return requestEntity;
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
