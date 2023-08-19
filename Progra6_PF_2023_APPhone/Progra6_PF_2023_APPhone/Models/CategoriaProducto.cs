using System;
using System.Collections.Generic;
using System.Text;

namespace Progra6_PF_2023_APPhone.Models
{
    public class CategoriaProducto
    {
        public CategoriaProducto()
        {
            //Productos = new HashSet<Producto>();
        }

        public int CategoriaProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuarioId { get; set; }

        //public virtual ICollection<Producto> Productos { get; set; }
    }
}
