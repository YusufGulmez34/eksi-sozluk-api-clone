using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozlukAPI.Persistence.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "channel",
                columns: table => new
                {
                    ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_channel", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "title",
                columns: table => new
                {
                    ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    channel_ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    entry_count = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_title", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_title_channel_channel_ıd",
                        column: x => x.channel_ıd,
                        principalTable: "channel",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role_ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_user_role_role_ıd",
                        column: x => x.role_ıd,
                        principalTable: "role",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entry",
                columns: table => new
                {
                    ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    like = table.Column<int>(type: "integer", nullable: false),
                    dislike = table.Column<int>(type: "integer", nullable: false),
                    title_ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    user_ıd = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entry", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_entry_title_title_ıd",
                        column: x => x.title_ıd,
                        principalTable: "title",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_entry_user_user_ıd",
                        column: x => x.user_ıd,
                        principalTable: "user",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ıx_entry_title_ıd",
                table: "entry",
                column: "title_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_entry_user_ıd",
                table: "entry",
                column: "user_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_title_channel_ıd",
                table: "title",
                column: "channel_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_user_role_ıd",
                table: "user",
                column: "role_ıd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entry");

            migrationBuilder.DropTable(
                name: "title");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "channel");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
