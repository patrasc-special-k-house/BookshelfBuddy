using BookshelfBuddy.Data.Repositories;
using BookshelfBuddy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace BookshelfBuddy.Settings
{
    public static class Dependencies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);

            applicationBuilder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            applicationBuilder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidIssuer = "BookshelfBuddy-Backend",
                    ValidAudience = "BookshelfBuddy-Anyone",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(applicationBuilder.Configuration["JWT:SecurityKey"]))
                };
            });
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<BookService>();
            services.AddScoped<ShelfService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<ShelfOwnersRepository>();
            services.AddScoped<BooksRepository>();
            services.AddScoped<ShelvesRepository>();
        }
    }
}
