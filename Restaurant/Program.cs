using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data;
using Restaurant.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddAppIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddAppService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.Run();
