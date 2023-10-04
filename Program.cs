using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MassageStudio.Data;
using MassageStudio.Areas.Identity.Data;
using MassageStudio.App.Services;
using MassageStudio.App.Services.Interaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Masseur" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var email = "admin@admin.com";
    var password = "Admin1234,";
    if (await userManeger.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.Email = email;
        user.UserName = email;
        user.EmailConfirmed = true;

        var response = await userManeger.CreateAsync(user, password);

        await userManeger.AddToRoleAsync(user, "Admin");
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var email = "masseur@masseur.com";
    var password = "Masseur1234,";
    if (await userManeger.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.Email = email;
        user.UserName = email;
        user.EmailConfirmed = true;

        var response = await userManeger.CreateAsync(user, password);

        await userManeger.AddToRoleAsync(user, "Masseur");
    }
}

app.Run();
