using Winwire.Assessment.API.Models.Dto;

namespace Winwire.Assessment.API.Repository.Interface
{
    /// <summary>
    /// Interface for Project service
    /// </summary>
    public interface IProjectDataServiceRepository
    {
        /// <summary>
        /// Get all project listing
        /// </summary>
        /// <returns>Returns list of projects</returns>
        public Task<IEnumerable<ProjectDto>> GetAllAsync();

        /// <summary>
        /// Get project data by id
        /// </summary>
        /// <param name="id">integer value to find project detail</param>
        /// <returns>Return project detail</returns>
        public Task<ProjectDto> GetByIdAsync(int Id);

        /// <summary>
        /// Create new project
        /// </summary>
        /// <param name="requestDto">Object of Dto class : AddProjectDto</param>
        /// <returns>Returns newly created record</returns>
        public Task<ProjectDto> CreateAsync(AddProjectDto requestDto);

        /// <summary>
        /// Update existing record by Id
        /// </summary>
        /// <param name="requestDto">Object of Dto class : EditProjectDto </param>
        /// <returns>Returns update record</returns>
        public Task<ProjectDto> UpdateAsync(EditProjectDto requestDto);

        /// <summary>
        /// Delete the record by id
        /// </summary>
        /// <param name="Id">integer number to delete record</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(int Id);
    }
}
