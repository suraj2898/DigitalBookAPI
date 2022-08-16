using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReaderAPI.Models
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

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Bookid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookid");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.BookContent)
                    .HasColumnType("ntext")
                    .HasColumnName("book_content");

                entity.Property(e => e.Category)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publish_date");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("publisher");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Userid).HasColumnName("userid");

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Paymentid)
                    .ValueGeneratedNever()
                    .HasColumnName("paymentid");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.Userid).HasColumnName("userid");

            });

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
