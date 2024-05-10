using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationSpec.Models;

public partial class SpecdatabaseContext : DbContext
{
    public SpecdatabaseContext()
    {
    }

    public SpecdatabaseContext(DbContextOptions<SpecdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E8E2E8CED7");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B282B899C");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF1E5A37C8");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__3D5E1FD2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C18C3C9A4");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__403A8C7D");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__412EB0B6");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1F3C8AE3D20");

            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.BillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cvv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PaymentMe__UserI__52593CB8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED0A6AF816");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__3A81B327");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE346CC284");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__Product__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__440B1D61");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Shopping__51BCD79722D7B5B1");

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ShoppingC__Produ__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ShoppingC__UserI__47DBAE45");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B9B1A3B90");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Transacti__Order__5629CD9C");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Transacti__Payme__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF39E48C9");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
