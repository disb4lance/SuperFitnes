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
    public class UserService : IUserService
    {
        public IQueryable<User> GetUserQueryable(DataContext context, UserFilterDto filter, bool asNoTracking = true)
        {
            IQueryable<User> query = context.Users;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
