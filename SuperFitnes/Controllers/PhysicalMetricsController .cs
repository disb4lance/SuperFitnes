using Classes.Database;
using Classes.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.Interfaces;
using SuperFitnes.Features.Managers;

[Route("PhysicalMetrics")]
public class PhysicalMetricsController : Controller
{
    private readonly IPhysicalMetricsManager _physicalMetricsManager;
    private readonly IUserManager _userManager;


    public PhysicalMetricsController(IPhysicalMetricsManager physicalMetricsManager, IUserManager userManager)
    {
        this._physicalMetricsManager = physicalMetricsManager;
        this._userManager = userManager;
    }


    [HttpGet, Route("Add")]
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
            _physicalMetricsManager.Create(newPhysicalMetrics);


            return RedirectToAction("Index", "Main"); // Перенаправление на главную страницу
        }
        return View(model);
    }


}