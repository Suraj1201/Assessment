using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedEmail = false;

})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.HttpOnly = true;
    opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    opts.LoginPath = "/Account/Login";
    opts.SlidingExpiration = true;
});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

async Task SeedRolesAndAdminAsync(IHost app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    const string adminRole = "Admin";
    const string userRole = "User";
    const string adminPassword = "Admin123$$$"; // Change this to a secure password

    // Create roles if they don't exist
    if (!await roleManager.RoleExistsAsync(adminRole))
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    if (!await roleManager.RoleExistsAsync(userRole))
        await roleManager.CreateAsync(new IdentityRole(userRole));

    // Create Admin user if it doesn't exist
    var admin = await userManager.FindByEmailAsync("admin");
    if (admin == null)
    {
        admin = new ApplicationUser
        {
            UserName = "admin",
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(admin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, adminRole);
        }
    }
}

// Call the seed method
await SeedRolesAndAdminAsync(app);

app.Run();
