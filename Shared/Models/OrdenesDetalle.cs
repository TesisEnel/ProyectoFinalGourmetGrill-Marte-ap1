using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class OrdenesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Ordenes")]
    public int OrdenId { get; set; }

    [ForeignKey("Productos")]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "Un Producto es requerido")]
    public Productos? Producto { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public int Cantidad { get; set; }
}
