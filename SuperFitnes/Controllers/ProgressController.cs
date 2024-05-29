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
            /// Получаем количество тренировок за последний месяц
            int trainingsCount = _trainMetricsManager.GetTrainingsCountForLastMonth(id);
            // Получаем количество силовых и кардио упражнений за последний месяц
            int strengthExercisesCount = await _exerciseManager.GetStrengthExerciseCountForLastMonth(id);
            int cardioExercisesCount = await _exerciseManager.GetCardioExerciseCountForLastMonth(id);

            // Получаем первое и последнее измерение веса и обхвата тела пользователя
            var firstPhysicalMetrics = await _physicalMetricsManager.GetFirstPhysicalMetrics(id);
            var lastPhysicalMetrics = await _physicalMetricsManager.GetLastPhysicalMetrics(id);

            // Проверяем, что получены значения
            if (firstPhysicalMetrics != null && lastPhysicalMetrics != null)
            {
                // Вычисляем изменение в весе и обхвате тела
                double weightChange = lastPhysicalMetrics.Weight - firstPhysicalMetrics.Weight;
                double bodyMeasurementsChange = lastPhysicalMetrics.BodyMeasurements - firstPhysicalMetrics.BodyMeasurements;

                // Передаем данные в представление
                ViewBag.WeightChange = weightChange;
                ViewBag.BodyMeasurementsChange = bodyMeasurementsChange;
            }
            else
            {
                // Если данные отсутствуют, передаем пустые значения в представление
                ViewBag.WeightChange = 0;
                ViewBag.BodyMeasurementsChange = 0;
            }

            // Передаем данные о тренировках и упражнениях в представление
            ViewBag.TrainingsCount = trainingsCount;
            ViewBag.StrengthExercisesCount = strengthExercisesCount;
            ViewBag.CardioExercisesCount = cardioExercisesCount;

            return View();
        }

    }
}
