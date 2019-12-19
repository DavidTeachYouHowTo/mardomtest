using MardomExamen.Domain.Entities;
using System.Data.Entity;

namespace MardomExamen.Repository.MyContext
{
    public class DbMardomExamen : DbContext
    {
        public DbMardomExamen() : base("DbMardomExamenConnection") { }

        public virtual DbSet<Almacenes> Almacenes { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<ArticuloAlmacen> ArticuloAlmacen { get; set; }
        public virtual DbSet<vwArticuloAlmaces> vwArticuloAlmaces { get; set; }
        public virtual DbSet<vwCantidadArticulosAlmacen> vwCantidadArticulosAlmacen { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacenes>()
               .Property(e => e.Almacen)
               .IsUnicode(false);

            modelBuilder.Entity<Almacenes>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Almacenes>()
                .HasMany(e => e.ListadoArticuloAlmacen)
                .WithRequired(e => e.Almacen)
                .HasForeignKey(e => e.Almacen_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Articulos>()
                .Property(e => e.Articulo)
                .IsUnicode(false);

            modelBuilder.Entity<Articulos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Articulos>()
                .Property(e => e.Precio)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Articulos>()
                .HasMany(e => e.ListadoArticulosAlmacenes)
                .WithRequired(e => e.Articulo)
                .HasForeignKey(e => e.Articulo_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vwArticuloAlmaces>()
                .Property(e => e.Articulo)
                .IsUnicode(false);

            modelBuilder.Entity<vwArticuloAlmaces>()
                .Property(e => e.Almacen)
                .IsUnicode(false);
        }

    }
}
