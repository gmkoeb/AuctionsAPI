using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<RocketseatAuctionDbContext>(options => 
{
    options.UseSqlite(@"Data Source=db\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
