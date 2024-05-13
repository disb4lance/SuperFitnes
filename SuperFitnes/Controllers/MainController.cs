namespace SuperFitnes.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("Main")]
    public class MainController : Controller
    {
        public MainController() { 

        }

        [HttpGet, Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
