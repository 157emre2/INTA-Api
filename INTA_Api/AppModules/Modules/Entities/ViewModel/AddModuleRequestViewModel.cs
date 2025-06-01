namespace INTA_Api.AppModules.Modules;

public class AddModuleRequestViewModel
{
    public string ModuleName { get; set; }
    public string ModuleDescription { get; set; }
    public string? ModuleImage { get; set; }
    public string? CreatedBy { get; set; }
    public int Language { get; set; }
}
