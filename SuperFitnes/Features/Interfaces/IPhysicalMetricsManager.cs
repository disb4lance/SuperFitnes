using Classes.models;
using SuperFitnes.Features.DtoModels.PhysicalMetrics;

namespace SuperFitnes.Features.Interfaces
{
    public interface IPhysicalMetricsManager
    {
        void Create(PhysicalMetrics PhysicalMetrics);
        Task<PhysicalMetrics> GetLastPhysicalMetrics(Guid userId);
        Task<PhysicalMetrics> GetFirstPhysicalMetrics(Guid userId);
    }
}
