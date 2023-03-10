using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RiceCakeSoftware.CattleBreedersNotes.Api.Models;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
AppSettings appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>() ?? new();

// Add services to the container.
// AutoValidateAntiforgeryTokenのためにWithViews
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery((options) =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((options) =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = appSettings.Issuer,
        ValidAudience = appSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SigningKey)),
    };
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// テスト用にリダイレクトしない
//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

IAntiforgery antiforgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use((context, next) =>
{
    string? path = context.Request.Path.Value;
    if (path != null && path.ToLower().Contains("/api"))
    {
        AntiforgeryTokenSet token = antiforgery.GetAndStoreTokens(context);
        context.Response.Cookies.Append("XSRF-TOKEN", token.RequestToken!, new() { HttpOnly = false, Secure = true, });
    }
    return next(context);
});

app.MapControllers();

app.Run();
