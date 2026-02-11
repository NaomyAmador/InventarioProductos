using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioProductos_Práctica_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioProductos_Práctica_Entity_Framework.Data
{
    public class InventarioProductosContext : DbContext
    {
            public DbSet<Productos> Productos { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=InventarioProductosBDD;Trusted_Connection=True;TrustServerCertificate=True;");
            }
    }
}
