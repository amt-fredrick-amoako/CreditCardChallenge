using System.ComponentModel.DataAnnotations;

namespace CreditCardChallenge.Web.Models;

public class CardDetails
{
    [CreditCard]
    public string CardNumber { get; set; }
    [Required]
    public string CardName { get; set; }
    [StringLength(2)]
    public string Month { get; set; }
    [StringLength(2)]
    public string Year { get; set; }
    [StringLength(4)]
    public string Cvv { get; set; }

    public CardType CardType { get; set; }

    
}

public enum CardType
{
    Visa = 1,
    Master = 2,
    Discover = 3
}
