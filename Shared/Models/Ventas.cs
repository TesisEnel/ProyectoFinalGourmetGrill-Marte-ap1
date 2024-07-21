using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string? ClienteId { get; set; }

    [Required(ErrorMessage = "El Combre del cliente es obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? NombreCliente { get; set; }

    [ForeignKey("Ordenes")]
    public int OrdenId { get; set; }

    [ForeignKey("MetodoPagos")]
    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public float SubTotal { get; set; }

    public float Total { get; set; }

    public float ITBS { get; set; }

    public float Recibido { get; set; }

    public float Devuelta { get; set; }

    public bool Eliminada { get; set; }

    [ForeignKey("VentaId")]
    public ICollection<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();
}
