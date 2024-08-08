using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoFinalGourmetGrill.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinalGourmetGrill.Services;

public class MetodosPagosService(ApplicationDbContext _contexto) : IServer<MetodoPagos>
{

    public async Task<List<MetodoPagos>> GetAllObject() {
        return await _contexto.MetodoPagos.ToListAsync();
    }

    public Task<MetodoPagos> GetObject(int id) {
        return _contexto.MetodoPagos.FirstOrDefaultAsync(x => x.MetodoPagoId == id);
    }

    public Task<bool> UpdateObject(MetodoPagos type) {
        throw new NotImplementedException();
    }
    public Task<MetodoPagos> AddObject(MetodoPagos type) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(int id) {
        throw new NotImplementedException();
    }
    public async Task<bool> Exist(int id, string? nombre) {        
        return await _contexto.MetodoPagos
            .AnyAsync(p => p.MetodoPagoId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
    }
    public Task<List<MetodoPagos>> GetObjectByCondition(Expression<Func<MetodoPagos, bool>> expression) {
        return _contexto.MetodoPagos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
