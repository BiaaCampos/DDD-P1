﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20231007012214_sadas")]
    partial class sadas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompradorEventos", b =>
                {
                    b.Property<int>("CompradoresUserId")
                        .HasColumnType("int");

                    b.Property<int>("EventosIdEventos")
                        .HasColumnType("int");

                    b.HasKey("CompradoresUserId", "EventosIdEventos");

                    b.HasIndex("EventosIdEventos");

                    b.ToTable("CompradorEventos");
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Eventos", b =>
                {
                    b.Property<int>("IdEventos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEventos"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdLimiteIngresso")
                        .HasColumnType("int");

                    b.Property<float>("ValorIngresso")
                        .HasColumnType("real");

                    b.HasKey("IdEventos");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendaId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdComprador")
                        .HasColumnType("int");

                    b.Property<int>("IdEventos")
                        .HasColumnType("int");

                    b.Property<int>("QtdIngresso")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RA")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Comprador", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.HasDiscriminator().HasValue("Comprador");
                });

            modelBuilder.Entity("CompradorEventos", b =>
                {
                    b.HasOne("DDD.Domain.GeralContext.Comprador", null)
                        .WithMany()
                        .HasForeignKey("CompradoresUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.GeralContext.Eventos", null)
                        .WithMany()
                        .HasForeignKey("EventosIdEventos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}