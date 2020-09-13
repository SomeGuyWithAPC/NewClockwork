﻿// <auto-generated />
using System;
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clockwork.API.Migrations
{
    [DbContext(typeof(ClockworkContext))]
    [Migration("20200912183212_TimeZon")]
    partial class TimeZon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Clockwork.API.Models.CurrentTimeQuery", b =>
                {
                    b.Property<int>("CurrentTimeQueryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientIp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZoneId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UTCTime")
                        .HasColumnType("TEXT");

                    b.HasKey("CurrentTimeQueryId");

                    b.ToTable("CurrentTimeQueries");
                });
#pragma warning restore 612, 618
        }
    }
}
