using System.ComponentModel.DataAnnotations;

namespace CreditCardChallenge.Web.Models;

public class CardDetails
{
    [CreditCard]
    [Required]
    public string CardNumber { get; set; } = string.Empty;
    [Required]
    public string CardName { get; set; } = string.Empty;
    [StringLength(2)]
    [Required]
    public string Month { get; set; } = string.Empty;
    [StringLength(2)]
    [Required]
    public string Year { get; set; } = string.Empty;
    [MinLength(3)]
    [MaxLength(4)]
    [Required]
    public string Cvv { get; set; } = string.Empty;

    public CardType CardType { get; set; }

    
}

public enum CardType
{
    Visa = 1,
    Master = 2,
    Discover = 3
}
