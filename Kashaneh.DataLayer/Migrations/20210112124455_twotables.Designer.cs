﻿// <auto-generated />
using System;
using Kashaneh.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kashaneh.DataLayer.Migrations
{
    [DbContext(typeof(KashanehContext))]
    [Migration("20210112124455_twotables")]
    partial class twotables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Blog.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Visit")
                        .HasColumnType("int");

                    b.HasKey("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Blog.BlogComment", b =>
                {
                    b.Property<int>("BlogCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("BlogCommentId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogComments");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("ParentId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.Estate", b =>
                {
                    b.Property<int>("EstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("BathRooms")
                        .HasColumnType("int");

                    b.Property<int>("BedRooms")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateDuration")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("EstateImageId")
                        .HasColumnType("int");

                    b.Property<int?>("EstateStatusStatusId")
                        .HasColumnType("int");

                    b.Property<int>("EstateTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Facilities")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Floors")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LikedEstateId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Region")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SubEstateType")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EstateId");

                    b.HasIndex("CityId");

                    b.HasIndex("EstateStatusStatusId");

                    b.HasIndex("EstateTypeId");

                    b.HasIndex("LikedEstateId");

                    b.HasIndex("Region");

                    b.HasIndex("SubEstateType");

                    b.HasIndex("UserId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateImage", b =>
                {
                    b.Property<int>("EstateImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("EstateImageId");

                    b.HasIndex("EstateId");

                    b.ToTable("EstateImages");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("EstateStatuses");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateType", b =>
                {
                    b.Property<int>("EstateTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstateTypeId");

                    b.HasIndex("ParentId");

                    b.ToTable("EstateTypes");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.LikedEstate", b =>
                {
                    b.Property<int>("LikedEstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LikedEstateId");

                    b.HasIndex("UserId");

                    b.ToTable("LikedEstates");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.NewsLetter", b =>
                {
                    b.Property<int>("NewsLetterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("NewsLetterId");

                    b.ToTable("NewsLetters");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("LikedEstateId")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.UserMessage", b =>
                {
                    b.Property<int>("UserMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserMessageId");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Blog.Blog", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.User.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Blog.BlogComment", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.Blog.Blog", "Blog")
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.City", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.City", null)
                        .WithMany("Cities")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.Estate", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.City", "City")
                        .WithMany("Estates")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.EstateStatus", "EstateStatus")
                        .WithMany("Estates")
                        .HasForeignKey("EstateStatusStatusId");

                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.EstateType", "EstateType")
                        .WithMany("Estates")
                        .HasForeignKey("EstateTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kashaneh.DataLayer.Entities.User.LikedEstate", "LikedEstate")
                        .WithMany("Estates")
                        .HasForeignKey("LikedEstateId");

                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.City", "Zone")
                        .WithMany("Zone")
                        .HasForeignKey("Region");

                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.EstateType", "SubType")
                        .WithMany("SubType")
                        .HasForeignKey("SubEstateType");

                    b.HasOne("Kashaneh.DataLayer.Entities.User.User", "User")
                        .WithMany("Estates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("EstateStatus");

                    b.Navigation("EstateType");

                    b.Navigation("LikedEstate");

                    b.Navigation("SubType");

                    b.Navigation("User");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateImage", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.Estate", "Estate")
                        .WithMany("EstateImages")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estate");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateType", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.Estate.EstateType", null)
                        .WithMany("EstateTypes")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.LikedEstate", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.User.User", "User")
                        .WithMany("LikedEstates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("Kashaneh.DataLayer.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kashaneh.DataLayer.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Blog.Blog", b =>
                {
                    b.Navigation("BlogComments");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.City", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Estates");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.Estate", b =>
                {
                    b.Navigation("EstateImages");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateStatus", b =>
                {
                    b.Navigation("Estates");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.Estate.EstateType", b =>
                {
                    b.Navigation("Estates");

                    b.Navigation("EstateTypes");

                    b.Navigation("SubType");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.LikedEstate", b =>
                {
                    b.Navigation("Estates");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Kashaneh.DataLayer.Entities.User.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Estates");

                    b.Navigation("LikedEstates");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
