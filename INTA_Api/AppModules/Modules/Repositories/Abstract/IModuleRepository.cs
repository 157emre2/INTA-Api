using INTA_Api.Core;

namespace INTA_Api.AppModules.Modules;

public interface IModuleRepository
{
    Task<CommonDBResModel<List<INTA_Modules>>> GetModulesWithLang(LanguageEnum lang);
    Task<CommonDBResModel<INTA_Modules>> AddModule(INTA_Modules module);
}
