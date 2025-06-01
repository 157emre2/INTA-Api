using INTA_Api.EntitySettings;

namespace INTA_Api.AppModules.Authentication;

public class INTA_Users : EntityDeleteBase
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string NameSurname { get; set; }
}
