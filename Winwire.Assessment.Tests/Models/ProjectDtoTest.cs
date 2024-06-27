using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winwire.Assessment.API.Models.Dto;

namespace Winwire.Assessment.Tests.Models
{
    public class ProjectDtoTest
    {
        string projectName = "Test 1";
        string projectDesc = "Test Desc";
        int projectId = 1;
        string projectType = "UI";
        string projectVersion = "1.0.9";

        [Fact]
        public void Model_ProjectDtoTest_Success()
        {
            IEnumerable<ProjectDto> model = new List<ProjectDto>
            {
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = projectId
                },
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = 2
                },
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = 3
                }
            };

            Assert.NotNull(model);
            Assert.Equal(model?.FirstOrDefault()?.ProjectName, projectName);
            Assert.Equal(model?.FirstOrDefault()?.ProjectVersion, projectVersion);
            Assert.Equal(model?.FirstOrDefault()?.ProjectId, projectId);
        }

        [Fact]
        public void Model_ProjectDtoTest_Error()
        {
            var projectId = 0;

            IEnumerable<ProjectDto> model = new List<ProjectDto>
            {
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = projectId
                },
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = 2
                },
                new ProjectDto()
                {
                    ProjectDescription = projectDesc,
                    ProjectName = projectName,
                    ProjectType = projectType,
                    ProjectVersion = projectVersion,
                    ProjectId = 3
                }
            };

            try
            {
                Assert.NotNull(model);
                Assert.Equal(model?.FirstOrDefault()?.ProjectId, projectId);
            }
            catch (Exception ex)
            {
                Assert.Equal("xunit.assert", ex.Source);
            }
        }
    }
}
