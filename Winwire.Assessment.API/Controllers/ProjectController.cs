using Microsoft.AspNetCore.Mvc;
using Winwire.Assessment.API.Models.Dto;
using Winwire.Assessment.API.Repository.Interface;

namespace Winwire.Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectDataServiceRepository _projectDataService;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="projectDataService">Object of IProjectDataServiceRepository interface</param>
        public ProjectController(IProjectDataServiceRepository projectDataService)
        {
            _projectDataService = projectDataService;
        }

        #region End Points

        /// <summary>
        /// Get all project listing
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projectDataService.GetAllAsync();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Get project data by id
        /// </summary>
        /// <param name="id">integer value to find project detail</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectDataService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Create new project
        /// </summary>
        /// <param name="requestDto">Object of Dto class : AddProjectDto </param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProject(AddProjectDto requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest();
            }
            await _projectDataService.CreateAsync(requestDto);
            return Ok(new { message = "Project created successfully!" });
        }

        /// <summary>
        /// Update existing record by Id
        /// </summary>
        /// <param name="requestDto">Object of Dto class : EditProjectDto </param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProject(EditProjectDto requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest();
            }
            await _projectDataService.UpdateAsync(requestDto);
            return Ok(new { message = "Project updated successfully!" });
        }

        /// <summary>
        /// Delete project by id
        /// </summary>
        /// <param name="id">integer number to delete the project</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectDataService.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        #endregion
    }
}
