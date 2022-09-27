using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FactProd.Models
{
    public class ProdSchema
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string fecha { get; set; }

    }
    public class FacturacionProdDbContext : ApplicationDbContext
    {
        public DbSet<ProdSchema> Productos { get; set; }


    }
}