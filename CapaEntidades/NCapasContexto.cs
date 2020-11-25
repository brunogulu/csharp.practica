namespace CapaEntidades.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NCapasContexto : DbContext
    {
        public NCapasContexto()
            : base("name=NCapasContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<Detalle_Perdida> DetallePerdida { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Perdida> Perdida { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.IdCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Dni)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.Ventas)
            //    .WithOptional(e => e.Cliente)
            //    .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Compra>()
                .Property(e => e.Total)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Compra>()
                .HasMany(e => e.DetallesCompras)
                .WithRequired(e => e.Compra)
                .HasForeignKey(e => e.IdCompra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.CostoUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.Subtotal)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Detalle_Perdida>()
                .Property(e => e.CostoUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.CostoUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.Subtotal)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Fabricante>()
                .HasMany(e => e.Productos)
                .WithOptional(e => e.Fabricante)
                .HasForeignKey(e => e.IdFabricante);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Productos)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.IdMarca);

            modelBuilder.Entity<Perdida>()
                .Property(e => e.Total)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Perdida>()
                .HasMany(e => e.DetallesPerdidas)
                .WithRequired(e => e.Perdida)
                .HasForeignKey(e => e.IdPerdida)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Costo)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Ganancia)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetallesCompras)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.IdProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetallesPerdidas)
                .WithOptional(e => e.Producto)
                .HasForeignKey(e => e.IdProducto);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetallesVentas)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.IdProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Compras)
                .WithRequired(e => e.Proveedores)
                .HasForeignKey(e => e.IdProveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.TipoComprobante)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.Total)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Venta>()
                .HasMany(e => e.DetallesVentas)
                .WithRequired(e => e.Venta)
                .HasForeignKey(e => e.IdVenta)
                .WillCascadeOnDelete(false);
        }
    }
}
