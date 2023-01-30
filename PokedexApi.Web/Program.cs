using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infra;
using PokedexApi.Infra.Implements;
using PokedexApi.Web.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContextPool<DataContext>(opt =>
                opt.UseMySql(mySqlConnection,ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(typeof(DomainProfile));

builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<IWeaknessRepository, WeaknessRepository>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ISpecialStageRepository, SpecialStageRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbContext.Database.EnsureCreated();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();