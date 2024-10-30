using System;
using System.Collections.Generic;
using BookStore.API.Data.Models;
using Microsoft.AspNetCore.Identity;
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
                .HasMaxLength(250)
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

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "87ca7854-7ed6-4120-bbf1-2d7392fc17a2",
            },
             new IdentityRole
             {
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR",
                 Id = "85dd46cd-31dd-47fb-94aa-1f15f80f35da",
             }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
               Id = "c6763dde-1e30-4fe3-b1ff-9835a108a378",
               Email = "admin@booksore.com",
               NormalizedEmail = "ADMIN@BOOKSTORE.COM",
               UserName = "BoogerAids",
               NormalizedUserName = "BOOGERAIDS",
               FirstName = "Rick",
               LastName = "Sanchez",
               PasswordHash = hasher.HashPassword(null, "P@assword1")
            },
             new ApiUser
             {
                Id = "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "Jessica123",
                NormalizedUserName = "JESSICA123",
                FirstName = "Morty",
                LastName = "Smith",
                 PasswordHash = hasher.HashPassword(null, "P@assword1")
             }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "85dd46cd-31dd-47fb-94aa-1f15f80f35da",
                    UserId = "c6763dde-1e30-4fe3-b1ff-9835a108a378"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "87ca7854-7ed6-4120-bbf1-2d7392fc17a2",
                    UserId = "5a080996-c520-4e3a-b4e3-98edc4dc6667"
                }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
