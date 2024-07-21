using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalGourmetGrill.Data;
using Shared.Models;

namespace GourmetGrillApi.api.DAL;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<CategoriaProductos> CategoriaProductos { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Ordenes> Ordenes { get; set; }
    public DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<VentasDetalle> VentasDetalle { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<MetodoPagos> MetodoPagos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //ConfigureGeneralModel(modelBuilder);
        //ConfigureProductosModel(modelBuilder);
    }

    public void ConfigureGeneralModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
             new Estados { EstadoId = 1, NombreEstado = "Pendiente" },
             new Estados { EstadoId = 2, NombreEstado = "Preparando" },
             new Estados { EstadoId = 3, NombreEstado = "YA ESTÁ PREPARADA" },
             new Estados { EstadoId = 4, NombreEstado = "Cancelado" }
        );
        modelBuilder.Entity<MetodoPagos>().HasData(
             new MetodoPagos { MetodoPagoId = 1, Nombre = "Efectivo" },
             new MetodoPagos { MetodoPagoId = 2, Nombre = "Tarjeta" }
        );
        modelBuilder.Entity<CategoriaProductos>().HasData(
             new CategoriaProductos { CategoriaId = 1, Nombre = "Hamburguesas" },
             new CategoriaProductos { CategoriaId = 2, Nombre = "Papas" },
             new CategoriaProductos { CategoriaId = 3, Nombre = "Acompañantes" },
             new CategoriaProductos { CategoriaId = 4, Nombre = "Bebidas" }             
        );
    }

   
}
