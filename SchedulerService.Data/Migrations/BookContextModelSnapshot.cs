// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchedulerService.Data.Context;

namespace SchedulerService.Data.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SchedulerService.Data.Model.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_user")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DsEmail")
                        .HasColumnName("ds_email")
                        .HasColumnType("text");

                    b.Property<string>("DsName")
                        .HasColumnName("ds_name")
                        .HasColumnType("text");

                    b.Property<string>("DsPassword")
                        .HasColumnName("ds_password")
                        .HasColumnType("text");

                    b.Property<string>("DsPhone")
                        .HasColumnName("ds_phone")
                        .HasColumnType("text");

                    b.Property<string>("DsSurname")
                        .HasColumnName("ds_surname")
                        .HasColumnType("text");

                    b.Property<DateTime>("DtBirthday")
                        .HasColumnName("dt_birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DtLastLogin")
                        .HasColumnName("dt_last_login")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("FlActive")
                        .HasColumnName("fl_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("FlDeleted")
                        .HasColumnName("fl_deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("FlValidated")
                        .HasColumnName("fl_validated")
                        .HasColumnType("boolean");

                    b.HasKey("IdUser");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
