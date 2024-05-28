namespace SuperFitnes.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SuperFitnes.Features.DtoModels.UserIdModel;

    [Route("Main")]
    public class MainController : Controller
    {
        public MainController() { 

        }

        [HttpGet, Route("Index")]
        public async Task<ActionResult> Index(Guid id)
        {
            var viewModel = new IdCurrentUser
            {
                Id = id
            };
            return View(viewModel);
        }
    }
}
