﻿using Domains.Common;
using Domains.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public partial class MyKidsStoreDbContext : IdentityDbContext<ApplicationUser, Roles, long, UserClaims, UserRoles, UserLogins, RoleClaims, AspNetUserTokens>
    {
        public MyKidsStoreDbContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public MyKidsStoreDbContext(DbContextOptions<MyKidsStoreDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<UserClaims> UsersClaims { get; set; }
        public virtual DbSet<Roles> SystemRoles { get; set; }
        public virtual DbSet<UserLogins> UsersLogins { get; set; }
        public virtual DbSet<UserRoles> UsersRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<UserCart> UserCart { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            if (!optionsBuilder.IsConfigured)
            {
              
                optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_UserCart");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Item");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MasterCategory)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.MasterCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MasterCategory_Category");
            });

            modelBuilder.Entity<MasterCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SubCategoryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_SubCategory_ApplicationUser1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SubCategoryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_SubCategory_ApplicationUser");

                entity.HasOne(d => d.SubCategoryNavigation)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.SizesAvailable)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Brand");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_SubCategory");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.SetId)
                    .HasConstraintName("FK_Item_Set");
            });




            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Sale_Item");
            });

            

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status).ValueGeneratedOnAdd();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_UserCart");
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserOrderCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserOrder_ApplicationUser1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_UserOrder");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserOrderModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserOrder_ApplicationUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrderUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUser_UserOrder");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
