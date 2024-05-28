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
    public class TrainService : ITrainService
    {
        public IQueryable<Train> GetUserQueryable(DataContext context, TrainFilter filter, bool asNoTracking = true)
        {
            IQueryable<Train> query = context.Trains;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
