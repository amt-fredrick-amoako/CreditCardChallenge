namespace CreditCardChallenge.Web.Models;

public class CardDetails
{

    public string CardNumber { get; set; }

    public string CardName { get; set; }

    public string Month { get; set; }

    public string Year { get; set; }

    public string Cvv { get; set; }

    public CardType CardType { get; set; }


}

public enum CardType
{
    Visa = 1,
    Master = 2,
    Discover = 3
}
