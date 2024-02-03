//Create builder first.
using MahlanguMM_Assign1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configure Services
builder.Services.AddControllersWithViews();
//Repository
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();

//Data
//SQL Server
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
 name: "default",
 pattern: "{controller=Home}/{action=Index}/{id?}");
SeedData.EnsurePopulated(app);
app.Run();