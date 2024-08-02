using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ProyectoFinalGourmetGrill.Data;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        ConfigureGeneralModel(modelBuilder);
        ConfigureProductosModel(modelBuilder);
    }

    public void ConfigureGeneralModel(ModelBuilder modelBuilder) {
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
    public void ConfigureProductosModel(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Productos>().HasData(
             new Productos { Nombre = "La Intensa", Cantidad = 50, Precio = 475, ITBIS = 85.5f, ProductoId = 1, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Pepper Jack, Mermelada de Arandanos, Pesto y Aderezo de Perejil", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/UltimateCrackBurger.jpg" },
             new Productos { Nombre = "Funghi Girl", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 2, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon y Crema de Hongos Trufada", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/PizzaBurger.jpg" },
             new Productos { Nombre = "La Formula", Cantidad = 50, Precio = 450, ITBIS = 72.0f, ProductoId = 3, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Bacon, Pulled Pork con Salsa BBQ y Coleslaw", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Formula.jpg" },
             new Productos { Nombre = "Clasic Bacon", Cantidad = 50, Precio = 325, ITBIS = 58.5f, ProductoId = 4, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Brioche, Doble Carne de 95g, Doble Queso Americano, Bacon y Aderezo Spread", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/ClassicBacon.jpg" },
             new Productos { Nombre = "Oklahoma", Cantidad = 50, Precio = 425, ITBIS = 76.5f, ProductoId = 5, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Cebolla Smashed y Alioli de Ajo", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Oklahoma.jpg" },
             new Productos { Nombre = "Kitchen Little", Cantidad = 50, Precio = 400, ITBIS = 72.0f, ProductoId = 6, CategoriaId = 1, Disponible = true, Descripcion = "Pan Brioche de Molde, Pechuga Empanizada, Doble Queso Americano, Bacon, Miel y Spicy Mayo", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/KitchenBurguer.jpg" },
             new Productos { Nombre = "Baby Q", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 7, CategoriaId = 1, Disponible = true, Descripcion = "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon, Aros de Cebolla Empanizadas y BBQ", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/CheeseBurguer.jpg" },
             new Productos { Nombre = "Bacon Cheese Fries", Cantidad = 50, Precio = 350, ITBIS = 63.0f, ProductoId = 8, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Fondue de Queso Cheddar, Puerro y Bacon Bites", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BaconFries.jpg" },
             new Productos { Nombre = "Chilli Fries", Cantidad = 50, Precio = 375, ITBIS = 67.5f, ProductoId = 9, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Chilli, Fondue de Queso Cheddar y Alioli de Ajo", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/ChiliFries.jpg" },
             new Productos { Nombre = "Birria Fries", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 10, CategoriaId = 2, Disponible = true, Descripcion = "Papas Fritas, Birria, Alioli de Ajo y Doble Queso Pepper Jack", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BirriaFries.jpg" },
             new Productos { Nombre = "Papas Fritas", Cantidad = 50, Precio = 50, ITBIS = 9.0f, ProductoId = 11, CategoriaId = 3, Disponible = true, Descripcion = "Papas Fritas", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Fries.jpg" },
             new Productos { Nombre = "Papas Wedges", Cantidad = 50, Precio = 125, ITBIS = 25.5f, ProductoId = 12, CategoriaId = 3, Disponible = true, Descripcion = "Papas Enteras con Su piel cortadas Por La Mitad y Sazonadas con Ajo, Sal y Pimienta", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/PotatoWedges.jpg" },
             new Productos { Nombre = "Aros de Cebolla", Cantidad = 50, Precio = 75, ITBIS = 13.5f, ProductoId = 13, CategoriaId = 3, Disponible = true, Descripcion = "5 Cebollas Fritas", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/FriedOnion.jpg" },
             new Productos { Nombre = "Agua", Cantidad = 50, Precio = 20, ITBIS = 3.6f, ProductoId = 14, CategoriaId = 4, Disponible = true, Descripcion = "Botella de Agua Fria", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BottleWaterjpg.jpg" },
             new Productos { Nombre = "Coca Cola 500ml ", Cantidad = 50, Precio = 50, ITBIS = 9.0f, ProductoId = 15, CategoriaId = 4, Disponible = true, Descripcion = "Coca Cola 500ml de Cristal", ImagenUrl = "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Cocacola.jpg" }
        );
    }
}
