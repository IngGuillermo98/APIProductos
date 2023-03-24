using System;
using System.Collections.Generic;

namespace CRUD_Productos_GML.Models.Entities
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Producto = new HashSet<Producto>();
        }

        public int Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
