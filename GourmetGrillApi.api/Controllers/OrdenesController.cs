using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GourmetGrillApi.api.DAL;
using Shared.Models;
using Shared.Interfaces;

namespace GourmetGrillApi.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenesController(IServer<Ordenes> service) : ControllerBase
{
    // GET: api/Ordenes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ordenes>>> GetOrdenes()
    {
        return await service.GetAllObject();
    }

    // GET: api/Ordenes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ordenes>> GetOrdenes(int id)
    {
        var Ordenes = await service.GetObject(id);

        if (Ordenes == null)
        {
            return NotFound();
        }

        return Ordenes;
    }

    // POST: api/Ordenes
    [HttpPost]
    public async Task<ActionResult<Ordenes>> PostOrdenes(Ordenes Ordenes)
    {
        var orden = await service.AddObject(Ordenes);
        return CreatedAtAction(nameof(GetOrdenes), new { id = orden.OrdenId }, orden);
    }

    // PUT: api/Ordenes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrdenes(int id, Ordenes Ordenes)
    {
        if (id != Ordenes.OrdenId)
        {
            return BadRequest();
        }
        await service.UpdateObject(Ordenes);
        return NoContent();
    }

    // DELETE: api/Ordenes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrdenes(int id)
    {
        var Ordenes = await service.DeleteObject(id);
        if (!Ordenes)
        {
            return NotFound();
        }
        return NoContent();
    }
}
