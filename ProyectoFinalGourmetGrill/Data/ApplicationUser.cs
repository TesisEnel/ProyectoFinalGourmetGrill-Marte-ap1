using Microsoft.AspNetCore.Identity;

namespace ProyectoFinalGourmetGrill.Data;

public class ApplicationUser : IdentityUser
{
    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public string? NickName { get; set; }
}
