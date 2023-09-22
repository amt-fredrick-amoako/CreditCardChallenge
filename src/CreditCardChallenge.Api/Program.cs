using CreditCardChallenge.Api.Data;
using CreditCardChallenge.Api.Models;
using CreditCardChallenge.Api.Repository;
using CreditCardChallenge.Api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
});
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()!);
        policyBuilder.WithHeaders("origin", "accept", "content-type");
        policyBuilder.WithMethods("GET", "POST");
    });
});
builder.Services.AddValidatorsFromAssemblyContaining<CardDtoValidator>(ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

// Card validation endpoint
app.MapPost("/validate-card-number", async ([AsParameters] CardValidationRequest request) =>
{
    try
    {
        // make validation request to external api
        var response =
            await request.httpClient.GetAsync(
                $"https://hq-challenge.free.beeceptor.com/validate/creditcard/{request.cardDto.CardNumber}");

        // read response message from response
        var message = await response.Content.ReadAsStringAsync();

        // convert dto to card details
        var card = request.cardDto.ToCardDetails();

        card.Id = Guid.NewGuid();

        // add card to backing store
        var cardDetails = await request.cardRepository.AddCard(card);

        // return added card and message from external api
        return Results.Ok(new CardResponse
        {
            CardName = cardDetails.CardName,
            CardNumber = cardDetails.CardNumber,
            Cvv = cardDetails.Cvv,
            Month = cardDetails.Month,
            Year = cardDetails.Year,
            CardType = cardDetails.CardType,
            Message = message
        });
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message,
            request.context.Request.Path, StatusCodes.Status500InternalServerError);
    }

}).WithName("ValidateCard")
.WithOpenApi();

app.Run();

/// <summary>
/// Endpoint Parameters
/// </summary>
/// <param name="context"></param>
/// <param name="cardDto"></param>
/// <param name="httpClient"></param>
/// <param name="cardRepository"></param>
record CardValidationRequest(HttpContext context,
                             CardDto cardDto,
                             HttpClient httpClient,
                             ICardRepository cardRepository);