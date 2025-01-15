﻿// <auto-generated />
using System;
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
    [Migration("20250115112109_1.5_seeding")]
    partial class _15_seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

                    b.HasIndex("CategoryID");

                    b.ToTable("Article");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 2,
                            Description = "Výzkumný tým Fakulty technologické UTB dosáhl významného úspěchu v oblasti vývoje biodegradabilních polymerů. Projekt získal mezinárodní uznání na konferenci v Berlíně.",
                            ImageSrc = "/img/articles/img1.jpg",
                            Title = "UTB získala prestižní ocenění za výzkum v oblasti polymerů"
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 3,
                            Description = "Fakulta multimediálních komunikací prezentovala práce studentů na mezinárodním Design Week. Projekty se zaměřily na udržitelný design a sociální inovace.",
                            ImageSrc = "/img/articles/img2.jpg",
                            Title = "Studenti designu představili inovativní projekty na Design Week"
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 7,
                            Description = "Fakulta aplikované informatiky otevřela moderní centrum pro výzkum umělé inteligence a kybernetické bezpečnosti. Centrum nabídne studentům špičkové vybavení.",
                            ImageSrc = "/img/articles/img3.jpg",
                            Title = "Nové technologické centrum otevřeno na FAI"
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 6,
                            Description = "UTB hostila významnou mezinárodní konferenci zaměřenou na udržitelný rozvoj a zelené technologie. Účastnili se odborníci z celého světa.",
                            ImageSrc = "/img/articles/img4.jpg",
                            Title = "Mezinárodní konference o udržitelném rozvoji na UTB"
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 4,
                            Description = "Reprezentanti UTB získali několik medailí na Českých akademických hrách. Vynikajících výsledků dosáhli zejména v atletice a plavání.",
                            ImageSrc = "/img/articles/img5.jpg",
                            Title = "Sportovci UTB zazářili na Univerzitních hrách"
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 1,
                            Description = "Fakulta managementu a ekonomiky představuje nový studijní program zaměřený na digitální transformaci podniků a průmysl 4.0.",
                            ImageSrc = "/img/articles/img6.jpg",
                            Title = "Nový studijní program: Digitální transformace"
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 5,
                            Description = "Tradiční studentský festival přinesl do ulic Zlína kulturu, umění a zábavu. Akce přilákala tisíce návštěvníků.",
                            ImageSrc = "/img/articles/img7.jpg",
                            Title = "Studentský festival oživil centrum Zlína"
                        },
                        new
                        {
                            Id = 8,
                            CategoryID = 2,
                            Description = "Významný objev v oblasti nanotechnologií byl publikován v prestižním vědeckém časopise Nature. Tým vedl profesor Jan Novák.",
                            ImageSrc = "/img/articles/img8.jpg",
                            Title = "Výzkumný tým UTB publikoval v Nature"
                        },
                        new
                        {
                            Id = 9,
                            CategoryID = 8,
                            Description = "Více než 2000 potenciálních studentů navštívilo UTB během Dne otevřených dveří. Největší zájem byl o technické a kreativní obory.",
                            ImageSrc = "/img/articles/img9.jpg",
                            Title = "Den otevřených dveří přilákal rekordní počet zájemců"
                        },
                        new
                        {
                            Id = 10,
                            CategoryID = 6,
                            Description = "V akademickém roce 2023/24 vyjede na zahraniční pobyt nejvíce studentů v historii UTB. Nejoblíbenější destinací je Španělsko.",
                            ImageSrc = "/img/articles/img10.jpg",
                            Title = "Erasmus+ na UTB: Rekordní počet výjezdů"
                        },
                        new
                        {
                            Id = 11,
                            CategoryID = 7,
                            Description = "Tým studentů FAI získal první místo v prestižní mezinárodní soutěži robotiky v Tokiu. Jejich robot vynikal v oblasti autonomního rozhodování.",
                            ImageSrc = "/img/articles/img11.jpg",
                            Title = "Úspěch studentů v mezinárodní soutěži robotiky"
                        },
                        new
                        {
                            Id = 12,
                            CategoryID = 5,
                            Description = "Moderní knihovna s kapacitou 500 míst nabízí studentům nejnovější technologie a příjemné prostředí pro studium.",
                            ImageSrc = "/img/articles/img12.jpg",
                            Title = "Nová univerzitní knihovna otevřena"
                        },
                        new
                        {
                            Id = 13,
                            CategoryID = 3,
                            Description = "Studenti ateliéru Design oděvu prezentovali své kolekce na prestižní módní přehlídce. Zaujali originálním pojetím udržitelné módy.",
                            ImageSrc = "/img/articles/img13.jpg",
                            Title = "Fakulta designu představila kolekci na Fashion Week"
                        },
                        new
                        {
                            Id = 14,
                            CategoryID = 8,
                            Description = "Spolupráce přinese studentům přístup k nejnovějším technologiím a možnost stáží v technologickém gigantu.",
                            ImageSrc = "/img/articles/img14.jpg",
                            Title = "UTB podepsala strategické partnerství s Microsoft"
                        },
                        new
                        {
                            Id = 15,
                            CategoryID = 4,
                            Description = "Hokejisté UTB porazili tým UK Praha a postupují do finále univerzitní ligy. Finálový zápas se odehraje příští týden.",
                            ImageSrc = "/img/articles/img15.jpg",
                            Title = "Univerzitní hokejový tým postupuje do finále"
                        },
                        new
                        {
                            Id = 16,
                            CategoryID = 1,
                            Description = "UTB rozšiřuje nabídku stipendijních programů. Nově nabízí podporu pro inovativní projekty a výzkumné aktivity studentů.",
                            ImageSrc = "/img/articles/img16.jpg",
                            Title = "Nové stipendijní programy pro nadané studenty"
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

                    b.HasIndex("ArticleID");

                    b.HasIndex("TagID");

                    b.ToTable("ArticleTag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleID = 1,
                            TagID = 2
                        },
                        new
                        {
                            Id = 2,
                            ArticleID = 1,
                            TagID = 5
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
                            TagID = 7
                        },
                        new
                        {
                            Id = 5,
                            ArticleID = 3,
                            TagID = 2
                        },
                        new
                        {
                            Id = 6,
                            ArticleID = 3,
                            TagID = 9
                        },
                        new
                        {
                            Id = 7,
                            ArticleID = 4,
                            TagID = 3
                        },
                        new
                        {
                            Id = 8,
                            ArticleID = 4,
                            TagID = 6
                        },
                        new
                        {
                            Id = 9,
                            ArticleID = 5,
                            TagID = 4
                        },
                        new
                        {
                            Id = 10,
                            ArticleID = 5,
                            TagID = 8
                        },
                        new
                        {
                            Id = 11,
                            ArticleID = 6,
                            TagID = 1
                        },
                        new
                        {
                            Id = 12,
                            ArticleID = 6,
                            TagID = 5
                        },
                        new
                        {
                            Id = 13,
                            ArticleID = 7,
                            TagID = 2
                        },
                        new
                        {
                            Id = 14,
                            ArticleID = 7,
                            TagID = 6
                        },
                        new
                        {
                            Id = 15,
                            ArticleID = 8,
                            TagID = 3
                        },
                        new
                        {
                            Id = 16,
                            ArticleID = 8,
                            TagID = 9
                        },
                        new
                        {
                            Id = 17,
                            ArticleID = 9,
                            TagID = 4
                        },
                        new
                        {
                            Id = 18,
                            ArticleID = 9,
                            TagID = 8
                        },
                        new
                        {
                            Id = 19,
                            ArticleID = 10,
                            TagID = 1
                        },
                        new
                        {
                            Id = 20,
                            ArticleID = 10,
                            TagID = 5
                        },
                        new
                        {
                            Id = 21,
                            ArticleID = 11,
                            TagID = 2
                        },
                        new
                        {
                            Id = 22,
                            ArticleID = 11,
                            TagID = 7
                        },
                        new
                        {
                            Id = 23,
                            ArticleID = 12,
                            TagID = 3
                        },
                        new
                        {
                            Id = 24,
                            ArticleID = 12,
                            TagID = 6
                        },
                        new
                        {
                            Id = 25,
                            ArticleID = 13,
                            TagID = 1
                        },
                        new
                        {
                            Id = 26,
                            ArticleID = 13,
                            TagID = 5
                        },
                        new
                        {
                            Id = 27,
                            ArticleID = 14,
                            TagID = 2
                        },
                        new
                        {
                            Id = 28,
                            ArticleID = 14,
                            TagID = 8
                        },
                        new
                        {
                            Id = 29,
                            ArticleID = 15,
                            TagID = 4
                        },
                        new
                        {
                            Id = 30,
                            ArticleID = 15,
                            TagID = 6
                        },
                        new
                        {
                            Id = 31,
                            ArticleID = 16,
                            TagID = 1
                        },
                        new
                        {
                            Id = 32,
                            ArticleID = 16,
                            TagID = 5
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Carousel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            ImageAlt = "UTB získala prestižní ocenění za výzkum",
                            ImageSrc = "/img/carousel/img1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 2,
                            ImageAlt = "Inovativní projekty studentů designu",
                            ImageSrc = "/img/carousel/img2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 3,
                            ImageAlt = "Nové technologické centrum na FAI",
                            ImageSrc = "/img/carousel/img3.jpg"
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
                            Name = "Studium"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Věda a výzkum"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kultura"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Univerzitní život"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mezinárodní"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Technologie"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Události"
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
                        },
                        new
                        {
                            Id = 3,
                            Name = "Úspěch"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Studentský život"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Výzkum"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Spolupráce"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Akce"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Mezinárodní"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Technologie"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Vzdělávání"
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Infrastructure.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Writer",
                            NormalizedName = "WRITER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Reader",
                            NormalizedName = "READER"
                        });
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "admin@admin.cz",
                            EmailConfirmed = true,
                            FirstName = "Adminek",
                            LastName = "Adminovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.CZ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "writer@writer.cz",
                            EmailConfirmed = true,
                            FirstName = "Writerek",
                            LastName = "Writerovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "WRITER@WRITER.CZ",
                            NormalizedUserName = "WRITER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "writer"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Article", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.ArticleTag", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Domain.Entities.Article", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UTB.Zpravodajstvi.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Carousel", b =>
                {
                    b.HasOne("UTB.Zpravodajstvi.Domain.Entities.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("UTB.Zpravodajstvi.Domain.Entities.Article", b =>
                {
                    b.Navigation("ArticleTags");
                });
#pragma warning restore 612, 618
        }
    }
}