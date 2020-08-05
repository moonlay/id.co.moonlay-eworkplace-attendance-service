﻿// <auto-generated />
using EWorkplaceAbsensiService.Lib;
using EWorkplaceAbsensiService.Lib.Models.Enum;
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
    partial class AbsensiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Activityname")
                        .HasMaxLength(500);

                    b.Property<int>("CategoryId");

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

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.ToTable("ActivityCategory");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Medical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<double?>("ApprovedExpense");

                    b.Property<string>("Comments");

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

                    b.Property<string>("Desc");

                    b.Property<int>("Division");

                    b.Property<string>("FileUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("ReceiptDate");

                    b.Property<double>("ReportedExpense");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Medicals");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Other", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<double>("ApprovedExpense");

                    b.Property<string>("Comments");

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

                    b.Property<string>("Desc");

                    b.Property<int>("Division");

                    b.Property<string>("FileUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset>("ReceiptDate");

                    b.Property<double>("ReportedExpense");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Overtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<double>("ApprovedExpense");

                    b.Property<string>("Comments");

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

                    b.Property<string>("Desc");

                    b.Property<int>("Division");

                    b.Property<int>("Duration");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("FileUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("KindOfDay");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<double>("MealsReimbursment");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset>("OvertimeDate");

                    b.Property<double>("ReportedExpense");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("Status");

                    b.Property<double>("TransportReimbursment");

                    b.HasKey("Id");

                    b.ToTable("Overtimes");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ClientName");

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

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Report", b =>
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

                    b.Property<int>("ProjectId");

                    b.Property<int>("TimesheetId");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.TaskManangement", b =>
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

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("ManHour");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TaskDescription");

                    b.Property<string>("TaskDifficulty");

                    b.Property<string>("TaskName")
                        .HasMaxLength(500);

                    b.Property<int>("TaskPriority");

                    b.Property<int>("TaskStatus");

                    b.HasKey("Id");

                    b.ToTable("TaskManangement");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.TimeSheet", b =>
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

                    b.Property<TimeSpan>("Duration");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<int>("ProjectId");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<int>("TaskManagementId");

                    b.HasKey("Id");

                    b.ToTable("TimeSheet");
                });

            modelBuilder.Entity("EWorkplaceAbsensiService.Lib.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<double>("ApprovedExpense");

                    b.Property<string>("Comments");

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

                    b.Property<string>("DepartureLocation");

                    b.Property<string>("Desc");

                    b.Property<string>("DestinationLocation");

                    b.Property<int>("Division");

                    b.Property<string>("FileUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<DateTime>("ReceiptDate");

                    b.Property<double>("ReportedExpense");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });
#pragma warning restore 612, 618
        }
    }
}
