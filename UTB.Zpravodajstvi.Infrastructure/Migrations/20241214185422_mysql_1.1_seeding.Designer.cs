﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UTB.Zpravodajstvi.Infrastructure.Database;

#nullable disable

namespace UTB.Zpravodajstvi.Infrastructure.Migrations
{
    [DbContext(typeof(ZpravodajstviDbContext))]
    [Migration("20241214185422_mysql_1.1_seeding")]
    partial class mysql_11_seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Article");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Description = "Popis prvního článku.",
                            ImageSrc = "/img/img1.jpg",
                            Title = "První článek"
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 2,
                            Description = "Popis druhého článku.",
                            ImageSrc = "/img/img2.jpg",
                            Title = "Druhý článek"
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.ArticleTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ArticleTag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleID = 1,
                            TagID = 1
                        },
                        new
                        {
                            Id = 2,
                            ArticleID = 1,
                            TagID = 2
                        },
                        new
                        {
                            Id = 3,
                            ArticleID = 2,
                            TagID = 1
                        },
                        new
                        {
                            Id = 4,
                            ArticleID = 2,
                            TagID = 2
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Carousel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageAlt = "První článek",
                            ImageSrc = "/img/img1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ImageAlt = "Druhý článek",
                            ImageSrc = "/img/img2.jpg"
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Technologie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Zprávy"
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Zajímavé"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Inovace"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}