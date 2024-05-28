using Classes.Database;
using Classes.models;
using Logic.DtoModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Services
{
    public interface ITrainService
    {
        IQueryable<Train> GetUserQueryable(DataContext context, TrainFilter filter, bool asNoTracking = true);
    }
}
