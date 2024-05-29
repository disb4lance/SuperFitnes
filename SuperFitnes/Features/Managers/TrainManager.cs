using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using SuperFitnes.Features.DtoModels.Train;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.Interfaces;

namespace SuperFitnes.Features.Managers
{
    public class TrainManager : ITrainManager
    {
        private readonly IMapper _mapper;
        private readonly ITrainRepository _trainRepository;
        private readonly ITrainService _trainService;
        private readonly DataContext _dataContext;


        public TrainManager(IMapper mapper, ITrainRepository trainRepository, ITrainService trainService, DataContext dataContext)
        {
            _mapper = mapper;
            _trainRepository = trainRepository;
            _trainService = trainService;
            _dataContext = dataContext;
        }
        public Guid Create(EditTrain train)
        {
            var user = new Train
            {
                IsnNode = train.IsnNode,
                DateTime = train.DateTime,
                UserId = train.UserId

            };
            _trainRepository.Create(_dataContext, user);
            _dataContext.SaveChanges();

            return train.IsnNode;
        }
        public int GetTrainingsCountForLastMonth(Guid userId)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            return _dataContext.Trains
                .Where(t => t.UserId == userId && t.DateTime >= oneMonthAgo)
                .Count();
        }

    }
}
