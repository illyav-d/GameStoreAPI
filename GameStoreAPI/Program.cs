using GameStoreAPI.Business.Services;
using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GameStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            InjectJWTAuthorisation(builder);
            InjectDatabase(builder);
            InjectAutoMapper(builder);
            InjectServices(builder);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }

        private static void InjectJWTAuthorisation(WebApplicationBuilder builder)
        {
            var config = builder.Configuration;
            // Add JWT Bearer Authentication
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings: Issuer"],
                    ValidAudience = config["JwtSettings: Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
        }

        private static void InjectDatabase(WebApplicationBuilder builder)
        {
            //Do not add connectionstring here in production!! This is sensitive information!!
            string connectionString = builder.Configuration.GetConnectionString("NZConnectionString");
            builder.Services.AddDbContext<GameStoreDBContext>(
                options => options.UseSqlServer(connectionString));
        }

        private static void InjectAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void InjectServices(WebApplicationBuilder builder)
        {
            //Add dependencies here:
            builder.Services.AddScoped<IGameProductRepository, GameProductRepository>();
            //builder.Services.AddScoped<IGenericRepository<GenreEntity>, GenericRepository<GenreEntity>>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IShoppingCartProductRepository, ShoppingCartProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IGameProductService, GameProductService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IPlatformService, PlatformService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IShoppingCartProductService, ShoppingCartProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
        }
    }
}
