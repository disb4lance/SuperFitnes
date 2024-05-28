using Classes.models;
using Microsoft.AspNetCore.Mvc;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;
using SuperFitnes.Features.Interfaces;

namespace SuperFitnes.Controllers
{
    [Route("Train")]
    public class TrainController : Controller
    {
        private readonly ITrainManager _trainMetricsManager;
        private readonly IUserManager _userManager;


        public TrainController(ITrainManager physicalMetricsManager, IUserManager userManager)
        {
            this._trainMetricsManager = physicalMetricsManager;
            this._userManager = userManager;
        }


        [HttpGet, Route("AddTrain")]
        public async Task<ActionResult> Add(Guid id)
        {
            var editPhysicalMetrics = new EditPhysicalMetrics { UserId = id };
            return View(editPhysicalMetrics);
        }

        [HttpPost(nameof(CreateAdd), Name = "CreateAdd")]
        public async Task<ActionResult> CreateAdd(EditPhysicalMetrics model)
        {
            if (ModelState.IsValid)
            {
                var newPhysicalMetrics = new PhysicalMetrics
                {
                    //IsnNode = model.IsnNode == Guid.Empty ? Guid.NewGuid() : model.IsnNode,
                    Weight = model.Weight,
                    BodyMeasurements = model.BodyMeasurements,
                    UserId = model.UserId,
                    Date = DateTime.Now,
                };
                // Сохранение физических показателей
                //_physicalMetricsManager.Create(newPhysicalMetrics);


                return RedirectToAction("Index", "Main"); // Перенаправление на главную страницу
            }
            return View(model);
        }
    }
}
