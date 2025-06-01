using AutoMapper;
using Core;
using Core.Model;
using INTA_Api.Core;
using System.Threading.Tasks;

namespace INTA_Api.AppModules.Authentication;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IMapper mapper, IJwtService jwtService, IAuthRepository authRepository, IConfiguration configuration)
    {
        _mapper = mapper;
        _jwtService = jwtService;
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<CommonViewModel<UserResponseModel>> Login(UserRequestModel userRequestModel)
    {
        var userInfo = await _authRepository.GetUserbyUsername(userRequestModel.Username);

        if (!userInfo.isSuccess || !BCrypt.Net.BCrypt.Verify(userRequestModel.Password, userInfo.Data.HashedPassword))
            return new CommonViewModel<UserResponseModel>
            {
                IsSuccess = false,
                Message = userInfo.Message
            };
        else
        {
            var token = _jwtService.GenerateToken(new JwtTokenModel()
            {
                UserId = userInfo.Data.Id.ToString(),
                Username = userInfo.Data.Username,
                JwtAudience = _configuration["Jwt:Audience"],
                JwtIssuer = _configuration["Jwt:Issuer"],
                JwtKey = _configuration["Jwt:Key"]
            });

            var resModel = _mapper.Map<UserResponseModel>(userInfo.Data);
            resModel.Token = token;

            return new CommonViewModel<UserResponseModel>
            {
                IsSuccess = true,
                Data = resModel,
                Message = "Login successful",
            };
        }
    }

    public async Task<CommonViewModel<UserResponseModel>> Register(UserRequestModel userRequestModel)
    {
        if (await _authRepository.GetUserbyUsername(userRequestModel.Username) is { isSuccess: true })
            return new CommonViewModel<UserResponseModel>
            {
                IsSuccess = false,
                Message = "Username already exists"
            };
        else
        {
            var user = _mapper.Map<INTA_Users>(userRequestModel);

            var userAdd = await _authRepository.AddUser(user);

            if (!userAdd.isSuccess)
                return new CommonViewModel<UserResponseModel>
                {
                    IsSuccess = false,
                    Message = userAdd.Message
                };
            else 
                return new CommonViewModel<UserResponseModel>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<UserResponseModel>(userAdd.Data),
                    Message = "User registered successfully",
                };
        }

    }
}
