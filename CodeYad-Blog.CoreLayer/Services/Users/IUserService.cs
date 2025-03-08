using Codeyad_Blog4.CoreLayer.DTOs.Users;
using Codeyad_Blog4.CoreLayer.Utilities;
using Codeyad_Blog4.DataLayer.Entities;

namespace Codeyad_Blog4.CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(LoginUserDto loginDto);
    }
}