﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AOP
//IoC Container -- Inversion of Control --> Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject
//AOP
//Postsharp --> ancak kurumsal ve ücretli altyapi mevcut

//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
    options.RegisterModule(new AutofacBusinessModule())
));

builder.Services.AddCors();     //API nin çalışması için injetcion

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

//Katmanlardan bagimsiz ama projenin calismasina etki eden modülleri asagiya "," ile ayirarak ekleyebiliriz.
builder.Services.AddDependecyResolvers(new ICoreModule[]
{
    new CoreModule() //,new securityModule(),new aspectModule gibi
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
