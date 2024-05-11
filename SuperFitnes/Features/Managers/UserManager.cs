﻿using AutoMapper;
using Classes.Database;
using Classes.models;
using Logic.DtoModels.Filters;
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


        public UserManager(IMapper mapper, IUserRepository centerRepository, IUserService centerServies, DataContext dataContext)
        {
            _mapper = mapper;
            _userRepository = centerRepository;
            _userService = centerServies;
            _dataContext = dataContext;
        }
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

        public void Update(EditUser updateCenter)
        {
            var center = _mapper.Map<User>(updateCenter);
            _userRepository.Update(_dataContext, center);
            _dataContext.SaveChanges();

        }
        public void Delete(Guid isnNode)
        {
            _userRepository.Delete(_dataContext, isnNode);
        }

        public UserDto GetCenter(Guid isnNode)
        {
            var center = _userRepository.GetById(_dataContext, isnNode);
            return _mapper.Map<UserDto>(center);
        }
        public UserDto[] GetListCenters(UserFilterDto centerFilter)
        {
            var center = _userService.GetUserQueryable(_dataContext, centerFilter, true).Select(x => new UserDto
            {
                IsnNode = x.IsnNode,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToArray();
            return center;
        }
    }
}