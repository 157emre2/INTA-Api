using INTA_Api.Core;
using INTA_Api.EntitySettings;
using Microsoft.EntityFrameworkCore;

namespace INTA_Api.AppModules.Modules;

public class ModuleRepository : IModuleRepository
{
    private readonly AppDbContext _context;

    public ModuleRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<CommonDBResModel<INTA_Modules>> AddModule(INTA_Modules module)
    {
        try
        {
            _context.INTA_Modules.Add(module);
            var result = await _context.SaveChangesAsync();

            return result > 0 ? new()
            {
                Data = module,
                isSuccess = true,
            }
            : new()
            {
                Data = null,
                isSuccess = false,
                Message = "Failed to add module."
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Data = null,
                isSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<CommonDBResModel<List<INTA_Modules>>> GetModulesWithLang(LanguageEnum lang)
    {
        _context.CurrentLanguage = lang;

        var list = await _context.INTA_Modules.ToListAsync();

        return new()
        {
            Data = list,
            isSuccess = true
        };
    }
}
