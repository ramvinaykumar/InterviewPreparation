using Microsoft.AspNetCore.Mvc;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectDataService _projectDataService;

        public ProjectController(IProjectDataService projectDataService)
        {
            _projectDataService = projectDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projectDataService.GetProjectsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectDataService.GetProjectByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(AddProject addProject)
        {
            await _projectDataService.AddProjectAsync(addProject);
            return Ok(new { message = "Project created successfully!" });
        }
    }
}
