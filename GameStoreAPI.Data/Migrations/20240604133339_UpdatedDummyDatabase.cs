using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStoreAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDummyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    TotalPriceInEuro = table.Column<double>(type: "float", nullable: false),
                    GameTitles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MinimumAge = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PriceInEuro = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    PlatformID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameProducts_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameProducts_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GameProductID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_GameProducts_GameProductID",
                        column: x => x.GameProductID,
                        principalTable: "GameProducts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2376), "Open-world", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2380) },
                    { 2, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2384), "RPG", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2385) },
                    { 3, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2387), "Action-Adventure", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2389) },
                    { 4, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2391), "First-Person-Shooter", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2392) },
                    { 5, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2394), "Metroidvania", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2395) },
                    { 6, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2398), "Horror", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2400) },
                    { 7, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2402), "Simulation", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2403) },
                    { 8, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2405), "Strategy", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2406) },
                    { 9, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2408), "Platformer", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2409) },
                    { 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2412), "Puzzle", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2414) },
                    { 11, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2415), "Fighting", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2417) },
                    { 12, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2419), "Racing", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2420) },
                    { 13, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2422), "Multiplayer", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2423) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "CustomerID", "GameTitles", "OrderDate", "TotalPriceInEuro", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2597), 1, "Elden Ring,GTA6", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2595), 150.0, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2599) },
                    { 2, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2604), 2, "Super Monkey Ball,Assassin's Creed: Mirage", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2603), 80.0, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2606) },
                    { 3, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2609), 3, "Final Fantasy VII: Rebirth", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2608), 69.989999999999995, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2610) }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "ID", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2463), "Nintendo Switch", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2467) },
                    { 2, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2472), "PlayStation 4", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2473) },
                    { 3, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2475), "PlayStation 5", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2477) },
                    { 4, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2479), "XBox One", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2480) },
                    { 5, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2482), "XBox Series X", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2484) },
                    { 6, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2487), "PC", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2488) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Active", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2520), "Bart", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2522) },
                    { 2, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2526), "Illya", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2527) },
                    { 3, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2529), "Gilles", new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2531) }
                });

            migrationBuilder.InsertData(
                table: "GameProducts",
                columns: new[] { "ID", "Active", "Created", "Description", "Developer", "GenreID", "ImageURL", "MinimumAge", "Name", "PlatformID", "PriceInEuro", "Publisher", "ReleaseDate", "Stock", "Updated" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(1987), "The open-world reinvention of the action-adventure Zelda franchise.", "Nintendo", 1, "https://imgur.com/bhfrngj.jpg", 12, "The Legend of Zelda: Breath of the Wild", 1, 59.990000000000002, "Nintendo", new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2030) },
                    { 2, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2039), "The long-awaited next 2D main installment of the legendary Metroid franchise.", "Mercury Steam, Nintendo EPD", 5, "https://imgur.com/pP1Tu0b.jpg", 12, "Metroid Dread", 2, 59.990000000000002, "Nintendo", new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2040) },
                    { 3, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2043), "A brutally difficult action-RPG set in fantasy Feudal Japan.", "FromSoftware", 3, "https://imgur.com/8Eru10D.jpg", 18, "Sekiro: Shadows Die Twice", 2, 59.990000000000002, "Activision", new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2045) },
                    { 4, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2048), "The open-world evolution of the classic action-RPG formula by the developer of Dark Souls.", "FromSoftware", 1, "https://imgur.com/WIdEXTt.jpg", 16, "Elden Ring", 3, 59.990000000000002, "Bandai Namco", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2049) },
                    { 5, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2052), "The latest installment in Microsoft's scifi shooter franchise.", "343 Industries", 4, "https://imgur.com/tkjN1HC.jpg", 12, "Halo Infinite", 4, 49.979999999999997, "Microsoft", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2055) },
                    { 6, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2061), "A tough as nails platformer about a girl climbing a mountain.", "Maddy Makes Games", 9, "https://imgur.com/SkvIdhv.jpg", 7, "Celeste", 1, 19.989999999999998, "Maddy Makes Games", new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2062) },
                    { 7, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2065), "The legendary ARPG franchise returns in this open-world installment.", "Blizzard Entertainment", 1, "https://imgur.com/2pfhksO.jpeg", 18, "Diablo IV", 6, 49.990000000000002, "Blizzard Entertainment", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2067) },
                    { 8, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2073), "Explore the lost ruins of an insectile civilization in this Metroidvania indie masterpiece.", "Team Cherry", 5, "https://imgur.com/ugHdnif.jpeg", 7, "Hollow Knight", 2, 14.99, "Team Cherry", new DateTime(2017, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2074) },
                    { 9, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2077), "The sequel to Marvel's Spider-Man 2018 PS4 success.", "Insomniac Games", 3, "https://imgur.com/nljVEBu.jpg", 16, "Spider-Man 2", 3, 49.990000000000002, "Sony Interactive Entertainment", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2078) },
                    { 10, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2083), "A remake of the PS2 classic horror game", "Bloober Team", 6, "https://imgur.com/QwjVC62.jpg", 18, "Silent Hill 2", 3, 69.980000000000004, "Sony Interactive Entertainment", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2084) },
                    { 11, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2088), "Experience the vastness of the Chernobyl quarantine zone filled with dangerous enemies, lost artifacts and anomalies.", "GSC Game World", 4, "https://imgur.com/GAKQ3Rs.jpg", 18, "S.T.A.L.K.E.R. 2 - Heart of Chernobyl", 5, 69.980000000000004, "Microsoft", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2089) },
                    { 12, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2092), "Get ready for the next Layton puzzle filled adventure in a steampunk world.", "Level 5", 10, "https://imgur.com/2vt76ij.jpg", 7, "Professor Layton and the New World of Steam", 1, 49.990000000000002, "Nintendo", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2093) },
                    { 13, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2097), "A wacky and fresh return to 2D platforming Mario action!", "Level 5", 9, "https://imgur.com/jw9ewXs.jpg", 12, "Super Mario Wonder", 1, 48.990000000000002, "Nintendo", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2098) },
                    { 14, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2101), "Team up with iconic heroes from past Fire Emblem entries in this celebratory entry in the turn-based strategy franchise.", "Level 5", 8, "https://imgur.com/R19vmF9.jpg", 12, "Fire Emblem: Engage!", 1, 49.990000000000002, "Nintendo", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2102) },
                    { 15, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2106), "Sid Meyer's classic strategy franchise returns in this newest installment.", "Firaxis Games", 8, "https://imgur.com/9lILiqp.png", 12, "Civilization VI", 6, 29.989999999999998, "2K", new DateTime(2016, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2107) },
                    { 16, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2111), "Assassin's Creed returns to its roots in this historical fiction epic set in Baghdad.", "Ubisoft Montpellier", 2, "https://imgur.com/CQu33Wf.jpg", 18, "Assassin's Creed: Mirage", 3, 49.979999999999997, "Ubisoft", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2112) },
                    { 17, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2115), "Return to Persia in this new action 2D-platformer in the legendary Ubisoft franchise.", "Ubisoft Montpellier", 5, "https://imgur.com/Yq5btuH.png", 16, "Prince Of Persia: The Lost Crown", 2, 49.979999999999997, "Ubisoft", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2116) },
                    { 18, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2121), "Race with more than 500 different cars in 20 vibrant environments and try your hand at the new and improved Career mode.", "Turn 10 Studios", 12, "https://imgur.com/NDQnZLg.png", 12, "Forza Motorsport", 5, 74.980000000000004, "Microsoft", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2122) },
                    { 19, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2126), "Race against new rivals in this back-to-the-roots, stylized entry of Need For Speed.", "Criterion Software", 12, "https://imgur.com/DFOkCoX.jpg", 12, "Need For Speed: Unbound", 3, 29.98, "Microsoft", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2127) },
                    { 20, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2130), "A brand-new and expanded version of Shin Megami Tensei V. With a new alternate story branch.", "Atlus", 2, "https://imgur.com/JoXhKHF.jpg", 16, "Shin Megami Tensei V: Vengeance", 1, 59.979999999999997, "Sega", new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2131) },
                    { 21, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2134), "Return to the Ancient Greece-inspired world of TitanQuest in this brand-new sequel!", "Grimlore Games", 2, "https://imgur.com/1HjHPRo.jpg", 12, "Titan Quest II", 6, 59.979999999999997, "THQ Nordic", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2136) },
                    { 22, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2139), "Kratos returns on his Nordic quest in this sequel to the critically acclaimed God of War 2018 reboot.", "Santa Monica Studios", 3, "https://imgur.com/Fmpx5OZ.jpg", 18, "God of War: Ragnarok", 3, 79.980000000000004, "Sony Entertainment", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2140) },
                    { 23, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2143), "Fight your friends with your favourite Dragon Ball characters in this gorgeous 2D team-based fighter!", "Arc System Works", 11, "https://imgur.com/6ExY4P2.png", 12, "Dragon Ball: FighterZ", 2, 19.98, "Bandai Namco Entertainment", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2144) },
                    { 24, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2147), "Psychological horror meets southern gothic aesthetics in this full remake of the original game.", "Pieces Interactive", 6, "https://imgur.com/HRONgc9.png", 18, "Alone In The Dark", 6, 59.979999999999997, "THQ Nordic", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2149) },
                    { 25, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2152), "After 20 years, the non-linear open-world pioneer Outcast franchise returns.", "Pieces Interactive", 1, "https://imgur.com/891a5Kq.jpeg", 12, "Outcast: A New Beginning", 6, 59.979999999999997, "THQ Nordic", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2153) },
                    { 26, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2156), "High quality Formula 1 racing returns in this yearly installment.", "CodeMasters", 12, "https://imgur.com/WdivjwX.jpg", 3, "EA Sport: F1 24", 2, 79.980000000000004, "EA", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2158) },
                    { 27, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2161), "Explore farming, mining and even finding love in this farming simulation RPG indie classic!", "Concerned Ape", 7, "https://imgur.com/iVC44nm.png", 3, "Stardew Valley", 6, 14.99, "Concerned Ape", new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2163) },
                    { 28, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2165), "Prepare for a nostalgic throwback to the 90s with this modern, 16-bit JRPG inspired indie RPG.", "Sabotage Studio", 2, "https://imgur.com/zPIM5Ym.jpg", 7, "Sea Of Stars", 1, 39.979999999999997, "Sabotage Studio", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2167) },
                    { 29, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2170), "Kazuya returns with a vengeance in the new installment of the classic arcade fighter franchise!", "Bandai Namco Studios", 11, "https://imgur.com/BBr6hDH.jpg", 16, "Tekken 8", 5, 74.980000000000004, "Bandai Namco Entertainment", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2171) },
                    { 30, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2175), "Who is the traitor of the crew? Try and find out in this co-operative multiplayer social game!", "Inner Sloth", 13, "https://imgur.com/JY12lE8.png", 7, "Among Us", 6, 19.98, "Inner Sloth", new DateTime(2018, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2176) },
                    { 31, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2179), "The Massively Multiplayer Online installment of the Fallout franchise.", "Bethesda Game Studios", 13, "https://imgur.com/JT8biBl.png", 18, "Fallout 76", 4, 12.99, "Bethesda", new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2180) },
                    { 32, true, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2183), "Collect loot for the Company with your friends and avoid getting fired...if you survive the trip that is.", "Zeekers", 13, "https://imgur.com/uqnSZ39.jpg", 16, "Lethal Company", 6, 9.9900000000000002, "Zeekers", new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2185) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartProducts",
                columns: new[] { "ID", "Amount", "Created", "GameProductID", "Updated", "UserID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2558), 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2560), 1 },
                    { 2, 3, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2566), 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2567), 2 },
                    { 3, 1, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2570), 2, new DateTime(2024, 6, 4, 15, 33, 38, 987, DateTimeKind.Local).AddTicks(2571), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProducts_GenreID",
                table: "GameProducts",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_GameProducts_PlatformID",
                table: "GameProducts",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_GameProductID",
                table: "ShoppingCartProducts",
                column: "GameProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_UserID",
                table: "ShoppingCartProducts",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCartProducts");

            migrationBuilder.DropTable(
                name: "GameProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
