using Classes.Database;
using Classes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Repositories
{
    public interface ITrainRepository
    {
        Train Create(DataContext dataContext, Train train);
    }
}
