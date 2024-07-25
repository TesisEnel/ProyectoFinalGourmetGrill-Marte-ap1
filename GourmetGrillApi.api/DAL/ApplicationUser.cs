using Microsoft.AspNetCore.Identity;

namespace GourmetGrillApi.api.DAL;

public class ApplicationUser : IdentityUser
{
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cedula { get; set; }

    public string? NickName { get; set; }
}
