using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using ProyectoFinalGourmetGrill.Components;
using ProyectoFinalGourmetGrill.Components.Account;
using ProyectoFinalGourmetGrill.Data;
using ProyectoFinalGourmetGrill.Services;
using Radzen;
using Shared.Interfaces;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options => {
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

// Configure DbContext with a connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

//Blob Services
var storageConnection = builder.Configuration["ConnectionStrings:GourmetGrill:Storage"];

builder.Services.AddAzureClients(azureBuilder => {
    azureBuilder.AddBlobServiceClient(storageConnection);
});

// Servicios
builder.Services.AddScoped<IServerAsp<ApplicationUser>, UsersService>();
builder.Services.AddScoped<IServerAsp<IdentityRole>, RolesService>();
builder.Services.AddScoped<IServerAsp<IdentityUserRole<string>>, UserRolesService>();
builder.Services.AddScoped<IServer<Productos>, ProductosService>();
builder.Services.AddScoped<IServer<CategoriaProductos>, CategoriaProductosService>();
builder.Services.AddScoped<IServer<Ordenes>, OrdenesService>();
builder.Services.AddScoped<IServer<Ventas>, VentasService>();
builder.Services.AddScoped<IServer<Estados>, EstadosService>();
builder.Services.AddScoped<IServer<MetodoPagos>, MetodosPagosService>();
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<MetodoPagos>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<IdentityUserService>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<NotificacionService>();

builder.Services.AddBlazorBootstrap();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
