//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParcialPedriño.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categorias
    {
        public Categorias()
        {
            this.Libros = new HashSet<Libros>();
        }
    
        public int CategoriaId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<bool> activo { get; set; }
        public string pais_origen { get; set; }
    
        public virtual ICollection<Libros> Libros { get; set; }
    }
}
