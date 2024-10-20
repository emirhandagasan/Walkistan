﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Walkistan.API.Data;

#nullable disable

namespace Walkistan.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241019231932_Initial Migration with Seeds")]
    partial class InitialMigrationwithSeeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Walkistan.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Easy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("Walkistan.API.Models.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1103,
                            Name = "Adalar",
                            RegionImageUrl = "https://images.unsplash.com/photo-1518352753950-d0c7da80e7a8"
                        },
                        new
                        {
                            Id = 1183,
                            Name = "Besiktas",
                            RegionImageUrl = "https://images.unsplash.com/photo-1589906528014-454c84ebaa5b"
                        },
                        new
                        {
                            Id = 1186,
                            Name = "Beyoglu",
                            RegionImageUrl = "https://images.unsplash.com/photo-1635357558138-df7ae85a3f61"
                        },
                        new
                        {
                            Id = 1185,
                            Name = "Beykoz",
                            RegionImageUrl = "https://images.unsplash.com/photo-1709458915635-4ba2e6076d6e"
                        },
                        new
                        {
                            Id = 1421,
                            Name = "Kadikoy",
                            RegionImageUrl = "https://images.unsplash.com/photo-1689410763484-d7fd8c775e25"
                        },
                        new
                        {
                            Id = 1708,
                            Name = "Uskudar",
                            RegionImageUrl = "https://images.unsplash.com/photo-1719954270201-4afb0efe559e"
                        });
                });

            modelBuilder.Entity("Walkistan.API.Models.Domain.Walk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<int>("LengthInKm")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This coastal walk takes you along the unique Maiden's Tower",
                            DifficultyId = 1,
                            LengthInKm = 3,
                            Name = "Uskudar Coast Walk",
                            RegionId = 1708,
                            WalkImageUrl = "https://images.unsplash.com/photo-1709940748754-eb59888100af"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Explore the beautiful Caddebostan Shore of Kadikoy on this leisurely walk",
                            DifficultyId = 2,
                            LengthInKm = 5,
                            Name = "Caddebostan Walk",
                            RegionId = 1421,
                            WalkImageUrl = "https://images.unsplash.com/photo-1607856339700-5520108d5f7c"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A walk from Taksim to Besiktas. This walk includes many historical places like Galata Tower, Dolmabahce and more",
                            DifficultyId = 2,
                            LengthInKm = 8,
                            Name = "Istiklal Street",
                            RegionId = 1186,
                            WalkImageUrl = "https://images.unsplash.com/photo-1607856339700-5520108d5f7c"
                        },
                        new
                        {
                            Id = 4,
                            Description = "We start this route, which is 7 kilometers and takes approximately 2 hours in total, excluding rest time, from Heybeliada Ferry Port. The route offers us a unique natural landscape track where blue and green mix. Heybeliada is such a beautiful place that when you complete this route, you are not only satisfied in terms of sports. The route also brings you many points of interest that you can visit.",
                            DifficultyId = 2,
                            LengthInKm = 7,
                            Name = "Heybeliada",
                            RegionId = 1103,
                            WalkImageUrl = "https://images.unsplash.com/photo-1721229902006-ab891d8dae87"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A 10 km walk from the Ferry Port of Besiktas to Bebek.",
                            DifficultyId = 2,
                            LengthInKm = 10,
                            Name = "Besiktas to Bebek",
                            RegionId = 1183,
                            WalkImageUrl = "https://images.unsplash.com/photo-1717150982298-1df8a5c0f342"
                        });
                });

            modelBuilder.Entity("Walkistan.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("Walkistan.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Walkistan.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}