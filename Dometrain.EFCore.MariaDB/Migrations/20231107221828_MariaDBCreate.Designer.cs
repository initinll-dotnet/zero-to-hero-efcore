﻿// <auto-generated />
using System;
using Dometrain.EFCore.MariaDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dometrain.EFCore.MariaDB.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20231107221828_MariaDBCreate")]
    partial class MariaDBCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.1.23419.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.ExternalInformation", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ImdbUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("RottenTomatoesUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("longtext");

                    b.HasKey("MovieId");

                    b.ToTable("ExternalInformations");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Movie", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgeRating")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<decimal>("InternetRating")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("MainGenreName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar")
                        .HasColumnName("Plot");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.HasKey("Identifier");

                    b.HasAlternateKey("Title", "ReleaseDate");

                    b.HasIndex("AgeRating")
                        .IsDescending();

                    b.HasIndex("MainGenreName");

                    b.ToTable("Pictures", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Movie");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Movie_Actor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("Movie_Actor");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.CinemaMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.MariaDB.Models.Movie");

                    b.Property<decimal>("GrossRevenue")
                        .HasColumnType("decimal(65,30)");

                    b.HasDiscriminator().HasValue("CinemaMovie");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.TelevisionMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.MariaDB.Models.Movie");

                    b.Property<string>("ChannelFirstAiredOn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("TelevisionMovie");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.ExternalInformation", b =>
                {
                    b.HasOne("Dometrain.EFCore.MariaDB.Models.Movie", "Movie")
                        .WithOne("ExternalInformation")
                        .HasForeignKey("Dometrain.EFCore.MariaDB.Models.ExternalInformation", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Movie", b =>
                {
                    b.HasOne("Dometrain.EFCore.MariaDB.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("MainGenreName")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Movie_Actor", b =>
                {
                    b.HasOne("Dometrain.EFCore.MariaDB.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MovieActor_Actor");

                    b.HasOne("Dometrain.EFCore.MariaDB.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MovieActor_Movie");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Dometrain.EFCore.MariaDB.Models.Movie", b =>
                {
                    b.Navigation("ExternalInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
