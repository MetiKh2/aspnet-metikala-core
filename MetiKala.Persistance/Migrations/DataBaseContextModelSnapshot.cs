﻿// <auto-generated />
using System;
using MetiKala.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MetiKala.Persistance.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MetiKala.Domain.Entities.Order.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<int>("SumAmount")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Order.OrderDetail", b =>
                {
                    b.Property<int>("OD_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("OD_ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Permission.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PermissionID");

                    b.HasIndex("ParentID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Permission.RolePermission", b =>
                {
                    b.Property<int>("RP_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("RP_ID");

                    b.HasIndex("PermissionID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.Discount", b =>
                {
                    b.Property<int>("DiscountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountUse")
                        .HasColumnType("int");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountID");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int?>("GrandParentGroupeID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ParentGroupeID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SubGroupeID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("GrandParentGroupeID");

                    b.HasIndex("ParentGroupeID");

                    b.HasIndex("SubGroupeID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductDiscount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DiscountID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductDiscounts");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductFeature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FeatureID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductsGroupe", b =>
                {
                    b.Property<int>("GroupeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupeTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("GroupeID");

                    b.HasIndex("ParentID");

                    b.ToTable("ProductsGroupes");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivationCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.UserDiscount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DiscountID");

                    b.HasIndex("UserID");

                    b.ToTable("UserDiscount");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UR_ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Order.Order", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.User.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Order.OrderDetail", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Order.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.Products.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Permission.Permission", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Permission.Permission", null)
                        .WithMany("ParentPermission")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Permission.RolePermission", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Permission.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Products.ProductsGroupe", "GrandParentGroupe")
                        .WithMany("GrandParentProducts")
                        .HasForeignKey("GrandParentGroupeID");

                    b.HasOne("MetiKala.Domain.Entities.Products.ProductsGroupe", "ParentGroupe")
                        .WithMany("ParentProducts")
                        .HasForeignKey("ParentGroupeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.Products.ProductsGroupe", "SubGroupe")
                        .WithMany("SubProducts")
                        .HasForeignKey("SubGroupeID");

                    b.Navigation("GrandParentGroupe");

                    b.Navigation("ParentGroupe");

                    b.Navigation("SubGroupe");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductDiscount", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Products.Discount", "Discount")
                        .WithMany("ProductDiscounts")
                        .HasForeignKey("DiscountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.Products.Product", "Product")
                        .WithMany("ProductDiscounts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductFeature", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Products.Product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductsGroupe", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Products.ProductsGroupe", null)
                        .WithMany("ParentGroupes")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.UserDiscount", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.Products.Discount", "Discount")
                        .WithMany("UserDiscounts")
                        .HasForeignKey("DiscountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.User.User", "User")
                        .WithMany("UserDiscounts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.UserRole", b =>
                {
                    b.HasOne("MetiKala.Domain.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MetiKala.Domain.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Order.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Permission.Permission", b =>
                {
                    b.Navigation("ParentPermission");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.Discount", b =>
                {
                    b.Navigation("ProductDiscounts");

                    b.Navigation("UserDiscounts");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductDiscounts");

                    b.Navigation("ProductFeatures");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.Products.ProductsGroupe", b =>
                {
                    b.Navigation("GrandParentProducts");

                    b.Navigation("ParentGroupes");

                    b.Navigation("ParentProducts");

                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MetiKala.Domain.Entities.User.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserDiscounts");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
