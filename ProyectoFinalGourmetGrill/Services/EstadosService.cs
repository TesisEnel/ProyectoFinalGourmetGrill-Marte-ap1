using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoFinalGourmetGrill.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinalGourmetGrill.Services;

public class EstadosService(ApplicationDbContext _contexto) : IServer<Estados>
{
    public async Task<List<Estados>> GetAllObject() {
        return await _contexto.Estados.ToListAsync();
    }

    public Task<Estados> GetObject(int id) {
        return (_contexto.Estados.FirstOrDefaultAsync(x => x.EstadoId == id))!;
    }

    public Task<bool> UpdateObject(Estados type) {
        throw new NotImplementedException();
    }
    public Task<Estados> AddObject(Estados type) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(int id) {
        throw new NotImplementedException();
    }
    public async Task<bool> Exist(int id, string? nombre) {
        
        return await _contexto.Estados
            .AnyAsync(p => p.EstadoId != id && p.NombreEstado.ToLower().Equals(nombre.ToLower()));
    }
    public Task<List<Estados>> GetObjectByCondition(Expression<Func<Estados, bool>> expression) {
        return _contexto.Estados
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
