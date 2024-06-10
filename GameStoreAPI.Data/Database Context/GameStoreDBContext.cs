using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Database_Context
{
    public class GameStoreDBContext : DbContext
    {
        public DbSet<GameProductEntity> GameProducts { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ShoppingCartProductEntity> ShoppingCartProducts { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }


        public GameStoreDBContext(DbContextOptions<GameStoreDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //seeding: dummy data 
        {
            base.OnModelCreating(modelBuilder);

            List<GameProductEntity> games = GenerateGameProducts();
            modelBuilder.Entity<GameProductEntity>().HasData(games);

            List<GenreEntity> genres = GenerateGenres();
            modelBuilder.Entity<GenreEntity>().HasData(genres);

            List<PlatformEntity> platforms = GeneratePlatforms();
            modelBuilder.Entity<PlatformEntity>().HasData(platforms);

            List<UserEntity> users = GenerateUsers();
            modelBuilder.Entity<UserEntity>().HasData(users);

            List<ShoppingCartProductEntity> shoppingCartProducts = GenerateShoppingCarts();
            modelBuilder.Entity<ShoppingCartProductEntity>().HasData(shoppingCartProducts);

            List<OrderEntity> orders = GenerateOrders();
            modelBuilder.Entity<OrderEntity>().HasData(orders);
        }

        public static void Main(string[] args)
        {
            List<GameProductEntity> games = GenerateGameProducts();
            List<GenreEntity> genres = GenerateGenres();
            List<PlatformEntity> platforms = GeneratePlatforms();
        }

        private static List<GameProductEntity> GenerateGameProducts()
        {
            var gameProductEntities = new List<GameProductEntity>()
            {
                new GameProductEntity()
                {
                    ID = 1,
                    Name = "The Legend of Zelda: Breath of the Wild",
                    Description = "The open-world reinvention of the action-adventure Zelda franchise.",
                    ReleaseDate = new DateTime(2017, 3, 3),
                    Developer = "Nintendo",
                    Publisher = "Nintendo",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/bhfrngj.jpg",
                    PriceInEuro = 59.99,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 1,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 2,
                    Name = "Metroid Dread",
                    Description = "The long-awaited next 2D main installment of the legendary Metroid franchise.",
                    ReleaseDate = new DateTime(2021, 10, 8),
                    Developer = "Mercury Steam, Nintendo EPD",
                    Publisher = "Nintendo",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/pP1Tu0b.jpg",
                    PriceInEuro = 59.99,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 5,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 3,
                    Name = "Sekiro: Shadows Die Twice",
                    Description = "A brutally difficult action-RPG set in fantasy Feudal Japan.",
                    ReleaseDate = new DateTime(2019, 3, 22),
                    Developer = "FromSoftware",
                    Publisher = "Activision",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/8Eru10D.jpg",
                    PriceInEuro = 59.99,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 3,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 4,
                    Name = "Elden Ring",
                    Description = "The open-world evolution of the classic action-RPG formula by the developer of Dark Souls.",
                    ReleaseDate = new DateTime(2022, 2, 25),
                    Developer = "FromSoftware",
                    Publisher = "Bandai Namco",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/WIdEXTt.jpg",
                    PriceInEuro = 59.99,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 1,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 5,
                    Name = "Halo Infinite",
                    Description = "The latest installment in Microsoft's scifi shooter franchise.",
                    ReleaseDate = new DateTime(2022, 2, 25),
                    Developer = "343 Industries",
                    Publisher = "Microsoft",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/tkjN1HC.jpg",
                    PriceInEuro = 49.98,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 4,
                    PlatformID = 4
                },
                new GameProductEntity()
                {
                    ID = 6,
                    Name = "Celeste",
                    Description = "A tough as nails platformer about a girl climbing a mountain.",
                    ReleaseDate = new DateTime(2018, 1, 25),
                    Developer = "Maddy Makes Games",
                    Publisher = "Maddy Makes Games",
                    MinimumAge = 7,
                    ImageURL = "https://imgur.com/SkvIdhv.jpg",
                    PriceInEuro = 19.99,
                    Stock = 12,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 9,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 7,
                    Name = "Diablo IV",
                    Description = "The legendary ARPG franchise returns in this open-world installment.",
                    ReleaseDate = new DateTime(2023, 6, 5),
                    Developer = "Blizzard Entertainment",
                    Publisher = "Blizzard Entertainment",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/2pfhksO.jpeg",
                    PriceInEuro = 49.99,
                    Stock = 25,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 1,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 8,
                    Name = "Hollow Knight",
                    Description = "Explore the lost ruins of an insectile civilization in this Metroidvania indie masterpiece.",
                    ReleaseDate = new DateTime(2017, 2, 24),
                    Developer = "Team Cherry",
                    Publisher = "Team Cherry",
                    MinimumAge = 7,
                    ImageURL = "https://imgur.com/ugHdnif.jpeg",
                    PriceInEuro = 14.99,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 5,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 9,
                    Name = "Spider-Man 2",
                    Description = "The sequel to Marvel's Spider-Man 2018 PS4 success.",
                    ReleaseDate = new DateTime(2023, 10, 20),
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/nljVEBu.jpg",
                    PriceInEuro = 49.99,
                    Stock = 20,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 3,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 10,
                    Name = "Silent Hill 2",
                    Description = "A remake of the PS2 classic horror game",
                    ReleaseDate = new DateTime(2024, 10, 8),
                    Developer = "Bloober Team",
                    Publisher = "Sony Interactive Entertainment",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/QwjVC62.jpg",
                    PriceInEuro = 69.98,
                    Stock = 0,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 6,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 11,
                    Name = "S.T.A.L.K.E.R. 2 - Heart of Chernobyl",
                    Description = "Experience the vastness of the Chernobyl quarantine zone filled with dangerous enemies, lost artifacts and anomalies.",
                    ReleaseDate = new DateTime(2024, 10, 8),
                    Developer = "GSC Game World",
                    Publisher = "Microsoft",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/GAKQ3Rs.jpg",
                    PriceInEuro = 69.98,
                    Stock = 20,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 4,
                    PlatformID = 5
                },
                new GameProductEntity()
                {
                    ID = 12,
                    Name = "Professor Layton and the New World of Steam",
                    Description = "Get ready for the next Layton puzzle filled adventure in a steampunk world.",
                    ReleaseDate = new DateTime(2025, 12, 31),
                    Developer = "Level 5",
                    Publisher = "Nintendo",
                    MinimumAge = 7,
                    ImageURL = "https://imgur.com/2vt76ij.jpg",
                    PriceInEuro = 49.99,
                    Stock = 0,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 10,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 13,
                    Name = "Super Mario Wonder",
                    Description = "A wacky and fresh return to 2D platforming Mario action!",
                    ReleaseDate = new DateTime(2023, 10, 20),
                    Developer = "Level 5",
                    Publisher = "Nintendo",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/jw9ewXs.jpg",
                    PriceInEuro = 48.99,
                    Stock = 13,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 9,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 14,
                    Name = "Fire Emblem: Engage!",
                    Description = "Team up with iconic heroes from past Fire Emblem entries in this celebratory entry in the turn-based strategy franchise.",
                    ReleaseDate = new DateTime(2023, 1, 20),
                    Developer = "Level 5",
                    Publisher = "Nintendo",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/R19vmF9.jpg",
                    PriceInEuro = 49.99,
                    Stock = 13,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 8,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 15,
                    Name = "Civilization VI",
                    Description = "Sid Meyer's classic strategy franchise returns in this newest installment.",
                    ReleaseDate = new DateTime(2016, 10, 21),
                    Developer = "Firaxis Games",
                    Publisher = "2K",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/9lILiqp.png",
                    PriceInEuro = 29.99,
                    Stock = 12,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 8,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 16,
                    Name = "Assassin's Creed: Mirage",
                    Description = "Assassin's Creed returns to its roots in this historical fiction epic set in Baghdad.",
                    ReleaseDate = new DateTime(2024, 1, 25),
                    Developer = "Ubisoft Montpellier",
                    Publisher = "Ubisoft",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/CQu33Wf.jpg",
                    PriceInEuro = 49.98,
                    Stock = 18,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 2,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 17,
                    Name = "Prince Of Persia: The Lost Crown",
                    Description = "Return to Persia in this new action 2D-platformer in the legendary Ubisoft franchise.",
                    ReleaseDate = new DateTime(2024, 1, 18),
                    Developer = "Ubisoft Montpellier",
                    Publisher = "Ubisoft",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/Yq5btuH.png",
                    PriceInEuro = 49.98,
                    Stock = 20,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 5,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 18,
                    Name = "Forza Motorsport",
                    Description = "Race with more than 500 different cars in 20 vibrant environments and try your hand at the new and improved Career mode.",
                    ReleaseDate = new DateTime(2023, 10, 10),
                    Developer = "Turn 10 Studios",
                    Publisher = "Microsoft",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/NDQnZLg.png",
                    PriceInEuro = 74.98,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 12,
                    PlatformID = 5
                },
                new GameProductEntity()
                {
                    ID = 19,
                    Name = "Need For Speed: Unbound",
                    Description = "Race against new rivals in this back-to-the-roots, stylized entry of Need For Speed.",
                    ReleaseDate = new DateTime(2022, 11, 29),
                    Developer = "Criterion Software",
                    Publisher = "Microsoft",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/DFOkCoX.jpg",
                    PriceInEuro = 29.98,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 12,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 20,
                    Name = "Shin Megami Tensei V: Vengeance",
                    Description = "A brand-new and expanded version of Shin Megami Tensei V. With a new alternate story branch.",
                    ReleaseDate = new DateTime(2024, 6, 14),
                    Developer = "Atlus",
                    Publisher = "Sega",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/JoXhKHF.jpg",
                    PriceInEuro = 59.98,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 2,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 21,
                    Name = "Titan Quest II",
                    Description = "Return to the Ancient Greece-inspired world of TitanQuest in this brand-new sequel!",
                    ReleaseDate = new DateTime(2024, 12, 31),
                    Developer = "Grimlore Games",
                    Publisher = "THQ Nordic",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/1HjHPRo.jpg",
                    PriceInEuro = 59.98,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 2,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 22,
                    Name = "God of War: Ragnarok",
                    Description = "Kratos returns on his Nordic quest in this sequel to the critically acclaimed God of War 2018 reboot.",
                    ReleaseDate = new DateTime(2024, 12, 31),
                    Developer = "Santa Monica Studios",
                    Publisher = "Sony Entertainment",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/Fmpx5OZ.jpg",
                    PriceInEuro = 79.98,
                    Stock = 15,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 3,
                    PlatformID = 3
                },
                new GameProductEntity()
                {
                    ID = 23,
                    Name = "Dragon Ball: FighterZ",
                    Description = "Fight your friends with your favourite Dragon Ball characters in this gorgeous 2D team-based fighter!",
                    ReleaseDate = new DateTime(2024, 12, 31),
                    Developer = "Arc System Works",
                    Publisher = "Bandai Namco Entertainment",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/6ExY4P2.png",
                    PriceInEuro = 19.98,
                    Stock = 8,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 11,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 24,
                    Name = "Alone In The Dark",
                    Description = "Psychological horror meets southern gothic aesthetics in this full remake of the original game.",
                    ReleaseDate = new DateTime(2024, 12, 31),
                    Developer = "Pieces Interactive",
                    Publisher = "THQ Nordic",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/HRONgc9.png",
                    PriceInEuro = 59.98,
                    Stock = 8,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 6,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 25,
                    Name = "Outcast: A New Beginning",
                    Description = "After 20 years, the non-linear open-world pioneer Outcast franchise returns.",
                    ReleaseDate = new DateTime(2024, 3, 15),
                    Developer = "Pieces Interactive",
                    Publisher = "THQ Nordic",
                    MinimumAge = 12,
                    ImageURL = "https://imgur.com/891a5Kq.jpeg",
                    PriceInEuro = 59.98,
                    Stock = 8,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 1,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 26,
                    Name = "EA Sport: F1 24",
                    Description = "High quality Formula 1 racing returns in this yearly installment.",
                    ReleaseDate = new DateTime(2024, 5, 31),
                    Developer = "CodeMasters",
                    Publisher = "EA",
                    MinimumAge = 3,
                    ImageURL = "https://imgur.com/WdivjwX.jpg",
                    PriceInEuro = 79.98,
                    Stock = 20,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 12,
                    PlatformID = 2
                },
                new GameProductEntity()
                {
                    ID = 27,
                    Name = "Stardew Valley",
                    Description = "Explore farming, mining and even finding love in this farming simulation RPG indie classic!",
                    ReleaseDate = new DateTime(2016, 2, 26),
                    Developer = "Concerned Ape",
                    Publisher = "Concerned Ape",
                    MinimumAge = 3,
                    ImageURL = "https://imgur.com/iVC44nm.png",
                    PriceInEuro = 14.99,
                    Stock = 13,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 7,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 28,
                    Name = "Sea Of Stars",
                    Description = "Prepare for a nostalgic throwback to the 90s with this modern, 16-bit JRPG inspired indie RPG.",
                    ReleaseDate = new DateTime(2024, 5, 10),
                    Developer = "Sabotage Studio",
                    Publisher = "Sabotage Studio",
                    MinimumAge = 7,
                    ImageURL = "https://imgur.com/zPIM5Ym.jpg",
                    PriceInEuro = 39.98,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 2,
                    PlatformID = 1
                },
                new GameProductEntity()
                {
                    ID = 29,
                    Name = "Tekken 8",
                    Description = "Kazuya returns with a vengeance in the new installment of the classic arcade fighter franchise!",
                    ReleaseDate = new DateTime(2024, 5, 10),
                    Developer = "Bandai Namco Studios",
                    Publisher = "Bandai Namco Entertainment",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/BBr6hDH.jpg",
                    PriceInEuro = 74.98,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 11,
                    PlatformID = 5
                },
                new GameProductEntity()
                {
                    ID = 30,
                    Name = "Among Us",
                    Description = "Who is the traitor of the crew? Try and find out in this co-operative multiplayer social game!",
                    ReleaseDate = new DateTime(2018, 6, 25),
                    Developer = "Inner Sloth",
                    Publisher = "Inner Sloth",
                    MinimumAge = 7,
                    ImageURL = "https://imgur.com/JY12lE8.png",
                    PriceInEuro = 19.98,
                    Stock = 10,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 13,
                    PlatformID = 6
                },
                new GameProductEntity()
                {
                    ID = 31,
                    Name = "Fallout 76",
                    Description = "The Massively Multiplayer Online installment of the Fallout franchise.",
                    ReleaseDate = new DateTime(2018, 11, 14),
                    Developer = "Bethesda Game Studios",
                    Publisher = "Bethesda",
                    MinimumAge = 18,
                    ImageURL = "https://imgur.com/JT8biBl.png",
                    PriceInEuro = 12.99,
                    Stock = 12,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 13,
                    PlatformID = 4
                },
                new GameProductEntity()
                {
                    ID = 32,
                    Name = "Lethal Company",
                    Description = "Collect loot for the Company with your friends and avoid getting fired...if you survive the trip that is.",
                    ReleaseDate = new DateTime(2018, 11, 14),
                    Developer = "Zeekers",
                    Publisher = "Zeekers",
                    MinimumAge = 16,
                    ImageURL = "https://imgur.com/uqnSZ39.jpg",
                    PriceInEuro = 9.99,
                    Stock = 12,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Active = true,
                    GenreID = 13,
                    PlatformID = 6
                },
            };
            return gameProductEntities;
        }

        private static List<GenreEntity> GenerateGenres()
        {
            var genreEntities = new List<GenreEntity>()
            {
                new GenreEntity()
                {
                    ID = 1,
                    Name = "Open-world",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 2,
                    Name = "RPG",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 3,
                    Name = "Action-Adventure",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 4,
                    Name = "First-Person-Shooter",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 5,
                    Name = "Metroidvania",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 6,
                    Name = "Horror",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 7,
                    Name = "Simulation",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 8,
                    Name = "Strategy",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 9,
                    Name = "Platformer",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 10,
                    Name = "Puzzle",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 11,
                    Name = "Fighting",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 12,
                    Name = "Racing",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new GenreEntity()
                {
                    ID = 13,
                    Name = "Multiplayer",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
            };

            return genreEntities;
        }

        private static List<PlatformEntity> GeneratePlatforms()
        {
            var platformEntities = new List<PlatformEntity>()
            {
                new PlatformEntity()
                {
                    ID = 1,
                    Name = "Nintendo Switch",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new PlatformEntity()
                {
                    ID = 2,
                    Name = "PlayStation 4",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new PlatformEntity()
                {
                    ID = 3,
                    Name = "PlayStation 5",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new PlatformEntity()
                {
                    ID = 4,
                    Name = "XBox One",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new PlatformEntity()
                {
                    ID = 5,
                    Name = "XBox Series X",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new PlatformEntity()
                {
                    ID = 6,
                    Name = "PC",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                }
            };

            return platformEntities;
        }

        private List<UserEntity> GenerateUsers()
        {
            var userEntities = new List<UserEntity>();
            userEntities.Add(new UserEntity()
            {
                ID = 1,
                Name = "Bart",
                Active = true,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            userEntities.Add(new UserEntity()
            {
                ID = 2,
                Name = "Illya",
                Active = true,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            userEntities.Add(new UserEntity()
            {
                ID = 3,
                Name = "Gilles",
                Active = true,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });

            return userEntities;
        }

        private List<ShoppingCartProductEntity> GenerateShoppingCarts()
        {
            var shoppingCartEntities = new List<ShoppingCartProductEntity>();

            shoppingCartEntities.Add(new ShoppingCartProductEntity()
            {
                ID = 1,
                Amount = 1,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                UserID = 1,
                GameProductID = 1,
            });
            shoppingCartEntities.Add(new ShoppingCartProductEntity()
            {
                ID = 2,
                Amount = 3,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                UserID = 2,
                GameProductID = 1,
            });
            shoppingCartEntities.Add(new ShoppingCartProductEntity()
            {
                ID = 3,
                Amount = 1,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                UserID = 1,
                GameProductID = 2,
            });

            return shoppingCartEntities;
        }
        private List<OrderEntity> GenerateOrders()
        {
            var orderEntities = new List<OrderEntity>();

            orderEntities.Add(new OrderEntity()
            {
                ID = 1,
                CustomerID = 1,
                TotalPriceInEuro = 150,
                GameTitles = "Elden Ring,GTA6",
                OrderDate = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now

            });
            orderEntities.Add(new OrderEntity()
            {
                ID = 2,
                CustomerID = 2,
                TotalPriceInEuro = 80,
                GameTitles = "Super Monkey Ball,Assassin's Creed: Mirage",
                OrderDate = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now

            });
            orderEntities.Add(new OrderEntity()
            {
                ID = 3,
                CustomerID = 3,
                TotalPriceInEuro = 69.99,
                GameTitles = "Final Fantasy VII: Rebirth",
                OrderDate = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now

            });
            return orderEntities;
        }
    }
}
