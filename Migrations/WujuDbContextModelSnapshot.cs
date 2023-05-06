﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wb_backend.Models;

#nullable disable

namespace wbbackend.Migrations
{
    [DbContext(typeof(WujuDbContext))]
    partial class WujuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserHasCursos", b =>
                {
                    b.Property<int>("CursosId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("CursosId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserHasCursos");
                });

            modelBuilder.Entity("UserHasEventos", b =>
                {
                    b.Property<int>("EventosId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("EventosId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserHasEventos");
                });

            modelBuilder.Entity("wb_backend.Models.Curso", b =>
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

                    b.Property<int>("Espacios_disponibles")
                        .HasColumnType("integer");

                    b.Property<int>("Espacios_restantes")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha_finalizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Fecha_inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Tematica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("wb_backend.Models.EstadoCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("EstadoCursos");
                });

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

            modelBuilder.Entity("wb_backend.Models.TipoUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoUsers");
                });

            modelBuilder.Entity("wb_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Calle")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("First_name")
                        .HasColumnType("text");

                    b.Property<int>("Id_EstadoCurso")
                        .HasColumnType("integer");

                    b.Property<int>("Id_TipoUser")
                        .HasColumnType("integer");

                    b.Property<string>("Last_name")
                        .HasColumnType("text");

                    b.Property<string>("Municipio")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Telefono")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id_EstadoCurso");

                    b.HasIndex("Id_TipoUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserHasCursos", b =>
                {
                    b.HasOne("wb_backend.Models.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wb_backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserHasEventos", b =>
                {
                    b.HasOne("wb_backend.Models.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wb_backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wb_backend.Models.User", b =>
                {
                    b.HasOne("wb_backend.Models.EstadoCurso", "EstadoCurso")
                        .WithMany("Users")
                        .HasForeignKey("Id_EstadoCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wb_backend.Models.TipoUser", "TipoUser")
                        .WithMany("Users")
                        .HasForeignKey("Id_TipoUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoCurso");

                    b.Navigation("TipoUser");
                });

            modelBuilder.Entity("wb_backend.Models.EstadoCurso", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("wb_backend.Models.TipoUser", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
