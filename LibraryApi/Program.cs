using LibraryApi.EFcore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EF_DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


app.MapControllers();

app.Run();
