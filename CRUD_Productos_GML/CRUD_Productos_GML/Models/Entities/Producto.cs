using System;
using System.Collections.Generic;

namespace CRUD_Productos_GML.Models.Entities
{
    public partial class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? Precio { get; set; }
        public int? CodigoFabricante { get; set; }

        public virtual Fabricante? CodigoFabricanteNavigation { get; set; }
    }
}
