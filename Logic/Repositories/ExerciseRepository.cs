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
    public class ExerciseRepository : IExerciseRepository
    {
        public Exercise Create(DataContext dataContext, Exercise exercise)
        {
            exercise.IsnNode = Guid.NewGuid();
            dataContext.Exercises.Add(exercise);
            return exercise;

        }
    }
}
