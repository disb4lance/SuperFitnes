using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.Interfaces;
using System.Data;

namespace SuperFitnes.Features.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;
        public Guid Create(EditUser User)
        {
            var user = new User
            {
                IsnNode = User.IsnNode,
                FirstName = User.FirstName,
                LastName = User.LastName

            };
            _userRepository.Create(_dataContext, user);
            _dataContext.SaveChanges();

            return user.IsnNode;
        }
    }
}
