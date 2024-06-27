using Winwire.Assessment.API.Models.Dto;

namespace Winwire.Assessment.Tests.Models
{
    public class EditProjectDtoTest
    {
        string projectName = "Test 1";
        string projectDesc = "Test Desc";
        int projectId = 1;
        string projectType = "UI";
        string projectVersion = "1.0.9";

        [Fact]
        public void Model_EditProjectDtoTest_Success()
        {
            var model = new EditProjectDto()
            {
                ProjectDescription = projectDesc,
                ProjectName = projectName,
                ProjectType = projectType,
                ProjectVersion = projectVersion,
                Id = 1
            };

            Assert.NotNull(model);
            Assert.Equal(model.ProjectName, projectName);
            Assert.Equal(model.ProjectVersion, projectVersion);
            Assert.Equal(model.Id, projectId);
        }

        [Fact]
        public void Model_EditProjectDtoTest_Error()
        {
            var projectId = 0;

            var model = new EditProjectDto()
            {
                ProjectDescription = projectDesc,
                ProjectName = projectName,
                ProjectType = projectType,
                ProjectVersion = projectVersion,
                Id = 1
            };

            try
            {
                Assert.NotNull(model);
                Assert.Equal(model.Id, projectId);
            }
            catch (Exception ex)
            {
                Assert.Equal("xunit.assert", ex.Source);
            }
        }
    }
}
