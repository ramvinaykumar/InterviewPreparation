using Microsoft.EntityFrameworkCore;
using Winwire.Assessment.API.Data.Db;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Models.Entities;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.API.Repository.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private AssessmentDbContext _context;

        public ProjectDataService(AssessmentDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddProjectAsync(AddProject requestDto)
        {
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.ProjectDescription = requestDto.ProjectDescription;
            projectEntity.ProjectName = requestDto.ProjectName;
            projectEntity.ProjectVersion = requestDto.ProjectVersion;
            projectEntity.ProjectType = requestDto.ProjectType;

            await _context.Projects.AddAsync(projectEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProjectDto> GetProjectByIdAsync(int id)
        {
            ProjectDto projectDto = new ProjectDto();

            var project = await _context.Projects.Where(x => x.ProjectId == id).FirstOrDefaultAsync();
            if (project != null)
            {
                projectDto.ProjectDescription = project.ProjectDescription;
                projectDto.ProjectName = project.ProjectName;
                projectDto.ProjectVersion = project.ProjectVersion;
                projectDto.ProjectId = project.ProjectId;
                projectDto.ProjectType = project.ProjectType;
            }
            return projectDto;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            var projectList = await _context.Projects.OrderByDescending(x => x.ProjectId).ToListAsync();

            List<ProjectDto> projects = new List<ProjectDto>();
            foreach (var project in projectList)
            {
                ProjectDto projectDto = new ProjectDto();

                projectDto.ProjectDescription = project.ProjectDescription;
                projectDto.ProjectName = project.ProjectName;
                projectDto.ProjectVersion = project.ProjectVersion;
                projectDto.ProjectId = project.ProjectId;
                projectDto.ProjectType = project.ProjectType;
                projects.Add(projectDto);
            }
            return projects;
        }
    }
}
