using Microsoft.AspNetCore.Mvc;
using SuperFitnes.Features.Interfaces;

namespace SuperFitnes.Controllers
{
    [Route("Progress")]
    public class ProgressController : Controller
    {
        private readonly ITrainManager _trainMetricsManager;
        private readonly IUserManager _userManager;
        private readonly IExerciseManager _exerciseManager;
        private readonly IPhysicalMetricsManager _physicalMetricsManager;
        public ProgressController(ITrainManager trainMetricsManager, IUserManager userManager, IExerciseManager exerciseManager, IPhysicalMetricsManager physicalMetricsManager)
        {
            this._trainMetricsManager = trainMetricsManager;
            this._userManager = userManager;
            this._exerciseManager = exerciseManager;
            this._physicalMetricsManager = physicalMetricsManager;
        }

        [HttpGet, Route("ProgressView")]
        public async Task<ActionResult> ProgressView(Guid id)
        {
            // Получаем количество тренировок за последний месяц
            int trainingsCount = _trainMetricsManager.GetTrainingsCountForLastMonth(id);
            // Получаем количество силовых и кардио упражнений за последний месяц
            int strengthExercisesCount = await _exerciseManager.GetStrengthExerciseCountForLastMonth(id);
            int cardioExercisesCount = await _exerciseManager.GetCardioExerciseCountForLastMonth(id);

            // Передаем данные в представление
            ViewBag.StrengthExercisesCount = strengthExercisesCount;
            ViewBag.CardioExercisesCount = cardioExercisesCount;

            // Передаем данные в представление
            ViewBag.TrainingsCount = trainingsCount;

            return View();
        }

    }
}
