using System;
using System.Collections.Generic;
using BookStore.API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data.Contexts;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthorModel> Authors { get; set; }

    public virtual DbSet<BookModel> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07123489B8");

            entity.Property(e => e.Bio)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<BookModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0756F8D4B0");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA87CE7FFF").IsUnique();

            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToAuthors");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
