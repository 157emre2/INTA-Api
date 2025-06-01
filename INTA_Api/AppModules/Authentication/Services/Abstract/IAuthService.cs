using INTA_Api.Core;

namespace INTA_Api.AppModules.Authentication;

public interface IAuthService
{
    Task<CommonViewModel<UserResponseModel>> Login(UserRequestModel userRequestModel);
    Task<CommonViewModel<UserResponseModel>> Register(UserRequestModel userRequestModel);
}
