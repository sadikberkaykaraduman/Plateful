using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Restorant.WebUI.Extension;

var builder = WebApplication.CreateBuilder(args);

// Define the authorization policy
var requireAuthorizePolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

// Add services to the container.
builder.Services.AddProjectServices();

// Add controllers with views and global authorization filter

// Configure cookie authentication

var app = builder.Build();

app.UseStatusCodePages(async statusCode =>
{
    if (statusCode.HttpContext.Response.StatusCode == 404)
    {
        statusCode.HttpContext.Response.Redirect("/Error/NotFound404Page");
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Default/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map area routes BEFORE the default route
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=About}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ShowCase}/{action=Index}/{id?}"
    );
});

app.Run();