﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.Database;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241211002420_InitialSchemaWithSeeds")]
    partial class InitialSchemaWithSeeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrupoPermissaoPermissao", b =>
                {
                    b.Property<Guid>("GruposPermissoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissoesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GruposPermissoesId", "PermissoesId");

                    b.HasIndex("PermissoesId");

                    b.ToTable("PermissoesGruposPermissoes", (string)null);
                });

            modelBuilder.Entity("GrupoPermissaoUsuario", b =>
                {
                    b.Property<Guid>("GruposPermissoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GruposPermissoesId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("UsuariosGruposPermissoes", (string)null);
                });

            modelBuilder.Entity("app.Models.Entities.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");

                    b.HasData(
                        new
                        {
                            Id = new Guid("696a30b8-aba8-484d-85f3-442d9c690ae5"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1770),
                            EstadoId = new Guid("8e4ca77b-9dbb-419a-b189-b8abec84b933"),
                            Name = "Campinas"
                        },
                        new
                        {
                            Id = new Guid("b552ed81-4ac1-4b99-911a-026e4ee6a5ca"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1770),
                            EstadoId = new Guid("0b6f9e9b-8493-493a-82e9-6ccca0bb6a62"),
                            Name = "Niterói"
                        },
                        new
                        {
                            Id = new Guid("916f355e-bb09-4935-9362-f3ea120f5b03"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1770),
                            EstadoId = new Guid("67542890-1c72-4f60-8243-88f8389c5502"),
                            Name = "Uberlândia"
                        },
                        new
                        {
                            Id = new Guid("00e918b1-4e98-43cd-908f-1f588e851830"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1780),
                            EstadoId = new Guid("4dc48fd3-bb60-47b8-aeb3-3c11f5b346c5"),
                            Name = "Salvador"
                        },
                        new
                        {
                            Id = new Guid("bc04f978-fca7-41d0-bb77-e838c7a51668"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1780),
                            EstadoId = new Guid("2a3afe25-f1e6-478c-be98-2cfa7ba00b7b"),
                            Name = "Curitiba"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CpfCnpj")
                        .IsUnique();

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a67dbbd-8504-4707-8af7-6455689f5244"),
                            CpfCnpj = "12345678901",
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1880),
                            Nome = "João Silva"
                        },
                        new
                        {
                            Id = new Guid("aa9d0cb3-3eb9-40f0-b95a-5481fb4310d1"),
                            CpfCnpj = "23456789012",
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1890),
                            Nome = "Maria Oliveira"
                        },
                        new
                        {
                            Id = new Guid("287a57bd-d799-40a8-a53b-7cdf0918c92b"),
                            CpfCnpj = "34567890123",
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1890),
                            Nome = "Carlos Souza"
                        },
                        new
                        {
                            Id = new Guid("85eb2b2e-3b96-4bb0-81d2-4094635b02f2"),
                            CpfCnpj = "45678901234",
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1900),
                            Nome = "Ana Santos"
                        },
                        new
                        {
                            Id = new Guid("a4ce91c3-4d92-413f-b588-70699337681b"),
                            CpfCnpj = "56789012345",
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1900),
                            Nome = "Pedro Costa"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e4ca77b-9dbb-419a-b189-b8abec84b933"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1660),
                            Name = "São Paulo",
                            Sigla = "SP"
                        },
                        new
                        {
                            Id = new Guid("0b6f9e9b-8493-493a-82e9-6ccca0bb6a62"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1660),
                            Name = "Rio de Janeiro",
                            Sigla = "RJ"
                        },
                        new
                        {
                            Id = new Guid("67542890-1c72-4f60-8243-88f8389c5502"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1670),
                            Name = "Minas Gerais",
                            Sigla = "MG"
                        },
                        new
                        {
                            Id = new Guid("4dc48fd3-bb60-47b8-aeb3-3c11f5b346c5"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1670),
                            Name = "Bahia",
                            Sigla = "BA"
                        },
                        new
                        {
                            Id = new Guid("2a3afe25-f1e6-478c-be98-2cfa7ba00b7b"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1670),
                            Name = "Paraná",
                            Sigla = "PR"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.FonteDeEnergia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EficienciaMedia")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FontesDeEnergia");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd585e21-3a5c-42db-9b33-96f2ebbc6243"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1940),
                            Tipo = "Solar"
                        },
                        new
                        {
                            Id = new Guid("2d6d5d12-f951-4509-8067-c6eb46c5d828"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1950),
                            Tipo = "Eólica"
                        },
                        new
                        {
                            Id = new Guid("1085090d-be10-461d-bb01-a5557381cf62"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(1950),
                            Tipo = "Biomassa"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.GrupoPermissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GruposPermissoes");
                });

            modelBuilder.Entity("app.Models.Entities.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissoes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4ebd9f8e-125b-4a06-a961-4ba3f5d38525"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2000),
                            Nome = "Usinas"
                        },
                        new
                        {
                            Id = new Guid("fcf7d927-da4a-412a-88f7-a205e71fcd44"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2010),
                            Nome = "Clientes"
                        },
                        new
                        {
                            Id = new Guid("460d1d59-bcec-4608-b65b-b9bad21993a0"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2010),
                            Nome = "Cidades"
                        },
                        new
                        {
                            Id = new Guid("a69daa42-7d7d-42ac-98d9-d6e681a700f4"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2010),
                            Nome = "Estados"
                        },
                        new
                        {
                            Id = new Guid("c4816589-6bf7-4da6-afca-c70d2b05a90f"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2020),
                            Nome = "FontesDeEnergia"
                        },
                        new
                        {
                            Id = new Guid("7117b8c7-dea0-452b-9cd3-6c0a19dccc8b"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2020),
                            Nome = "ProducaoDeEnergia"
                        },
                        new
                        {
                            Id = new Guid("f90c0219-8682-4cec-949f-8d154bffcdc7"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2020),
                            Nome = "Usuarios"
                        },
                        new
                        {
                            Id = new Guid("932bc69f-df62-4d30-8b9d-5bf66520a80f"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2030),
                            Nome = "GruposPermissoes"
                        },
                        new
                        {
                            Id = new Guid("df7049fc-6b6f-4934-bfab-1a984d1ca801"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2030),
                            Nome = "Permissoes"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.ProducaoDeEnergia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataProducao")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EficienciaOperacional")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("EnergiaGeradaKW")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsinaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsinaId");

                    b.ToTable("ProducoesDeEnergia");
                });

            modelBuilder.Entity("app.Models.Entities.Usina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CapacidadeKW")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("FonteDeEnergiaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StatusOperacional")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FonteDeEnergiaId");

                    b.ToTable("Usinas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b32cc14-2ec2-4519-96e8-ee117148e316"),
                            CapacidadeKW = 1000.0m,
                            CidadeId = new Guid("696a30b8-aba8-484d-85f3-442d9c690ae5"),
                            ClienteId = new Guid("3a67dbbd-8504-4707-8af7-6455689f5244"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2200),
                            DataInicio = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua A, 123",
                            FonteDeEnergiaId = new Guid("cd585e21-3a5c-42db-9b33-96f2ebbc6243"),
                            Nome = "Usina Solar SP",
                            StatusOperacional = "Operando"
                        },
                        new
                        {
                            Id = new Guid("298e9c1e-1045-46f9-a43c-33f2db4d6081"),
                            CapacidadeKW = 1500.0m,
                            CidadeId = new Guid("b552ed81-4ac1-4b99-911a-026e4ee6a5ca"),
                            ClienteId = new Guid("aa9d0cb3-3eb9-40f0-b95a-5481fb4310d1"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2210),
                            DataInicio = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua B, 456",
                            FonteDeEnergiaId = new Guid("2d6d5d12-f951-4509-8067-c6eb46c5d828"),
                            Nome = "Usina Eólica RJ",
                            StatusOperacional = "Operando"
                        },
                        new
                        {
                            Id = new Guid("5f544973-7cd4-493a-81c0-4cd0f3900cb9"),
                            CapacidadeKW = 800.0m,
                            CidadeId = new Guid("916f355e-bb09-4935-9362-f3ea120f5b03"),
                            ClienteId = new Guid("287a57bd-d799-40a8-a53b-7cdf0918c92b"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2220),
                            DataInicio = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua C, 789",
                            FonteDeEnergiaId = new Guid("1085090d-be10-461d-bb01-a5557381cf62"),
                            Nome = "Usina Biomassa MG",
                            StatusOperacional = "Operando"
                        },
                        new
                        {
                            Id = new Guid("79b105d9-dfc4-4c19-a307-9b22f61ed7c0"),
                            CapacidadeKW = 1200.0m,
                            CidadeId = new Guid("00e918b1-4e98-43cd-908f-1f588e851830"),
                            ClienteId = new Guid("85eb2b2e-3b96-4bb0-81d2-4094635b02f2"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2220),
                            DataInicio = new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua D, 321",
                            FonteDeEnergiaId = new Guid("cd585e21-3a5c-42db-9b33-96f2ebbc6243"),
                            Nome = "Usina Solar BA",
                            StatusOperacional = "Em Manutenção"
                        },
                        new
                        {
                            Id = new Guid("879ea38e-91ed-4605-8117-ed617c362791"),
                            CapacidadeKW = 2000.0m,
                            CidadeId = new Guid("bc04f978-fca7-41d0-bb77-e838c7a51668"),
                            ClienteId = new Guid("a4ce91c3-4d92-413f-b588-70699337681b"),
                            CreatedAt = new DateTime(2024, 12, 10, 21, 24, 19, 779, DateTimeKind.Local).AddTicks(2230),
                            DataInicio = new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua E, 654",
                            FonteDeEnergiaId = new Guid("2d6d5d12-f951-4509-8067-c6eb46c5d828"),
                            Nome = "Usina Eólica PR",
                            StatusOperacional = "Operando"
                        });
                });

            modelBuilder.Entity("app.Models.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GrupoPermissaoPermissao", b =>
                {
                    b.HasOne("app.Models.Entities.GrupoPermissao", null)
                        .WithMany()
                        .HasForeignKey("GruposPermissoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Entities.Permissao", null)
                        .WithMany()
                        .HasForeignKey("PermissoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoPermissaoUsuario", b =>
                {
                    b.HasOne("app.Models.Entities.GrupoPermissao", null)
                        .WithMany()
                        .HasForeignKey("GruposPermissoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("app.Models.Entities.Cidade", b =>
                {
                    b.HasOne("app.Models.Entities.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("app.Models.Entities.ProducaoDeEnergia", b =>
                {
                    b.HasOne("app.Models.Entities.Usina", "Usina")
                        .WithMany("ProducoesDeEnergia")
                        .HasForeignKey("UsinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usina");
                });

            modelBuilder.Entity("app.Models.Entities.Usina", b =>
                {
                    b.HasOne("app.Models.Entities.Cidade", "Cidade")
                        .WithMany("Usinas")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Entities.Cliente", "Cliente")
                        .WithMany("Usinas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Entities.FonteDeEnergia", "FonteDeEnergia")
                        .WithMany()
                        .HasForeignKey("FonteDeEnergiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");

                    b.Navigation("FonteDeEnergia");
                });

            modelBuilder.Entity("app.Models.Entities.Usuario", b =>
                {
                    b.HasOne("app.Models.Entities.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("app.Models.Entities.Cidade", b =>
                {
                    b.Navigation("Usinas");
                });

            modelBuilder.Entity("app.Models.Entities.Cliente", b =>
                {
                    b.Navigation("Usinas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("app.Models.Entities.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("app.Models.Entities.Usina", b =>
                {
                    b.Navigation("ProducoesDeEnergia");
                });
#pragma warning restore 612, 618
        }
    }
}