using INTA_Api.Core;
using INTA_Api.DbOperations;

namespace INTA_Api.AppModules.Authentication;

public class AuthRepository : IAuthRepository
{
    private readonly IDbOperations<INTA_Users> _dbOperations;

    public AuthRepository(IDbOperations<INTA_Users> dbOperations)
    {
        _dbOperations = dbOperations;
    }

    public async Task<CommonDBResModel<INTA_Users>> AddUser(INTA_Users user)
    {
        var userAdded = await  _dbOperations.Add(user);

        if (userAdded != null)
            return new CommonDBResModel<INTA_Users>
            {
                Data = userAdded,
                isSuccess = true,
                Message = "User added successfully"
            };
        else
            return new CommonDBResModel<INTA_Users>
            {
                isSuccess = false,
                Message = "Failed to add user"
            };
    }

    public async Task<CommonDBResModel<INTA_Users>> GetUserbyUsername(string username)
    {
        var userinfo = await _dbOperations.GetByFilterSingle(x => x.Username == username);

        if (userinfo != null)
            return new CommonDBResModel<INTA_Users>
            {
                Data = userinfo,
                isSuccess = true
            };
        else
            return new CommonDBResModel<INTA_Users>
            {
                isSuccess = false,
                Message = "User not found"
            };
    }
}
