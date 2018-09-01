using System.Data.Entity;
using UPictures.Core;

namespace UPictures.Data
{
    public class UPicturesEntities : DbContext
    {
        public UPicturesEntities() : base("name=UPicturesEntities")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Download> Downloads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Album>()
                .HasMany(mc => mc.Pictures)
                .WithRequired()
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Picture>()
                .HasRequired(mf => mf.Album)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Download>()
                .HasMany(mf => mf.Pictures)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}