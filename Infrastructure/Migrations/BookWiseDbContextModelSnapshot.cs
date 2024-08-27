﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BookWiseDbContext))]
    partial class BookWiseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Autor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Dascricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Domain.Entities.Livro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdAutor")
                        .HasColumnType("uuid");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("QuantidadeDisponivel")
                        .HasColumnType("integer");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("IdAutor");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("LivroCategoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LivroId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriaId", "LivroId");

                    b.HasIndex("LivroId");

                    b.ToTable("LivroCategoria");
                });

            modelBuilder.Entity("Domain.Entities.Livro", b =>
                {
                    b.HasOne("Domain.Entities.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("LivroCategoria", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LivroCategoria_CategoriaId");

                    b.HasOne("Domain.Entities.Livro", null)
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LivroCategoria_LivroId");
                });

            modelBuilder.Entity("Domain.Entities.Autor", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}