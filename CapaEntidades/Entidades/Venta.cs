namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENTAS")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            DetallesVentas = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string TipoComprobante { get; set; }

        public int NroComprobante { get; set; }

        public DateTime Fecha { get; set; }

        public int? IdCliente { get; set; }

        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetallesVentas { get; set; }
    }
}
