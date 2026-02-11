using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventarioProductos_Práctica_Entity_Framework.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Stop { get; set; }
    }
}
