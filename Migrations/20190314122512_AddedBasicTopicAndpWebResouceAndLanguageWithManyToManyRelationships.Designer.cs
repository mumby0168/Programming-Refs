﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programming_Reference_Website.Persistance;

namespace ProgrammingReferenceWebsite.Migrations
{
    [DbContext(typeof(ProgrammingReferenceDbContext))]
    [Migration("20190314122512_AddedBasicTopicAndpWebResouceAndLanguageWithManyToManyRelationships")]
    partial class AddedBasicTopicAndpWebResouceAndLanguageWithManyToManyRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Programming_Reference_Website.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.TopicLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicLanguages");
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FreindlyName");

                    b.Property<byte[]>("Password");

                    b.Property<byte[]>("Salt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.WebResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LanguageId");

                    b.Property<int?>("TopicId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("TopicId");

                    b.ToTable("WebResources");
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.TopicLanguage", b =>
                {
                    b.HasOne("Programming_Reference_Website.Models.Language", "Language")
                        .WithMany("TopicLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Programming_Reference_Website.Models.Topic", "Topic")
                        .WithMany("TopicLanguages")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Programming_Reference_Website.Models.WebResource", b =>
                {
                    b.HasOne("Programming_Reference_Website.Models.Language")
                        .WithMany("WebResources")
                        .HasForeignKey("LanguageId");

                    b.HasOne("Programming_Reference_Website.Models.Topic")
                        .WithMany("WebResources")
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
