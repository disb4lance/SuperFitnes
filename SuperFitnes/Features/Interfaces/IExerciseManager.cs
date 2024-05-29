using SuperFitnes.Features.DtoModels.Exercise;

namespace SuperFitnes.Features.Interfaces
{
    public interface IExerciseManager
    {
        Guid Create(EditExercise exercise);
        Task<int> GetStrengthExerciseCountForLastMonth(Guid userId);
        Task<int> GetCardioExerciseCountForLastMonth(Guid userId);
    }
}
