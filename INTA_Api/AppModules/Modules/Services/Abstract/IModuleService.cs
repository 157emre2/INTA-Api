using INTA_Api.Core;

namespace INTA_Api.AppModules.Modules;

public interface IModuleService
{
    Task<CommonViewModel<List<ModuleViewModel>>> GetModulesWithLang(int lang);
    Task<CommonViewModel<ModuleViewModel>> AddModule(AddModuleRequestViewModel module);
}
