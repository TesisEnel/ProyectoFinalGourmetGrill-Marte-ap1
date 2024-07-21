using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalGourmetGrill.Data;
using Shared.Models;

namespace GourmetGrillApi.api.DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<CategoriaProductos> CategoriaProductos { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Ordenes> Ordenes { get; set; }
    public DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<VentasDetalle> VentasDetalle { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<MetodoPagos> MetodoPagos { get; set; }
}
