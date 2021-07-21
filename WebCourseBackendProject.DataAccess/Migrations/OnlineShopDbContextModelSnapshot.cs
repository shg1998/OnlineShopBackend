﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCourseBackendProject.DataAccess.Services;

namespace WebCourseBackendProject.DataAccess.Migrations
{
    [DbContext(typeof(OnlineShopDbContext))]
    partial class OnlineShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CatId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CotName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CotName");

                    b.HasKey("CatId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Commodity", b =>
                {
                    b.Property<int>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ComId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ComName");

                    b.Property<double>("ComPrice")
                        .HasColumnType("float")
                        .HasColumnName("ComPrice");

                    b.Property<int>("ComRemained")
                        .HasColumnType("int")
                        .HasColumnName("ComRemained");

                    b.Property<int>("ComSaledCount")
                        .HasColumnType("int")
                        .HasColumnName("ComSaledCount");

                    b.HasKey("ComId");

                    b.HasIndex("CategoryID");

                    b.ToTable("commodities");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReceiptId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComCount")
                        .HasColumnType("int")
                        .HasColumnName("ComCount");

                    b.Property<int>("ComId")
                        .HasColumnType("int");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("float")
                        .HasColumnName("FinalPrice");

                    b.Property<long>("ReceiptDate")
                        .HasColumnType("bigint")
                        .HasColumnName("ReceiptDate");

                    b.Property<double>("ReceiptTrackingCode")
                        .HasColumnType("float")
                        .HasColumnName("ReceiptTrackingCode");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId");

                    b.HasIndex("ComId");

                    b.HasIndex("StatusID");

                    b.HasIndex("UserId");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StatusName");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountCharge")
                        .HasColumnType("int")
                        .HasColumnName("AccountCharge");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FullName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("UserAddress");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Commodity", b =>
                {
                    b.HasOne("WebCourseBackendProject.DataAccess.Models.Category", "ComCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComCategory");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.Receipt", b =>
                {
                    b.HasOne("WebCourseBackendProject.DataAccess.Models.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebCourseBackendProject.DataAccess.Models.Status", "ReceiptStatus")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebCourseBackendProject.DataAccess.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Commodity");

                    b.Navigation("ReceiptStatus");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebCourseBackendProject.DataAccess.Models.User", b =>
                {
                    b.HasOne("WebCourseBackendProject.DataAccess.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}