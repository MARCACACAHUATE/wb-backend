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
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserHasCursos", b =>
                {
                    b.Property<int>("CursosIdCursos")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("CursosIdCursos", "UsersId");

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

            modelBuilder.Entity("wb_backend.Models.CursoSeparacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad_personas_contratadas")
                        .HasColumnType("integer");

                    b.Property<int>("CursosId")
                        .HasColumnType("integer");

                    b.Property<int?>("CursosIdCursos")
                        .HasColumnType("integer");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<int>("Telefono")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CursosId");

                    b.HasIndex("CursosIdCursos");

                    b.ToTable("CursoSeparacions");
                });

            modelBuilder.Entity("wb_backend.Models.Cursos", b =>
                {
                    b.Property<int>("IdCursos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCursos"));

                    b.Property<string>("Calle")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("CostoReservacion")
                        .HasColumnType("integer");

                    b.Property<int>("CostoTotal")
                        .HasColumnType("integer");

                    b.Property<string>("Detalle")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("EstadoCursoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdEstadoCurso")
                        .HasColumnType("integer");

                    b.Property<string>("Municipio")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Tematica")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("IdCursos");

                    b.HasIndex("EstadoCursoId");

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

                    b.Property<string>("ColorGlobos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("CostoEnvioMaterial")
                        .HasColumnType("real");

                    b.Property<float>("Costo_reservacion")
                        .HasColumnType("real");

                    b.Property<float>("Costo_total")
                        .HasColumnType("real");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Municipio")
                        .HasColumnType("integer");

                    b.Property<string>("Mobiliario")
                        .HasColumnType("text");

                    b.Property<string>("NombrePaquete")
                        .HasColumnType("text");

                    b.Property<string>("Ocasion")
                        .HasColumnType("text");

                    b.Property<string>("Servicios")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id_Municipio");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("wb_backend.Models.EventoSeparacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HoraEvento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HoraMontaje")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Evento")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id_Evento")
                        .IsUnique();

                    b.ToTable("EventoSeparacions");
                });

            modelBuilder.Entity("wb_backend.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreMunicipio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Municipios");
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
                    b.HasOne("wb_backend.Models.Cursos", null)
                        .WithMany()
                        .HasForeignKey("CursosIdCursos")
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

            modelBuilder.Entity("wb_backend.Models.CursoSeparacion", b =>
                {
                    b.HasOne("wb_backend.Models.Cursos", "Cursos")
                        .WithMany()
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wb_backend.Models.Cursos", null)
                        .WithMany("CursoSeparacions")
                        .HasForeignKey("CursosIdCursos");

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("wb_backend.Models.Cursos", b =>
                {
                    b.HasOne("wb_backend.Models.EstadoCurso", "EstadoCurso")
                        .WithMany()
                        .HasForeignKey("EstadoCursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoCurso");
                });

            modelBuilder.Entity("wb_backend.Models.Evento", b =>
                {
                    b.HasOne("wb_backend.Models.Municipio", "Municipio")
                        .WithMany("Eventos")
                        .HasForeignKey("Id_Municipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("wb_backend.Models.EventoSeparacion", b =>
                {
                    b.HasOne("wb_backend.Models.Evento", "Evento")
                        .WithOne("Separacion")
                        .HasForeignKey("wb_backend.Models.EventoSeparacion", "Id_Evento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
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

            modelBuilder.Entity("wb_backend.Models.Cursos", b =>
                {
                    b.Navigation("CursoSeparacions");
                });

            modelBuilder.Entity("wb_backend.Models.EstadoCurso", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("wb_backend.Models.Evento", b =>
                {
                    b.Navigation("Separacion");
                });

            modelBuilder.Entity("wb_backend.Models.Municipio", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("wb_backend.Models.TipoUser", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
