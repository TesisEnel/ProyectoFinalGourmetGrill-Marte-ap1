using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoFinalGourmetGrill.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace ProyectoFinalGourmetGrill.Services;

public class CategoriaProductosService(ApplicationDbContext _contexto) : IServer<CategoriaProductos>
{
    public async Task<List<CategoriaProductos>> GetAllObject() {
        return await _contexto.CategoriaProductos.ToListAsync();
    }

    public async Task<CategoriaProductos> GetObject(int id) {
        return await _contexto.CategoriaProductos.FindAsync(id);
    }

    public async Task<CategoriaProductos> AddObject(CategoriaProductos type) {
        _contexto.CategoriaProductos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(CategoriaProductos type) {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id) {
        var categoria = await _contexto.CategoriaProductos.FindAsync(id);
        if (categoria == null)
            return false;
        _contexto.CategoriaProductos.Remove(categoria);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Exist(int id, string? nombre) {
        
        return await _contexto.CategoriaProductos
            .AnyAsync(p => p.CategoriaId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
    }
    public async Task<List<CategoriaProductos>> GetObjectByCondition(Expression<Func<CategoriaProductos, bool>> expression) {
        return await _contexto.CategoriaProductos.
            AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}