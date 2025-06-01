using AutoMapper;

namespace INTA_Api.AppModules.Modules;

public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMaps();
    }

    protected void CreateMaps()
    {
        CreateMap<ModuleViewModel, INTA_Modules>()
            .ReverseMap();

        CreateMap<AddModuleRequestViewModel, INTA_Modules>();
    }
}
