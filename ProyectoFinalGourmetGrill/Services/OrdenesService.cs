using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoFinalGourmetGrill.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinalGourmetGrill.Services;

public class OrdenesService : IServer<Ordenes>
{
    private readonly ApplicationDbContext _contexto;
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public OrdenesService(ApplicationDbContext contexto, IDbContextFactory<ApplicationDbContext> contextFactory) {
        _contexto = contexto;
        _contextFactory = contextFactory;
    }

    public async Task<List<Ordenes>> GetAllObject() {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
            .Include(m => m.MetodoPago)
            .ToListAsync();
    }

    public async Task<Ordenes> GetObject(int id) {
        return await _contexto.Ordenes
            .Include(d => d.OrdenesDetalle)
            .Include(m => m.MetodoPago)
            .FirstOrDefaultAsync(r => r.OrdenId == id);
    }

    public async Task<Ordenes> AddObject(Ordenes orden) {
        _contexto.Ordenes.Add(orden);
        await _contexto.SaveChangesAsync();
        return orden;
    }

    public async Task<bool> UpdateObject(Ordenes orden) {
        var detalle = await _contexto.OrdenesDetalle.Where(r => r.DetalleId == orden.OrdenId).ToListAsync();
        foreach (var item in detalle) {
            var producto = await _contexto.Productos.FindAsync(item.ProductoId);
            if (producto != null) {
                producto.Cantidad += item.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();
            }
        }

        if (orden.EstadoId != 4) {
            foreach (var item in orden.OrdenesDetalle) {
                var producto = await _contexto.Productos.FindAsync(item.ProductoId);
                if (producto != null) {
                    producto.Cantidad -= item.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                }
            }
        }
        _contexto.Entry(orden).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id) {
        var orden = await _contexto.Ordenes.FindAsync(id);
        if (orden == null)
            return false;

        await _contexto.OrdenesDetalle.Where(r => r.OrdenId == id).ExecuteDeleteAsync();
        _contexto.Ordenes.Remove(orden);
        await _contexto.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Exist(int id, string? nombre) {
        return await _contexto.Ordenes
            .AnyAsync(p => p.OrdenId != id && p.NombreCliente.ToLower().Equals(nombre.ToLower()));
    }

    public Task<List<Ordenes>> GetObjectByCondition(Expression<Func<Ordenes, bool>> expression) {
        return _contexto.Ordenes
            .Include(d => d.OrdenesDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
