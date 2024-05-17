using SuperFitnes.Features.DtoModels.PhysicalMetrics;

namespace SuperFitnes.Features.Interfaces
{
    public interface IPhysicalMetricsManager
    {
        Guid Create(EditPhysicalMetrics PhysicalMetrics);
    }
}
