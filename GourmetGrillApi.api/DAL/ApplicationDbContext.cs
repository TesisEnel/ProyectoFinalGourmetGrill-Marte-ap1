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
        ConfigureGeneralModel(modelBuilder);
        ConfigureProductosModel(modelBuilder);
    }

    public void ConfigureGeneralModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
             new Estados { EstadoId = 1, NombreEstado = "Pendiente" },
             new Estados { EstadoId = 2, NombreEstado = "Preparando" },
             new Estados { EstadoId = 3, NombreEstado = "YA ESTÁ LISTA" },
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
    public void ConfigureProductosModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>().HasData(
             new Productos { Nombre = "La Intensa", Cantidad = 50, Precio = 475, ProductoId = 1, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Pepper Jack, Mermelada de Arandanos, Pesto y Aderezo de Perejil", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/UltimateCrackBurger.jpg" },
             new Productos { Nombre = "Funghi Girl", Cantidad = 50, Precio = 500, ProductoId = 2, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon y Crema de Hongos Trufada", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/PizzaBurger.jpg" },
             new Productos { Nombre = "La Formula", Cantidad = 50, Precio = 450, ProductoId = 3, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Bacon, Pulled Pork con Salsa BBQ y Coleslaw", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/CheeseBurguer.jpg" },
             new Productos { Nombre = "Clasic Bacon", Cantidad = 50, Precio = 325, ProductoId = 4, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Brioche, Doble Carne de 95g, Doble Queso Americano, Bacon y Aderezo Spread" },
             new Productos { Nombre = "Oklahoma", Cantidad = 50, Precio = 425, ProductoId = 5, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Cebolla Smashed y Alioli de Ajo" },
             new Productos { Nombre = "Kitchen Little", Cantidad = 50, Precio = 400, ProductoId = 6, CategoriaId = 1, Disponible = true, Descripcion = "Pan Brioche de Molde, Pechuga Empanizada, Doble Queso Americano, Bacon, Miel y Spicy Mayo" },
             new Productos { Nombre = "Baby Q", Cantidad = 50, Precio = 500, ProductoId = 7, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon, Aros de Cebolla Empanizadas y BBQ" },
             new Productos { Nombre = "Bacon Cheese Fries", Cantidad = 50, Precio = 350, ProductoId = 8, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Fondue de Queso Cheddar, Puerro y Bacon Bites" },
             new Productos { Nombre = "Animal Smashed", Cantidad = 50, Precio = 375, ProductoId = 9, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Carne Smashed, Fondue de Queso Cheddar y Alioli de Ajo" },
             new Productos { Nombre = "Birria Fries", Cantidad = 50, Precio = 500, ProductoId = 10, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Birria, Alioli de Ajo y Doble Queso Pepper Jack" },
             new Productos { Nombre = "Papas Fritas", Cantidad = 50, Precio = 50, ProductoId = 11, CategoriaId = 3, Disponible = true, Descripcion = "Papas Fritas" },
             new Productos { Nombre = "Papas Wedges", Cantidad = 50, Precio = 125, ProductoId = 12, CategoriaId = 3, Disponible = true, Descripcion = "Papas Enteras con Su piel cortadas Por La Mitad y Sazonadas" },
             new Productos { Nombre = "Aros de Cebolla", Cantidad = 50, Precio = 75, ProductoId = 13, CategoriaId = 3, Disponible = true, Descripcion = "5 Cebollas Fritas" },
             new Productos { Nombre = "Agua", Cantidad = 50, Precio = 20, ProductoId = 14, CategoriaId = 4, Disponible = true, Descripcion = "Botella de Agua Fria" },
             new Productos { Nombre = "Coca Cola 500ml ", Cantidad = 50, Precio = 50, ProductoId = 15, CategoriaId = 4, Disponible = true, Descripcion = "Coca Cola 500ml de Cristal" }
        );
    }
}
