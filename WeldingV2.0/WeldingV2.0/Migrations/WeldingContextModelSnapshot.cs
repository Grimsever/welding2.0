﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeldingV2._0.Models;

namespace WeldingV2._0.Migrations
{
    [DbContext(typeof(WeldingContext))]
    partial class WeldingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeldingV2._0.Models.Amperage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineDataId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MachineDataId");

                    b.ToTable("Amperages");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Foremen", b =>
                {
                    b.Property<int>("ForemenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForemenId");

                    b.ToTable("Foremen");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineDataId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineDataId")
                        .IsUnique();

                    b.HasIndex("TaskId")
                        .IsUnique()
                        .HasFilter("[TaskId] IS NOT NULL");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("WeldingV2._0.Models.MachineData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MachineDatas");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("TechMapId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("TechMapId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WeldingV2._0.Models.TechMap", b =>
                {
                    b.Property<int>("TechMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("MaxValueAmp")
                        .HasColumnType("float");

                    b.Property<double>("MaxValueVolt")
                        .HasColumnType("float");

                    b.Property<double>("MinValueAmp")
                        .HasColumnType("float");

                    b.Property<double>("MinValueVolt")
                        .HasColumnType("float");

                    b.HasKey("TechMapId");

                    b.ToTable("TechMaps");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Voltage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineDataId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MachineDataId");

                    b.ToTable("Voltages");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Workers", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForemenId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerId");

                    b.HasIndex("ForemenId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Amperage", b =>
                {
                    b.HasOne("WeldingV2._0.Models.MachineData", "MachineData")
                        .WithMany("Amperages")
                        .HasForeignKey("MachineDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeldingV2._0.Models.Machine", b =>
                {
                    b.HasOne("WeldingV2._0.Models.MachineData", "MachineData")
                        .WithOne("Machine")
                        .HasForeignKey("WeldingV2._0.Models.Machine", "MachineDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeldingV2._0.Models.Task", "Task")
                        .WithOne("Machine")
                        .HasForeignKey("WeldingV2._0.Models.Machine", "TaskId");
                });

            modelBuilder.Entity("WeldingV2._0.Models.Task", b =>
                {
                    b.HasOne("WeldingV2._0.Models.TechMap", "TechMap")
                        .WithMany("Tasks")
                        .HasForeignKey("TechMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeldingV2._0.Models.Workers", "Worker")
                        .WithMany("Task")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeldingV2._0.Models.Voltage", b =>
                {
                    b.HasOne("WeldingV2._0.Models.MachineData", "MachineData")
                        .WithMany("Voltages")
                        .HasForeignKey("MachineDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeldingV2._0.Models.Workers", b =>
                {
                    b.HasOne("WeldingV2._0.Models.Foremen", "Foremen")
                        .WithMany("Workers")
                        .HasForeignKey("ForemenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
