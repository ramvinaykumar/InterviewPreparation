using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winwire.Assessment.API.Controllers;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.Tests.Controller
{
    public class ProjectControllerTest
    {
        private Mock<IProjectDataService> _mockProjectService;
        private ProjectController _mockController;

        private void InitilizeServices()
        {
            _mockProjectService = new Mock<IProjectDataService>();
            _mockController = new ProjectController(_mockProjectService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn200_StatusCoce()
        {
            InitilizeServices();
            _mockProjectService.Setup(_=> _.GetProjectsAsync()).ReturnsAsync(GetProjectsData());
            var result = await _mockController.GetProjects();
            var response = (OkObjectResult)result;
            response.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_ShouldReturn404_StatusCoce()
        {
            InitilizeServices();
            _mockProjectService.Setup(_ => _.GetProjectsAsync()).ReturnsAsync(GetProjects_WithoutData());
            var result = await _mockController.GetProjects();
            var response = (NotFoundResult)result;
            response.StatusCode.Should().Be(404);
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
    }
}
