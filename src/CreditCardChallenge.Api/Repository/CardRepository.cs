using CreditCardChallenge.Api.Data;
using CreditCardChallenge.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCardChallenge.Api.Repository;

public interface ICardRepository
{
    public Task<CardDetails> AddCard(CardDetails cardDetails);
    public Task<List<CardDetails>> GetCards();
}
public class CardRepository : ICardRepository
{
    private readonly AppDbContext _appDbContext;

    public CardRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<CardDetails> AddCard(CardDetails cardDetails)
    {
        _appDbContext.CardDetails.Add(cardDetails);
        await _appDbContext.SaveChangesAsync();
        return cardDetails;
    }

    public async Task<List<CardDetails>> GetCards()
    {
        return await _appDbContext.CardDetails.ToListAsync();
    }
}
