namespace CreditCardChallenge.Api.Models;

public class CardResponse
{
    public string CardNumber { get; set; }
    public string CardName { get; set; }

    public string Month { get; set; }

    public string Year { get; set; }

    public string Cvv { get; set; }

    public CardType CardType { get; set; }
    public string Message { get; set; }
}