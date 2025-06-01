using AutoMapper;

namespace INTA_Api.AppModules.Authentication;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMaps();
    }

    protected void CreateMaps()
    {
        CreateMap<INTA_Users, UserResponseModel>();
        CreateMap<UserRequestModel, INTA_Users>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
    }
}
