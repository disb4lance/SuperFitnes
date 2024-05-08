using Classes.Database;
using Classes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(DataContext dataContext, User user);
        User Update(DataContext dataContext, User user);
        void Delete(DataContext dataContext, Guid IsNode);
        User GetById(DataContext dataContext, Guid IsnNode);
    }
}
