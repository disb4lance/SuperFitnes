using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class PhysicalMetricsRepository : IPhysicalMetricsRepository
    {
        public PhysicalMetrics Create(DataContext dataContext, PhysicalMetrics physicalMetrics)
        {
            physicalMetrics.IsnNode = Guid.NewGuid();
            dataContext.PhysicalMetricss.Add(physicalMetrics);
            return physicalMetrics;

        }
    }
}
