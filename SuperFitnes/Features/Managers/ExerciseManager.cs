using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
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
        public void Create(PhysicalMetrics PhysicalMetrics)
        {

            _dataContext.PhysicalMetricss.Add(PhysicalMetrics);
            _dataContext.SaveChanges();

            //return PhysicalMetrics.IsnNode;
        }
    }
}
