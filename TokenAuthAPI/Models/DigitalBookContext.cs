using Microsoft.EntityFrameworkCore;

namespace TokenAuthAPI.Models
{
    public partial class DigitalBookContext : DbContext
    {
        public DigitalBookContext()
        {
        }

        public DigitalBookContext(DbContextOptions<DigitalBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("user_type")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
