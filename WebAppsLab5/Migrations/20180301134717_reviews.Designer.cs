﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebAppsLab5.Models;

namespace WebAppsLab5.Migrations
{
    [DbContext(typeof(WebAppsLab5Context))]
    [Migration("20180301134717_reviews")]
    partial class reviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppsLab5.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price");

                    b.Property<string>("Rating")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("WebAppsLab5.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("comment");

                    b.Property<int?>("movieID");

                    b.Property<string>("name");

                    b.HasKey("ID");

                    b.HasIndex("movieID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WebAppsLab5.Models.Review", b =>
                {
                    b.HasOne("WebAppsLab5.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movieID");
                });
#pragma warning restore 612, 618
        }
    }
}
