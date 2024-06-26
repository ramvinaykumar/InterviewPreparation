using Winwire.Assessment.API.Models.Dto;

namespace Winwire.Assessment.API.Repository.Interface
{
    public interface IProjectDataService
    {
        public Task<IEnumerable<ProjectDto>> GetProjectsAsync();

        public Task<ProjectDto> GetProjectByIdAsync(int Id);

        public Task<int> AddProjectAsync(AddProject requestDto);
    }
}
