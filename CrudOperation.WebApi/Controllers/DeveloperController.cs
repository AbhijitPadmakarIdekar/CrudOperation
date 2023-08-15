using CrudOperation.Domain.Entities;
using CrudOperation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger _logger;

        public DeveloperController(IUnitOfWork unitOfWork, ILogger<DeveloperController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("GetAllDevelopers")]
        public async Task<ActionResult> GetAllDevelopers()
        {
            var actorsFromRepo = await _unitOfWork.Developer?.GetAll();
            _logger.LogInformation("The GetAllDevelopers method called.");
            return Ok(actorsFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeveloperAndProject()
        {
            var developer = new Developer
            {
                Followers = 35,
                DeveloperName = "Aslam Shaikh"
            };
            var project = new Project
            {
                ProjectName = "AslamNazeerShaikh"
            };
            await _unitOfWork.Developer.Add(developer);
            await _unitOfWork.Project?.Add(project);
            await _unitOfWork.SavaAsync();
            return Ok();
        }
    }
}