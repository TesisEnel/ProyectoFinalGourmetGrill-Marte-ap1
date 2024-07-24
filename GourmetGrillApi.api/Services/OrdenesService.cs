using GourmetGrillApi.api.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace GourmetGrillApi.api.Services;

public class OrdenesService(ApplicationDbContext _contexto) : IServer<Ordenes>
{
    public Task<List<Ordenes>> GetAllObject()
    {
        return _contexto.Ordenes
            .Include(d => d.OrdenesDetalle)
            .ToListAsync();
    }
    public async Task<Ordenes> GetObject(int id)
    {
        return (await _contexto.Ordenes
            .Include(d => d.OrdenesDetalle)
            .FirstOrDefaultAsync(r => r.OrdenId == id))!;
    }
    public async Task<Ordenes> AddObject(Ordenes type)
    {
        _contexto.Ordenes.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Ordenes type)
    {
        var detalle = await _contexto.OrdenesDetalle.Where(r => r.DetalleId == type.OrdenId).ToListAsync();
        foreach (var item in detalle)
        {
            var producto = await _contexto.Productos.FindAsync(item.ProductoId);
            producto!.Cantidad += item.Cantidad;
            _contexto.Entry(producto).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        if (type.EstadoId != 4)
        {
            foreach (var item in type.OrdenesDetalle)
            {
                var producto = await _contexto.Productos.FindAsync(item.ProductoId);
                producto!.Cantidad -= item.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();
            }
        }
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteObject(int id)
    {
        var orden = await _contexto.Ordenes.FindAsync(id);
        if (orden == null)
            return false;

        await _contexto.OrdenesDetalle.Where(r => r.OrdenId == id).ExecuteDeleteAsync();
        _contexto.Ordenes.Remove(orden);
        await _contexto.SaveChangesAsync();
        return true;
    }
    public Task<List<Ordenes>> GetObjectByCondition(Expression<Func<Ordenes, bool>> expression)
    {
        return _contexto.Ordenes
            .Include(d => d.OrdenesDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
