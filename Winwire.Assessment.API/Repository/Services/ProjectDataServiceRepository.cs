using Microsoft.EntityFrameworkCore;
using Winwire.Assessment.API.Data.Db;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Models.Entities;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.API.Repository.Services
{
    /// <summary>
    /// Service class to implement business logic for project
    /// </summary>
    public class ProjectDataServiceRepository : IProjectDataServiceRepository
    {
        private AssessmentDbContext _context;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProjectDataServiceRepository(AssessmentDbContext context)
        {
            _context = context;
        }

        #region CRUD Methods

        /// <summary>
        /// Create new project
        /// </summary>
        /// <param name="requestDto">Object of Dto class : AddProjectDto</param>
        /// <returns>Returns newly created record</returns>
        public async Task<ProjectDto> CreateAsync(AddProjectDto requestDto)
        {
            var projectDto = new ProjectDto() { ProjectId = 0 };

            if (requestDto != null && requestDto.ProjectName != string.Empty)
            {
                var projectEntity = new ProjectEntity();

                projectEntity.ProjectDescription = requestDto.ProjectDescription;
                projectEntity.ProjectName = requestDto.ProjectName;
                projectEntity.ProjectVersion = requestDto.ProjectVersion;
                projectEntity.ProjectType = requestDto.ProjectType;

                await _context.Projects.AddAsync(projectEntity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    projectDto = await ProjectDtoAsync(projectEntity);
                }
            }
            return projectDto;
        }

        /// <summary>
        /// Get project data by id
        /// </summary>
        /// <param name="id">integer value to find project detail</param>
        /// <returns>Return project detail</returns>
        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var projectDto = new ProjectDto();

            var project = await GetProjectById(id);
            if (project != null)
            {
                projectDto = await ProjectDtoAsync(project);
            }
            return projectDto;
        }

        /// <summary>
        /// Get all project listing
        /// </summary>
        /// <returns>Returns list of projects</returns>
        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projectList = await _context.Projects.OrderByDescending(x => x.ProjectId).ToListAsync();
            //.Result.SelectMany(project => project).ToList()
            //{
            //    ProjectDescription = project.ProjectDescription,
            //    ProjectName = project.ProjectName,
            //    ProjectVersion = project.ProjectVersion,
            //    ProjectId = project.ProjectId,
            //    ProjectType = project.ProjectType
            //})


            //                         { new ProjectDto() {
            //                         ProjectDescription = project.ProjectDescription,
            //    ProjectName = project.ProjectName,
            //    ProjectVersion = project.ProjectVersion,
            //    ProjectId = project.ProjectId,
            //    ProjectType = project.ProjectType
            //} });

            //var projects = projectList.SelectMany(project => new ProjectDto() {
            //    ProjectDescription = project.ProjectDescription,
            //    ProjectName = project.ProjectName,
            //    ProjectVersion = project.ProjectVersion,
            //    ProjectId = project.ProjectId,
            //    ProjectType = project.ProjectType
            //});

            var projects = new List<ProjectDto>();
            foreach (var project in projectList)
            {
                var projectDto = new ProjectDto();

                projectDto = await ProjectDtoAsync(project);
                projects.Add(projectDto);
            }
            return projects;
        }

        /// <summary>
        /// Update existing record by Id
        /// </summary>
        /// <param name="requestDto">Object of Dto class : EditProjectDto </param>
        /// <returns>Returns update record</returns>
        public async Task<ProjectDto> UpdateAsync(EditProjectDto requestDto)
        {
            var projectDto = new ProjectDto();

            if (requestDto != null && requestDto.Id > 0)
            {
                var exitingRecord = await GetProjectById(requestDto.Id);

                if (exitingRecord != null)
                {
                    exitingRecord.ProjectDescription = requestDto.ProjectDescription;
                    exitingRecord.ProjectName = requestDto.ProjectName;
                    exitingRecord.ProjectVersion = requestDto.ProjectVersion;
                    exitingRecord.ProjectType = requestDto.ProjectType;

                    _context.Projects.Update(exitingRecord);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                        projectDto = await ProjectDtoAsync(exitingRecord);
                }
                else
                {
                    projectDto.ProjectId = 0;
                }
            }
            else
            {
                projectDto.ProjectId = 0;
            }
            return projectDto;
        }

        /// <summary>
        /// Delete the record by id
        /// </summary>
        /// <param name="Id">integer number to delete record</param>
        /// <returns>Returns 1 for success</returns>
        public async Task<int> DeleteAsync(int id)
        {
            var project = await GetProjectById(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                return _context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Private / ADHOC methods

        /// <summary>
        /// Get project detail by Id
        /// </summary>
        /// <param name="id">Id to fetch data for that id</param>
        /// <returns></returns>
        private async Task<ProjectEntity?> GetProjectById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
        }

        /// <summary>
        /// Dto for returning data to controller from entity
        /// </summary>
        /// <param name="project">Model object of ProjectEntity </param>
        /// <returns></returns>
        private async Task<ProjectDto> ProjectDtoAsync(ProjectEntity project)
        {
            var projectDto = new ProjectDto();

            await Task.Run(() =>
            {
                projectDto.ProjectDescription = project.ProjectDescription;
                projectDto.ProjectName = project.ProjectName;
                projectDto.ProjectVersion = project.ProjectVersion;
                projectDto.ProjectId = project.ProjectId;
                projectDto.ProjectType = project.ProjectType;
            });
            return projectDto;
        }

        #endregion
    }
}
