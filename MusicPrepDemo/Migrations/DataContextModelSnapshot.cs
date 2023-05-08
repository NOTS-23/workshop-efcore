﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicPrepDemo.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicPrepDemo.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicPrepDemo.Models.Afspeellijst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Afspeellijsten");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.AfspeellijstNummer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AfspeellijstId")
                        .HasColumnType("integer");

                    b.Property<int>("NummerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AfspeellijstId");

                    b.HasIndex("NummerId");

                    b.ToTable("AfspeellijstNummers");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtiestId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDatum")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtiestId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.AlbumCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AlbumId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId")
                        .IsUnique();

                    b.ToTable("AlbumCovers");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Artiest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artiesten");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Nummer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Nummers");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.AfspeellijstNummer", b =>
                {
                    b.HasOne("MusicPrepDemo.Models.Afspeellijst", "Afspeellijst")
                        .WithMany("Nummers")
                        .HasForeignKey("AfspeellijstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicPrepDemo.Models.Nummer", "Nummer")
                        .WithMany("Lijsten")
                        .HasForeignKey("NummerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afspeellijst");

                    b.Navigation("Nummer");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Album", b =>
                {
                    b.HasOne("MusicPrepDemo.Models.Artiest", "Artiest")
                        .WithMany("Albums")
                        .HasForeignKey("ArtiestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiest");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.AlbumCover", b =>
                {
                    b.HasOne("MusicPrepDemo.Models.Album", "Album")
                        .WithOne("AlbumCover")
                        .HasForeignKey("MusicPrepDemo.Models.AlbumCover", "AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Nummer", b =>
                {
                    b.HasOne("MusicPrepDemo.Models.Album", "Album")
                        .WithMany("Nummers")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Afspeellijst", b =>
                {
                    b.Navigation("Nummers");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Album", b =>
                {
                    b.Navigation("AlbumCover")
                        .IsRequired();

                    b.Navigation("Nummers");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Artiest", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicPrepDemo.Models.Nummer", b =>
                {
                    b.Navigation("Lijsten");
                });
#pragma warning restore 612, 618
        }
    }
}
