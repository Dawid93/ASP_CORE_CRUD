﻿// <auto-generated />
using System;
using Crud.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crud.DataAccess.Migrations
{
    [DbContext(typeof(BeerDbContext))]
    partial class BeerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crud.DataAccess.Models.Beer", b =>
                {
                    b.Property<Guid>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeerDescription")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("BeerLabelImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BeerTypeFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BeerId");

                    b.HasIndex("BeerTypeFK");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Crud.DataAccess.Models.BeerType", b =>
                {
                    b.Property<Guid>("BeerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeerTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BeerTypeId");

                    b.ToTable("BeerTypes");
                });

            modelBuilder.Entity("Crud.DataAccess.Models.Beer", b =>
                {
                    b.HasOne("Crud.DataAccess.Models.BeerType", "BeerType")
                        .WithMany()
                        .HasForeignKey("BeerTypeFK");
                });
#pragma warning restore 612, 618
        }
    }
}
