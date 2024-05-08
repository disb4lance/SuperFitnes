using Classes.models;
using SuperFitnes.Features.DtoModels.User;

namespace SuperFitnes.Features.Interfaces
{
    public interface IUserManager
    {
        Guid Create(EditUser User);
    }
}
