namespace Winwire.Assessment.API.Models.Dto
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string ProjectDescription { get; set; } = string.Empty;

        public string ProjectVersion { get; set; } = string.Empty;

        public string ProjectType { get; set; } = string.Empty;
    }
}
