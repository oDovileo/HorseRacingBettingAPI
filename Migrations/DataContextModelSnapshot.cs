﻿// <auto-generated />
using System;
using HorseRacingBettingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorseRacingBettingAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorseRacingBettingAPI.Entities.RaceBettorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HorseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HorseId");

                    b.ToTable("RaceBettors");
                });

            modelBuilder.Entity("HorseRacingBettingAPI.Entities.RaceHorseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RaceHorses");
                });

            modelBuilder.Entity("HorseRacingBettingAPI.Entities.RaceBettorModel", b =>
                {
                    b.HasOne("HorseRacingBettingAPI.Entities.RaceHorseModel", null)
                        .WithMany("RaceBettors")
                        .HasForeignKey("HorseId");
                });

            modelBuilder.Entity("HorseRacingBettingAPI.Entities.RaceHorseModel", b =>
                {
                    b.Navigation("RaceBettors");
                });
#pragma warning restore 612, 618
        }
    }
}