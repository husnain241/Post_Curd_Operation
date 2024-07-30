﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Post_Crud.Models;

#nullable disable

namespace Post_Crud.Migrations
{
    [DbContext(typeof(PostDBContext))]
    partial class PostDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Post_Crud.Models.Post", b =>
                {
                    b.Property<int>("Post_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Post_Id"));

                    b.Property<string>("Post_Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Post_Description");

                    b.Property<string>("Post_Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Post_Name");

                    b.HasKey("Post_Id");

                    b.ToTable("posts");
                });
#pragma warning restore 612, 618
        }
    }
}