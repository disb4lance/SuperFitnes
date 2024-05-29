using AutoMapper;
using Classes.Database;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using SuperFitnes.Features.DtoModels.Train;

namespace SuperFitnes.Features.Interfaces
{
    public interface ITrainManager
    {
        int GetTrainingsCountForLastMonth(Guid userId);
        Guid Create(EditTrain train);
    }
}
