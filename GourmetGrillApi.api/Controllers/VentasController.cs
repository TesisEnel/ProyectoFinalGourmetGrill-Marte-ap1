using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace GourmetGrillApi.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentasController(IServer<Ventas> service) : ControllerBase
{
    // GET: api/Ventas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
    {
        return await service.GetAllObject();
    }

    // GET: api/Ventas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ventas>> GetVentas(int id)
    {
        var ventas = await service.GetObject(id);

        if (ventas == null)
        {
            return NotFound();
        }

        return ventas;
    }

    // POST: api/Ventas
    [HttpPost]
    public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
    {
        var ven = await service.AddObject(ventas);

        return CreatedAtAction(nameof(GetVentas), new { id = ven.VentaId }, ven);
    }

    // PUT: api/Ventas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVentas(int id, Ventas ventas)
    {
        if (id != ventas.VentaId)
        {
            return BadRequest();
        }
        await service.UpdateObject(ventas);
        return NoContent();
    }

    // DELETE: api/Ventas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVentas(int id)
    {
        var ventas = await service.DeleteObject(id);
        if (!ventas)
        {
            return NotFound();
        }

        return NoContent();
    }
}
