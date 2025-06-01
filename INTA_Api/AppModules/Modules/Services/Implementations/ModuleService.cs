using AutoMapper;
using INTA_Api.Core;

namespace INTA_Api.AppModules.Modules;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly IMapper _mapper;

    public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
    {
        _moduleRepository = moduleRepository;
        _mapper = mapper;
    }

    public async Task<CommonViewModel<ModuleViewModel>> AddModule(AddModuleRequestViewModel module)
    {
        var entityModel = _mapper.Map<INTA_Modules>(module);

        var result = await _moduleRepository.AddModule(entityModel);

        return result.isSuccess ?
            new()
            {
                Data = _mapper.Map<ModuleViewModel>(result.Data),
                IsSuccess = true,
            }
            : new()
            {
                Data = null,
                IsSuccess = false,
                Message = result.Message,
            };
    }

    public async Task<CommonViewModel<List<ModuleViewModel>>> GetModulesWithLang(int lang)
    {
        var languageEnum = (LanguageEnum)lang;

        var result = await _moduleRepository.GetModulesWithLang(languageEnum);

        return result.isSuccess ?
            new()
            {
                Data = _mapper.Map<List<ModuleViewModel>>(result.Data),
                IsSuccess = true,
            }
            : new()
            {
                Data = null,
                IsSuccess = false,
            };
    }
}
