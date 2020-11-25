namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTOS")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            DetallesCompras = new HashSet<DetalleCompra>();
            DetallesPerdidas = new HashSet<Detalle_Perdida>();
            DetallesVentas = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public int? IdMarca { get; set; }

        [Column("producto")]
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public decimal? Ganancia { get; set; }

        public int? Existencia { get; set; }

        public int? IdEstado { get; set; }

        public int? IdFabricante { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Precio { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetallesCompras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Perdida> DetallesPerdidas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetallesVentas { get; set; }

        public virtual Fabricante Fabricante { get; set; }

        public virtual Marca Marca { get; set; }
    }
}
