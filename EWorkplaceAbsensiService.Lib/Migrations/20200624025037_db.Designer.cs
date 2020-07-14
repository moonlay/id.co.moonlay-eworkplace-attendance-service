﻿// <auto-generated />
using EWorkplaceAbsensiService.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    [DbContext(typeof(AbsensiDbContext))]
    [Migration("20200624025037_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Absensi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Approval");

                    b.Property<string>("ApprovalByAdmin");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<string>("ClientName");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<string>("HeadDivision");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<string>("Note");

                    b.Property<string>("Photo");

                    b.Property<string>("ProjectName");

                    b.Property<string>("State");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Absensis");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("ActivityCategoryId");

                    b.Property<string>("Activityname")
                        .HasMaxLength(500);

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("description");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCategoryId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.ActivityCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Category")
                        .HasMaxLength(500);

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("description");

                    b.HasKey("Id");

                    b.ToTable("ActivityCategory");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("contract");

                    b.Property<string>("projectName")
                        .HasMaxLength(500);

                    b.Property<int>("status");

                    b.Property<string>("workType");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.TaskManangement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("ActivityCategoryId");

                    b.Property<int?>("ActivityId");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<int>("ManHour");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("TaskName")
                        .HasMaxLength(500);

                    b.Property<int>("TaskPriority");

                    b.Property<string>("TaskStatus");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCategoryId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TaskManangement");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Timer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeName");

                    b.Property<TimeSpan>("End");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("TaskManangementId");

                    b.Property<DateTime>("date")
                        .HasMaxLength(500);

                    b.Property<TimeSpan>("start");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskManangementId");

                    b.ToTable("Timer");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Activity", b =>
                {
                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.ActivityCategory", "ActivityCategory")
                        .WithMany()
                        .HasForeignKey("ActivityCategoryId");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.TaskManangement", b =>
                {
                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.ActivityCategory", "ActivityCategory")
                        .WithMany()
                        .HasForeignKey("ActivityCategoryId");

                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Timer", b =>
                {
                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("EWorkplaceAbsensiService.Lib.Models.TaskManangement", "TaskManangement")
                        .WithMany()
                        .HasForeignKey("TaskManangementId");
                });
#pragma warning restore 612, 618
        }
    }
}
