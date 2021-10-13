﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211012150945_photosEntity")]
    partial class photosEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Activity", b =>
                {
                    b.Property<long>("Activity_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity_Creation_Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Activity_Detail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Activity_ID");

                    b.ToTable("Activitiess");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.Property<long>("Message_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("message_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message_Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("message_content");

                    b.Property<DateTime>("Message_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 15, 9, 45, 84, DateTimeKind.Utc).AddTicks(5174))
                        .HasColumnName("message_creation_date");

                    b.Property<DateTime>("Message_Modified_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("message_modified_date");

                    b.Property<DateTime>("Message_Sent_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("message_sent_date");

                    b.Property<string>("Message_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("message_status");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Message_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("message");
                });

            modelBuilder.Entity("DAL.Entities.Photo", b =>
                {
                    b.Property<long>("Photo_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photo_Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Photo_ID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DAL.Entities.Point", b =>
                {
                    b.Property<long>("Point_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("point_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Point_Amount")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("0")
                        .HasColumnName("point_amount");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Point_ID");

                    b.HasIndex("User_ID")
                        .IsUnique();

                    b.ToTable("point");
                });

            modelBuilder.Entity("DAL.Entities.Reply", b =>
                {
                    b.Property<long>("Reply_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("reply_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Message_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Reply_Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("reply_content");

                    b.Property<DateTime>("Reply_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 15, 9, 45, 85, DateTimeKind.Utc).AddTicks(7630))
                        .HasColumnName("reply_creation_date");

                    b.Property<DateTime>("Reply_Modified_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("reply_modified_date");

                    b.Property<DateTime>("Reply_Sent_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("reply_sent_date");

                    b.Property<string>("Reply_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("reply_status");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Reply_ID");

                    b.HasIndex("Message_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("reply");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<long>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("User_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 15, 9, 45, 66, DateTimeKind.Utc).AddTicks(2562))
                        .HasColumnName("user_creation_date");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("user_email");

                    b.Property<string>("User_Profile_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_profile_name");

                    b.Property<string>("User_Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("username");

                    b.HasKey("User_ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Point", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithOne("Point")
                        .HasForeignKey("DAL.Entities.Point", "User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Reply", b =>
                {
                    b.HasOne("DAL.Entities.Message", "Message")
                        .WithMany("Replies")
                        .HasForeignKey("Message_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Replies")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Point");

                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
