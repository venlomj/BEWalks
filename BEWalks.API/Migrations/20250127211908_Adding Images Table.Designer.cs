﻿// <auto-generated />
using System;
using BEWalks.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BEWalks.API.Migrations
{
    [DbContext(typeof(BEWalksDbContext))]
    [Migration("20250127211908_Adding Images Table")]
    partial class AddingImagesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BEWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("BEWalks.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BEWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Id = new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                            Code = "VLG",
                            Name = "Flanders",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/Flag_of_Flanders.svg/1200px-Flag_of_Flanders.svg.png"
                        },
                        new
                        {
                            Id = new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                            Code = "WAL",
                            Name = "Wallonia",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Flag_of_Wallonia.svg/1200px-Flag_of_Wallonia.svg.png"
                        },
                        new
                        {
                            Id = new Guid("14ceba71-4b51-4777-9b17-46602cf66153"),
                            Code = "BRU",
                            Name = "Brussels-Capital",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Flag_of_the_Brussels-Capital_Region.svg/1200px-Flag_of_the_Brussels-Capital_Region.svg.png"
                        },
                        new
                        {
                            Id = new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                            Code = "ANT",
                            Name = "Antwerp",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Antwerp.svg/1200px-Flag_of_Antwerp.svg.png"
                        },
                        new
                        {
                            Id = new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                            Code = "LIE",
                            Name = "Liège",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Flag_of_Liège.svg/1200px-Flag_of_Liège.svg.png"
                        },
                        new
                        {
                            Id = new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                            Code = "LUX",
                            Name = "Luxembourg",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Luxembourg_%28province%29.svg/1200px-Flag_of_Luxembourg_%28province%29.svg.png"
                        });
                });

            modelBuilder.Entity("BEWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("BEWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("BEWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEWalks.API.Models.Domain.Region", "Region")
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
