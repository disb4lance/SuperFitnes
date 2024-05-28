using System.ComponentModel.DataAnnotations;

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
    }
}
