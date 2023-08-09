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
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllDevelopers")]
        public async Task<ActionResult> GetAllDevelopers()
        {
            var actorsFromRepo = await _unitOfWork.Developer?.GetAll();
            return Ok(actorsFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeveloperAndProject()
        {
            var developer = new Developer
            {
                Followers = 35,
                Name = "Aslam Shaikh"
            };
            var project = new Project
            {
                Name = "AslamNazeerShaikh"
            };
            await _unitOfWork.Developer.Add(developer);
            await _unitOfWork.Project?.Add(project);
            await _unitOfWork.SavaAsync();
            return Ok();
        }
    }
}