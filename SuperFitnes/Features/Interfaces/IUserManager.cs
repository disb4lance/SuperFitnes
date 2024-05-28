using Classes.Database;
using Classes.models;
using Logic.DtoModels.Filters;
using SuperFitnes.Features.DtoModels.User;

namespace SuperFitnes.Features.Interfaces
{
    public interface IUserManager
    {
        Guid Create(EditUser User);
        public User FindByFirstName(string firstName);
        public User FindByIsnNode(Guid id);
        //public void Update(EditUser updateCenter);
        //public void Delete(Guid isnNode);

        //public UserDto GetCenter(Guid isnNode);
        //public UserDto[] GetListCenters(UserFilterDto centerFilter);
    }
}
