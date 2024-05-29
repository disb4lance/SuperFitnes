using Classes.models;
using Microsoft.AspNetCore.Mvc;
using SuperFitnes.Features.DtoModels.Exercise;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;
using SuperFitnes.Features.DtoModels.Train;
using SuperFitnes.Features.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperFitnes.Controllers
{
    [Route("Train")]
    public class TrainController : Controller
    {
        private readonly ITrainManager _trainMetricsManager;
        private readonly IUserManager _userManager;
        private readonly IExerciseManager _exerciseManager;



        public TrainController(ITrainManager physicalMetricsManager, IUserManager userManager, IExerciseManager exerciseManager)
        {
            this._trainMetricsManager = physicalMetricsManager;
            this._userManager = userManager;
            this._exerciseManager = exerciseManager;
        }


        [HttpGet, Route("AddTrain")]
        public async Task<ActionResult> AddTrain(Guid id, bool createNewTrain = true)
        {
            EditExercise editexercise;
            if (createNewTrain)
            {
                EditTrain newTrain = new EditTrain
                {
                    IsnNode = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    UserId = id,
                };
                _trainMetricsManager.Create(newTrain);

                editexercise = new EditExercise { TrainingId = newTrain.IsnNode };
            }
            else
            {
                editexercise = new EditExercise { TrainingId = id };
            }
            ViewBag.ExerciseTypes = new SelectList(EditExercise.GetExerciseTypes(), "Value", "Text");
            return View(editexercise);
        }

        // Метод для обработки формы
        [HttpPost(nameof(CreateTrain), Name = "CreateTrain")]
        public async Task<ActionResult> CreateTrain(EditExercise model, string action)
        {
            if (ModelState.IsValid)
            {
                var newExtencion = new EditExercise
                {
                    Name = model.Name,
                    Type = model.Type,
                    TrainingId = model.TrainingId,
                };
                _exerciseManager.Create(newExtencion);

                if (action == "continue")
                {

                    return RedirectToAction("Index", "Main", new { id = _userManager.GetIsnNode(newExtencion.TrainingId) }); // Перенаправление на главную страницу
                }
                else if (action == "addExercise")
                {
                    // Передаем createNewTrain = false, чтобы не создавать новый EditTrain при редиректе
                    return RedirectToAction("AddTrain", "Train", new { id = newExtencion.TrainingId, createNewTrain = false });
                }
            }
            ViewBag.ExerciseTypes = new SelectList(EditExercise.GetExerciseTypes(), "Value", "Text");
            return View(model);
        }
    }
}
