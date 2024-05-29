using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using SuperFitnes.Features.DtoModels.Exercise;
using SuperFitnes.Features.DtoModels.Train;
using SuperFitnes.Features.Interfaces;

namespace SuperFitnes.Features.Managers
{
    public class ExerciseManager : IExerciseManager
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _ExerciseRepository;
        private readonly IExerciseService _ExerciseService;
        private readonly DataContext _dataContext;


        public ExerciseManager(IMapper mapper, IExerciseRepository ExerciseRepository, IExerciseService ExerciseService, DataContext dataContext)
        {
            _mapper = mapper;
            _ExerciseRepository = ExerciseRepository;
            _ExerciseService = ExerciseService;
            _dataContext = dataContext;
        }
        public Guid Create(EditExercise exercise)
        {
            var user = new Exercise
            {
                IsnNode = exercise.IsnNode == Guid.Empty ? Guid.NewGuid() : exercise.IsnNode,
                Name = exercise.Name,
                Type = exercise.Type,
                TrainingId = exercise.TrainingId

            };
            _ExerciseRepository.Create(_dataContext, user);
            _dataContext.SaveChanges();

            return exercise.IsnNode;
        }
        public async Task<int> GetStrengthExerciseCountForLastMonth(Guid userId)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            return await _dataContext.Exercises
                .Where(e => _dataContext.Trains
                    .Where(t => t.UserId == userId && t.IsnNode == e.TrainingId && t.DateTime >= oneMonthAgo)
                    .Any() && e.Type == "Strength")
                .CountAsync();
        }

        public async Task<int> GetCardioExerciseCountForLastMonth(Guid userId)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            return await _dataContext.Exercises
                .Where(e => _dataContext.Trains
                    .Where(t => t.UserId == userId && t.IsnNode == e.TrainingId && t.DateTime >= oneMonthAgo)
                    .Any() && e.Type == "Cardio")
                .CountAsync();
        }
    }
}
