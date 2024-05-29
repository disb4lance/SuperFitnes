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
    public class TrainRepository : ITrainRepository
    {
        public Train Create(DataContext dataContext, Train train)
        {
            //train.IsnNode = Guid.NewGuid();
            dataContext.Trains.Add(train);
            return train;

        }
    }
}
