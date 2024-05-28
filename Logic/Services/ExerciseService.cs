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
    public class ExerciseService : IExerciseService
    {
        public IQueryable<Exercise> GetUserQueryable(DataContext context, ExerceseFilter filter, bool asNoTracking = true)
        {
            IQueryable<Exercise> query = context.Exercises;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
