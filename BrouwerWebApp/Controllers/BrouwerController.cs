using System.Collections.Generic;
using System.Threading.Tasks;
using BrouwerService.Repositories;
using BrouwerWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BrouwerWebApp.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase
    {
        private readonly IBrouwerRepository repository;
        public BrouwerController(IBrouwerRepository repository) =>
        this.repository = repository;
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var brouwer = await repository.FindByIdAsync(id);
            if (brouwer == null)
            {
                return base.NotFound();
            }
            return base.Ok(brouwer);
        }
    }
}