using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.DtoModels.Filters;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using SuperFitnes.Features.DtoModels.User;
using SuperFitnes.Features.Interfaces;
using System.Data;
using System.Security.Principal;

namespace SuperFitnes.Features.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;
        private readonly ITrainManager _trainManager;

        public UserManager(IMapper mapper, IUserRepository userRepository, IUserService userServies, DataContext dataContext, ITrainManager trainManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userServies;
            _dataContext = dataContext;
            _trainManager = trainManager;
        }
        public Guid Create(EditUser User)
        {
            var user = new User
            {
                IsnNode = User.IsnNode,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Password = User.Password

            };
            _userRepository.Create(_dataContext, user);
            _dataContext.SaveChanges();

            return user.IsnNode;
        }

        public User FindByFirstName(string firstName, string password)
        {
            // Используйте LINQ запрос для поиска пользователя по FirstName
            var a = _dataContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.Password == password);

            return a;
        }
        public User FindByIsnNode(Guid id)
        {
            // Используйте LINQ запрос для поиска пользователя по FirstName
            var a = _dataContext.Users.FirstOrDefault(u => u.IsnNode == id);
            return a;
        }

        public Guid GetIsnNode(Guid id)
        {
            var a = _dataContext.Users.FirstOrDefault(u => u.IsnNode == _trainManager.GetUserId(id));
            return a?.IsnNode ?? Guid.Empty;
        }

        //public void Update(EditUser updateCenter)
        //{
        //    var center = _mapper.Map<User>(updateCenter);
        //    _userRepository.Update(_dataContext, center);
        //    _dataContext.SaveChanges();

        //}
        //public void Delete(Guid isnNode)
        //{
        //    _userRepository.Delete(_dataContext, isnNode);
        //}

        //public UserDto GetCenter(Guid isnNode)
        //{
        //    var center = _userRepository.GetById(_dataContext, isnNode);
        //    return _mapper.Map<UserDto>(center);
        //}
        //public UserDto[] GetListCenters(UserFilterDto centerFilter)
        //{
        //    var center = _userService.GetUserQueryable(_dataContext, centerFilter, true).Select(x => new UserDto
        //    {
        //        IsnNode = x.IsnNode,
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //    }).ToArray();
        //    return center;
        //}
    }
}
