namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detalle_Perdida
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPerdida { get; set; }

        public decimal? CostoUnitario { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public virtual Perdida Perdida { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
