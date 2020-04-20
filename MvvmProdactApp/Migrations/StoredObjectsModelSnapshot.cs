﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvvmProdactApp.DataContext;

namespace MvvmProdactApp.Migrations
{
    [DbContext(typeof(StoredObjects))]
    partial class StoredObjectsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvvmProdactApp.Models.HierarchicalObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DataContainerId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataContainerId");

                    b.ToTable("HierarchicalObjects");

                    b.HasDiscriminator<string>("Discriminator").HasValue("HierarchicalObject");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LCstateId")
                        .HasColumnType("int");

                    b.Property<int?>("LiteraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("LCstateId");

                    b.HasIndex("LiteraId");

                    b.ToTable("ObjProperties");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProppsClasses.PropertyObj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("dbImage")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("_AbstractPropertyObjs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PropertyObj");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Annotation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("prodactObjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("prodactObjectId");

                    b.ToTable("ObjStructure");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.DataContainer", b =>
                {
                    b.HasBaseType("MvvmProdactApp.Models.HierarchicalObject");

                    b.HasDiscriminator().HasValue("DataContainer");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ProdactObject", b =>
                {
                    b.HasBaseType("MvvmProdactApp.Models.HierarchicalObject");

                    b.Property<int?>("PropsId")
                        .HasColumnType("int");

                    b.HasIndex("PropsId");

                    b.HasDiscriminator().HasValue("ProdactObject");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProppsClasses.LifeCycleState", b =>
                {
                    b.HasBaseType("MvvmProdactApp.Models.ObjProppsClasses.PropertyObj");

                    b.HasDiscriminator().HasValue("LifeCycleState");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProppsClasses.Litera", b =>
                {
                    b.HasBaseType("MvvmProdactApp.Models.ObjProppsClasses.PropertyObj");

                    b.HasDiscriminator().HasValue("Litera");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProppsClasses.ProdactClass", b =>
                {
                    b.HasBaseType("MvvmProdactApp.Models.ObjProppsClasses.PropertyObj");

                    b.HasDiscriminator().HasValue("ProdactClass");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.HierarchicalObject", b =>
                {
                    b.HasOne("MvvmProdactApp.Models.DataContainer", null)
                        .WithMany("Prodacts")
                        .HasForeignKey("DataContainerId");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjProperties", b =>
                {
                    b.HasOne("MvvmProdactApp.Models.ObjProppsClasses.ProdactClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("MvvmProdactApp.Models.ObjProppsClasses.LifeCycleState", "LCstate")
                        .WithMany()
                        .HasForeignKey("LCstateId");

                    b.HasOne("MvvmProdactApp.Models.ObjProppsClasses.Litera", "Litera")
                        .WithMany()
                        .HasForeignKey("LiteraId");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ObjStructure", b =>
                {
                    b.HasOne("MvvmProdactApp.Models.ProdactObject", "prodactObject")
                        .WithMany("Structure")
                        .HasForeignKey("prodactObjectId");
                });

            modelBuilder.Entity("MvvmProdactApp.Models.ProdactObject", b =>
                {
                    b.HasOne("MvvmProdactApp.Models.ObjProperties", "Props")
                        .WithMany()
                        .HasForeignKey("PropsId");
                });
#pragma warning restore 612, 618
        }
    }
}
