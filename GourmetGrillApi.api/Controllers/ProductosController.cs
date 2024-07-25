using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GourmetGrillApi.api.DAL;
using Shared.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Shared.Interfaces;

namespace GourmetGrillApi.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController(IServer<Productos> service) : ControllerBase
{
    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
    {
        return await service.GetAllObject();
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Productos>> GetProductos(int id)
    {
        var productos = await service.GetObject(id);

        if (productos == null)
        {
            return NotFound();
        }

        return productos;
    }

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Productos>> PostProductos(Productos productos)
    {
        var product = await service.AddObject(productos);
        return CreatedAtAction(nameof(GetProductos), new { id = product.ProductoId }, product);
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductos(int id, Productos productos)
    {
        if (id != productos.ProductoId)
        {
            return BadRequest();
        }
        await service.UpdateObject(productos);
        return NoContent();
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductos(int id)
    {
        var productos = await service.DeleteObject(id);
        if (!productos)
        {
            return NotFound();
        }
        return NoContent();
    }
}
