using LearnChineseVue.Data;
using LearnChineseVue.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.Builder.Extensions;
using VueCliMiddleware;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.Repositories;
using LearnChineseVue.Services.Contracts;
using LearnChineseVue.Services;
using LearnChineseVue.Extensions;

namespace LearnChineseVue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //builder.Services.AddTransient<IPasswordValidator<ApplicationUser>,
            //    CustomPasswordValidator>(serv => new CustomPasswordValidator(6));
            builder.Services.AddScoped<IChineseWordApi, ChineseWordApi>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            builder.Services.AddScoped<IChineseWordsRepository, ChineseWordsRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IOrderNumChineseWordsRepository, OrderNumChineseWordsRepository>();

            var app = builder.Build();
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapFallbackToFile("index.html");
            app.UseHttpsRedirection();

            app.UseAuthorization();
            UpdateDatabase(app);

            app.MapControllers();
            //app.MapControllerRoute(
            //    name: "default",
            //pattern: "{controller=CRM}/{action=Index}/{id?}");
            app.Run();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                   // context.Database.Migrate();
                }
            }
        }
    }
}