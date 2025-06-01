using INTA_Api.Core;

namespace INTA_Api.AppModules.Authentication;

public interface IAuthRepository
{
    Task<CommonDBResModel<INTA_Users>> GetUserbyUsername(string username);
    Task<CommonDBResModel<INTA_Users>> AddUser(INTA_Users user);
}

