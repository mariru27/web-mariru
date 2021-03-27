using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ITEC_WebApp.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    IdWheather = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.IdWheather);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    RoleIdRole = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleIdRole",
                        column: x => x.RoleIdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    UserIdUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                    table.ForeignKey(
                        name: "FK_Country_User_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountryIdCountry = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryIdCountry",
                        column: x => x.CountryIdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Weather_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Weather",
                        principalColumn: "IdWheather",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Covid",
                columns: table => new
                {
                    IdCovid = table.Column<int>(nullable: false),
                    ProcentageVaccination = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid", x => x.IdCovid);
                    table.ForeignKey(
                        name: "FK_Covid_Country_IdCovid",
                        column: x => x.IdCovid,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdHotel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CityIdCity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IdHotel);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityIdCity",
                        column: x => x.CityIdCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    IdRoom = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HotelIdHotel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.IdRoom);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelIdHotel",
                        column: x => x.HotelIdHotel,
                        principalTable: "Hotel",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryIdCountry",
                table: "City",
                column: "CountryIdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UserIdUser",
                table: "Country",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityIdCity",
                table: "Hotel",
                column: "CityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelIdHotel",
                table: "Room",
                column: "HotelIdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleIdRole",
                table: "User",
                column: "RoleIdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
