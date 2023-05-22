﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wb_backend.Models;

#nullable disable

namespace wbbackend.Migrations
{
    [DbContext(typeof(WujuDbContext))]
    [Migration("20230419041841_Modelos para las reservaciones")]
    partial class Modelosparalasreservaciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        

            modelBuilder.Entity("wb_backend.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Costo_reservacion")
                        .HasColumnType("real");

                    b.Property<float>("Costo_total")
                        .HasColumnType("real");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Tematica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

        
            modelBuilder.Entity("wb_backend.Models.ReservacionEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_evento")
                        .HasColumnType("integer");

                    b.Property<int>("Id_user")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id_evento");

                    b.HasIndex("Id_user");

                    b.ToTable("ReservacionEvento");
                });

            modelBuilder.Entity("wb_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("First_name")
                        .HasColumnType("text");

                    b.Property<bool>("Is_admin")
                        .HasColumnType("boolean");

                    b.Property<bool>("Is_staff")
                        .HasColumnType("boolean");

                    b.Property<string>("Last_name")
                        .HasColumnType("text");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Telefono")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

        

            modelBuilder.Entity("wb_backend.Models.ReservacionEvento", b =>
                {
                    b.HasOne("wb_backend.Models.Evento", "Eventos")
                        .WithMany()
                        .HasForeignKey("Id_evento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wb_backend.Models.User", "Users")
                        .WithMany("ReservacionEventos")
                        .HasForeignKey("Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("wb_backend.Models.User", b =>
                {

                    b.Navigation("ReservacionEventos");
                });
#pragma warning restore 612, 618
        }
    }
}
