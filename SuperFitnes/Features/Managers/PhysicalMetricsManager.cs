using AutoMapper;
using Classes.Database;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;
using Classes.models;
using Microsoft.EntityFrameworkCore;
using SuperFitnes.Features.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public void Create(PhysicalMetrics PhysicalMetrics)
        {

            _dataContext.PhysicalMetricss.Add(PhysicalMetrics);
            _dataContext.SaveChanges();

            //return PhysicalMetrics.IsnNode;
        }
    }
}
