using Classes.Database;
using Classes.models;
using Logic.DtoModels.Filters;
using Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class PhysicalMetricsService : IPhysicalMetricsService
    {
        public IQueryable<PhysicalMetrics> GetUserQueryable(DataContext context, PhysicalMetricsFilterDto filter, bool asNoTracking = true)
        {
            IQueryable<PhysicalMetrics> query = context.PhysicalMetricss;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
