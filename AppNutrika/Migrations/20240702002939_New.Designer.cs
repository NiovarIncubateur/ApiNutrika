﻿// <auto-generated />
using System;
using AppNutrika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppNutrika.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240702002939_New")]
    partial class New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppNutrika.Models.Entities.CategorieOfConsommation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("libelle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("categorieOfConsommation");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Consommation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<int>("categorieOfConsommationid")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("productionid")
                        .HasColumnType("int");

                    b.Property<int>("qteRestant")
                        .HasColumnType("int");

                    b.Property<int>("qteServie")
                        .HasColumnType("int");

                    b.Property<int>("qteUtilise")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categorieOfConsommationid");

                    b.HasIndex("productionid");

                    b.ToTable("consommation");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Materiels", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("qteReste")
                        .HasColumnType("int");

                    b.Property<int>("qteUtilise")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("materiels");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Observation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("observation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("productionid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productionid");

                    b.ToTable("observation");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Production", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("apportEau")
                        .HasColumnType("int");

                    b.Property<int>("apportProvende")
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("eauRestant")
                        .HasColumnType("int");

                    b.Property<int>("eauUtilise")
                        .HasColumnType("int");

                    b.Property<int>("effectifDepart")
                        .HasColumnType("int");

                    b.Property<int>("effectifFin")
                        .HasColumnType("int");

                    b.Property<int>("effectifMort")
                        .HasColumnType("int");

                    b.Property<string>("libelleTraitement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("observation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("poids")
                        .HasColumnType("int");

                    b.Property<int>("provendeRestant")
                        .HasColumnType("int");

                    b.Property<int>("provendeUtilise")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("production");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.RoleOfUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("creatAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("libelle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("roleOfUsers");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Traitement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("debut")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("libelleTraitement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("productionid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productionid");

                    b.ToTable("traitement");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("archived")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("etat")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("profile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("roleOfUserid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roleOfUserid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Consommation", b =>
                {
                    b.HasOne("AppNutrika.Models.Entities.CategorieOfConsommation", "categorieOfConsommation")
                        .WithMany()
                        .HasForeignKey("categorieOfConsommationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppNutrika.Models.Entities.Production", "production")
                        .WithMany()
                        .HasForeignKey("productionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categorieOfConsommation");

                    b.Navigation("production");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Observation", b =>
                {
                    b.HasOne("AppNutrika.Models.Entities.Production", "production")
                        .WithMany()
                        .HasForeignKey("productionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("production");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.Traitement", b =>
                {
                    b.HasOne("AppNutrika.Models.Entities.Production", "production")
                        .WithMany()
                        .HasForeignKey("productionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("production");
                });

            modelBuilder.Entity("AppNutrika.Models.Entities.User", b =>
                {
                    b.HasOne("AppNutrika.Models.Entities.RoleOfUser", "roleOfUser")
                        .WithMany()
                        .HasForeignKey("roleOfUserid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roleOfUser");
                });
#pragma warning restore 612, 618
        }
    }
}
