
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NightWatchBackend.Database;
using NightWatchBackend.Repositories;
using NightWatchBackend.Services;

namespace NightWatchBackend
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

            builder.Services.AddDbContext<NightWatchDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //user
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRepository>();
            //movie
            builder.Services.AddScoped<MovieService>();
            builder.Services.AddScoped<MovieRepository>();
            //genre
            builder.Services.AddScoped<GenreService>();
            builder.Services.AddScoped<GenreRepository>();
           
            //mapper profile
            builder.Services.AddAutoMapper(x => x.AddProfile<MapperProfile>());
            var app = builder.Build();
            //middleware (fontos a sorrend!)
            app.UseMiddleware<LoggerWare>();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"img")),
                RequestPath = new PathString("/img")
            });


            app.MapControllers();

            app.Run();
        }
    }
}
