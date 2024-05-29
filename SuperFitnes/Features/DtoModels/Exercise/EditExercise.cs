using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SuperFitnes.Features.DtoModels.Exercise
{
    public class EditExercise
    {
        public Guid IsnNode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }

        // Внешний ключ для тренировки
        public Guid TrainingId { get; set; }
        public static List<SelectListItem> GetExerciseTypes()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Strength", Text = "Силовое" },
            new SelectListItem { Value = "Cardio", Text = "Кардио" }
        };
        }
    }
}
