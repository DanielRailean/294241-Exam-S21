﻿// <auto-generated />
using API.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(FootballContext))]
    [Migration("20210607090915_UpdatePlaper")]
    partial class UpdatePlaper
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("API.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoalsThisSeason")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salary")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShirtNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamRefTeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamName");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("API.Models.Team", b =>
                {
                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfCoach")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Ranking")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamName");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("API.Models.Player", b =>
                {
                    b.HasOne("API.Models.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamName");
                });

            modelBuilder.Entity("API.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}