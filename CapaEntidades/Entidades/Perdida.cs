namespace CapaEntidades.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERDIDAS")]
    public partial class Perdida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Perdida()
        {
            DetallesPerdidas = new HashSet<Detalle_Perdida>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int IdEstado { get; set; }

        public decimal? Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Perdida> DetallesPerdidas { get; set; }
    }
}
