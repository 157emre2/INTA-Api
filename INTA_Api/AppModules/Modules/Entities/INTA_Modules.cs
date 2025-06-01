using INTA_Api.EntitySettings;

namespace INTA_Api.AppModules.Modules;

public class INTA_Modules : EntityDeleteBase
{
    public string ModuleName { get; set; }
    public string ModuleDescription { get; set; }
    public string? ModuleImage { get; set; }
}
