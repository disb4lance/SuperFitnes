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
    public interface IExerciseService
    {
        IQueryable<Exercise> GetUserQueryable(DataContext context, ExerceseFilter filter, bool asNoTracking = true);
    }
}
