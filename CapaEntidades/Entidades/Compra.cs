namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMPRAS")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            DetallesCompras = new HashSet<DetalleCompra>();
        }

        public int Id { get; set; }

        public int NroComprobante { get; set; }

        public DateTime Fecha { get; set; }

        public int IdProveedor { get; set; }

        public decimal Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetallesCompras { get; set; }

        public virtual Proveedor Proveedores { get; set; }
    }
}
