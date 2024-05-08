using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(DataContext dataContext, User user)
        {
            user.IsnNode = Guid.NewGuid();
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return user;

        }

        public User Update(DataContext dataContext, User user)
        {
            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == user.IsnNode)
            ?? throw new Exception($"User с индификатором {user.IsnNode} не найден");

            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;

            return userDb;
        }

        public void Delete(DataContext dataContext, Guid IsNode)
        {
            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == IsNode)
            ?? throw new Exception($"User с индификатором {IsNode} не найден");

            dataContext.Users.Remove(userDb);
        }

        public User GetById(DataContext dataContext, Guid IsnNode)
        {
            var userDb = dataContext.Users.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"User с индификатором {IsnNode} не найден");

            return userDb;
        }
    }
}
