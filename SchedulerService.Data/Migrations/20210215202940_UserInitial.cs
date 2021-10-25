using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchedulerService.Data.Migrations
{
    public partial class UserInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_name = table.Column<string>(nullable: true),
                    ds_surname = table.Column<string>(nullable: true),
                    ds_email = table.Column<string>(nullable: true),
                    ds_phone = table.Column<string>(nullable: true),
                    ds_password = table.Column<string>(nullable: true),
                    fl_active = table.Column<bool>(nullable: false),
                    fl_deleted = table.Column<bool>(nullable: false),
                    dt_birthday = table.Column<DateTime>(nullable: false),
                    dt_last_login = table.Column<DateTime>(nullable: false),
                    fl_validated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id_user);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
