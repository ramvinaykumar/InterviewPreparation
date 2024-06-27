using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Winwire.Assessment.API.Controllers;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.Tests.Controller
{
    public class ProjectControllerTest
    {
        private Mock<IProjectDataServiceRepository> _mockProjectService = new Mock<IProjectDataServiceRepository>();
        private ProjectController _mockController = null!;

        private void InitilizeServices()
        {
            _mockProjectService = new Mock<IProjectDataServiceRepository>();
            _mockController = new ProjectController(_mockProjectService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn200_StatusCoce()
        {
            InitilizeServices();
            _mockProjectService.Setup(_ => _.GetAllAsync()).ReturnsAsync(GetProjectsData());
            var result = await _mockController.GetProjects();
            var response = (OkObjectResult)result;
            response.StatusCode.Should().Be(200);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturn404_StatusCoce()
        {
            InitilizeServices();
            _mockProjectService.Setup(_ => _.GetAllAsync()).ReturnsAsync(GetProjects_WithoutData());
            var result = await _mockController.GetProjects();
            var response = (NotFoundResult)result;
            response.StatusCode.Should().Be(404);
            Assert.Equal(StatusCodes.Status404NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetProjectById_ShouldReturn200Status()
        {
            InitilizeServices();
            var projectList = GetProjectsData();
            _mockProjectService.Setup(_ => _.GetByIdAsync(3)).ReturnsAsync(projectList[2]);

            var result = (OkObjectResult)await _mockController.GetProjectById(3);

            result.StatusCode.Should().Be(200);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task GetProjectById_ShouldReturn404Status()
        {
            InitilizeServices();
            var projectList = GetProjectsData();
            _mockProjectService.Setup(_ => _.GetByIdAsync(5));

            var result = (NotFoundResult)await _mockController.GetProjectById(5);

            result.StatusCode.Should().Be(404);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task DeleteProjectById_ShouldReturn200Status()
        {
            InitilizeServices();
            _mockProjectService.Setup(_ => _.DeleteAsync(It.IsAny<int>())).ReturnsAsync(1);

            // Act
            var result = await _mockController.DeleteProject(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(1, okResult.Value);
        }

        [Fact]
        public async Task DeleteProjectById_ShouldReturn404Status()
        {
            InitilizeServices();
            _mockProjectService.Setup(_ => _.DeleteAsync(It.IsAny<int>()));

            var result = (NotFoundResult)await _mockController.DeleteProject(5);

            result.StatusCode.Should().Be(404);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task CreateProjectById_ShouldReturn200Status()
        {
            InitilizeServices();
            var requestDto = Mock_RequestDto();
            _mockProjectService.Setup(_ => _.CreateAsync(It.IsAny<AddProjectDto>()));

            var result = (OkObjectResult)await _mockController.CreateProject(requestDto);

            result.StatusCode.Should().Be(200);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task CreateProjectById_ShouldReturn400Status()
        {
            InitilizeServices();
            var requestDto = Mock_RequestDto();
            requestDto = null;
            _mockProjectService.Setup(_ => _.CreateAsync(It.IsAny<AddProjectDto>()));

            var result = (BadRequestResult)await _mockController.CreateProject(requestDto);

            result.StatusCode.Should().Be(400);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task UpdateProjectById_ShouldReturn200Status()
        {
            InitilizeServices();
            var requestDto = Mock_EditRequestDto();
            _mockProjectService.Setup(_ => _.UpdateAsync(It.IsAny<EditProjectDto>()));

            var result = (OkObjectResult)await _mockController.UpdateProject(requestDto);

            result.StatusCode.Should().Be(200);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task UpdateProjectById_ShouldReturn400Status()
        {
            InitilizeServices();
            var requestDto = Mock_EditRequestDto();
            requestDto = null;
            _mockProjectService.Setup(_ => _.UpdateAsync(It.IsAny<EditProjectDto>()));

            var result = (BadRequestResult)await _mockController.UpdateProject(requestDto);

            result.StatusCode.Should().Be(400);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        private List<ProjectDto> GetProjectsData()
        {
            List<ProjectDto> projects = new List<ProjectDto>
            {
                new ProjectDto
                {
                    ProjectId = 1,
                    ProjectName = "P1",
                    ProjectDescription = "Desc 123",
                    ProjectType = "UI",
                    ProjectVersion = "V1"
                },
                new ProjectDto
                {
                    ProjectId = 0,
                    ProjectName = "P0",
                    ProjectDescription = "Desc 123",
                    ProjectType = "UI",
                    ProjectVersion = "V0"
                },
                new ProjectDto
                {
                    ProjectId = 3,
                    ProjectName = "P3",
                    ProjectDescription = "Desc 123",
                    ProjectType = "MS",
                    ProjectVersion = "V3.0"
                }
            };
            return projects;
        }

        private List<ProjectDto> GetProjects_WithoutData()
        {
            List<ProjectDto> projects = new List<ProjectDto>();
            return projects;
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
