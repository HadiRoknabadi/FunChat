using FunChat.Infrastructure.IoC;
using FunChat.Infrastructure.IdentityConfigs;
using FunChat.Infrastructure.MappingProfile;
using FluentValidation;
using FunChat.Application.DTOs.Account;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using FunChat.Application.Services.Interfaces;
using FunChat.Application.Services.Implementations;
using FunChat.Application.Services.Interfaces.Context;
using FunChat.Persistence.Contexts;
using FluentValidation.AspNetCore;
using FunChat.Infrastructure.Senders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddIdentityService();

builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<RegisterUserDTO>, RegisterUserValidator>();
builder.Services.AddTransient<IValidator<LoginUserDTO>, LoginUserValidator>();
builder.Services.AddScoped<IApplicationDbContext,ApplicationDbContext>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ISenderService,SenderService>();
builder.Services.AddScoped<IViewRenderService,ViewRenderService>();

#region Html Encoder

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));

#endregion



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
     name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
