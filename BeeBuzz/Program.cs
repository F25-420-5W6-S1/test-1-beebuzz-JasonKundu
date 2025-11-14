using BeeBuzz.Data;
using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using BeeBuzz.Data.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// added this Identity for the users
builder.Services.AddIdentity<ApplicationUsers, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllers();

builder.Services.AddTransient<BeeBuzzSeeder>(); // added seeder

builder.Services.AddScoped<IRepositoryProvider>(sp =>
{
    var context = sp.GetRequiredService<ApplicationDbContext>();
    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    return new RepositoryProvider(context, loggerFactory);
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var seeder = scope.ServiceProvider.GetRequiredService<BeeBuzzSeeder>();
            await seeder.Seed();
            Console.WriteLine("Database seeded successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine( "An error occurred while seeding the database");
        }
    }
}













app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();