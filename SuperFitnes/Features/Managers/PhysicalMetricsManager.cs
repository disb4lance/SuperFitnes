using AutoMapper;
using Classes.Database;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;
using Classes.models;
using Microsoft.EntityFrameworkCore;
using SuperFitnes.Features.Interfaces;

namespace SuperFitnes.Features.Managers
{
    public class PhysicalMetricsManager : IPhysicalMetricsManager
    {
        private readonly IMapper _mapper;
        private readonly IPhysicalMetricsRepository _PhysicalMetricsRepository;
        private readonly IPhysicalMetricsService _PhysicalMetricsService;
        private readonly DataContext _dataContext;


        public PhysicalMetricsManager(IMapper mapper, IPhysicalMetricsRepository PhysicalMetricsRepository, IPhysicalMetricsService PhysicalMetricsService, DataContext dataContext)
        {
            _mapper = mapper;
            _PhysicalMetricsRepository = PhysicalMetricsRepository;
            _PhysicalMetricsService = PhysicalMetricsService;
            _dataContext = dataContext;
        }
        public Guid Create(EditPhysicalMetrics PhysicalMetrics)
        {
            var newPhysicalMetrics = new PhysicalMetrics
            {
                IsnNode = PhysicalMetrics.IsnNode == Guid.Empty ? Guid.NewGuid() : PhysicalMetrics.IsnNode,
                Weight = PhysicalMetrics.Weight,
                BodyMeasurements = PhysicalMetrics.BodyMeasurements,
            };

            _dataContext.PhysicalMetricss.Add(newPhysicalMetrics);
            _dataContext.SaveChanges();

            return newPhysicalMetrics.IsnNode;
        }
    }
}
