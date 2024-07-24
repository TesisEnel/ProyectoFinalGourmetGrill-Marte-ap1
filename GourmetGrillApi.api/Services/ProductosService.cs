
using GourmetGrillApi.api.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinalGourmetGrill.Services;

public class ProductosService(ApplicationDbContext _contexto) : IServer<Productos>
{
    public async Task<Productos> GetObject(int id)
    {
        return await _contexto.Productos.FindAsync(id);
    }

    public async Task<List<Productos>> GetAllObject()
    {
        return await _contexto.Productos
            .Include(p => p.CategoriaId)
            .ToListAsync();
    }

    public async Task<Productos> AddObject(Productos producto)
    {
        _contexto.Productos.Add(producto);
        await _contexto.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> UpdateObject(Productos producto)
    {
        _contexto.Entry(producto).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Productos?> Search(int productoId)
    {
        return await _contexto.Productos.AsNoTracking().FirstOrDefaultAsync(a => a.ProductoId == productoId);
    }

    public async Task<bool> DeleteObject(int id)
    {
        var producto = await _contexto.Productos.FindAsync(id);
        if (producto == null)
        {
            return false;
        }
        _contexto.Productos.Remove(producto);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<Productos>> GetObjectByCondition(Expression<Func<Productos, bool>> expression)
    {
        return await _contexto.Productos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }

    //public async Task<string?> GetCategoriaNombre(int productoId)
    //{
    //    var producto = await _contexto.Productos
    //        .Include(p => p.CategoriaId)
    //        .FirstOrDefaultAsync(p => p.ProductoId == productoId);

    //    return producto.CategoriaId.;
    //}
}
