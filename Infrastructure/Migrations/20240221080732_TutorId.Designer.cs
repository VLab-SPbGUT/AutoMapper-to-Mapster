﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20240221080732_TutorId")]
    partial class TutorId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AnswerOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnswerFormat")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptionNumber")
                        .HasColumnType("int");

                    b.Property<int>("OptionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("AnswerOption");
                });

            modelBuilder.Entity("Domain.Entities.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("CreditedDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsCredited")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TutorFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("CreditedDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ExerciseBlockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExerciseNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseVariant")
                        .HasColumnType("int");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<bool>("IsCredited")
                        .HasColumnType("bit");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarkType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseBlockId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("CreditedDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsCredited")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarkType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SubType")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ExerciseBlocks");
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("CreditedDate")
                        .HasColumnType("date");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<bool?>("IsCredited")
                        .HasColumnType("bit");

                    b.Property<int>("LessonNumber")
                        .HasColumnType("int");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarkType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Domain.Entities.AnswerOption", b =>
                {
                    b.HasOne("Domain.Entities.Exercise", "Exercise")
                        .WithMany("Answers")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Content", "Answer", b1 =>
                        {
                            b1.Property<Guid>("AnswerOptionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnswerOptionId");

                            b1.ToTable("AnswerOption");

                            b1.WithOwner()
                                .HasForeignKey("AnswerOptionId");
                        });

                    b.Navigation("Answer")
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Domain.Entities.Discipline", b =>
                {
                    b.OwnsOne("Domain.Entities.Student", "Student", b1 =>
                        {
                            b1.Property<Guid>("DisciplineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("GroupNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhotoUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ShortName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DisciplineId");

                            b1.ToTable("Disciplines");

                            b1.WithOwner()
                                .HasForeignKey("DisciplineId");
                        });

                    b.Navigation("Student")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.HasOne("Domain.Entities.ExerciseBlock", "ExerciseBlock")
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Content", "Example", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Content", "MethodicalInstructions", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Test", "Test", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.Navigation("Example")
                        .IsRequired();

                    b.Navigation("ExerciseBlock");

                    b.Navigation("MethodicalInstructions")
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseBlock", b =>
                {
                    b.HasOne("Domain.Entities.Lesson", "Lesson")
                        .WithMany("ExerciseBlocks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Content", "GeneralInformation", b1 =>
                        {
                            b1.Property<Guid>("ExerciseBlockId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseBlockId");

                            b1.ToTable("ExerciseBlocks");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseBlockId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Content", "Theory", b1 =>
                        {
                            b1.Property<Guid>("ExerciseBlockId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseBlockId");

                            b1.ToTable("ExerciseBlocks");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseBlockId");
                        });

                    b.Navigation("GeneralInformation")
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Theory")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.HasOne("Domain.Entities.Discipline", "Discipline")
                        .WithMany("Lessons")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Content", "Theory", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.Navigation("Discipline");

                    b.Navigation("Theory");
                });

            modelBuilder.Entity("Domain.Entities.Discipline", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseBlock", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.Navigation("ExerciseBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}
