namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetalleVenta
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        public int IdVenta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }

        public decimal CostoUnitario { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Cantidad { get; set; }

        public decimal Subtotal { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
