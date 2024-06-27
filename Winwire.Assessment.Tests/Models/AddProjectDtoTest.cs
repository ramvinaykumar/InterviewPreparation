using Winwire.Assessment.API.Models.Dto;

namespace Winwire.Assessment.Tests.Models
{
    public class AddProjectDtoTest
    {
        string projectName = "Test 1";
        string projectDesc = "Test Desc";
        string projectType = "UI";
        string projectVersion = "1.0.9";

        [Fact]
        public void Model_AddProjectDtoTest_Success()
        {
            var model = new AddProjectDto()
            {
                ProjectDescription = projectDesc,
                ProjectName = projectName,
                ProjectType = projectType,
                ProjectVersion = projectVersion,
            };

            Assert.NotNull(model);
            Assert.Equal(model.ProjectName, projectName);
            Assert.Equal(model.ProjectVersion, projectVersion);
        }

        [Fact]
        public void Model_AddProjectDtoTest_Error()
        {
            var projectNameBlank = string.Empty;

            var model = new AddProjectDto()
            {
                ProjectDescription = projectDesc,
                ProjectName = projectName,
                ProjectType = projectType,
                ProjectVersion = projectVersion,
            };

            try
            {
                Assert.NotNull(model);
                Assert.Equal(model.ProjectName, projectNameBlank);
            }
            catch (Exception ex)
            {
                Assert.Equal("xunit.assert", ex.Source);
            }
        }
    }
}
