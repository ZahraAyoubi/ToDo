using ToDo.Web;
using ToDo.Web.Services;
using ToDo.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddHttpClient<IToDoListService, ToDoListService>();
builder.Services.AddHttpClient<IUserManagementService, UserManagementService>();
//SD.ToDoAPIListBase = builder.Configuration["ServiceUrls:ToDoListAPI"];
SD.UserManagementAPIBase = builder.Configuration["ServiceUrls:UserManagementAPI"];

//builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IUserManagementService,UserManagementService>(); 
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
 {
     options.DefaultScheme = "Cookies";
     options.DefaultChallengeScheme = "oidc";
 }).AddCookie("Cookies", c=>c.ExpireTimeSpan= TimeSpan.FromMinutes(10))
 .AddOpenIdConnect("oidc", options =>
 {
     options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"]; 
     options.GetClaimsFromUserInfoEndpoint = true;
     //options.ClientId = "todo";
     options.ClientId = "userManagement";
     options.ClientSecret = "secret";
     options.ResponseType = "code";
     options.TokenValidationParameters.NameClaimType = "name";
     options.TokenValidationParameters.RoleClaimType = "role";
     //options.Scope.Add("todo");
     options.Scope.Add("userManagement");
     options.SaveTokens = true;
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

app.Run();
