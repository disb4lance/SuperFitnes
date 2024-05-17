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

    public PhysicalMetricsController(IPhysicalMetricsManager physicalMetricsManager)
    {
        this._physicalMetricsManager = _physicalMetricsManager;
    }


    [HttpGet, Route("Add")]
    public async Task<ActionResult> Add()
    {
        return View();
    }

    [HttpPost(nameof(CreateAdd), Name = "CreateAdd")]
    public async Task<ActionResult> CreateAdd(EditPhysicalMetrics model)
    {
        if (ModelState.IsValid)
        {

            // Добавление пользователя в контекст данных и сохранение его в базе данных
            _physicalMetricsManager.Create(model);

            // Пример редиректа на главную страницу после регистрации
            return RedirectToAction("Index", "Main");
        }

        // Если валидация модели не удалась, вернуть представление с ошибками
        return View(nameof(Add), model);
    }

}