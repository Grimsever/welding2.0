﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeldingV2._0.Models;

namespace WeldingV2._0.Migrations
{
    [DbContext(typeof(WeldingContext))]
    [Migration("20200324131937_UpdateDB")]
    partial class UpdateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.HasIndex("MachineDataId")
                        .IsUnique();

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("WeldingV2._0.Models.MachineData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("MachineDatas");
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
