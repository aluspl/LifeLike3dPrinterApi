﻿// <auto-generated />
using System;
using Database.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20231123202325_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("WolverineEnabled", "true");

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Filament.Filament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("FilamentType")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("Used")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Filaments", (string)null);
                });

            modelBuilder.Entity("Wolverine.EntityFrameworkCore.Internals.IncomingMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Attempts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("attempts");

                    b.Property<byte[]>("Body")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("body");

                    b.Property<DateTimeOffset?>("ExecutionTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("execution_time");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message_type");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.Property<string>("ReceivedAt")
                        .HasColumnType("text")
                        .HasColumnName("received_at");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("wolverine_incoming_envelopes", "wolverine", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Wolverine.EntityFrameworkCore.Internals.OutgoingMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Attempts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("attempts");

                    b.Property<byte[]>("Body")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("body");

                    b.Property<DateTimeOffset?>("DeliverBy")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deliver_by");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("destination");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message_type");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.HasKey("Id");

                    b.ToTable("wolverine_outgoing_envelopes", "wolverine", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Domain.Filament.Filament", b =>
                {
                    b.OwnsMany("Domain.Filament.FilamentItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("FilamentId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<DateTime>("Bought")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.HasKey("FilamentId", "Id");

                            b1.ToTable("Filaments");

                            b1.ToJson("Items");

                            b1.WithOwner()
                                .HasForeignKey("FilamentId");
                        });

                    b.OwnsMany("Domain.Filament.FilamentUsedItem", "UsedItems", b1 =>
                        {
                            b1.Property<Guid>("FilamentId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<DateTime>("UsedDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<int>("Weight")
                                .HasColumnType("integer");

                            b1.HasKey("FilamentId", "Id");

                            b1.ToTable("Filaments");

                            b1.ToJson("UsedItems");

                            b1.WithOwner()
                                .HasForeignKey("FilamentId");
                        });

                    b.Navigation("Items");

                    b.Navigation("UsedItems");
                });
#pragma warning restore 612, 618
        }
    }
}