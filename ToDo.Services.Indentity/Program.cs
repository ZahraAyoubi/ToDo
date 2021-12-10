using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDo.Services.Indentity;
using ToDo.Services.Indentity.DbContexts;
using ToDo.Services.Indentity.Initializer;
using ToDo.Services.Indentity.Models;
using ToDo.Services.Indentity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=ToDoIdentityServer");
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var bldr = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(SD.IdentityResources)
.AddInMemoryApiScopes(SD.ApiScopes)
.AddInMemoryClients(SD.Clients)
.AddAspNetIdentity<ApplicationUser>();


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();

bldr.AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    IDbInitializer dbInitializer = services.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}


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

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
